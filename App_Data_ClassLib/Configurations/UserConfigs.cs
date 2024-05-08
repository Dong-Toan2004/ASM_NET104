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
    public class UserConfigs : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Thực hiện các config trên entity
            builder.ToTable("Users");//Đặt tên bảng
            //Xác định khóa chính
            // builder.HasNoKey();//Không khóa
            builder.HasKey(x => x.Id);//Set khóa là cột id
            //builder.HasNoKey(x => new { x.Id,x.Address });//Khóa chính có Composite(Nhiều cột) 
            //Thiết lập thuộc tính cho cột
            builder.Property(x => x.Name).HasColumnName("Tên").HasColumnType("nvarchar(50)");
            builder.Property(x=>x.Address).HasColumnName("Địa chỉ").HasMaxLength(50).IsFixedLength().IsUnicode(true);//nvarchar(50)
            builder.Property(x => x.Username).IsRequired();//IsRequired()=Not null
        }
    }
}
