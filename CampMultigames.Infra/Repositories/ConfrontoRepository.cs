using CampMultigames.Domain.Interfaces;
using CampMultigames.Domain.Models;
using CampMultigames.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CampMultigames.Infra.Repositories;

public class ConfrontoRepository : Repository<Confronto>, IConfrontoRepository
{
    private readonly AppDbContext _context;

    public ConfrontoRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public new Task<List<Confronto>> GetAllAsync()
    {
        return _context.Confrontos
            .Include(c => c.TimeCasa)
            .Include(c => c.TimeFora)
            .Include(c => c.JogoBase)
            .ToListAsync();
    }
}