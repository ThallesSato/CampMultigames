using CampMultigames.Domain.Interfaces;
using CampMultigames.Domain.Models;
using CampMultigames.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CampMultigames.Infra.Repositories;

public class PontosPorColocacaoRepository : Repository<PontosPorColocacao>, IPontosPorColocacaoRepository
{
    private readonly AppDbContext _context;
    public PontosPorColocacaoRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public Task<PontosPorColocacao?> GetByJogoAndPosicaoAsync(JogoFfa jogo, int posicao)
    {
        return _context.PontosPorColocacao
            .FirstOrDefaultAsync(p => p.JogoFfaId == jogo.Id && p.Colocacao == posicao);
    }
}