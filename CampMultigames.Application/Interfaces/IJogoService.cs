using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Interfaces;

public interface IJogoService
{
    Task<Jogo> PostAsync(Jogo jogo);
}