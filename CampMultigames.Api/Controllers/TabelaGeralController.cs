using CampMultigames.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CampMultigames.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TabelaGeralController : ControllerBase
{
    private readonly ITabelaGeralService _tabelaGeralService;
    
    public TabelaGeralController(ITabelaGeralService tabelaGeralService)
    {
        _tabelaGeralService = tabelaGeralService;
    }
    
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        return Ok(await _tabelaGeralService.GetAllAsync());
    }
    
}