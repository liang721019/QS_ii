﻿using function.lib;
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
        QS_ii_function fun = new QS_ii_function();

        public QS_ii_DB QSiiDB = new QS_ii_DB();

        public QS_ii_Quotes_add()
        {
            InitializeComponent();
        }

        #region 變數
        //==============================================================================================================
        public string QueryDB       //DB連線字串
        {
            set;
            get;
        }

        public string QT_NO         //報價單號
        {
            set;
            get;
        }

        public string CUST_NO       //客戶編號
        {
            set;
            get;
        }

        private string ALLOW_QS     //是不核准報價的變數
        {
            set;
            get;
        }

        public string QS_ii_QuotesNO       //報價單號變數
        {
            set;
            get;
        }        
        
        //==============================================================================================================
        #endregion

        #region 方法
        //==============================================================================================================

        public void ALL_RB()        //是否核准報價
        {
            if (ALLOW_QT_YES.Checked)
            {
                ALLOW_QS = "Y";                
            }
            if (ALLOW_QT_NO.Checked)
            {
                ALLOW_QS = "N";
            }
        }        

        public void GetSQL(string x)
        {
            if (x == "新增")
            {
                #region 內容
                ALL_RB();
                QueryDB = @"EXEC [TEST_SLSYHI].[dbo].[SLS_QS_Insert] '" + QT_DATE_dTP.Text +       //--報價日期
                         @"','" + tb_CUST_NO.Text.Trim() +           //--客戶編號
                         @"','" + tb_CHAIN_NO.Text.Trim() +         //通路編號
                         @"','" + QT_EFF_DATE_dTP.Text +         //報價有效日期(期限)
                         @"','" + tb_SALESMAN.Text.Trim() +         //報價人(業務員)
                         @"','" + tb_AMT_NOTAX.Text.Trim() +        //總金額 (未稅)int.Parse(textBox1.Text)
                         @"','" + tb_TAX_AMT.Text.Trim() +          //稅額
                         @"','" + tb_TOT_AMT.Text.Trim() +          //含稅金額
                         @"','" + tb_CURRENCY.Text.Trim() +          //幣別
                         @"','" + tb_EXC_RATE.Text.Trim() +          //匯率
                         @"','" + ALLOW_QS +                        //是否核准報價
                         @"','" + tb_BPM_NO.Text.Trim() +           //簽核單號
                         @"','" + tb_DELI_MODE.Text.Trim() +          //交貨方式 
                         @"','" + tb_RECEIVE.Text.Trim() +          //收貨人                                                 
                         @"','" + tb_APPROVE.Text.Trim() +          //核准人員
                         @"','" + tb_APPR_DATE.Text +          //核准日期
                         @"','" + tb_REMARK.Text.Trim() +          //備註
                         //@"','" + USER_ID.Text +                 //附件
                         @"','" + USER_ID.Text +                //使用者ID
                         "',@QS_ii_QuotesNO  output";                 //報價單號
                #endregion
            }
            else if(x == "表身新增")
            {
                QueryDB = @"exec [TEST_SLSYHI].[dbo].[SLS_QS_Insert_Detail] '" + fun.QS_ii_QuotesNO + "',@AA1,@AA2,@AA3,@AA4,@AA5,@AA6,@AA7,'" + USER_ID.Text + "'";
                //QueryDB = @"insert into [TEST_SLSYHI].[dbo].[SLS_QT02] values('P010001',@AA1,@AA2,@AA3,@AA4,@AA5,@AA6,'','','105070',null,null,null,null,null)";
            }
            else if (x == "歷史報價查詢")
            {
                #region 內容
                QueryDB = @"select * from [TEST_SLSYHI].[dbo].[SLS_QS_Query_HQT]() where [QT_NO] is not null ";
                if (tb_HQuery_CUST_NO.Text != "")
                {
                    QueryDB += "and CUST_NO = '" + tb_HQuery_CUST_NO.Text + "'";
                }
                if (tb_HQuery_item_NO.Text != "")
                {
                    QueryDB += "and item_NO = '" + tb_HQuery_item_NO.Text + "'";
                }
                QueryDB += "order by 1";
                #endregion
            }
            else if (x == "歷史表頭")
            {
                #region 內容
                //QueryDB = @"select * from [TEST_SLSYHI].[dbo].[SLS_QS_CUST_QueryTemp]() where [DEL_FALG] = 'N' and [客戶編號] = '" + CUST_NO + "'";
                QueryDB = @"exec [TEST_SLSYHI].[dbo].[SLS_QS_Query_HQT01] '" + CUST_NO + "'";
                #endregion
            }
            else if (x == "歷史表身")
            {
                #region 內容
                QueryDB = @"SELECT [Check] = '0',[QT_NO],[item_NO],[item_NAME],[SPEC],[UNIT],[QTY],[UNIT_PRICE],[item_AMT]
                            FROM [TEST_SLSYHI].[dbo].[SLS_HQT02] where [QT_NO] = '"+QT_NO+"'";
                #endregion
            }
            else if(x == "商品主檔查詢")
            {
                #region 內容
                QueryDB = @"select * from [TEST_SLSYHI].[dbo].[SLS_QS_Product_QueryTemp]() where [DEL_FALG] = 'N'";
                #endregion

            }
            
        }
        
        public void default_status()            //預設狀態
        {
            this.Text = "報價系統";
            //this.MaximizeBox = true;       //最大化
            //this.MinimizeBox = true;       //最小化
            this.FormBorderStyle = FormBorderStyle.FixedSingle;     //限制使用者改變form大小
            this.AutoSize = false;          //自動調整大小
            //this.Size = new System.Drawing.Size(1249, 882);      //設定Form大小
 
            Product_DGV_SetColumns();           //QS_ii_Product_DGV自定顯示欄位
            HQuery_DGV_SetColumns();            //QS_ii_HQuery_DGV自定顯示欄位
            QS_ii_Product_DGV.DataSource = QSiiDB.QS_ii_QProduct;
            fun.Format_Panel_dTP(QS_ii_Head_panel, "yyyy-MM-dd");     //自訂日期格式
            fun.EoD_Panel_txt(QS_ii_Head_panel, true);     //QS_ii_Head_panel內的TextBox設定唯讀
            fun.EoD_Panel_DateTimePicker(QS_ii_Head_panel, false);       //QS_ii_Head_panel內的DateTimePicker設定唯讀
            //fun.EoD_Panel_txt(QS_ii_Check_panel, true);             //QS_ii_Check_panel內的TextBox設定唯讀
            fun.EoD_Panel_RadioButton(QS_ii_Check_panel, false);    //QS_ii_Check_panel內的RadioButton設定唯讀
            fun.EoD_Panel_txt(QS_ii_money_panel, true);     //QS_ii_money_panel內的TextBox設定唯讀 

            QS_ii_查詢button.Visible = false;
            tb_AMT_NOTAX.DataBindings.Add("Text", QSiiDB.QS_ii_QProduct, "SubTotal", true);     //總金額 (未稅)綁定資料
            tb_TAX_AMT.DataBindings.Add("Text", QSiiDB.QS_ii_QProduct, "ColTax", true);     //稅額 綁定資料
            tb_TOT_AMT.DataBindings.Add("Text", QSiiDB.QS_ii_QProduct, "TOT_AMT", true);     //含稅總額 綁定資料
            Product_多選button.Visible = false;
            Product_新增button.Visible = false;
            Product_刪除button.Visible = false;

            QS_ii_新增button.Enabled = true;
            QS_ii_產品button.Enabled = true;
            QS_ii_刪除button.Enabled = true;
            QS_ii_查詢button.Enabled = true;
            QS_ii_儲存button.Visible = false;
            QS_ii_取消button.Visible = false;
            QS_ii_儲存button.Enabled = false;
            QS_ii_取消button.Enabled = false;
            Status_info.Visible = false;

        }

        public void start_status(Button x)      //啟動狀態
        {
            if (x == QS_ii_新增button)
            {
                Status_info.Text = "新增";
                Status_info.Visible = true;
                tb_QT_NO.Text = "";

                //fun.EoD_Panel_txt(QS_ii_Head_panel, false);                 //QS_ii_Head_panel內的TextBox設定可讀寫
                //fun.EoD_Panel_DateTimePicker(QS_ii_Head_panel, true);      //QS_ii_Head_panel內的DateTimePicker設定可讀寫
                Product_多選button.Visible = true;
                Product_新增button.Visible = true;
                Product_刪除button.Visible = true;

                tb_SALESMAN.Text = USER_ID.Text;        //報價業務
                QS_ii_新增button.Enabled = false;
                QS_ii_修改button.Enabled = false;
                //QS_ii_產品button.Enabled = false;
                QS_ii_刪除button.Enabled = false;
                QS_ii_查詢button.Enabled = false;
                QS_ii_儲存button.Visible = true;
                QS_ii_取消button.Visible = true;
                QS_ii_儲存button.Enabled = true;
                QS_ii_取消button.Enabled = true;

            }
            else if (x == QS_ii_修改button)
            {
                Status_info.Text = "修改";
                Status_info.Visible = true;
                QS_ii_新增button.Enabled = false;
                QS_ii_修改button.Enabled = false;
                //QS_ii_產品button.Enabled = false;
                QS_ii_刪除button.Enabled = false;
                QS_ii_查詢button.Enabled = false;
                QS_ii_儲存button.Visible = true;
                QS_ii_取消button.Visible = true;
                QS_ii_儲存button.Enabled = true;
                QS_ii_取消button.Enabled = true;

            }
            else if (x == QS_ii_刪除button)
            {

            }
            else if (x == QS_ii_查詢button)
            {
                Status_info.Text = "";
                Status_info.Visible = false;

            }
            else if(x == QS_ii_儲存button)
            {
                Status_info.Text = "";
                Status_info.Visible = false;
                fun.EoD_Panel_txt(QS_ii_Head_panel, true);                 //QS_ii_Head_panel內的TextBox設定唯讀
                fun.EoD_Panel_DateTimePicker(QS_ii_Head_panel, false);      //QS_ii_Head_panel內的DateTimePicker設定唯讀
                tb_SALESMAN.Text = "";        //報價業務
                QSiiDB.QS_ii_QProduct.Clear();      //清空DATATable
                fun.clearAir(QS_ii_Head_panel);     //清空報價單表頭

                Product_多選button.Visible = false;
                Product_新增button.Visible = false;
                Product_刪除button.Visible = false;

                QS_ii_新增button.Enabled = true;
                QS_ii_修改button.Enabled = true;
                //QS_ii_產品button.Enabled = true;
                QS_ii_刪除button.Enabled = true;
                QS_ii_查詢button.Enabled = true;
                QS_ii_儲存button.Visible = false;
                QS_ii_取消button.Visible = false;
                QS_ii_儲存button.Enabled = false;
                QS_ii_取消button.Enabled = false;

            }
            else if(x == QS_ii_取消button)
            {
                Status_info.Text = "";
                Status_info.Visible = false;
                fun.EoD_Panel_txt(QS_ii_Head_panel, true);                 //QS_ii_Head_panel內的TextBox設定唯讀
                fun.EoD_Panel_DateTimePicker(QS_ii_Head_panel, false);      //QS_ii_Head_panel內的DateTimePicker設定唯讀
                tb_SALESMAN.Text = "";        //報價業務

                Product_多選button.Visible = false;
                Product_新增button.Visible = false;
                Product_刪除button.Visible = false;
                QS_ii_新增button.Enabled = true;
                QS_ii_修改button.Enabled = true;
                //QS_ii_產品button.Enabled = true;
                QS_ii_刪除button.Enabled = true;
                QS_ii_查詢button.Enabled = true;
                QS_ii_儲存button.Visible = false;
                QS_ii_取消button.Visible = false;
                QS_ii_儲存button.Enabled = false;
                QS_ii_取消button.Enabled = false;

            }
            else if (x == QS_ii_歷史查詢button)
            {


            }

        }
        
        private void Quotes_Add()       //報價單新增
        {
            #region 內容
            if (MessageBox.Show("確定要新增？", "警告!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                fun.Check_error = false;
                GetSQL("新增");
                fun.QS_ii_Qinsert(QueryDB);
                GetSQL("表身新增");
                fun.QS_ii_Product_ds(QueryDB, QSiiDB.QS_ii_QProduct);
                
                if (fun.Check_error == false)
                {
                    start_status(QS_ii_儲存button);
                    MessageBox.Show("資料《新增》成功!!", this.Text);
                }

            }
            #endregion
        }

        private void Quotes_Modify()        //報價單修改
        {
            #region 內容


            #endregion

        }

        private void Quotes_Delete()        //報價單刪除
        {

        }

        private void Quotes_HQueryDoubleClick()         //報價單查詢==>QS_ii_HQuery_DGV雙擊二下
        {
            #region 內容
            tb_QT_NO.Text = QT_NO;
            GetSQL("歷史表頭");
            fun.QS_ii_HQTQuery_ds(QueryDB, QSiiDB.QS_ii_HQCustomer);
            Quotes_import_Head();                //報價單主檔表頭與TextBox對應
            GetSQL("歷史表身");
            fun.QS_ii_HQTQuery_ds(QueryDB, QSiiDB.QS_ii_QProduct);
            QS_ii_tabControl1.SelectedIndex = 0;
            #endregion
        }

        private void Quotes_HQuery()        //歷史記錄查詢
        {
            //fun.Check_error = false;
            GetSQL("歷史報價查詢");
            fun.xxx_DB(QueryDB,QS_ii_HQuery_DGV);
            
        }

        private void QS_ii_客戶_Open()       //客戶主檔開窗
        {
            QS_ii_TCustomer inSea = new QS_ii_TCustomer(this);
            //設定init_Staff 新視窗的相對位置#############
            inSea.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //############################################
            inSea.Server_ENV.Text = QS_ii_Server_ENV.Text;      //server
            inSea.USER_ID.Text = USER_ID.Text;          //UID
            inSea.ShowDialog();
        }

        private void HQuery()
        {

        }

        private void Quotes_import_Head()         //報價單主檔表頭與TextBox對應
        {            
            tb_CUST_NO.Text = QSiiDB.Tables["QS_ii_HQCustomer"].Rows[0]["CUST_NO"].ToString();          //客戶編號            
            tb_CUST_NAME.Text = QSiiDB.Tables["QS_ii_HQCustomer"].Rows[0]["CUST_NAME"].ToString();      //客戶名稱
            tb_PROD_TYPE.Text = QSiiDB.Tables["QS_ii_HQCustomer"].Rows[0]["CUST_TYPE"].ToString();      //客戶類別
            tb_CONTACT.Text = QSiiDB.Tables["QS_ii_HQCustomer"].Rows[0]["CONTACT"].ToString();          //連絡人
            tb_CONT_TITLE.Text = QSiiDB.Tables["QS_ii_HQCustomer"].Rows[0]["CONT_TITLE"].ToString();    //連絡人職稱
            tb_CONT_TEL.Text = QSiiDB.Tables["QS_ii_HQCustomer"].Rows[0]["CONT_TEL"].ToString();        //連絡人電話
            tb_FAX.Text = QSiiDB.Tables["QS_ii_HQCustomer"].Rows[0]["FAX"].ToString();                  //傳真
            tb_CUST_MAIL.Text = QSiiDB.Tables["QS_ii_HQCustomer"].Rows[0]["CUST_MAIL"].ToString();      //客戶MAIL
            tb_VAT_NO.Text = QSiiDB.Tables["QS_ii_HQCustomer"].Rows[0]["VAT_NO"].ToString();            //統一編號
            tb_CUST_ADDR.Text = QSiiDB.Tables["QS_ii_HQCustomer"].Rows[0]["CUST_ADDR"].ToString();    //客戶地址            
            tb_DELI_ADDR_NO.Text = QSiiDB.Tables["QS_ii_HQCustomer"].Rows[0]["DELI_ADDR_NO"].ToString();    //送貨郵地區號
            tb_DELI_ADDR.Text = QSiiDB.Tables["QS_ii_HQCustomer"].Rows[0]["DELI_ADDR"].ToString();       //送貨地址
            tb_PAY_METH.Text = QSiiDB.Tables["QS_ii_HQCustomer"].Rows[0]["PAY_METH"].ToString();        //付款方式
            tb_CHAIN_NO.Text = QSiiDB.Tables["QS_ii_HQCustomer"].Rows[0]["CHAIN_NO"].ToString();        //通路名稱
        }

        private void Product_Query(DataGridView dgv)            //商品主檔查詢
        {
            GetSQL("商品主檔查詢");    //語法丟進QueryDB
            //Product_Query_conditions();      //查詢客戶主檔的條件
            fun.xxx_DB(QueryDB, dgv);         //連接DB-執行DB指令
        }

        public void Product_DGV_SetColumns()        //QS_ii_Product_DGV自定顯示欄位
        {
            QS_ii_Product_DGV.AutoGenerateColumns = false;
            QS_ii_Product_DGV_Column1.DataPropertyName = "Check";
            QS_ii_Product_DGV_Column2.DataPropertyName = "item_NO";
            QS_ii_Product_DGV_Column3.DataPropertyName = "item_NAME";
            QS_ii_Product_DGV_Column4.DataPropertyName = "SPEC";
            QS_ii_Product_DGV_Column5.DataPropertyName = "UNIT";
            QS_ii_Product_DGV_Column6.DataPropertyName = "QTY";
            QS_ii_Product_DGV_Column7.DataPropertyName = "UNIT_PRICE";
        }

        private void HQuery_DGV_SetColumns()        //QS_ii_HQuery_DGV自定顯示欄位
        {
            QS_ii_HQuery_DGV.AutoGenerateColumns = false;
            QS_ii_HQuery_DGV_Column1.DataPropertyName = "QT_NO";
            QS_ii_HQuery_DGV_Column2.DataPropertyName = "CUST_NO";
            QS_ii_HQuery_DGV_Column3.DataPropertyName = "CHAIN_NO";
            QS_ii_HQuery_DGV_Column4.DataPropertyName = "item_NO";
            QS_ii_HQuery_DGV_Column5.DataPropertyName = "item_NAME";
            QS_ii_HQuery_DGV_Column6.DataPropertyName = "QTY";
            QS_ii_HQuery_DGV_Column7.DataPropertyName = "UNIT_PRICE";
            QS_ii_HQuery_DGV_Column8.DataPropertyName = "QT_DATE";
            QS_ii_HQuery_DGV_Column9.DataPropertyName = "SALESMAN";

        }

        
        //==============================================================================================================
        #endregion

        private void QS_ii_main_Load(object sender, EventArgs e)
        {
            default_status();
        }


        #region button
        //==============================================================================================================

        private void QS_ii_新增button_Click(object sender, EventArgs e)
        {
            start_status(QS_ii_新增button);
        }

        private void QS_ii_修改button_Click(object sender, EventArgs e)
        {
            start_status(QS_ii_修改button);
        }

        private void QS_ii_客戶button_Click(object sender, EventArgs e)
        {
            QS_ii_客戶_Open();
        }

        private void QS_ii_產品button_Click(object sender, EventArgs e)
        {            
            QS_ii_TProduct inQS_Product = new QS_ii_TProduct(this);
            //設定init_Staff 新視窗的相對位置#############
            inQS_Product.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //############################################
            inQS_Product.Server_ENV.Text = QS_ii_Server_ENV.Text;      //server
            inQS_Product.USER_ID.Text = USER_ID.Text;      //UID
            inQS_Product.ShowDialog();
        }

        private void QS_ii_查詢button_Click(object sender, EventArgs e)
        {
            start_status(QS_ii_查詢button);
        }

        private void QS_ii_儲存button_Click(object sender, EventArgs e)
        {
            if (Status_info.Text == "新增")
            {
                #region 內容
                //Product_Add();
                Quotes_Add();       //報價單新增                
                #endregion
            }
            else if (Status_info.Text == "修改")
            {
                #region 內容
                Quotes_Modify();        //報價單修改                
                #endregion
            }

        }

        private void QS_ii_取消button_Click(object sender, EventArgs e)
        {
            start_status(QS_ii_取消button);

        }

        private void Product_新增button_Click(object sender, EventArgs e)
        {
            #region  內容
            QS_ii_TQueryDGV ProductADD = new QS_ii_TQueryDGV(this);
            Product_Query(ProductADD.QS_ii_DGView1);        //商品主檔查詢            
            //設定init_Staff 新視窗的相對位置#############
            ProductADD.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //############################################            
            ProductADD.ShowDialog();
            #endregion
        }

        private void Product_刪除button_Click(object sender, EventArgs e)
        {
            #region 內容
            for (int i = 0; i < this.QS_ii_Product_DGV.Rows.Count; i++)
            {
                if (QS_ii_Product_DGV.Rows[i].Cells[0].Value.ToString() == "1")
                {
                    this.QS_ii_Product_DGV.Rows.Remove(this.QS_ii_Product_DGV.Rows[i]);                    
                    i = -1;
                }
                
            }
            QSiiDB.QS_ii_QProduct.AcceptChanges();      //****重要****上面是刪除DGV中的資料~要加這行才算是更新DataTable
            #endregion
        }

        private void Product_多選button_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = QSiiDB.QS_ii_QProduct;
        }

        private void QS_ii_歷史查詢button_Click(object sender, EventArgs e)
        {
            start_status(QS_ii_歷史查詢button);
            Quotes_HQuery();        //歷史記錄查詢

        }

        private void QS_ii_Product_DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        //==============================================================================================================
        #endregion

        #region 事件
        //==============================================================================================================

        private void QS_ii_Product_DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)         //QS_ii_Product_DGV中的Checkbox
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                #region 內容
                 
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)QS_ii_Product_DGV.Rows[e.RowIndex].Cells[0];
                //DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)QS_ii_Product_DGV.Rows[e.RowIndex].Cells[0];
                //Boolean flag = Convert.ToBoolean(QS_ii_Product_DGV.Rows[e.RowIndex].Cells[0].Value);
                string flag = QS_ii_Product_DGV.Rows[e.RowIndex].Cells[0].Value.ToString();
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

        private void tb_EXC_RATE_KeyPress(object sender, KeyPressEventArgs e)           //限制tb_EXC_RATE只能輸入數字
        {
            fun.TxTLimit_input_money(e);       //限制Text只能輸入數字
        }

        private void tb_HQuery_CUST_NO_KeyDown(object sender, KeyEventArgs e)        //歷史記錄查詢-客戶編號Textbox
        {
            if (e.KeyCode == Keys.Enter)
            {
                QS_ii_客戶_Open();
            }            
        }

        private void QS_ii_HQuery_DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)       //QS_ii_HQuery_DGV雙擊二下
        {
            if (e.RowIndex >= 0)
            {
                QT_NO = QS_ii_HQuery_DGV.CurrentRow.Cells[0].Value.ToString();
                CUST_NO = QS_ii_HQuery_DGV.CurrentRow.Cells[1].Value.ToString();                
                Quotes_HQueryDoubleClick();
                //QS_ii_HQProduct_ds
                //GetSQL("DGV1_檔案查詢", get_ID);    //語法丟進fun.Query_DB
                //fun.xxx_DB(Query_DB, DMS_dataGridView2);         //連接DB-執行DB指令                 
                //DMS_tabControl1.SelectedIndex = 1;

            }
        }
        
        //==============================================================================================================
        #endregion

    }

    public class QS_ii_TCustomer : QS_ii_Customer       //客戶主檔
    {
        QS_ii_Quotes_add QS_iiQ_add;

        public QS_ii_TCustomer(QS_ii_Quotes_add x)
        {
            this.QS_iiQ_add = x;
        }

        public override void Customer_import_Head()         //引入到報價單主檔表頭
        {
            QS_iiQ_add.tb_PROD_TYPE.Text = tb_CUST_TYPE.Text;       //客戶類別
            QS_iiQ_add.tb_CUST_NO.Text = tb_CUST_NO.Text;           //客戶編號
            QS_iiQ_add.tb_CUST_NAME.Text = tb_CUST_NAME.Text;       //客戶名稱
            QS_iiQ_add.tb_VAT_NO.Text = tb_VAT_NO.Text;             //統一編號
            QS_iiQ_add.tb_CHAIN_NO.Text = tb_CHAIN_NAME.Text;       //通路名稱
            QS_iiQ_add.tb_CONT_TITLE.Text = tb_CONT_TITLE.Text;     //連絡人職稱
            QS_iiQ_add.tb_CONTACT.Text = tb_CONTACT.Text;           //連絡人
            QS_iiQ_add.tb_CONT_TEL.Text = tb_CONT_TEL.Text;         //連絡人電話
            QS_iiQ_add.tb_FAX.Text = tb_FAX.Text;                   //傳真
            QS_iiQ_add.tb_CUST_MAIL.Text = tb_CUST_MAIL.Text;       //客戶MAIL
            QS_iiQ_add.tb_CUST_ADDR.Text = tb_CUST_ADDR.Text;       //公司地址
            QS_iiQ_add.tb_DELI_ADDR_NO.Text = tb_DELI_ADDR_NO.Text;       //郵地區號
            QS_iiQ_add.tb_DELI_ADDR.Text = tb_DELI_ADDR.Text;             //送貨地址
            QS_iiQ_add.tb_PAY_METH.Text = tb_PAY_METH.Text;             //付款方式

            QS_iiQ_add.tb_HQuery_CUST_NO.Text = tb_CUST_NO.Text;           //負責業務
        }
    }

    public class QS_ii_TProduct : QS_ii_Product         //商品主檔
    {
        QS_ii_Quotes_add QS_iiQ_add;

        public QS_ii_TProduct(QS_ii_Quotes_add x)
        {
            QS_iiQ_add = x;
            QS_Quotes_DGV = QS_iiQ_add.QS_ii_Product_DGV;
        }
        

        public override void QS_ii_Add_Product_Detail()     //增加至報價單商品明細
        {
            #region 內容
            DataColumn Amount = QS_iiQ_add.QSiiDB.QS_ii_QProduct.AMOUNTColumn;      //單價*數量
            Amount.Expression = "QTY*UNIT_PRICE";
            DataColumn SubTotal = QS_iiQ_add.QSiiDB.QS_ii_QProduct.SubTotalColumn;      //SUM(單價*數量)
            SubTotal.Expression = "SUM(AMOUNT)";
            DataColumn ColTax = QS_iiQ_add.QSiiDB.QS_ii_QProduct.ColTaxColumn;          //SUM(單價*數量)*0.05 =>稅額
            ColTax.Expression = "SUM(AMOUNT)*0.05";
            DataColumn TOT_AMT = QS_iiQ_add.QSiiDB.QS_ii_QProduct.TOT_AMTColumn;        //SUM(單價*數量)*1.05 =>稅後總額
            TOT_AMT.Expression = "(SubTotal)+(ColTax)";
            //QS_iiQ_add.tb_AMT_NOTAX.Text = QS_iiQ_add.QSiiDB.QS_ii_QProduct.Compute("sum(AMOUNT)", "").ToString();
            
            
            DataRow QS_ii_dr = QS_iiQ_add.QSiiDB.QS_ii_QProduct.NewRow();
            QS_ii_dr["Check"] = "0";
            QS_ii_dr["item_NO"] = tb_item_NO.Text;
            QS_ii_dr["item_NAME"] = tb_item_NAME.Text;
            QS_ii_dr["SPEC"] = tb_SPEC.Text;
            QS_ii_dr["UNIT"] = tb_UNIT.Text;
            QS_ii_dr["QTY"] = 1;
            QS_ii_dr["UNIT_PRICE"] = Convert.ToSingle(tb_UNIT_PRICE.Text.Trim());            
            QS_iiQ_add.QSiiDB.QS_ii_QProduct.Rows.Add(QS_ii_dr);

            #endregion
        }
        
    }

    public class QS_ii_TQueryDGV : QS_ii_QueryDGV       //查詢
    {
        QS_ii_Quotes_add QS_iiQ_add;

        public QS_ii_TQueryDGV(QS_ii_Quotes_add x)
        {
            this.QS_iiQ_add = x;
        }

        public override void QS_ii_QueryDGV_DGView1()       //把選取資料對應到TextBox
        {
            #region 內容
            DataColumn Amount = QS_iiQ_add.QSiiDB.QS_ii_QProduct.AMOUNTColumn;      //單價*數量
            Amount.Expression = "QTY*UNIT_PRICE";
            DataColumn SubTotal = QS_iiQ_add.QSiiDB.QS_ii_QProduct.SubTotalColumn;      //SUM(單價*數量)
            SubTotal.Expression = "SUM(AMOUNT)";
            DataColumn ColTax = QS_iiQ_add.QSiiDB.QS_ii_QProduct.ColTaxColumn;          //SUM(單價*數量)*0.05 =>稅額
            ColTax.Expression = "SUM(AMOUNT)*0.05";
            DataColumn TOT_AMT = QS_iiQ_add.QSiiDB.QS_ii_QProduct.TOT_AMTColumn;        //SUM(單價*數量)*1.05 =>稅後總額
            TOT_AMT.Expression = "(SubTotal)+(ColTax)";
            //QS_iiQ_add.tb_AMT_NOTAX.Text = QS_iiQ_add.QSiiDB.QS_ii_QProduct.Compute("sum(AMOUNT)", "").ToString();


            DataRow QS_ii_dr = QS_iiQ_add.QSiiDB.QS_ii_QProduct.NewRow();
            QS_ii_dr["Check"] = "0";
            QS_ii_dr["item_NO"] = QS_ii_DGView1.CurrentRow.Cells["商品編號"].Value.ToString();
            QS_ii_dr["item_NAME"] = QS_ii_DGView1.CurrentRow.Cells["商品名稱"].Value.ToString();
            QS_ii_dr["SPEC"] = QS_ii_DGView1.CurrentRow.Cells["規格"].Value.ToString();
            QS_ii_dr["UNIT"] = QS_ii_DGView1.CurrentRow.Cells["單位"].Value.ToString();
            QS_ii_dr["QTY"] = 1;
            QS_ii_dr["UNIT_PRICE"] = Convert.ToSingle(QS_ii_DGView1.CurrentRow.Cells["單價"].Value.ToString());
            QS_iiQ_add.QSiiDB.QS_ii_QProduct.Rows.Add(QS_ii_dr);

            #endregion          

        }
    }

}
