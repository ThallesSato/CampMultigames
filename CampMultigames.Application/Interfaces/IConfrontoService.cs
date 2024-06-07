using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Interfaces;

public interface IConfrontoService
{
    Task<Confronto?> GetByIdAsync(int confrontoId);
    Task<List<Confronto>> GetAllAsync();
    Task CreateAllAsync(List<Time> times, List<JogoTabela> jogos);
    void Update(Confronto confronto);
}