using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DatabaseApproach.Domain.Repository.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DatabaseApproach.Domain.Repository
{
    public partial class TestDbContext : DbContext
    {
        public TestDbContext()
        {
        }

        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Attendance> Attendance { get; set; }
        public virtual DbSet<AttendanceDetail> AttendanceDetail { get; set; }
        public virtual DbSet<Component> Component { get; set; }
        public virtual DbSet<ComponentMaterial> ComponentMaterial { get; set; }
        public virtual DbSet<ImportExport> ImportExport { get; set; }
        public virtual DbSet<ImportExportDetail> ImportExportDetail { get; set; }
        public virtual DbSet<Matrial> Matrial { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<Process> Process { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductComponent> ProductComponent { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<SectionDepartment> SectionDepartment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=ADMIN;Initial Catalog=GSP_DB_test;Persist Security Info=True;User ID=sa;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasOne(d => d.AccountNavigation)
                    .WithOne(p => p.Account)
                    .HasForeignKey<Account>(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_SectionDepartment");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Account_Role");
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Attendance)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Attendance_SectionDepartment");
            });

            modelBuilder.Entity<AttendanceDetail>(entity =>
            {
                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AttendanceDetail)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_AttendanceDetail_Account");

                entity.HasOne(d => d.Attendance)
                    .WithMany(p => p.AttendanceDetail)
                    .HasForeignKey(d => d.AttendanceId)
                    .HasConstraintName("FK_AttendanceDetail_Attendance");
            });

            modelBuilder.Entity<ComponentMaterial>(entity =>
            {
                entity.HasOne(d => d.Component)
                    .WithMany(p => p.ComponentMaterial)
                    .HasForeignKey(d => d.ComponentId)
                    .HasConstraintName("FK_Component_Material_Component");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.ComponentMaterial)
                    .HasForeignKey(d => d.MaterialId)
                    .HasConstraintName("FK_Component_Material_Matrial");
            });

            modelBuilder.Entity<ImportExport>(entity =>
            {
                entity.HasOne(d => d.Account)
                    .WithMany(p => p.ImportExport)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_ImportExport_SectionDepartment");
            });

            modelBuilder.Entity<ImportExportDetail>(entity =>
            {
                entity.HasOne(d => d.ImportExport)
                    .WithMany(p => p.ImportExportDetail)
                    .HasForeignKey(d => d.ImportExportId)
                    .HasConstraintName("FK_ImportExportDetail_ImportExport");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ImportExportDetail)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_ImportExportDetail_Component");

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.ImportExportDetail)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_ImportExportDetail_Matrial");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Order_Account");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderDetail_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_OrderDetail_Product");
            });

            modelBuilder.Entity<Process>(entity =>
            {
                entity.HasOne(d => d.Manufacturing)
                    .WithMany(p => p.Process)
                    .HasForeignKey(d => d.ManufacturingId)
                    .HasConstraintName("FK_Process_Account");

                entity.HasOne(d => d.OrderDetail)
                    .WithMany(p => p.Process)
                    .HasForeignKey(d => d.OrderDetailId)
                    .HasConstraintName("FK_Process_OrderDetail");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Process)
                    .HasForeignKey(d => d.SectionId)
                    .HasConstraintName("FK_Process_SectionDepartment");
            });

            modelBuilder.Entity<ProductComponent>(entity =>
            {
                entity.HasOne(d => d.Component)
                    .WithMany(p => p.ProductComponent)
                    .HasForeignKey(d => d.ComponentId)
                    .HasConstraintName("FK_Product_Component_Component");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductComponent)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Product_Component_Product");
            });

            modelBuilder.Entity<SectionDepartment>(entity =>
            {
                entity.HasOne(d => d.Component)
                    .WithMany(p => p.SectionDepartment)
                    .HasForeignKey(d => d.ComponentId)
                    .HasConstraintName("FK_SectionDepartment_Component");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
