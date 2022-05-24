using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaWebTest.Storage.InMemory
{
    public interface IMemoryDatabaseProvider
    {
        /// <summary>
        /// Gets the <see cref="MemoryDatabase"/>.
        /// </summary>
        MemoryDatabase Database { get; }
    }
}
