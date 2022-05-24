using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaWebTest.Storage.InMemory
{
    /// <summary>
    /// In Memory database this must be a singleton class
    /// </summary>
    public class MemoryDatabase
    {
        private readonly Dictionary<Type, object> _database;

        private readonly object _syncObj = new object();
        public MemoryDatabase()
        {
            _database = new Dictionary<Type, object>();
        }

        public List<tEntity> Set<tEntity>()
        {
            var entityType = typeof(tEntity);
            lock (_syncObj)
            {
                if (!_database.ContainsKey(entityType))
                {
                    _database[entityType] = new List<tEntity>();
                }
                return _database[entityType] as List<tEntity>;
            }
        }
    }
}
