using CampMultigames.Application.Interfaces;
using CampMultigames.Domain.Interfaces;
using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Services;

public class TabelaGeralService : ITabelaGeralService
{
    private readonly ITabelaGeralRepository _repository;

    public TabelaGeralService(ITabelaGeralRepository repository)
    {
        _repository = repository;
    }

    public void CreateAsync(Time time)
    {
        _repository.CreateAsync(new TabelaGeral
        {
            Time = time
        });
    }

    public Task<List<TabelaGeral>> GetAllAsync()
    {
        return _repository.GetAllAsync();
    }
}