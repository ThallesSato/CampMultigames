using CampMultigames.Application.Interfaces;
using CampMultigames.Domain.Interfaces;
using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Services;

public class TimeService : ITimeService
{
    private readonly ITimeRepository _timeRepository;
    public TimeService(ITimeRepository timeRepository)
    {
        _timeRepository = timeRepository;
    }
    public async Task<Time> PostAsync(Time time)
    {
        return await _timeRepository.CreateAsync(time);
    }
    
    public async Task<List<Time>> GetAllAsync()
    {
        return await _timeRepository.GetAllAsync();
    }

    public Task<Time?> GetByIdAsync(int id)
    {
        return _timeRepository.GetByIdOrDefaultAsync(id);
    }
}