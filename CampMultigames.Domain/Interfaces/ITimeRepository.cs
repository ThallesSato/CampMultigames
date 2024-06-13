﻿using CampMultigames.Domain.Models;

namespace CampMultigames.Domain.Interfaces;

public interface ITimeRepository : IRepository<Time>
{
    new Task<List<Time>> GetAllAsync();
    new Task<Time?> GetByIdOrDefaultAsync(int id);
}