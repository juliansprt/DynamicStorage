using Microsoft.Extensions.DependencyInjection;
using SanaWebTest.Storage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaWebTest.Storage
{
    public static class StorageIoC
    {

        /// <summary>
        /// Configure de Storage Dynamic Engine
        /// </summary>
        /// <param name="service"></param>
        /// <param name="repositoryRegister"></param>
        /// <returns></returns>
        public static IServiceCollection StorageConfigure(this IServiceCollection service, params Type[] repositoryRegister)
        {
            service.AddSingleton<IStorageContainer>((serv) =>
            {
                StorageContainer container = new StorageContainer();
                var firstRepository = repositoryRegister.FirstOrDefault();
                foreach (var item in repositoryRegister)
                {
                    container.Register(item);
                }
                container.SetCurrent(firstRepository.FullName);
                return container;
            });

            service.AddScoped(typeof(IRepository<>), typeof(StorageRepository<>)); //This capsulate all StorageType in StorageReposityr class
            return service;
        }
    }
}
