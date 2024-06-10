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
            .Include(c => c.JogoTabela)
            .ToListAsync();
    }

    public Task<List<Confronto>> GetFuturosAsync()
    {
        return _context.Confrontos
            .Where(c => c.Data == null)
            .Include(c => c.TimeCasa)
            .Include(c => c.TimeFora)
            .Include(c => c.JogoTabela)
            .ToListAsync();
    }

    public Task<List<Confronto>> GetPassadosAsync()
    {
        return _context.Confrontos
            .Where(c => c.Data < DateTime.Now)
            .Include(c => c.TimeCasa)
            .Include(c => c.TimeFora)
            .Include(c => c.JogoTabela)
            .OrderByDescending(c => c.Data)
            .ToListAsync();
    }

    public Task<List<Confronto>> GetPassadosByTimeAsync(int timeId)
    {
        return _context.Confrontos
            .Where(c => c.Data < DateTime.Now && (c.TimeCasaId == timeId || c.TimeForaId == timeId))
            .Include(c => c.TimeCasa)
            .Include(c => c.TimeFora)
            .Include(c => c.JogoTabela)
            .OrderByDescending(c => c.Data)
            .ToListAsync();
    }

    public Task<List<Confronto>> GetFuturosByTimeAsync(int timeId)
    {
        return _context.Confrontos
            .Where(c => c.Data == null && (c.TimeCasaId == timeId || c.TimeForaId == timeId))
            .Include(c => c.TimeCasa)
            .Include(c => c.TimeFora)
            .Include(c => c.JogoTabela)
            .ToListAsync();
    }
}