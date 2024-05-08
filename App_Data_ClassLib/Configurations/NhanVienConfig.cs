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
    public class NhanVienConfig : IEntityTypeConfiguration<NhanVien>
    {
        public void Configure(EntityTypeBuilder<NhanVien> builder)
        {
            builder.ToTable("NhanViens");//Đặt tên bảng
            builder.HasKey(x => x.IdNhanVien);
            builder.HasOne(x=>x.ChucVu).WithMany(x=>x.NhanViens).HasForeignKey(x=>x.IdChucVu).HasConstraintName("FK_NhanVien_ChucVu");
        }
    }
}
