using System;
using System.Windows.Forms;
using BadmintonBooking.BUS;

namespace BadmintonBooking.GUI
{
    public partial class FormDangKy : Form
    {
        public FormDangKy(){ InitializeComponent(); btnOK.Click += BtnOK_Click; }
        private void BtnOK_Click(object? sender, EventArgs e)
        {
            var ok = new AuthBUS().DangKy(txtHoTen.Text.Trim(), txtEmail.Text.Trim(), txtMatKhau.Text, out var msg);
            MessageBox.Show(msg);
            if (ok) this.Close();
        }
    }
}
