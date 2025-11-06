using Microsoft.SqlServer.Server;
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
    public partial class Kho : Form
    {
        string Model;
        public Kho(string model)
        {
            InitializeComponent();
            Model = model;
        }

        private void Kho_Load(object sender, EventArgs e)
        {
            Load_Data();
            lbl_tensp.Text = Convert.ToString(Sql.Scalar($"select distinct(TenSP) from dbo.v_uf_SanPham_MauKhoSize('{Model}')"));
        }
        private void Load_Data()
        {
            string query_mau = $@"select distinct(Mau) from dbo.v_uf_SanPham_MauKhoSize('{Model}')";
            List<string> mauList = new List<string>(); SqlDataReader rd_mau = Sql.Reader(query_mau);
                while (rd_mau.Read())
                {
                    mauList.Add(rd_mau["Mau"].ToString());
                }

            for(int i =0;i<mauList.Count;i++)
            {
                string tenMau = mauList[i].ToString();
                string query_size = $@"select distinct(Size) from dbo.v_uf_SanPham_MauKhoSize('{Model}') where Mau = N'{tenMau}'";
                TabPage tab = new TabPage(tenMau) { BackColor = Color.White };
                // Lấy list size cho màu này
                SqlDataReader rd_size = Sql.Reader(query_size);
                List<string> sizes = new List<string>();
                while (rd_size.Read())
                {
                    sizes.Add(rd_size["Size"].ToString());
                }

                TableLayoutPanel tbl = TaoBangSize(sizes);  // Hàm tạo bảng size
                tbl.Dock = DockStyle.Top;

                DataGridView dgv = TaoDgvMau();             // Hàm tạo dgv mới
                dgv.Dock = DockStyle.Fill;

                tab.Controls.Add(dgv);      // Add dgv TRƯỚC
                tab.Controls.Add(tbl);      // Add TableLayoutPanel SAU (nằm trên cùng)

                tabControl1.TabPages.Add(tab);
                //var tbl = TaoBangSize(sizes);
                //tab.Controls.Add(tbl);    // add TableLayoutPanel trên top

                //var dgv = TaoDgvMau();
                //tab.Controls.Add(dgv);    // add DataGridView bên dưới

                //tabControl1.TabPages.Add(tab);

            }
        }
        // Tạo và trả về TableLayoutPanel mẫu (với 6 button size ở cột 2~7, dòng 2)
        public TableLayoutPanel TaoBangSize(List<string> sizes)
        {
            var tbl = new TableLayoutPanel();
            tbl.Dock = DockStyle.Top;
            tbl.Size = new Size(1022, 145);
            tbl.ColumnCount = 10;
            tbl.RowCount = 3;

            tbl.ColumnStyles.Clear();
            for (int i = 0; i < tbl.ColumnCount; i++)
                tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10f));

            tbl.RowStyles.Clear();
            for (int i = 0; i < tbl.RowCount; i++)
                tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33f));

            // Các màu nút size
            Color[] colors = {
        Color.FromArgb(255, 241, 208),
        Color.FromArgb(255, 224, 163),
        Color.FromArgb(255, 209, 122),
        Color.FromArgb(255, 191, 83),
        Color.FromArgb(252, 181, 59),
        Color.FromArgb(230, 162, 51)
    };

            // Add các button vào cột 2~7 dòng 2, text là size
            for (int i = 0; i < Math.Min(6, sizes.Count); i++)
            {
                var btn = new Button();
                btn.Text = sizes[i];
                btn.Dock = DockStyle.Fill;
                btn.BackColor = colors[i];
                btn.Tag = sizes[i];   // Lưu lại size
                btn.Click += BtnSize_Click; // Xử lý khi click
                tbl.Controls.Add(btn, i + 2, 1); // cột 2~7, dòng 2 (hàng chỉ số 1)
            }
            return tbl;
        }

        // Tạo DataGridView mẫu dùng cho mỗi tab
        public DataGridView TaoDgvMau()
        {
            var dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;
            dgv.BackgroundColor = Color.White;
            dgv.AllowUserToAddRows = false;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.ColumnCount = 2;
            dgv.Columns[0].Name = "Chi nhánh";
            dgv.Columns[1].Name = "Số lượng";
            dgv.ColumnHeadersHeight = 40; dgv.RowTemplate.Height = 40;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            return dgv;
        }

        private void BtnSize_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string size = btn.Text;
            TabPage tab = (TabPage)btn.Parent.Parent;

            DataGridView dgv = tab.Controls.OfType<DataGridView>().FirstOrDefault();
            if (dgv != null)
            {
                dgv.Rows.Clear();
                string tenMau = tab.Text;
                string query = $@"select MaCN, SL from dbo.v_uf_SanPham_MauKhoSize('{Model}') where Mau = N'{tenMau}' and Size = '{size}'";
                SqlDataReader rd = Sql.Reader(query);
                    while (rd.Read())
                        dgv.Rows.Add(rd["MaCN"], rd["SL"]);
            }
        }
        private void btn_dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
