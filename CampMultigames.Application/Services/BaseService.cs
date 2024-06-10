using CampMultigames.Application.Interfaces;
using CampMultigames.Domain.Interfaces;
using CampMultigames.Domain.Models;

namespace CampMultigames.Application.Services;

public class BaseService <TEntity> : IBaseService <TEntity> where TEntity : BaseEntity
{
    private readonly IRepository<TEntity> _repository;
    
    public BaseService(IRepository<TEntity> repository)
    {
        _repository = repository;
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdOrDefaultAsync(id);
    }
    
    public async Task<TEntity> PostAsync(TEntity entity)
    {
        return await _repository.CreateAsync(entity);
    }
}