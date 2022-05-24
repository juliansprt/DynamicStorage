using SanaWebTest.Storage.Entities;

namespace SanaWebTest.Storage.EFSqlServer
{


    /// <summary>
    /// Is a default repository with dbcontext of sana test
    /// </summary>
    /// <typeparam name="tEntity"></typeparam>
    public class SanaTestEFRepository<tEntity> : EFSqlServer.Repository.EntityCoreRepository<SanaTestDbContext, tEntity>
        where tEntity : class, IEntity<int>
    {
        public SanaTestEFRepository(IDbContextProvider<SanaTestDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
