using CampMultigames.Application.Interfaces;
using CampMultigames.Domain.Interfaces;
using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Services;

public class PlayerService : IPlayerService
{
    private readonly IRepository<Player> _playerRepository;
    public PlayerService(IRepository<Player> playerRepository)
    {
        _playerRepository = playerRepository;
    }
    public async Task<Player> PostAsync(Player player)
    {
        return await _playerRepository.CreateAsync(player);
    }
}