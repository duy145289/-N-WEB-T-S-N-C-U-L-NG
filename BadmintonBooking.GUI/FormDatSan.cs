using System;
using System.Linq;
using System.Windows.Forms;
using BadmintonBooking.BUS;

namespace BadmintonBooking.GUI
{
    public partial class FormDatSan : Form
    {
        private readonly int _clbId;
        private readonly string _clbTen;
        private readonly BookingBUS _bus = new BookingBUS();

        public FormDatSan(int clbId, string clbTen)
        {
            _clbId = clbId; _clbTen = clbTen;
            InitializeComponent();
            this.Text = $"Đặt sân - {_clbTen}";
            Load += (s,e)=>{
                cboSan.DisplayMember="TenSan";
                cboSan.ValueMember="Id";
                cboSan.DataSource = _bus.DanhSachSanTheoCLB(_clbId).ToList();
                dtGio.Value = DateTime.Today.AddHours(6);
            };
            btnKiemTra.Click += (s,e)=>{
                if (cboSan.SelectedValue==null) return;
                var ok = _bus.KiemTraTrong((int)cboSan.SelectedValue, dtNgay.Value.Date, dtGio.Value.TimeOfDay, (int)numSoGio.Value);
                MessageBox.Show(ok? "Khung giờ TRỐNG" : "Khung giờ đã có người đặt");
            };
            btnDat.Click += (s, e) =>
            {
                if (!Session.IsLoggedIn)
                {
                    MessageBox.Show("Vui lòng đăng nhập.");
                    return;
                }

                // 1) Kiểm tra combobox đã chọn
                if (cboSan.SelectedIndex < 0 || cboSan.SelectedValue == null)
                {
                    MessageBox.Show("Hãy chọn sân.");
                    return;
                }

                // 2) Lấy sanId an toàn (SelectedValue có thể là string/boxed)
                int sanId;
                try
                {
                    sanId = cboSan.SelectedValue is int v
                            ? v
                            : Convert.ToInt32(cboSan.SelectedValue);
                }
                catch
                {
                    MessageBox.Show("Giá trị sân không hợp lệ.");
                    return;
                }

                // 3) Lấy userId an toàn
                var userId = Session.CurrentUser?.Id ?? 0;
                if (userId == 0)
                {
                    MessageBox.Show("Phiên đăng nhập không hợp lệ.");
                    return;
                }

                // 4) Lấy dữ liệu đầu vào
                var ngay = dtNgay.Value.Date;
                var gio = dtGio.Value.TimeOfDay;
                var soGio = (int)numSoGio.Value;
                var gia = (int)numGiaGio.Value;

                // 5) Gọi BUS
                var result = _bus.DatSan(userId, sanId, ngay, gio, soGio, gia);
                MessageBox.Show(result.message);

                // 6) Chuyển trang thanh toán khi thành công
                if (result.ok && result.datSanId.HasValue)
                {
                    using var f = new FormThanhToan(result.datSanId.Value);
                    f.ShowDialog(this);
                }
            };

        }
    }
}
