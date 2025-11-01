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
    public partial class ThemKhachHang : Form
    {
        string Value;
        bool TrangThai;
        public ThemKhachHang( string value, bool status)
        {
            InitializeComponent();
            Value = value;
            TrangThai = status;
            Load_data();
        }

        private void Load_data()
        {
            //MessageBox.Show(Value + " " + TrangThai);
            if (TrangThai)
            {
                SqlDataReader rd = Sql.Reader($"select * from KhachHang where SDT = '{Value}'");
                rd.Read();
                txt_makh.Text = rd["MaKH"].ToString();
                txt_hoten.Text = rd["HoTen"].ToString();
                string gt = rd["Phai"].ToString();
                if(gt == "Nữ") rb_nu.Checked = true; else rb_nam.Checked = true;
                txt_sdt.Text = rd["SDT"].ToString();
                dtp_ngaysinh.Value = Convert.ToDateTime(rd["NgaySinh"].ToString());
                txt_diachi.Text= rd["DiaChi"].ToString();
                txt_diachi.ReadOnly = true;
                btn_DangKy.Enabled = false;
                button1.Enabled = true;
                button2.Enabled = true;
                rd.Close();
            }
            else
            {
                txt_makh.Text = Convert.ToString(Sql.Scalar($"select dbo.uf_NextNumber('KH','KhachHang','KH')"));
                txt_diachi.ReadOnly = false;
                txt_sdt.Text = Value;
                btn_DangKy.Enabled = true;
                button1.Enabled = false;
                button2.Enabled = false;
            }
        }

        private void txt_hoten_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            { e.SuppressKeyPress = true; }
            else
                return;
        }

        private void txt_sdt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9 || e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            { return; }
            else
                e.SuppressKeyPress = true;
        }

        private void btn_DangKy_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txt_hoten.Text)||string.IsNullOrWhiteSpace(txt_hoten.Text))
            {
                MessageBox.Show("Bạn chưa nhập họ tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_hoten.Focus();
                return; 
            }
            if (string.IsNullOrEmpty(txt_sdt.Text) || string.IsNullOrWhiteSpace(txt_sdt.Text))
            {
                MessageBox.Show("Bạn chưa nhập họ tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_hoten.Focus();
                return;
            }
            string makh = txt_makh.Text;
            string hoten = txt_hoten.Text;
            string phai = rb_nam.Checked ? "Nam" : "Nữ";
            string ngaysinh = dtp_ngaysinh.Value.ToString("yyyy-MM-dd");
            string diachi = txt_diachi.Text;
            string sdt = txt_sdt.Text;
            string query = $"INSERT INTO KhachHang (MaKH, HoTen, Phai, SDT, NgaySinh, DiaChi) VALUES ('{makh}', N'{hoten}', N'{phai}', '{sdt}', '{ngaysinh}', N'{diachi}')";
            try
            {
                Sql.NonQuery(query);
                this.Close();
            }
            catch 
            {
                MessageBox.Show("Ngày sinh không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_dong_Click(object sender, EventArgs e)
        {
            var a = MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (a == DialogResult.OK)
                Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_hoten.Text) || string.IsNullOrWhiteSpace(txt_hoten.Text))
            {
                MessageBox.Show("Bạn chưa nhập họ tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_hoten.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txt_sdt.Text) || string.IsNullOrWhiteSpace(txt_sdt.Text))
            {
                MessageBox.Show("Bạn chưa nhập họ tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_hoten.Focus();
                return;
            }
            string makh = txt_makh.Text;
            string hoten = txt_hoten.Text;
            string phai = rb_nam.Checked ? "Nam" : "Nữ";
            string ngaysinh = dtp_ngaysinh.Value.ToString("yyyy-MM-dd");
            string diachi = txt_diachi.Text;
            string sdt = txt_sdt.Text;
            string query = $"Update KhachHang set HoTen=N'{hoten}', Phai=N'{phai}', SDT='{sdt}', NgaySinh='{ngaysinh}', DiaChi=N'{diachi}' where MaKH ='{makh}'";
                Sql.NonQuery(query);
                this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string makh = txt_makh.Text;
            string query = $"EXEC sp_XoaKhachHang @MaKH ='{makh}'";

                Sql.NonQuery(query);
                this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
