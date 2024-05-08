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
    public class GioHangChiTietConfig : IEntityTypeConfiguration<GioHangChiTiet>
    {
        public void Configure(EntityTypeBuilder<GioHangChiTiet> builder)
        {
            builder.ToTable("GioHangChiTiets");//Đặt tên bảng
            builder.HasKey(x => x.IdGioHangCT);
            builder.HasOne(x => x.GioHang).WithMany(x => x.GioHangChiTiets).HasForeignKey(x => x.IdGioHoang).HasConstraintName("FK_GioHang_GHCT");
            builder.HasOne(x => x.SanPham).WithMany(x => x.GioHangChiTiets).HasForeignKey(x => x.IdSP).HasConstraintName("FK_SP_GHCT");
        }
    }
}
