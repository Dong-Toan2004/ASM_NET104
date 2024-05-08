using App_Data_ClassLib.Models;
using App_Data_ClassLib.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App_MVC.Controllers
{
    public class ChucVuController : Controller
    {
        // GET: ChucVuController
        SD18302_NET104Context _context;
        DbSet<ChucVu> _chuVu;
        AllRepository<ChucVu> _repository;
        public ChucVuController()
        {
            _context = new SD18302_NET104Context();
            _chuVu = _context.ChucVus;
            _repository = new AllRepository<ChucVu>(_chuVu, _context);
        }
        public ActionResult Index()
        {
            var data = _repository.GetAll();
            return View(data);
        }

        // GET: ChucVuController/Details/5
        public ActionResult Details(Guid id)
        {
            var data = _repository.GetByID(id);
            return View(data);
        }

        // GET: ChucVuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChucVuController/Create
        [HttpPost]
        public ActionResult Create(ChucVu chucVu)
        {
            Guid id = new Guid();
            try
            {
                chucVu.IdChucVu = id;
                _repository.CreateObj(chucVu);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ChucVuController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var data = _repository.GetByID(id);
            return View(data);
        }

        // POST: ChucVuController/Edit/5
        [HttpPost]
        public ActionResult Edit(ChucVu chucVu)
        {
            try
            {
                _repository.UpdateObj(chucVu);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ChucVuController/Delete/5
        public ActionResult Delete(Guid id)
        {
            _repository.DeleteObj(id);
            return RedirectToAction("Index");
        }

        // POST: ChucVuController/Delete/5
        
    }
}
