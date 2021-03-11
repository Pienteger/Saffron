using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saffron.Services
{
    public static class SaffronServices
    {
        public static IServiceCollection AddSaffronServices(
             this IServiceCollection services)
        {
            services.AddSingleton<IMenuService,MenuService>();
            return services;
        }
    }
}
