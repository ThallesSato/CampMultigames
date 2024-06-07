using CampMultigames.Application.Interfaces;
using CampMultigames.Domain.Interfaces;
using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Services;

public class TabelaGeralService : ITabelaGeralService
{
    private readonly ITabelaGeralRepository _repository;

    public TabelaGeralService(ITabelaGeralRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateAllAsync(List<Time> times)
    {
        var timeslist = await _repository.GetAllAsync();
        foreach (var time in times)
        {
            if (timeslist.Any(t => t.Time.Id == time.Id))
                continue;
            await _repository.CreateAsync(new TabelaGeral
            {
                Id = time.Id,
                Time = time
            });
        }
    }

    public Task<List<TabelaGeral>> GetAllAsync()
    {
        return _repository.GetAllAsync();
    }

    public async Task UpdateWinner(Time time, int pontos)
    {
        var tabelaGeral = await _repository.GetByIdOrDefaultAsync(time.Id);
        if (tabelaGeral == null)
            return;

        tabelaGeral.vitorias++;
        tabelaGeral.pontos += pontos;
        tabelaGeral.jogos++;
        _repository.Update(tabelaGeral);
    }

    public async Task UpdateLooser(Time time)
    {
        var tabelaGeral = await _repository.GetByIdOrDefaultAsync(time.Id);
        if (tabelaGeral == null)
            return;

        tabelaGeral.derrotas++;
        tabelaGeral.jogos++;
        _repository.Update(tabelaGeral);
    }
}