using BarnehageAdministrasjon.Interfaces;
using BarnehageAdministrasjon.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarnehageAdministrasjon.Web.API
{
    public class DependencyInjectionConfig
    {
        public static void AddScope(IServiceCollection services)
        {
            //services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IApplicationService, ApplicationService>();
        }
    }
}
