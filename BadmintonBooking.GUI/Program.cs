using System;
using System.Windows.Forms;
using BadmintonBooking.DAL;

namespace BadmintonBooking.GUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (var db = new BadmintonContext()) db.EnsureCreatedAndSeed();
            Application.Run(new FormChinh());
        }
    }
}
