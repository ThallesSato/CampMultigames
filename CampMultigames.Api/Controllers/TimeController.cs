using CampMultigames.Application.Dtos.Input;
using CampMultigames.Application.Interfaces;
using CampMultigames.Domain.Interfaces;
using CampMultigames.Domain.Models;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace CampMultigames.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TimeController : ControllerBase
{
    private readonly ITimeService _timeService;
    private readonly ITabelaGeralService _tabelaGeralService;
    private readonly IUnitOfWork _unitOfWork;
    
    public TimeController(ITimeService timeService, IUnitOfWork unitOfWork, ITabelaGeralService tabelaGeralService)
    {
        _timeService = timeService;
        _unitOfWork = unitOfWork;
        _tabelaGeralService = tabelaGeralService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        return Ok(await _timeService.GetAllAsync());
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(TimeDto timeDto)
    {
        var time = timeDto.Adapt<Time>();
        var result = await _timeService.PostAsync(time);
        _tabelaGeralService.CreateAsync(result);
        await _unitOfWork.SaveChangesAsync();
        return Ok(result);
    }
}