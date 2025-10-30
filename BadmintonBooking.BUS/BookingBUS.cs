using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using BadmintonBooking.DAL;
using Microsoft.EntityFrameworkCore;

namespace BadmintonBooking.BUS
{
    public class LichSuItem
    {
        public int Id { get; set; }
        public string CLB { get; set; } = "";
        public string San { get; set; } = "";
        public DateTime Ngay { get; set; }
        public string GioBatDau { get; set; } = "";
        public int SoGio { get; set; }
        public int GiaGio { get; set; }
        public int TongTien { get; set; }
    }

    public class BookingBUS
    {
        private static bool IsOverlap(DateTime ngay, string gioStr, int soGio, DateTime start, DateTime end)
        {
            var ts = TimeSpan.ParseExact(gioStr, @"hh\:mm", CultureInfo.InvariantCulture);
            var s = ngay.Date + ts;
            var e = s.AddHours(soGio);
            return s < end && start < e;
        }

        private static string NormalizeVN(string? input)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;
            var s = input.ToLowerInvariant().Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder(s.Length);
            foreach (var ch in s)
            {
                var cat = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (cat != UnicodeCategory.NonSpacingMark) sb.Append(ch);
            }
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        // ===== CLB =====
        public IEnumerable<CauLacBo> DanhSachCLB(string? keyword = null)
        {
            using var db = new BadmintonContext();
            var query = db.CauLacBos.AsNoTracking().OrderBy(x => x.TenCLB);

            if (string.IsNullOrWhiteSpace(keyword))
                return query.ToList();

            var k = NormalizeVN(keyword);
            return query.AsEnumerable()
                        .Where(c => NormalizeVN(c.TenCLB).Contains(k) ||
                                    NormalizeVN(c.DiaChi).Contains(k))
                        .ToList();
        }

        // ===== SÂN =====
        public IEnumerable<San> DanhSachSanTheoCLB(int clbId, string? keyword = null)
        {
            using var db = new BadmintonContext();

            var query = db.Sans.AsNoTracking()
                        .Where(s => s.CLBId == clbId)
                        .Select(s => new San { Id = s.Id, CLBId = s.CLBId, TenSan = s.TenSan, TrangThai = s.TrangThai })
                        .OrderBy(s => s.TenSan);

            if (string.IsNullOrWhiteSpace(keyword))
                return query.ToList();

            var k = NormalizeVN(keyword);
            return query.AsEnumerable()
                        .Where(s => NormalizeVN(s.TenSan).Contains(k) ||
                                    NormalizeVN(s.TrangThai).Contains(k))
                        .ToList();
        }

        // ===== KIỂM TRA TRỐNG =====
        public bool KiemTraTrong(int sanId, DateTime ngay, TimeSpan gioBatDau, int soGio)
        {
            using var db = new BadmintonContext();

            var start = ngay.Date + gioBatDau;
            var end = start.AddHours(soGio);

            var sameDay = db.DatSans.AsNoTracking()
                            .Where(x => x.SanId == sanId && x.Ngay == ngay.Date)
                            .Select(x => new { x.Ngay, x.GioBatDau, x.SoGio })
                            .ToList();

            return !sameDay.Any(x => IsOverlap(x.Ngay, x.GioBatDau, x.SoGio, start, end));
        }

        // ===== ĐẶT SÂN =====
        public (bool ok, string message, int? datSanId) DatSan(
            int nguoiDungId, int sanId, DateTime ngay, TimeSpan gioBatDau, int soGio, int giaGio)
        {
            if (nguoiDungId <= 0) return (false, "Người dùng không hợp lệ.", null);
            if (sanId <= 0) return (false, "Sân không hợp lệ.", null);
            if (soGio <= 0) return (false, "Số giờ phải > 0.", null);
            if (giaGio < 0) return (false, "Giá giờ không hợp lệ.", null);

            using var db = new BadmintonContext();

            if (!db.Sans.AsNoTracking().Any(s => s.Id == sanId))
                return (false, "Không tìm thấy sân.", null);

            var start = ngay.Date + gioBatDau;
            var end = start.AddHours(soGio);

            var sameDay = db.DatSans.AsNoTracking()
                            .Where(x => x.SanId == sanId && x.Ngay == ngay.Date)
                            .Select(x => new { x.Ngay, x.GioBatDau, x.SoGio })
                            .ToList();

            if (sameDay.Any(x => IsOverlap(x.Ngay, x.GioBatDau, x.SoGio, start, end)))
                return (false, "Khung giờ đã có người đặt.", null);

            var ds = new DatSan
            {
                NguoiDungId = nguoiDungId,
                SanId = sanId,
                Ngay = ngay.Date,
                GioBatDau = gioBatDau.ToString(@"hh\:mm"),
                SoGio = soGio,
                GiaGio = giaGio
            };

            db.DatSans.Add(ds);
            db.SaveChanges();
            return (true, "Đặt sân thành công.", ds.Id);
        }

        // ===== LỊCH SỬ NGƯỜI DÙNG =====
        public IEnumerable<LichSuItem> LichSuNguoiDung(int nguoiDungId)
        {
            using var db = new BadmintonContext();

            var q = from d in db.DatSans.AsNoTracking()
                    join s in db.Sans.AsNoTracking() on d.SanId equals s.Id
                    join c in db.CauLacBos.AsNoTracking() on s.CLBId equals c.Id
                    where d.NguoiDungId == nguoiDungId
                    orderby d.Ngay descending, d.GioBatDau
                    select new LichSuItem
                    {
                        Id = d.Id,
                        CLB = c.TenCLB,
                        San = s.TenSan,
                        Ngay = d.Ngay,
                        GioBatDau = d.GioBatDau,
                        SoGio = d.SoGio,
                        GiaGio = d.GiaGio,
                        TongTien = d.SoGio * d.GiaGio
                    };

            return q.ToList();
        }

        // ===== THANH TOÁN =====
        public (bool ok, string message) ThanhToan(int datSanId)
        {
            using var db = new BadmintonContext();

            var ds = db.DatSans.AsNoTracking()
                       .Where(x => x.Id == datSanId)
                       .Select(x => new { x.Id, x.SoGio, x.GiaGio })
                       .FirstOrDefault();

            if (ds == null) return (false, "Không tìm thấy đặt sân.");
            if (db.ThanhToans.AsNoTracking().Any(x => x.DatSanId == datSanId))
                return (false, "Đơn này đã thanh toán.");

            var tong = ds.SoGio * ds.GiaGio;

            db.ThanhToans.Add(new ThanhToan
            {
                DatSanId = ds.Id,
                TongTien = tong,
                NgayThanhToan = DateTime.Now
            });
            db.SaveChanges();
            return (true, "Thanh toán thành công.");
        }
    }
}
