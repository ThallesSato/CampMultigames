using CampMultigames.Domain.Models;

namespace CampMultigames.Domain.Interfaces;

public interface IJogosRepository : IRepository<JogoBase>
{
    Task<List<JogoTabela>> GetAllTabelaAsync();
    Task<List<JogoFfa>> GetAllFfaAsync();
    Task<JogoFfa?> GetFfaById(int id);
}