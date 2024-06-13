using CampMultigames.Domain.Models;

namespace CampMultigames.Domain.Interfaces;

public interface IPontosPorColocacaoRepository : IRepository<PontosPorColocacao>
{
    Task<PontosPorColocacao?> GetByJogoAndPosicaoAsync(JogoFfa jogo, int posicao);
}