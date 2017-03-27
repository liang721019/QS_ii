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
    public partial class QS_ii_Quotes_add : Form
    {
        init_function fun = new init_function();
        public QS_ii_Quotes_add()
        {
            InitializeComponent();
        }

        private void QS_ii_main_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = true;       //最大化
            this.MinimizeBox = true;       //最小化
            this.FormBorderStyle = FormBorderStyle.FixedSingle;     //限制使用者改變form大小
            this.AutoSize = false;          //自動調整大小
            //this.Size = new System.Drawing.Size(1249, 882);      //設定Form大小           
            


        }

        private void button9_Click(object sender, EventArgs e)
        {
            QS_ii_Customer QS_C = new QS_ii_Customer();                         
                
            //設定init_Staff 新視窗的相對位置#############
            QS_C.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //############################################
            QS_C.ShowDialog(); 
        }

        private void button10_Click(object sender, EventArgs e)
        {
            QS_ii_Product QS_P = new QS_ii_Product();

            //設定init_Staff 新視窗的相對位置#############
            QS_P.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //############################################
            QS_P.ShowDialog(); 

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

    }
}
