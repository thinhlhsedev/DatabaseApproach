using DBApproach.Domain.Repositories.Models;
using Microsoft.EntityFrameworkCore;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DBApproach.Domain.Repositories
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
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<Process> Process { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductComponent> ProductComponent { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Section> Section { get; set; }

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
                entity.Property(e => e.AccountId).HasMaxLength(100);

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.AvatarUrl).HasMaxLength(100);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(100);

                entity.Property(e => e.RoleId).HasMaxLength(100);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Account_Role1");
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.Property(e => e.AttendanceId).HasMaxLength(100);

                entity.Property(e => e.AccountId).HasMaxLength(100);

                entity.Property(e => e.CheckDate).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(100);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Attendance)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Attendance_Section");
            });

            modelBuilder.Entity<AttendanceDetail>(entity =>
            {
                entity.Property(e => e.AttendanceDetailId).HasMaxLength(100);

                entity.Property(e => e.AccountId).HasMaxLength(100);

                entity.Property(e => e.AttendanceId).HasMaxLength(100);

                entity.Property(e => e.Note).HasMaxLength(100);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AttendanceDetail)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_AttendanceDetail_Account");

                entity.HasOne(d => d.Attendance)
                    .WithMany(p => p.AttendanceDetail)
                    .HasForeignKey(d => d.AttendanceId)
                    .HasConstraintName("FK_AttendanceDetail_Attendance");
            });

            modelBuilder.Entity<Component>(entity =>
            {
                entity.Property(e => e.ComponentId).HasMaxLength(100);

                entity.Property(e => e.ComponentName).HasMaxLength(100);

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.ImageUrl).HasMaxLength(100);

                entity.Property(e => e.ManufactuirngDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(100);
            });

            modelBuilder.Entity<ComponentMaterial>(entity =>
            {
                entity.ToTable("Component_Material");

                entity.Property(e => e.Id).HasMaxLength(100);

                entity.Property(e => e.ComponentId).HasMaxLength(100);

                entity.Property(e => e.MaterialId).HasMaxLength(100);

                entity.HasOne(d => d.Component)
                    .WithMany(p => p.ComponentMaterial)
                    .HasForeignKey(d => d.ComponentId)
                    .HasConstraintName("FK_Component_Material_Component1");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.ComponentMaterial)
                    .HasForeignKey(d => d.MaterialId)
                    .HasConstraintName("FK_Component_Material_Matrial1");
            });

            modelBuilder.Entity<ImportExport>(entity =>
            {
                entity.Property(e => e.ImportExportId).HasMaxLength(100);

                entity.Property(e => e.AccountId).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemType).HasMaxLength(100);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.ImportExport)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_ImportExport_Section");
            });

            modelBuilder.Entity<ImportExportDetail>(entity =>
            {
                entity.Property(e => e.ImportExportDetailId).HasMaxLength(100);

                entity.Property(e => e.ImportExportId).HasMaxLength(100);

                entity.Property(e => e.ItemId).HasMaxLength(100);

                entity.HasOne(d => d.ImportExport)
                    .WithMany(p => p.ImportExportDetail)
                    .HasForeignKey(d => d.ImportExportId)
                    .HasConstraintName("FK_ImportExportDetail_ImportExport1");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ImportExportDetail)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_ImportExportDetail_Component1");

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.ImportExportDetail)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_ImportExportDetail_Matrial1");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.Property(e => e.MaterialId).HasMaxLength(100);

                entity.Property(e => e.ImageUrl).HasMaxLength(100);

                entity.Property(e => e.MaterialName).HasMaxLength(100);

                entity.Property(e => e.Status).HasMaxLength(100);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasMaxLength(100);

                entity.Property(e => e.AccountId).HasMaxLength(100);

                entity.Property(e => e.Deadline).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(100);

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Order_Account1");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.OrderDetailId).HasMaxLength(100);

                entity.Property(e => e.Note).HasMaxLength(100);

                entity.Property(e => e.OrderId).HasMaxLength(100);

                entity.Property(e => e.ProductId).HasMaxLength(100);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderDetail_Order1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_OrderDetail_Product1");
            });

            modelBuilder.Entity<Process>(entity =>
            {
                entity.Property(e => e.ProcessId).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.FinishedDate).HasColumnType("datetime");

                entity.Property(e => e.ManufacturingId).HasMaxLength(100);

                entity.Property(e => e.OrderDetailId).HasMaxLength(100);

                entity.Property(e => e.SectionId).HasMaxLength(100);

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.HasOne(d => d.OrderDetail)
                    .WithMany(p => p.Process)
                    .HasForeignKey(d => d.OrderDetailId)
                    .HasConstraintName("FK_Process_OrderDetail1");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Process)
                    .HasForeignKey(d => d.SectionId)
                    .HasConstraintName("FK_Process_Section");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasMaxLength(100);

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.ImageUrl).HasMaxLength(100);

                entity.Property(e => e.ManufacturingDate).HasColumnType("datetime");

                entity.Property(e => e.ProductName).HasMaxLength(100);

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.Property(e => e.Unit).HasMaxLength(100);
            });

            modelBuilder.Entity<ProductComponent>(entity =>
            {
                entity.ToTable("Product_Component");

                entity.Property(e => e.Id).HasMaxLength(100);

                entity.Property(e => e.ComponentId).HasMaxLength(100);

                entity.Property(e => e.ProductId).HasMaxLength(100);

                entity.HasOne(d => d.Component)
                    .WithMany(p => p.ProductComponent)
                    .HasForeignKey(d => d.ComponentId)
                    .HasConstraintName("FK_Product_Component_Component1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductComponent)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Product_Component_Product1");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Status).HasMaxLength(100);
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.Property(e => e.AccountId).HasMaxLength(100);

                entity.Property(e => e.ComponentId).HasMaxLength(100);

                entity.HasOne(d => d.Account)
                    .WithOne(p => p.Section)
                    .HasForeignKey<Section>(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Section_Account");

                entity.HasOne(d => d.Component)
                    .WithMany(p => p.Section)
                    .HasForeignKey(d => d.ComponentId)
                    .HasConstraintName("FK_Section_Component");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
