using System.Linq;
using BadmintonBooking.DAL;

namespace BadmintonBooking.BUS
{
    public class AuthBUS
    {
        public NguoiDung? DangNhap(string email, string matkhau)
        {
            using var db = new BadmintonContext();
            return db.NguoiDungs.FirstOrDefault(x => x.Email == email && x.MatKhau == matkhau);
        }

        public bool DangKy(string hoTen, string email, string matkhau, out string message)
        {
            using var db = new BadmintonContext();
            if (db.NguoiDungs.Any(x => x.Email == email))
            {
                message = "Email đã tồn tại.";
                return false;
            }
            var nd = new NguoiDung{ HoTen = hoTen, Email = email, MatKhau = matkhau, LaAdmin = false };
            db.NguoiDungs.Add(nd);
            db.SaveChanges();
            message = "Đăng ký thành công.";
            return true;
        }
    }
}
