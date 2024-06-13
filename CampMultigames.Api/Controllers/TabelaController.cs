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
    private readonly ITabelaPorJogoFfaService _tabelaPorJogoFfaService;
    private readonly IJogoService _jogoService;

    public TabelaController(ITabelaGeralService tabelaGeralService, ITabelaPorJogoTabelaService tabelaPorJogoTabelaService, IJogoService jogoService, ITabelaPorJogoFfaService tabelaPorJogoFfaService)
    {
        _tabelaGeralService = tabelaGeralService;
        _tabelaPorJogoTabelaService = tabelaPorJogoTabelaService;
        _jogoService = jogoService;
        _tabelaPorJogoFfaService = tabelaPorJogoFfaService;
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

    [HttpGet("all")]
    public async Task<ActionResult> GetAllJogoTabela()
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
    
    [HttpGet("jogoffa")]
    public async Task<ActionResult> GetAllJogoFfa()
    {
        try
        {
            var result = new List<object>();

            var sub = new
            {
                Name="",
                tabelas = new List<TabelaAllFfa>()
            };

            var contador = 0;
            
            var porjogo = await _tabelaPorJogoFfaService.GetAllAsync();
            porjogo = porjogo.OrderBy( t => t.JogoFfa.Id ).ToList();
            foreach (var i in porjogo)
            {
                if (i.JogoFfa.Name != sub.Name)
                {
                    if (contador !=0)
                        result.Add(sub);
                    sub = new
                    {
                        Name = i.JogoFfa.Name,
                        tabelas = new List<TabelaAllFfa>()
                    };
                }
                var tabela = i.Adapt<TabelaAllFfa>();
                tabela.Time = i.Time.Name;
                sub.tabelas.Add(tabela);
                contador++;
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