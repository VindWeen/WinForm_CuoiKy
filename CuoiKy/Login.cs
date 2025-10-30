using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
