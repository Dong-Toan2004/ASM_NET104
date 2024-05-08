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
    public class HoaDonCTConfig : IEntityTypeConfiguration<HoaDonChiTiet>
    {
        public void Configure(EntityTypeBuilder<HoaDonChiTiet> builder)
        {
            builder.ToTable("HoaDonChiTiets");//Đặt tên bảng
            builder.HasKey(x => x.IdHoaDonCT);
            builder.HasOne(x => x.HoaDon).WithMany(x => x.HoaDonChiTiets).HasForeignKey(x => x.IdHD).HasConstraintName("FK_HD_HDCT");
            builder.HasOne(x => x.SanPham).WithMany(x => x.HoaDonChiTiets).HasForeignKey(x => x.IdSP).HasConstraintName("FK_SP_HDCT");
        }
    }
}
