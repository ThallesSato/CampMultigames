using CampMultigames.Application.Interfaces;
using CampMultigames.Domain.Interfaces;
using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Services;

public class JogoService : IJogoService
{
    private readonly IRepository<JogoBase> _repository;

    public JogoService(IRepository<JogoBase> repository)
    {
        _repository = repository;
    }
    public async Task<JogoBase> PostAsync(JogoBase jogoBase)
    {
        return await _repository.CreateAsync(jogoBase);
    }
}