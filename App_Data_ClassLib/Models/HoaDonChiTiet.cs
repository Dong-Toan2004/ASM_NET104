using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data_ClassLib.Models
{
    public class HoaDonChiTiet
    {
        public Guid IdHoaDonCT { get; set; }
        public Guid IdHD { get; set; }
        public Guid IdSP { get; set; }
        public Decimal Gia { get; set; }
        public int SoLuong { get; set; }
        public Decimal ThanhTien { get; set; }
        public virtual HoaDon HoaDon { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
