using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Interfaces;

public interface IConfrontoService : IBaseService<Confronto>
{
    new Task<Confronto?> GetByIdAsync(int confrontoId);
    Task CreateAllAsync(List<Time> times, List<JogoTabela> jogos);
    void Update(Confronto confronto);
    Task<List<Confronto>> GetFuturosAsync();
    Task<List<Confronto>> GetPassadosAsync();
    Task<List<Confronto>> GetPassadosByTimeAsync(int timeId);
    Task<List<Confronto>> GetFuturosByTimeAsync(int timeId);
}