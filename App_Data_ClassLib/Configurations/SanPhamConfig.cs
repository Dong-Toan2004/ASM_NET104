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
    public class SanPhamConfig : IEntityTypeConfiguration<SanPham>
    {
        public void Configure(EntityTypeBuilder<SanPham> builder)
        {
            builder.ToTable("SanPhams");//Đặt tên bảng
            builder.HasKey(x => x.IdSP);
            //builder.HasOne(p=>p.User).WithMany(p=>p.HoaDons).HasForeignKey(p=>p.UserId).HasConstraintName("FK_User_HD");
            //Với mỗi user sẽ có nhiều hóa đơn, khóa ngoại là cột UserId nối với bảng User
            //Tên của khóa ngoại là IsRequired()
            builder.HasOne(p => p.DanhMucSP).WithMany(p => p.SanPhams).HasForeignKey(p => p.IdDMSP).HasConstraintName("FK_DanhMuc_SanPham");
            builder.Property(x => x.Name).HasColumnName("Tên").HasColumnType("nvarchar(50)");
            // builder.Property(x => x.Address).HasColumnName("Địa chỉ").HasMaxLength(50).IsFixedLength().IsUnicode(true);//nvarchar(50)
            // builder.Property(x => x.Username).IsRequired();//IsRequired()=Not null
            builder.Property(x => x.TacGia).HasColumnName("Tác giả").HasColumnType("nvarchar(50)");

        }
    }
}
