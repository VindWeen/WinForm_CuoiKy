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
    public partial class ChiNhanh : Form
    {
        public ChiNhanh()
        {
            InitializeComponent();
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

        private void ChiNhanh_Load(object sender, EventArgs e)
        {
            Load_Data();
            Them();
        }
        private void Load_Data()
        {
            dgv_chinhanh.Rows.Clear();
            string query = "Select * from ChiNhanh";
            SqlDataReader rd = Sql.Reader(query);
            while (rd.Read())
            {
                dgv_chinhanh.Rows.Add(rd["MaCN"].ToString(), rd["TenCN"].ToString(), rd["DiaChi"].ToString());
            }
            dgv_chinhanh.ClearSelection();
        }
        private void Them()
        {
            btn_them.Enabled = true;
            btn_xoa.Enabled = false;
            btn_sua.Enabled = false;
            txt_macn.ReadOnly = false;
            txt_macn.Clear();
            txt_tencn.Clear();
            txt_diachi.Clear();
        }
        private void SuaXoa()
        {
            btn_them.Enabled =false;
            btn_xoa.Enabled = true;
            btn_sua.Enabled = true;
            txt_macn.ReadOnly = true;
        }

        private void dgv_chinhanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_chinhanh.Rows[e.RowIndex].IsNewRow)
            {
                Them();
                return;
            }
            else
            {
                SuaXoa();
                DataGridViewRow a = dgv_chinhanh.Rows[e.RowIndex];
                txt_macn.Text = a.Cells["MaCN"].Value.ToString();
                txt_tencn.Text = a.Cells["TenCN"].Value.ToString();
                txt_diachi.Text = a.Cells["DiaChi"].Value.ToString();
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            string query = $"Update ChiNhanh set TenCN =N'{txt_tencn.Text}',DiaChi =N'{txt_diachi.Text}' where MaCN = '{txt_macn.Text}'";
            Sql.NonQuery(query);
            Load_Data();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            bool ktra = Sql.KiemTra($"if exists (select * from ChiNhanh where MaCN like '{txt_macn.Text}') select 1 else select 0");
            if (!ktra)
            {
                string query = $"insert into ChiNhanh values ('{txt_macn.Text}',N'{txt_tencn.Text}',N'{txt_diachi.Text}')";
                Sql.NonQuery(query);
                Load_Data();
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            var a = MessageBox.Show("Bạn có chắc muốn xóa chứ? Thao tác này sẽ xóa luôn những dữ liệu khác có thông tin liên quan đến chi nhánh này!", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (a == DialogResult.OK)
            {
                string query = $"EXEC sp_XoaChiNhanh_Cascade @MaCN = '{txt_macn.Text}'";
                Sql.NonQuery(query);
                Load_Data();
            }
            else
                return;
        }
    }
}
