﻿using CampMultigames.Domain.Interfaces;
using CampMultigames.Domain.Models;
using CampMultigames.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CampMultigames.Infra.Repositories;

public class JogosRepository : Repository<JogoBase>, IJogosRepository
{
    private readonly AppDbContext _context;

    public JogosRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<JogoTabela>> GetAllTabelaAsync()
    {
        return await _context.JogosTabela.ToListAsync();
    }
}