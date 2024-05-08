using App_Data_ClassLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data_ClassLib.ViewModels
{
    public class ViewModelGioHang
    {
        public IEnumerable<GioHangChiTiet> GioHangChiTiets { get; set; }
        public IEnumerable<SanPham> SanPhams { get; set; }
    }
}
