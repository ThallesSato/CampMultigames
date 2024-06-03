using CampMultigames.Application.Interfaces;
using CampMultigames.Domain.Interfaces;
using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Services;

public class TimeService : ITimeService
{
    private readonly IRepository<Time> _timeRepository;
    public TimeService(IRepository<Time> timeRepository)
    {
        _timeRepository = timeRepository;
    }
    public async void Post(Time time)
    {
        await _timeRepository.CreateAsync(time);
    }
    
    public async Task<List<Time>> GetAll()
    {
        return await _timeRepository.GetAllAsync();
    }
}