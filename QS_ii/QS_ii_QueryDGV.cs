using function.lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QS_ii
{
    public partial class QS_ii_QueryDGV : Form 
    {
        

        public QS_ii_QueryDGV()
        {
            InitializeComponent();            
        }

        private void QS_ii_QueryDGV_Load(object sender, EventArgs e)
        {
            this.Text = "查詢";
            this.MaximizeBox = false;       //最大化
            this.MinimizeBox = false;       //最小化
            this.FormBorderStyle = FormBorderStyle.FixedSingle;     //限制使用者改變form大小
            this.AutoSize = false;          //自動調整大小

        }

        private void QS_ii_查詢button_Click(object sender, EventArgs e)
        {
            QS_ii_QueryDGV_QueryButton();          
        }

        public virtual void QS_ii_QueryDGV_QueryButton()        //查詢Button
        {

        }        
        
        public virtual void QS_ii_QueryDGV_DGView1()        //DGView1資料呼叫方法
        {
            
            
        }
        
        private void QS_ii_DGView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)        //DGV雙擊左鍵二下
        {
            if (e.RowIndex >= 0)
            {
                QS_ii_QueryDGV_DGView1();       //DGView1資料呼叫方法
                this.Close();
            }

        }

        public void QS_ii_DGView1_CellContentClick(object sender, DataGridViewCellEventArgs e)          //QS_ii_DGView1中的Checkbox
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                #region 內容
                //QS_ii_QS_ii_DGView1_CellContentClick();
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)QS_ii_DGView1.Rows[e.RowIndex].Cells[0];
                string flag = QS_ii_DGView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (flag == "1")     //被選取的資料行
                {
                    checkCell.Value = "0";
                }
                else
                {
                    checkCell.Value = "1";
                }
                #endregion
            }
        }

        public virtual void QS_ii_QueryDGV_加入button()           //加入Button
        {

        }

        private void QS_ii_加入button_Click(object sender, EventArgs e)
        {
            QS_ii_QueryDGV_加入button();
        }

    }
    
}
