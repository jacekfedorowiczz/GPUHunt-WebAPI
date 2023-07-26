using GPUHunt.Application.Interfaces;
using GPUHunt.Application.Services.CardSetter;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPUHunt.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICardSetter, CardSetter>();
        }
    }
}
