namespace CuoiKy
{
    partial class BanHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BanHang));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cb_nhanvien = new System.Windows.Forms.ComboBox();
            this.cb_sanpham = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_sanpham = new System.Windows.Forms.DataGridView();
            this.TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Up = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Down = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_nhantien = new System.Windows.Forms.TextBox();
            this.btn_ThanhToan = new System.Windows.Forms.Button();
            this.lbl_TienThoi = new System.Windows.Forms.Label();
            this.lbl_thanhtien = new System.Windows.Forms.Label();
            this.lbl_SoLuong = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_ThemKhachHang = new System.Windows.Forms.Button();
            this.cb_khachhang = new System.Windows.Forms.ComboBox();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.btn_DoanhThu = new System.Windows.Forms.Button();
            this.btn_Quanly = new System.Windows.Forms.Button();
            this.btn_HoaDon = new System.Windows.Forms.Button();
            this.btn_BanHang = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sanpham)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cb_nhanvien);
            this.panel1.Controls.Add(this.cb_sanpham);
            this.panel1.Location = new System.Drawing.Point(10, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1120, 61);
            this.panel1.TabIndex = 3;
            // 
            // cb_nhanvien
            // 
            this.cb_nhanvien.ForeColor = System.Drawing.Color.Black;
            this.cb_nhanvien.FormattingEnabled = true;
            this.cb_nhanvien.Location = new System.Drawing.Point(777, 11);
            this.cb_nhanvien.Name = "cb_nhanvien";
            this.cb_nhanvien.Size = new System.Drawing.Size(327, 38);
            this.cb_nhanvien.TabIndex = 1;
            this.cb_nhanvien.SelectedIndexChanged += new System.EventHandler(this.cb_nhanvien_SelectedIndexChanged);
            this.cb_nhanvien.TextUpdate += new System.EventHandler(this.cb_nhanvien_TextUpdate);
            // 
            // cb_sanpham
            // 
            this.cb_sanpham.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_sanpham.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cb_sanpham.DropDownHeight = 200;
            this.cb_sanpham.DropDownWidth = 800;
            this.cb_sanpham.ForeColor = System.Drawing.Color.Black;
            this.cb_sanpham.FormattingEnabled = true;
            this.cb_sanpham.IntegralHeight = false;
            this.cb_sanpham.Location = new System.Drawing.Point(14, 11);
            this.cb_sanpham.Name = "cb_sanpham";
            this.cb_sanpham.Size = new System.Drawing.Size(746, 38);
            this.cb_sanpham.TabIndex = 0;
            this.cb_sanpham.SelectedIndexChanged += new System.EventHandler(this.cb_sanpham_SelectedIndexChanged);
            this.cb_sanpham.TextUpdate += new System.EventHandler(this.cb_sanpham_TextUpdate);
            this.cb_sanpham.Click += new System.EventHandler(this.cb_sanpham_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgv_sanpham);
            this.panel2.Location = new System.Drawing.Point(10, 164);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1120, 615);
            this.panel2.TabIndex = 4;
            // 
            // dgv_sanpham
            // 
            this.dgv_sanpham.AllowUserToAddRows = false;
            this.dgv_sanpham.BackgroundColor = System.Drawing.Color.White;
            this.dgv_sanpham.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_sanpham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_sanpham.ColumnHeadersVisible = false;
            this.dgv_sanpham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TenSP,
            this.DonGia,
            this.SL,
            this.Up,
            this.Down,
            this.Delete});
            this.dgv_sanpham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_sanpham.GridColor = System.Drawing.Color.Gainsboro;
            this.dgv_sanpham.Location = new System.Drawing.Point(0, 0);
            this.dgv_sanpham.Name = "dgv_sanpham";
            this.dgv_sanpham.RowHeadersVisible = false;
            this.dgv_sanpham.RowTemplate.Height = 40;
            this.dgv_sanpham.Size = new System.Drawing.Size(1118, 613);
            this.dgv_sanpham.TabIndex = 0;
            this.dgv_sanpham.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_sanpham_CellContentClick);
            // 
            // TenSP
            // 
            this.TenSP.HeaderText = "Tên sản phẩm";
            this.TenSP.Name = "TenSP";
            this.TenSP.ReadOnly = true;
            this.TenSP.Width = 550;
            // 
            // DonGia
            // 
            dataGridViewCellStyle1.Format = "#,##0";
            dataGridViewCellStyle1.NullValue = "0";
            this.DonGia.DefaultCellStyle = dataGridViewCellStyle1;
            this.DonGia.HeaderText = "Đơn giá";
            this.DonGia.Name = "DonGia";
            this.DonGia.ReadOnly = true;
            this.DonGia.Width = 200;
            // 
            // SL
            // 
            this.SL.HeaderText = "Số lượng";
            this.SL.Name = "SL";
            this.SL.ReadOnly = true;
            this.SL.Width = 120;
            // 
            // Up
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "▲";
            dataGridViewCellStyle2.NullValue = "▲";
            this.Up.DefaultCellStyle = dataGridViewCellStyle2;
            this.Up.HeaderText = "Tăng";
            this.Up.Name = "Up";
            this.Up.ReadOnly = true;
            this.Up.Text = "▲";
            this.Up.Width = 80;
            // 
            // Down
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "▼";
            dataGridViewCellStyle3.NullValue = "▼";
            this.Down.DefaultCellStyle = dataGridViewCellStyle3;
            this.Down.HeaderText = "Giảm";
            this.Down.Name = "Down";
            this.Down.ReadOnly = true;
            this.Down.Text = "▼";
            this.Down.Width = 80;
            // 
            // Delete
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "🗑️";
            dataGridViewCellStyle4.NullValue = "🗑️";
            this.Delete.DefaultCellStyle = dataGridViewCellStyle4;
            this.Delete.HeaderText = "Xóa";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Text = "🗑️";
            this.Delete.Width = 80;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txt_nhantien);
            this.panel3.Controls.Add(this.btn_ThanhToan);
            this.panel3.Controls.Add(this.lbl_TienThoi);
            this.panel3.Controls.Add(this.lbl_thanhtien);
            this.panel3.Controls.Add(this.lbl_SoLuong);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.btn_ThemKhachHang);
            this.panel3.Controls.Add(this.cb_khachhang);
            this.panel3.Location = new System.Drawing.Point(1131, 104);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(405, 675);
            this.panel3.TabIndex = 4;
            // 
            // txt_nhantien
            // 
            this.txt_nhantien.BackColor = System.Drawing.Color.White;
            this.txt_nhantien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_nhantien.Location = new System.Drawing.Point(178, 290);
            this.txt_nhantien.Multiline = true;
            this.txt_nhantien.Name = "txt_nhantien";
            this.txt_nhantien.Size = new System.Drawing.Size(202, 40);
            this.txt_nhantien.TabIndex = 20;
            this.txt_nhantien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_nhantien.TextChanged += new System.EventHandler(this.txt_nhantien_TextChanged);
            this.txt_nhantien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_nhantien_KeyDown);
            // 
            // btn_ThanhToan
            // 
            this.btn_ThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(181)))), ((int)(((byte)(59)))));
            this.btn_ThanhToan.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_ThanhToan.Location = new System.Drawing.Point(20, 541);
            this.btn_ThanhToan.Name = "btn_ThanhToan";
            this.btn_ThanhToan.Size = new System.Drawing.Size(360, 72);
            this.btn_ThanhToan.TabIndex = 19;
            this.btn_ThanhToan.Text = "Thanh toán (F9)";
            this.btn_ThanhToan.UseVisualStyleBackColor = false;
            this.btn_ThanhToan.Click += new System.EventHandler(this.btn_ThanhToan_Click);
            // 
            // lbl_TienThoi
            // 
            this.lbl_TienThoi.ForeColor = System.Drawing.Color.Black;
            this.lbl_TienThoi.Location = new System.Drawing.Point(131, 360);
            this.lbl_TienThoi.Name = "lbl_TienThoi";
            this.lbl_TienThoi.Size = new System.Drawing.Size(249, 48);
            this.lbl_TienThoi.TabIndex = 11;
            this.lbl_TienThoi.Text = "0";
            this.lbl_TienThoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_thanhtien
            // 
            this.lbl_thanhtien.ForeColor = System.Drawing.Color.Black;
            this.lbl_thanhtien.Location = new System.Drawing.Point(143, 203);
            this.lbl_thanhtien.Name = "lbl_thanhtien";
            this.lbl_thanhtien.Size = new System.Drawing.Size(237, 48);
            this.lbl_thanhtien.TabIndex = 9;
            this.lbl_thanhtien.Text = "0";
            this.lbl_thanhtien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_SoLuong
            // 
            this.lbl_SoLuong.ForeColor = System.Drawing.Color.Black;
            this.lbl_SoLuong.Location = new System.Drawing.Point(143, 126);
            this.lbl_SoLuong.Name = "lbl_SoLuong";
            this.lbl_SoLuong.Size = new System.Drawing.Size(237, 48);
            this.lbl_SoLuong.TabIndex = 8;
            this.lbl_SoLuong.Text = "0";
            this.lbl_SoLuong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(15, 360);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 48);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tiền thối:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(15, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 48);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tiền nhận:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(15, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 48);
            this.label2.TabIndex = 5;
            this.label2.Text = "Thành tiền:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(15, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 48);
            this.label1.TabIndex = 4;
            this.label1.Text = "Số lượng:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(181)))), ((int)(((byte)(59)))));
            this.button1.Image = global::CuoiKy.Properties.Resources.edit_35dp_393E46_FILL0_wght400_GRAD0_opsz40;
            this.button1.Location = new System.Drawing.Point(350, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 40);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_ThemKhachHang
            // 
            this.btn_ThemKhachHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(181)))), ((int)(((byte)(59)))));
            this.btn_ThemKhachHang.Image = global::CuoiKy.Properties.Resources.person_add;
            this.btn_ThemKhachHang.Location = new System.Drawing.Point(305, 11);
            this.btn_ThemKhachHang.Name = "btn_ThemKhachHang";
            this.btn_ThemKhachHang.Size = new System.Drawing.Size(40, 40);
            this.btn_ThemKhachHang.TabIndex = 3;
            this.btn_ThemKhachHang.UseVisualStyleBackColor = false;
            this.btn_ThemKhachHang.Click += new System.EventHandler(this.btn_ThemKhachHang_Click);
            // 
            // cb_khachhang
            // 
            this.cb_khachhang.ForeColor = System.Drawing.Color.Black;
            this.cb_khachhang.FormattingEnabled = true;
            this.cb_khachhang.Location = new System.Drawing.Point(15, 11);
            this.cb_khachhang.Name = "cb_khachhang";
            this.cb_khachhang.Size = new System.Drawing.Size(284, 38);
            this.cb_khachhang.TabIndex = 2;
            this.cb_khachhang.SelectedIndexChanged += new System.EventHandler(this.cb_khachhang_SelectedIndexChanged);
            this.cb_khachhang.TextUpdate += new System.EventHandler(this.cb_khachhang_TextUpdate);
            this.cb_khachhang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb_khachhang_KeyDown);
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.btn_Thoat.ForeColor = System.Drawing.Color.White;
            this.btn_Thoat.Image = global::CuoiKy.Properties.Resources.logoutwhite;
            this.btn_Thoat.Location = new System.Drawing.Point(1345, 12);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(154, 73);
            this.btn_Thoat.TabIndex = 2;
            this.btn_Thoat.UseVisualStyleBackColor = false;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // btn_DoanhThu
            // 
            this.btn_DoanhThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(201)))), ((int)(((byte)(238)))));
            this.btn_DoanhThu.Image = global::CuoiKy.Properties.Resources.finance;
            this.btn_DoanhThu.Location = new System.Drawing.Point(617, 12);
            this.btn_DoanhThu.Name = "btn_DoanhThu";
            this.btn_DoanhThu.Size = new System.Drawing.Size(154, 73);
            this.btn_DoanhThu.TabIndex = 2;
            this.btn_DoanhThu.UseVisualStyleBackColor = false;
            // 
            // btn_Quanly
            // 
            this.btn_Quanly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(125)))), ((int)(((byte)(85)))));
            this.btn_Quanly.Image = global::CuoiKy.Properties.Resources.package;
            this.btn_Quanly.Location = new System.Drawing.Point(420, 12);
            this.btn_Quanly.Name = "btn_Quanly";
            this.btn_Quanly.Size = new System.Drawing.Size(154, 73);
            this.btn_Quanly.TabIndex = 2;
            this.btn_Quanly.UseVisualStyleBackColor = false;
            // 
            // btn_HoaDon
            // 
            this.btn_HoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(226)))), ((int)(((byte)(250)))));
            this.btn_HoaDon.Image = global::CuoiKy.Properties.Resources.receipt;
            this.btn_HoaDon.Location = new System.Drawing.Point(221, 12);
            this.btn_HoaDon.Name = "btn_HoaDon";
            this.btn_HoaDon.Size = new System.Drawing.Size(154, 73);
            this.btn_HoaDon.TabIndex = 1;
            this.btn_HoaDon.UseVisualStyleBackColor = false;
            this.btn_HoaDon.Click += new System.EventHandler(this.btn_HoaDon_Click);
            // 
            // btn_BanHang
            // 
            this.btn_BanHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(206)))), ((int)(((byte)(136)))));
            this.btn_BanHang.Image = global::CuoiKy.Properties.Resources.shopping;
            this.btn_BanHang.Location = new System.Drawing.Point(24, 12);
            this.btn_BanHang.Name = "btn_BanHang";
            this.btn_BanHang.Size = new System.Drawing.Size(154, 73);
            this.btn_BanHang.TabIndex = 0;
            this.btn_BanHang.UseVisualStyleBackColor = false;
            // 
            // BanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1534, 791);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_DoanhThu);
            this.Controls.Add(this.btn_Quanly);
            this.Controls.Add(this.btn_HoaDon);
            this.Controls.Add(this.btn_BanHang);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "BanHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BanHang";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BanHang_FormClosing);
            this.Load += new System.EventHandler(this.BanHang_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sanpham)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_BanHang;
        private System.Windows.Forms.Button btn_HoaDon;
        private System.Windows.Forms.Button btn_Quanly;
        private System.Windows.Forms.Button btn_DoanhThu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cb_sanpham;
        private System.Windows.Forms.Button btn_Thoat;
        private System.Windows.Forms.ComboBox cb_nhanvien;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cb_khachhang;
        private System.Windows.Forms.Button btn_ThemKhachHang;
        private System.Windows.Forms.Label lbl_TienThoi;
        private System.Windows.Forms.Label lbl_thanhtien;
        private System.Windows.Forms.Label lbl_SoLuong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ThanhToan;
        private System.Windows.Forms.TextBox txt_nhantien;
        private System.Windows.Forms.DataGridView dgv_sanpham;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn SL;
        private System.Windows.Forms.DataGridViewButtonColumn Up;
        private System.Windows.Forms.DataGridViewButtonColumn Down;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.Button button1;
    }
}