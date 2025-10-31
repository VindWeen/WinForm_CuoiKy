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
    public partial class BanHang : Form
    {
        public string MaCN;
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
            MessageBox.Show(MaCN);
        }
    }
}
