using System;
using System.Linq;
using System.Windows.Forms;
using BadmintonBooking.BUS;

// Alias để dùng đúng Timer của WinForms
using WinFormsTimer = System.Windows.Forms.Timer;

namespace BadmintonBooking.GUI
{
    public partial class FormChinh : Form
    {
        private readonly BookingBUS booking = new BookingBUS();

        // Dùng alias rõ ràng để tránh trùng với System.Threading.Timer
        private WinFormsTimer _searchTimer; // debounce tìm kiếm

        public FormChinh()
        {
            InitializeComponent();

            // ====== Cấu hình sự kiện ======
            this.Load += (s, e) =>
            {
                LoadDanhSachCLB(); // nạp dữ liệu ban đầu
                RefreshTitle();
            };

            btnDangNhap.Click += (s, e) =>
            {
                using var f = new FormDangNhap();
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    RefreshTitle();
                    MoManHinhDatSanSauDangNhap();
                }
            };

            btnDangKy.Click += (s, e) => { using var f = new FormDangKy(); f.ShowDialog(this); };

            btnTaiKhoan.Click += (s, e) =>
            {
                if (Session.IsLoggedIn)
                    MessageBox.Show($"Tài khoản: {Session.CurrentUser!.Email}");
                else
                    btnDangNhap.PerformClick();
            };

            btnSanDaDat.Click += (s, e) =>
            {
                if (!Session.IsLoggedIn)
                {
                    MessageBox.Show("Vui lòng đăng nhập.");
                    return;
                }
                using var f = new FormLichSu();
                f.ShowDialog(this);
            };

            btnTinhTien?.Click += (s, e) =>
            {
                using var f = new FormTinhTien();
                f.ShowDialog(this);
            };

            // ====== Tìm kiếm tự động (debounce) ======
            _searchTimer = new WinFormsTimer { Interval = 300 }; // 300ms
            _searchTimer.Tick += (s, e) =>
            {
                _searchTimer.Stop();
                TimKiemCLB();
            };
            txtTimKiem.TextChanged += (s, e) =>
            {
                _searchTimer.Stop();
                _searchTimer.Start();
            };
        }

        private void RefreshTitle()
        {
            this.Text = Session.IsLoggedIn
                ? $"Xin chào, {Session.CurrentUser!.HoTen}"
                : "BadmintonBooking";
        }

        // ============= NẠP DANH SÁCH CLB =============
        private void LoadDanhSachCLB()
        {
            var ds = booking.DanhSachCLB();
            HienThiDanhSach(ds);
        }

        // ============= TÌM KIẾM =============
        private void TimKiemCLB()
        {
            var keyword = txtTimKiem.Text?.Trim() ?? string.Empty;
            var ds = booking.DanhSachCLB(keyword);
            HienThiDanhSach(ds);
        }

        // ============= HIỂN THỊ DANH SÁCH CLB =============
        private void HienThiDanhSach(System.Collections.Generic.IEnumerable<BadmintonBooking.DAL.CauLacBo> clbs)
        {
            flowDanhSach.SuspendLayout();
            flowDanhSach.Controls.Clear();

            foreach (var clb in clbs)
            {
                var card = new Panel
                {
                    Width = 520,
                    Height = 140,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10)
                };

                var lbl = new Label
                {
                    Text = $"{clb.TenCLB}\n{clb.DiaChi}",
                    AutoSize = false,
                    Dock = DockStyle.Top,
                    Height = 60,
                    Padding = new Padding(8)
                };

                var btn = new Button
                {
                    Text = "ĐẶT LỊCH",
                    Dock = DockStyle.Bottom,
                    Height = 36
                };

                btn.Click += (s, e) =>
                {
                    if (!Session.IsLoggedIn)
                    {
                        MessageBox.Show("Vui lòng đăng nhập trước khi đặt sân.");
                        return;
                    }

                    using var f = new FormDatSan(clb.Id, clb.TenCLB);
                    f.ShowDialog(this);
                };

                card.Controls.Add(btn);
                card.Controls.Add(lbl);
                flowDanhSach.Controls.Add(card);
            }

            flowDanhSach.ResumeLayout();
        }

        // ============= MỞ FORM ĐẶT SÂN SAU ĐĂNG NHẬP =============
        private void MoManHinhDatSanSauDangNhap()
        {
            var clbs = booking.DanhSachCLB().ToList();
            if (clbs.Count == 0)
            {
                MessageBox.Show("Chưa có câu lạc bộ.");
                return;
            }

            using var f = new FormDatSan(clbs[0].Id, clbs[0].TenCLB);
            f.ShowDialog(this);
        }

        private void btnDangKy_Click(object sender, EventArgs e) { }
    }
}
