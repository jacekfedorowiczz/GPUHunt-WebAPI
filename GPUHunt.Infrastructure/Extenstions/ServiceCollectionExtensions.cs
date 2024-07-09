using GPUHunt.Domain.Interfaces;
using GPUHunt.Infrastructure.Persistance;
using GPUHunt.Infrastructure.Repositories;
using GPUHunt.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GPUHunt.Infrastructure.Extenstions
{
    public static class ServiceCollectionExtensions
    {
        private const string _localConnectionString = "MainDatabase";

        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GPUHuntDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(_localConnectionString));
            });

            services.AddScoped<IGraphicCardRepository, GraphicCardRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<Seeder>();
        }
    }
}
