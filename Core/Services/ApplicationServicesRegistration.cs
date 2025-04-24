using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class ApplicationServicesRegistration
    {
        /// <summary>
        /// Adds AutoMapper Service 
        /// Adds UserManager Service
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Services.AssemblyReference).Assembly);
            services.AddScoped<IServiceManager, ServiceManager>();
            return services;
        }
    }
}
