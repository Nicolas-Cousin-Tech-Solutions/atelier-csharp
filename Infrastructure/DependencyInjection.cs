using Application.Interfaces.Services;
using Application.Services;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"))
            );

            // Enregistrement des repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IDossierRepository, DossierRepository>();
            services.AddScoped<IEtablissementRepository, EtablissementRepository>();
            services.AddScoped<ITransmissionRepository, TransmissionRepository>();
            services.AddScoped<IAgentVerbalisateurRepository, AgentVerbalisateurRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IAgentRepository, AgentRepository>();

            services.AddScoped<IDossierService, DossierService>();

            return services;
        }
    }
}
