using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data_ClassLib.iRepository
{
    public interface IAllRepository<T> where T : class
    {
        public ICollection<T> GetAll();//Lấy ra tất cả

        public T GetByID(dynamic id); //có thể dùng được Type thay cho dynamic - Lấy bởi ID
        //dynamic chấp nhận mọi loại dữ liệu
        public bool CreateObj(T obj); //Tạo mới và thêm vào trong Db;
        public bool UpdateObj(T obj);//Sửa và lưu lại vào trong Db
        public bool DeleteObj(dynamic id);//Xoá đối tượng trong db
    }
}
