using CampMultigames.Application.Interfaces;
using CampMultigames.Domain.Interfaces;
using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Services;

public class TabelaGeralService : BaseService<TabelaGeral>, ITabelaGeralService
{
    private readonly ITabelaGeralRepository _repository;
    private readonly IPontosPorColocacaoRepository _pontosPorColocacaoRepository;

    public TabelaGeralService(ITabelaGeralRepository repository, IPontosPorColocacaoRepository pontosPorColocacaoRepository) : base(repository)
    {
        _repository = repository;
        _pontosPorColocacaoRepository = pontosPorColocacaoRepository;
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

    public async Task UpdateWinner(Time time, int pontos)
    {
        var tabelaGeral = await _repository.GetByIdOrDefaultAsync(time.Id);
        if (tabelaGeral == null)
            return;

        tabelaGeral.Vitorias++;
        tabelaGeral.Pontos += pontos;
        tabelaGeral.Jogos++;
        _repository.Update(tabelaGeral);
    }

    public async Task UpdateLooser(Time time)
    {
        var tabelaGeral = await _repository.GetByIdOrDefaultAsync(time.Id);
        if (tabelaGeral == null)
            return;

        tabelaGeral.Derrotas++;
        tabelaGeral.Jogos++;
        _repository.Update(tabelaGeral);
    }
    
    public async Task UpdateFfa(Time time, int posicao, JogoFfa jogo)
    {
        var FfaGeral = await _repository.GetByIdOrDefaultAsync(time.Id);
        if (FfaGeral == null)
            return;
        
        var pontosPorColocacao = await _pontosPorColocacaoRepository.GetByJogoAndPosicaoAsync(jogo, posicao);

        if (pontosPorColocacao != null)
            FfaGeral.Pontos += pontosPorColocacao.Ponto;
        _repository.Update(FfaGeral);
    }
}