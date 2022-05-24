using SanaWebTest.Storage.Entities;
using SanaWebTest.Storage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaWebTest.Storage.InMemory.Repository
{

    /// <summary>
    /// Memory storage with a default primary key
    /// </summary>
    /// <typeparam name="tEntity"></typeparam>
    public class MemoryRepository<tEntity> : MemoryRepository<tEntity, int>, IRepository<tEntity>, IMemoryRepository<tEntity>
        where tEntity : class, IEntity<int>
    {
        public MemoryRepository(IMemoryDatabaseProvider databaseProvider) 
            : base(databaseProvider)
        {
        }
    }
}
