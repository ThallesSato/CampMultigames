using CampMultigames.Application.Interfaces;
using CampMultigames.Application.Services;
using CampMultigames.Domain.Interfaces;
using CampMultigames.Infra.Context;
using CampMultigames.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CampMultigames.Application.Di;


public static class Initializer
{
    public static void ConfigureDi(this IServiceCollection services)
    {
        // bd
        services.AddDbContext<AppDbContext>(o => o.UseInMemoryDatabase("AuthDb"));

        // repositories
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        services.AddScoped(typeof(ITimeRepository), typeof(TimeRepository));
        services.AddScoped(typeof(ITabelaGeralRepository), typeof(TabelaGeralRepository));
        
        
        // services
        services.AddScoped(typeof(ITimeService), typeof(TimeService));
        services.AddScoped(typeof(ITabelaGeralService), typeof(TabelaGeralService));
        services.AddScoped(typeof(IPlayerService), typeof(PlayerService));
        services.AddScoped(typeof(IJogoService), typeof(JogoService));
        
    }
}