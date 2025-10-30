namespace BadmintonBooking.GUI
{
    partial class FormChinh
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel topBar;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Panel searchBar;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.FlowLayoutPanel flowDanhSach;
        private System.Windows.Forms.Panel tabBottom;
        private System.Windows.Forms.Button btnTinhTien;
        private System.Windows.Forms.Button btnSanDaDat;
        private System.Windows.Forms.Button btnTaiKhoan;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            topBar = new Panel();
            btnDangNhap = new Button();
            btnDangKy = new Button();
            searchBar = new Panel();
            txtTimKiem = new TextBox();
            flowDanhSach = new FlowLayoutPanel();
            tabBottom = new Panel();
            btnTinhTien = new Button();
            btnSanDaDat = new Button();
            btnTaiKhoan = new Button();
            topBar.SuspendLayout();
            searchBar.SuspendLayout();
            tabBottom.SuspendLayout();
            SuspendLayout();
            // 
            // topBar
            // 
            topBar.BackColor = Color.FromArgb(0, 158, 122);
            topBar.Controls.Add(btnDangNhap);
            topBar.Controls.Add(btnDangKy);
            topBar.Dock = DockStyle.Top;
            topBar.Location = new Point(0, 0);
            topBar.Name = "topBar";
            topBar.Padding = new Padding(10);
            topBar.Size = new Size(1136, 56);
            topBar.TabIndex = 3;
            // 
            // btnDangNhap
            // 
            btnDangNhap.Anchor = AnchorStyles.Right;
            btnDangNhap.Location = new Point(790, 11);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(140, 32);
            btnDangNhap.TabIndex = 0;
            btnDangNhap.Text = "Đăng nhập";
            // 
            // btnDangKy
            // 
            btnDangKy.Anchor = AnchorStyles.Right;
            btnDangKy.Location = new Point(946, 12);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(140, 32);
            btnDangKy.TabIndex = 1;
            btnDangKy.Text = "Đăng ký";
            btnDangKy.Click += btnDangKy_Click;
            // 
            // searchBar
            // 
            searchBar.BackColor = Color.White;
            searchBar.Controls.Add(txtTimKiem);
            searchBar.Dock = DockStyle.Top;
            searchBar.Location = new Point(0, 56);
            searchBar.Name = "searchBar";
            searchBar.Padding = new Padding(10);
            searchBar.Size = new Size(1136, 56);
            searchBar.TabIndex = 2;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(12, 16);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(560, 27);
            txtTimKiem.TabIndex = 0;
            // 
            // flowDanhSach
            // 
            flowDanhSach.AutoScroll = true;
            flowDanhSach.Dock = DockStyle.Fill;
            flowDanhSach.Location = new Point(0, 112);
            flowDanhSach.Name = "flowDanhSach";
            flowDanhSach.Padding = new Padding(12);
            flowDanhSach.Size = new Size(1136, 423);
            flowDanhSach.TabIndex = 0;
            // 
            // tabBottom
            // 
            tabBottom.BackColor = Color.FromArgb(0, 110, 85);
            tabBottom.Controls.Add(btnTinhTien);
            tabBottom.Controls.Add(btnSanDaDat);
            tabBottom.Controls.Add(btnTaiKhoan);
            tabBottom.Dock = DockStyle.Bottom;
            tabBottom.Location = new Point(0, 535);
            tabBottom.Name = "tabBottom";
            tabBottom.Size = new Size(1136, 60);
            tabBottom.TabIndex = 1;
            // 
            // btnTinhTien
            // 
            btnTinhTien.Location = new Point(43, 12);
            btnTinhTien.Name = "btnTinhTien";
            btnTinhTien.Size = new Size(130, 36);
            btnTinhTien.TabIndex = 0;
            btnTinhTien.Text = "Tính tiền";
            // 
            // btnSanDaDat
            // 
            btnSanDaDat.Location = new Point(216, 12);
            btnSanDaDat.Name = "btnSanDaDat";
            btnSanDaDat.Size = new Size(130, 36);
            btnSanDaDat.TabIndex = 1;
            btnSanDaDat.Text = "Sân đã đặt";
            // 
            // btnTaiKhoan
            // 
            btnTaiKhoan.Location = new Point(386, 12);
            btnTaiKhoan.Name = "btnTaiKhoan";
            btnTaiKhoan.Size = new Size(130, 36);
            btnTaiKhoan.TabIndex = 2;
            btnTaiKhoan.Text = "Tài khoản";
            // 
            // FormChinh
            // 
            ClientSize = new Size(1136, 595);
            Controls.Add(flowDanhSach);
            Controls.Add(tabBottom);
            Controls.Add(searchBar);
            Controls.Add(topBar);
            MinimumSize = new Size(1000, 600);
            Name = "FormChinh";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BadmintonBooking";
            topBar.ResumeLayout(false);
            searchBar.ResumeLayout(false);
            searchBar.PerformLayout();
            tabBottom.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
