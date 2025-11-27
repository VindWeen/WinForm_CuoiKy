using SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sql = SQL.SQL;

namespace CuoiKy
{
    public partial class SanPham : Form
    {
        string dau = CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator;

        string QuyenHan = TaiKhoan.QuyenHan;
        string MaCN = TaiKhoan.MaCN;
        public SanPham()
        {
            InitializeComponent();
        }

        private void SanPham_Load(object sender, EventArgs e)
        {
            Load_Data();
            lbl_TongSP.Text = dgv_sanpham.Rows.Count.ToString(); int tong = 0;
            foreach (DataGridViewRow row in dgv_sanpham.Rows)
            {
                if (row.Cells["SL"].Value != null)
                {
                    int sl;
                    if (int.TryParse(row.Cells["SL"].Value.ToString().Replace(dau, ""), out sl))
                        tong += sl;
                }
            }
            lbl_TongSoLuong.Text = tong.ToString("N0");
            btn_themsp.Visible = QuyenHan=="Admin"? true:false;
        }
        private void Load_Data()
        {
            dgv_sanpham.Rows.Clear();
            string filter_sl = "", filter_tt = "";
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
            switch (cb_filterTT.Text)
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
            string query = $@"";
            if (QuyenHan != "Admin")
            {
                query += $"select * from dbo.uf_SanPham_Kho ('{MaCN}') where 1=1";
            }
            else
                query += $"select * from dbo.v_SanPham_Kho where 1=1";
            // 🔸 Lọc theo model
            if (!string.IsNullOrWhiteSpace(txt_masp.Text))
            {
                txt_tensp.Clear();
                query += $" and Model like N'%{txt_masp.Text.Trim()}%'";
            }

            // 🔸 Lọc theo tên sản phẩm
            if (!string.IsNullOrWhiteSpace(txt_tensp.Text))
            {
                query += $" and TenSP like N'%{txt_tensp.Text.Trim()}%'";
            }
            // 🔸 Lọc theo giá
            if (!string.IsNullOrWhiteSpace(txt_SL.Text) && txt_SL.Text != "*")
            {
                query += $" and Gia {filter_sl} {txt_SL.Text}";
            }

            // 🔸 Lọc theo tổng tồn
            if (!string.IsNullOrWhiteSpace(txt_TT.Text))
            {
                // Có thể dùng khoảng hoặc chính xác
                query += $" and TongSL {filter_tt} {txt_TT.Text}";
            }
            SqlDataReader rd = Sql.Reader(query);
            int sum = 0;
            while (rd.Read())
            {
                dgv_sanpham.Rows.Add(rd["Model"].ToString(), rd["TenSP"].ToString(), Convert.ToInt32(rd["DonGia"]).ToString("N0"), rd["TongSL"].ToString());
                sum += Convert.ToInt32(rd["TongSL"]);
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

        private void txt_masp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Load_Data();
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

        private void txt_TT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9 || e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                return;
            else if (e.KeyCode == Keys.Enter)
            {
                Load_Data();
                if (string.IsNullOrEmpty(txt_TT.Text))
                {
                    txt_TT.Enabled = false;
                    cb_filterTT.SelectedIndex = 0;
                }
            }
            else
                e.SuppressKeyPress = true;
        }

        private void cb_filterTT_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cb_filterTT.SelectedIndex)
            {
                case 0:
                    txt_SL.Clear();
                    txt_TT.Enabled = false;
                    Load_Data(); break;
                default:
                    txt_TT.Enabled = true;
                    break;
            }
        }

        private void txt_tensp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Load_Data();
            }
        }

        private void dgv_sanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_sanpham.Columns[e.ColumnIndex].Name == "XemTon")
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;
                DataGridViewRow a = dgv_sanpham.Rows[e.RowIndex];
                Kho frm = new Kho(a.Cells["Model"].Value.ToString());
                frm.ShowDialog();
            }
            else
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0&&QuyenHan!="Admin")
                    return;

                DataGridViewRow a = dgv_sanpham.Rows[e.RowIndex];
                Load_Data();
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

        private void btn_BanHang_Click(object sender, EventArgs e)
        {
            this.Hide();
            BanHang frm = new BanHang();
            frm.ShowDialog();
            this.Close();
        }

        private void btn_themsp_Click(object sender, EventArgs e)
        {
            ThemSanPham frm = new ThemSanPham();
            frm.FormClosed += (s, argr) =>
            {
                Load_Data();
            };
            frm.ShowDialog();
        }
    }
}
