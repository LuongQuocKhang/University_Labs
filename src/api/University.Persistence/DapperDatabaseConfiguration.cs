using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Persistence
{
    public static class DapperDatabaseConfiguration
    {
        public static IServiceCollection AddDapperConfiguration(this IServiceCollection services)
        {
            services.AddSingleton<UniversityContextDapper>();
            return services;
        }
    }
}
