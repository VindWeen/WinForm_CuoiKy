namespace CuoiKy
{
    partial class ChiNhanh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChiNhanh));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.btn_DoanhThu = new System.Windows.Forms.Button();
            this.btn_Quanly = new System.Windows.Forms.Button();
            this.btn_HoaDon = new System.Windows.Forms.Button();
            this.btn_BanHang = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_tencn = new System.Windows.Forms.TextBox();
            this.txt_macn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.dgv_chinhanh = new System.Windows.Forms.DataGridView();
            this.MaCN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenCN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_diachi = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_chinhanh)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Thoat);
            this.panel1.Controls.Add(this.btn_DoanhThu);
            this.panel1.Controls.Add(this.btn_Quanly);
            this.panel1.Controls.Add(this.btn_HoaDon);
            this.panel1.Controls.Add(this.btn_BanHang);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1534, 102);
            this.panel1.TabIndex = 36;
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.btn_Thoat.ForeColor = System.Drawing.Color.White;
            this.btn_Thoat.Image = global::CuoiKy.Properties.Resources.logoutwhite;
            this.btn_Thoat.Location = new System.Drawing.Point(1355, 16);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(154, 73);
            this.btn_Thoat.TabIndex = 26;
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
            this.btn_DoanhThu.TabIndex = 24;
            this.btn_DoanhThu.UseVisualStyleBackColor = false;
            this.btn_DoanhThu.Click += new System.EventHandler(this.btn_DoanhThu_Click);
            // 
            // btn_Quanly
            // 
            this.btn_Quanly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(125)))), ((int)(((byte)(85)))));
            this.btn_Quanly.Image = global::CuoiKy.Properties.Resources.package;
            this.btn_Quanly.Location = new System.Drawing.Point(421, 16);
            this.btn_Quanly.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btn_Quanly.Name = "btn_Quanly";
            this.btn_Quanly.Size = new System.Drawing.Size(154, 73);
            this.btn_Quanly.TabIndex = 25;
            this.btn_Quanly.UseVisualStyleBackColor = false;
            this.btn_Quanly.Click += new System.EventHandler(this.btn_Quanly_Click);
            // 
            // btn_HoaDon
            // 
            this.btn_HoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(226)))), ((int)(((byte)(250)))));
            this.btn_HoaDon.Image = global::CuoiKy.Properties.Resources.receipt;
            this.btn_HoaDon.Location = new System.Drawing.Point(222, 16);
            this.btn_HoaDon.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btn_HoaDon.Name = "btn_HoaDon";
            this.btn_HoaDon.Size = new System.Drawing.Size(154, 73);
            this.btn_HoaDon.TabIndex = 23;
            this.btn_HoaDon.UseVisualStyleBackColor = false;
            this.btn_HoaDon.Click += new System.EventHandler(this.btn_HoaDon_Click);
            // 
            // btn_BanHang
            // 
            this.btn_BanHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(206)))), ((int)(((byte)(136)))));
            this.btn_BanHang.Image = global::CuoiKy.Properties.Resources.shopping;
            this.btn_BanHang.Location = new System.Drawing.Point(25, 16);
            this.btn_BanHang.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btn_BanHang.Name = "btn_BanHang";
            this.btn_BanHang.Size = new System.Drawing.Size(154, 73);
            this.btn_BanHang.TabIndex = 22;
            this.btn_BanHang.UseVisualStyleBackColor = false;
            this.btn_BanHang.Click += new System.EventHandler(this.btn_BanHang_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(1152, 102);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(382, 689);
            this.panel2.TabIndex = 37;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.txt_diachi);
            this.panel5.Controls.Add(this.txt_tencn);
            this.panel5.Controls.Add(this.txt_macn);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(382, 573);
            this.panel5.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 30);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tên chi nhánh:";
            // 
            // txt_tencn
            // 
            this.txt_tencn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_tencn.Location = new System.Drawing.Point(30, 225);
            this.txt_tencn.Multiline = true;
            this.txt_tencn.Name = "txt_tencn";
            this.txt_tencn.Size = new System.Drawing.Size(330, 42);
            this.txt_tencn.TabIndex = 2;
            // 
            // txt_macn
            // 
            this.txt_macn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_macn.Location = new System.Drawing.Point(30, 120);
            this.txt_macn.Multiline = true;
            this.txt_macn.Name = "txt_macn";
            this.txt_macn.Size = new System.Drawing.Size(327, 42);
            this.txt_macn.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã chi nhánh:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btn_xoa);
            this.panel4.Controls.Add(this.btn_sua);
            this.panel4.Controls.Add(this.btn_them);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 573);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(382, 116);
            this.panel4.TabIndex = 6;
            // 
            // btn_xoa
            // 
            this.btn_xoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(181)))), ((int)(((byte)(59)))));
            this.btn_xoa.Location = new System.Drawing.Point(252, 21);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(101, 51);
            this.btn_xoa.TabIndex = 5;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = false;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(181)))), ((int)(((byte)(59)))));
            this.btn_sua.Location = new System.Drawing.Point(145, 21);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(101, 51);
            this.btn_sua.TabIndex = 5;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.UseVisualStyleBackColor = false;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_them
            // 
            this.btn_them.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(181)))), ((int)(((byte)(59)))));
            this.btn_them.Location = new System.Drawing.Point(35, 21);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(101, 51);
            this.btn_them.TabIndex = 5;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = false;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // dgv_chinhanh
            // 
            this.dgv_chinhanh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_chinhanh.BackgroundColor = System.Drawing.Color.White;
            this.dgv_chinhanh.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_chinhanh.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_chinhanh.ColumnHeadersHeight = 40;
            this.dgv_chinhanh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaCN,
            this.TenCN,
            this.DiaChi});
            this.dgv_chinhanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_chinhanh.GridColor = System.Drawing.Color.Gainsboro;
            this.dgv_chinhanh.Location = new System.Drawing.Point(0, 102);
            this.dgv_chinhanh.Name = "dgv_chinhanh";
            this.dgv_chinhanh.ReadOnly = true;
            this.dgv_chinhanh.RowHeadersVisible = false;
            this.dgv_chinhanh.RowTemplate.Height = 40;
            this.dgv_chinhanh.Size = new System.Drawing.Size(1152, 689);
            this.dgv_chinhanh.TabIndex = 38;
            this.dgv_chinhanh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_chinhanh_CellClick);
            // 
            // MaCN
            // 
            this.MaCN.HeaderText = "Mã chi nhánh";
            this.MaCN.Name = "MaCN";
            this.MaCN.ReadOnly = true;
            // 
            // TenCN
            // 
            this.TenCN.HeaderText = "Tên chi nhánh";
            this.TenCN.Name = "TenCN";
            this.TenCN.ReadOnly = true;
            // 
            // DiaChi
            // 
            this.DiaChi.HeaderText = "Địa chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 315);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Địa chỉ:";
            // 
            // txt_diachi
            // 
            this.txt_diachi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_diachi.Location = new System.Drawing.Point(30, 348);
            this.txt_diachi.Multiline = true;
            this.txt_diachi.Name = "txt_diachi";
            this.txt_diachi.Size = new System.Drawing.Size(330, 135);
            this.txt_diachi.TabIndex = 2;
            // 
            // ChiNhanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1534, 791);
            this.Controls.Add(this.dgv_chinhanh);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "ChiNhanh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChiNhanh";
            this.Load += new System.EventHandler(this.ChiNhanh_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_chinhanh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Thoat;
        private System.Windows.Forms.Button btn_DoanhThu;
        private System.Windows.Forms.Button btn_Quanly;
        private System.Windows.Forms.Button btn_HoaDon;
        private System.Windows.Forms.Button btn_BanHang;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_tencn;
        private System.Windows.Forms.TextBox txt_macn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.DataGridView dgv_chinhanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCN;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenCN;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_diachi;
    }
}