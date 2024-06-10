using CampMultigames.Domain.Models;

namespace CampMultigames.Domain.Interfaces;

public interface IConfrontoRepository : IRepository<Confronto>
{
    new Task<List<Confronto>> GetAllAsync();
    Task<List<Confronto>> GetFuturosAsync();
    Task<List<Confronto>> GetPassadosAsync();
    Task<List<Confronto>> GetPassadosByTimeAsync(int timeId);
    Task<List<Confronto>> GetFuturosByTimeAsync(int timeId);
}