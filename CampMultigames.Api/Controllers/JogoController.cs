using CampMultigames.Application.Interfaces;
using CampMultigames.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CampMultigames.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class JogoController : ControllerBase
{
    private readonly IJogoService _jogoService;
    public JogoController(IJogoService jogoService)
    {
        _jogoService = jogoService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(Jogo jogo)
    {
        return Ok(await _jogoService.PostAsync(jogo));
    }
}