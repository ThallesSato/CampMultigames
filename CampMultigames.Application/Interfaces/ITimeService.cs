using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Interfaces;

public interface ITimeService
{
    Task<Time> PostAsync(Time time);
    Task<List<Time>> GetAllAsync();
    Task<Time?> GetByIdAsync(int id);
}