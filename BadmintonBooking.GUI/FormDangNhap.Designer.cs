namespace BadmintonBooking.GUI
{
    partial class FormDangNhap
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnHuy;

        protected override void Dispose(bool disposing){ if (disposing && components!=null) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.txtEmail.Top = 20; this.txtEmail.Left = 20; this.txtEmail.Width = 260; this.txtEmail.PlaceholderText = "Email";
            this.txtMatKhau.Top = 60; this.txtMatKhau.Left = 20; this.txtMatKhau.Width = 260; this.txtMatKhau.PasswordChar='*'; this.txtMatKhau.PlaceholderText="Mật khẩu";
            this.btnOK.Text="Đăng nhập"; this.btnOK.Top = 100; this.btnOK.Left = 20; this.btnOK.Width=120;
            this.btnHuy.Text="Hủy"; this.btnHuy.Top=100; this.btnHuy.Left=160; this.btnHuy.Width=120; this.btnHuy.DialogResult=System.Windows.Forms.DialogResult.Cancel;
            this.ClientSize = new System.Drawing.Size(300, 150);
            this.Controls.AddRange(new System.Windows.Forms.Control[]{this.txtEmail,this.txtMatKhau,this.btnOK,this.btnHuy});
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đăng nhập";
            this.ResumeLayout(false);
        }
    }
}
