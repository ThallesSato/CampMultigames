using CampMultigames.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CampMultigames.Infra.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Time> Times => Set<Time>();
    public DbSet<Confronto> Confrontos => Set<Confronto>();
    public DbSet<Player> Players => Set<Player>();
    public DbSet<JogoBase> Jogos => Set<JogoBase>();
    public DbSet<TabelaGeral> TabelasGerais => Set<TabelaGeral>();
}