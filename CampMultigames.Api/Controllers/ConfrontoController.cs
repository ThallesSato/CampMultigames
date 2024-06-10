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
    private readonly ITimeService _timeService;
    private readonly IJogoService _jogoService;
    private readonly ITabelaGeralService _tabelaGeralService;
    private readonly ITabelaPorJogoTabelaService _tabelaPorJogoTabelaService;
    private readonly IUnitOfWork _unitOfWork;
    
    public ConfrontoController(IConfrontoService confrontoService, ITimeService timeService, IJogoService jogoService, IUnitOfWork unitOfWork, ITabelaGeralService tabelaGeralService, ITabelaPorJogoTabelaService tabelaPorJogoTabelaService)
    {
        _confrontoService = confrontoService;
        _timeService = timeService;
        _jogoService = jogoService;
        _unitOfWork = unitOfWork;
        _tabelaGeralService = tabelaGeralService;
        _tabelaPorJogoTabelaService = tabelaPorJogoTabelaService;
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
    
    [HttpPost("GenerateAll")]
    //[Authorize]
    public async Task<IActionResult> GenerateAll()
    {
        try
        {
            var times = await _timeService.GetAllAsync();
            var jogos = await _jogoService.GetAllTabelaAsync();
            
            // Cria todos os confrontos
            await _confrontoService.CreateAllAsync(times, jogos);
            
            // Cria os times nas tabelas
            await _tabelaGeralService.CreateAllAsync(times);
            await _tabelaPorJogoTabelaService.CreateAllAsync(times, jogos);
            
            // Salva e retorna
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPut("{confrontoId}")]
    //[Authorize]
    public async Task<IActionResult> UpdateConfronto(int confrontoId, ConfrontoDto confrontoDto)
    {
        try
        {
            // Verifica se o confronto existe
            var confronto = await _confrontoService.GetByIdAsync(confrontoId);
            if (confronto == null) 
                return NotFound("Confronto not found");
            
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

}