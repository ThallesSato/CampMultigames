using CampMultigames.Application.Interfaces;
using CampMultigames.Domain.Interfaces;
using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Services;

public class ConfrontoService : BaseService<Confronto>, IConfrontoService
{
    private readonly IConfrontoRepository _repository;
    public ConfrontoService(IConfrontoRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public async Task CreateAllAsync(List<Time> times, List<JogoTabela> jogos)
    {
        // Buscar os confrontos existentes (diminuir request ao banco)
        var confrontos = await _repository.GetAllAsync();
        
        // Para cada jogo, time1 e time2
        foreach (var jogo in jogos)
        {
            foreach (var time1 in times)
            {
                foreach (var time2 in times)
                {
                    // se os times forem o mesmo, pular
                    if (time1 == time2) continue;

                    // se o confronto existente for o mesmo, pular
                    var confrontoExistente = confrontos.Find(c => c.TimeCasa == time1 && c.TimeFora == time2 && c.JogoTabela == jogo);
                    if (confrontoExistente != null) continue;
                    
                    // cria o confronto
                    var confronto = new Confronto
                    {
                        TimeCasa = time1,
                        TimeFora = time2,
                        JogoTabela = jogo
                    };
                    
                    // insere no banco
                    await _repository.CreateAsync(confronto);
                }
            }
        }
    }

    public void Update(Confronto confronto)
    {
        _repository.Update(confronto);
    }

    public new Task<Confronto?> GetByIdAsync(int id)
    {
        return _repository.GetByIdOrDefaultAsync(id);
    }

    public async Task<List<Confronto>> GetFuturosAsync()
    {
        return await _repository.GetFuturosAsync();
    }

    public async Task<List<Confronto>> GetPassadosAsync()
    {
        return await _repository.GetPassadosAsync();
    }

    public async Task<List<Confronto>> GetPassadosByTimeAsync(int timeId)
    {
        return await _repository.GetPassadosByTimeAsync(timeId);
    }

    public async Task<List<Confronto>> GetFuturosByTimeAsync(int timeId)
    {
        return await _repository.GetFuturosByTimeAsync(timeId);
    }
}