using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data_ClassLib.Models
{
    public class DanhMucSP
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<SanPham> SanPhams { get; set; }
        // ICollection<HoaDon> HoaDons chỉ để thể hiện 1 user có thể có nhiều hóa đơn                                                                 
        // ICollection<HoaDon> còn được sử dụng để làm Navigation để trỏ đến khi cần
    }
}
