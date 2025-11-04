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
    public partial class XemHoaDon : Form
    {
        string SoHD;
        public XemHoaDon(string soHD)
        {
            InitializeComponent();
            SoHD = soHD;
        }

        private void XemHoaDon_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string query1 = $@"exec dbo.sp_XemHoaDon '{SoHD}'";
            //MessageBox.Show(query1);
            string query2 = $@"select TenSP,Sl,DonGia from dbo.vCTHD where SoHD like '{SoHD}'";
            //MessageBox.Show(query2);
            SqlDataReader rd = Sql.Reader(query1);
            rd.Read();
            lbl_SoHoaDon.Text = rd["SoHD"].ToString();
            lbl_Ngay.Text = Convert.ToDateTime(rd["NgayLap"]).ToString("dd/MM/yyyy hh:mm:ss");
            lbl_TenKH.Text = rd["HoTen"].ToString();
            lbl_SDT_KH.Text = rd["SDT"].ToString();
            lbl_NhanVien.Text = rd["HoTenNV"].ToString();
            lbl_sum.Text = Convert.ToInt32(rd["TongTien"]).ToString("N0");
            rd.Close();
            rd = Sql.Reader(query2);
            while (rd.Read())
            {
                string tensp = rd["TenSP"].ToString();
                string sl = rd["SL"].ToString();
                string dongia = Convert.ToInt32(rd["DonGia"]).ToString("N0");
                dataGridView1.Rows.Add(tensp, sl, dongia);
            }
            dataGridView1.ClearSelection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var a = MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (a == DialogResult.OK)
                Dispose();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
