using DataAccess;
using Hellang.Middleware.ProblemDetails;
using Logic;
using Microsoft.EntityFrameworkCore;
using Services;
using System.Reflection;

namespace WebApp.Helpers.Services
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabaseLayer(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options
                .UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            }, ServiceLifetime.Scoped); //DbContext 
            return services;
        }

        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {

            services.AddScoped<DeckSerivce>();
            services.AddScoped<CardService>();
            services.AddScoped<CardImageService>();

            return services;
        }

        public static IServiceCollection AddLogicLayer(this IServiceCollection services)
        {
            services.AddScoped<CardLogic>();

            return services;
        }

        public static IServiceCollection AddHelpers(this IServiceCollection services)
        {
            services.AddScoped<FileHelper>();

            return services;
        }

        public static IServiceCollection AddOtherService(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer(); //Swagger
            services.AddSwaggerGen(); //Swagger

            services.AddAutoMapper(Assembly.GetAssembly(typeof(DeckSerivce)));

            services.AddProblemDetails(options =>
            {
                options.IsProblem = httpContext => new ProblemDetailsMiddlewareHelper().IsProblem(httpContext);
            });

            return services;
        }
    }
}
