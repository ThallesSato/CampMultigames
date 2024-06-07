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
public class PlayerController : ControllerBase
{
    private readonly IPlayerService _playerService;
    private readonly ITimeService _timeService;
    private readonly IUnitOfWork _unitOfWork;

    public PlayerController(IPlayerService playerService, IUnitOfWork unitOfWork, ITimeService timeService)
    {
        _playerService = playerService;
        _unitOfWork = unitOfWork;
        _timeService = timeService;
    }

    [HttpPost]
    //[Authorize]
    public async Task<IActionResult> Post(PlayerDto playerDto)
    {
        try
        {
            var time = await _timeService.GetByIdAsync(playerDto.TimeId);
            if (time == null) return NotFound("Time not found");
            var player = playerDto.Adapt<Player>();
            player.Time = time;
            var response = await _playerService.PostAsync(player);
            await _unitOfWork.SaveChangesAsync();
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}