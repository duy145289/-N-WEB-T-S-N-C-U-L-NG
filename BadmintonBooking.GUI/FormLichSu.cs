using System;
using System.ComponentModel; // BindingList
using System.Linq;
using System.Windows.Forms;
using BadmintonBooking.BUS;

namespace BadmintonBooking.GUI
{
    public partial class FormLichSu : Form
    {
        public FormLichSu()
        {
            InitializeComponent();
            this.Load += FormLichSu_Load;
            btnDong.Click += (s, e) => Close();
        }

        private void FormLichSu_Load(object? sender, EventArgs e)
        {
            if (!Session.IsLoggedIn)
            {
                MessageBox.Show("Vui lòng đăng nhập.");
                Close();
                return;
            }

            var bus = new BookingBUS();
            var list = bus.LichSuNguoiDung(Session.CurrentUser!.Id).ToList();

            grid.AutoGenerateColumns = true;
            grid.Columns.Clear();
            grid.DataSource = new BindingList<LichSuItem>(list);

            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.ReadOnly = true;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (grid.Columns.Contains("GiaGio"))
                grid.Columns["GiaGio"].DefaultCellStyle.Format = "N0";
            if (grid.Columns.Contains("TongTien"))
                grid.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            if (grid.Columns.Contains("Ngay"))
                grid.Columns["Ngay"].DefaultCellStyle.Format = "dd/MM/yyyy";

            if (list.Count == 0)
                MessageBox.Show("Chưa có lịch sử đặt sân.", "Thông báo");
        }
    }
}
