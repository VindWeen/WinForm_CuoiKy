﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sql = SQL.SQL;

namespace CuoiKy
{
    public partial class BanHang : Form
    {
        public string MaCN; 
        bool isLoaded = false; bool isLoadingSP = false;
        public BanHang(string maCN)
        {
            InitializeComponent();
            MaCN = maCN;
        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BanHang_Load(object sender, EventArgs e)
        {

            Load_combobox_sanpham();
            Load_combobox_nhanvien();
            Load_combobox_khachhang();
            isLoaded = true;
            button1.Enabled = false;
        }

        private void Load_combobox_sanpham()
        {
            cb_sanpham.DataSource = null;
            cb_sanpham.DataSource = Sql.getData($"select* from dbo.uf_SanPham('{MaCN}')");
            cb_sanpham.DisplayMember = "TenSP";
            cb_sanpham.ValueMember = "MaSP";
            cb_sanpham.Text = null;
            cb_sanpham.SelectedIndex = -1;
        }
        private void Load_combobox_nhanvien()
        {
            cb_nhanvien.DataSource = null;
            cb_nhanvien.DataSource = Sql.getData($"select MaCN,(MaNV+' - '+HoTenNV) as 'key' from NhanVien where MaCN like '{MaCN}'");
            cb_nhanvien.DisplayMember = "key";
            cb_nhanvien.ValueMember = "key";
            cb_nhanvien.Text = null;
            cb_nhanvien.SelectedIndex = -1;
        }

        private void Load_combobox_khachhang()
        {
            try
            {
                cb_khachhang.DataSource = null;
                cb_khachhang.DataSource = Sql.getData(@"select HoTenKhachHang+' - '+ SDT as HienThi from vKhachHang");
                cb_khachhang.DisplayMember = "HienThi";
                cb_khachhang.ValueMember = "HienThi";
                cb_khachhang.Text = null;
                cb_khachhang.SelectedIndex = -1;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Update_SL()
        {
            int sl = 0;
            foreach (DataGridViewRow a in dgv_sanpham.Rows)
            {
                sl += Convert.ToInt32(a.Cells["SL"].Value);
            }
            lbl_SoLuong.Text = sl.ToString("N0");
        }
        private void Update_ThanhTien()
        {
            int total = 0;
            foreach (DataGridViewRow a in dgv_sanpham.Rows)
            {
                //MessageBox.Show(a.Cells["DonGia"].Value.ToString().Replace(".", "")+" "+ Convert.ToInt32(a.Cells["SL"].Value).ToString());
                total += Convert.ToInt32(a.Cells["DonGia"].Value.ToString().Replace(".", ""))* Convert.ToInt32(a.Cells["SL"].Value);
            }
            lbl_thanhtien.Text = total.ToString("N0");
        }
        private void txt_nhantien_TextChanged(object sender, EventArgs e)
        {
            if (txt_nhantien.Text == "") return;

            // Lưu vị trí con trỏ hiện tại
            int selectionStart = txt_nhantien.SelectionStart;

            // Bỏ dấu phẩy cũ đi
            string cleanText = txt_nhantien.Text.Replace(".", "");

            // Kiểm tra xem có phải số không
            if (decimal.TryParse(cleanText, out decimal value))
            {
                // Format lại: N0 = format kiểu số nguyên có dấu phẩy ngăn cách
                txt_nhantien.Text = string.Format("{0:N0}", value);

                // Đưa con trỏ về cuối chuỗi
                txt_nhantien.SelectionStart = txt_nhantien.Text.Length;
            }
        }

        private void cb_sanpham_TextUpdate(object sender, EventArgs e)
        {
            string text = cb_sanpham.Text.Trim();

            if (text.Length < 2&&cb_sanpham.Items.Count<1) {
                Load_combobox_sanpham();
                return; // chỉ bắt đầu tìm khi nhập >= 2 ký tự
                }

            // Lấy dữ liệu gợi ý theo ký tự đang nhập
            DataTable dt = Sql.getData($"SELECT MaSP, TenSP FROM dbo.uf_SanPham('{MaCN}') WHERE TenSP LIKE N'%{text}%'");

            // Lưu lại text hiện tại
            string currentText = cb_sanpham.Text;
            int selStart = cb_sanpham.SelectionStart;

            // Tạm tắt datasource để cập nhật
            isLoadingSP = true;
            cb_sanpham.BeginUpdate();
            cb_sanpham.DataSource = null;
            cb_sanpham.Items.Clear();

            // Gán dữ liệu mới
            cb_sanpham.DataSource = dt;
            cb_sanpham.DisplayMember = "TenSP";
            cb_sanpham.ValueMember = "MaSP";

            // Giữ lại text người dùng đang gõ
            cb_sanpham.DroppedDown = true;
            cb_sanpham.Text = currentText;
            cb_sanpham.SelectionStart = selStart;
            cb_sanpham.EndUpdate();

            // Đặt lại con trỏ chuột
            Cursor.Current = Cursors.Default; 
            if (cb_sanpham.Text.Length > 2 && cb_sanpham.Items.Count == 0)
            {
                cb_sanpham.DataSource = null;
                cb_sanpham.Text = currentText;
                cb_sanpham.SelectionStart = selStart;
                cb_sanpham.EndUpdate();
                cb_sanpham.Items.Add(cb_sanpham.Text);
            }
            isLoadingSP = false;
        }

        private void cb_nhanvien_TextUpdate(object sender, EventArgs e)
        {
            string text = cb_nhanvien.Text.Trim();


            if (text.Length < 2&&cb_nhanvien.Items.Count < 1)
            {
                Load_combobox_nhanvien();
                return; // chỉ bắt đầu tìm khi nhập >= 2 ký tự
            }

            // Lấy dữ liệu gợi ý theo ký tự đang nhập
            DataTable dt = Sql.getData($"select MaCN,(MaNV+' - '+HoTenNV) as 'key' from NhanVien where MaCN like '{MaCN}' and (MaNV+' - '+HoTenNV) like N'%{text}%'");

            // Lưu lại text hiện tại
            string currentText = cb_nhanvien.Text;
            int selStart = cb_nhanvien.SelectionStart;

            // Tạm tắt datasource để cập nhật
            cb_nhanvien.BeginUpdate();
            cb_nhanvien.DataSource = null;
            cb_nhanvien.Items.Clear();

            // Gán dữ liệu mới
            cb_nhanvien.DataSource = dt;
            cb_nhanvien.DisplayMember = "key";
            cb_nhanvien.ValueMember = "key";

            // Giữ lại text người dùng đang gõ
            cb_nhanvien.DroppedDown = true;
            cb_nhanvien.Text = currentText;
            cb_nhanvien.SelectionStart = selStart;
            cb_nhanvien.EndUpdate();

            // Đặt lại con trỏ chuột
            Cursor.Current = Cursors.Default; 
            if (cb_nhanvien.Text.Length > 2 && cb_nhanvien.Items.Count == 0)
            {
                cb_nhanvien.DataSource = null;
                cb_nhanvien.Text = currentText;
                cb_nhanvien.SelectionStart = selStart;
                cb_nhanvien.EndUpdate();
                cb_nhanvien.Items.Add(cb_nhanvien.Text);
            }
        }

        private void cb_nhanvien_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cb_sanpham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoaded || isLoadingSP) return;
            if (cb_sanpham.SelectedIndex < 0 || cb_sanpham.SelectedValue == null)
                return; // bỏ qua nếu chưa chọn item hợp lệ
            string query_sp = $@"if exists (select * from SanPham where TenSP like N'%{cb_sanpham.Text}%')
                                        select 1
                                     else
                                        select 0";
            if (!Sql.KiemTra(query_sp))
                return;
            string TenSP = cb_sanpham.Text;
            string DonGia = string.Format("{0:N0}", Sql.Scalar($"SELECT DonGia FROM SanPham WHERE TenSP like N'%{cb_sanpham.Text}%'"));

            bool found = false;
            foreach (DataGridViewRow row in dgv_sanpham.Rows)
            {
                if (row.Cells["TenSP"].Value.ToString() == TenSP)
                {
                    int sl = Convert.ToInt32(row.Cells["SL"].Value);
                    row.Cells["SL"].Value = sl + 1;
                    found = true;
                    break;
                }
            }
            if (!found)
                dgv_sanpham.Rows.Add(TenSP, DonGia, 1);

            cb_sanpham.Text = null;
            cb_sanpham.SelectedIndex = -1;
            Update_SL();
            Update_ThanhTien();
        }

        private void cb_sanpham_Click(object sender, EventArgs e)
        {
        }

        private void dgv_sanpham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lấy hàng hiện tại
            DataGridViewRow row = dgv_sanpham.Rows[e.RowIndex];

            if (dgv_sanpham.Columns[e.ColumnIndex].Name == "Up")
            {
                int soLuong = Convert.ToInt32(row.Cells["SL"].Value);
                row.Cells["SL"].Value = ++soLuong;
            }
            else if (dgv_sanpham.Columns[e.ColumnIndex].Name == "Down")
            {
                int soLuong = Convert.ToInt32(row.Cells["SL"].Value);
                if (soLuong > 1)
                    row.Cells["SL"].Value = --soLuong;
            }
            else if (dgv_sanpham.Columns[e.ColumnIndex].Name == "Delete")
            {
                dgv_sanpham.Rows.RemoveAt(e.RowIndex);
            }
            Update_SL();
            Update_ThanhTien();
        }

        private void cb_khachhang_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9 || e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                { return; }
            else
                e.SuppressKeyPress = true;
        }

        private void cb_khachhang_TextUpdate(object sender, EventArgs e)
        {
            string text = cb_khachhang.Text.Trim();

            if (text.Length < 2 && cb_khachhang.Items.Count < 1)
            {
                Load_combobox_khachhang();
                return; // chỉ bắt đầu tìm khi nhập >= 2 ký tự
            }

            // Lấy dữ liệu gợi ý theo ký tự đang nhập
            DataTable dt = Sql.getData($"Select HoTenKhachHang+' - '+ SDT as HienThi from vKhachHang WHERE SDT LIKE N'%{text}%'");

            // Lưu lại text hiện tại
            string currentText = cb_khachhang.Text;
            int selStart = cb_khachhang.SelectionStart;

            // Tạm tắt datasource để cập nhật
            cb_khachhang.BeginUpdate();
            cb_khachhang.DataSource = null;
            cb_khachhang.Items.Clear();

            // Gán dữ liệu mới
            cb_khachhang.DataSource = dt;
            cb_khachhang.DisplayMember = "HienThi";
            cb_khachhang.ValueMember = "HienThi";

            // Giữ lại text người dùng đang gõ
            cb_khachhang.DroppedDown = true;
            cb_khachhang.Text = currentText;
            cb_khachhang.SelectionStart = selStart;
            cb_khachhang.EndUpdate();

            // Đặt lại con trỏ chuột
            Cursor.Current = Cursors.Default;
            if(cb_khachhang.Text.Length>2&&cb_khachhang.Items.Count==0)
            {
                cb_khachhang.DataSource = null;
                cb_khachhang.Text = currentText;
                cb_khachhang.SelectionStart = selStart;
                cb_khachhang.EndUpdate();
                cb_khachhang.Items.Add(cb_khachhang.Text);
                btn_ThemKhachHang.Enabled = true;
                button1.Enabled = false;
            }
            else
            {
                btn_ThemKhachHang.Enabled=false;
                button1.Enabled = false;
            }
        }

        private void btn_ThemKhachHang_Click(object sender, EventArgs e)
        {
            ThemKhachHang frm = new ThemKhachHang(cb_khachhang.Text, false);
            frm.ShowDialog();
            cb_khachhang.Text = null;
            Load_combobox_khachhang();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            var a = MessageBox.Show("Bạn có chắc muốn đăng xuất chứ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (a == DialogResult.OK)
            {
                Login frm = new Login();
                frm.ShowDialog();
                this.Dispose();
            }
        }

        private void BanHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            var a = MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (a == DialogResult.Cancel)
                e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] a = cb_khachhang.Text.Replace(" ","").Split('-');
            MessageBox.Show(a[1].Replace(" ", ""));
            cb_khachhang.Text = null;
            Load_combobox_khachhang();
            ThemKhachHang frm = new ThemKhachHang(a[1].Replace(" ", ""), true);
            frm.ShowDialog();
        }

        private void txt_nhantien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode>=Keys.D0&&e.KeyCode<=Keys.D9||e.KeyCode>=Keys.NumPad0&&e.KeyCode<=Keys.NumPad9||e.KeyCode==Keys.Delete||e.KeyCode==Keys.Back)
            {
                return;
            }
            else if(e.KeyCode == Keys.Enter)
            {
                int tongtien = Convert.ToInt32(lbl_thanhtien.Text.Replace(".", ""));
                int sotiennhan = Convert.ToInt32(txt_nhantien.Text.Replace(".", ""));
                if (sotiennhan >= tongtien)
                    lbl_TienThoi.Text = (sotiennhan - tongtien).ToString("N0");
                else
                    MessageBox.Show("Số tiền nhận phải lớn hơn thành tiền");
            }
            else
                e.SuppressKeyPress = true;
        }

        private void cb_khachhang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_khachhang.SelectedIndex >= 0)
            {
                button1.Enabled = true;
                btn_ThemKhachHang.Enabled = false;
            }
        }

        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            string[] kh = cb_khachhang.Text.Replace(" ", "").Split('-');
            string query_ktraKH = $@"if exists (select * from KhachHang where SDT like'{kh[kh.Length-1]}')
                                        select 1
                                     else
                                        select 0";
            string[] nv = cb_nhanvien.Text.Replace(" ", "").Split('-');
            string query_ktraNV = $@"if exists (select * from NhanVien where MaNV like'{nv[0]}' or HoTenNV like N'{nv[0]}')
                                        select 1
                                     else
                                        select 0";
            string query_ktraSP = $@"if exists (select * from SanPham where TenSP like'{cb_sanpham.Text}')
                                        select 1
                                     else
                                        select 0";
            if (!Sql.KiemTra(query_ktraKH)&&cb_khachhang.SelectedIndex<0)
            {
                MessageBox.Show("Khách hàng không hợp lệ","Cảnh báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (!Sql.KiemTra(query_ktraNV)&& cb_nhanvien.SelectedIndex<0)
            {
                MessageBox.Show("Nhân viên không hợp lệ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            string SoHD = Convert.ToString(Sql.Scalar($@"SELECT dbo.uf_NextNumber ('{MaCN}','HoaDon','SoHD')"));
            string MaKH = Convert.ToString(Sql.Scalar($@"Select MaKH from KhachHang where SDT like '{kh[kh.Length - 1]}'"));

            Sql.NonQuery($@"INSERT INTO HoaDon Values ('{SoHD}','{nv[0]}','{MaKH}','{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}')");
            string query_cthd;
            foreach (DataGridViewRow a in dgv_sanpham.Rows) 
            {
                string masp = Convert.ToString(Sql.Scalar($@"Select MaSP from SanPham where TenSP like N'%{a.Cells["TenSP"].Value}%'"));
                int sl = Convert.ToInt32(a.Cells["SL"].Value);
                int thanhtien = sl * Convert.ToInt32(a.Cells["DonGia"].Value.ToString().Replace(".",""));
                query_cthd = $@"insert into CTHD values ('{SoHD}','{masp}',{sl},{thanhtien})"; 
                Sql.NonQuery(query_cthd);
            }
            dgv_sanpham.Rows.Clear();
            cb_khachhang.Text = null;
            cb_nhanvien.Text = null;
            btn_ThemKhachHang.Enabled = false;
            button1.Enabled = false;
            lbl_SoLuong.Text = "0";
            lbl_thanhtien.Text = "0";
            lbl_TienThoi.Text = "0";
            txt_nhantien.Clear();
        }

        private void btn_HoaDon_Click(object sender, EventArgs e)
        {
            this.Hide();
            HoaDon frm = new HoaDon(MaCN);
            frm.ShowDialog();
            this.Close();
        }
    }
}
