using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data_ClassLib.Models
{
    public class DonHang
    {
        public Guid IdDonHang { get; set; }
        public Guid IdUser { get; set; }
        public DateTime NgayTao { get; set; }
        public Decimal TongTien { get; set; }
        public int TrangThai { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual User User { get; set; }
        
    }
}
