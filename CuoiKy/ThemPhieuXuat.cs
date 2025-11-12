using SQL;
using System;
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
    public partial class ThemPhieuXuat : Form
    {
        string MaCN; bool isLoaded = false; bool isLoadingSP = false;
        DateTime lastKeyPress = DateTime.Now;
        StringBuilder barcodeBuffer = new StringBuilder(); bool isScanning = false;
        public ThemPhieuXuat(string maCN)
        {
            InitializeComponent();
            MaCN = maCN;
        }

        private void ThemPhieuXuat_Load(object sender, EventArgs e)
        {
            Load_Data();
            Load_combobox_sanpham();
            isLoaded = true; 
            this.KeyPreview = true;
            this.KeyPress += BanHang_KeyPress;
            this.KeyDown += BanHang_KeyDown; cb_sanpham.AutoCompleteMode = AutoCompleteMode.None;
            cb_sanpham.AutoCompleteSource = AutoCompleteSource.None;
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
        private void Load_Data()
        {
            txt_sopx.Text = Convert.ToString(Sql.Scalar($@"select dbo.uf_NextNumber('PX','PhieuXuat','SoPX');"));
            cb_chinhanh.DataSource = Sql.getData("select MaCN,TenCN from ChiNhanh");
            cb_chinhanh.DisplayMember = "TenCN";
            cb_chinhanh.ValueMember = "MaCN";
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCTPX.Columns[e.ColumnIndex].Name == "MaSP")
            {
                string maSP = dgvCTPX.Rows[e.RowIndex].Cells["MaSP"].Value?.ToString();
                if (string.IsNullOrEmpty(maSP)) return;

                string tenSP = Convert.ToString(Sql.Scalar($@"select TenSP from SanPham where MaSP like '{maSP}'"));
                if (string.IsNullOrEmpty(tenSP))
                {
                    dgvCTPX.Rows[e.RowIndex].Cells["MaSP"].Value = null;
                    dgvCTPX.Rows[e.RowIndex].Cells["TenSP"].Value = null;
                    return;
                }

                foreach (DataGridViewRow row in dgvCTPX.Rows)
                {
                    if (row.Index != e.RowIndex && row.Cells["MaSP"].Value?.ToString() == maSP)
                    {
                        int slCu = Convert.ToInt32(row.Cells["SL"].Value ?? 0);
                        row.Cells["SL"].Value = slCu + 1;

                        dgvCTPX.Rows.RemoveAt(e.RowIndex);
                        return;
                    }
                }

                dgvCTPX.Rows[e.RowIndex].Cells["TenSP"].Value = tenSP;
                if (dgvCTPX.Rows[e.RowIndex].Cells["SL"].Value == null)
                    dgvCTPX.Rows[e.RowIndex].Cells["SL"].Value = 1;
            }
        }
        ComboBox cbSP;
        private void dgvCTPX_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvCTPX.CurrentCell.OwningColumn.Name == "SL" && e.Control is TextBox tb)
            {
                tb.KeyPress -= Tb_KeyPress; 
                tb.KeyPress += Tb_KeyPress;
            }
            if (dgvCTPX.CurrentCell.OwningColumn.Name == "MaSP" && e.Control is ComboBox cb)
            {
                cb.DropDownHeight = 200;
                cb.DropDownWidth = 250; 
                cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cb.AutoCompleteSource = AutoCompleteSource.ListItems;
                cb.SelectedIndexChanged -= CbSP_SelectedIndexChanged;

                cb.SelectedIndexChanged += CbSP_SelectedIndexChanged;

                cbSP = cb; 
            }
        }
        private void CbSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSP.SelectedValue == null) return;

            int rowIndex = dgvCTPX.CurrentCell.RowIndex;
            string maSP = cbSP.SelectedValue.ToString();

            // Lấy thông tin sản phẩm tương ứng
            DataRow rowSP = Sql.getData($"SELECT MaSP, TenSP FROM SanPham").AsEnumerable()
                .FirstOrDefault(r => r["MaSP"].ToString() == maSP);

            if (rowSP != null)
            {
                dgvCTPX.Rows[rowIndex].Cells["TenSP"].Value = rowSP["TenSP"].ToString();

                // Nếu SL đang null thì gán mặc định 1
                var cellSL = dgvCTPX.Rows[rowIndex].Cells["SL"];
                if (cellSL.Value == null || string.IsNullOrWhiteSpace(cellSL.Value.ToString()))
                    cellSL.Value = 1;
            }
            else
            {
                MessageBox.Show("Sản phẩm không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvCTPX.Rows[rowIndex].Cells["MaSP"].Value = null;
            }
        }
        private void Tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho nhập số và phím điều khiển
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void dgvCTPX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex ==3)
            {
                dgvCTPX.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void btn_taophieu_Click(object sender, EventArgs e)
        {
            string query = $@"insert into PhieuXuat values ('{txt_sopx.Text}','{MaCN}','{cb_chinhanh.SelectedValue.ToString()}','{DateTime.Now:yyyy-MM-dd HH:mm:ss}')";
            Sql.NonQuery(query);
            foreach (DataGridViewRow a in dgvCTPX.Rows)
            {
                query = $@"EXEC dbo.sp_ThemCTPX '{txt_sopx.Text}','{a.Cells["MaSP"].Value}','{Convert.ToInt32(a.Cells["SL"].Value)}'";
                Sql.NonQuery(query);
            }
            this.Close();
        }

        private void cb_sanpham_TextUpdate(object sender, EventArgs e)
        {
            string text = cb_sanpham.Text.Trim();

            if (text.Length < 2 && cb_sanpham.Items.Count < 1)
            {
                Load_combobox_sanpham();
                return; // chỉ bắt đầu tìm khi nhập >= 2 ký tự
            }

            // Lấy dữ liệu gợi ý theo ký tự đang nhập
            DataTable dt = Sql.getData($@"
                                        SELECT MaSP, TenSP 
                                        FROM dbo.uf_SanPham('{MaCN}') 
                                        WHERE TenSP LIKE N'%{text}%' OR MaSP LIKE N'%{text}%'");

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
            bool found = false;
            foreach (DataGridViewRow row in dgvCTPX.Rows)
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
                dgvCTPX.Rows.Add(cb_sanpham.SelectedValue, cb_sanpham.Text, 1);

            cb_sanpham.Text = null;
            cb_sanpham.SelectedIndex = -1;
        }

        private void cb_sanpham_KeyDown(object sender, KeyEventArgs e)
        {
            //cb_sanpham.TextUpdate -= cb_sanpham_TextUpdate; 
            if (e.KeyCode == Keys.Enter)
            {
                //if(cb_sanpham.Items.Count > 0) cb_sanpham.SelectedIndex = 0;
                string query_sp = $@"if exists (select * from SanPham where MaSP like N'%{cb_sanpham.Text}%') select 1 else select 0";
                if (!Sql.KiemTra(query_sp))
                {
                    cb_sanpham.Text = null;
                    return;
                }
                else
                    cb_sanpham.SelectedValue = cb_sanpham.Text;
            }
        }
        private void BanHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cb_sanpham.Focused)
            {
                TimeSpan interval = DateTime.Now - lastKeyPress;
                lastKeyPress = DateTime.Now;

                if (interval.TotalMilliseconds < 50)
                {
                    isScanning = true; // bật chế độ quét
                    barcodeBuffer.Append(e.KeyChar);
                    e.Handled = true; // không cho hiện ký tự
                }
                else
                {
                    isScanning = false;
                    barcodeBuffer.Clear();
                    barcodeBuffer.Append(e.KeyChar);
                }
            }
        }

        private void BanHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (cb_sanpham.Focused && e.KeyCode == Keys.Enter && barcodeBuffer.Length > 0)
            {
                string maSP = barcodeBuffer.ToString().Trim();
                barcodeBuffer.Clear();
                isScanning = false;

                string query_sp = $@"if exists (select * from SanPham where TenSP like N'%{cb_sanpham.Text}%')
                                        select 1
                                     else
                                        select 0";
                if (!Sql.KiemTra(query_sp))
                    return;
                string TenSP = cb_sanpham.Text;
                bool found = false;
                foreach (DataGridViewRow row in dgvCTPX.Rows)
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
                    dgvCTPX.Rows.Add(cb_sanpham.SelectedValue, cb_sanpham.Text, 1);
                cb_sanpham.Text = "";
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
