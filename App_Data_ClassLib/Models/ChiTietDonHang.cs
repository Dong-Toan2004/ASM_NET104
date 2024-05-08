using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data_ClassLib.Models
{
    public class ChiTietDonHang
    {
        public Guid IdCTDonHang { get; set; }
        public Guid IdDonHang { get; set;}
        public Guid IdSP {  get; set; }
        public int SoLuong { get; set; }
        public Decimal Gia { get; set; }
        public Decimal ThanhTien { get; set; }
        public virtual DonHang DonHang { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
