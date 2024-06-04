using API_QLSV.Models;
using lib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_QLSV.Adapters
{
    public class StudentAdapter : IStudentAdapter
    {
        public Students Adapt(StudentsModel student)
        {
            return new Students()
            {
                MaSinhVien = student.MaSinhVien,
                HoLot = student.HoLot,
                Ten = student.Ten,
                NgaySinh = student.NgaySinh,
                GioiTinh = student.GioiTinh,
                DanToc = student.DanToc,
                TonGiao = student.TonGiao,
                TrangThai = student.TrangThai,
                //CreatedOn = DateTime.Now,
                //IsDeleted = false,
                //LastModifiedOn = DateTime.Now,
                //LastModifiedBy = "User 1"
            };
        }
    }
}

