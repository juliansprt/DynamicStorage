using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaWebTest.Storage.EFSqlServer.Repository
{
    public interface IRepositoryWithDbContext
    {
        DbContext GetDbContext();

        Task<DbContext> GetDbContextAsync();
    }
}
