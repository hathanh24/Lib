using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LibProject.Models;

public partial class LibraryDbContext : DbContext
{
    public LibraryDbContext()
    {
    }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Sach> Saches { get; set; }

    public virtual DbSet<TheThuVien> TheThuViens { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-16I3HOA;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Accounts__3214EC0711E8B77B");

            entity.Property(e => e.Gmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sach>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sach__3214EC0757DC1074");

            entity.ToTable("Sach");

            entity.Property(e => e.NhaXuatBan)
                .HasMaxLength(250)
                .HasColumnName("nhaXuatBan");
            entity.Property(e => e.SoLuong).HasColumnName("soLuong");
            entity.Property(e => e.TacGia)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("tacGia");
            entity.Property(e => e.TenSach)
                .HasMaxLength(250)
                .HasColumnName("tenSach");
        });

        modelBuilder.Entity<TheThuVien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TheThuVi__3214EC076BBE92C4");

            entity.ToTable("TheThuVien");

            entity.Property(e => e.DiaChi)
                .HasMaxLength(250)
                .HasColumnName("diaChi");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .HasColumnName("email");
            entity.Property(e => e.GioiTinh)
                .HasMaxLength(10)
                .HasColumnName("gioiTinh");
            entity.Property(e => e.HoVaTen)
                .HasMaxLength(250)
                .HasColumnName("hoVaTen");
            entity.Property(e => e.NgaySinh)
                .HasMaxLength(20)
                .HasColumnName("ngaySinh");
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("soDienThoai");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
