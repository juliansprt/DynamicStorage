using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaWebTest.Storage.InMemory
{
    public  class DefaultMemoryDatabaseProviver : IMemoryDatabaseProvider
    {
        private MemoryDatabase _database;

        public DefaultMemoryDatabaseProviver()
        {
            _database = new MemoryDatabase();
        }
        public MemoryDatabase Database => _database;
    }
}
