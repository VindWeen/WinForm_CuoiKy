using SQL;
using System;
using System.CodeDom;
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
    public partial class XemPhieuXuat : Form
    {
        string SoPX;
        public XemPhieuXuat(string soPX)
        {
            InitializeComponent();
            SoPX = soPX;
        }

        private void XemPhieuXuat_Load(object sender, EventArgs e)
        {
            Load_Data();
        }
        private void Load_Data()
        {
            string query = $@"select * from dbo.v_XemCTPX where SoPX like '{SoPX}'";
            SqlDataReader rd = Sql.Reader(query);
            rd.Read();
            lbl_Ngay.Text = Convert.ToDateTime(rd["NgayLap"]).ToString("yyyy-MM-dd HH:mm:ss");
            lbl_SoPX.Text = rd["SoPX"].ToString();
            lbl_TuCN.Text = rd["TuCN"].ToString();
            lbl_DenCN.Text = rd["DenCN"].ToString();
            lbl_sum.Text = rd["TongSL"].ToString();
            rd.Close();
            query = $@"select * from dbo.v_XemSanPhamPhieuXuat where SoPX like '{SoPX}'";
            rd = Sql.Reader(query);
            while (rd.Read())
            {
                dataGridView1.Rows.Add(rd["MaSP"].ToString(),rd["TenSP"].ToString(), rd["SL"].ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var mess = MessageBox.Show(@"Bạn có chắc muốn xóa phiếu xuất này chứ?","Hỏi",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (mess == DialogResult.OK)
            {
                Sql.NonQuery($"EXEC dbo.sp_XoaPhieuXuat '{SoPX}'");
                this.Close();
            }
            else
                return;
        }
    }
}
