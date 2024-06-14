using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Interfaces;

public interface IJogoService : IBaseService<JogoBase>
{
    new Task<JogoBase> PostAsync(JogoBase jogoBase);
    Task<List<JogoTabela>> GetAllTabelaAsync();
    Task<List<JogoFfa>> GetAllFfaAsync();
    Task<JogoFfa?> GetFfaById(int id);
}