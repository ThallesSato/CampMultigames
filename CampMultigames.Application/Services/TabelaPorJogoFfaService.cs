using CampMultigames.Application.Interfaces;
using CampMultigames.Domain.Interfaces;
using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Services;

public class TabelaPorJogoFfaService : BaseService<TabelaPorJogoFfa>, ITabelaPorJogoFfaService
{
    private readonly ITabelaPorJogoFfaRepository _repository;
    private readonly IPontosPorColocacaoRepository _pontosPorColocacaoRepository;
    public TabelaPorJogoFfaService(ITabelaPorJogoFfaRepository repository, IPontosPorColocacaoRepository pontosPorColocacaoRepository) : base(repository)
    {
        _repository = repository;
        _pontosPorColocacaoRepository = pontosPorColocacaoRepository;
    }
    
    
    public async Task<List<TabelaPorJogoFfa>> GetAllByJogoAsync(JogoFfa jogoFfa)
    {
        var all = await _repository.GetAllAsync();
        return all.Where(t => t.JogoFfa.Id == jogoFfa.Id).ToList();
    }

    public async Task CreateAllAsync(List<Time> times, List<JogoFfa> jogos)
    {
        var existentes = await _repository.GetAllAsync();
        foreach (var time in times)
        {
            foreach (var jogo in jogos)
            {
                if (existentes.Any(t => t.Time.Id == time.Id && t.JogoFfa.Id == jogo.Id))
                    continue;
                await _repository.CreateAsync(new TabelaPorJogoFfa
                {
                    Time = time,
                    JogoFfa = jogo
                });
            }
        }
    }

    public async Task Update(Time time, int posicao, JogoFfa jogo)
    {
        var FfaGeral = await _repository.GetByTimeJogoAsync(time, jogo);
        if (FfaGeral == null)
            return;
        
        var pontosPorColocacao = await _pontosPorColocacaoRepository.GetByJogoAndPosicaoAsync(jogo, posicao);

        if (pontosPorColocacao != null)
            FfaGeral.Pontos += pontosPorColocacao.Ponto;
        
        switch (posicao)
        {
            case 1:
                FfaGeral.P1++;
                break;
            case 2:
                FfaGeral.P2++;
                break;
            case 3:
                FfaGeral.P3++;
                break;
            case 4:
                FfaGeral.P4++;
                break;
        }
        _repository.Update(FfaGeral);
    }
}