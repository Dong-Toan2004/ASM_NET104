using App_Data_ClassLib.Models;
using App_Data_ClassLib.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;

namespace App_MVC.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVienController
        SD18302_NET104Context _context;
        DbSet<NhanVien> _nhanViens;
        AllRepository<NhanVien> _repository;
        public NhanVienController()
        {
            _context = new SD18302_NET104Context();
            _nhanViens = _context.NhanViens;
            _repository = new AllRepository<NhanVien>(_nhanViens, _context);
        }
        public ActionResult Index()
        {
            var data = _repository.GetAll();
            return View(data);
        }

        // GET: NhanVienController/Details/5
        public ActionResult Details(Guid id)
        {
            var data = _nhanViens.Find(id);
            return View(data);
        }

        // GET: NhanVienController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhanVienController/Create
        [HttpPost]
        public ActionResult Create(NhanVien nhanVien)
        {
            Guid id = new Guid();
            var idNhanVienSS = HttpContext.Session.GetString("nhanVien");
            var idNhanVien = Guid.Parse(idNhanVienSS);
            var chucVu = _repository.GetAll().Where(x => x.IdNhanVien == idNhanVien && x.ChucVu.Equals("Admin"));
            if (chucVu != null)
            {
                _repository.CreateObj(nhanVien);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: NhanVienController/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View();
        }

        // POST: NhanVienController/Edit/5
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

        // GET: NhanVienController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NhanVienController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
