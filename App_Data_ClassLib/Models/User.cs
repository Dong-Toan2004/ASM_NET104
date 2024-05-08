using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data_ClassLib.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string PhongNumber {get; set; }
        public string Address { get; set; }
        public DateTime DoB { get; set; }//Ngày sinh
        public virtual ICollection<HoaDon> HoaDons { get; set; }  
        // ICollection<HoaDon> HoaDons chỉ để thể hiện 1 user có thể có nhiều hóa đơn                                                                 
        // ICollection<HoaDon> còn được sử dụng để làm Navigation để trỏ đến khi cần
        public virtual GioHang GioHang { get; set; }
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
