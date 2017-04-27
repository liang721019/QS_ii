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
    public partial class QS_ii_ProductSC : Form
    {


        QS_ii_function fun = new QS_ii_function();
        public QS_ii_Quotes_add QS_iiQ_add;

        public QS_ii_ProductSC(QS_ii_Quotes_add x)
        {
            InitializeComponent();
            QS_iiQ_add = x;            
        }

        private void QS_ii_ProductSC_Load(object sender, EventArgs e)
        {
            default_status();            //預設狀態
        }

        #region 變數
        //====================================================

        //====================================================
        #endregion

        #region 方法
        //====================================================
        private void default_status()            //預設狀態
        {
            this.Text = "通路";
            this.MaximizeBox = false;       //最大化
            this.MinimizeBox = false;       //最小化
            this.FormBorderStyle = FormBorderStyle.FixedSingle;     //限制使用者改變form大小
            QS_ii_ProductSC_DGV1.DataSource = QS_iiQ_add.QSiiDB.QS_ii_ProductSC;

            this.AutoSize = false;          //自動調整大小
            fun.EoD_Panel_btn(ProductSC_panel1, true);
            ProductSC_Status_info.Visible = false;
            QS_ii_ProductSC_儲存Button.Visible = false;
            QS_ii_ProductSC_取消Button.Visible = false;
            QS_ii_Product多選.Visible = false;
            QS_ii_Product新增.Visible = false;
            QS_ii_Product刪除.Visible = false;

        }

        private void start_status(Button x)      //啟動狀態
        {
            if (x == QS_ii_ProductSC_新增Button)
            {
                ProductSC_Status_info.Text = "新增";
                ProductSC_Status_info.Visible = true;
                fun.EoD_Panel_btn(ProductSC_panel1, false);
                QS_ii_ProductSC_儲存Button.Visible = true;
                QS_ii_ProductSC_儲存Button.Enabled = true;
                QS_ii_ProductSC_取消Button.Visible = true;
                QS_ii_ProductSC_取消Button.Enabled = true;
                QS_ii_Product多選.Visible = true;
                QS_ii_Product新增.Visible = true;
                QS_ii_Product刪除.Visible = true;


            }
            else if (x == QS_ii_ProductSC_修改Button)
            {
                ProductSC_Status_info.Text = "修改";
                ProductSC_Status_info.Visible = true;
                fun.EoD_Panel_btn(ProductSC_panel1, false);
                QS_ii_ProductSC_儲存Button.Visible = true;
                QS_ii_ProductSC_儲存Button.Enabled = true;
                QS_ii_ProductSC_取消Button.Visible = true;
                QS_ii_ProductSC_取消Button.Enabled = true;
                QS_ii_Product多選.Visible = true;
                QS_ii_Product新增.Visible = true;
                QS_ii_Product刪除.Visible = true;


            }
            else if (x == QS_ii_ProductSC_刪除Button)
            {

            }
            else if (x == QS_ii_ProductSC_查詢Button)
            {

            }
            else if (x == QS_ii_ProductSC_儲存Button)
            {

            }
            else if (x == QS_ii_ProductSC_取消Button)
            {
                ProductSC_Status_info.Text = "瀏覽";
                ProductSC_Status_info.Visible = false;
                fun.EoD_Panel_btn(ProductSC_panel1, true);
                QS_ii_ProductSC_儲存Button.Visible = false;
                QS_ii_ProductSC_儲存Button.Enabled = false;
                QS_ii_ProductSC_取消Button.Visible = false;
                QS_ii_ProductSC_取消Button.Enabled = false;
                QS_ii_Product多選.Visible = false;
                QS_ii_Product新增.Visible = false;
                QS_ii_Product刪除.Visible = false;
                QS_iiQ_add.QSiiDB.QS_ii_ProductSC.RejectChanges();

            }
        }

        private void QS_ii_ProductSC_Add()           //新增
        {


        }

        private void QS_ii_ProductSC_Modify()        //修改
        {

        }

        private void QS_ii_ProductSC_Delete()        //刪除
        {

        }

        private void QS_ii_ProductSC_Save()          //儲存
        {
            #region 內容

            #endregion
        }

        private void QS_ii_ProductSC_Cancel()        //取消
        {

            start_status(QS_ii_ProductSC_取消Button);
        }

        private void QS_ii_Product新增_Open()         //明細新增的方法
        {
            #region 內容
            QS_ii_ProductSC_T ProductSC_ADD = new QS_ii_ProductSC_T(this);
            ProductSC_ADD.QS_ii_QueryDGV_Column1.Visible = false;           //自訂DGV欄位設定顯示
            QS_iiQ_add.Product_Query(ProductSC_ADD.QS_ii_DGView1);        //商品主檔查詢            
            //設定init_Staff 新視窗的相對位置#############
            ProductSC_ADD.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //############################################            
            ProductSC_ADD.ShowDialog();
            #endregion

        }

        private void QS_ii_Product刪除_Open()         //明細刪除的方法
        {
            #region 內容

            #endregion
        }

        private void QS_ii_Product多選_Open()         //明細多選的方法
        {
            #region 內容

            #endregion
        }



        //====================================================
        #endregion

        #region Button


        private void QS_ii_ProductSC_新增Button_Click(object sender, EventArgs e)
        {
            start_status(QS_ii_ProductSC_新增Button);
        }

        private void QS_ii_ProductSC_修改Button_Click(object sender, EventArgs e)
        {
            start_status(QS_ii_ProductSC_修改Button);
        }

        private void QS_ii_ProductSC_刪除Button_Click(object sender, EventArgs e)
        {
            start_status(QS_ii_ProductSC_刪除Button);
        }

        private void QS_ii_ProductSC_查詢Button_Click(object sender, EventArgs e)
        {
            start_status(QS_ii_ProductSC_查詢Button);
        }
        private void QS_ii_ProductSC_儲存Button_Click(object sender, EventArgs e)
        {
            QS_ii_ProductSC_Save();
        }

        private void QS_ii_ProductSC_取消Button_Click(object sender, EventArgs e)
        {
            QS_ii_ProductSC_Cancel();            
        }

        private void QS_ii_Product多選_Click(object sender, EventArgs e)
        {
            QS_ii_Product多選_Open();
        }

        private void QS_ii_Product新增_Click(object sender, EventArgs e)
        {
            #region  內容
            QS_ii_Product新增_Open();           
            #endregion
        }

        private void QS_ii_Product刪除_Click(object sender, EventArgs e)
        {
            QS_ii_Product刪除_Open();
        }


        #endregion

        #region 事件
        //====================================================

        //====================================================
        #endregion

    }

    public class QS_ii_ProductSC_T : QS_ii_QueryDGV
    {

        QS_ii_ProductSC QSiiSC;
        //QS_ii_DB QSiiPSC = new QS_ii_DB();

        public QS_ii_ProductSC_T(QS_ii_ProductSC x)
        {
            this.QSiiSC = x;
        }

        public override void QS_ii_QueryDGV_DGView1()       //把選取資料對應到TextBox
        {
            #region 內容
            try
            {
                DataRow QS_ii_dr = QSiiSC.QS_iiQ_add.QSiiDB.QS_ii_ProductSC.NewRow();
                QS_ii_dr["Check"] = "0";
                QS_ii_dr["CHAIN_NO"] = QSiiSC.QS_ii_ProductSC_CHAIN_NO.Text;
                QS_ii_dr["item_NO"] = QS_ii_DGView1.CurrentRow.Cells["商品編號"].Value.ToString();
                QS_ii_dr["item_NAME"] = QS_ii_DGView1.CurrentRow.Cells["商品名稱"].Value.ToString();
                QS_ii_dr["EN_NAME"] = QS_ii_DGView1.CurrentRow.Cells["英文名稱"].Value.ToString();

                QSiiSC.QS_iiQ_add.QSiiDB.QS_ii_ProductSC.Rows.Add(QS_ii_dr);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }

            #endregion
        }
        
    }
}
