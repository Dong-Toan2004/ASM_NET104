using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data_ClassLib.Models
{
    public class SanPham
    {
        public Guid IdSP { get; set; }
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public int SoLuong { get; set; }
        public int TrangThai { get; set; }
        public string TacGia { get; set; }
        public string Anh { get; set; }
        public Guid IdDMSP { get; set; }
        public virtual DanhMucSP DanhMucSP { get; set; }
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        public virtual ICollection<GioHangChiTiet> GioHangChiTiets { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}
