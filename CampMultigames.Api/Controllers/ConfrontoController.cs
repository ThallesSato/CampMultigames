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
    private readonly IUnitOfWork _unitOfWork;
    
    public ConfrontoController(IConfrontoService confrontoService, ITimeService timeService, IJogoService jogoService, IUnitOfWork unitOfWork)
    {
        _confrontoService = confrontoService;
        _timeService = timeService;
        _jogoService = jogoService;
        _unitOfWork = unitOfWork;
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
    
    [HttpPost("GenerateConfrontos")]
    [Authorize]
    public async Task<IActionResult> GenerateConfrontos()
    {
        try
        {
            var times = await _timeService.GetAllAsync();
            var jogos = await _jogoService.GetAllTabelaAsync();
            await _confrontoService.CreateAllAsync(times, jogos);
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    // [HttpPut("{confrontoId}")]
    // [Authorize]
    // public async Task<IActionResult> UpdateConfronto(int confrontoId, Confronto confronto)
    // {
    //     try
    //     {
    //         confronto.Id = confrontoId;
    //         await _unitOfWork.SaveChangesAsync();
    //         return Ok();
    //     }
    //     catch (Exception e)
    //     {
    //         return BadRequest(e.Message);
    //     }
    // }
    
}