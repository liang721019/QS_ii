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
    }
}
