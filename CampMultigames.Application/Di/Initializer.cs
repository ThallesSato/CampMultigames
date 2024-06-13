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
        //services.AddDbContext<AppDbContext>(o => o.UseInMemoryDatabase("AuthDb"));
        services.AddDbContext<AppDbContext>(o => o.UseSqlite("Data Source = Database"));

        // repositories
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        services.AddScoped(typeof(ITimeRepository), typeof(TimeRepository));
        services.AddScoped(typeof(ITabelaGeralRepository), typeof(TabelaGeralRepository));
        services.AddScoped(typeof(ITabelaPorJogoTabelaRepository), typeof(TabelaPorJogoTabelaRepository));
        services.AddScoped(typeof(IJogosRepository), typeof(JogosRepository));
        services.AddScoped(typeof(IConfrontoRepository), typeof(ConfrontoRepository));
        services.AddScoped(typeof(ITabelaPorJogoFfaRepository), typeof(TabelaPorJogoFfaRepository));
        services.AddScoped(typeof(IPontosPorColocacaoRepository), typeof(PontosPorColocacaoRepository));
        
        
        
        // services
        services.AddScoped(typeof(ITabelaGeralService), typeof(TabelaGeralService));
        services.AddScoped(typeof(ITabelaPorJogoTabelaService), typeof(TabelaPorJogoTabelaService));
        services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
        services.AddScoped(typeof(IConfrontoService), typeof(ConfrontoService));
        services.AddScoped(typeof(IJogoService), typeof(JogoService));
        services.AddScoped(typeof(ITimeService), typeof(TimeService));
        services.AddScoped(typeof(ITabelaPorJogoFfaService), typeof(TabelaPorJogoFfaService));
        services.AddScoped(typeof(IPontosPorColocacaoService), typeof(PontosPorColocacaoService));
        
    }
}