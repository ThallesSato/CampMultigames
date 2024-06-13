using CampMultigames.Application.Interfaces;
using CampMultigames.Domain.Interfaces;
using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Services;

public class PontosPorColocacaoService : BaseService<PontosPorColocacao>, IPontosPorColocacaoService
{
    private readonly IPontosPorColocacaoRepository _repository;
    public PontosPorColocacaoService(IPontosPorColocacaoRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public async Task CreateAllAsync(List<JogoFfa> jogoFfa)
    {
        foreach (var jogo in jogoFfa)
        {
            for (int i = 1; i <= 4; i++)
            {
                var pts = await _repository.GetByJogoAndPosicaoAsync(jogo, i);
                if (pts != null) continue;
                var pt = 4 - i;
                await _repository.CreateAsync(new PontosPorColocacao
                {
                    JogoFfa = jogo,
                    Colocacao = i,
                    Ponto = pt
                });
            }
        }
    }
}