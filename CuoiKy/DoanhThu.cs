using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Sql = SQL.SQL;

namespace CuoiKy
{
    public partial class DoanhThu : Form
    {
        string MaCN;
        public DoanhThu()
        {
            InitializeComponent();
            MaCN = TaiKhoan.MaCN;
        }

        private void DoanhThu_Load(object sender, EventArgs e)
        {
            cb_filterngay.SelectedIndex = 0;
            pb_date.Visible = false;
            Load_Data();
        }
        private void Load_Data()
        {
            lbl_TenChiNhanh.Text = Convert.ToString(Sql.Scalar($"select TenCN from ChiNhanh where MaCN like '{MaCN}'"));
            string query = $@"select * from dbo.vBaoCaoBanHang_Ngay_ChiNhanh
                                where	Ngay between '{dtp_tungay.Value.ToString("yyyy-MM-dd")+" "+dtp_tutg.Value.ToString("hh:mm:ss")}' 
                                        and '{dtp_denngay.Value.ToString("yyyy-MM-dd")+" "+dtp_dentg.Value.ToString("hh:mm:ss")}' 
                                        and MaCN like '%{MaCN}%'";
            SqlDataReader rd = Sql.Reader(query);
            if(rd.Read())
            {
                lbl_TongDoanhThu.Text = Convert.ToInt32(rd["TongThanhTien"]).ToString("N0");
                lbl_SLHoaDon.Text = rd["SoHD_DaBan"].ToString();
                lbl_SLSanPham.Text = rd["TongSLBan"].ToString();
                lbl_SLKhachHang.Text = rd["SoKhachHang"].ToString();
                lbl_slKhachLe.Text = rd["SoKhachLe"].ToString();
                rd.Close();
            }
            else
            {
                lbl_TenChiNhanh.Text = Convert.ToString(Sql.Scalar($"select TenCN from ChiNhanh where MaCN like '{MaCN}'"));
                lbl_TongDoanhThu.Text = "0";
                lbl_SLHoaDon.Text = "0";
                lbl_SLSanPham.Text = "0";
                lbl_SLKhachHang.Text = "0";
                lbl_slKhachLe.Text = "0";
            }
            Load_Chart();
        }

        private void Load_Chart()
        {
            chart_DoanhThu.Legends.Clear();
            chart_DoanhThu.Titles.Clear();
            chart_DoanhThu.Series.Clear();

            Series series = new Series("Doanh thu");
            series.IsValueShownAsLabel = true;
            series.Color = ColorTranslator.FromHtml("#8FABD4");

            // Tính khoảng thời gian
            TimeSpan khoangTG = dtp_denngay.Value - dtp_tungay.Value;

            string query;
            bool theoGio = khoangTG.TotalDays < 2; // nếu dưới 2 ngày thì vẽ theo giờ

            if (theoGio)
            {
                query = $@"EXEC sp_ChartHour '{dtp_tungay.Value.ToString("yyyy-MM-dd")+" "+dtp_tutg.Value.ToString("HH:mm:ss")}', '{dtp_denngay.Value.ToString("yyyy-MM-dd")+" "+dtp_dentg.Value.ToString("HH:mm:ss") }','{MaCN}'";
            }
            else
            {
                query = $@"EXEC sp_ChartDay '{dtp_tungay.Value.ToString("yyyy-MM-dd") + " " + dtp_tutg.Value.ToString("HH:mm:ss")}', '{dtp_denngay.Value.ToString("yyyy-MM-dd") + " " + dtp_dentg.Value.ToString("HH:mm:ss")}','{MaCN}'";
            }
            SqlDataReader rd = Sql.Reader(query); 
            int count = 0;
            while (rd.Read())
            {
                if (theoGio)
                {
                    int gio = Convert.ToInt32(rd["Gio"]);
                    int tongTien = Convert.ToInt32(rd["TongTien"]);
                    series.Points.AddXY($"{gio}:00", tongTien);
                }
                else
                {
                    DateTime ngay = Convert.ToDateTime(rd["Ngay"]);
                    int tongTien = Convert.ToInt32(rd["TongTien"]);
                    series.Points.AddXY(ngay.ToString("dd/MM/yyyy"), tongTien);
                }
                count++;
            }
            if (count > 0)
            {
                chart_DoanhThu.Series.Add(series);
                chart_DoanhThu.ChartAreas[0].AxisX.Interval = 1;
                chart_DoanhThu.ChartAreas[0].AxisY.LabelStyle.Format = "#,##0";
                chart_DoanhThu.ChartAreas[0].AxisY.Title = "Doanh thu (VNĐ)";
                chart_DoanhThu.ChartAreas[0].AxisX.Title = theoGio ? "Giờ" : "Ngày";
                chart_DoanhThu.Titles.Add("Thống kê bán hàng");
                lbl_thongbao.Visible = false;
            }
            else 
            {
                lbl_thongbao.Visible =true;
                lbl_thongbao.Text = "Chưa có doanh thu để thống kê";
            }
        }

        private void cb_filterngay_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cb_filterngay.SelectedIndex)
            {
                case 0://Hôm nay
                    dtp_tungay.Value = DateTime.Now;
                    dtp_denngay.Value = DateTime.Now;
                    dtp_tutg.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 1, 0, 0);
                    dtp_dentg.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
                    pb_date.Visible = false;
                    break;
                case 1://Hôm qua
                    dtp_tungay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 1);
                    dtp_denngay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 1);
                    dtp_tutg.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 1, 1, 0, 0);
                    dtp_dentg.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 1, 23, 59, 59);
                    pb_date.Visible = false;
                    break;
                case 2://7 ngày
                    dtp_tungay.Value = DateTime.Now.AddDays(-6).Date; // hôm nay tính là ngày thứ 7
                    dtp_denngay.Value = DateTime.Now.Date;
                    dtp_tutg.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(-6).Day, 1, 0, 0);
                    dtp_dentg.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
                    pb_date.Visible = false;
                    break;
                case 3://Tháng này
                    DateTime now = DateTime.Now;
                    DateTime firstDay = new DateTime(now.Year, now.Month, 1); // Ngày đầu tháng
                    DateTime lastDay = firstDay.AddMonths(1).AddDays(-1);     // Ngày cuối tháng

                    dtp_tungay.Value = firstDay;
                    dtp_denngay.Value = lastDay;

                    dtp_tutg.Value = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day, 1, 0, 0);
                    dtp_dentg.Value = new DateTime(lastDay.Year, lastDay.Month, lastDay.Day, 23, 59, 59);
                    pb_date.Visible = false;
                    break;
                case 4://Tùy chỉnh
                    dtp_tutg.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
                    dtp_dentg.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 22, 0, 0);
                    pb_date.Visible = true;
                    break;
            }
            Load_Data();

        }

        private void btn_BanHang_Click(object sender, EventArgs e)
        {
            this.Hide();
            BanHang frm = new BanHang();
            frm.ShowDialog();
            this.Close();
        }

        private void btn_HoaDon_Click(object sender, EventArgs e)
        {
            this.Hide();
            HoaDon frm = new HoaDon();
            frm.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Load_Data();
            pb_date.Visible=false;
        }

        private void btn_Quanly_Click(object sender, EventArgs e)
        {

            this.Hide();
            QuanLy_Tong frm = new QuanLy_Tong();
            frm.ShowDialog();
            this.Close();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            var a = MessageBox.Show("Bạn có chắc muốn đăng xuất chứ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (a == DialogResult.OK)
            {
                this.Hide();
                Login frm = new Login();
                frm.ShowDialog();
                this.Close();
            }
        }
    }
}
