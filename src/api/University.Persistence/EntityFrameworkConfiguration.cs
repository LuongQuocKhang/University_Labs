using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace University.Persistence
{
    public static class EntityFrameworkConfiguration
    {
        public static IServiceCollection AddEntityFramworkInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UniversityContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));

            return services;
        }
    }
}
