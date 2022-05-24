using SanaWebTest.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaWebTest.Storage.Repository
{
    public class StorageRepository<tEntity> : StorageRepository<tEntity, int>, IRepository<tEntity>
        where tEntity : class, IEntity<int>
    {
        public StorageRepository(IStorageContainer container, IServiceProvider serviceProvider) : base(container, serviceProvider)
        {
        }
    }
}
