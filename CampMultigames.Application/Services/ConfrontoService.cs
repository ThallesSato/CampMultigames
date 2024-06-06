using CampMultigames.Application.Interfaces;
using CampMultigames.Domain.Interfaces;
using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Services;

public class ConfrontoService : IConfrontoService
{
    private readonly IRepository<Confronto> _repository;
    public ConfrontoService(IRepository<Confronto> repository)
    {
        _repository = repository;
    }

    public async Task<List<Confronto>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task CreateAllAsync(List<Time> times, List<JogoTabela> jogos)
    {
        foreach (var jogo in jogos)
        {
            foreach (var time1 in times)
            {
                foreach (var time2 in times)
                {
                    if (time1 == time2) break;
                    var confronto = new Confronto
                    {
                        TimeCasa = time1,
                        TimeFora = time2,
                        JogoBase = jogo
                    };
                    await _repository.CreateAsync(confronto);
                }
            }
        }
    }
}