using BadmintonBooking.BUS;
using BadmintonBooking.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BadmintonBooking.GUI
{
    public partial class FormThanhToan : Form
    {
        private readonly int _datSanId;
        public FormThanhToan(int datSanId)
        {
            _datSanId = datSanId;
            InitializeComponent();
            Load += FormThanhToan_Load;
            btnThanhToan.Click += BtnThanhToan_Click;
        }

        private void FormThanhToan_Load(object sender, EventArgs e)
        {
            using var db = new BadmintonContext();

            var ds = (from d in db.DatSans
                      join s in db.Sans on d.SanId equals s.Id
                      join c in db.CauLacBos on s.CLBId equals c.Id
                      where d.Id == _datSanId
                      select new
                      {
                          c.TenCLB,
                          s.TenSan,
                          d.Ngay,
                          d.GioBatDau,
                          d.SoGio,
                          // Ép rõ ràng về decimal để tránh cast lỗi
                          GiaGio = (decimal)EF.Property<decimal>(d, nameof(d.GiaGio))
                      })
                      .AsEnumerable() // đảm bảo ép kiểu chạy trên bộ nhớ, không phụ thuộc provider
                      .FirstOrDefault();

            if (ds == null) { Close(); return; }

            decimal tong = ds.SoGio * ds.GiaGio; // decimal * int -> decimal
            lblInfo.Text = $"CLB: {ds.TenCLB}\nSân: {ds.TenSan}\n" +
                           $"Ngày: {ds.Ngay:dd/MM/yyyy}  {ds.GioBatDau}  ({ds.SoGio} giờ)\n" +
                           $"Giá/giờ: {ds.GiaGio:N0} đ   Tổng: {tong:N0} đ";
        }


        private void BtnThanhToan_Click(object? sender, EventArgs e)
        {
            var (ok,msg) = new BookingBUS().ThanhToan(_datSanId);
            MessageBox.Show(msg);
            if (ok) this.Close();
        }
    }
}
