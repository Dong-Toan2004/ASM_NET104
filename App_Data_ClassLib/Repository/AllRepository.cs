using App_Data_ClassLib.iRepository;
using App_Data_ClassLib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data_ClassLib.Repository
{
    public class AllRepository<T> : IAllRepository<T> where T : class// có thể đổi T thành các từ khác
    {
        SD18302_NET104Context _context;
        DbSet<T> _dbSet;//CRUD trên DbSet vì nó đại diện cho bảng
        //Khi cần gọi lại và dùng thật thì lại cần chính xác nó là DBSet nào
        //Lúc đó ta sẽ gắn _dbSet  = DbSet cần dùng
        public AllRepository()
        {
            _context = new SD18302_NET104Context();
        }

        public AllRepository(DbSet<T> dbSet,SD18302_NET104Context context)
        {
            this._context = context;// Gán lại khi dùng
            this._dbSet = dbSet;
        }

        public bool CreateObj(T obj) //Thêm mới 
        {
            try
            {
                _dbSet.Add(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteObj(dynamic id)
        {
            try
            {
                // tìm trong bảng đối tượng cần xóa
                var deleteObj = _dbSet.Find(id);// find truyền vào thuộc tính
                // chỉ sử dụng với pk
                _dbSet.Remove(deleteObj);// xóa 
                _context.SaveChanges();// lưu lại
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ICollection<T> GetAll()
        {
           return _dbSet.ToList();
        }

        public T GetByID(dynamic id)
        {
            return _dbSet.Find(id);
        }

        public bool UpdateObj(T obj)
        {
            try
            {
                // tìm trong bảng đối tượng cần xóa
                //var deleteObj = _dbSet.Find(id);// find truyền vào thuộc tính
                // chỉ sử dụng với pk
                _dbSet.Update(obj);// Sửa 
                _context.SaveChanges();// lưu lại
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
