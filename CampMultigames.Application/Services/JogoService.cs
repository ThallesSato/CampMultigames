using CampMultigames.Application.Interfaces;
using CampMultigames.Domain.Interfaces;
using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Services;

public class JogoService : IJogoService
{
    private readonly IRepository<Jogo> _repository;

    public JogoService(IRepository<Jogo> repository)
    {
        _repository = repository;
    }
    public async Task<Jogo> PostAsync(Jogo jogo)
    {
        return await _repository.CreateAsync(jogo);
    }
}