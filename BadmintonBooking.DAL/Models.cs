using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BadmintonBooking.DAL
{
    public class CauLacBo
    {
        public int Id { get; set; }
        public string TenCLB { get; set; } = "";
        public string DiaChi { get; set; } = "";
        public string GioMoCua { get; set; } = "06:00";
        public string GioDongCua { get; set; } = "22:00";
    }

    public class San
    {
        public int Id { get; set; }
        public int CLBId { get; set; }
        public string TenSan { get; set; } = "";
        public string TrangThai { get; set; } = "";

        [ForeignKey(nameof(CLBId))]
        public CauLacBo? CauLacBo { get; set; }
    }

    public class NguoiDung
    {
        public int Id { get; set; }
        public string HoTen { get; set; } = "";
        public string Email { get; set; } = "";
        public string MatKhau { get; set; } = "";
        public bool LaAdmin { get; set; }
    }

    public class DatSan
    {
        public int Id { get; set; }
        public int NguoiDungId { get; set; }
        public int SanId { get; set; }
        public DateTime Ngay { get; set; }
        public string GioBatDau { get; set; } = "00:00";
        public int SoGio { get; set; }
        public int GiaGio { get; set; }
    }

    public class ThanhToan
    {
        public int Id { get; set; }
        public int DatSanId { get; set; }
        public int TongTien { get; set; }
        public DateTime NgayThanhToan { get; set; }
    }
}
