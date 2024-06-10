using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Interfaces;

public interface IJogoService : IBaseService<JogoBase>
{
    Task<JogoBase> PostAsync(JogoBase jogoBase);
    Task<List<JogoTabela>> GetAllTabelaAsync();
    Task<List<JogoBase>> GetAllAsync();
    Task<JogoTabela?> GetTabelaById(int id);
}