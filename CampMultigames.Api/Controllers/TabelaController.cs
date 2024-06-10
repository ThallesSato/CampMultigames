using CampMultigames.Application.Dtos.Output;
using CampMultigames.Application.Interfaces;
using CampMultigames.Domain.Models;
using Mapster;
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
    public async Task<ActionResult> GetGeral()
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
            // Verifica se o jogo existe
            var jogo = await _jogoService.GetTabelaById(id);
            if (jogo == null)
                return NotFound("Jogo not found");
            
            // Retorna a tabela
            return Ok(await _tabelaPorJogoTabelaService.GetAllByJogoAsync(jogo));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("All")]
    public async Task<ActionResult> GetAll()
    {
        try
        {
            var geral = await _tabelaGeralService.GetAllAsync();

            var sub = new
            {
                Name = "Geral",
                tabelas = new List<TabelaAll>()
            };
            foreach (var i in geral)
            {
                var tabela = i.Adapt<TabelaAll>();
                tabela.Time = i.Time.Name;
                sub.tabelas.Add(tabela);
            }
            
            var result = new List<object>();
            
            var porjogo = await _tabelaPorJogoTabelaService.GetAllAsync();
            porjogo = porjogo.OrderBy( t => t.JogoTabela.Id ).ToList();
            foreach (var i in porjogo)
            {
                if (i.JogoTabela.Name != sub.Name)
                {
                    result.Add(sub);
                    sub = new
                    {
                        Name = i.JogoTabela.Name,
                        tabelas = new List<TabelaAll>()
                    };
                }
                var tabela = i.Adapt<TabelaAll>();
                tabela.Time = i.Time.Name;
                sub.tabelas.Add(tabela);
            }
            result.Add(sub);
            
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}