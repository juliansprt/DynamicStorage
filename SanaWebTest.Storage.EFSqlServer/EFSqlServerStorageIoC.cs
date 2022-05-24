using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SanaWebTest.Storage.EFSqlServer;
using SanaWebTest.Storage.EFSqlServer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaWebTest.Storage
{
    public static class EFSqlServerStorageIoC
    {


        public static IServiceCollection ConfigureEntityFrameworkSqlServer<dbContext>(this IServiceCollection service, string connectionString, Type entityCoreRepository)
            where dbContext: DbContext
        {
            service.AddDbContext<dbContext>(p => p.UseSqlServer(connectionString));
            service.AddTransient<IDbContextProvider<dbContext>>((service) =>
            {
                var dbContext = service.GetService<dbContext>();
                if (dbContext == null)
                    throw new Exception("You must instance a DbContext");
                return new DefaultDbContextProvider<dbContext>(dbContext);
            });

            service.AddTransient(typeof(IEFSqlServerRepository<>), entityCoreRepository);
            return service;
        }
    }
}
