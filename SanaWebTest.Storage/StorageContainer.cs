using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SanaWebTest.Storage
{

    /// <summary>
    /// Implementation of Storage container
    /// This class manage all storage types
    /// </summary>
    public class StorageContainer : IStorageContainer
    {
        public Type Current { get; private set; }

        private Dictionary<string, (Type type, string name)> Storages;

        public StorageContainer()
        {
            Storages = new Dictionary<string, (Type type, string name)>();
        }

        public Type GetCurrent()
        {
            return Current;
        }

        public Dictionary<string, string> GetStorages()
        {
            return Storages.ToDictionary(p => p.Key, p => p.Value.name);
        }

        public void Register(Type type)
        {
            lock (this)
            {
                if (!Storages.ContainsKey(type.FullName))
                {
                    string name = type.Name;
                    NamedRepositoryAttribute namedRepository = type.GetCustomAttribute<NamedRepositoryAttribute>();
                    if (namedRepository != null)
                        name = namedRepository.ToString();
                    Storages.Add(type.FullName,(type, name));
                }
            }
        }

        public void SetCurrent(string typeName)
        {
            if (!Storages.ContainsKey(typeName))
            {
                throw new Exception($"You must register the assembly: {typeName}");
            }
            Current = Storages[typeName].type;
        }

        public void UnRegister(Type type)
        {
            lock (this)
            {
                if (Storages.ContainsKey(type.FullName))
                {
                    Storages.Remove(type.FullName);
                }
            }

        }
    }
}
