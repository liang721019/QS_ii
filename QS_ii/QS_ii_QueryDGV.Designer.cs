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
            this.panel1 = new System.Windows.Forms.Panel();
            this.QS_ii_查詢button = new System.Windows.Forms.Button();
            this.QS_ii_QueryDGv_PID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.QS_ii_DGView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.QS_ii_DGView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QS_ii_DGView1.Location = new System.Drawing.Point(0, 0);
            this.QS_ii_DGView1.Margin = new System.Windows.Forms.Padding(5);
            this.QS_ii_DGView1.Name = "QS_ii_DGView1";
            this.QS_ii_DGView1.ReadOnly = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.QS_ii_DGView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.QS_ii_DGView1.RowTemplate.Height = 24;
            this.QS_ii_DGView1.Size = new System.Drawing.Size(610, 324);
            this.QS_ii_DGView1.TabIndex = 0;
            this.QS_ii_DGView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.QS_ii_DGView1_CellMouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.QS_ii_DGView1);
            this.panel1.Location = new System.Drawing.Point(14, 97);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 324);
            this.panel1.TabIndex = 1;
            // 
            // QS_ii_查詢button
            // 
            this.QS_ii_查詢button.Location = new System.Drawing.Point(498, 14);
            this.QS_ii_查詢button.Name = "QS_ii_查詢button";
            this.QS_ii_查詢button.Size = new System.Drawing.Size(114, 29);
            this.QS_ii_查詢button.TabIndex = 2;
            this.QS_ii_查詢button.Text = "查詢";
            this.QS_ii_查詢button.UseVisualStyleBackColor = true;
            this.QS_ii_查詢button.Click += new System.EventHandler(this.QS_ii_查詢button_Click);
            // 
            // QS_ii_QueryDGv_PID
            // 
            this.QS_ii_QueryDGv_PID.Location = new System.Drawing.Point(96, 14);
            this.QS_ii_QueryDGv_PID.Name = "QS_ii_QueryDGv_PID";
            this.QS_ii_QueryDGv_PID.Size = new System.Drawing.Size(160, 29);
            this.QS_ii_QueryDGv_PID.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "商品編號";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.QS_ii_查詢button);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.QS_ii_QueryDGv_PID);
            this.panel2.Location = new System.Drawing.Point(12, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(612, 60);
            this.panel2.TabIndex = 5;
            // 
            // QS_ii_QueryDGV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(644, 441);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "QS_ii_QueryDGV";
            this.Text = "QS_ii_QueryDGV";
            this.Load += new System.EventHandler(this.QS_ii_QueryDGV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QS_ii_DGView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button QS_ii_查詢button;
        internal System.Windows.Forms.DataGridView QS_ii_DGView1;
        private System.Windows.Forms.TextBox QS_ii_QueryDGv_PID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
    }
}