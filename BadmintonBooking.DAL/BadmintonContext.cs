using System;
using System.Configuration;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BadmintonBooking.DAL
{
    public class BadmintonContext : DbContext
    {
        public DbSet<CauLacBo> CauLacBos => Set<CauLacBo>();
        public DbSet<San> Sans => Set<San>();
        public DbSet<NguoiDung> NguoiDungs => Set<NguoiDung>();
        public DbSet<DatSan> DatSans => Set<DatSan>();
        public DbSet<ThanhToan> ThanhToans => Set<ThanhToan>();

        // 1) Kết nối từ App.config
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            var cs = ConfigurationManager.ConnectionStrings["BadmintonBooking"]?.ConnectionString;
            if (string.IsNullOrWhiteSpace(cs))
                throw new InvalidOperationException("Thiếu connectionStrings['BadmintonBooking'] trong App.config.");

            optionsBuilder.UseSqlServer(cs, o => o.EnableRetryOnFailure());
        }

        // 2) Cấu hình bảng/khóa
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<CauLacBo>().ToTable("CauLacBo").HasKey(x => x.Id);
            modelBuilder.Entity<NguoiDung>().ToTable("NguoiDung").HasKey(x => x.Id);

            modelBuilder.Entity<San>(e =>
            {
                e.ToTable("San");
                e.HasKey(x => x.Id);
                e.Property(p => p.TenSan).HasColumnType("nvarchar(100)");
                e.Property(p => p.TrangThai).HasColumnType("nvarchar(50)");
                e.HasOne(x => x.CauLacBo)
                 .WithMany()
                 .HasForeignKey(x => x.CLBId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<DatSan>(e =>
            {
                e.ToTable("DatSan");
                e.HasKey(x => x.Id);
                e.Property(p => p.Ngay).HasColumnType("date");
                e.Property(p => p.GioBatDau).HasColumnType("nvarchar(5)");
            });

            modelBuilder.Entity<ThanhToan>(e =>
            {
                e.ToTable("ThanhToan");
                e.HasKey(x => x.Id);
                e.Property(p => p.NgayThanhToan).HasColumnType("datetime");
            });
        }

        // Tạo DB & seed mẫu (gọi 1 lần lúc khởi động)
        public void EnsureCreatedAndSeed()
        {
            Database.EnsureCreated();

            var strategy = Database.CreateExecutionStrategy();
            strategy.Execute(() =>
            {
                using var tx = Database.BeginTransaction();

                if (!CauLacBos.Any())
                {
                    ExecWithIdentityInsert("CauLacBo", () =>
                    {
                        CauLacBos.AddRange(
                            new CauLacBo { Id = 1, TenCLB = "CLB Cầu Lông TPT Sport", DiaChi = "Q1, TP.HCM", GioMoCua = "06:00", GioDongCua = "23:00" },
                            new CauLacBo { Id = 2, TenCLB = "NESTWORLD BADMINTON", DiaChi = "TP Thủ Đức", GioMoCua = "05:00", GioDongCua = "24:00" },
                            new CauLacBo { Id = 3, TenCLB = "Sân Bóng Tân Hòa", DiaChi = "Tân Phú", GioMoCua = "05:00", GioDongCua = "24:00" },
                            new CauLacBo { Id = 4, TenCLB = "CLB Nguyễn Du", DiaChi = "Q1, TP.HCM", GioMoCua = "06:00", GioDongCua = "22:00" }
                        );
                        SaveChanges();
                    });
                }

                if (!Sans.Any())
                {
                    ExecWithIdentityInsert("San", () =>
                    {
                        Sans.AddRange(
                            new San { Id = 1, CLBId = 1, TenSan = "Sân 1", TrangThai = "Hoạt động" },
                            new San { Id = 2, CLBId = 1, TenSan = "Sân 2", TrangThai = "Hoạt động" },
                            new San { Id = 3, CLBId = 2, TenSan = "Sân 1", TrangThai = "Hoạt động" },
                            new San { Id = 4, CLBId = 2, TenSan = "Sân 2", TrangThai = "Hoạt động" }
                        );
                        SaveChanges();
                    });
                }

                if (!NguoiDungs.Any())
                {
                    ExecWithIdentityInsert("NguoiDung", () =>
                    {
                        NguoiDungs.AddRange(
                            new NguoiDung { Id = 1, HoTen = "Người dùng A", Email = "user1@badminton.local", MatKhau = "123456", LaAdmin = false },
                            new NguoiDung { Id = 2, HoTen = "Người dùng B", Email = "user2@badminton.local", MatKhau = "123456", LaAdmin = false }
                        );
                        SaveChanges();
                    });
                }

                tx.Commit();
            });
        }

        private void ExecWithIdentityInsert(string tableName, Action action)
        {
            Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [dbo].[{tableName}] ON");
            try { action(); }
            finally { Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [dbo].[{tableName}] OFF"); }
        }
    }
}
