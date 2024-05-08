using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data_ClassLib.Models
{
    public class ChucVu
    {
        public Guid IdChucVu { get; set; }
        public string Name { get; set; }
        public string MoTa { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
