namespace ThucTapNhom1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txttenpx = new System.Windows.Forms.TextBox();
            this.cbbfind2 = new System.Windows.Forms.ComboBox();
            this.cbbidkhpx = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpngaypx = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtidpx = new System.Windows.Forms.TextBox();
            this.txttienpx = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txthtttpx = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.khhn = new System.Windows.Forms.Button();
            this.btnshowkh = new System.Windows.Forms.Button();
            this.khnothn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbbfindpx = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btntongpx = new System.Windows.Forms.Button();
            this.btnhuypx = new System.Windows.Forms.Button();
            this.btnluupx = new System.Windows.Forms.Button();
            this.btnloadpx = new System.Windows.Forms.Button();
            this.btnxoapx = new System.Windows.Forms.Button();
            this.btnsuapx = new System.Windows.Forms.Button();
            this.btnthempx = new System.Windows.Forms.Button();
            this.dgvPX = new System.Windows.Forms.DataGridView();
            this.dgvkhpx = new System.Windows.Forms.DataGridView();
            this.quanLyBanHangDataSet = new ThucTapNhom1.QuanLyBanHangDataSet();
            this.sanPhamBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sanPhamTableAdapter = new ThucTapNhom1.QuanLyBanHangDataSetTableAdapters.SanPhamTableAdapter();
            this.quanLyBanHangDataSet1 = new ThucTapNhom1.QuanLyBanHangDataSet1();
            this.khachHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.khachHangTableAdapter = new ThucTapNhom1.QuanLyBanHangDataSet1TableAdapters.KhachHangTableAdapter();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvkhpx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyBanHangDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sanPhamBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyBanHangDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.khachHangBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(4, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1138, 592);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Aqua;
            this.tabPage1.Controls.Add(this.dgvkhpx);
            this.tabPage1.Controls.Add(this.dgvPX);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1130, 566);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(728, 369);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox3.Controls.Add(this.txttenpx);
            this.groupBox3.Controls.Add(this.cbbfind2);
            this.groupBox3.Controls.Add(this.cbbidkhpx);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.dtpngaypx);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtidpx);
            this.groupBox3.Controls.Add(this.txttienpx);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txthtttpx);
            this.groupBox3.Location = new System.Drawing.Point(46, 24);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1028, 141);
            this.groupBox3.TabIndex = 45;
            this.groupBox3.TabStop = false;
            // 
            // txttenpx
            // 
            this.txttenpx.Location = new System.Drawing.Point(452, 35);
            this.txttenpx.Name = "txttenpx";
            this.txttenpx.Size = new System.Drawing.Size(133, 20);
            this.txttenpx.TabIndex = 25;
            // 
            // cbbfind2
            // 
            this.cbbfind2.DisplayMember = "NgayBan";
            this.cbbfind2.FormattingEnabled = true;
            this.cbbfind2.Location = new System.Drawing.Point(64, 138);
            this.cbbfind2.Name = "cbbfind2";
            this.cbbfind2.Size = new System.Drawing.Size(121, 21);
            this.cbbfind2.TabIndex = 23;
            this.cbbfind2.ValueMember = "NgayBan";
            // 
            // cbbidkhpx
            // 
            this.cbbidkhpx.DataSource = this.khachHangBindingSource;
            this.cbbidkhpx.DisplayMember = "idkhachhang";
            this.cbbidkhpx.FormattingEnabled = true;
            this.cbbidkhpx.Location = new System.Drawing.Point(648, 34);
            this.cbbidkhpx.Name = "cbbidkhpx";
            this.cbbidkhpx.Size = new System.Drawing.Size(200, 21);
            this.cbbidkhpx.TabIndex = 6;
            this.cbbidkhpx.ValueMember = "idkhachhang";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(591, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "IDKH";
            // 
            // dtpngaypx
            // 
            this.dtpngaypx.Location = new System.Drawing.Point(648, 96);
            this.dtpngaypx.Name = "dtpngaypx";
            this.dtpngaypx.Size = new System.Drawing.Size(200, 20);
            this.dtpngaypx.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(197, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "IDPX";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tong Tien";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(410, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "HTTT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(391, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ten Hang";
            // 
            // txtidpx
            // 
            this.txtidpx.Location = new System.Drawing.Point(242, 39);
            this.txtidpx.Name = "txtidpx";
            this.txtidpx.Size = new System.Drawing.Size(145, 20);
            this.txtidpx.TabIndex = 1;
            // 
            // txttienpx
            // 
            this.txttienpx.Location = new System.Drawing.Point(242, 101);
            this.txttienpx.Name = "txttienpx";
            this.txttienpx.Size = new System.Drawing.Size(145, 20);
            this.txttienpx.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(591, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "NgayBan";
            // 
            // txthtttpx
            // 
            this.txthtttpx.Location = new System.Drawing.Point(452, 98);
            this.txthtttpx.Name = "txthtttpx";
            this.txthtttpx.Size = new System.Drawing.Size(133, 20);
            this.txthtttpx.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.khhn);
            this.groupBox1.Controls.Add(this.btnshowkh);
            this.groupBox1.Controls.Add(this.khnothn);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbbfindpx);
            this.groupBox1.Location = new System.Drawing.Point(309, 171);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 95);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            // 
            // khhn
            // 
            this.khhn.Location = new System.Drawing.Point(223, 16);
            this.khhn.Name = "khhn";
            this.khhn.Size = new System.Drawing.Size(75, 23);
            this.khhn.TabIndex = 30;
            this.khhn.Text = "KH ở HN";
            this.khhn.UseVisualStyleBackColor = true;
            this.khhn.Click += new System.EventHandler(this.khhn_Click_1);
            // 
            // btnshowkh
            // 
            this.btnshowkh.Location = new System.Drawing.Point(334, 16);
            this.btnshowkh.Name = "btnshowkh";
            this.btnshowkh.Size = new System.Drawing.Size(75, 73);
            this.btnshowkh.TabIndex = 29;
            this.btnshowkh.Text = "Hiển Thị KH";
            this.btnshowkh.UseVisualStyleBackColor = true;
            this.btnshowkh.Click += new System.EventHandler(this.btnshowkh_Click_1);
            // 
            // khnothn
            // 
            this.khnothn.Location = new System.Drawing.Point(223, 66);
            this.khnothn.Name = "khnothn";
            this.khnothn.Size = new System.Drawing.Size(75, 23);
            this.khnothn.TabIndex = 29;
            this.khnothn.Text = "KH ko ở HN";
            this.khnothn.UseVisualStyleBackColor = true;
            this.khnothn.Click += new System.EventHandler(this.khnothn_Click_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(78, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Theo Tên SP";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Tìm Kiếm";
            // 
            // cbbfindpx
            // 
            this.cbbfindpx.DataSource = this.sanPhamBindingSource;
            this.cbbfindpx.DisplayMember = "TenHang";
            this.cbbfindpx.FormattingEnabled = true;
            this.cbbfindpx.Location = new System.Drawing.Point(62, 43);
            this.cbbfindpx.Name = "cbbfindpx";
            this.cbbfindpx.Size = new System.Drawing.Size(121, 21);
            this.cbbfindpx.TabIndex = 20;
            this.cbbfindpx.ValueMember = "TenHang";
            this.cbbfindpx.SelectedIndexChanged += new System.EventHandler(this.cbbfindpx_SelectedIndexChanged_1);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.btntongpx);
            this.groupBox2.Controls.Add(this.btnhuypx);
            this.groupBox2.Controls.Add(this.btnluupx);
            this.groupBox2.Controls.Add(this.btnloadpx);
            this.groupBox2.Controls.Add(this.btnxoapx);
            this.groupBox2.Controls.Add(this.btnsuapx);
            this.groupBox2.Controls.Add(this.btnthempx);
            this.groupBox2.Location = new System.Drawing.Point(46, 272);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1019, 100);
            this.groupBox2.TabIndex = 47;
            this.groupBox2.TabStop = false;
            // 
            // btntongpx
            // 
            this.btntongpx.Location = new System.Drawing.Point(860, 48);
            this.btntongpx.Name = "btntongpx";
            this.btntongpx.Size = new System.Drawing.Size(75, 23);
            this.btntongpx.TabIndex = 29;
            this.btntongpx.Text = "Tổng Thu";
            this.btntongpx.UseVisualStyleBackColor = true;
            this.btntongpx.Click += new System.EventHandler(this.btntongpx_Click_1);
            // 
            // btnhuypx
            // 
            this.btnhuypx.Location = new System.Drawing.Point(583, 48);
            this.btnhuypx.Name = "btnhuypx";
            this.btnhuypx.Size = new System.Drawing.Size(75, 23);
            this.btnhuypx.TabIndex = 17;
            this.btnhuypx.Text = "Hủy";
            this.btnhuypx.UseVisualStyleBackColor = true;
            this.btnhuypx.Click += new System.EventHandler(this.btnhuypx_Click_1);
            // 
            // btnluupx
            // 
            this.btnluupx.Location = new System.Drawing.Point(441, 48);
            this.btnluupx.Name = "btnluupx";
            this.btnluupx.Size = new System.Drawing.Size(75, 23);
            this.btnluupx.TabIndex = 16;
            this.btnluupx.Text = "Lưu";
            this.btnluupx.UseVisualStyleBackColor = true;
            this.btnluupx.Click += new System.EventHandler(this.btnluupx_Click_1);
            // 
            // btnloadpx
            // 
            this.btnloadpx.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.btnloadpx.Location = new System.Drawing.Point(725, 48);
            this.btnloadpx.Name = "btnloadpx";
            this.btnloadpx.Size = new System.Drawing.Size(75, 23);
            this.btnloadpx.TabIndex = 22;
            this.btnloadpx.Text = "Load Lại";
            this.btnloadpx.UseVisualStyleBackColor = true;
            this.btnloadpx.Click += new System.EventHandler(this.btnloadpx_Click_1);
            // 
            // btnxoapx
            // 
            this.btnxoapx.Location = new System.Drawing.Point(305, 48);
            this.btnxoapx.Name = "btnxoapx";
            this.btnxoapx.Size = new System.Drawing.Size(75, 23);
            this.btnxoapx.TabIndex = 15;
            this.btnxoapx.Text = "Xóa";
            this.btnxoapx.UseVisualStyleBackColor = true;
            this.btnxoapx.Click += new System.EventHandler(this.btnxoapx_Click_1);
            // 
            // btnsuapx
            // 
            this.btnsuapx.Location = new System.Drawing.Point(174, 48);
            this.btnsuapx.Name = "btnsuapx";
            this.btnsuapx.Size = new System.Drawing.Size(75, 23);
            this.btnsuapx.TabIndex = 14;
            this.btnsuapx.Text = "Sửa";
            this.btnsuapx.UseVisualStyleBackColor = true;
            this.btnsuapx.Click += new System.EventHandler(this.btnsuapx_Click);
            // 
            // btnthempx
            // 
            this.btnthempx.Location = new System.Drawing.Point(38, 48);
            this.btnthempx.Name = "btnthempx";
            this.btnthempx.Size = new System.Drawing.Size(75, 23);
            this.btnthempx.TabIndex = 13;
            this.btnthempx.Text = "Thêm";
            this.btnthempx.UseVisualStyleBackColor = true;
            this.btnthempx.Click += new System.EventHandler(this.btnthempx_Click);
            // 
            // dgvPX
            // 
            this.dgvPX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPX.Location = new System.Drawing.Point(16, 393);
            this.dgvPX.Name = "dgvPX";
            this.dgvPX.Size = new System.Drawing.Size(615, 154);
            this.dgvPX.TabIndex = 48;
            this.dgvPX.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPX_CellContentDoubleClick_1);
            // 
            // dgvkhpx
            // 
            this.dgvkhpx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvkhpx.Location = new System.Drawing.Point(676, 393);
            this.dgvkhpx.Name = "dgvkhpx";
            this.dgvkhpx.Size = new System.Drawing.Size(389, 154);
            this.dgvkhpx.TabIndex = 49;
            // 
            // quanLyBanHangDataSet
            // 
            this.quanLyBanHangDataSet.DataSetName = "QuanLyBanHangDataSet";
            this.quanLyBanHangDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sanPhamBindingSource
            // 
            this.sanPhamBindingSource.DataMember = "SanPham";
            this.sanPhamBindingSource.DataSource = this.quanLyBanHangDataSet;
            // 
            // sanPhamTableAdapter
            // 
            this.sanPhamTableAdapter.ClearBeforeFill = true;
            // 
            // quanLyBanHangDataSet1
            // 
            this.quanLyBanHangDataSet1.DataSetName = "QuanLyBanHangDataSet1";
            this.quanLyBanHangDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // khachHangBindingSource
            // 
            this.khachHangBindingSource.DataMember = "KhachHang";
            this.khachHangBindingSource.DataSource = this.quanLyBanHangDataSet1;
            // 
            // khachHangTableAdapter
            // 
            this.khachHangTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 594);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvkhpx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyBanHangDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sanPhamBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyBanHangDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.khachHangBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvPX;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btntongpx;
        private System.Windows.Forms.Button btnhuypx;
        private System.Windows.Forms.Button btnluupx;
        private System.Windows.Forms.Button btnloadpx;
        private System.Windows.Forms.Button btnxoapx;
        private System.Windows.Forms.Button btnsuapx;
        private System.Windows.Forms.Button btnthempx;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button khhn;
        private System.Windows.Forms.Button btnshowkh;
        private System.Windows.Forms.Button khnothn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbbfindpx;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txttenpx;
        private System.Windows.Forms.ComboBox cbbfind2;
        private System.Windows.Forms.ComboBox cbbidkhpx;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpngaypx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtidpx;
        private System.Windows.Forms.TextBox txttienpx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txthtttpx;
        private System.Windows.Forms.DataGridView dgvkhpx;
        private QuanLyBanHangDataSet quanLyBanHangDataSet;
        private System.Windows.Forms.BindingSource sanPhamBindingSource;
        private QuanLyBanHangDataSetTableAdapters.SanPhamTableAdapter sanPhamTableAdapter;
        private QuanLyBanHangDataSet1 quanLyBanHangDataSet1;
        private System.Windows.Forms.BindingSource khachHangBindingSource;
        private QuanLyBanHangDataSet1TableAdapters.KhachHangTableAdapter khachHangTableAdapter;
    }
}

