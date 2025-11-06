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
using System.Data.SqlTypes;
using System.Data.SqlClient;


namespace CuoiKy
{
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var a = MessageBox.Show("Bạn có chắc muốn thoát không?","Thông báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (a == DialogResult.OK)
                Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txt_user.Text, password = textBox1.Text;
            if(Sql.KiemTra($"select dbo.uf_CheckAccount('{username}','{password}')")){//Kiểm tra tài khoản có tồn tại hoặc có hoạt động không
                label3.Visible=false;

                //Lấy mã chi nhánh
                SqlDataReader rd = Sql.Reader($"select * from dbo.ufTaiKhoan('{username}','{password}')");
                rd.Read();
                TaiKhoan.MaCN = rd["MaCN"].ToString();
                TaiKhoan.QuyenHan = rd["QuyenHan"].ToString() ;
                TaiKhoan.ChucVu = rd["ChucVu"].ToString();
                rd.Close();
                //Mở form mới
                this.Hide();
                BanHang frm = new BanHang();
                frm.ShowDialog();
                this.Close();
            }
            else
            {
                label3.Visible=true;
            }    
        }
    }
}
