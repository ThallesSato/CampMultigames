using CampMultigames.Domain.Models;

namespace CampMultigames.Domain.Interfaces;

public interface ITabelaPorJogoFfaRepository : IRepository<TabelaPorJogoFfa>
{
    new Task<List<TabelaPorJogoFfa>> GetAllAsync();

    Task<TabelaPorJogoFfa?> GetByTimeJogoAsync(Time time, JogoFfa jogo);
}