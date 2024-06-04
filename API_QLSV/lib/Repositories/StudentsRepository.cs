using lib.data;
using lib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib.Repositories
{
    public interface IStudentsRepository : IRepository<Students>
    {
        List<Students> GetStudentsList();
    }
    public class StudentsRepository : RepositoryBase<Students>, IStudentsRepository
    {
        public StudentsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
        public List<Students> GetStudentsList()
        {
            var query = _dbcontext.Students.AsQueryable();
            return query.ToList();
        }
    }
}
