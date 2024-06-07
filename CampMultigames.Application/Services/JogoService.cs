using CampMultigames.Application.Interfaces;
using CampMultigames.Domain.Interfaces;
using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Services;

public class JogoService : IJogoService
{
    private readonly IJogosRepository _repository;

    public JogoService(IJogosRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<JogoBase>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<JogoTabela?> GetTabelaById(int id)
    {
        var tabelas = await _repository.GetAllTabelaAsync();
        var result = tabelas.FirstOrDefault(t => t.Id == id);
        return result;
    }

    public async Task<List<JogoTabela>> GetAllTabelaAsync()
    {
        return await _repository.GetAllTabelaAsync();
    }

    public async Task<JogoBase> PostAsync(JogoBase jogoBase)
    {
        var tab = new JogoTabela()
        {
            Name = jogoBase.Name
        };
        return await _repository.CreateAsync(tab);
    }
}