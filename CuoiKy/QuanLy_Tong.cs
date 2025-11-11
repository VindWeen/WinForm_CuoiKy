using System;
using System.Collections;
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
    public partial class QuanLy_Tong : Form
    {
        string MaCN;
        string QuyenHan = TaiKhoan.QuyenHan;
        public QuanLy_Tong()
        {
            InitializeComponent();
            MaCN= TaiKhoan.MaCN;
        }

        private void QuanLy_Tong_Load(object sender, EventArgs e)
        {
            cb_filterngay.SelectedIndex = 0;
            group_sp.Visible = QuyenHan == "Admin"? true : false;
            Load_Data();
            
        }
        private void Load_Data()
        {
            //MessageBox.Show($"{MaCN}");
            string query1 = $@"SELECT *
                              FROM [CoupleTX_SQL].[dbo].[vBaoCaoQuanLy_Ngay_ChiNhanh] where MaCN like '{MaCN}' and Ngay between '{dtp_tungay.Value.ToString("yyyy-MM-dd")}' and '{dtp_denngay.Value.ToString("yyyy-MM-dd")}'";
            lbl_TenChiNhanh.Text = Convert.ToString(Sql.Scalar($"Select TenCN from ChiNhanh where MaCN like '{MaCN}'"));
            string query2 = $@"SELECT TonCuoiNgay,TonDauNgay FROM dbo.vTonKho_TheoChiNhanh WHERE MaCN LIKE '{MaCN}' and Ngay between '{dtp_tungay.Value.ToString("yyyy-MM-dd")}' and '{dtp_denngay.Value.ToString("yyyy-MM-dd")}'";
            SqlDataReader rd = Sql.Reader(query2);
            if (rd.Read())
            {
                lbl_Ton.Text = Convert.ToInt32(rd["TonCuoiNgay"]).ToString("N0");
                lbl_tondaungay.Text = Convert.ToInt32(rd["TonDauNgay"]).ToString("N0");
                rd.Close();
            }
            else
            {
                lbl_Ton.Text = "0";
                lbl_tondaungay.Text = "0";
            }
            rd = Sql.Reader(query1);
            if (rd.Read())
            {
                lbl_SLDaNhap.Text = Convert.ToInt32(rd["SL_Nhap"]).ToString("N0");
                lbl_SLKDaXuat.Text = Convert.ToInt32(rd["SL_Ban_Xuat"]).ToString("N0");
                rd.Close();
            }
            else
            {
                lbl_SLDaNhap.Text = "0";
                lbl_SLKDaXuat.Text = "0";
            }
            int sl = Convert.ToInt32(Sql.Scalar($@"select count(*) from [dbo].[PhieuNhap] where DenCN like '{MaCN}' and LEFT(SoPN,2) LIKE 'PX'"));
            if (sl > 0)
                errorProvider1.SetError(btn_NhapPhieu, "Có phiếu nhập chưa được xử lý");
            else
                errorProvider1.Clear();
        }

        private void cb_filterngay_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cb_filterngay.SelectedIndex)
            {
                case 0://Hôm nay
                    dtp_tungay.Value = DateTime.Now;
                    dtp_denngay.Value = DateTime.Now;             
                    pb_date.Visible = false;
                    break;
                case 1://Hôm qua
                    dtp_tungay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 1);
                    dtp_denngay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 1);
                    pb_date.Visible = false;
                    break;
                case 2://7 ngày
                    dtp_tungay.Value = DateTime.Now.AddDays(-6).Date; // hôm nay tính là ngày thứ 7
                    dtp_denngay.Value = DateTime.Now.Date;
                    pb_date.Visible = false;
                    break;
                case 3://Tháng này
                    DateTime now = DateTime.Now;
                    DateTime firstDay = new DateTime(now.Year, now.Month, 1); // Ngày đầu tháng
                    DateTime lastDay = firstDay.AddMonths(1).AddDays(-1);     // Ngày cuối tháng

                    dtp_tungay.Value = firstDay;
                    dtp_denngay.Value = lastDay;
                    pb_date.Visible = false;
                    break;
                case 4://Tùy chỉnh
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

        private void btn_DoanhThu_Click(object sender, EventArgs e)
        {

            this.Hide();
            DoanhThu frm = new DoanhThu();
            frm.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Load_Data();
            pb_date.Visible=false;
        }

        private void btn_NhapPhieu_Click(object sender, EventArgs e)
        {
            this.Hide();
            PhieuNhap frm = new PhieuNhap();
            frm.ShowDialog();
            this.Close();
        }

        private void btn_TaoPhieuXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            PhieuXuat frm = new PhieuXuat();
            frm.ShowDialog();
            this.Close();
        }

        private void btn_Quanly_Click(object sender, EventArgs e)
        {

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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SanPham frm = new SanPham();
            frm.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Hide();
            NhanVien frm = new NhanVien();
            frm.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChiNhanh frm = new ChiNhanh();
            frm.ShowDialog();
            this.Close();
        }

        private void btn_XuatBaoCao_Click(object sender, EventArgs e)
        {
            rpt_XuatNhapKho frm = new rpt_XuatNhapKho(dtp_tungay.Value, dtp_denngay.Value);
            frm.tondau = Convert.ToInt32(lbl_tondaungay.Text.Replace(".",""));  
            frm.toncuoi = Convert.ToInt32(lbl_Ton.Text.Replace(".", ""));
            frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Account frm = new Account();
            frm.ShowDialog();
            this.Close();
        }
    }
}
