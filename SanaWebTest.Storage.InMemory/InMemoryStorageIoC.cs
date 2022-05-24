using Microsoft.Extensions.DependencyInjection;
using SanaWebTest.Storage.InMemory;
using SanaWebTest.Storage.InMemory.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaWebTest.Storage
{
    public static class InMemoryStorageIoC
    {

        public static IServiceCollection ConfigureMemoryStorage(this IServiceCollection service)
        {
            service.AddSingleton<IMemoryDatabaseProvider>((service) =>
            {
                var provider =  new DefaultMemoryDatabaseProviver();
                return provider;

            });
            service.AddTransient(typeof(IMemoryRepository<>), typeof(MemoryRepository<>));
            return service;
        }

        public static IServiceCollection ConfigureMemoryStorage(this IServiceCollection service, IMemoryDatabaseProvider provider)
        {
            service.AddSingleton<IMemoryDatabaseProvider>(provider);
            return service;
        }


        public static IServiceCollection ConfigureMemoryStorage(this IServiceCollection service, Func<IServiceProvider, IMemoryDatabaseProvider> funcProvider)
        {
            service.AddSingleton<IMemoryDatabaseProvider>(funcProvider);
            return service;
        }

    }
}
