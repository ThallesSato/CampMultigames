using CampMultigames.Application.Interfaces;
using CampMultigames.Domain.Interfaces;
using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Services;

public class TabelaPorJogoTabelaService : ITabelaPorJogoTabelaService
{
    private readonly ITabelaPorJogoTabelaRepository _repository;
    public TabelaPorJogoTabelaService(ITabelaPorJogoTabelaRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<TabelaPorJogoTabela>> GetAllAsync(JogoTabela jogoTabela)
    {
        var all = await _repository.GetAllAsync();
        return all.Where(t => t.JogoTabela.Id == jogoTabela.Id).ToList();
    }

    public async Task CreateAllAsync(List<Time> times, List<JogoTabela> jogos)
    {
        var existentes = await _repository.GetAllAsync();
        foreach (var time in times)
        {
            foreach (var jogo in jogos)
            {
                if (existentes.Any(t => t.Time.Id == time.Id && t.JogoTabela.Id == jogo.Id))
                    continue;
                await _repository.CreateAsync(new TabelaPorJogoTabela
                {
                    Time = time,
                    JogoTabela = jogo
                });
            }
        }
    }

    public async Task UpdateWinner(Time time, int pontos, JogoTabela jogo)
    {
        var tabelaGeral = await _repository.GetByTimeJogoAsync(time, jogo);
        if (tabelaGeral == null)
            return;

        tabelaGeral.vitorias++;
        tabelaGeral.pontos += pontos;
        tabelaGeral.jogos++;
        _repository.Update(tabelaGeral);
    }

    public async Task UpdateLooser(Time time,JogoTabela jogo)
    {
        var tabelaGeral = await _repository.GetByTimeJogoAsync(time, jogo);
        if (tabelaGeral == null)
            return;

        tabelaGeral.derrotas++;
        tabelaGeral.jogos++;
        _repository.Update(tabelaGeral);
    }
}