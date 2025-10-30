namespace BadmintonBooking.GUI
{
    partial class FormThanhToan
    {
        private System.ComponentModel.IContainer components=null;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnThanhToan, btnDong;
        protected override void Dispose(bool disposing){ if (disposing && components!=null) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            lblInfo = new Label();
            btnThanhToan = new Button();
            btnDong = new Button();
            SuspendLayout();
            // 
            // lblInfo
            // 
            lblInfo.Location = new Point(0, 0);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(100, 23);
            lblInfo.TabIndex = 0;
            // 
            // btnThanhToan
            // 
            btnThanhToan.Location = new Point(0, 0);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(75, 23);
            btnThanhToan.TabIndex = 1;
            // 
            // btnDong
            // 
            btnDong.Location = new Point(0, 0);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(75, 23);
            btnDong.TabIndex = 2;
            // 
            // FormThanhToan
            // 
            ClientSize = new Size(637, 394);
            Controls.Add(lblInfo);
            Controls.Add(btnThanhToan);
            Controls.Add(btnDong);
            Name = "FormThanhToan";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thanh toán";
            ResumeLayout(false);
        }
    }
}
