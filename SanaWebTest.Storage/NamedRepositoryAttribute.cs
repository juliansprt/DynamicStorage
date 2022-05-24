using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaWebTest.Storage
{


    /// <summary>
    /// Attribute to set the name of Storage name in UI
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Interface, Inherited = true, AllowMultiple = false)]
    public class NamedRepositoryAttribute : Attribute
    {
        /// <summary>
        /// Name of a repository
        /// </summary>
        public string Name { get; set; }

        public NamedRepositoryAttribute(string name)
        {
            Name = name;
        }


        public override string ToString()
        {
            return Name;
        }
    }
}
