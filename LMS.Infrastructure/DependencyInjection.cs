using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using LMS.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using LMS.Infrastructure.Persistence.Repositories;
using LMS.Application.Abstractions.Repositories.Identity;
using LMS.Application.Abstractions.Repositories.Records;
using LMS.Application.Abstractions.Repositories;

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
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            services.AddScoped<ISectionRepository, SectionRepository>();

            return services;
        }
    }
}
