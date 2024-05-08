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
    public class GioHangConfig : IEntityTypeConfiguration<GioHang>
    {
        public void Configure(EntityTypeBuilder<GioHang> builder)
        {
            builder.ToTable("GioHangs");//Đặt tên bảng
            builder.HasKey(x => x.IdGH);
            builder.HasOne(x => x.User).WithOne(x => x.GioHang).HasForeignKey<GioHang>(x => x.IdUser).HasConstraintName("FK_GioHang_User");
        }
    }
}
