using CampMultigames.Application.Dtos.Input;
using CampMultigames.Application.Interfaces;
using CampMultigames.Domain.Interfaces;
using CampMultigames.Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CampMultigames.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ConfrontoController : ControllerBase
{
    private readonly IConfrontoService _confrontoService;
    private readonly IBaseService<ConfrontoFfa> _confrontoFfaService;
    private readonly ITimeService _timeService;
    private readonly IJogoService _jogoService;
    private readonly ITabelaGeralService _tabelaGeralService;
    private readonly ITabelaPorJogoTabelaService _tabelaPorJogoTabelaService;
    private readonly ITabelaPorJogoFfaService _tabelaPorJogoFfaService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPontosPorColocacaoService _pontosPorColocacaoService;

    public ConfrontoController(IConfrontoService confrontoService, ITimeService timeService, IJogoService jogoService, IUnitOfWork unitOfWork, ITabelaGeralService tabelaGeralService, ITabelaPorJogoTabelaService tabelaPorJogoTabelaService, ITabelaPorJogoFfaService tabelaPorJogoFfaService, IPontosPorColocacaoService pontosPorColocacaoService, IBaseService<ConfrontoFfa> confrontoFfaService)
    {
        _confrontoService = confrontoService;
        _timeService = timeService;
        _jogoService = jogoService;
        _unitOfWork = unitOfWork;
        _tabelaGeralService = tabelaGeralService;
        _tabelaPorJogoTabelaService = tabelaPorJogoTabelaService;
        _tabelaPorJogoFfaService = tabelaPorJogoFfaService;
        _pontosPorColocacaoService = pontosPorColocacaoService;
        _confrontoFfaService = confrontoFfaService;
    }
    
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        try
        {
            return Ok(await _confrontoService.GetAllAsync());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet]
    [Route("{confrontoId}")]
    public async Task<ActionResult> GetById(int confrontoId)
    {
        try
        {
            return Ok(await _confrontoService.GetByIdAsync(confrontoId));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet]
    [Route("/futuros")]
    public async Task<ActionResult> GetFuturos()
    {
        try
        {
            return Ok(await _confrontoService.GetFuturosAsync());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet]
    [Route("/passados")]
    public async Task<ActionResult> GetPassados()
    {
        try
        {
            return Ok(await _confrontoService.GetPassadosAsync());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet]
    [Route("time/futuros/{timeId}")]
    public async Task<ActionResult> GetFuturosByTime(int timeId)
    {
        try
        {
            return Ok(await _confrontoService.GetFuturosByTimeAsync(timeId));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet]
    [Route("time/passados/{timeId}")]
    public async Task<ActionResult> GetPassadosByTime(int timeId)
    {
        try
        {
            return Ok(await _confrontoService.GetPassadosByTimeAsync(timeId));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost("GenerateAll")]
    public async Task<IActionResult> GenerateAll()
    {
        try
        {
            var times = await _timeService.GetAllAsync();
            var jogoTabela = await _jogoService.GetAllTabelaAsync();
            var jogoFfa = await _jogoService.GetAllFfaAsync();
            
            // Cria todos os confrontos
            await _confrontoService.CreateAllAsync(times, jogoTabela);
            
            // Cria os times nas tabelas
            await _tabelaGeralService.CreateAllAsync(times);
            await _tabelaPorJogoTabelaService.CreateAllAsync(times, jogoTabela);
            await _tabelaPorJogoFfaService.CreateAllAsync(times, jogoFfa);
            
            // Cria Pontuação dos times Ffa
            await _pontosPorColocacaoService.CreateAllAsync(jogoFfa);
            
            // Salva e retorna
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPut("tabela/{confrontoId}")]
    public async Task<IActionResult> UpdateConfronto(int confrontoId, ConfrontoDto confrontoDto)
    {
        try
        {
            // Verifica se o confronto existe
            var confronto = await _confrontoService.GetByIdAsync(confrontoId);
            if (confronto == null) 
                return NotFound("Confronto not found");
            
            // Cria os mapas
            var mapasDto = new List<MapaDto?>{ confrontoDto.Mapa1, confrontoDto.Mapa2, confrontoDto.Mapa3 };

            // Contador para verificar mapas validos
            var contar = 0;
            
            // Percorre os mapas enviados
            foreach (var mapaDto in mapasDto)
            {
                
                // Verifica se o mapa existe
                if (mapaDto == null)
                {
                    // Aumenta o contador 
                    contar++;
                    if (contar == 2)
                        return BadRequest("Mapa1 and Mapa2 are required");
                    continue;
                }
                
                // Verifica se o Id do time que pikou o mapa é presente no confronto
                if (mapaDto.TimePickId != confronto.TimeCasaId && mapaDto.TimePickId != confronto.TimeForaId)
                    return BadRequest("TimePickId is different from TimeCasaId and TimeForaId");
                
                // Mapeia o mapa
                var result = mapaDto.Adapt<Mapa>();
                result.Confronto = confronto;
                
                // Atribui o mapa ao confronto
                confronto.Mapas.Add(result);
            }
            
            // Atribui os dados
            confronto.PontosCasa = confrontoDto.PontosCasa;
            confronto.PontosFora = confrontoDto.PontosFora;
            confronto.Data = confrontoDto.Data;
            
            // Atualiza o confront
            _confrontoService.Update(confronto);

            // Atualiza as tabelas conforme o vencedor do confronto
            if (confronto.PontosCasa > confronto.PontosFora)
            {
                await _tabelaGeralService.UpdateWinner(confronto.TimeCasa, confronto.JogoTabela.pontosPorGame);
                await _tabelaGeralService.UpdateLooser(confronto.TimeFora);
                await _tabelaPorJogoTabelaService.UpdateWinner(confronto.TimeCasa,confronto.JogoTabela.pontosPorGame, confronto.JogoTabela);
                await _tabelaPorJogoTabelaService.UpdateLooser(confronto.TimeFora, confronto.JogoTabela);
            }
            else
            {
                await _tabelaGeralService.UpdateWinner(confronto.TimeFora, confronto.JogoTabela.pontosPorGame);
                await _tabelaGeralService.UpdateLooser(confronto.TimeCasa);
                await _tabelaPorJogoTabelaService.UpdateWinner(confronto.TimeFora,confronto.JogoTabela.pontosPorGame, confronto.JogoTabela);
                await _tabelaPorJogoTabelaService.UpdateLooser(confronto.TimeCasa, confronto.JogoTabela);
            }
            
            // Salva e retorna
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost("ffa")]
    public async Task<ActionResult> PostFfa(ConfrontoFfaDto confrontoDto)
    {
        try
        {
            
            // TODO fazendo
            var jogoFfa = await _jogoService.GetFfaById(confrontoDto.JogoFfaId);

            if (jogoFfa == null)
                return BadRequest("JogoFfa not found");
            
            var confronto = confrontoDto.Adapt<ConfrontoFfa>();

            confronto.JogoFfaId = jogoFfa.Id;
            confronto.JogoFfa = jogoFfa;
            
            var listTimesIds = new List<int> {confronto.P1TimeId, confronto.P2TimeId, confronto.P3TimeId, confronto.P4TimeId};
            var contador = 0;
            foreach (var id in listTimesIds)
            {
                contador++;
                var timeGet = await _timeService.GetByIdAsync(id);
                if (timeGet == null)
                    return BadRequest("Time not found" + id);

                await _tabelaPorJogoFfaService.Update(timeGet, contador, jogoFfa);
                await _tabelaGeralService.UpdateFfa(timeGet, contador, jogoFfa);

            }
            
            await _confrontoFfaService.PostAsync(confronto);
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}