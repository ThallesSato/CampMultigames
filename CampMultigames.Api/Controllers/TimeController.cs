using CampMultigames.Application.Dtos.Input;
using CampMultigames.Application.Interfaces;
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
    
    public TimeController(ITimeService timeService)
    {
        _timeService = timeService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        return Ok(await _timeService.GetAll());
    }
    
    [HttpPost]
    public IActionResult Post(TimeDto timeDto)
    {
        var time = timeDto.Adapt<Time>();
        _timeService.Post(time);
        return Ok();
    }
}