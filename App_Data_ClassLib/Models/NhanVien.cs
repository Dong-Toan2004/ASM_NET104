using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data_ClassLib.Models
{
    public class NhanVien
    {
        public Guid IdNhanVien { get; set; }
        public Guid IdChucVu { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int TrangThai { get; set; }
        public Decimal Luong { get; set; }
        public virtual ChucVu ChucVu { get; set; }
    }
}
