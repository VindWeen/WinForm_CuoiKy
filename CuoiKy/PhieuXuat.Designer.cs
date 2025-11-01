namespace CuoiKy
{
    partial class PhieuXuat
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
            this.btn_DoanhThu = new System.Windows.Forms.Button();
            this.btn_Quanly = new System.Windows.Forms.Button();
            this.btn_HoaDon = new System.Windows.Forms.Button();
            this.btn_BanHang = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btn_DoanhThu
            // 
            this.btn_DoanhThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(201)))), ((int)(((byte)(238)))));
            this.btn_DoanhThu.Image = global::CuoiKy.Properties.Resources.finance;
            this.btn_DoanhThu.Location = new System.Drawing.Point(617, 12);
            this.btn_DoanhThu.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btn_DoanhThu.Name = "btn_DoanhThu";
            this.btn_DoanhThu.Size = new System.Drawing.Size(154, 73);
            this.btn_DoanhThu.TabIndex = 17;
            this.btn_DoanhThu.UseVisualStyleBackColor = false;
            // 
            // btn_Quanly
            // 
            this.btn_Quanly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(125)))), ((int)(((byte)(85)))));
            this.btn_Quanly.Image = global::CuoiKy.Properties.Resources.package;
            this.btn_Quanly.Location = new System.Drawing.Point(420, 12);
            this.btn_Quanly.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btn_Quanly.Name = "btn_Quanly";
            this.btn_Quanly.Size = new System.Drawing.Size(154, 73);
            this.btn_Quanly.TabIndex = 18;
            this.btn_Quanly.UseVisualStyleBackColor = false;
            // 
            // btn_HoaDon
            // 
            this.btn_HoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(226)))), ((int)(((byte)(250)))));
            this.btn_HoaDon.Image = global::CuoiKy.Properties.Resources.receipt;
            this.btn_HoaDon.Location = new System.Drawing.Point(221, 12);
            this.btn_HoaDon.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btn_HoaDon.Name = "btn_HoaDon";
            this.btn_HoaDon.Size = new System.Drawing.Size(154, 73);
            this.btn_HoaDon.TabIndex = 16;
            this.btn_HoaDon.UseVisualStyleBackColor = false;
            // 
            // btn_BanHang
            // 
            this.btn_BanHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(206)))), ((int)(((byte)(136)))));
            this.btn_BanHang.Image = global::CuoiKy.Properties.Resources.shopping;
            this.btn_BanHang.Location = new System.Drawing.Point(24, 12);
            this.btn_BanHang.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btn_BanHang.Name = "btn_BanHang";
            this.btn_BanHang.Size = new System.Drawing.Size(154, 73);
            this.btn_BanHang.TabIndex = 15;
            this.btn_BanHang.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(-5, 104);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(3084, 694);
            this.panel1.TabIndex = 19;
            // 
            // PhieuXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1534, 791);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_DoanhThu);
            this.Controls.Add(this.btn_Quanly);
            this.Controls.Add(this.btn_HoaDon);
            this.Controls.Add(this.btn_BanHang);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "PhieuXuat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PhieuXuat";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_DoanhThu;
        private System.Windows.Forms.Button btn_Quanly;
        private System.Windows.Forms.Button btn_HoaDon;
        private System.Windows.Forms.Button btn_BanHang;
        private System.Windows.Forms.Panel panel1;
    }
}