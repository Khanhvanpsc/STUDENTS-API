using API_QLSV.Models;
using lib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_QLSV.Adapters
{
    public interface IStudentAdapter
    {
        Students Adapt(StudentsModel student);
    }
}
