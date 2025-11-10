using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuoiKy
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new BanHang("Tong"));
            Application.Run(new Login());
            //Application.Run(new XemHoaDon());
            //Application.Run(new QuanLy_Tong());
            //Application.Run(new HoaDon("Tong"));
            //Application.Run(new DoanhThu("Tong"));
            //Application.Run(new QuanLy_Tong("Tong"));
            //Application.Run(new PhieuXuat("Tong"));
            //Application.Run(new ThemPhieuXuat("Tong"));
            //Application.Run(new rpt_BaoCaoDoanhThu());
        }
    }
}
