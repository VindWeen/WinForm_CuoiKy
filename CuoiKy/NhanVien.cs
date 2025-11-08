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
    public partial class NhanVien : Form
    {
        public NhanVien()
        {
            InitializeComponent();
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            Load_Data();
            Them();
        }
        private void Load_Data()
        {
            string query = $@"select MaNV,HoTenNV,Phai,NgaySinh,SDT,ChucVu,TenCN from NhanVien join ChiNhanh on NhanVien.MaCN=ChiNhanh.MaCN";
            SqlDataReader rd = Sql.Reader(query);
            while(rd.Read())
            {
                dgv_nhanvien.Rows.Add(rd["MaNV"].ToString(), rd["HoTenNV"].ToString(), rd["Phai"].ToString(), Convert.ToDateTime(rd["NgaySinh"]).ToString("dd-MM-yyyy"), rd["SDT"].ToString(), rd["ChucVu"].ToString(), rd["TenCN"].ToString());
            }
            query = "select * from ChiNhanh";
            cb_chinhanh.DataSource = Sql.getData(query);
            cb_chinhanh.DisplayMember = "TenCN";
            cb_chinhanh.ValueMember = "MaCN";
            dgv_nhanvien.ClearSelection(); 
        }
        private void SuaXoa()
        {
            btn_sua.Enabled = true;
            btn_xoa.Enabled = true;
            btn_them.Enabled = false;
            txt_manv.ReadOnly = true;
        }
        private void Them()
        {
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
            btn_them.Enabled = true;
            txt_manv.ReadOnly = false;
            txt_manv.Clear();
            txt_hoten.Clear();
            txt_sdt.Clear();
        }

        private void dgv_nhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_nhanvien.Rows[e.RowIndex].IsNewRow) {
                Them();
                return;
            }
            else
            {
                SuaXoa();
                DataGridViewRow a = dgv_nhanvien.Rows[e.RowIndex];
                txt_manv.Text = a.Cells["MaNV"].Value.ToString();
                txt_hoten.Text = a.Cells["HoTenNV"].Value.ToString();
                switch(a.Cells["GioiTinh"].Value.ToString()) {
                    case "Nam":
                        rd_nam.Checked = true; break;
                    case "Nữ":
                        rd_nu.Checked = true; break;
                }
                dtp_ngaysinh.Value = Convert.ToDateTime(a.Cells["NgaySinh"].Value);
                txt_sdt.Text = a.Cells["SDT"].Value.ToString();
                cb_chucvu.SelectedItem = a.Cells["ChucVu"].Value.ToString();
                cb_chinhanh.SelectedIndex = cb_chinhanh.FindStringExact(a.Cells["ChiNhanh"].Value.ToString());
            }


        }

        private void txt_sdt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9 || e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                return;
            else
                e.SuppressKeyPress = true;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if(Sql.KiemTra($@"if exists (select * from NhanVien where MaNV like '{txt_manv.Text}') select 1 else select 0"))
            {
                MessageBox.Show("Mã nhân viên đã tồn tại", "Cảnh báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txt_manv.Focus();
                return;
            }
            string MaNV = txt_manv.Text;
            string HoTen = txt_hoten.Text;
            string GioiTinh = rd_nam.Checked ? "Nam" : "Nữ";
            if(dtp_ngaysinh.Value.Year>= DateTime.Now.Year)
            {
                MessageBox.Show("Ngày sinh không hợp lệ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtp_ngaysinh.Focus();
                return;
            }
            string NgaySinh = dtp_ngaysinh.Value.ToString("yyyy-MM-dd");
            string SDT = txt_sdt.Text;
            string ChucVu = cb_chucvu.Text;
            string ChiNhanh = cb_chinhanh.SelectedValue.ToString();
            string query = $@"insert into NhanVien values ('{MaNV}',N'{HoTen}',N'{GioiTinh}','{NgaySinh}','{SDT}',N'{ChucVu}','{ChiNhanh}')";
            Sql.NonQuery(query);
            Them();
            NhanVien_Load(sender,e);
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            string MaNV = txt_manv.Text;
            string HoTen = txt_hoten.Text;
            string GioiTinh = rd_nam.Checked ? "Nam" : "Nữ";
            if (dtp_ngaysinh.Value.Year >= DateTime.Now.Year)
            {
                MessageBox.Show("Ngày sinh không hợp lệ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtp_ngaysinh.Focus();
                return;
            }
            string NgaySinh = dtp_ngaysinh.Value.ToString("yyyy-MM-dd");
            string SDT = txt_sdt.Text;
            string ChucVu = cb_chucvu.Text;
            string ChiNhanh = cb_chinhanh.SelectedValue.ToString();
            string query = $@"update NhanVien set HoTenNV = N'{HoTen}',Phai = N'{GioiTinh}',NgaySinh = '{NgaySinh}',SDT = '{SDT}',ChucVu = N'{ChucVu}',MaCN = '{ChiNhanh}' where MaNV ='{txt_manv.Text}'";
            Sql.NonQuery(query);
            Them();
            NhanVien_Load(sender, e);


        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            var a = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này chứ? Thao tác này sẽ khiến các hóa đơn liên quan tới nhân viên này bị hủy theo!", "Cảnh báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            if (a == DialogResult.OK)
            {
                string MaNV = txt_manv.Text;
                string query = $@"Exec dbo.sp_XoaNhanVien '{MaNV}'";
                Sql.NonQuery(query);
                NhanVien_Load(sender, e);

            }
            else
                return;
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
    }
}
