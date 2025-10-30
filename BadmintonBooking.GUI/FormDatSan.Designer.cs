namespace BadmintonBooking.GUI
{
    partial class FormDatSan
    {
        private System.ComponentModel.IContainer components=null;
        private System.Windows.Forms.ComboBox cboSan;
        private System.Windows.Forms.DateTimePicker dtNgay, dtGio;
        private System.Windows.Forms.NumericUpDown numSoGio, numGiaGio;
        private System.Windows.Forms.Button btnKiemTra, btnDat, btnDong;

        protected override void Dispose(bool disposing){ if (disposing && components!=null) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            cboSan = new System.Windows.Forms.ComboBox(){ Left=20, Top=20, Width=300, DropDownStyle=System.Windows.Forms.ComboBoxStyle.DropDownList };
            dtNgay = new System.Windows.Forms.DateTimePicker(){ Left=20, Top=60, Width=140, Format=System.Windows.Forms.DateTimePickerFormat.Short };
            dtGio = new System.Windows.Forms.DateTimePicker(){ Left=180, Top=60, Width=140, Format=System.Windows.Forms.DateTimePickerFormat.Time, ShowUpDown=true };
            numSoGio = new System.Windows.Forms.NumericUpDown(){ Left=20, Top=100, Width=140, Minimum=1, Maximum=6, Value=2 };
            numGiaGio = new System.Windows.Forms.NumericUpDown(){ Left=180, Top=100, Width=140, Minimum=50000, Maximum=1000000, Increment=50000, Value=150000 };
            btnKiemTra = new System.Windows.Forms.Button(){ Left=20, Top=140, Width=100, Text="Kiểm tra" };
            btnDat = new System.Windows.Forms.Button(){ Left=130, Top=140, Width=100, Text="Đặt" };
            btnDong = new System.Windows.Forms.Button(){ Left=240, Top=140, Width=100, Text="Đóng", DialogResult=System.Windows.Forms.DialogResult.Cancel };
            this.ClientSize = new System.Drawing.Size(350, 190);
            this.Controls.AddRange(new System.Windows.Forms.Control[]{cboSan,dtNgay,dtGio,numSoGio,numGiaGio,btnKiemTra,btnDat,btnDong});
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đặt sân";
        }
    }
}
