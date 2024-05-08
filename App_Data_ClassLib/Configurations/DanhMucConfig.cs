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
    public class DanhMucConfig : IEntityTypeConfiguration<DanhMucSP>
    {
        public void Configure(EntityTypeBuilder<DanhMucSP> builder)
        {
            builder.ToTable("DanhMucs");//Đặt tên bảng
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Name).HasColumnName("Tên danh mục").HasColumnType("nvarchar(50)");
        }
    }
}
