using App_Data_ClassLib.Models;
using App_Data_ClassLib.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App_MVC.Controllers
{
    public class SanPhamController : Controller
    {
        SD18302_NET104Context _context;
        DbSet<SanPham> _sanPham;
        AllRepository<SanPham> _repository;
        public SanPhamController()
        {
            //Khởi tạo dbcontext
            _context = new SD18302_NET104Context();
            //Khỏi tạo repository với 2 tham số dbset và dbcontext
            _sanPham = _context.SanPhams;
            _repository = new AllRepository<SanPham>(_sanPham, _context);
        }
        //Lấy ra tất cả danh sách Sản phẩm
        public IActionResult Index()
        {
            var sanPham = _repository.GetAll();
            return View(sanPham);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SanPham sanPham,IFormFile imgFile)
        {
            sanPham.IdSP = Guid.NewGuid();
            //Xây dựng 1 đường dẫn lưu hình ảnh
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", imgFile.FileName);
            //Kết quả thu được có dạng như sau: wwwroot/img/config.png
            //Thực hiện sao chép file được chọn vào thư mục
            var stream = new FileStream(path, FileMode.Create);
            //Thực hiện sao chép ảnh vào thư mục root
            imgFile.CopyTo(stream);
            sanPham.Anh = imgFile.FileName;
            _repository.CreateObj(sanPham);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(Guid id)
        {
            var updateData = _repository.GetByID(id);
            return View(updateData);
        }

        [HttpPost]
        public IActionResult Edit(SanPham sanPham, IFormFile imgFile)
        {
            if (imgFile != null && imgFile.Length > 0)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + imgFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imgFile.CopyTo(fileStream);
                }

                sanPham.Anh = uniqueFileName; // Lưu tên tệp vào cơ sở dữ liệu, không phải là imgFile.FileName
            }

            _repository.UpdateObj(sanPham);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            _repository.DeleteObj(id);
            return RedirectToAction("Index");
        }
        //Thông tin
        public IActionResult Details(Guid id)
        {
            var getSanPham = _repository.GetByID(id);
            return View(getSanPham);
        }


    }
}
