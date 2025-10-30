using System;
using System.Windows.Forms;
using BadmintonBooking.BUS;

namespace BadmintonBooking.GUI
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap(){ InitializeComponent(); this.btnOK.Click += BtnOK_Click; }
        private void BtnOK_Click(object? sender, EventArgs e)
        {
            var auth = new AuthBUS();
            var u = auth.DangNhap(txtEmail.Text.Trim(), txtMatKhau.Text);
            if (u == null) { MessageBox.Show("Sai email hoặc mật khẩu"); return; }
            Session.CurrentUser = u;
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
