using System.Runtime.CompilerServices;

namespace LMS.API.Extensions
{
    public class JwtExtension
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection service, IConfiguration _config)
        {
            service.AddAuthentication("Bearer").AddJwtBearer
        }
    }
}
