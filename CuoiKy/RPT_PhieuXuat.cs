using Microsoft.Reporting.WinForms;
using SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuoiKy
{
    public partial class RPT_PhieuXuat : Form
    {
        string SoPX;
        public RPT_PhieuXuat(string soPX)
        {
            InitializeComponent();
            SoPX = soPX;
        }

        private void RPT_PhieuXuat_Load(object sender, EventArgs e)
        {
            // Load dữ liệu
            DataTable dt = SQL.SQL.getData($"select * from dbo.v_PhieuXuat where SoPX ='{SoPX}'");

            // Gán nguồn dữ
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
