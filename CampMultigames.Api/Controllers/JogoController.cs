using CampMultigames.Application.Dtos.Input;
using CampMultigames.Application.Interfaces;
using CampMultigames.Domain.Interfaces;
using CampMultigames.Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace CampMultigames.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class JogoController : ControllerBase
{
    private readonly IJogoService _jogoService;
    private readonly IUnitOfWork _unitOfWork;
    public JogoController(IJogoService jogoService, IUnitOfWork unitOfWork)
    {
        _jogoService = jogoService;
        _unitOfWork = unitOfWork;
    }
    
    [HttpGet("tabela")]
    public async Task<IActionResult> GetAllTabela()
    {
        try
        {
            return Ok(await _jogoService.GetAllTabelaAsync());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("ffa")]
    public async Task<IActionResult> GetAllFfa()
    {
        try
        {
            return Ok(await _jogoService.GetAllFfaAsync());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost("ffa")]
    //[Authorize]
    public async Task<IActionResult> Post(JogoFfaDto jogoBase)
    {
        try
        {
            // Cria o jogo
            var jogo = jogoBase.Adapt<JogoFfa>();
            var result = await _jogoService.PostAsync(jogo);

            // Salva e retorna
            await _unitOfWork.SaveChangesAsync();
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost("tabela")]
    //[Authorize]
    public async Task<IActionResult> Post(JogoTabela jogoBase)
    {
        try
        {
            // Cria o jogo
            var result = await _jogoService.PostAsync(jogoBase);

            // Salva e retorna
            await _unitOfWork.SaveChangesAsync();
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}