using GPUHunt.Domain.Interfaces;
using GPUHunt.Infrastructure.Persistance;
using GPUHunt.Infrastructure.Repositories;
using GPUHunt.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPUHunt.Infrastructure.Extenstions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GPUHuntDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MainDatabase"));
            });

            services.AddScoped<IGraphicCardRepository, GraphicCardRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<Seeder>();
        }
    }
}
