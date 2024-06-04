using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Interfaces;

public interface IPlayerService
{
    Task<Player> PostAsync(Player player);
}
