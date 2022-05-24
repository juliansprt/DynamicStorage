using Microsoft.EntityFrameworkCore;

namespace SanaWebTest.Storage.EFSqlServer
{
    public interface IDbContextProvider<tContext>
        where tContext : DbContext
    {
        Task<tContext> GetDbContextAsync();


        tContext GetDbContext();
    }
}