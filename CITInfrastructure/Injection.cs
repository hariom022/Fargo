using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CITApplication.Data;
using CITApplication.Interfaces;
using CITApplication.Services;
using CITDomain.Interfaces;
using CITInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using CITInfrastructure.Repository;

namespace CITApplication
{
    public static class Injection
    {

        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddScoped<CITDbConnection>(option =>
            new CITDbConnection(configuration.GetConnectionString("DefaultConnect"))
            );

            service.AddScoped<CITDBContext>(options => options.GetService<CITDBContext>());
            service.AddScoped<CITDbConnection>(options => options.GetService<CITDbConnection>());

            //service.AddScoped<IRegistrationFormService, RegistrationFormServices>();
            //service.AddScoped<IRegistrationFormRepository, RegsitrationFormRepository>();

            return service;
        }
    }
}