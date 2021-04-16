using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Saffron.Services.BlogServices;
using Saffron.Services.CoreServices;
using Saffron.Services.CoreServices.Menu;

namespace Saffron.Services
{
    public static class SaffronServices
    {
        public static IServiceCollection AddSaffronServices(
             this IServiceCollection services)
        {
            services.AddScoped<IMenuService,MenuService>();
            services.AddScoped<UtilityService>();
            services.AddSingleton<NavigationService>();
            services.AddScoped<IBlogService, BlogService>();

            return services;
        }
    }
}
