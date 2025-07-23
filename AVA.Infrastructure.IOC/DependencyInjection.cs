using AVA.Application.Interfaces;
using AVA.Application.Services;
using AVA.Domain.Interfaces;
using AVA.Infrastructure.Repositories;
using AVA.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AVA.Application.Security;
using AVA.Application.Interfaces.Security;



namespace AVA.Infrastructure.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // Application Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<JwtTokenGenerator>();

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();

            // DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            

            return services;
        }

    }
}
