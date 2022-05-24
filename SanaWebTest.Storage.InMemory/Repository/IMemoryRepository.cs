using SanaWebTest.Storage.Entities;
using SanaWebTest.Storage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaWebTest.Storage.InMemory.Repository
{
    public interface IMemoryRepository<tEntity, tPrimaryKey> : IRepository<tEntity, tPrimaryKey>
         where tEntity : class, IEntity<tPrimaryKey>
    {
    }

    /// <summary>
    /// Interface to build a repository
    /// </summary>
    /// <typeparam name="tEntity"></typeparam>

    [NamedRepository("In Memory Database")]
    public interface IMemoryRepository<tEntity> : IRepository<tEntity, int>
        where tEntity : class, IEntity<int>
    { 
    }
}
