using CampMultigames.Domain.Interfaces;
using CampMultigames.Domain.Models;
using CampMultigames.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CampMultigames.Infra.Repositories;

public class TabelaPorJogoFfaRepository : Repository<TabelaPorJogoFfa>, ITabelaPorJogoFfaRepository
{
    private readonly AppDbContext _context;
    public TabelaPorJogoFfaRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<TabelaPorJogoFfa?> GetByTimeJogoAsync(Time time, JogoFfa jogo)
    {
        return await _context.TabelasPorJogoFfa
            .FirstOrDefaultAsync(t => t.Time.Id == time.Id && t.JogoFfa.Id == jogo.Id);
    }

    public new Task<List<TabelaPorJogoFfa>> GetAllAsync()
    {
        return _context.TabelasPorJogoFfa
            .AsNoTracking()
            .Include(t => t.Time)
            .Include(t => t.JogoFfa)
            .OrderByDescending(t => t.Pontos)
            .ToListAsync();
    }
}