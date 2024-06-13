using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Interfaces;

public interface ITabelaPorJogoFfaService : IBaseService<TabelaPorJogoFfa>
{
    Task CreateAllAsync(List<Time> times, List<JogoFfa> jogoFfa);

    Task<List<TabelaPorJogoFfa>> GetAllByJogoAsync(JogoFfa jogoFfa);

    Task Update(Time time, int posicao, JogoFfa jogo);
}