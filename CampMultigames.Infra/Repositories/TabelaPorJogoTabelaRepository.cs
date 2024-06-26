using CampMultigames.Domain.Interfaces;
using CampMultigames.Domain.Models;
using CampMultigames.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CampMultigames.Infra.Repositories;

public class TabelaPorJogoTabelaRepository : Repository<TabelaPorJogoTabela>, ITabelaPorJogoTabelaRepository
{
    private readonly AppDbContext _context;
    public TabelaPorJogoTabelaRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<TabelaPorJogoTabela?> GetByTimeJogoAsync(Time time, JogoTabela jogo)
    {
        return await _context.TabelasPorJogoTabela
            .FirstOrDefaultAsync(t => t.Time.Id == time.Id && t.JogoTabela.Id == jogo.Id);
    }

    public new Task<List<TabelaPorJogoTabela>> GetAllAsync()
    {
        return _context.TabelasPorJogoTabela
            .Include(t => t.Time)
            .Include(t => t.JogoTabela)
            .OrderByDescending(t => t.Pontos)
            .ToListAsync();
    }
}