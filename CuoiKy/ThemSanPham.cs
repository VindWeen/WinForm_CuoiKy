using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sql = SQL.SQL;

namespace CuoiKy
{
    public partial class ThemSanPham : Form
    {
        string dau = Convert.ToString(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
        public ThemSanPham()
        {
            InitializeComponent();
        }

        private void ThemSanPham_Load(object sender, EventArgs e)
        {
            Load_Data();
        }
        private void Load_Data()
        {
            txt_masp.Text = Convert.ToString(Sql.Scalar("SELECT  dbo.uf_TaoMaSP()"));
        }
        private void txt_nhantien_TextChanged(object sender, EventArgs e)
        {
            if (txt_nhantien.Text == "") return;

            // Lưu vị trí con trỏ hiện tại
            int selectionStart = txt_nhantien.SelectionStart;

            // Bỏ dấu phẩy cũ đi
            string cleanText = txt_nhantien.Text.Replace(dau, "");

            // Kiểm tra xem có phải số không
            if (decimal.TryParse(cleanText, out decimal value))
            {
                // Format lại: N0 = format kiểu số nguyên có dấu phẩy ngăn cách
                txt_nhantien.Text = string.Format("{0:N0}", value);

                // Đưa con trỏ về cuối chuỗi
                txt_nhantien.SelectionStart = txt_nhantien.Text.Length;
            }
        }

        private void txt_nhantien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9 || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                return;
            }
            else
                e.SuppressKeyPress = true;
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9 || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                return;
            }
            else
                e.SuppressKeyPress = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (txt_sl.Text == "") return;

            // Lưu vị trí con trỏ hiện tại
            int selectionStart = txt_sl.SelectionStart;

            // Bỏ dấu phẩy cũ đi
            string cleanText = txt_sl.Text.Replace(dau, "");

            // Kiểm tra xem có phải số không
            if (decimal.TryParse(cleanText, out decimal value))
            {
                // Format lại: N0 = format kiểu số nguyên có dấu phẩy ngăn cách
                txt_sl.Text = string.Format("{0:N0}", value);

                // Đưa con trỏ về cuối chuỗi
                txt_sl.SelectionStart = txt_sl.Text.Length;
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txt_tensp.Text)) { MessageBox.Show("Chưa nhập tên sản phẩm", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if(string.IsNullOrEmpty(txt_nhantien.Text)) { MessageBox.Show("Chưa nhập giá sản phẩm", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if(string.IsNullOrEmpty(txt_dvt.Text)) { MessageBox.Show("Chưa nhập đơn vị tính sản phẩm", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if(string.IsNullOrEmpty(txt_sl.Text)) { MessageBox.Show("Chưa nhập số lượng sản phẩm để xuất", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            
            string MaSP = txt_masp.Text;
            string TenSP = txt_tensp.Text;
            int DonGia = Convert.ToInt32(txt_nhantien.Text.Replace(dau, ""));
            string DVT = txt_dvt.Text;
            
            int SL = Convert.ToInt32(txt_sl.Text.Replace(dau, ""));
            string query = $@"insert into SanPham values ('{MaSP}',N'{TenSP}',{DonGia},N'{DVT}')";
            Sql.NonQuery(query);
            query = $"INSERT INTO KHO VALUES ('{TaiKhoan.MaCN}','{MaSP}',{SL})";
            Sql.NonQuery(query);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
