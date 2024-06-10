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
    private readonly IBaseService<Player> _playerService;
    private readonly ITimeService _timeService;
    private readonly IUnitOfWork _unitOfWork;

    public PlayerController(IBaseService<Player> playerService, IUnitOfWork unitOfWork, ITimeService timeService)
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
            // Verifica se o time existe
            var time = await _timeService.GetByIdAsync(playerDto.TimeId);
            if (time == null) 
                return NotFound("Time not found");
            
            // Transforma o Dto em Player
            var player = playerDto.Adapt<Player>();
            
            // Atribui o time
            player.Time = time;
            
            // Insere o player no banco
            var response = await _playerService.PostAsync(player);
            
            // Salva e retorna
            await _unitOfWork.SaveChangesAsync();
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}