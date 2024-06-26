using CampMultigames.Domain.Interfaces;
using CampMultigames.Domain.Models;
using CampMultigames.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CampMultigames.Infra.Repositories;

    
public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TEntity?> GetByIdOrDefaultAsync(int id)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        var result = await _context.Set<TEntity>()
            .ToListAsync();
        return result;
    }

    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        var result = await _context.Set<TEntity>().AddAsync(entity);
        return result.Entity;
    }

    public bool Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        return true;
    }
}