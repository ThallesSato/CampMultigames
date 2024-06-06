using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Interfaces;

public interface IConfrontoService
{
    Task<List<Confronto>> GetAllAsync();
    Task CreateAllAsync(List<Time> times, List<JogoTabela> jogos);
}