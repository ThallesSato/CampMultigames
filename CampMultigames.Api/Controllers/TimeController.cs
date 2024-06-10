using CampMultigames.Application.Dtos.Input;
using CampMultigames.Application.Interfaces;
using CampMultigames.Domain.Interfaces;
using CampMultigames.Domain.Models;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CampMultigames.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TimeController : ControllerBase
{
    private readonly ITimeService _timeService;
    private readonly IUnitOfWork _unitOfWork;

    public TimeController(ITimeService timeService, IUnitOfWork unitOfWork)
    {
        _timeService = timeService;
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        try
        {
            return Ok(await _timeService.GetAllAsync());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    //[Authorize]
    public async Task<IActionResult> Post(TimeDto timeDto)
    {
        try
        {
            // Transforma o Dto em Time
            var time = timeDto.Adapt<Time>();
            
            // Insere o time no banco
            var result = await _timeService.PostAsync(time);
            
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