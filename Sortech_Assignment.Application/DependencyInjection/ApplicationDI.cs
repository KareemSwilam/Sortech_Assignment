using Microsoft.Extensions.DependencyInjection;
using Sortech_Assignment.Application.IServices;
using Sortech_Assignment.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortech_Assignment.Application.DependencyInjection
{
    public static class ApplicationDI
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddScoped<ICountryServices, CountryServices>();
            return services;
        }
    }
}
