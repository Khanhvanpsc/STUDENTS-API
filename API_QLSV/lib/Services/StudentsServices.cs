using lib.Entity;
using lib.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib.Services
{
    public interface IStudentsService
    {
        void Save();
        List<Students> GetStudentsList();
        void InsertStudents(Students st);
        void ChangeStudents(Students student);

        void DeleteStudents(Students student);
    }

    public class StudentsServices : IStudentsService
    {
        private IStudentsRepository StudentsRepository { get; set; }
        private ApplicationDbContext dbContext;

        public StudentsServices(ApplicationDbContext dbContext, IStudentsRepository StudentsRepository)
        {
            this.dbContext = dbContext;
            this.StudentsRepository = StudentsRepository;
        }
        public void Save()
        {
            dbContext.SaveChanges();
        }
        public List<Students> GetStudentsList()
        {
            return StudentsRepository.GetStudentsList();
        }
        public void InsertStudents(Students st)
        {
            StudentsRepository.Add(st);
            Save();
        }
        public void ChangeStudents(Students student)
        {
            Students st = dbContext.Students.Where(p => p.MaSinhVien == student.MaSinhVien).FirstOrDefault();
            st.HoLot = student.HoLot;
            st.Ten = student.Ten;
            st.NgaySinh = student.NgaySinh;
            st.GioiTinh = student.GioiTinh;
            st.DanToc = student.DanToc;
            st.TonGiao = student.TonGiao;
            st.TrangThai = student.TrangThai;
            StudentsRepository.Update(st);
            Save();
        }
        public void DeleteStudents(Students student)
        {
            StudentsRepository.Delete(student);
            Save();
        }

        public async Task<Students> GetStudentById(int Id)
        {
           return await dbContext.Students.Where(p => p.MaSinhVien == Id).FirstOrDefaultAsync();
        }
    }
}
