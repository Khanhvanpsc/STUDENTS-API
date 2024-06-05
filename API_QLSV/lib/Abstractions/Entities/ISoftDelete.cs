﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib.Abstractions.Entities
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
        DateTime DeletedAt { get; set; }
        string DeletedBy { get; set; }
    }
}
