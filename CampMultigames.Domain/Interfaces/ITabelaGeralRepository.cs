using CampMultigames.Domain.Models;

namespace CampMultigames.Domain.Interfaces;

public interface ITabelaGeralRepository : IRepository<TabelaGeral>
{
    new Task<List<TabelaGeral>> GetAllAsync();
}