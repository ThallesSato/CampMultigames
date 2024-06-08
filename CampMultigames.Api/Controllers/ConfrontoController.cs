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
            await _confrontoService.CreateAllAsync(times, jogos);
            await _tabelaGeralService.CreateAllAsync(times);
            await _tabelaPorJogoTabelaService.CreateAllAsync(times, jogos);
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
            var confronto = await _confrontoService.GetByIdAsync(confrontoId);
            if (confronto == null) 
                return NotFound("Confronto not found");
            
            confronto.PontosCasa = confrontoDto.PontosCasa;
            confronto.PontosFora = confrontoDto.PontosFora;
            confronto.Data = confrontoDto.Data;
            _confrontoService.Update(confronto);

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
            
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
}