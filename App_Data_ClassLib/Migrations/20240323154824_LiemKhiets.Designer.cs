﻿// <auto-generated />
using System;
using App_Data_ClassLib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App_Data_ClassLib.Migrations
{
    [DbContext(typeof(SD18302_NET104Context))]
    [Migration("20240323154824_LiemKhiets")]
    partial class LiemKhiets
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("App_Data_ClassLib.Models.ChiTietDonHang", b =>
                {
                    b.Property<Guid>("IdCTDonHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Gia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("IdDonHang")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdSP")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<decimal>("ThanhTien")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdCTDonHang");

                    b.HasIndex("IdDonHang");

                    b.HasIndex("IdSP");

                    b.ToTable("DonHangChiTiets", (string)null);
                });

            modelBuilder.Entity("App_Data_ClassLib.Models.ChucVu", b =>
                {
                    b.Property<Guid>("IdChucVu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdChucVu");

                    b.ToTable("ChucVus", (string)null);
                });

            modelBuilder.Entity("App_Data_ClassLib.Models.DanhMucSP", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Tên danh mục");

                    b.HasKey("ID");

                    b.ToTable("DanhMucs", (string)null);
                });

            modelBuilder.Entity("App_Data_ClassLib.Models.DonHang", b =>
                {
                    b.Property<Guid>("IdDonHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TongTien")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("IdDonHang");

                    b.HasIndex("IdUser");

                    b.ToTable("DonHangs", (string)null);
                });

            modelBuilder.Entity("App_Data_ClassLib.Models.GioHang", b =>
                {
                    b.Property<Guid>("IdGH")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TongTien")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("IdGH");

                    b.HasIndex("IdUser")
                        .IsUnique();

                    b.ToTable("GioHangs", (string)null);
                });

            modelBuilder.Entity("App_Data_ClassLib.Models.GioHangChiTiet", b =>
                {
                    b.Property<Guid>("IdGioHangCT")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("DonGia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("IdGioHoang")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdSP")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<decimal>("ThanhTien")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdGioHangCT");

                    b.HasIndex("IdGioHoang");

                    b.HasIndex("IdSP");

                    b.ToTable("GioHangChiTiets", (string)null);
                });

            modelBuilder.Entity("App_Data_ClassLib.Models.HoaDon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("SoldDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalMoney")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("HoaDons", (string)null);
                });

            modelBuilder.Entity("App_Data_ClassLib.Models.HoaDonChiTiet", b =>
                {
                    b.Property<Guid>("IdHoaDonCT")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Gia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("IdHD")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdSP")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<decimal>("ThanhTien")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdHoaDonCT");

                    b.HasIndex("IdHD");

                    b.HasIndex("IdSP");

                    b.ToTable("HoaDonChiTiets", (string)null);
                });

            modelBuilder.Entity("App_Data_ClassLib.Models.NhanVien", b =>
                {
                    b.Property<Guid>("IdNhanVien")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdChucVu")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Luong")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdNhanVien");

                    b.HasIndex("IdChucVu");

                    b.ToTable("NhanViens", (string)null);
                });

            modelBuilder.Entity("App_Data_ClassLib.Models.SanPham", b =>
                {
                    b.Property<Guid>("IdSP")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Anh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdDMSP")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Tên");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("TacGia")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Tác giả");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("IdSP");

                    b.HasIndex("IdDMSP");

                    b.ToTable("SanPhams", (string)null);
                });

            modelBuilder.Entity("App_Data_ClassLib.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nchar(50)")
                        .HasColumnName("Địa chỉ")
                        .IsFixedLength();

                    b.Property<DateTime>("DoB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Tên");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhongNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("App_Data_ClassLib.Models.ChiTietDonHang", b =>
                {
                    b.HasOne("App_Data_ClassLib.Models.DonHang", "DonHang")
                        .WithMany("ChiTietDonHangs")
                        .HasForeignKey("IdDonHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_DH_CTDH");

                    b.HasOne("App_Data_ClassLib.Models.SanPham", "SanPham")
                        .WithMany("ChiTietDonHangs")
                        .HasForeignKey("IdSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_SP_CTDH");

                    b.Navigation("DonHang");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("App_Data_ClassLib.Models.DonHang", b =>
                {
                    b.HasOne("App_Data_ClassLib.Models.User", "User")
                        .WithMany("DonHangs")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_DH_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("App_Data_ClassLib.Models.GioHang", b =>
                {
                    b.HasOne("App_Data_ClassLib.Models.User", "User")
                        .WithOne("GioHang")
                        .HasForeignKey("App_Data_ClassLib.Models.GioHang", "IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_GioHang_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("App_Data_ClassLib.Models.GioHangChiTiet", b =>
                {
                    b.HasOne("App_Data_ClassLib.Models.GioHang", "GioHang")
                        .WithMany("GioHangChiTiets")
                        .HasForeignKey("IdGioHoang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_GioHang_GHCT");

                    b.HasOne("App_Data_ClassLib.Models.SanPham", "SanPham")
                        .WithMany("GioHangChiTiets")
                        .HasForeignKey("IdSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_SP_GHCT");

                    b.Navigation("GioHang");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("App_Data_ClassLib.Models.HoaDon", b =>
                {
                    b.HasOne("App_Data_ClassLib.Models.User", "User")
                        .WithMany("HoaDons")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_User_HD");

                    b.Navigation("User");
                });

            modelBuilder.Entity("App_Data_ClassLib.Models.HoaDonChiTiet", b =>
                {
                    b.HasOne("App_Data_ClassLib.Models.HoaDon", "HoaDon")
                        .WithMany("HoaDonChiTiets")
                        .HasForeignKey("IdHD")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_HD_HDCT");

                    b.HasOne("App_Data_ClassLib.Models.SanPham", "SanPham")
                        .WithMany("HoaDonChiTiets")
                        .HasForeignKey("IdSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_SP_HDCT");

                    b.Navigation("HoaDon");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("App_Data_ClassLib.Models.NhanVien", b =>
                {
                    b.HasOne("App_Data_ClassLib.Models.ChucVu", "ChucVu")
                        .WithMany("NhanViens")
                        .HasForeignKey("IdChucVu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_NhanVien_ChucVu");

                    b.Navigation("ChucVu");
                });

            modelBuilder.Entity("App_Data_ClassLib.Models.SanPham", b =>
                {
                    b.HasOne("App_Data_ClassLib.Models.DanhMucSP", "DanhMucSP")
                        .WithMany("SanPhams")
                        .HasForeignKey("IdDMSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_DanhMuc_SanPham");

                    b.Navigation("DanhMucSP");
                });

            modelBuilder.Entity("App_Data_ClassLib.Models.ChucVu", b =>
                {
                    b.Navigation("NhanViens");
                });

            modelBuilder.Entity("App_Data_ClassLib.Models.DanhMucSP", b =>
                {
                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("App_Data_ClassLib.Models.DonHang", b =>
                {
                    b.Navigation("ChiTietDonHangs");
                });

            modelBuilder.Entity("App_Data_ClassLib.Models.GioHang", b =>
                {
                    b.Navigation("GioHangChiTiets");
                });

            modelBuilder.Entity("App_Data_ClassLib.Models.HoaDon", b =>
                {
                    b.Navigation("HoaDonChiTiets");
                });

            modelBuilder.Entity("App_Data_ClassLib.Models.SanPham", b =>
                {
                    b.Navigation("ChiTietDonHangs");

                    b.Navigation("GioHangChiTiets");

                    b.Navigation("HoaDonChiTiets");
                });

            modelBuilder.Entity("App_Data_ClassLib.Models.User", b =>
                {
                    b.Navigation("DonHangs");

                    b.Navigation("GioHang")
                        .IsRequired();

                    b.Navigation("HoaDons");
                });
#pragma warning restore 612, 618
        }
    }
}
