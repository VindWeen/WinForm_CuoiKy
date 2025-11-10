using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sql = SQL.SQL;

namespace CuoiKy
{
    public partial class Bill : Form
    {
        public string SoHD;
        public Bill(string soHD)
        {
            InitializeComponent();
            SoHD = soHD;
        }

        private void Bill_Load(object sender, EventArgs e)
        {
            // Load dữ liệu
            DataTable dt = Sql.getData($"exec dbo.sp_ChiTietHoaDon '{SoHD}'");

            // Gán nguồn dữ
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            DataTable dt2 = Sql.getData($"exec dbo.sp_ChiTietHoaDon1 '{SoHD}'");

            // Gán nguồn dữ
            ReportDataSource rds2 = new ReportDataSource("DataSet2", dt2);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.DataSources.Add(rds2);
            this.reportViewer1.RefreshReport();
        }
        public void Print()
        {
            reportViewer1.Print += reportViewer1_Print;
        }

        private void reportViewer1_Print(object sender, ReportPrintEventArgs e)
        {
        }
    }
}
