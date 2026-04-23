using Microsoft.Extensions.DependencyInjection;
using Sortech_Assignment.Application.IServices;
using Sortech_Assignment.Domain.IRepository;
using Sortech_Assignment.Infrastructure.ExternalCalling.IPgeoLocation;
using Sortech_Assignment.Infrastructure.Memory;
using Sortech_Assignment.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortech_Assignment.Infrastructure.DependencyInjection
{
    public static class InfrastructureDI
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddSingleton<InMemoryContext>();
            
            services.AddSingleton<IBlockCountryRepository, BlockCountryRepository>();
            services.AddSingleton<ILocationServices, IPgeoLocationCalling>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
