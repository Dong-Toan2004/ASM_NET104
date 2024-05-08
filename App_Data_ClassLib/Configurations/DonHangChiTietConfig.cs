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
    public class DonHangChiTietConfig : IEntityTypeConfiguration<ChiTietDonHang>
    {
        public void Configure(EntityTypeBuilder<ChiTietDonHang> builder)
        {
            builder.ToTable("DonHangChiTiets");//Đặt tên bảng
            builder.HasKey(x => x.IdCTDonHang);
            builder.HasOne(x=>x.SanPham).WithMany(x=>x.ChiTietDonHangs).HasForeignKey(x=>x.IdSP).HasConstraintName("FK_SP_CTDH");
            builder.HasOne(x => x.DonHang).WithMany(x => x.ChiTietDonHangs).HasForeignKey(x => x.IdDonHang).HasConstraintName("FK_DH_CTDH");
        }
    }
}
