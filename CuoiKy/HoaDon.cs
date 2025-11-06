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
using Sql = SQL.SQL;

namespace CuoiKy
{
    public partial class HoaDon : Form
    {
        string MaCN = TaiKhoan.MaCN;
        public HoaDon()
        {
            InitializeComponent();
        }


        private void cb_filterngay_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cb_filterngay.SelectedIndex)
            {
                case 0: // Hôm nay
                    dtp_tungay.Value = DateTime.Now.Date;
                    dtp_denngay.Value = DateTime.Now.Date;
                    dtp_tutg.Value = DateTime.Now.Date.AddHours(1);
                    dtp_dentg.Value = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                    pb_date.Visible = false;
                    break;

                case 1: // Hôm qua
                    DateTime homQua = DateTime.Now.AddDays(-1).Date;
                    dtp_tungay.Value = homQua;
                    dtp_denngay.Value = homQua;
                    dtp_tutg.Value = homQua.AddHours(1);
                    dtp_dentg.Value = homQua.AddHours(23).AddMinutes(59).AddSeconds(59);
                    pb_date.Visible = false;
                    break;

                case 2: // 7 ngày gần nhất
                    DateTime bayNgayTruoc = DateTime.Now.AddDays(-6).Date;
                    DateTime homNay = DateTime.Now.Date;
                    dtp_tungay.Value = bayNgayTruoc;
                    dtp_denngay.Value = homNay;
                    dtp_tutg.Value = bayNgayTruoc.AddHours(1);
                    dtp_dentg.Value = homNay.AddHours(23).AddMinutes(59).AddSeconds(59);
                    pb_date.Visible = false;
                    break;

                case 3: // Tháng này
                    DateTime now = DateTime.Now;
                    DateTime firstDay = new DateTime(now.Year, now.Month, 1);
                    DateTime lastDay = firstDay.AddMonths(1).AddDays(-1);

                    dtp_tungay.Value = firstDay;
                    dtp_denngay.Value = lastDay;
                    dtp_tutg.Value = firstDay.AddHours(1);
                    dtp_dentg.Value = lastDay.AddHours(23).AddMinutes(59).AddSeconds(59);
                    pb_date.Visible = false;
                    break;

                case 4: // Tùy chỉnh
                    dtp_tutg.Value = DateTime.Now.Date.AddHours(8);
                    dtp_dentg.Value = DateTime.Now.Date.AddHours(22);
                    pb_date.Visible = true;
                    break;
            }
            Load_dgv();
        }
        private void Load_dgv()
        {
            /*
                *
                =
                >
                ≥
                <
                ≤
             */
            dgv_sanpham.Rows.Clear();
            string filter_sl="", filter_tt="";
            switch (cb_filterSL.Text)
            {
                case "*":
                    filter_sl = "";
                    break;
                case "=":
                    filter_sl = "=";
                    break;
                case ">":
                    filter_sl = ">";
                    break;
                case "<":
                    filter_sl = "<";
                    break;
                case "≥":
                    filter_sl = ">=";
                    break;
                case "≤":
                    filter_sl = "<=";
                    break;
            }
            switch (cb_filterThanhTien.Text)
            {
                case "*":
                    filter_tt = "";
                    break;
                case "=":
                    filter_tt = "=";
                    break;
                case ">":
                    filter_tt = ">";
                    break;
                case "<":
                    filter_tt = "<";
                    break;
                case "≥":
                    filter_tt = ">=";
                    break;
                case "≤":
                    filter_tt = "<=";
                    break;
            }
            string query = $@"select * from dbo.vHoaDon where LEFT(SoHD, PATINDEX('%[0-9]%', SoHD) - 1) like N'{MaCN}'
                                                              and NgayLap >= '{dtp_tungay.Value.ToString("yyyy-MM-dd")+" "+dtp_tutg.Value.ToString("HH:mm:ss")}'
                                                              and NgayLap <= '{dtp_denngay.Value.ToString("yyyy-MM-dd") + " " + dtp_dentg.Value.ToString("HH:mm:ss")}'";
            // 🔸 Lọc theo số hóa đơn
            if (!string.IsNullOrWhiteSpace(txt_timsohd.Text))
            {
                query += $" and SoHD like N'%{txt_timsohd.Text.Trim()}%'";
            }

            // 🔸 Lọc theo số điện thoại
            if (!string.IsNullOrWhiteSpace(txt_SDT.Text) && txt_SDT.Text != "*")
            {
                query += $" and SDT like N'%{txt_SDT.Text.Trim()}%'";
            }

            // 🔸 Lọc theo nhân viên
            if (!string.IsNullOrWhiteSpace(txt_NhanVien.Text) && txt_NhanVien.Text != "*")
            {
                query += $" and HoTenNV like N'%{txt_NhanVien.Text.Trim()}%'";
            }

            // 🔸 Lọc theo số lượng
            if (!string.IsNullOrWhiteSpace(txt_SL.Text) && txt_SL.Text != "*")
            {
                query += $" and SL {filter_sl} {txt_SL.Text}";
            }

            // 🔸 Lọc theo thành tiền (nếu bạn muốn thêm textbox hoặc combobox lọc giá trị)
            if (!string.IsNullOrWhiteSpace(txt_ThanhTien.Text))
            {
                // Có thể dùng khoảng hoặc chính xác
                query += $" and TongTien {filter_tt} {txt_ThanhTien.Text}";
            }

            // 🔸 Cuối cùng: sắp xếp theo thời gian mới nhất
            query += " order by NgayLap desc";
            SqlDataReader rd = Sql.Reader(query);
            int sumSL = 0,sumTT = 0;
            while(rd.Read()) 
            {
                string sdt = rd["SDT"] == DBNull.Value ? "Khách lẻ" : rd["SDT"].ToString();
                dgv_sanpham.Rows.Add(
                    rd["NgayLap"].ToString(),
                    rd["SoHD"].ToString(),
                    Convert.ToInt32(rd["SL"]).ToString(),
                    Convert.ToInt32(rd["TongTien"]).ToString("N0"),
                    sdt,
                    rd["HoTenNV"].ToString()
                );

                //dgv_sanpham.Rows.Add(rd["NgayLap"].ToString() ,rd["SoHD"].ToString(),Convert.ToInt32(rd["SL"]).ToString(),Convert.ToInt32(rd["TongTien"]).ToString("N0"),rd["SDT"].ToString(),rd["HoTenNV"].ToString());
                sumSL += Convert.ToInt32(rd["SL"].ToString());
                sumTT += Convert.ToInt32(rd["TongTien"].ToString());
            }
            rd.Close();
            lbl_TongHoaDon.Text = dgv_sanpham.Rows.Count.ToString();
            lbl_TongSoLuong.Text = sumSL.ToString();
            lbl_TongTien.Text = sumTT.ToString("N0");
            dgv_sanpham.ClearSelection();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            pb_date.Visible=false;
            Load_dgv();
        }

        private void HoaDon_Load_1(object sender, EventArgs e)
        {
            cb_filterngay.SelectedIndex = 0;
            cb_filterSL.SelectedIndex = 0;
            cb_filterThanhTien.SelectedIndex = 0;
            Load_dgv();
        }

        private void dgv_sanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            DataGridViewRow a = dgv_sanpham.Rows[e.RowIndex];
            XemHoaDon frm = new XemHoaDon(a.Cells["SoHD"].Value.ToString());
            //MessageBox.Show(a.Cells["SoHD"].Value.ToString());
            frm.ShowDialog();
            dgv_sanpham.ClearSelection();
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

        private void cb_filterSL_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cb_filterSL.SelectedIndex)
            {
                case 0:
                    txt_SL.Clear();
                    txt_SL.Enabled = false;
                    Load_dgv(); break;
                default:
                    txt_SL.Enabled = true;
                    break;
            }
        }

        private void txt_timsohd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Load_dgv();
            }
        }

        private void txt_SL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9 || e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                return;
            else if (e.KeyCode == Keys.Enter)
            {
                Load_dgv();
                if (string.IsNullOrEmpty(txt_SL.Text))
                {
                    txt_SL.Enabled = false;
                    cb_filterSL.SelectedIndex = 0;
                }
            }
            else
                e.SuppressKeyPress = true;
        }

        private void txt_ThanhTien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9 || e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                return;
            else if (e.KeyCode == Keys.Enter)
            {
                Load_dgv();
                if (string.IsNullOrEmpty(txt_ThanhTien.Text))
                {
                    txt_ThanhTien.Enabled = false;
                    cb_filterThanhTien.SelectedIndex = 0;
                }
            }
            else
                e.SuppressKeyPress = true;
        }

        private void txt_SDT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9 || e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                return;
            else if (e.KeyCode == Keys.Enter)
            {
                Load_dgv();

            }
            else
                e.SuppressKeyPress = true;
        }

        private void cb_filterThanhTien_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cb_filterThanhTien.SelectedIndex)
            {
                case 0:
                    txt_SL.Clear();
                    txt_ThanhTien.Enabled = false;
                    Load_dgv(); break;
                default:
                    txt_ThanhTien.Enabled = true;
                    break;
            }
        }

        private void txt_NhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Load_dgv();
            }
        }

        private void btn_BanHang_Click(object sender, EventArgs e)
        {
            this.Hide();
            BanHang frmBanHang = new BanHang();
            frmBanHang.ShowDialog();
            this.Close();
        }

        private void dgv_sanpham_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Chặn hành động sort
            dgv_sanpham.Columns[e.ColumnIndex].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void HoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btn_DoanhThu_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoanhThu frm = new DoanhThu();
            frm.ShowDialog();
            this.Close();
        }

        private void btn_Quanly_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLy_Tong frm = new QuanLy_Tong();
            frm.ShowDialog();
            this.Close();
        }
    }
}
