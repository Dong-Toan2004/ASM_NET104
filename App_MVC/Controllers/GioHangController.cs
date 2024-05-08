using App_Data_ClassLib.Models;
using App_Data_ClassLib.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App_MVC.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHangController
        SD18302_NET104Context _context;
        DbSet<GioHang> _gioHangs;
        AllRepository<GioHang> _repository;
        public GioHangController()
        {
            _context = new SD18302_NET104Context();
            _gioHangs = _context.GioHangs;
            _repository = new AllRepository<GioHang>(_gioHangs,_context);
        }
        public ActionResult Index()
        {
            var sessionData = HttpContext.Session.GetString("user");
            if (sessionData == null)
            {
                // Redirect đến trang đăng nhập nếu người dùng chưa đăng nhập
                return RedirectToAction("Login", "User");
            }
            else
            {
                var user = _context.Users.FirstOrDefault(p => p.Id == Guid.Parse(sessionData));
                var data = _context.GioHangChiTiets.Where(x => x.IdGioHoang == Guid.Parse(sessionData)).ToList();
                return View(data);
            }
        }

        // GET: GioHangController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GioHangController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GioHangController/Create
        //[HttpPost]
        //public ActionResult Create(Guid idSanPham)
        //{
        //    var sessionData = HttpContext.Session.GetString("user");
        //    if (sessionData == null)
        //    {
        //        // Redirect đến trang đăng nhập nếu người dùng chưa đăng nhập
        //        return RedirectToAction("Login", "User");
        //    }
        //    else
        //    {
        //        var username = sessionData;

        //        var user = _context.Users.FirstOrDefault(p => p.Username == username);
        //        if (user == null)
        //        {
        //            return Content("Người dùng không tồn tại trong cơ sở dữ liệu");
        //        }

        //        // Lấy giỏ hàng của người dùng từ cơ sở dữ liệu
        //        GioHang gioHang = _context.GioHangs.FirstOrDefault(g => g.IdUser == user.Id );
        //        if (gioHang == null)
        //        {
        //            // Nếu giỏ hàng chưa tồn tại, tạo mới
        //            gioHang = new GioHang
        //            {
        //                IdGH = Guid.NewGuid(),
        //                IdUser = user.Id,
        //                TongTien = 0,
        //                TrangThai = 1
        //            };
        //            _repository.CreateObj(gioHang);
        //        }

        //        // Lấy thông tin sản phẩm từ cơ sở dữ liệu
        //        var sanPham = _context.SanPhams.FirstOrDefault(sp => sp.IdSP == idSanPham);
        //        if (sanPham == null)
        //        {
        //            return Content("Sản phẩm không tồn tại trong cơ sở dữ liệu");
        //        }

        //        // Kiểm tra xem sản phẩm đã có trong giỏ hàng chưa
        //        var gioHangChiTiet = gioHang.GioHangChiTiets.FirstOrDefault(g => g.IdSP == idSanPham);
        //        if (gioHangChiTiet != null)
        //        {
        //            // Nếu đã có, tăng số lượng lên 1
        //            gioHangChiTiet.SoLuong++;
        //            gioHangChiTiet.ThanhTien += sanPham.Price;
        //        }
        //        else
        //        {
        //            // Nếu chưa có, thêm mới vào giỏ hàng
        //            gioHangChiTiet = new GioHangChiTiet
        //            {
        //                IdGioHangCT = Guid.NewGuid(),
        //                IdSP = idSanPham,
        //                IdGioHoang = gioHang.IdGH,
        //                SoLuong = 1,
        //                DonGia = sanPham.Price,
        //                ThanhTien = sanPham.Price
        //            };
        //            gioHang.GioHangChiTiets.Add(gioHangChiTiet);
        //        }

        //        // Cập nhật tổng tiền của giỏ hàng
        //        gioHang.TongTien += sanPham.Price;
        //        _repository.CreateObj(gioHang);

        //        // Chuyển hướng người dùng về trang giỏ hàng
        //        return RedirectToAction("Index", "GioHang");
        //    }
        //}

        // GET: GioHangController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GioHangController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GioHangController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var giohangCT = _context.GioHangChiTiets.FirstOrDefault(x=>x.IdGioHangCT == id);
            _context.GioHangChiTiets.Remove(giohangCT);
            _context.SaveChanges();
            return RedirectToAction("Index","GioHang");
        }

        // POST: GioHangController/Delete/5
        
    }
}
