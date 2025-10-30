namespace BadmintonBooking.GUI
{
    partial class FormLichSu
    {
        private System.ComponentModel.IContainer components=null;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button btnDong;
        protected override void Dispose(bool disposing){ if (disposing && components!=null) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            grid = new DataGridView();
            btnDong = new Button();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            SuspendLayout();
            // 
            // grid
            // 
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.Location = new Point(0, 0);
            grid.Name = "grid";
            grid.RowHeadersWidth = 51;
            grid.Size = new Size(698, 323);
            grid.TabIndex = 0;
            // 
            // btnDong
            // 
            btnDong.Location = new Point(0, 0);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(75, 23);
            btnDong.TabIndex = 1;
            // 
            // FormLichSu
            // 
            ClientSize = new Size(700, 320);
            Controls.Add(grid);
            Controls.Add(btnDong);
            Name = "FormLichSu";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Lịch sử đặt sân";
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ResumeLayout(false);
        }
    }
}
