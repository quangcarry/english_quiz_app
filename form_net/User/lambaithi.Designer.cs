namespace form_net.User
{
    partial class lambaithi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(lambaithi));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.time = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCauD = new System.Windows.Forms.Label();
            this.lblCauC = new System.Windows.Forms.Label();
            this.lblCauB = new System.Windows.Forms.Label();
            this.lblCauA = new System.Windows.Forms.Label();
            this.radD = new System.Windows.Forms.RadioButton();
            this.radB = new System.Windows.Forms.RadioButton();
            this.radC = new System.Windows.Forms.RadioButton();
            this.radA = new System.Windows.Forms.RadioButton();
            this.lblCauHoi = new System.Windows.Forms.Label();
            this.lblCauSo = new System.Windows.Forms.Label();
            this.btnTruoc = new System.Windows.Forms.Button();
            this.btnNopBai = new System.Windows.Forms.Button();
            this.btnSau = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbxDatco = new System.Windows.Forms.CheckBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblThongtin = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(82)))), ((int)(((byte)(14)))));
            this.time.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time.ForeColor = System.Drawing.Color.White;
            this.time.Image = ((System.Drawing.Image)(resources.GetObject("time.Image")));
            this.time.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.time.Location = new System.Drawing.Point(7, 6);
            this.time.MinimumSize = new System.Drawing.Size(300, 40);
            this.time.Name = "time";
            this.time.Padding = new System.Windows.Forms.Padding(3);
            this.time.Size = new System.Drawing.Size(300, 40);
            this.time.TabIndex = 0;
            this.time.Text = "Thời gian còn lại : 00:00:00";
            this.time.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(48, 115);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(450, 463);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(1312, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(572, 1047);
            this.panel1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Location = new System.Drawing.Point(48, 32);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(450, 77);
            this.panel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label1);
            this.panel5.Location = new System.Drawing.Point(-48, -6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(531, 80);
            this.panel5.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(215, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Questionnaire";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.lblCauD);
            this.panel2.Controls.Add(this.lblCauC);
            this.panel2.Controls.Add(this.lblCauB);
            this.panel2.Controls.Add(this.lblCauA);
            this.panel2.Controls.Add(this.radD);
            this.panel2.Controls.Add(this.radB);
            this.panel2.Controls.Add(this.radC);
            this.panel2.Controls.Add(this.radA);
            this.panel2.Controls.Add(this.lblCauHoi);
            this.panel2.Controls.Add(this.lblCauSo);
            this.panel2.Controls.Add(this.btnTruoc);
            this.panel2.Controls.Add(this.btnNopBai);
            this.panel2.Controls.Add(this.btnSau);
            this.panel2.Location = new System.Drawing.Point(-1, 184);
            this.panel2.MinimumSize = new System.Drawing.Size(400, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1307, 872);
            this.panel2.TabIndex = 2;
            // 
            // lblCauD
            // 
            this.lblCauD.AutoSize = true;
            this.lblCauD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCauD.Location = new System.Drawing.Point(721, 482);
            this.lblCauD.MaximumSize = new System.Drawing.Size(400, 80);
            this.lblCauD.MinimumSize = new System.Drawing.Size(400, 80);
            this.lblCauD.Name = "lblCauD";
            this.lblCauD.Size = new System.Drawing.Size(400, 80);
            this.lblCauD.TabIndex = 18;
            this.lblCauD.Text = resources.GetString("lblCauD.Text");
            // 
            // lblCauC
            // 
            this.lblCauC.AutoSize = true;
            this.lblCauC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCauC.Location = new System.Drawing.Point(181, 482);
            this.lblCauC.MaximumSize = new System.Drawing.Size(400, 80);
            this.lblCauC.MinimumSize = new System.Drawing.Size(400, 80);
            this.lblCauC.Name = "lblCauC";
            this.lblCauC.Size = new System.Drawing.Size(400, 80);
            this.lblCauC.TabIndex = 17;
            this.lblCauC.Text = resources.GetString("lblCauC.Text");
            // 
            // lblCauB
            // 
            this.lblCauB.AutoSize = true;
            this.lblCauB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCauB.Location = new System.Drawing.Point(721, 266);
            this.lblCauB.MaximumSize = new System.Drawing.Size(400, 80);
            this.lblCauB.MinimumSize = new System.Drawing.Size(400, 80);
            this.lblCauB.Name = "lblCauB";
            this.lblCauB.Size = new System.Drawing.Size(400, 80);
            this.lblCauB.TabIndex = 16;
            this.lblCauB.Text = resources.GetString("lblCauB.Text");
            // 
            // lblCauA
            // 
            this.lblCauA.AutoSize = true;
            this.lblCauA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCauA.Location = new System.Drawing.Point(181, 266);
            this.lblCauA.MaximumSize = new System.Drawing.Size(400, 80);
            this.lblCauA.MinimumSize = new System.Drawing.Size(400, 80);
            this.lblCauA.Name = "lblCauA";
            this.lblCauA.Size = new System.Drawing.Size(400, 80);
            this.lblCauA.TabIndex = 15;
            this.lblCauA.Text = resources.GetString("lblCauA.Text");
            // 
            // radD
            // 
            this.radD.AutoSize = true;
            this.radD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radD.Location = new System.Drawing.Point(668, 478);
            this.radD.Name = "radD";
            this.radD.Size = new System.Drawing.Size(47, 29);
            this.radD.TabIndex = 14;
            this.radD.TabStop = true;
            this.radD.Text = "D";
            this.radD.UseVisualStyleBackColor = true;
            // 
            // radB
            // 
            this.radB.AutoSize = true;
            this.radB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radB.Location = new System.Drawing.Point(668, 262);
            this.radB.Name = "radB";
            this.radB.Size = new System.Drawing.Size(46, 29);
            this.radB.TabIndex = 13;
            this.radB.TabStop = true;
            this.radB.Text = "B";
            this.radB.UseVisualStyleBackColor = true;
            // 
            // radC
            // 
            this.radC.AutoSize = true;
            this.radC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radC.Location = new System.Drawing.Point(128, 478);
            this.radC.Name = "radC";
            this.radC.Size = new System.Drawing.Size(48, 29);
            this.radC.TabIndex = 12;
            this.radC.TabStop = true;
            this.radC.Text = "C";
            this.radC.UseVisualStyleBackColor = true;
            // 
            // radA
            // 
            this.radA.AutoSize = true;
            this.radA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radA.Location = new System.Drawing.Point(128, 262);
            this.radA.Name = "radA";
            this.radA.Size = new System.Drawing.Size(47, 29);
            this.radA.TabIndex = 11;
            this.radA.TabStop = true;
            this.radA.Text = "A";
            this.radA.UseVisualStyleBackColor = true;
            // 
            // lblCauHoi
            // 
            this.lblCauHoi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCauHoi.AutoSize = true;
            this.lblCauHoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblCauHoi.Location = new System.Drawing.Point(123, 115);
            this.lblCauHoi.MaximumSize = new System.Drawing.Size(1100, 100);
            this.lblCauHoi.MinimumSize = new System.Drawing.Size(1000, 100);
            this.lblCauHoi.Name = "lblCauHoi";
            this.lblCauHoi.Size = new System.Drawing.Size(1099, 100);
            this.lblCauHoi.TabIndex = 10;
            this.lblCauHoi.Text = resources.GetString("lblCauHoi.Text");
            // 
            // lblCauSo
            // 
            this.lblCauSo.AutoSize = true;
            this.lblCauSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblCauSo.Location = new System.Drawing.Point(49, 56);
            this.lblCauSo.Name = "lblCauSo";
            this.lblCauSo.Size = new System.Drawing.Size(54, 25);
            this.lblCauSo.TabIndex = 9;
            this.lblCauSo.Text = "Câu ";
            this.lblCauSo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnTruoc
            // 
            this.btnTruoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTruoc.BackColor = System.Drawing.Color.Transparent;
            this.btnTruoc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTruoc.BackgroundImage")));
            this.btnTruoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTruoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTruoc.FlatAppearance.BorderSize = 0;
            this.btnTruoc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnTruoc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnTruoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTruoc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTruoc.ForeColor = System.Drawing.Color.White;
            this.btnTruoc.Location = new System.Drawing.Point(3, 741);
            this.btnTruoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTruoc.MaximumSize = new System.Drawing.Size(148, 47);
            this.btnTruoc.MinimumSize = new System.Drawing.Size(148, 47);
            this.btnTruoc.Name = "btnTruoc";
            this.btnTruoc.Size = new System.Drawing.Size(148, 47);
            this.btnTruoc.TabIndex = 6;
            this.btnTruoc.Text = "Prev";
            this.btnTruoc.UseVisualStyleBackColor = false;
            this.btnTruoc.Visible = false;
            this.btnTruoc.Click += new System.EventHandler(this.btnTruoc_Click);
            // 
            // btnNopBai
            // 
            this.btnNopBai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNopBai.BackColor = System.Drawing.Color.Transparent;
            this.btnNopBai.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNopBai.BackgroundImage")));
            this.btnNopBai.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNopBai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNopBai.FlatAppearance.BorderSize = 0;
            this.btnNopBai.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnNopBai.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnNopBai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNopBai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNopBai.ForeColor = System.Drawing.Color.White;
            this.btnNopBai.Location = new System.Drawing.Point(1156, 741);
            this.btnNopBai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNopBai.MaximumSize = new System.Drawing.Size(148, 47);
            this.btnNopBai.MinimumSize = new System.Drawing.Size(148, 47);
            this.btnNopBai.Name = "btnNopBai";
            this.btnNopBai.Size = new System.Drawing.Size(148, 47);
            this.btnNopBai.TabIndex = 8;
            this.btnNopBai.Text = "Submit";
            this.btnNopBai.UseVisualStyleBackColor = false;
            this.btnNopBai.Visible = false;
            this.btnNopBai.Click += new System.EventHandler(this.btnNopBai_Click);
            // 
            // btnSau
            // 
            this.btnSau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSau.BackColor = System.Drawing.Color.Transparent;
            this.btnSau.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSau.BackgroundImage")));
            this.btnSau.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSau.FlatAppearance.BorderSize = 0;
            this.btnSau.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSau.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSau.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSau.ForeColor = System.Drawing.Color.White;
            this.btnSau.Location = new System.Drawing.Point(1156, 741);
            this.btnSau.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSau.MaximumSize = new System.Drawing.Size(148, 47);
            this.btnSau.MinimumSize = new System.Drawing.Size(148, 47);
            this.btnSau.Name = "btnSau";
            this.btnSau.Size = new System.Drawing.Size(148, 47);
            this.btnSau.TabIndex = 7;
            this.btnSau.Text = "Next";
            this.btnSau.UseVisualStyleBackColor = false;
            this.btnSau.Click += new System.EventHandler(this.btnSau_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panel3.Controls.Add(this.cbxDatco);
            this.panel3.Controls.Add(this.lblTrangThai);
            this.panel3.Controls.Add(this.lblThongtin);
            this.panel3.Location = new System.Drawing.Point(12, 111);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1304, 63);
            this.panel3.TabIndex = 3;
            // 
            // cbxDatco
            // 
            this.cbxDatco.AutoSize = true;
            this.cbxDatco.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxDatco.Location = new System.Drawing.Point(432, 19);
            this.cbxDatco.Name = "cbxDatco";
            this.cbxDatco.Size = new System.Drawing.Size(100, 29);
            this.cbxDatco.TabIndex = 3;
            this.cbxDatco.Text = "Set flag";
            this.cbxDatco.UseVisualStyleBackColor = true;
            this.cbxDatco.CheckStateChanged += new System.EventHandler(this.cbxDatco_CheckStateChanged);
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThai.Location = new System.Drawing.Point(228, 20);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(100, 25);
            this.lblTrangThai.TabIndex = 1;
            this.lblTrangThai.Text = "Trạng thái";
            // 
            // lblThongtin
            // 
            this.lblThongtin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThongtin.AutoSize = true;
            this.lblThongtin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongtin.Location = new System.Drawing.Point(30, 20);
            this.lblThongtin.Name = "lblThongtin";
            this.lblThongtin.Size = new System.Drawing.Size(108, 25);
            this.lblThongtin.TabIndex = 0;
            this.lblThongtin.Text = "Information";
            // 
            // lambaithi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1882, 1055);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.time);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "lambaithi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Làm bài thi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblThongtin;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbxDatco;
        private System.Windows.Forms.Button btnSau;
        private System.Windows.Forms.Button btnTruoc;
        private System.Windows.Forms.Button btnNopBai;
        private System.Windows.Forms.Label lblCauSo;
        private System.Windows.Forms.Label lblCauHoi;
        private System.Windows.Forms.RadioButton radD;
        private System.Windows.Forms.RadioButton radB;
        private System.Windows.Forms.RadioButton radC;
        private System.Windows.Forms.RadioButton radA;
        private System.Windows.Forms.Label lblCauD;
        private System.Windows.Forms.Label lblCauC;
        private System.Windows.Forms.Label lblCauB;
        private System.Windows.Forms.Label lblCauA;
    }
}