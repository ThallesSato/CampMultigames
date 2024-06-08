using CampMultigames.Domain.Models;

namespace CampMultigames.Domain.Interfaces;

public interface IConfrontoRepository : IRepository<Confronto>
{
    new Task<List<Confronto>> GetAllAsync();
    new Task<Confronto?> GetByIdOrDefaultAsync(int id);
}