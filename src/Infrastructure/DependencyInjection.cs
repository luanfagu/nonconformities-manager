using TesteQualyteam.Application;
using TesteQualyteam.Application.Common.Interfaces;
using TesteQualyteam.Infrastructure.Identity;
using TesteQualyteam.Infrastructure.Persistence;
using TesteQualyteam.Infrastructure.Services;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TesteQualyteam.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("TesteQualyteam.Api")));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            if (!environment.IsEnvironment("Test"))
            { 
                services.AddTransient<IDateTime, DateTimeService>();
            }

            return services;
        }
    }
}
