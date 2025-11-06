namespace CuoiKy
{
    partial class SanPham
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_masp = new System.Windows.Forms.TextBox();
            this.txt_tensp = new System.Windows.Forms.TextBox();
            this.txt_SL = new System.Windows.Forms.TextBox();
            this.cb_filterSL = new System.Windows.Forms.ComboBox();
            this.dgv_sanpham = new System.Windows.Forms.DataGridView();
            this.cb_filterTT = new System.Windows.Forms.ComboBox();
            this.txt_TT = new System.Windows.Forms.TextBox();
            this.lbl_TongSoLuong = new System.Windows.Forms.Label();
            this.lbl_TongSP = new System.Windows.Forms.Label();
            this.btn_themsp = new System.Windows.Forms.Button();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.btn_DoanhThu = new System.Windows.Forms.Button();
            this.btn_Quanly = new System.Windows.Forms.Button();
            this.btn_HoaDon = new System.Windows.Forms.Button();
            this.btn_BanHang = new System.Windows.Forms.Button();
            this.Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XemTon = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sanpham)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_masp);
            this.panel1.Controls.Add(this.txt_tensp);
            this.panel1.Controls.Add(this.txt_TT);
            this.panel1.Controls.Add(this.txt_SL);
            this.panel1.Controls.Add(this.cb_filterTT);
            this.panel1.Controls.Add(this.cb_filterSL);
            this.panel1.Location = new System.Drawing.Point(0, 121);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1534, 61);
            this.panel1.TabIndex = 32;
            // 
            // txt_masp
            // 
            this.txt_masp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_masp.Location = new System.Drawing.Point(12, 18);
            this.txt_masp.Name = "txt_masp";
            this.txt_masp.Size = new System.Drawing.Size(283, 35);
            this.txt_masp.TabIndex = 22;
            this.txt_masp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_masp_KeyDown);
            // 
            // txt_tensp
            // 
            this.txt_tensp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_tensp.Location = new System.Drawing.Point(312, 17);
            this.txt_tensp.Name = "txt_tensp";
            this.txt_tensp.Size = new System.Drawing.Size(585, 35);
            this.txt_tensp.TabIndex = 22;
            this.txt_tensp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_tensp_KeyDown);
            // 
            // txt_SL
            // 
            this.txt_SL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_SL.Enabled = false;
            this.txt_SL.Location = new System.Drawing.Point(966, 18);
            this.txt_SL.Name = "txt_SL";
            this.txt_SL.Size = new System.Drawing.Size(145, 35);
            this.txt_SL.TabIndex = 20;
            this.txt_SL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_SL_KeyDown);
            // 
            // cb_filterSL
            // 
            this.cb_filterSL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_filterSL.FormattingEnabled = true;
            this.cb_filterSL.Items.AddRange(new object[] {
            "*",
            "=",
            ">",
            "≥",
            "<",
            "≤"});
            this.cb_filterSL.Location = new System.Drawing.Point(922, 16);
            this.cb_filterSL.Name = "cb_filterSL";
            this.cb_filterSL.Size = new System.Drawing.Size(42, 38);
            this.cb_filterSL.TabIndex = 23;
            this.cb_filterSL.SelectedIndexChanged += new System.EventHandler(this.cb_filterSL_SelectedIndexChanged);
            // 
            // dgv_sanpham
            // 
            this.dgv_sanpham.AllowUserToAddRows = false;
            this.dgv_sanpham.BackgroundColor = System.Drawing.Color.White;
            this.dgv_sanpham.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_sanpham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_sanpham.ColumnHeadersHeight = 40;
            this.dgv_sanpham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Model,
            this.TenSP,
            this.DonGia,
            this.SL,
            this.XemTon});
            this.dgv_sanpham.GridColor = System.Drawing.Color.Gainsboro;
            this.dgv_sanpham.Location = new System.Drawing.Point(0, 182);
            this.dgv_sanpham.Name = "dgv_sanpham";
            this.dgv_sanpham.ReadOnly = true;
            this.dgv_sanpham.RowHeadersVisible = false;
            this.dgv_sanpham.RowTemplate.Height = 40;
            this.dgv_sanpham.Size = new System.Drawing.Size(1534, 552);
            this.dgv_sanpham.TabIndex = 31;
            this.dgv_sanpham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_sanpham_CellClick);
            // 
            // cb_filterTT
            // 
            this.cb_filterTT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_filterTT.FormattingEnabled = true;
            this.cb_filterTT.Items.AddRange(new object[] {
            "*",
            "=",
            ">",
            "≥",
            "<",
            "≤"});
            this.cb_filterTT.Location = new System.Drawing.Point(1137, 15);
            this.cb_filterTT.Name = "cb_filterTT";
            this.cb_filterTT.Size = new System.Drawing.Size(42, 38);
            this.cb_filterTT.TabIndex = 23;
            this.cb_filterTT.SelectedIndexChanged += new System.EventHandler(this.cb_filterTT_SelectedIndexChanged);
            // 
            // txt_TT
            // 
            this.txt_TT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_TT.Enabled = false;
            this.txt_TT.Location = new System.Drawing.Point(1181, 17);
            this.txt_TT.Name = "txt_TT";
            this.txt_TT.Size = new System.Drawing.Size(145, 35);
            this.txt_TT.TabIndex = 20;
            this.txt_TT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_TT_KeyDown);
            // 
            // lbl_TongSoLuong
            // 
            this.lbl_TongSoLuong.Location = new System.Drawing.Point(1143, 742);
            this.lbl_TongSoLuong.Name = "lbl_TongSoLuong";
            this.lbl_TongSoLuong.Size = new System.Drawing.Size(183, 42);
            this.lbl_TongSoLuong.TabIndex = 34;
            this.lbl_TongSoLuong.Text = "0";
            this.lbl_TongSoLuong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_TongSP
            // 
            this.lbl_TongSP.Location = new System.Drawing.Point(20, 742);
            this.lbl_TongSP.Name = "lbl_TongSP";
            this.lbl_TongSP.Size = new System.Drawing.Size(221, 41);
            this.lbl_TongSP.TabIndex = 35;
            this.lbl_TongSP.Text = "Số mẫu sản phẩm";
            this.lbl_TongSP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_themsp
            // 
            this.btn_themsp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(181)))), ((int)(((byte)(59)))));
            this.btn_themsp.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_themsp.Location = new System.Drawing.Point(1340, 739);
            this.btn_themsp.Name = "btn_themsp";
            this.btn_themsp.Size = new System.Drawing.Size(179, 48);
            this.btn_themsp.TabIndex = 33;
            this.btn_themsp.Text = "Thêm sản phẩm";
            this.btn_themsp.UseVisualStyleBackColor = false;
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.btn_Thoat.ForeColor = System.Drawing.Color.White;
            this.btn_Thoat.Image = global::CuoiKy.Properties.Resources.logoutwhite;
            this.btn_Thoat.Location = new System.Drawing.Point(1355, 16);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(154, 73);
            this.btn_Thoat.TabIndex = 21;
            this.btn_Thoat.UseVisualStyleBackColor = false;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // btn_DoanhThu
            // 
            this.btn_DoanhThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(201)))), ((int)(((byte)(238)))));
            this.btn_DoanhThu.Image = global::CuoiKy.Properties.Resources.finance;
            this.btn_DoanhThu.Location = new System.Drawing.Point(618, 16);
            this.btn_DoanhThu.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btn_DoanhThu.Name = "btn_DoanhThu";
            this.btn_DoanhThu.Size = new System.Drawing.Size(154, 73);
            this.btn_DoanhThu.TabIndex = 19;
            this.btn_DoanhThu.UseVisualStyleBackColor = false;
            // 
            // btn_Quanly
            // 
            this.btn_Quanly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(125)))), ((int)(((byte)(85)))));
            this.btn_Quanly.Image = global::CuoiKy.Properties.Resources.package;
            this.btn_Quanly.Location = new System.Drawing.Point(421, 16);
            this.btn_Quanly.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btn_Quanly.Name = "btn_Quanly";
            this.btn_Quanly.Size = new System.Drawing.Size(154, 73);
            this.btn_Quanly.TabIndex = 20;
            this.btn_Quanly.UseVisualStyleBackColor = false;
            // 
            // btn_HoaDon
            // 
            this.btn_HoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(226)))), ((int)(((byte)(250)))));
            this.btn_HoaDon.Image = global::CuoiKy.Properties.Resources.receipt;
            this.btn_HoaDon.Location = new System.Drawing.Point(222, 16);
            this.btn_HoaDon.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btn_HoaDon.Name = "btn_HoaDon";
            this.btn_HoaDon.Size = new System.Drawing.Size(154, 73);
            this.btn_HoaDon.TabIndex = 18;
            this.btn_HoaDon.UseVisualStyleBackColor = false;
            // 
            // btn_BanHang
            // 
            this.btn_BanHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(206)))), ((int)(((byte)(136)))));
            this.btn_BanHang.Image = global::CuoiKy.Properties.Resources.shopping;
            this.btn_BanHang.Location = new System.Drawing.Point(25, 16);
            this.btn_BanHang.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btn_BanHang.Name = "btn_BanHang";
            this.btn_BanHang.Size = new System.Drawing.Size(154, 73);
            this.btn_BanHang.TabIndex = 17;
            this.btn_BanHang.UseVisualStyleBackColor = false;
            // 
            // Model
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.Model.DefaultCellStyle = dataGridViewCellStyle8;
            this.Model.HeaderText = "Model";
            this.Model.Name = "Model";
            this.Model.ReadOnly = true;
            this.Model.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Model.Width = 300;
            // 
            // TenSP
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.TenSP.DefaultCellStyle = dataGridViewCellStyle9;
            this.TenSP.HeaderText = "Tên sản phẩm";
            this.TenSP.Name = "TenSP";
            this.TenSP.ReadOnly = true;
            this.TenSP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TenSP.Width = 610;
            // 
            // DonGia
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DonGia.DefaultCellStyle = dataGridViewCellStyle10;
            this.DonGia.HeaderText = "Giá";
            this.DonGia.Name = "DonGia";
            this.DonGia.ReadOnly = true;
            this.DonGia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DonGia.Width = 210;
            // 
            // SL
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SL.DefaultCellStyle = dataGridViewCellStyle11;
            this.SL.HeaderText = "Tổng tồn";
            this.SL.Name = "SL";
            this.SL.ReadOnly = true;
            this.SL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SL.Width = 210;
            // 
            // XemTon
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.Format = "🔍 Xem tồn";
            dataGridViewCellStyle12.NullValue = "🔍 Xem tồn";
            dataGridViewCellStyle12.Padding = new System.Windows.Forms.Padding(20, 3, 20, 3);
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            this.XemTon.DefaultCellStyle = dataGridViewCellStyle12;
            this.XemTon.HeaderText = "*________";
            this.XemTon.Name = "XemTon";
            this.XemTon.ReadOnly = true;
            this.XemTon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.XemTon.Width = 200;
            // 
            // SanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1534, 791);
            this.Controls.Add(this.lbl_TongSoLuong);
            this.Controls.Add(this.lbl_TongSP);
            this.Controls.Add(this.btn_themsp);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv_sanpham);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_DoanhThu);
            this.Controls.Add(this.btn_Quanly);
            this.Controls.Add(this.btn_HoaDon);
            this.Controls.Add(this.btn_BanHang);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "SanPham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SanPham";
            this.Load += new System.EventHandler(this.SanPham_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sanpham)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Thoat;
        private System.Windows.Forms.Button btn_DoanhThu;
        private System.Windows.Forms.Button btn_Quanly;
        private System.Windows.Forms.Button btn_HoaDon;
        private System.Windows.Forms.Button btn_BanHang;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_masp;
        private System.Windows.Forms.TextBox txt_tensp;
        private System.Windows.Forms.TextBox txt_SL;
        private System.Windows.Forms.ComboBox cb_filterSL;
        private System.Windows.Forms.DataGridView dgv_sanpham;
        private System.Windows.Forms.TextBox txt_TT;
        private System.Windows.Forms.ComboBox cb_filterTT;
        private System.Windows.Forms.Label lbl_TongSoLuong;
        private System.Windows.Forms.Label lbl_TongSP;
        private System.Windows.Forms.Button btn_themsp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Model;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn SL;
        private System.Windows.Forms.DataGridViewButtonColumn XemTon;
    }
}