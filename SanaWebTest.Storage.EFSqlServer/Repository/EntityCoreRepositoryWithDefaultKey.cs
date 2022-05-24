using Microsoft.EntityFrameworkCore;
using SanaWebTest.Storage.Entities;
using SanaWebTest.Storage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaWebTest.Storage.EFSqlServer.Repository
{

    /// <summary>
    /// Implementation of repository using Entity Framework with a default primary key(int)
    /// </summary>
    /// <typeparam name="tContext"></typeparam>
    /// <typeparam name="tEntity"></typeparam>
    public class EntityCoreRepository<tContext, tEntity> : EntityCoreRepository<tContext, tEntity, int>, IRepository<tEntity>, IEFSqlServerRepository<tEntity>
        where tEntity : class, IEntity<int>
        where tContext : DbContext
    {
        public EntityCoreRepository(IDbContextProvider<tContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
