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
using Sql = SQL.SQL;
namespace CuoiKy
{
    public partial class rpt_BaoCaoDoanhThu : Form
    {
        DateTime tungay, denngay;
        public rpt_BaoCaoDoanhThu(DateTime TuNgay, DateTime DenNgay)
        {
            InitializeComponent();
            tungay = TuNgay;
            denngay = DenNgay;
        }

        private void rpt_BaoCaoDoanhThu_Load(object sender, EventArgs e)
        {// Load dữ liệu
            DataTable dt = Sql.getData($"exec dbo.sp_BaoCaoDoanhThuNgay_Report '{tungay.ToString("yyyy-MM-dd")}','{denngay.ToString("yyyy-MM-dd")}', '{TaiKhoan.MaCN}'");

            // Gán nguồn dữ
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.DataSources.Clear(); 
            reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }
    }
}
