using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CITApplication.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;

namespace CITApplication
{
    public static class Injection
    {
        public static IServiceCollection RegisterApplicationsServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRegisteredServices, RegisteredServices>();
            return services;
        }
    }
}
