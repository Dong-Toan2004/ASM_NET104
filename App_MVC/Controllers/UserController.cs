using App_Data_ClassLib.Models;
using App_Data_ClassLib.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


namespace App_MVC.Controllers
{
    public class UserController : Controller
    {
        SD18302_NET104Context _context;
        DbSet<User> _users;
        AllRepository<User> _repository;
        
        public UserController()
        {
            //Khởi tạo DBcontext
            _context = new SD18302_NET104Context();
            //Khởi tạo repository với 2 tham số là DbSet và DbContext
            _users = _context.Users;
            _repository = new AllRepository<User>(_users, _context);
        }
        //Lấy ra tất cả danh sách user
        public IActionResult Index(string name) // tham số name để tìm kiếm
        {
            var sessionData = HttpContext.Session.GetString("user");
            if (sessionData == null)
            {
                ViewData["message"] = "Bạn chưa đăng nhập hoặc hết phiên đăng nhập";
            }
            else
            {
                ViewData["message"] = $"Chào mừng {sessionData} đến với bình nguyên vô tận"; 
            }
            var userData = _repository.GetAll();
            if (string.IsNullOrEmpty(name))
            {
                return View(userData);
            }
            else
            {
                var searchData = _repository.GetAll().Where(x => x.Name.Contains(name)).ToList(); // Tìm theo tên           
                ViewData["count"] = searchData.Count;
                ViewBag.Count = searchData.Count;
                if (searchData.Count == 0) // Nếu ko tìm thấy 
                {
                    return View(userData);
                }
                else return View(searchData); // có tìm thấy
            }

        }
        //Thêm data 
        public IActionResult Create()//Action để mở form điền thông tin user
        {
            return View();
        }
        //Action để thực hiện thêm vào db
        [HttpPost]
        public IActionResult Create(User user)
        {
            user.Id = Guid.NewGuid();
            _repository.CreateObj(user);
            return RedirectToAction("Index","Home");
        }
        //Sửa
        public IActionResult Edit(Guid id)//Form load ra đối tượng cần sửa
        {
            //Lấy ra đối tượng cần sửa
            var updateUser = _repository.GetByID(id);
            return View(updateUser);
        }
        public IActionResult EditUser(User user)// Action này thực hiện thay đổi khi cần thì trỏ tới nó
        {
            _repository.UpdateObj(user);
            return RedirectToAction("Index");
        }
        //Xóa
        public IActionResult Delete(Guid id)
        {
            //Lấy ra đối tượng cần xóa 
            var deleteUser = _repository.GetByID(id);
            var jsondata = JsonConvert.SerializeObject(deleteUser);//Ép kiểu sang Json
            HttpContext.Session.SetString("deleted", jsondata);//Cho dữ liệu vào Json 
            _repository.DeleteObj(id);
            return RedirectToAction("Index");
        }
        public IActionResult RollBack()
        {
            if (HttpContext.Session.Keys.Contains("deleted"))
            {
                var jsondata = HttpContext.Session.GetString("deleted");
                //Tạo mới đối tượng có dữ liệu với đối tượng y hệt dữ liệu cũ
                var deleted = JsonConvert.DeserializeObject<User>(jsondata);
                _repository.CreateObj(deleted);//Thêm mới vào db
                return RedirectToAction("Index");//Về trang Index  
            }
            else
            {
                return Content("Đã quá muộn rồi");
            }
        }
        //Thông tin
        public IActionResult Details(Guid id)
        {
            var getUser = _repository.GetByID(id);
            return View(getUser);
        }
        public IActionResult Login()// Action này return về view để mở view cho phép nhập thông tin đăng nhập
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username , string password)//Action này để đăng nhập
        {
            var user = _repository.GetAll().FirstOrDefault(p => p.Username == username && p.Password == password);
            if (user != null)
            {
                //return Content("Đăng nhập thành công");
                //Dùng temData để lưu trữ dữ liệu tạm thời
                TempData["Login"] = username;
                //Lưu trữ thông tin đăng nhập vào session
                HttpContext.Session.SetString("user",user.Id.ToString());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Content("Đăng nhập thất bại");
            }
        }
       public IActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            return RedirectToAction("Index","Home");
        }
    }
}
