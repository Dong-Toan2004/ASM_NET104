using App_Data_ClassLib.Models;
using App_Data_ClassLib.Repository;
using App_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace App_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        SD18302_NET104Context _context;
        DbSet<GioHang> _gioHangs;
        AllRepository<GioHang> _repository;

        public HomeController()
        {
            //Khởi tạo dbcontext
            _context = new SD18302_NET104Context();
            _gioHangs = _context.GioHangs;
            _repository = new AllRepository<GioHang>(_gioHangs, _context);
        }

        public IActionResult Index(string name)
        {
            var sanPham = _context.SanPhams.ToList();
            if (string.IsNullOrEmpty(name))
            {
                return View(sanPham);
            }
            else
            {
                var searchData = _context.SanPhams.Where(x => x.Name.Contains(name)).ToList(); // Tìm theo tên           
                ViewData["count"] = searchData.Count;
                ViewBag.Count = searchData.Count;
                if (searchData.Count == 0) // Nếu ko tìm thấy 
                {
                    return View(sanPham);
                }
                else return View(searchData); // có tìm thấy
            }
        }

        public ActionResult ThemSanPhamVaoGioHang(Guid idSanPham, int soLuong)
        {
            var sessionData = HttpContext.Session.GetString("user");
            if (soLuong < 0)
            {
                return Content("Số lượng không được âm");
            }
            if (sessionData == null)
            {
                // Redirect đến trang đăng nhập nếu người dùng chưa đăng nhập
                return RedirectToAction("Login", "User");
            }
            else
            {
                var userId = sessionData;

                var user = _context.Users.FirstOrDefault(p => p.Id == Guid.Parse(userId));
                if (user == null)
                {
                    return Content("Người dùng không tồn tại trong cơ sở dữ liệu");
                }

                // Lấy giỏ hàng của người dùng từ cơ sở dữ liệu
                GioHang gioHang = _context.GioHangs.FirstOrDefault(g => g.IdUser == user.Id);
                if (gioHang == null)
                {
                    // Nếu giỏ hàng chưa tồn tại, tạo mới
                    gioHang = new GioHang
                    {
                        IdGH = user.Id,
                        IdUser = user.Id,
                        TongTien = 0,
                        TrangThai = 1
                    };
                    _repository.CreateObj(gioHang);
                }

                // Lấy thông tin sản phẩm từ cơ sở dữ liệu
                var sanPham = _context.SanPhams.FirstOrDefault(sp => sp.IdSP == idSanPham);
                if (sanPham == null)
                {
                    return Content("Sản phẩm không tồn tại trong cơ sở dữ liệu");
                }
                // Kiểm tra xem sản phẩm đã có trong giỏ hàng chưa
                GioHangChiTiet gioHangChiTiet = _context.GioHangChiTiets.FirstOrDefault(g => g.IdSP == idSanPham && g.IdGioHoang == user.Id);
                if (gioHangChiTiet != null && soLuong == 0)
                {
                    // Nếu đã có, tăng số lượng lên 1
                    gioHangChiTiet.SoLuong++;
                    gioHangChiTiet.ThanhTien = sanPham.Price * gioHangChiTiet.SoLuong;
                    if (gioHangChiTiet.SoLuong > sanPham.SoLuong)
                    {
                        return Content("Sản phẩm không đủ số lượng");
                    }
                    //else if (gioHangChiTiet.SoLuong > soLuong)
                    //{
                    //    var soLuongMoi = gioHangChiTiet.SoLuong - soLuong;
                    //    sanPham.SoLuong = sanPham.SoLuong + soLuongMoi;
                    //    _context.SanPhams.Update(sanPham);
                    //}
                    else
                    {
                        sanPham.SoLuong = sanPham.SoLuong - gioHangChiTiet.SoLuong;
                        _context.SanPhams.Update(sanPham);
                    }
                }
                else if (gioHangChiTiet != null && soLuong != 0)
                {
                    gioHangChiTiet.SoLuong = soLuong;
                    gioHangChiTiet.ThanhTien = sanPham.Price * soLuong;
                    if (gioHangChiTiet.SoLuong > sanPham.SoLuong)
                    {
                        return Content("Sản phẩm không đủ số lượng");
                    }
                    //else if (gioHangChiTiet.SoLuong > soLuong)
                    //{
                    //    var soLuongMoi = gioHangChiTiet.SoLuong - soLuong;
                    //    sanPham.SoLuong = sanPham.SoLuong + soLuongMoi;
                    //    _context.SanPhams.Update(sanPham);
                    //}
                    else
                    {
                        sanPham.SoLuong = sanPham.SoLuong - gioHangChiTiet.SoLuong;
                        _context.SanPhams.Update(sanPham);
                    }
                }
                else
                {
                    // Nếu chưa có, thêm mới vào giỏ hàng
                    gioHangChiTiet = new GioHangChiTiet
                    {
                        IdGioHangCT = Guid.NewGuid(),
                        IdSP = idSanPham,
                        IdGioHoang = user.Id,
                        SoLuong = 1,
                        DonGia = sanPham.Price,
                        ThanhTien = sanPham.Price
                    };
                    if (gioHangChiTiet.SoLuong > sanPham.SoLuong)
                    {
                        return Content("Sản phẩm không đủ số lượng");
                    }
                    else
                    {
                        sanPham.SoLuong = sanPham.SoLuong - gioHangChiTiet.SoLuong;
                        _context.SanPhams.Update(sanPham);
                    }
                    _context.SanPhams.Update(sanPham);
                    _context.GioHangChiTiets.Add(gioHangChiTiet);
                }
                // Cập nhật tổng tiền của giỏ hàng
                gioHang.TongTien += sanPham.Price;
                _context.SaveChanges();

                // Chuyển hướng người dùng về trang giỏ hàng
                return RedirectToAction("Index", "GioHang");
            }
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}