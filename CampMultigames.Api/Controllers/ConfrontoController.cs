using CampMultigames.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CampMultigames.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ConfrontoController : ControllerBase
{
    private readonly IConfrontoService _confrontoService;
    
    public ConfrontoController(IConfrontoService confrontoService)
    {
        _confrontoService = confrontoService;
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
}