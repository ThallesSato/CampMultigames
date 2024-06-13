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
    public DbSet<JogoTabela> JogosTabela => Set<JogoTabela>();
    public DbSet<TabelaPorJogoTabela> TabelasPorJogoTabela => Set<TabelaPorJogoTabela>();
    public DbSet<Mapa> Mapas => Set<Mapa>();
    public DbSet<JogoFfa> JogosFfa => Set<JogoFfa>();
    public DbSet<TabelaPorJogoFfa> TabelasPorJogoFfa => Set<TabelaPorJogoFfa>();
    public DbSet<PontosPorColocacao> PontosPorColocacao => Set<PontosPorColocacao>();
    public DbSet<ConfrontoFfa> ConfrontosFfa => Set<ConfrontoFfa>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Confronto>(e =>
        {
            e.HasIndex(c => new { c.TimeCasaId, c.TimeForaId, c.JogoTabelaId })
                .IsUnique();
        });
    }
}