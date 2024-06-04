using CampMultigames.Domain.Interfaces;
using CampMultigames.Domain.Models;
using CampMultigames.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CampMultigames.Infra.Repositories;

public class TabelaGeralRepository : Repository<TabelaGeral> , ITabelaGeralRepository
{
    private readonly AppDbContext _context;
    public TabelaGeralRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public new Task<List<TabelaGeral>> GetAllAsync()
    {
        return _context.TabelasGerais.Include(x => x.Time).ToListAsync();
    }
}