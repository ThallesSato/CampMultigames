using CampMultigames.Domain.Models;

namespace CampMultigames.Domain.Interfaces;

public interface ITabelaPorJogoTabelaRepository : IRepository<TabelaPorJogoTabela>
{
    Task<TabelaPorJogoTabela?> GetByTimeJogoAsync(Time time, JogoTabela jogo);
    new Task<List<TabelaPorJogoTabela>> GetAllAsync();
}