using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaWebTest.Storage.Entities
{

    /// <summary>
    /// Is basic Entity implementation
    /// </summary>
    /// <typeparam name="tPrimaryKey"></typeparam>
    public interface IEntity<tPrimaryKey>
    {
        tPrimaryKey Id { get; set; }

        DateTime CreateDate { get; set; }


        DateTime? UpdateDate { get; set; }
    }
}
