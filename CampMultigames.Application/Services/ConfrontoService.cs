using CampMultigames.Application.Interfaces;
using CampMultigames.Domain.Interfaces;
using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Services;

public class ConfrontoService : IConfrontoService
{
    private readonly IConfrontoRepository _repository;
    public ConfrontoService(IConfrontoRepository repository)
    {
        _repository = repository;
    }

    public Task<Confronto?> GetByIdAsync(int confrontoId)
    {
        return _repository.GetByIdOrDefaultAsync(confrontoId);
    }

    public async Task<List<Confronto>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task CreateAllAsync(List<Time> times, List<JogoTabela> jogos)
    {
        var confrontos = await _repository.GetAllAsync();
        foreach (var jogo in jogos)
        {
            foreach (var time1 in times)
            {
                foreach (var time2 in times)
                {
                    if (time1 == time2) continue;
                    var confrontoExistente = confrontos.Find(c => c.TimeCasa == time1 && c.TimeFora == time2 && c.JogoTabela == jogo);
                    if (confrontoExistente != null) continue;
                    
                    var confronto = new Confronto
                    {
                        TimeCasa = time1,
                        TimeFora = time2,
                        JogoTabela = jogo
                    };
                    
                    await _repository.CreateAsync(confronto);
                }
            }
        }
    }

    public void Update(Confronto confronto)
    {
        _repository.Update(confronto);
    }
}