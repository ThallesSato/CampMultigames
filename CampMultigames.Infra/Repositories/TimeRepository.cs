using CampMultigames.Domain.Interfaces;
using CampMultigames.Domain.Models;
using CampMultigames.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CampMultigames.Infra.Repositories;

public class TimeRepository : Repository<Time>, ITimeRepository
{
    private readonly AppDbContext _context;
    public TimeRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public new Task<List<Time>> GetAllAsync()
    {
        return _context.Times.Include(x => x.Players).ToListAsync();
    }
}