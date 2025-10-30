namespace BadmintonBooking.GUI
{
    partial class FormTinhTien
    {
        private System.ComponentModel.IContainer components=null;
        private System.Windows.Forms.NumericUpDown numTienSan, numTienCau, numGio;
        private System.Windows.Forms.NumericUpDown numNam, numNu;
        private System.Windows.Forms.CheckBox chkNuGiam5k;
        private System.Windows.Forms.Button btnTinh, btnDong;
        private System.Windows.Forms.TextBox txtKetQua;

        protected override void Dispose(bool d){ if(d&&components!=null) components.Dispose(); base.Dispose(d);}
        private void InitializeComponent()
        {
            numTienSan = new NumericUpDown();
            numTienCau = new NumericUpDown();
            numGio = new NumericUpDown();
            numNam = new NumericUpDown();
            numNu = new NumericUpDown();
            chkNuGiam5k = new CheckBox();
            btnTinh = new Button();
            btnDong = new Button();
            txtKetQua = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)numTienSan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTienCau).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numGio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numNam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numNu).BeginInit();
            SuspendLayout();
            // 
            // numTienSan
            // 
            numTienSan.Location = new Point(155, 32);
            numTienSan.Name = "numTienSan";
            numTienSan.Size = new Size(120, 27);
            numTienSan.TabIndex = 0;
            // 
            // numTienCau
            // 
            numTienCau.Location = new Point(462, 34);
            numTienCau.Name = "numTienCau";
            numTienCau.Size = new Size(120, 27);
            numTienCau.TabIndex = 1;
            // 
            // numGio
            // 
            numGio.Location = new Point(746, 34);
            numGio.Name = "numGio";
            numGio.Size = new Size(120, 27);
            numGio.TabIndex = 2;
            // 
            // numNam
            // 
            numNam.Location = new Point(155, 84);
            numNam.Name = "numNam";
            numNam.Size = new Size(120, 27);
            numNam.TabIndex = 3;
            // 
            // numNu
            // 
            numNu.Location = new Point(462, 84);
            numNu.Name = "numNu";
            numNu.Size = new Size(120, 27);
            numNu.TabIndex = 4;
            // 
            // chkNuGiam5k
            // 
            chkNuGiam5k.Location = new Point(762, 87);
            chkNuGiam5k.Name = "chkNuGiam5k";
            chkNuGiam5k.Size = new Size(104, 24);
            chkNuGiam5k.TabIndex = 5;
            // 
            // btnTinh
            // 
            btnTinh.Location = new Point(57, 344);
            btnTinh.Name = "btnTinh";
            btnTinh.Size = new Size(75, 33);
            btnTinh.TabIndex = 6;
            btnTinh.Text = "Tính";
            // 
            // btnDong
            // 
            btnDong.Location = new Point(930, 359);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(75, 29);
            btnDong.TabIndex = 7;
            btnDong.Text = "Đóng";
            btnDong.Click += btnDong_Click;
            // 
            // txtKetQua
            // 
            txtKetQua.Location = new Point(155, 150);
            txtKetQua.Multiline = true;
            txtKetQua.Name = "txtKetQua";
            txtKetQua.Size = new Size(764, 175);
            txtKetQua.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(66, 34);
            label1.Name = "label1";
            label1.Size = new Size(68, 20);
            label1.TabIndex = 9;
            label1.Text = "Tiền Sân:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(69, 87);
            label2.Name = "label2";
            label2.Size = new Size(44, 20);
            label2.TabIndex = 10;
            label2.Text = "Nam:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(382, 39);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 11;
            label3.Text = "Tiền Cầu:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(688, 39);
            label4.Name = "label4";
            label4.Size = new Size(35, 20);
            label4.TabIndex = 12;
            label4.Text = "Giờ:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(382, 91);
            label5.Name = "label5";
            label5.Size = new Size(29, 20);
            label5.TabIndex = 13;
            label5.Text = "Nữ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(793, 88);
            label6.Name = "label6";
            label6.Size = new Size(107, 20);
            label6.TabIndex = 14;
            label6.Text = "Nữ<Nam 5000";
            // 
            // FormTinhTien
            // 
            ClientSize = new Size(1072, 448);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numTienSan);
            Controls.Add(numTienCau);
            Controls.Add(numGio);
            Controls.Add(numNam);
            Controls.Add(numNu);
            Controls.Add(chkNuGiam5k);
            Controls.Add(btnTinh);
            Controls.Add(btnDong);
            Controls.Add(txtKetQua);
            Name = "FormTinhTien";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tính tiền buổi đánh";
            ((System.ComponentModel.ISupportInitialize)numTienSan).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTienCau).EndInit();
            ((System.ComponentModel.ISupportInitialize)numGio).EndInit();
            ((System.ComponentModel.ISupportInitialize)numNam).EndInit();
            ((System.ComponentModel.ISupportInitialize)numNu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}
