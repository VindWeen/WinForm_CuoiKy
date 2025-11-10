using Microsoft.Reporting.WinForms;
using SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sql = SQL.SQL;

namespace CuoiKy
{
    public partial class rpt_XuatNhapKho : Form
    {
        DateTime tungay, denngay;
        public int tondau, toncuoi;

        public rpt_XuatNhapKho(DateTime TuNgay, DateTime DenNgay)
        {
            InitializeComponent(); tungay = TuNgay;
            denngay = DenNgay;
        }

        private void rpt_XuatNhapKho_Load(object sender, EventArgs e)
        {
            // Load dữ liệu
            DataTable dt = Sql.getData($"exec dbo.sp_BaoCaoXuatNhapKho '{tungay.ToString("yyyy-MM-dd")}','{denngay.ToString("yyyy-MM-dd")}', '{TaiKhoan.MaCN}'");

            // Gán nguồn dữ
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            DataTable dt1 = Sql.getData($"EXEC dbo.sp_TonDauCuoi_TheoKhoangNgay_ChiNhanh '{tungay.ToString("yyyy-MM-dd")}','{denngay.ToString("yyyy-MM-dd")}', '{TaiKhoan.MaCN}'");
            // Giả sử dt1 là DataTable bạn vừa lấy
            
            // Gán nguồn dữ
            ReportDataSource rds2 = new ReportDataSource("DataSet2", dt1);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.DataSources.Add(rds2);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
