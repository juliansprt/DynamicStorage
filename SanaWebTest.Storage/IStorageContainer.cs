using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaWebTest.Storage
{

    /// <summary>
    /// Container of a Storage types
    /// </summary>
    public interface IStorageContainer
    {

        /// <summary>
        /// Get all storage types
        /// </summary>
        /// <returns></returns>
        Dictionary<string, string> GetStorages();


        /// <summary>
        /// Register a Storage Type
        /// </summary>
        /// <param name="type"></param>
        void Register(Type type);


        /// <summary>
        /// Unregister a Storage type
        /// </summary>
        /// <param name="type"></param>
        void UnRegister(Type type);


        /// <summary>
        /// Set a current storage by type fullname
        /// </summary>
        /// <param name="typeName"></param>
        void SetCurrent(string typeName);
    

        /// <summary>
        /// Get a current storage type
        /// </summary>
        /// <returns></returns>
        Type GetCurrent();

    }
}
