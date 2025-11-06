using SQL;
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
    public partial class PhieuXuat : Form
    {
        string MaCN;
        public PhieuXuat()
        {
            InitializeComponent();
            MaCN = TaiKhoan.MaCN; 
        }

        private void PhieuXuat_Load(object sender, EventArgs e)
        {
            cb_filterngay.SelectedIndex = 0;
            cb_filterSL.SelectedIndex = 0;
            Load_Data();
        }
        private void Load_Data()
        {
            dgv_phieuxuat.Rows.Clear();
            string filter_sl = "";
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
            string TenCN = Convert.ToString(Sql.Scalar($"select TenCN from ChiNhanh where MaCN like '{MaCN}'"));
            string query = $@"select * from v_XemPhieuXuat where TuCN like N'{TenCN}'
                                                              and NgayLap >= '{dtp_tungay.Value.ToString("yyyy-MM-dd") + " " + dtp_tutg.Value.ToString("HH:mm:ss")}'
                                                              and NgayLap <= '{dtp_denngay.Value.ToString("yyyy-MM-dd") + " " + dtp_dentg.Value.ToString("HH:mm:ss")}'";
            // 🔸 Lọc theo số phiếu xuất
            if (!string.IsNullOrWhiteSpace(txt_sopx.Text))
            {
                query += $" and SoPX like N'%{txt_sopx.Text.Trim()}%'";
            }

            // 🔸 Lọc theo chi nhánh xuất
            if (!string.IsNullOrWhiteSpace(txt_DenCN.Text) && txt_DenCN.Text != "*")
            {
                query += $" and DenCN like N'%{txt_DenCN.Text.Trim()}%'";
            }

            // 🔸 Lọc theo số lượng
            if (!string.IsNullOrWhiteSpace(txt_SL.Text) && txt_SL.Text != "*")
            {
                query += $" and SL {filter_sl} {txt_SL.Text}";
            }// 🔸 Cuối cùng: sắp xếp theo thời gian mới nhất
            query += " order by NgayLap desc";
            //MessageBox.Show(query);
            int sumSL = 0;
            SqlDataReader rd = Sql.Reader(query);
            while (rd.Read())
            {
                //MessageBox.Show($"{rd["NgayLap"].ToString()}\n{rd["SoPX"].ToString()}\n{rd["DenCN"].ToString()}\n{Convert.ToInt32(rd["TongSL"]).ToString("N0")}");
                dgv_phieuxuat.Rows.Add(rd["NgayLap"].ToString() ,rd["SoPX"].ToString(),rd["DenCN"].ToString(),Convert.ToInt32(rd["TongSL"]).ToString("N0"));
                sumSL += Convert.ToInt32(rd["TongSL"].ToString());
            }
            rd.Close();
            lbl_TongPhieuXuat.Text = dgv_phieuxuat.Rows.Count.ToString();
            lbl_TongSoLuong.Text = sumSL.ToString("N0");
            dgv_phieuxuat.ClearSelection();
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

        private void cb_filterSL_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cb_filterSL.SelectedIndex)
            {
                case 0:
                    txt_SL.Clear();
                    txt_SL.Enabled = false;
                    Load_Data(); break;
                default:
                    txt_SL.Enabled = true;
                    break;
            }
        }

        private void txt_SL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9 || e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                return;
            else if (e.KeyCode == Keys.Enter)
            {
                Load_Data();
                if (string.IsNullOrEmpty(txt_SL.Text))
                {
                    txt_SL.Enabled = false;
                    cb_filterSL.SelectedIndex = 0;
                }
            }
            else
                e.SuppressKeyPress = true;
        }

        private void btn_taophieuxuat_Click(object sender, EventArgs e)
        {
            ThemPhieuXuat frm = new ThemPhieuXuat(MaCN);
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Load_Data();
        }

        private void txt_sopx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {

            }
        }

        private void btn_Quanly_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLy_Tong frm = new QuanLy_Tong();
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

        private void btn_HoaDon_Click(object sender, EventArgs e)
        {
            this.Hide();
            HoaDon frm = new HoaDon();
            frm.ShowDialog();
            this.Close();
        }

        private void dgv_phieuxuat_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Chặn hành động sort
            dgv_phieuxuat.Columns[e.ColumnIndex].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void dgv_phieuxuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Tạo report ở đây
            if (dgv_phieuxuat.Columns[e.ColumnIndex].Name == "InPhieu")
            {
            }
            else
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                DataGridViewRow a = dgv_phieuxuat.Rows[e.RowIndex];
                XemPhieuXuat frm = new XemPhieuXuat(a.Cells["SoPX"].Value.ToString());
                frm.ShowDialog();
                Load_Data();
            }
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
