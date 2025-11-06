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
    public partial class XemPhieuNhap : Form
    {
        string SoPN;
        public XemPhieuNhap(string soPN)
        {
            InitializeComponent();
            SoPN = soPN;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var mess = MessageBox.Show(@"Bạn có chắc muốn xóa phiếu nhập này chứ?", "Hỏi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (mess == DialogResult.OK)
            {
                Sql.NonQuery($"EXEC PROCEDURE sp_XoaPhieuNhap '{SoPN}'");
                this.Close();
            }
            else
                return;
        }
        private void Load_Data() 
        {
            string query = $@"select * from dbo.v_XemPhieuNhap where SoPN like '{SoPN}'";
            SqlDataReader rd = Sql.Reader(query);
            rd.Read();
            lbl_Ngay.Text = Convert.ToDateTime(rd["NgayLap"]).ToString("yyyy-MM-dd HH:mm:ss");
            lbl_SoPN.Text = rd["SoPN"].ToString().Substring(0,2)=="PX"? rd["SoPN"].ToString().Replace("PX", "PN") : rd["SoPN"].ToString();
            lbl_TuCN.Text = rd["TuCN"].ToString();
            lbl_DenCN.Text = rd["DenCN"].ToString();
            lbl_sum.Text = rd["TongSL"].ToString();
            rd.Close();
            query = $@"select * from dbo.v_XemCTPN where SoPN like '{SoPN}'";
            rd = Sql.Reader(query);
            while (rd.Read())
            {
                dataGridView1.Rows.Add(rd["MaSP"].ToString(), rd["TenSP"].ToString(), rd["SL"].ToString());
            }
        }

        private void XemPhieuNhap_Load(object sender, EventArgs e)
        {

            Load_Data();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}
