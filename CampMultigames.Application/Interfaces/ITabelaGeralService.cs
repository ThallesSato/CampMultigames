using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Interfaces;

public interface ITabelaGeralService : IBaseService<TabelaGeral>
{
    Task CreateAllAsync(List<Time> times);
    Task UpdateWinner(Time time, int pontos);
    Task UpdateLooser(Time time);

    Task UpdateFfa(Time time, int posicao, JogoFfa jogo);
}