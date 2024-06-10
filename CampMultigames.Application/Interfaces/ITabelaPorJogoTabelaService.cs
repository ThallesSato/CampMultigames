using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Interfaces;

public interface ITabelaPorJogoTabelaService : IBaseService<TabelaPorJogoTabela>
{
    Task<List<TabelaPorJogoTabela>> GetAllByJogoAsync(JogoTabela jogoTabela);
    Task CreateAllAsync(List<Time> times, List<JogoTabela> jogos);
    Task UpdateWinner(Time time, int pontos, JogoTabela jogoTabela);
    Task UpdateLooser(Time time, JogoTabela jogoTabela);
}