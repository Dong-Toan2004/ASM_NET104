using App_Data_ClassLib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data_ClassLib.Configurations
{
    public class HoaDonConfigs : IEntityTypeConfiguration<HoaDon>
    {
        public void Configure(EntityTypeBuilder<HoaDon> builder)
        {
            builder.ToTable("HoaDons");//Đặt tên bảng
            builder.HasKey(x => x.Id);
            //config Khóa ngoại
            builder.HasOne(p=>p.User).WithMany(p=>p.HoaDons).HasForeignKey(p=>p.UserId).HasConstraintName("FK_User_HD");
            //Với mỗi user sẽ có nhiều hóa đơn, khóa ngoại là cột UserId nối với bảng User
            //Tên của khóa ngoại là IsRequired()
        }
    }
}
