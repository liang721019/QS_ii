using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using function.lib;


namespace QS_ii
{
    public partial class QS_ii_Product : Form
    {

        QS_ii_function fun = new QS_ii_function();
        //public QS_ii_DB QSiiDB = new QS_ii_DB();
       
        public QS_ii_Product()
        {
            InitializeComponent();
        }

        #region 變數
        //=============================================        

        private string QueryOLOD        //查詢條件變數
        {
            set;
            get;
        }

        private string QueryDB        //SQL語法變數
        {
            set;
            get;
        }

        public DataGridView QS_Quotes_DGV       //報價單主檔中的DGV
        {
            set;
            get;
        }

        //=============================================
        #endregion

        #region 方法
        //=============================================
        
        private void GetSQL(string x)           //DB語法
        {
            QueryDB = "";
            if (x == "新增")
            {                
                #region 內容
                QueryDB = @"EXEC [TEST_SLSYHI].[dbo].[SLS_QS_Product_Insert] '" + tb_item_NAME.Text.Trim() +       //商品名稱
                         @"','" + tb_EN_NAME.Text.Trim() +           //商品英文名稱
                         @"','" + tb_item_TYPE.Text.Trim() +         //商品類別
                         @"','" + tb_SPEC.Text.Trim() +              //規格
                         @"','" + tb_UNIT.Text.Trim() +              //單位
                         @"','" + tb_UNIT_PRICE.Text.Trim() +        //單價
                         @"','" + tb_CURRENCY.Text.Trim() +          //幣別
                         @"','" + tb_EFF_DATE_dTP1.Text +          //變動生效日
                         @"','" + USER_ID.Text.Trim() + "'";         //建立者帳號
                         
                #endregion
            }
            else if (x == "修改")
            {
                #region 內容
                QueryDB = @"EXEC [TEST_SLSYHI].[dbo].[SLS_QS_Product_Update] '" + tb_item_NO.Text +           //商品代號                         
                         @"','" + tb_item_NAME.Text +                //商品名稱 
                         @"','" + tb_EN_NAME.Text.Trim() +           //商品英文名稱
                         @"','" + tb_item_TYPE.Text.Trim() +         //商品類別
                         @"','" + tb_SPEC.Text.Trim() +              //規格
                         @"','" + tb_UNIT.Text.Trim() +              //單位
                         @"','" + tb_UNIT_PRICE.Text.Trim() +        //單價
                         @"','" + tb_CURRENCY.Text.Trim() +          //幣別
                         @"','" + tb_EFF_DATE_dTP1.Text +          //變動生效日
                         @"','" + USER_ID.Text + "'";                //修改者帳號
                #endregion
            }
            else if (x == "查詢")
            {
                #region 內容
                QueryDB = @"select * from [TEST_SLSYHI].[dbo].[SLS_QS_Product_QueryTemp]() where [DEL_FALG] = 'N'";
                #endregion
            }
            else if (x == "增加至報價單")
            {
                #region 內容
                QueryDB = @"select [商品編號] from [TEST_SLSYHI].[dbo].[SLS_QS_Product_QueryTemp]() where [DEL_FALG] = 'N' and [商品編號] = '" + tb_item_NO.Text + "'";
                #endregion

            }

        }

        private void default_status()       //預設
        {
            this.Text = "商品主檔";
            Product_Status_info.Text = "";     //狀態文字
            //this.MaximizeBox = true;       //最大化
            //this.MinimizeBox = true;       //最小化
            this.FormBorderStyle = FormBorderStyle.FixedSingle;     //限制使用者改變form大小
            this.AutoSize = false;          //自動調整大小
            //this.Size = new System.Drawing.Size(1249, 882);      //設定Form大小            
            fun.Format_Panel_dTP(Product_Detail_panel, "yyyy-MM-dd");     //自訂日期格式
            fun.EoD_Panel_txt(Product_Detail_panel, true);     //Product_Detail_panel內的TextBox設定唯讀
            fun.EoD_Panel_btnVisible(Product_panel1, true);      //Product_panel1內的button設定顯示
            tb_item_NO.ReadOnly = false;     //商品編號
            tb_item_TYPE.ReadOnly = false;      //商品類型
            tb_item_NAME.ReadOnly = false;      //商品名稱

            tb_UNIT_PRICE.TextAlign = HorizontalAlignment.Right;            //TextBox靠右對齊

            QS_ii_Product_儲存Button.Visible = false;
            QS_ii_Product_取消Button.Visible = false;
            Product_Status_info.Visible = false;

        }

        private void start_status(Button x)      //啟動狀態
        {
            if (x == QS_ii_Product_新增Button)
            {
                #region 新增
                Product_Status_info.Visible = true;
                Product_Status_info.Text = "新增";
                fun.clearAir(Product_panel2);
                fun.clearAir(Product_Detail_panel);
                fun.EoD_Panel_txt(Product_Detail_panel, false);     //Product_Detail_panel內的TextBox設定唯讀    
                fun.EoD_Panel_txt(Product_panel2, false);     //Product_panel2內的TextBox設定可讀寫              
                tb_item_NO.ReadOnly = true;     //商品編號                

                QS_ii_Product_新增Button.Enabled = false;
                QS_ii_Product_修改Button.Enabled = false;
                QS_ii_Product_刪除Button.Enabled = false;
                QS_ii_Product_查詢Button.Enabled = false;

                QS_ii_Product_儲存Button.Visible = true;
                QS_ii_Product_取消Button.Visible = true;
                QS_ii_Product_儲存Button.Enabled = true;
                QS_ii_Product_取消Button.Enabled = true;
                #endregion
            }
            else if (x == QS_ii_Product_修改Button)
            {
                #region 修改
                Product_Status_info.Visible = true;
                Product_Status_info.Text = "修改";
                fun.EoD_Panel_txt(Product_Detail_panel, false);     //QS_ii_Head_panel內的TextBox設定可讀寫
                fun.EoD_Panel_txt(Product_panel2, false);     //Product_panel2內的TextBox設定可讀寫
                tb_item_NO.ReadOnly = true;     //商品編號  
                QS_ii_Product_新增Button.Enabled = false;
                QS_ii_Product_修改Button.Enabled = false;
                QS_ii_Product_刪除Button.Enabled = false;
                QS_ii_Product_查詢Button.Enabled = false;
                QS_ii_Product_儲存Button.Visible = true;
                QS_ii_Product_取消Button.Visible = true;
                QS_ii_Product_儲存Button.Enabled = true;
                QS_ii_Product_取消Button.Enabled = true;
                #endregion
            }
            else if (x == QS_ii_Product_刪除Button)
            {

            }
            else if (x == QS_ii_Product_查詢Button)
            {
                #region 查詢
                fun.EoD_Panel_txt(Product_panel2, false);     //Product_panel2內的TextBox設定可讀寫
                fun.clearAir(Product_panel2);
                fun.clearAir(Product_Detail_panel);
                tb_item_NO.Focus();
                #endregion

            }
            else if (x == QS_ii_Product_儲存Button)
            {
                #region 儲存
                Product_Status_info.Visible = false;
                Product_Status_info.Text = "";
                fun.clearAir(Product_panel2);
                fun.clearAir(Product_Detail_panel);
                fun.EoD_Panel_txt(Product_panel2, false);     //Product_panel2內的TextBox設定可讀寫
                fun.EoD_Panel_txt(Product_Detail_panel, true);     //QS_ii_Head_panel內的TextBox設定唯讀

                //tb_item_NO.ReadOnly = true;     //商品編號

                QS_ii_Product_新增Button.Enabled = true;
                QS_ii_Product_修改Button.Enabled = true;
                QS_ii_Product_刪除Button.Enabled = true;
                QS_ii_Product_查詢Button.Enabled = true;

                QS_ii_Product_儲存Button.Visible = false;
                QS_ii_Product_取消Button.Visible = false;
                QS_ii_Product_儲存Button.Enabled = true;
                QS_ii_Product_取消Button.Enabled = true;
                #endregion
            }
            else if (x == QS_ii_Product_取消Button)
            {
                #region 取消
                Product_Status_info.Visible = false;
                Product_Status_info.Text = "";
                fun.EoD_Panel_txt(Product_panel2, false);     //Product_panel2內的TextBox設定可讀寫
                fun.EoD_Panel_txt(Product_Detail_panel, true);     //QS_ii_Head_panel內的TextBox設定唯讀                
                tb_item_NO.ReadOnly = true;     //商品編號                

                QS_ii_Product_新增Button.Enabled = true;
                QS_ii_Product_修改Button.Enabled = true;
                QS_ii_Product_刪除Button.Enabled = true;
                QS_ii_Product_查詢Button.Enabled = true;

                QS_ii_Product_儲存Button.Visible = false;
                QS_ii_Product_取消Button.Visible = false;
                QS_ii_Product_儲存Button.Enabled = true;
                QS_ii_Product_取消Button.Enabled = true;
                #endregion
            }

        }

        private void Product_add()              //商品主檔新增
        {
            #region 內容
            if (MessageBox.Show("確定要新增？", "警告!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                fun.Check_error = false;
                GetSQL("新增");
                fun.QS_ii_insert(QueryDB);
                if (fun.Check_error == false)
                {
                    MessageBox.Show("資料《新增》成功!!", this.Text);                    
                }
            }
            #endregion
        }

        private void Product_Modify()           //商品主檔修改
        {
            #region 內容
            if (tb_item_NO.Text != "")
            {
                if (MessageBox.Show("確定要修改？", "警告!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    fun.Check_error = false;
                    GetSQL("修改");
                    fun.QS_ii_insert(QueryDB);
                    if (fun.Check_error == false)
                    {
                        MessageBox.Show("資料《修改》成功!!", this.Text);                        
                    }

                }
            }

            #endregion
        }

        private void Product_delete()           //商品主檔刪除
        {
            #region 內容
            MessageBox.Show("目前沒有權限!!", this.Text);
            #endregion
        }

        private void Product_Query(DataGridView dgv)            //商品主檔查詢
        {
            GetSQL("查詢");    //語法丟進QueryDB
            Product_Query_conditions();      //查詢客戶主檔的條件
            fun.xxx_DB(QueryDB + QueryOLOD, dgv);         //連接DB-執行DB指令

        }

        private void Product_Query_conditions()         //查詢商品主檔的條件
        {
            QueryOLOD = "";
            if (tb_item_NO.Text != "")       //商品編號
            {
                QueryOLOD += @"and [商品編號] = N'" + tb_item_NO.Text.Trim() + "'";
            }
            if (tb_item_TYPE.Text != "")       //商品類別
            {
                QueryOLOD += @"and [產品分類] like N'%" + tb_item_TYPE.Text.Trim() + "%'";
            }
            if (tb_item_NAME.Text != "")       //商品名稱
            {
                QueryOLOD += @"and [商品名稱] like N'%" + tb_item_NAME.Text.Trim() + "%'";
            }
            QueryOLOD += @"order by 1";

        }

        public void Product_Query_Enter()           //客戶編號按enter後的方法
        {
            #region  按enter之後執行
            QS_ii_Product_T QSQDGV = new QS_ii_Product_T(this);
            //設定init_Staff 新視窗的相對位置#############
            QSQDGV.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //############################################
            Product_Query(QSQDGV.QS_ii_DGView1);           //商品主檔查詢
            QSQDGV.ShowDialog();
            #endregion
        }

        public virtual void QS_ii_Add_Product_Detail()         //增加至報價單商品明細
        {
            #region 內容

            #endregion
        }

        //=============================================
        #endregion

        #region button
        //=============================================
        private void QS_ii_Product_Load(object sender, EventArgs e)
        {
            default_status();
        }

        private void QS_ii_Product_儲存Button_Click(object sender, EventArgs e)
        {
            if (Product_Status_info.Text == "新增")
            {

                Product_add();         //商品主檔新增                
                start_status(QS_ii_Product_儲存Button);       //啟動狀態
            }
            else if (Product_Status_info.Text == "修改")
            {
                Product_Modify();        //商品主檔修改
                start_status(QS_ii_Product_儲存Button);       //啟動狀態

            }
        }

        private void QS_ii_Product_取消Button_Click(object sender, EventArgs e)
        {
            start_status(QS_ii_Product_取消Button);
        }

        private void QS_ii_Product_新增Button_Click(object sender, EventArgs e)
        {
            start_status(QS_ii_Product_新增Button);
        }

        private void QS_ii_Product_修改Button_Click(object sender, EventArgs e)
        {
            start_status(QS_ii_Product_修改Button);
        }

        private void QS_ii_Product_刪除Button_Click(object sender, EventArgs e)
        {
            Product_delete();
            start_status(QS_ii_Product_刪除Button);
        }

        private void QS_ii_Product_查詢Button_Click(object sender, EventArgs e)
        {
            start_status(QS_ii_Product_查詢Button);
        }

        //=============================================
        #endregion

        #region 事件
        //=============================================
        private void tb_item_NO_KeyDown(object sender, KeyEventArgs e)          //商品編號按enter後的查詢事件
        {
            if (Product_Status_info.Text == "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Product_Query_Enter();
                }
            }

        }

        private void tb_item_TYPE_KeyDown(object sender, KeyEventArgs e)        //商品類型按enter後的查詢事件
        {
            if (Product_Status_info.Text == "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Product_Query_Enter();
                }
            }

        }

        private void tb_item_NAME_KeyDown(object sender, KeyEventArgs e)        //商品名稱按enter後的查詢事件
        {
            if (Product_Status_info.Text == "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Product_Query_Enter();
                }
            }

        }

        private void tb_UNIT_PRICE_KeyPress(object sender, KeyPressEventArgs e)         //限制tb_UNIT_PRICE只能輸入數字
        {
            fun.TxTLimit_input_money(e);       //限制Text只能輸入數字            
        }

        private void QS_ii_Product_Import_Button_Click(object sender, EventArgs e)      //增加至報價單
        {
            if (tb_item_NO.Text != "")
            {
                //QS_ii_Add_Product_Detail();         //增加至報價單商品明細
                GetSQL("增加至報價單");
                fun.ProductDB_ds(QueryDB);

                if (fun.ds_index.Tables[0].Rows.Count != 0)
                {
                    QS_ii_Add_Product_Detail();         //增加至報價單商品明細
                    this.Close();
                }
                else
                {
                    MessageBox.Show("查無此商品!!", this.Text);
                }
            }
            else
            {
                MessageBox.Show("商品編號不能為空白!!", this.Text);
            }
        }
        //=============================================
        #endregion
    }

    public class QS_ii_Product_T : QS_ii_QueryDGV
    {
        QS_ii_Product QSiiP;

        public QS_ii_Product_T(QS_ii_Product x)
        {
            this.QSiiP = x;
        }

        public override void QS_ii_QueryDGV_DGView1()       //把選取資料對應到TextBox
        {

            QSiiP.tb_item_NO.Text = QS_ii_DGView1.CurrentRow.Cells["商品編號"].Value.ToString();
            QSiiP.tb_item_TYPE.Text = QS_ii_DGView1.CurrentRow.Cells["產品分類"].Value.ToString();
            QSiiP.tb_item_NAME.Text = QS_ii_DGView1.CurrentRow.Cells["商品名稱"].Value.ToString();
            QSiiP.tb_EN_NAME.Text = QS_ii_DGView1.CurrentRow.Cells["英文名稱"].Value.ToString();
            QSiiP.tb_SPEC.Text = QS_ii_DGView1.CurrentRow.Cells["規格"].Value.ToString();
            QSiiP.tb_CURRENCY.Text = QS_ii_DGView1.CurrentRow.Cells["幣別"].Value.ToString();
            QSiiP.tb_UNIT.Text = QS_ii_DGView1.CurrentRow.Cells["單位"].Value.ToString();
            QSiiP.tb_EFF_DATE_dTP1.Text = QS_ii_DGView1.CurrentRow.Cells["變動生效日"].Value.ToString();
            QSiiP.tb_UNIT_PRICE.Text = QS_ii_DGView1.CurrentRow.Cells["單價"].Value.ToString();            

        }


    }
}
