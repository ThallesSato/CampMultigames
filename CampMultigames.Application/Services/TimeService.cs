using CampMultigames.Application.Interfaces;
using CampMultigames.Domain.Interfaces;
using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Services;

public class TimeService : BaseService<Time>, ITimeService
{
    private readonly ITimeRepository _repository;
    public TimeService(ITimeRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public new Task<List<Time>> GetAllAsync()
    {
        return _repository.GetAllAsync();
    }
}