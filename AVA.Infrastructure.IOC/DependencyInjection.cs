using AVA.Application.Interfaces;
using AVA.Application.Services;
using AVA.Domain.Interfaces;
using AVA.Infrastructure;
using AVA.Infrastructure.Repositories;
using AVA.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace AVA.Infrastructure.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // Application Services
            services.AddScoped<IUserService, UserService>();

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();

            // DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            // Outros serviços de infraestrutura (ex: Email, SignalR, etc)
            // services.AddScoped<IEmailService, EmailService>();

            return services;
        }

    }
}
