using SanaWebTest.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaWebTest.Storage.Repository
{

    /// <summary>
    /// Implementation of the repository with (int as primary key)
    /// </summary>
    /// <typeparam name="tEntity"></typeparam>
    public interface IRepository<tEntity> : IRepository<tEntity, int>
        where tEntity: class, IEntity<int>
    {
    }
}
