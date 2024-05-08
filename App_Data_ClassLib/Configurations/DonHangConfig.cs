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
    public class DonHangConfig : IEntityTypeConfiguration<DonHang>
    {
        public void Configure(EntityTypeBuilder<DonHang> builder)
        {
            builder.ToTable("DonHangs");//Đặt tên bảng
            builder.HasKey(x => x.IdDonHang);
            builder.HasOne(x=>x.User).WithMany(x=>x.DonHangs).HasForeignKey(x=>x.IdUser).HasConstraintName("FK_DH_User");
        }
    }
}
