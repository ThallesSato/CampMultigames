using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Interfaces;

public interface IPontosPorColocacaoService : IBaseService<PontosPorColocacao>
{
    Task CreateAllAsync(List<JogoFfa> jogoFfa);
}