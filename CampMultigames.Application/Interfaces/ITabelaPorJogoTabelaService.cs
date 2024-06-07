using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Interfaces;

public interface ITabelaPorJogoTabelaService
{
    Task<List<TabelaPorJogoTabela>> GetAllAsync(JogoTabela jogoTabela);
    Task CreateAllAsync(List<Time> times, List<JogoTabela> jogos);
    Task UpdateWinner(Time time, int pontos, JogoTabela jogoTabela);
    Task UpdateLooser(Time time, JogoTabela jogoTabela);
}