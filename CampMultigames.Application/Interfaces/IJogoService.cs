using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Interfaces;

public interface IJogoService
{
    Task<JogoBase> PostAsync(JogoBase jogoBase);
}