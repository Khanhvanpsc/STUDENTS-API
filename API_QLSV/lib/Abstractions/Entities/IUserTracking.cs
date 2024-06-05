using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib.Entity.Entities
{
    public interface IUserTracking
    {
        string CreatedBy { get; set; }
        string UpdatedBy { get; set; }
    }
}
