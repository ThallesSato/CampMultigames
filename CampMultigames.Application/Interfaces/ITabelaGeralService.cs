using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Interfaces;

public interface ITabelaGeralService
{
    void CreateAsync(Time time);
    Task<List<TabelaGeral>> GetAllAsync();
}