using SanaWebTest.Storage.Entities;
using SanaWebTest.Storage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaWebTest.Storage.EFSqlServer.Repository
{
    public interface IEFSqlServerRepository<tEntity, tPrimaryKey> : IRepository<tEntity, tPrimaryKey>
        where tEntity : class, IEntity<tPrimaryKey>
    {
    }



    /// <summary>
    /// Interface to build repository 
    /// </summary>
    /// <typeparam name="tEntity"></typeparam>
    [NamedRepository("Sql Database (EF)")]
    public interface IEFSqlServerRepository<tEntity>: IRepository<tEntity, int>
        where tEntity : class, IEntity<int>
    {

    }
}
