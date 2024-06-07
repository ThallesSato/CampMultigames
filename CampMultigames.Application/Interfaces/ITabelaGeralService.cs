using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Interfaces;

public interface ITabelaGeralService
{
    Task<List<TabelaGeral>> GetAllAsync();
    Task CreateAllAsync(List<Time> times);
    Task UpdateWinner(Time time, int pontos);
    Task UpdateLooser(Time time);
}