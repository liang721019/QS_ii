namespace QS_ii
{
    partial class QS_ii_QueryDGV
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
            this.QS_ii_DGView1 = new System.Windows.Forms.DataGridView();
            this.QS_ii_QueryDGV_Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.QS_ii_查詢button = new System.Windows.Forms.Button();
            this.QS_ii_QueryDGv_PID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.init_panel = new System.Windows.Forms.Panel();
            this.QS_ii_加入button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.QS_ii_DGView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.init_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // QS_ii_DGView1
            // 
            this.QS_ii_DGView1.AllowUserToAddRows = false;
            this.QS_ii_DGView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.QS_ii_DGView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.QS_ii_DGView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.QS_ii_DGView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.QS_ii_DGView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.QS_ii_QueryDGV_Column1});
            this.QS_ii_DGView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QS_ii_DGView1.Location = new System.Drawing.Point(0, 0);
            this.QS_ii_DGView1.Margin = new System.Windows.Forms.Padding(5);
            this.QS_ii_DGView1.Name = "QS_ii_DGView1";
            this.QS_ii_DGView1.ReadOnly = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.QS_ii_DGView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.QS_ii_DGView1.RowTemplate.Height = 24;
            this.QS_ii_DGView1.Size = new System.Drawing.Size(618, 376);
            this.QS_ii_DGView1.TabIndex = 0;
            this.QS_ii_DGView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.QS_ii_DGView1_CellContentClick);
            this.QS_ii_DGView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.QS_ii_DGView1_CellMouseDoubleClick);
            // 
            // QS_ii_QueryDGV_Column1
            // 
            this.QS_ii_QueryDGV_Column1.FalseValue = "0";
            this.QS_ii_QueryDGV_Column1.HeaderText = "選取";
            this.QS_ii_QueryDGV_Column1.Name = "QS_ii_QueryDGV_Column1";
            this.QS_ii_QueryDGV_Column1.ReadOnly = true;
            this.QS_ii_QueryDGV_Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.QS_ii_QueryDGV_Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.QS_ii_QueryDGV_Column1.TrueValue = "1";
            this.QS_ii_QueryDGV_Column1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.QS_ii_DGView1);
            this.panel1.Location = new System.Drawing.Point(12, 69);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(618, 376);
            this.panel1.TabIndex = 1;
            // 
            // QS_ii_查詢button
            // 
            this.QS_ii_查詢button.Location = new System.Drawing.Point(507, 9);
            this.QS_ii_查詢button.Name = "QS_ii_查詢button";
            this.QS_ii_查詢button.Size = new System.Drawing.Size(98, 29);
            this.QS_ii_查詢button.TabIndex = 2;
            this.QS_ii_查詢button.Text = "查詢";
            this.QS_ii_查詢button.UseVisualStyleBackColor = true;
            this.QS_ii_查詢button.Click += new System.EventHandler(this.QS_ii_查詢button_Click);
            // 
            // QS_ii_QueryDGv_PID
            // 
            this.QS_ii_QueryDGv_PID.Location = new System.Drawing.Point(100, 9);
            this.QS_ii_QueryDGv_PID.Name = "QS_ii_QueryDGv_PID";
            this.QS_ii_QueryDGv_PID.Size = new System.Drawing.Size(160, 29);
            this.QS_ii_QueryDGv_PID.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "商品編號:";
            // 
            // init_panel
            // 
            this.init_panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.init_panel.Controls.Add(this.QS_ii_加入button);
            this.init_panel.Controls.Add(this.QS_ii_查詢button);
            this.init_panel.Controls.Add(this.label1);
            this.init_panel.Controls.Add(this.QS_ii_QueryDGv_PID);
            this.init_panel.Location = new System.Drawing.Point(12, 13);
            this.init_panel.Name = "init_panel";
            this.init_panel.Size = new System.Drawing.Size(618, 48);
            this.init_panel.TabIndex = 5;
            // 
            // QS_ii_加入button
            // 
            this.QS_ii_加入button.Location = new System.Drawing.Point(403, 10);
            this.QS_ii_加入button.Name = "QS_ii_加入button";
            this.QS_ii_加入button.Size = new System.Drawing.Size(98, 28);
            this.QS_ii_加入button.TabIndex = 5;
            this.QS_ii_加入button.Text = "加入";
            this.QS_ii_加入button.UseVisualStyleBackColor = true;
            this.QS_ii_加入button.Click += new System.EventHandler(this.QS_ii_加入button_Click);
            // 
            // QS_ii_QueryDGV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(644, 459);
            this.Controls.Add(this.init_panel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "QS_ii_QueryDGV";
            this.Text = "QS_ii_QueryDGV";
            this.Load += new System.EventHandler(this.QS_ii_QueryDGV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QS_ii_DGView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.init_panel.ResumeLayout(false);
            this.init_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button QS_ii_查詢button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel init_panel;
        public System.Windows.Forms.TextBox QS_ii_QueryDGv_PID;
        internal System.Windows.Forms.DataGridView QS_ii_DGView1;
        internal System.Windows.Forms.DataGridViewCheckBoxColumn QS_ii_QueryDGV_Column1;
        private System.Windows.Forms.Button QS_ii_加入button;
    }
}