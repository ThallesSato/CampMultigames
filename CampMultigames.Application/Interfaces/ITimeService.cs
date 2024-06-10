using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Interfaces;

public interface ITimeService : IBaseService<Time>
{
    new Task<List<Time>> GetAllAsync();
}