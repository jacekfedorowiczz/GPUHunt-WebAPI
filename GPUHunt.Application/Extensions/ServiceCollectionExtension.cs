using FluentValidation;
using FluentValidation.AspNetCore;
using GPUHunt.Application.Account.Commands.RegisterAccount;
using GPUHunt.Application.ApplicationUser;
using GPUHunt.Application.Authentication;
using GPUHunt.Application.Authorization;
using GPUHunt.Application.GraphicCard.Commands.CrawlGraphicCards;
using GPUHunt.Application.Interfaces;
using GPUHunt.Application.Services.CardComparer;
using GPUHunt.Application.Services.CardCrawler;
using GPUHunt.Application.Services.CardScraper;
using GPUHunt.Application.Services.CardSetter;
using GPUHunt.Application.Services.CardUpdater;
using GPUHunt.Application.Services.CardValidator;
using GPUHunt.Application.Services.StoreCrawlers;
using GPUHunt.Application.Services.ValidatorStrategy;
using GPUHunt.Domain.Constanst;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using IValidationStrategy = GPUHunt.Application.Interfaces.IValidationStrategy;

namespace GPUHunt.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            var authenticationSettings = new AuthenticationSettings();
            configuration.GetSection(ConstValues.Authentication).Bind(authenticationSettings);
            services.AddSingleton(authenticationSettings);

            services.AddScoped<IStoreCrawler, MoreleCrawler>();
            services.AddScoped<IStoreCrawler, XkomCrawler>();
            services.AddScoped<ICardSetter, CardSetter>();
            services.AddScoped<ICardCrawler, CardCrawler>();
            services.AddScoped<ICardComparer, CardComparer>();
            services.AddScoped<ICardValidator, CardValidator>();
            services.AddScoped<ICardUpdater, CardUpdater>();
            services.AddScoped<ICardScraper, CardScraper>();
            services.AddScoped<IPasswordHasher<Domain.Entities.Account>, PasswordHasher<Domain.Entities.Account>>();
            services.AddScoped<IUserContext, UserContext>();
            services.AddScoped<IValidatorStrategyContext, ValidatorStrategyContext>();
            services.AddScoped<IValidationStrategy, ValidationWithUpdateStrategy>();
            services.AddScoped<IValidationStrategy, ValidationWithoutUpdateStrategy>();
            services.AddScoped<IAuthorizationHandler, AccountOperationRequirementHandler>();
            
            services.AddHttpContextAccessor();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(CrawlGraphicCardsCommand)));
            services.AddAutoMapper(cfg => cfg.AddMaps(typeof(ServiceCollectionExtension).Assembly));

            services.AddValidatorsFromAssemblyContaining<RegisterAccountDtoValidator>()
                        .AddFluentValidationAutoValidation()
                        .AddFluentValidationClientsideAdapters();


            services.AddAuthorization(options =>
            {
                // TODO: DODAJ JEDNĄ CUSTOMOWĄ POLITYKĘ AUTORYZACJI
                //options.AddPolicy("testName", builder => builder.AddRequirements(new Requirement))
            });


            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = ConstValues.Bearer;
                option.DefaultScheme = ConstValues.Bearer;
                option.DefaultChallengeScheme = ConstValues.Bearer;

            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authenticationSettings.JwtIssuer,
                    ValidAudience = authenticationSettings.JwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
                };
            });
        }
    }
}
