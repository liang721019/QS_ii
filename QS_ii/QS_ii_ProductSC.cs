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


        internal QS_ii_function fun = new QS_ii_function();
        internal QS_ii_Quotes_add QS_iiQ_add;

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
        public string QueryDB      //SQL語法
        {
            set;
            get;
        }

        public string PSC_ID       //取得通路編號
        {
            set;
            get;
        }
        //====================================================
        #endregion

        #region 方法
        //====================================================

        internal void GetSQL(string x)
        {
            if (x == "新增")
            {
                #region 內容
                this.QueryDB = @"exec [TEST_SLSYHI].[dbo].[SLS_QS_ProductSC_Insert] '"+PSC_ID+"','" + QS_ii_ProductSC_CHAIN_NAME.Text.Trim() +
                               @"',@ITEM_NO,'"+USER_ID.Text + "'";
                #endregion
            }
            else if(x == "取得通路編號")
            {
                this.QueryDB = @"select [TEST_SLSYHI].[dbo].[GETSLS_QS_itemCH_NO]() AS 'CHAIN_NO'";
            }
            else if(x == "查詢通路")
            {
                this.QueryDB = @"select distinct [CHAIN_NO] AS 通路編號,[CHAIN_NAME] AS 通路名稱 from [TEST_SLSYHI].[dbo].[SLS_QS_ProductSC_QueryTemp]()";
            }
            else if(x == "查詢通路明細")
            {
                this.QueryDB = @"select [Check] = '0', * from [TEST_SLSYHI].[dbo].[SLS_QS_ProductSC_QueryTemp]() where [CHAIN_NO] = '" + PSC_ID + "'";
            }
            else if (x == "表身修改")
            {
                this.QueryDB = @"exec [TEST_SLSYHI].[dbo].[SLS_QS_ProductSC_Update] '" + QS_ii_ProductSC_CHAIN_NO.Text + 
                                @"','"+QS_ii_ProductSC_CHAIN_NAME.Text.Trim()+"','"+USER_ID.Text+"'";
            }
            else if (x == "表身刪除")
            {
                this.QueryDB = @"exec [TEST_SLSYHI].[dbo].[SLS_QS_ProductSC_Delete] '" + QS_ii_ProductSC_CHAIN_NO.Text + "',@ITEM_NO";
            }
            else if (x == "表身新增")
            {
                this.QueryDB = @"exec [TEST_SLSYHI].[dbo].[SLS_QS_ProductSC_Insert] '" + QS_ii_ProductSC_CHAIN_NO.Text + "','" + QS_ii_ProductSC_CHAIN_NAME.Text.Trim() +
                               @"',@ITEM_NO,'" + USER_ID.Text + "'";
            }

        }

        private void default_status()            //預設狀態
        {
            this.Text = "通路";
            this.MaximizeBox = false;       //最大化
            this.MinimizeBox = false;       //最小化
            this.FormBorderStyle = FormBorderStyle.FixedSingle;     //限制使用者改變form大小            
            this.AutoSize = false;          //自動調整大小
            QS_ii_ProductSC_DGV1_SetColumns();      //ProductSC_DGV1自定顯示欄位
            QS_ii_ProductSC_DGV1.DataSource = QS_iiQ_add.QSiiDB.QS_ii_ProductSC;
            dataGridView1.DataSource = QS_iiQ_add.QSiiDB.QS_ii_ProductSC;
            fun.EoD_Panel_btn(ProductSC_panel1, true);

            QS_ii_ProductSC_CHAIN_NO.ReadOnly = true;
            QS_ii_ProductSC_CHAIN_NAME.ReadOnly = true;
            QS_ii_ProductSC_DGV1_Column1.Visible = false;
            ProductSC_Status_info.Visible = false;
            QS_ii_ProductSC_儲存Button.Visible = false;
            QS_ii_ProductSC_取消Button.Visible = false;
            QS_ii_ProductSC多選.Visible = false;
            QS_ii_ProductSC新增.Visible = false;
            QS_ii_ProductSC刪除.Visible = false;

        }

        private void start_status(Button x)      //啟動狀態
        {
            if (x == QS_ii_ProductSC_新增Button)
            {
                ProductSC_Status_info.Text = "新增";
                ProductSC_Status_info.Visible = true;
                fun.EoD_Panel_btn(ProductSC_panel1, false);
                QS_iiQ_add.QSiiDB.QS_ii_ProductSC.Clear();      //清除QS_ii_ProductSC_DGV1的資料源
                QS_ii_ProductSC_CHAIN_NO.Text = "";         //通路編號
                QS_ii_ProductSC_CHAIN_NAME.Text = "";       //通路名稱
                
                QS_ii_ProductSC_CHAIN_NO.ReadOnly = true;
                QS_ii_ProductSC_CHAIN_NAME.ReadOnly = false;
                QS_ii_ProductSC_DGV1_Column1.Visible = true;
                QS_ii_ProductSC_儲存Button.Visible = true;
                QS_ii_ProductSC_儲存Button.Enabled = true;
                QS_ii_ProductSC_取消Button.Visible = true;
                QS_ii_ProductSC_取消Button.Enabled = true;
                QS_ii_ProductSC多選.Visible = true;
                QS_ii_ProductSC新增.Visible = true;
                QS_ii_ProductSC刪除.Visible = true;


            }
            else if (x == QS_ii_ProductSC_修改Button)
            {
                ProductSC_Status_info.Text = "修改";
                ProductSC_Status_info.Visible = true;
                fun.EoD_Panel_btn(ProductSC_panel1, false);
                
                QS_ii_ProductSC_CHAIN_NO.ReadOnly = true;
                QS_ii_ProductSC_CHAIN_NAME.ReadOnly = false;
                QS_ii_ProductSC_DGV1_Column1.Visible = true;
                QS_ii_ProductSC_儲存Button.Visible = true;
                QS_ii_ProductSC_儲存Button.Enabled = true;
                QS_ii_ProductSC_取消Button.Visible = true;
                QS_ii_ProductSC_取消Button.Enabled = true;
                QS_ii_ProductSC多選.Visible = true;
                QS_ii_ProductSC新增.Visible = true;
                QS_ii_ProductSC刪除.Visible = true;


            }
            else if (x == QS_ii_ProductSC_刪除Button)
            {

            }
            else if (x == QS_ii_ProductSC_查詢Button)
            {

            }
            else if (x == QS_ii_ProductSC_儲存Button)
            {
                ProductSC_Status_info.Text = "瀏覽";
                ProductSC_Status_info.Visible = false;
                fun.EoD_Panel_btn(ProductSC_panel1, true);
                QS_iiQ_add.QSiiDB.QS_ii_ProductSC.Clear();      //清空DATATable


                QS_ii_ProductSC_CHAIN_NO.Text = "";         //通路編號
                QS_ii_ProductSC_CHAIN_NAME.Text = "";       //通路名稱
                                
                QS_ii_ProductSC_CHAIN_NO.ReadOnly = true;
                QS_ii_ProductSC_CHAIN_NAME.ReadOnly = true;
                QS_ii_ProductSC_DGV1_Column1.Visible = false;
                QS_ii_ProductSC_儲存Button.Visible = false;
                QS_ii_ProductSC_儲存Button.Enabled = false;
                QS_ii_ProductSC_取消Button.Visible = false;
                QS_ii_ProductSC_取消Button.Enabled = false;
                QS_ii_ProductSC多選.Visible = false;
                QS_ii_ProductSC新增.Visible = false;
                QS_ii_ProductSC刪除.Visible = false;

                                

            }
            else if (x == QS_ii_ProductSC_取消Button)
            {
                ProductSC_Status_info.Text = "瀏覽";
                ProductSC_Status_info.Visible = false;
                fun.EoD_Panel_btn(ProductSC_panel1, true);
                
                QS_ii_ProductSC_CHAIN_NO.ReadOnly = true;
                QS_ii_ProductSC_CHAIN_NAME.ReadOnly = true;
                QS_ii_ProductSC_DGV1_Column1.Visible = false;
                QS_ii_ProductSC_儲存Button.Visible = false;
                QS_ii_ProductSC_儲存Button.Enabled = false;
                QS_ii_ProductSC_取消Button.Visible = false;
                QS_ii_ProductSC_取消Button.Enabled = false;
                QS_ii_ProductSC多選.Visible = false;
                QS_ii_ProductSC新增.Visible = false;
                QS_ii_ProductSC刪除.Visible = false;
                QS_iiQ_add.QSiiDB.QS_ii_ProductSC.RejectChanges();

            }
        }

        private void QS_ii_ProductSC_Add()           //新增
        {
            #region 內容
            if (MessageBox.Show("確定要新增？", "警告!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                fun.Check_error = false;
                GetSQL("取得通路編號");
                fun.QS_ii_ProductSC_GetID_ds(this.QueryDB);
                PSC_ID = fun.Temp_ds.Tables[0].Rows[0]["CHAIN_NO"].ToString();
                if (!fun.Check_error)
                {
                    GetSQL("新增");
                    fun.QS_ii_ProductSC_ds(this.QueryDB, QS_iiQ_add.QSiiDB.QS_ii_ProductSC);
                }                

                if (fun.Check_error == false)
                {
                    start_status(QS_ii_ProductSC_儲存Button);
                    QS_iiQ_add.QSiiDB.QS_ii_ProductSC.AcceptChanges();      //****重要****要加這行才算是更新DataTable
                    MessageBox.Show("資料《新增》成功!!", this.Text);
                }
                else
                {
                    MessageBox.Show("資料《新增》失敗!!", this.Text);
                }
            }
            #endregion
        }

        private void QS_ii_ProductSC_Modify()        //修改
        {
            #region 內容
            if (QS_ii_ProductSC_CHAIN_NO.Text != "")
            {
                #region 內容
                if (MessageBox.Show("確定要修改？", "警告!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    fun.Check_error = false;
                    GetSQL("表身修改");
                    fun.QS_ii_ModifyQT01_ds(QueryDB);
                    GetSQL("表身刪除");
                    fun.QS_ii_ModifyProductSCDEL_ds(QueryDB, QS_iiQ_add.QSiiDB.QS_ii_ProductSC);
                    GetSQL("表身新增");
                    fun.QS_ii_ModifyProductSCADD_ds(QueryDB, QS_iiQ_add.QSiiDB.QS_ii_ProductSC);
                    //fun.QS_ii_QText(QSiiDB.QS_ii_QProduct);                
                    if (fun.Check_error == false)
                    {
                        start_status(QS_ii_ProductSC_儲存Button);
                        QS_iiQ_add.QSiiDB.QS_ii_ProductSC.AcceptChanges();      //****重要****要加這行才算是更新DataTable
                        MessageBox.Show("資料《修改》成功!!", this.Text);
                    }
                }
                #endregion
            }
            else
            {
                MessageBox.Show("沒有通路編號!!無法修改",this.Text);
            }
            
            #endregion
        }

        private void QS_ii_ProductSC_Delete()        //刪除
        {

        }

        private void QS_ii_ProductSC_Query()         //查詢
        {
            #region 內容
            QS_ii_ProductSC_Head ProductSC_Query = new QS_ii_ProductSC_Head(this);            
            GetSQL("查詢通路");
            fun.xxx_DB(this.QueryDB, ProductSC_Query.QS_ii_DGView1);
            //設定init_Staff 新視窗的相對位置#############
            ProductSC_Query.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //############################################            
            ProductSC_Query.ShowDialog();
            

            //fun.xxx_DB(this.QueryDB,);

            #endregion
        }

        private void QS_ii_ProductSC_Save()          //儲存
        {
            #region 內容
            if (ProductSC_Status_info.Text == "新增")
            {
                QS_ii_ProductSC_Add();          //新增
            }
            else if (ProductSC_Status_info.Text == "修改")
            {
                QS_ii_ProductSC_Modify();       //修改
            }
            
            #endregion
        }

        private void QS_ii_ProductSC_Cancel()        //取消
        {
            start_status(QS_ii_ProductSC_取消Button);
        }

        private void QS_ii_ProductSC_Detail_Modify(Button x)        //明細新增資料的方法(多選or單選)
        {
            #region 內容
            QS_ii_ProductSC_Detail ProductSC_ADD = new QS_ii_ProductSC_Detail(this);            
            ProductSC_ADD.QS_ii_QueryDGV_Column1.DataPropertyName = "Check";
            if (x == QS_ii_ProductSC多選)
            {
                ProductSC_ADD.QS_ii_QueryDGV_Column1.Visible = true;           //自訂DGV欄位設定顯示or隱藏
                ProductSC_ADD.QS_ii_加入button.Visible = true;
            }
            else if (x == QS_ii_ProductSC新增)
            {
                ProductSC_ADD.QS_ii_QueryDGV_Column1.Visible = false;           //自訂DGV欄位設定顯示or隱藏
                ProductSC_ADD.QS_ii_加入button.Visible = false;
            }

            QS_iiQ_add.Product_Query(ProductSC_ADD.QS_ii_QueryDGv_PID, QS_iiQ_add.QSiiDB.QS_ii_Product, ProductSC_ADD.QS_ii_DGView1);        //商品主檔查詢
            //QS_iiQ_add.Product_Query(ProductSC_ADD.QS_ii_DGView1);        //商品主檔查詢  
            //設定init_Staff 新視窗的相對位置#############
            ProductSC_ADD.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //############################################            
            ProductSC_ADD.ShowDialog();
            #endregion
        }

        private void QS_ii_ProductSC新增_Open()         //明細新增的方法
        {
            #region 內容
            QS_ii_ProductSC_Detail_Modify(QS_ii_ProductSC新增);
            #endregion
        }

        private void QS_ii_ProductSC刪除_Open()         //明細刪除的方法
        {
            #region 內容
            //***************DataTable刪除選取的資料*****************
            for (int i = QS_ii_ProductSC_DGV1.Rows.Count - 1; i >= 0; i--)
            {
                if (QS_ii_ProductSC_DGV1.Rows[i].Cells[0].Value.ToString() == "1")
                {
                    this.QS_ii_ProductSC_DGV1.Rows.Remove(this.QS_ii_ProductSC_DGV1.Rows[i]);
                    i = QS_ii_ProductSC_DGV1.Rows.Count;
                }
            }            

            #endregion
        }

        private void QS_ii_ProductSC多選_Open()         //明細多選的方法
        {
            #region 內容
            QS_ii_ProductSC_Detail_Modify(QS_ii_ProductSC多選);

            #endregion
        }        

        private void QS_ii_ProductSC_DGV1_SetColumns()      //ProductSC_DGV1自定顯示欄位
        {
            QS_ii_ProductSC_DGV1.AutoGenerateColumns = false;
            QS_ii_ProductSC_DGV1_Column1.DataPropertyName = "Check";
            QS_ii_ProductSC_DGV1_Column2.DataPropertyName = "CHAIN_NO";
            QS_ii_ProductSC_DGV1_Column3.DataPropertyName = "item_NO";
            QS_ii_ProductSC_DGV1_Column4.DataPropertyName = "item_NAME";
            QS_ii_ProductSC_DGV1_Column5.DataPropertyName = "EN_NAME";
            QS_ii_ProductSC_DGV1_Column6.DataPropertyName = "SPEC";


        }

        public void QS_ii_ProductSC_DataBinding(DataTable x)     //datatable的欄位與Text綁定資料-通路編號&通路名稱
        {
            QS_ii_ProductSC_CHAIN_NO.DataBindings.Clear();
            QS_ii_ProductSC_CHAIN_NAME.DataBindings.Clear();
            if (ProductSC_Status_info.Text == "瀏覽")
            {
                QS_ii_ProductSC_CHAIN_NO.DataBindings.Add("Text", x, "CHAIN_NO", true);     //通路編號
                QS_ii_ProductSC_CHAIN_NAME.DataBindings.Add("Text", x, "CHAIN_NAME", true);     //通路名稱                
            }
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
            QS_ii_ProductSC_Query();        //查詢
        }

        private void QS_ii_ProductSC_儲存Button_Click(object sender, EventArgs e)
        {
            QS_ii_ProductSC_Save();
        }

        private void QS_ii_ProductSC_取消Button_Click(object sender, EventArgs e)
        {
            QS_ii_ProductSC_Cancel();            
        }

        private void QS_ii_ProductSC多選_Click(object sender, EventArgs e)
        {
            QS_ii_ProductSC多選_Open();
        }

        private void QS_ii_ProductSC新增_Click_1(object sender, EventArgs e)
        {
            #region  內容
            QS_ii_ProductSC新增_Open();
            #endregion

        }       

        private void QS_ii_ProductSC刪除_Click(object sender, EventArgs e)
        {
            QS_ii_ProductSC刪除_Open();
        }

        #endregion        

        #region 事件
        //====================================================
        private void QS_ii_ProductSC_DGV1_CellContentClick(object sender, DataGridViewCellEventArgs e)      //QS_ii_Product_DGV中的Checkbox
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                #region 內容
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)QS_ii_ProductSC_DGV1.Rows[e.RowIndex].Cells[0];
                string flag = QS_ii_ProductSC_DGV1.Rows[e.RowIndex].Cells[0].Value.ToString();
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

        //====================================================
        #endregion

    }

    public class QS_ii_ProductSC_Detail : QS_ii_QueryDGV         //明細
    {

        QS_ii_ProductSC QSiiSC;
        //QS_ii_DB QSiiPSC = new QS_ii_DB();

        public QS_ii_ProductSC_Detail(QS_ii_ProductSC x)
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
                QS_ii_dr["CHAIN_NAME"] = QSiiSC.QS_ii_ProductSC_CHAIN_NAME.Text;
                QS_ii_dr["item_NO"] = QS_ii_DGView1.CurrentRow.Cells["商品編號"].Value.ToString();
                QS_ii_dr["item_NAME"] = QS_ii_DGView1.CurrentRow.Cells["商品名稱"].Value.ToString();
                QS_ii_dr["EN_NAME"] = QS_ii_DGView1.CurrentRow.Cells["英文名稱"].Value.ToString();
                QS_ii_dr["SPEC"] = QS_ii_DGView1.CurrentRow.Cells["規格"].Value.ToString();
                QSiiSC.QS_iiQ_add.QSiiDB.QS_ii_ProductSC.Rows.Add(QS_ii_dr);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }

            #endregion
        }

        public override void QS_ii_QueryDGV_QueryButton()       //查詢Button
        {
            //DataTable ProductM_dt = new DataTable();
            //ProductM_dt.Columns.Add("Check");
            //QS_ii_QueryDGV_Column1.Visible = true;
            QSiiSC.QS_iiQ_add.Product_Query(QS_ii_QueryDGv_PID, QSiiSC.QS_iiQ_add.QSiiDB.QS_ii_Product, QS_ii_DGView1);        //商品主檔查詢
            
        }

        public override void QS_ii_QueryDGV_加入button()      //報價單明細檔多選的加入button
        {
            DataView QS_ii_DViewPSC = new DataView(QSiiSC.QS_iiQ_add.QSiiDB.QS_ii_Product);
            DataView QS_ii_QDViewPSC = new DataView(QSiiSC.QS_iiQ_add.QSiiDB.QS_ii_ProductSC);
            QS_ii_DViewPSC.RowFilter = "Check = '1'";
            foreach (DataRowView DViewPSC in QS_ii_DViewPSC)
            {
                QS_ii_QDViewPSC.RowFilter = "item_NO = '" + DViewPSC["商品編號"].ToString() + "'";
                if (QS_ii_QDViewPSC.Count == 0)
                {
                    DataRow QS_ii_dr = QSiiSC.QS_iiQ_add.QSiiDB.QS_ii_ProductSC.NewRow();
                    QS_ii_dr["Check"] = "0";
                    QS_ii_dr["CHAIN_NO"] = QSiiSC.QS_ii_ProductSC_CHAIN_NO.Text;
                    QS_ii_dr["CHAIN_NAME"] = QSiiSC.QS_ii_ProductSC_CHAIN_NAME.Text;  //QS_ii_ProductSC_CHAIN_NAME
                    QS_ii_dr["item_NO"] = DViewPSC["商品編號"];
                    QS_ii_dr["item_NAME"] = DViewPSC["商品名稱"];
                    QS_ii_dr["EN_NAME"] = DViewPSC["英文名稱"];
                    QS_ii_dr["SPEC"] = DViewPSC["規格"];
                    QSiiSC.QS_iiQ_add.QSiiDB.QS_ii_ProductSC.Rows.Add(QS_ii_dr);
                }
            }
            this.Close();
        }        
    }

    public class QS_ii_ProductSC_Head : QS_ii_QueryDGV          //表頭查詢
    {
        
        QS_ii_ProductSC QSiiSC;

        public QS_ii_ProductSC_Head(QS_ii_ProductSC x)
        {
            this.QSiiSC = x;
        }

        public override void QS_ii_QueryDGV_DGView1()       //DGV雙擊左鍵二下
        {

            QSiiSC.PSC_ID = QS_ii_DGView1.CurrentRow.Cells["通路編號"].Value.ToString();
            //QS_ii_QueryDGV_Column1.DataPropertyName = "Check";
            QSiiSC.GetSQL("查詢通路明細");
            QSiiSC.fun.QS_ii_ProductSC_Query_ds(QSiiSC.QueryDB, QSiiSC.QS_iiQ_add.QSiiDB.QS_ii_ProductSC);
            QSiiSC.QS_ii_ProductSC_DataBinding(QSiiSC.QS_iiQ_add.QSiiDB.QS_ii_ProductSC);     //datatable的欄位與Text綁定資料-通路編號&通路名稱
            
            //@"distinct [CHAIN_NO]	AS 通路編號,[CHAIN_NAME]	AS 通路名稱 FROM [TEST_SLSYHI].[dbo].[SLS_ItemCH]";
        }
        public override void QS_ii_QueryDGV_QueryButton()        //查詢Button
        {
            #region 內容

            #endregion
        }

    }
}
