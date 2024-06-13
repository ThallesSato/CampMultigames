using CampMultigames.Domain.Interfaces;
using CampMultigames.Domain.Models;
using CampMultigames.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CampMultigames.Infra.Repositories;

public class ConfrontoRepository : Repository<Confronto>, IConfrontoRepository
{
    public new Task<Confronto?> GetByIdOrDefaultAsync(int id)
    {
        return _context.Confrontos
            .Include(c => c.TimeCasa)
            .ThenInclude(t => t.Players)
            .Include(c => c.TimeFora)
            .ThenInclude(t => t.Players)
            .Include(c => c.JogoTabela)
            .Include(c=> c.Mapas)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

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
            .Include(c=> c.Mapas)
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
            .Where(c => c.Data < DateTime.UtcNow)
            .Include(c => c.TimeCasa)
            .Include(c => c.TimeFora)
            .Include(c => c.JogoTabela)
            .OrderByDescending(c => c.Data)
            .ToListAsync();
    }

    public Task<List<Confronto>> GetPassadosByTimeAsync(int timeId)
    {
        return _context.Confrontos
            .Where(c => c.Data < DateTime.UtcNow && (c.TimeCasaId == timeId || c.TimeForaId == timeId))
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