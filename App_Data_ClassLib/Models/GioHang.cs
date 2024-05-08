using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data_ClassLib.Models
{
    public class GioHang
    {
        public Guid IdGH { get; set; }
        public Guid IdUser { get; set; }
        public Decimal TongTien { get; set; }
        public int TrangThai { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<GioHangChiTiet> GioHangChiTiets { get; set; }
    }
}
