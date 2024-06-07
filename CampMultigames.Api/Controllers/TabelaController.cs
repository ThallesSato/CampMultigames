using CampMultigames.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CampMultigames.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TabelaController : ControllerBase
{
    private readonly ITabelaGeralService _tabelaGeralService;
    private readonly ITabelaPorJogoTabelaService _tabelaPorJogoTabelaService;
    private readonly IJogoService _jogoService;

    public TabelaController(ITabelaGeralService tabelaGeralService, ITabelaPorJogoTabelaService tabelaPorJogoTabelaService, IJogoService jogoService)
    {
        _tabelaGeralService = tabelaGeralService;
        _tabelaPorJogoTabelaService = tabelaPorJogoTabelaService;
        _jogoService = jogoService;
    }

    [HttpGet("geral")]
    public async Task<ActionResult> GetAll()
    {
        try
        {
            return Ok(await _tabelaGeralService.GetAllAsync());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("porjogo/{id}")]
    public async Task<ActionResult> GetByJogo(int id)
    {
        try
        {
            var jogo = await _jogoService.GetTabelaById(id);
            if (jogo == null)
                return NotFound();
            return Ok(await _tabelaPorJogoTabelaService.GetAllAsync(jogo));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}