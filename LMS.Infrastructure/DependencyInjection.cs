using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using LMS.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using LMS.Infrastructure.Persistence.Repositories;
using LMS.Application.Abstractions.Repositories.Identity;

namespace LMS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseNpgsql("Database");
            }); 

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
