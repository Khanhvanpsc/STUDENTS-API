using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_QLSV.Models
{
    public class StudentsModel
    {
        public int MaSinhVien { get; set; }
        public string HoLot { get; set; }
        public string Ten { get; set; }
        public string NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DanToc { get; set; }
        public string TonGiao { get; set; }
        public int TrangThai { get; set; }
    }
}
