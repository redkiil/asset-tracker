using System.Globalization;
using FleetApi.Application.Interfaces;
using FleetApi.Application.Mappings;
using FleetApi.Application.Services;
using FleetApi.Data.Context;
using FleetApi.Data.Repositories;
using FleetApi.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FleetApi.IoC
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
                b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

            services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            services.AddScoped<IEquipmentService, EquipmentService>();

            services.AddSingleton<ILocalizerService, LocalizerService>();


            services.AddAutoMapper(typeof(DomainToDTOMapProfile));


            var myHandlers = AppDomain.CurrentDomain.Load("FleetApi.Application");
            services.AddMediatR(myHandlers);
            
            var culture = CultureInfo.GetCultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = culture;

            return services;
        }
    }
}