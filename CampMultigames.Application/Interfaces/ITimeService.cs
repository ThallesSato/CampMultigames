using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Interfaces;

public interface ITimeService
{
    void Post(Time time);
    Task<List<Time>> GetAll();
}