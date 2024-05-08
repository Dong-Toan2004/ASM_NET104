using App_Data_ClassLib.Models;
using App_Data_ClassLib.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App_MVC.Controllers
{
    public class DanhMucController : Controller
    {
        SD18302_NET104Context _context;
        DbSet<DanhMucSP> _danhMucSP;
        AllRepository<DanhMucSP> _repository;
        public DanhMucController()
        {
            _context = new SD18302_NET104Context();
            _danhMucSP = _context.DanhMucSPs;
            _repository = new AllRepository<DanhMucSP>(_danhMucSP, _context);
        }
        public IActionResult Index()
        {
            var danhMuc = _repository.GetAll();
            return View(danhMuc);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DanhMucSP danhMuc)
        {
            danhMuc.ID = Guid.NewGuid();
            _repository.CreateObj(danhMuc);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(Guid id)
        {
            var updateData = _repository.GetByID(id);
            return View(updateData);
        }
        [HttpPost]
        public IActionResult Edit(DanhMucSP danhMucSP)
        {
            _repository.UpdateObj(danhMucSP);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid id)
        {
            _repository.DeleteObj(id);
            return RedirectToAction("Index");
        }
        public IActionResult Details(Guid id)
        {
            var getdanhMuc = _repository.GetByID(id);
            return View(getdanhMuc);
        }
    }
}
