using Microsoft.EntityFrameworkCore;

namespace CampMultigames.Infra.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}