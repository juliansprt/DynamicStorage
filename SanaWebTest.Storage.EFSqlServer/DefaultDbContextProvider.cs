using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaWebTest.Storage.EFSqlServer
{
    public class DefaultDbContextProvider<tContext> : IDbContextProvider<tContext>
        where tContext: DbContext
    {

        public tContext DbContext { get; }


        public DefaultDbContextProvider(tContext context)
        {
            DbContext = context;
        }
        public tContext GetDbContext()
        {
            return DbContext;
        }

        public Task<tContext> GetDbContextAsync()
        {
            return Task.FromResult(DbContext);
        }
    }
}
