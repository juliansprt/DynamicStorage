using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaWebTest.Storage.InMemory.Helper
{
    /// <summary>
    /// Help class to generete autoincremental Id's
    /// </summary>
    /// <typeparam name="tPrimaryKey"></typeparam>
    internal class PrimaryKeyGenerator<tPrimaryKey>
    {
        private object _lastObj;

        public PrimaryKeyGenerator()
        {
            Initialize();
        }

        public tPrimaryKey GetNext()
        {
            lock (this)
            {
                return NextPrimaryKey();
            }
        }

        public void Initialize()
        {
            if (typeof(tPrimaryKey) == typeof(int))
            {
                _lastObj = 0;
            }
            else if (typeof(tPrimaryKey) == typeof(long))
            {
                _lastObj = 0L;

            }
            else if (typeof(tPrimaryKey) == typeof(short))
            {
                _lastObj = (short)0;

            }
            else if (typeof(tPrimaryKey) == typeof(byte))
            {
                _lastObj = (byte)0;

            }
            else if (typeof(tPrimaryKey) == typeof(Guid))
            {
                _lastObj = null;
            }
            else
            {
                throw new Exception($"Unsoported primary key: {typeof(tPrimaryKey).Name}");
            }
        }

        private tPrimaryKey NextPrimaryKey()
        {
            if (typeof(tPrimaryKey) == typeof(int))
            {
                _lastObj = ((int)_lastObj) + 1;
            }
            else if (typeof(tPrimaryKey) == typeof(long))
            {
                _lastObj = ((long)_lastObj) + 1L;
            }
            else if (typeof(tPrimaryKey) == typeof(short))
            {
                _lastObj = (short)(((short)_lastObj) + 1);
            }
            else if (typeof(tPrimaryKey) == typeof(byte))
            {
                _lastObj = (byte)(((byte)_lastObj) + 1);
            }
            else if (typeof(tPrimaryKey) == typeof(Guid))
            {
                _lastObj = Guid.NewGuid();
            }
            else
            {
                throw new Exception($"Unsoported primary key: {typeof(tPrimaryKey).Name}");
            }

            return (tPrimaryKey)_lastObj;
        }
    }
}
