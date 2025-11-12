namespace CuoiKy
{
    partial class ThemPhieuXuat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThemPhieuXuat));
            this.button2 = new System.Windows.Forms.Button();
            this.btn_taophieu = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_sopx = new System.Windows.Forms.TextBox();
            this.cb_chinhanh = new System.Windows.Forms.ComboBox();
            this.dgvCTPX = new System.Windows.Forms.DataGridView();
            this.MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cb_sanpham = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTPX)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(854, 601);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 51);
            this.button2.TabIndex = 30;
            this.button2.Text = "Đóng";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_taophieu
            // 
            this.btn_taophieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(181)))), ((int)(((byte)(59)))));
            this.btn_taophieu.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_taophieu.ForeColor = System.Drawing.Color.Black;
            this.btn_taophieu.Location = new System.Drawing.Point(699, 601);
            this.btn_taophieu.Name = "btn_taophieu";
            this.btn_taophieu.Size = new System.Drawing.Size(132, 51);
            this.btn_taophieu.TabIndex = 29;
            this.btn_taophieu.Text = "Xuất";
            this.btn_taophieu.UseVisualStyleBackColor = false;
            this.btn_taophieu.Click += new System.EventHandler(this.btn_taophieu_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.label4.Location = new System.Drawing.Point(403, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 32);
            this.label4.TabIndex = 26;
            this.label4.Text = "Đến chi nhánh:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.label1.Location = new System.Drawing.Point(44, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 32);
            this.label1.TabIndex = 20;
            this.label1.Text = "Số phiếu xuất:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_sopx
            // 
            this.txt_sopx.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_sopx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_sopx.Location = new System.Drawing.Point(191, 50);
            this.txt_sopx.Name = "txt_sopx";
            this.txt_sopx.ReadOnly = true;
            this.txt_sopx.Size = new System.Drawing.Size(135, 35);
            this.txt_sopx.TabIndex = 31;
            // 
            // cb_chinhanh
            // 
            this.cb_chinhanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_chinhanh.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_chinhanh.FormattingEnabled = true;
            this.cb_chinhanh.Location = new System.Drawing.Point(556, 50);
            this.cb_chinhanh.Name = "cb_chinhanh";
            this.cb_chinhanh.Size = new System.Drawing.Size(430, 38);
            this.cb_chinhanh.TabIndex = 32;
            // 
            // dgvCTPX
            // 
            this.dgvCTPX.AllowUserToAddRows = false;
            this.dgvCTPX.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCTPX.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCTPX.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvCTPX.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCTPX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCTPX.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSP,
            this.TenSP,
            this.SL,
            this.delete});
            this.dgvCTPX.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgvCTPX.Location = new System.Drawing.Point(38, 176);
            this.dgvCTPX.Name = "dgvCTPX";
            this.dgvCTPX.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCTPX.RowHeadersVisible = false;
            this.dgvCTPX.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCTPX.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.dgvCTPX.RowTemplate.Height = 35;
            this.dgvCTPX.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCTPX.Size = new System.Drawing.Size(948, 400);
            this.dgvCTPX.TabIndex = 33;
            this.dgvCTPX.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCTPX_CellClick);
            this.dgvCTPX.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dgvCTPX.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvCTPX_EditingControlShowing);
            // 
            // MaSP
            // 
            this.MaSP.FillWeight = 50F;
            this.MaSP.HeaderText = "Mã sản phẩm";
            this.MaSP.Name = "MaSP";
            this.MaSP.ReadOnly = true;
            this.MaSP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MaSP.Width = 265;
            // 
            // TenSP
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TenSP.DefaultCellStyle = dataGridViewCellStyle1;
            this.TenSP.HeaderText = "Tên sản phẩm";
            this.TenSP.Name = "TenSP";
            this.TenSP.ReadOnly = true;
            this.TenSP.Width = 460;
            // 
            // SL
            // 
            this.SL.HeaderText = "Số lượng";
            this.SL.Name = "SL";
            this.SL.Width = 120;
            // 
            // delete
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "🗑️";
            this.delete.DefaultCellStyle = dataGridViewCellStyle2;
            this.delete.HeaderText = "Xóa";
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Text = "Xóa";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cb_sanpham);
            this.panel1.Controls.Add(this.dgvCTPX);
            this.panel1.Controls.Add(this.cb_chinhanh);
            this.panel1.Controls.Add(this.txt_sopx);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btn_taophieu);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1031, 685);
            this.panel1.TabIndex = 34;
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
            this.cb_sanpham.Location = new System.Drawing.Point(240, 119);
            this.cb_sanpham.Name = "cb_sanpham";
            this.cb_sanpham.Size = new System.Drawing.Size(746, 38);
            this.cb_sanpham.TabIndex = 34;
            this.cb_sanpham.SelectedIndexChanged += new System.EventHandler(this.cb_sanpham_SelectedIndexChanged);
            this.cb_sanpham.TextUpdate += new System.EventHandler(this.cb_sanpham_TextUpdate);
            this.cb_sanpham.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb_sanpham_KeyDown);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.label2.Location = new System.Drawing.Point(44, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 32);
            this.label2.TabIndex = 26;
            this.label2.Text = "Nhập sản phẩm:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ThemPhieuXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1031, 685);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "ThemPhieuXuat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ThemPhieuXuat";
            this.Load += new System.EventHandler(this.ThemPhieuXuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTPX)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_taophieu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_sopx;
        private System.Windows.Forms.ComboBox cb_chinhanh;
        private System.Windows.Forms.DataGridView dgvCTPX;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cb_sanpham;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn SL;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
    }
}