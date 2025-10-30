using System;
using System.Text;
using System.Windows.Forms;

namespace BadmintonBooking.GUI
{
    public partial class FormTinhTien : Form
    {
        public FormTinhTien()
        {
            InitializeComponent();

            // ================== Cấu hình NumericUpDown ==================
            // Tiền Sân
            numTienSan.Minimum = 0m;
            numTienSan.Maximum = 1_000_000_000m;
            numTienSan.Increment = 1_000m;
            numTienSan.DecimalPlaces = 0;
            numTienSan.ThousandsSeparator = true;
            numTienSan.TextAlign = HorizontalAlignment.Right;

            // Tiền Cầu
            numTienCau.Minimum = 0m;
            numTienCau.Maximum = 1_000_000_000m;
            numTienCau.Increment = 1_000m;
            numTienCau.DecimalPlaces = 0;
            numTienCau.ThousandsSeparator = true;
            numTienCau.TextAlign = HorizontalAlignment.Right;

            // Giờ (cho phép 0 nếu không bật chênh lệch; khi bật sẽ auto >=1)
            numGio.Minimum = 0m;
            numGio.Maximum = 12m;
            numGio.Increment = 1m;
            numGio.DecimalPlaces = 0;

            // Nam / Nữ
            numNam.Minimum = 0m; numNam.Maximum = 200m; numNam.Increment = 1m; numNam.DecimalPlaces = 0;
            numNu.Minimum = 0m; numNu.Maximum = 200m; numNu.Increment = 1m; numNu.DecimalPlaces = 0;

            // Nếu bật chênh lệch mà giờ = 0 thì tự nâng lên 1
            chkNuGiam5k.CheckedChanged += (s, e) =>
            {
                if (chkNuGiam5k.Checked && numGio.Value == 0) numGio.Value = 1;
            };

            // ================== Sự kiện nút ==================
            btnTinh.Click += (s, e) => Tinh();
            btnDong.Click += btnDong_Click;

            // Enter để tính nhanh
            this.AcceptButton = btnTinh;
            // Esc để đóng
            this.CancelButton = btnDong;
        }

        private void Tinh()
        {
            decimal tienSan = numTienSan.Value;
            decimal tienCau = numTienCau.Value;
            int nNam = (int)numNam.Value;
            int nNu = (int)numNu.Value;

            int n = nNam + nNu;
            if (n == 0)
            {
                txtKetQua.Text = "Chưa nhập số người.";
                return;
            }

            decimal tong = tienSan + tienCau;

            // Không áp dụng chênh lệch (hoặc 1 nhóm = 0) => chia đều
            if (!chkNuGiam5k.Checked || nNam == 0 || nNu == 0)
            {
                decimal moiNguoi = tong / n;
                txtKetQua.Text =
                    $"Tổng: {tong:N0} đ (Sân {tienSan:N0} + Cầu {tienCau:N0})\r\n" +
                    $"{n} người × {moiNguoi:N0} đ/người";
                return;
            }

            // CHÊNH LỆCH CỐ ĐỊNH 5.000 (không theo giờ)
            decimal d = 5000m;                    // x - y = 5.000
            decimal x = (tong + nNu * d) / n;     // tiền 1 nam
            decimal y = x - d;                    // tiền 1 nữ

            // Nếu d quá lớn làm y < 0, chặn y=0 và phân bổ lại cho nam
            if (y < 0)
            {
                if (nNam == 0)
                {
                    txtKetQua.Text = "Thiết lập chênh lệch không hợp lệ (không có nam).";
                    return;
                }
                y = 0;
                x = tong / nNam;
            }

            var sb = new StringBuilder();
            sb.AppendLine($"Tổng: {tong:N0} đ (Sân {tienSan:N0} + Cầu {tienCau:N0})");
            sb.AppendLine($"Chênh lệch mỗi người (Nam - Nữ): {d:N0} đ");
            sb.AppendLine($"Nam: {nNam} người × {x:N0} đ = {(nNam * x):N0} đ");
            sb.AppendLine($"Nữ : {nNu} người × {y:N0} đ = {(nNu * y):N0} đ");
            sb.AppendLine($"Tổng kiểm tra: {(nNam * x + nNu * y):N0} đ");
            txtKetQua.Text = sb.ToString();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            // Đóng form an toàn cho cả Show/ShowDialog
            if (this.Modal) this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
