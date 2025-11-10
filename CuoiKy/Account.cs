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
    public partial class Account : Form
    {
        public Account()
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

        private void Account_Load(object sender, EventArgs e)
        {
            Load_Data();
            Them();
        }
        private void Them()
        {
            btn_them.Enabled = true;
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
            txt_password.ReadOnly = false;
            txt_username.Clear();
            txt_password.Clear();
            cb_nhanvien.SelectedIndex = 0;
            cb_quyenhan.SelectedIndex = 0;
            txt_username.ReadOnly = false;
            cb_nhanvien.Enabled = true;
        }
        private void SuaXoa()
        {
            btn_them.Enabled = false;
            btn_sua.Enabled = true;
            btn_xoa.Enabled = true;
            txt_username.ReadOnly = true;
            cb_nhanvien.Enabled = false;
        }
        private void Load_Data()
        {
            string query = "select MaNV,TenNV from NhanVien";
            cb_nhanvien.DataSource = Sql.getData(query);
            cb_nhanvien.ValueMember = "MaNV";
            cb_nhanvien.DisplayMember = "TenNV";
            query = "select HoTenNV,TenDN,QuyenHan,case TrangThai when 1 then N'Kích hoạt' when 0 then 'Khóa' end as TrangThai from TaiKhoan join NhanVien on TaiKhoan.MaNV = NhanVien.MaNV where QuyenHan != 'Admin'";
            SqlDataReader rd = Sql.Reader(query);
            while (rd.Read())
            {
                dgv_taikhoan.Rows.Add(rd["HoTenNV"].ToString(), rd["TenDN"].ToString(), rd["QuyenHan"].ToString(), rd["TrangThai"].ToString());
            }
        }

        private void dgv_taikhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_taikhoan.Rows[e.RowIndex].IsNewRow)
            {
                Them();
                return;
            }
            else
            {
                SuaXoa();
                DataGridViewRow a = dgv_taikhoan.Rows[e.RowIndex];
                cb_nhanvien.SelectedIndex = cb_nhanvien.FindStringExact(a.Cells["NhanVien"].Value.ToString());
                txt_username.Text = a.Cells["Username"].Value.ToString();
                cb_quyenhan.SelectedValue = a.Cells["QuyenHan"].Value.ToString();
                switch (a.Cells["TrangThai"].Value.ToString())
                {
                    case "Khoá":
                        rd_khoa.Checked = true; break;
                    case "Kích hoạt":
                        rd_kichhoat.Checked = true; break;
                }
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            string TenDN = txt_username.Text;
            string MatKhau = $"EncryptByPassPhrase('MaHoaMatKhau',N'{txt_password.Text}')";
            string MaNV = cb_nhanvien.SelectedValue.ToString();
            string QuyenHan = cb_quyenhan.SelectedValue.ToString();
            int TrangThai = rd_khoa.Checked ? 0 : 1;
            string NgayTao = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string query = $"Insert into TaiKhoa values ('{TenDN}',{MatKhau},'{MaNV}',N'{QuyenHan}',{TrangThai},'{NgayTao}')";
            Sql.NonQuery(query);
            Load_Data();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            string TenDN = txt_username.Text;
            string MatKhau = $"EncryptByPassPhrase('MaHoaMatKhau',N'{txt_password.Text}')";
            string MaNV = cb_nhanvien.SelectedValue.ToString();
            string QuyenHan = cb_quyenhan.SelectedValue.ToString();
            int TrangThai = rd_khoa.Checked ? 0 : 1;
            string NgayTao = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string query = $"Update TaiKhoa set MatKhau = {MatKhau}, QuyenHan = N'{QuyenHan}',TrangThai = {TrangThai} where TenDN";
            Sql.NonQuery(query);
            Load_Data();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string TenDN = txt_username.Text; string MaNV = cb_nhanvien.SelectedValue.ToString();
            string query = $"Delete from TaiKhoa where TenDN like '{TenDN}' and MaNV like '{MaNV}'";
            Sql.NonQuery(query);
        }

        private void dgv_taikhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
