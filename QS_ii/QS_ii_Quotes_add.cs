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
        QS_ii_function QSfun = new QS_ii_function();

        public QS_ii_DB QSiiDB = new QS_ii_DB();        

        public QS_ii_Quotes_add()
        {
            InitializeComponent();
        }

        private void QS_ii_main_Load(object sender, EventArgs e)
        {
            default_status();
            //QS_ii_Head_DataBinding(QSiiDB.QS_ii_HQT01);           //datatable的欄位與Text綁定資料-報價單表頭
            //QS_ii_DataBinding(QSiiDB.QS_ii_QProduct);           //datatable的欄位與Text綁定資料-金額欄位

        }

        #region 變數
        //==============================================================================================================

        public QS_ii_function fun
        {
            get
            {
                return this.QSfun;
            }
        }

        public string QueryDB       //DB連線字串
        {
            set;
            get;
        }

        private string QT_NO         //報價單號
        {
            set;
            get;
        }

        private string CUST_NO       //客戶編號
        {
            set;
            get;
        }

        private string ALLOW_QS     //是不核准報價的變數
        {
            set;
            get;
        }

        private string QS_ii_QuotesNO       //報價單號變數
        {
            set;
            get;
        }

        public string DATE_value       //報價日期
        {
            set;
            get;
        }

        private string DATE_END_value    //報價有效日期
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
            if (x == "新增-表頭新增")
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
            else if(x == "新增-表身新增")
            {
                QueryDB = @"exec [TEST_SLSYHI].[dbo].[SLS_QS_Insert_Detail] @QT_NO,@item_NO,@item_NAME,@SPEC,@UNIT,@QTY,@UNIT_PRICE,@AMOUNT,'" + USER_ID.Text + "'";
            }
            else if(x== "表頭修改")
            {
                #region 內容
                //QueryDB = @"exec [TEST_SLSYHI].[dbo].[SLS_QS_Update] @QT_NO,@QT_DATE,@EFF_DATE,@AMT_NOTAX,@TAX_AMT,@TOT_AMT,@REMARK,'" + USER_ID.Text + "'";
                QueryDB = @"exec [TEST_SLSYHI].[dbo].[SLS_QS_Update] '" + tb_QT_NO.Text +
                            @"','" + QT_DATE_dTP.Text +
                            @"','" + QT_EFF_DATE_dTP.Text +
                            @"','" + tb_AMT_NOTAX.Text +
                            @"','" + tb_TAX_AMT.Text +
                            @"','" + tb_TOT_AMT.Text +
                            @"','" + tb_REMARK.Text +
                            @"','" + USER_ID.Text + "'";
                             
                #endregion

            }
            else if(x == "修改-表身新增")
            {
                QueryDB = @"exec [TEST_SLSYHI].[dbo].[SLS_QS_Insert_Detail] @QT_NO,@item_NO,@item_NAME,@SPEC,@UNIT,@QTY,@UNIT_PRICE,@AMOUNT,'" + USER_ID.Text + "'";
                //fun.QS_ii_QDetailADD = @"exec [TEST_SLSYHI].[dbo].[SLS_QS_Insert_Detail] @QT_NO,@item_NO,@item_NAME,@SPEC,@UNIT,@QTY,@UNIT_PRICE,@AMOUNT,'" + USER_ID.Text + "'";   
            }
            else if (x == "修改-表身修改")
            {
                #region 內容

                QueryDB = @"exec [TEST_SLSYHI].[dbo].[SLS_QS_Update_Detail] @QT_NO,@item_NO,@QTY,@AMOUNT,'" + USER_ID.Text + "'";
                //fun.QS_ii_QDetailMOD = @"exec [TEST_SLSYHI].[dbo].[SLS_QS_Update_Detail] @QT_NO,@item_NO,@QTY,@AMOUNT,'" + USER_ID.Text + "'";
                #endregion
            }
            else if (x == "修改-表身刪除")
            {
                #region 內容
                QueryDB = @"exec [TEST_SLSYHI].[dbo].[SLS_QS_Delete_Detail] @QT_NO,@item_NO";
                //fun.QS_ii_QDetailDEL = @"exec [TEST_SLSYHI].[dbo].[SLS_QS_Delete_Detail] @QT_NO,@item_NO";
                #endregion

            }
            else if (x == "歷史報價查詢")
            {
                #region 內容
                QueryDB = @"select * from [TEST_SLSYHI].[dbo].[SLS_QS_Query_HQT]() where [QT_NO] is not null ";
                if (tb_HQuery_CUST_NO.Text != "")
                {
                    QueryDB += "and CUST_NO = '" + tb_HQuery_CUST_NO.Text + "'";        //客戶編號
                }
                if (tb_HQuery_item_NO.Text != "")
                {
                    QueryDB += "and item_NO = '" + tb_HQuery_item_NO.Text + "'";        //商品編號
                }
                QueryDB += "order by 1";
                #endregion
            }
            else if (x == "歷史表頭")
            {
                #region 內容
                //QueryDB = @"select * from [TEST_SLSYHI].[dbo].[SLS_QS_CUST_QueryTemp]() where [DEL_FALG] = 'N' and [客戶編號] = '" + CUST_NO + "'";
                //QueryDB = @"select * from [TEST_SLSYHI].[dbo].[SLS_QS_CUST_QueryTemp]() where [DEL_FALG] = 'N' and [客戶編號] = '" + CUST_NO + "'";
                QueryDB = @"exec [TEST_SLSYHI].[dbo].[SLS_QS_Query_HQT01] '" + QT_NO + "'";
                #endregion
            }
            else if (x == "歷史表身")
            {
                #region 內容
                QueryDB = @"exec [TEST_SLSYHI].[dbo].[SLS_QS_Query_HQT02] '" + QT_NO + "'";
                #endregion
            }
            else if(x =="客戶主檔查詢")
            {
                #region 內容
                QueryDB = @"exec [TEST_SLSYHI].[dbo].[SLS_QS_CUST_Query] '" + CUST_NO + "'";
                #endregion
            }
            else if (x == "客戶主檔快速查詢")
            {
                #region 內容
                QueryDB = @"select TOP 100 [Check] = '0',* from  [TEST_SLSYHI].[dbo].[SLS_QS_CUST_QueryTemp_ADD](" + USER_ID.Text + ") where [DEL_FALG] = 'N'";
                #endregion

            }
            else if (x == "多選商品主檔")
            {
                #region 內容
                QueryDB = @"select TOP 100 [Check] = '0',* from [TEST_SLSYHI].[dbo].[SLS_QS_Product_QueryTemp_ADD](" + USER_ID.Text + ") where [DEL_FALG] = 'N'";

                #endregion
            }
            else if(x == "商品主檔查詢")
            {
                #region 內容
                QueryDB = @"select TOP 100 * from [TEST_SLSYHI].[dbo].[SLS_QS_Product_QueryTemp_ADD](" + USER_ID.Text + ") where [DEL_FALG] = 'N'";
                #endregion
            }
            else if (x == "取得日期")
            {
                #region 內容
                QueryDB = @"select replace(CONVERT(nvarchar(10),GETDATE(),111),'/','-'),replace(CONVERT(nvarchar(10),GETDATE()+7,111),'/','-')";
                #endregion
            }
            else if (x == "取得有效日期")
            {
                #region 內容
                QueryDB = @"select CONVERT(date,GETDATE()+7,111)";
                #endregion
            }           
            
        }
        
        public void default_status()            //預設狀態
        {
            #region 內容
            this.Text = "報價系統";
            //this.MaximizeBox = true;       //最大化
            //this.MinimizeBox = true;       //最小化
            this.FormBorderStyle = FormBorderStyle.FixedSingle;     //限制使用者改變form大小
            this.AutoSize = false;          //自動調整大小
            //this.Size = new System.Drawing.Size(1249, 882);      //設定Form大小            
            Product_DGV_SetColumns();           //QS_ii_Product_DGV自定顯示欄位
            HQuery_DGV_SetColumns();            //QS_ii_HQuery_DGV自定顯示欄位           
            QS_ii_Product_DGV.DataSource = QSiiDB.QS_ii_QProduct;       //DGV綁定DataSource
            //dataGridView1.DataSource = QSiiDB.QS_ii_LOGIN;          //DGV綁定DataSource
            //dataGridView2.DataSource = QSiiDB.QS_ii_QCustomer;          //DGV綁定DataSource            
            fun.Format_Panel_dTP(QS_ii_Head_panel, "yyyy-MM-dd");     //自訂日期格式
            fun.EoD_Panel_txt(QS_ii_Head_panel, true);     //QS_ii_Head_panel內的TextBox設定唯讀
            fun.EoD_Panel_DateTimePicker(QS_ii_Head_panel, false);       //QS_ii_Head_panel內的DateTimePicker設定唯讀
            //fun.EoD_Panel_txt(QS_ii_Check_panel, true);             //QS_ii_Check_panel內的TextBox設定唯讀
            fun.EoD_Panel_RadioButton(QS_ii_Check_panel, false);    //QS_ii_Check_panel內的RadioButton設定唯讀
            fun.EoD_Panel_txt(QS_ii_money_panel, true);     //QS_ii_money_panel內的TextBox設定唯讀
            USER_ID.Text = QSiiDB.QS_ii_LOGIN.Rows[0]["EMP_ID"].ToString();
            fun.ReMAC(Local_MAC, Local_IP);         //取得本機MAC及IP 
            SYS_log("登入成功");             //在DB記錄登入狀態
            
            #region 取得DB日期
            GetSQL("取得日期");
            fun.ProductDB_ds(QueryDB);
            DATE_value = fun.ds_index.Tables[0].Rows[0][0].ToString();      //設定報價日期
            DATE_END_value = fun.ds_index.Tables[0].Rows[0][1].ToString();      //設定報價有效日期
            #endregion
            QS_ii_Product_DGV_Column1.Visible = false;      //報價單明細<選取>關閉
            QS_ii_Product_DGV_Column6.ReadOnly = true;      //報價單明細<數量>唯讀
            tb_REMARK.ReadOnly = true;
            QS_ii_查詢button.Visible = false;
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
            QS_ii_Query_CUST_NO.Enabled = false;
            QS_ii_Query_CUST_NAME.Enabled = false;
            QS_ii_Query_VAT_NO.Enabled = false;
            Status_info.Visible = false;

            //*****在綁定資料後的敘述不會啟動*****
            QS_ii_Head_DataBinding(QSiiDB.QS_ii_HQT01);           //datatable的欄位與Text綁定資料-報價單表頭            
            QS_ii_PriceDataBinding(QSiiDB.QS_ii_QProduct);     //datatable的欄位與Text綁定資料-金額欄位
            #endregion
        }

        private void start_status(Button x)      //啟動狀態
        {
            if (x == QS_ii_新增button)
            {
                #region 內容
                Status_info.Text = "新增";
                Status_info.Visible = true;
                tb_QT_NO.Text = "";                
                //fun.EoD_Panel_txt(QS_ii_Head_panel, false);                 //QS_ii_Head_panel內的TextBox設定可讀寫
                //fun.EoD_Panel_DateTimePicker(QS_ii_Head_panel, true);      //QS_ii_Head_panel內的DateTimePicker設定可讀寫
                fun.clearAir(QS_ii_Head_panel);     //清空報價單-表頭
                fun.clearAir(QS_ii_Other_panel);     //清空報價單-其他
                fun.clearAir(QS_ii_Check_panel);     //清空報價單-簽核
                fun.clearAir(QS_ii_money_panel);     //清空報價單-金額

                tb_REMARK.ReadOnly = false;
                Product_多選button.Visible = true;
                Product_新增button.Visible = true;
                Product_刪除button.Visible = true;
                QS_ii_Product_DGV_Column1.Visible = true;           //報價單明細<選取>顯示
                QS_ii_Product_DGV_Column6.ReadOnly = false;      //報價單明細<數量>可讀寫

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
                QS_ii_Query_CUST_NO.Enabled = true;
                QS_ii_Query_CUST_NAME.Enabled = true;
                QS_ii_Query_VAT_NO.Enabled = true;

                QT_DATE_dTP.Text = DATE_value;
                QT_EFF_DATE_dTP.Text = DATE_END_value;
                //******清除DataTable******
                QSiiDB.QS_ii_QProduct.Clear();      //清除DataTable

                #endregion
            }
            else if (x == QS_ii_修改button)
            {
                #region 內容
                Status_info.Text = "修改";
                Status_info.Visible = true;
                QS_ii_新增button.Enabled = false;
                QS_ii_修改button.Enabled = false;
                tb_REMARK.ReadOnly = false;
                //QS_ii_產品button.Enabled = false;
                Product_多選button.Visible = true;
                Product_新增button.Visible = true;
                Product_刪除button.Visible = true;
                QS_ii_Product_DGV_Column1.Visible = true;           //報價單明細<選取>顯示
                QS_ii_Product_DGV_Column6.ReadOnly = false;      //報價單明細<數量>可讀寫
                QS_ii_刪除button.Enabled = false;
                QS_ii_查詢button.Enabled = false;
                QS_ii_儲存button.Visible = true;
                QS_ii_取消button.Visible = true;
                QS_ii_儲存button.Enabled = true;
                QS_ii_取消button.Enabled = true;
                QS_ii_Query_CUST_NO.Enabled = false;
                QS_ii_Query_CUST_NAME.Enabled = false;
                QS_ii_Query_VAT_NO.Enabled = false;
                           
                QS_ii_PriceDataBinding(QSiiDB.QS_ii_QProduct);     //datatable的欄位與Text綁定資料-金額欄位
                #endregion
            }
            else if (x == QS_ii_刪除button)
            {

            }
            else if (x == QS_ii_查詢button)
            {
                Status_info.Text = "瀏覽";
                Status_info.Visible = false;

            }
            else if(x == QS_ii_儲存button)
            {
                #region 內容
                Status_info.Text = "瀏覽";
                Status_info.Visible = false;
                fun.EoD_Panel_txt(QS_ii_Head_panel, true);                 //QS_ii_Head_panel內的TextBox設定唯讀
                fun.EoD_Panel_DateTimePicker(QS_ii_Head_panel, false);      //QS_ii_Head_panel內的DateTimePicker設定唯讀
                tb_SALESMAN.Text = "";        //報價業務
                QSiiDB.QS_ii_QProduct.Clear();      //清空DATATable
                QSiiDB.QS_ii_HQT01.Clear();      //清空DATATable

                fun.clearAir(QS_ii_Head_panel);     //清空報價單-表頭
                fun.clearAir(QS_ii_Other_panel);     //清空報價單-其他
                fun.clearAir(QS_ii_Check_panel);     //清空報價單-簽核
                fun.clearAir(QS_ii_money_panel);     //清空報價單-金額


                tb_REMARK.ReadOnly = true;
                Product_多選button.Visible = false;
                Product_新增button.Visible = false;
                Product_刪除button.Visible = false;
                QS_ii_Product_DGV_Column1.Visible = false;          //報價單明細<選取>關閉
                QS_ii_Product_DGV_Column6.ReadOnly = true;      //報價單明細<數量>唯讀
                QS_ii_新增button.Enabled = true;
                QS_ii_修改button.Enabled = true;
                //QS_ii_產品button.Enabled = true;
                QS_ii_刪除button.Enabled = true;
                QS_ii_查詢button.Enabled = true;
                QS_ii_儲存button.Visible = false;
                QS_ii_取消button.Visible = false;
                QS_ii_儲存button.Enabled = false;
                QS_ii_取消button.Enabled = false;
                QS_ii_Query_CUST_NO.Enabled = false;
                QS_ii_Query_CUST_NAME.Enabled = false;
                QS_ii_Query_VAT_NO.Enabled = false;
                #endregion
            }
            else if(x == QS_ii_取消button)
            {
                #region 內容
                Status_info.Text = "瀏覽";
                Status_info.Visible = false;
                fun.EoD_Panel_txt(QS_ii_Head_panel, true);                 //QS_ii_Head_panel內的TextBox設定唯讀
                fun.EoD_Panel_DateTimePicker(QS_ii_Head_panel, false);      //QS_ii_Head_panel內的DateTimePicker設定唯讀
                tb_SALESMAN.Text = "";        //報價業務

                tb_REMARK.ReadOnly = true;
                Product_多選button.Visible = false;
                Product_新增button.Visible = false;
                Product_刪除button.Visible = false;
                QS_ii_新增button.Enabled = true;
                QS_ii_修改button.Enabled = true;
                QS_ii_Product_DGV_Column1.Visible = false;          //報價單明細<選取>關閉
                QS_ii_Product_DGV_Column6.ReadOnly = true;      //報價單明細<數量>唯讀
                //QS_ii_產品button.Enabled = true;
                QS_ii_刪除button.Enabled = true;
                QS_ii_查詢button.Enabled = true;
                QS_ii_儲存button.Visible = false;
                QS_ii_取消button.Visible = false;
                QS_ii_儲存button.Enabled = false;
                QS_ii_取消button.Enabled = false;
                QS_ii_Query_CUST_NO.Enabled = false;
                QS_ii_Query_CUST_NAME.Enabled = false;
                QS_ii_Query_VAT_NO.Enabled = false;

                QSiiDB.QS_ii_QProduct.RejectChanges();
                #endregion

            }
            else if (x == QS_ii_歷史查詢button)
            {

            }
            else if (x == QS_ii_通路button)
            {


            }

        }

        private void SYS_log(string x)        //在DB記錄執行狀態
        {
            int N = Local_IP.Text.LastIndexOf(".");
            int Q = Local_IP.Text.Length;
            fun.Local_ID = USER_ID.Text;
            fun.Local_SYS = this.Text;
            fun.Local_PROC_NAME = x;
            fun.Local_MYIP = Local_IP.Text.Substring(N,Q-N);
            fun.Local_MYMAC = "";
            fun.Local_HOST_NAME = QS_ii_Server_ENV.Text;
            fun.Local_PCNAME = Environment.MachineName;
            fun.Local_USERNAME = Environment.UserName;
            fun.Login_log();
        }
                
        private void Quotes_Add()           //報價單新增
        {
            #region 內容
            if (MessageBox.Show("確定要新增？", "警告!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                fun.Check_error = false;
                GetSQL("新增-表頭新增");
                fun.Quotes_ADD = QueryDB;                           
                GetSQL("新增-表身新增");                
                fun.Quotes_Detail_ADD = QueryDB;
                fun.QS_ii_QT01_insert(QSiiDB.QS_ii_QProduct);
                if (fun.Check_error == false)
                {                    
                    start_status(QS_ii_儲存button);
                    QSiiDB.QS_ii_QProduct.AcceptChanges();      //****重要****要加這行才算是更新DataTable
                    SYS_log("新增報價單");          //在DB記錄執行狀態
                    MessageBox.Show("資料《新增》成功!!", this.Text);
                }
            }
            #endregion
        }

        private void Quotes_Modify()        //報價單修改
        {
            #region 內容
            if (MessageBox.Show("確定要修改？", "警告!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                fun.Check_error = false;
                GetSQL("修改-表身修改");
                fun.QS_ii_ModifyProductMODIFY_ds(QueryDB, QSiiDB.QS_ii_QProduct);
                GetSQL("修改-表身刪除");
                fun.QS_ii_ModifyProductDEL_ds(QueryDB, QSiiDB.QS_ii_QProduct);
                GetSQL("修改-表身新增");
                fun.QS_ii_ModifyProductADD_ds(QueryDB, QSiiDB.QS_ii_QProduct);
                GetSQL("表頭修改");
                fun.QS_ii_ModifyQT01_ds(QueryDB);
                //fun.QS_ii_QText(QSiiDB.QS_ii_QProduct);                
                if (fun.Check_error == false)
                {
                    start_status(QS_ii_儲存button);
                    QSiiDB.QS_ii_QProduct.AcceptChanges();      //****重要****要加這行才算是更新DataTable
                    SYS_log("修改報價單");          //在DB記錄執行狀態
                    MessageBox.Show("資料《修改》成功!!", this.Text);
                }
            }

            #endregion
        }

        private void Quotes_Delete()        //報價單刪除
        {
            if (tb_QT_NO.Text != "")
            {
                MessageBox.Show("目前無權限刪除!!", this.Text);
            }
            else
            {
                MessageBox.Show("沒有報價單號!!",this.Text);
            }
            
        }

        private void Quotes_HQueryDoubleClick()             //報價單查詢==>QS_ii_HQuery_DGV雙擊二下
        {
            #region 內容
            tb_QT_NO.Text = QT_NO;
            GetSQL("歷史表頭");
            fun.QS_ii_HQTQuery_ds(QueryDB, QSiiDB.QS_ii_HQT01);
            GetSQL("客戶主檔查詢");
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

        private void Quotes_Detail_Modify(Button x)          //報價單明細新增資料的方法(多選or單選)
        {
            #region  內容
            QS_ii_TQueryDGV ProductADD = new QS_ii_TQueryDGV(this);
            
            ProductADD.QS_ii_QueryDGV_Column1.DataPropertyName = "Check";
            if (x == Product_新增button)
            {
                ProductADD.QS_ii_QueryDGV_Column1.Visible = false;           //自訂DGV欄位設定顯示or隱藏
                ProductADD.加入button_Visible = false;                
            }
            else if (x == Product_多選button)
            {
                ProductADD.QS_ii_QueryDGV_Column1.Visible = true;           //自訂DGV欄位設定顯示or隱藏
                ProductADD.加入button_Visible = true;                
            }
            Product_Query(ProductADD.QS_ii_QueryDGv_PID, QSiiDB.QS_ii_Product, ProductADD.QS_ii_DGView1);        //商品主檔查詢
            //設定init_Staff 新視窗的相對位置#############
            ProductADD.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //############################################            
            ProductADD.ShowDialog();
            #endregion
        }

        private void QS_ii_客戶_Open()       //客戶主檔開窗
        {
            QS_ii_TCustomer inSea = new QS_ii_TCustomer(this);            
            inSea.引入Button_ToF = Status_info.Text == "新增" ? true : false;            
            //設定init_Staff 新視窗的相對位置#############
            inSea.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //############################################
            inSea.Server_ENV.Text = QS_ii_Server_ENV.Text;      //server
            inSea.USER_ID.Text = USER_ID.Text;          //UID
            inSea.ShowDialog();
        }

        private void QS_ii_產品_Open()       //商品主檔開窗
        {
            QS_ii_TProduct inQS_Product = new QS_ii_TProduct(this);
            //設定init_Staff 新視窗的相對位置#############
            inQS_Product.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //############################################
            inQS_Product.Server_ENV.Text = QS_ii_Server_ENV.Text;      //server
            inQS_Product.USER_ID.Text = USER_ID.Text;      //UID
            inQS_Product.ShowDialog();

        }

        private void QS_ii_通路_Open()       //通路主檔開窗
        {
            QS_ii_ProductSC inQS_ProductSC = new QS_ii_ProductSC(this);
            //設定init_Staff 新視窗的相對位置#############
            inQS_ProductSC.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //############################################
            inQS_ProductSC.Server_ENV.Text = QS_ii_Server_ENV.Text;      //server
            inQS_ProductSC.USER_ID.Text = USER_ID.Text;      //UID
            inQS_ProductSC.ShowDialog();

        }

        private void Query_CUST(string x)        //報價單-客戶查詢
        {
            #region 內容
            QS_ii_TQuery_CUST CUSTQuery = new QS_ii_TQuery_CUST(this);
            //設定init_Staff 新視窗的相對位置#############
            CUSTQuery.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //############################################
            CUSTQuery.加入button_Visible = false;
            CUSTQuery.QS_ii_QueryDGV_Column1.Visible = false;
            CUSTQuery.QS_ii_QueryDGV_Column1.DataPropertyName = "Check";
            CUSTQuery.NOID_Value = x + ":";
            CUST_Query(x, CUSTQuery.QS_ii_QueryDGv_PID, QSiiDB.QS_ii_Customer, CUSTQuery.QS_ii_DGView1);          //依客戶編號-查詢客戶主檔            
            CUSTQuery.ShowDialog();
            #endregion
        }

        private void HQuery_CUST_NO(string x)        //歷史記錄查詢-客戶編號查詢
        {
            //QS_ii_THQuery_CUST
            #region 內容
            QS_ii_THQuery HCUSTQuery = new QS_ii_THQuery(this);
            //設定init_Staff 新視窗的相對位置#############
            HCUSTQuery.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //############################################
            HCUSTQuery.加入button_Visible = false;
            HCUSTQuery.QS_ii_QueryDGV_Column1.Visible = false;
            HCUSTQuery.QS_ii_QueryDGV_Column1.DataPropertyName = "Check";
            HCUSTQuery.NOID_Value = x + ":";
            CUST_Query(x, HCUSTQuery.QS_ii_QueryDGv_PID, QSiiDB.QS_ii_Customer, HCUSTQuery.QS_ii_DGView1);          //依客戶編號-查詢客戶主檔            
            HCUSTQuery.ShowDialog();
            #endregion
        }

        private void HQuery_Item_NO(string x)       //歷史記錄查詢-商品編號查詢
        {
            #region 內容
            QS_ii_THQuery HCUSTQuery = new QS_ii_THQuery(this);
            //設定init_Staff 新視窗的相對位置#############
            HCUSTQuery.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //############################################
            HCUSTQuery.加入button_Visible = false;
            HCUSTQuery.QS_ii_QueryDGV_Column1.Visible = false;
            HCUSTQuery.QS_ii_QueryDGV_Column1.DataPropertyName = "Check";
            HCUSTQuery.NOID_Value = x + ":";
            Product_Query(tb_HQuery_item_NO, QSiiDB.QS_ii_Product, HCUSTQuery.QS_ii_DGView1);          //依客戶編號-查詢客戶主檔            
            HCUSTQuery.ShowDialog();
            #endregion
        }

        private void Query_CUST_NO()        //客戶編號快速查詢
        {
            #region 內容
            Query_CUST("客戶編號");        //客戶查詢
            #endregion
        }

        private void Query_CUST_NAME()      //客戶名稱快速查詢
        {
            #region 內容
            Query_CUST("客戶名稱");        //客戶查詢
            #endregion
        }

        public void Query_VAT_NO()         //客戶統一編號快速查詢
        {
            #region 內容
            Query_CUST("統一編號");        //客戶查詢
            #endregion
        }

        public void Product_Query(TextBox tx, DataTable Dx, DataGridView dgv)        //依商品編號-查詢商品主檔
        {
            
            GetSQL("多選商品主檔");    //語法丟進QueryDB
            if (tx.Text != "")
            {
                QueryDB += @"and [商品編號] like '" + tx.Text.Trim() + "%'";
            }

            fun.QS_ii_ProductM_ds(QueryDB,Dx,dgv);         //連接DB-執行DB指令

        }

        public void Product_Query(DataGridView dgv)            //依商品編號-查詢商品主檔
        {
            GetSQL("商品主檔查詢");    //語法丟進QueryDB            
            fun.xxx_DB(QueryDB, dgv);         //連接DB-執行DB指令
        }

        public void CUST_Query(string stx ,TextBox tx, DataTable Dx, DataGridView dgv)          //依客戶編號-查詢客戶主檔
        {
            #region 內容
            if (stx != null)
            {
                GetSQL("客戶主檔快速查詢");    //語法丟進QueryDB
                if (tx.Text != "")
                {
                    QueryDB += @"and [" + stx + "] like N'%" + tx.Text.Trim() + "%'";
                }
                else
                {
                    QueryDB += @" order by [客戶編號]";
                }
                fun.QS_ii_Query(QueryDB, Dx, dgv);         //連接DB-執行DB指令
            }
            else
            {
                MessageBox.Show("變數不能為NULL!!",this.Text);
            }
            

            #endregion
        }

        private void QS_ii_Head_DataBinding(DataTable x)        //datatable的欄位與Text綁定資料-報價單表頭
        {
            QT_DATE_dTP.DataBindings.Add("Text", x, "QT_DATE", true);
            QT_EFF_DATE_dTP.DataBindings.Add("Text", x, "EFF_DATE", true);
            tb_REMARK.DataBindings.Add("Text", x, "REMARK", true);
        }

        public void QS_ii_PriceDataBinding(DataTable x)     //datatable的欄位與Text綁定資料-金額欄位
        {
            tb_AMT_NOTAX.DataBindings.Clear();
            tb_TAX_AMT.DataBindings.Clear();
            tb_TOT_AMT.DataBindings.Clear();
            if (Status_info.Text == "新增" || Status_info.Text == "修改")
            {                
                tb_AMT_NOTAX.DataBindings.Add("Text", x, "AMT_NOTAX", true);     //總金額 (未稅)綁定資料
                tb_TAX_AMT.DataBindings.Add("Text", x, "TAX_AMT", true);     //稅額 綁定資料
                tb_TOT_AMT.DataBindings.Add("Text", x, "TOT_AMT", true);     //含稅總額 綁定資料
            }
            
            
        }

        public void QS_ii_CUSTDataBinding(DataTable x)      //datatable的欄位與Text綁定資料-CUST
        {
            #region 內容

            #endregion
        }

        private void QS_ii_USERIDDataBinding(DataTable x)     //datatable的欄位與Text綁定資料-USERID
        {
            QT_DATE_dTP.DataBindings.Add("Text", x, "EMP_ID", true);
        }

        public void DataTable_SETColumnExpression()            //設定DataTable的Column.Expression
        {
            #region 內容
            DataColumn AMOUNT = QSiiDB.QS_ii_QProduct.AMOUNTColumn;      //單價*數量
            AMOUNT.Expression = "QTY*UNIT_PRICE";
            DataColumn AMT_NOTAX = QSiiDB.QS_ii_QProduct.AMT_NOTAXColumn;      //SUM(單價*數量)
            AMT_NOTAX.Expression = "SUM(AMOUNT)";
            DataColumn TAX_AMT = QSiiDB.QS_ii_QProduct.TAX_AMTColumn;          //SUM(單價*數量)*0.05 =>稅額
            TAX_AMT.Expression = "SUM(AMOUNT)*0.05";
            DataColumn TOT_AMT = QSiiDB.QS_ii_QProduct.TOT_AMTColumn;        //SUM(單價*數量)*1.05 =>稅後總額
            TOT_AMT.Expression = "AMT_NOTAX + TAX_AMT";
            #endregion
        }

        private void Quotes_import_Head()           //報價單主檔表頭與TextBox對應
        {
            #region 內容
            //tb_QT_NO.Text = QSiiDB.Tables["QS_ii_HQT01"].Rows[0]["QT_NO"].ToString();                   //報價單編號
            tb_CUST_NO.Text = QSiiDB.Tables["QS_ii_HQT01"].Rows[0]["CUST_NO"].ToString();          //客戶編號
            //tb_CUST_NO.Text = QSiiDB.Tables["QS_ii_HQCustomer"].Rows[0]["CUST_NO"].ToString();          //客戶編號            
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
            tb_AMT_NOTAX.Text = QSiiDB.Tables["QS_ii_HQT01"].Rows[0]["AMT_NOTAX"].ToString();           //總金額(未稅)
            tb_TAX_AMT.Text = QSiiDB.Tables["QS_ii_HQT01"].Rows[0]["TAX_AMT"].ToString();               //稅額
            tb_TOT_AMT.Text = QSiiDB.Tables["QS_ii_HQT01"].Rows[0]["TOT_AMT"].ToString();               //總金額(含稅)
            //tb_REMARK.Text = QSiiDB.Tables["QS_ii_HQT01"].Rows[0]["REMARK"].ToString();                 //備註
            #endregion
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

        #region button
        //==============================================================================================================

        private void QS_ii_新增button_Click(object sender, EventArgs e)
        {
            start_status(QS_ii_新增button);
        }

        private void QS_ii_修改button_Click(object sender, EventArgs e)
        {
            if (tb_QT_NO.Text.Trim().Length != 0)
            {
                start_status(QS_ii_修改button);
            }
            else
            {
                MessageBox.Show("沒有載入報價單編號!!",this.Text);
            }
            
        }

        private void QS_ii_客戶button_Click(object sender, EventArgs e)
        {
            QS_ii_客戶_Open();        //客戶主檔開窗
        }

        private void QS_ii_產品button_Click(object sender, EventArgs e)
        {
            QS_ii_產品_Open();        //商品主檔開窗            
        }

        private void QS_ii_通路button_Click(object sender, EventArgs e)
        {
            QS_ii_通路_Open();       //通路主檔開窗
        }

        private void QS_ii_刪除button_Click(object sender, EventArgs e)
        {
            start_status(QS_ii_刪除button);
            Quotes_Delete();        //報價單刪除
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
            Quotes_Detail_Modify(Product_新增button);            
            #endregion
        }

        private void Product_刪除button_Click(object sender, EventArgs e)
        {
            #region 內容
            
            //***************DataTable刪除選取的資料*****************
            for (int i = QS_ii_Product_DGV.Rows.Count-1; i >=0; i--)
            {
                if (QS_ii_Product_DGV.Rows[i].Cells[0].Value.ToString() == "1")
                {
                    this.QS_ii_Product_DGV.Rows.Remove(this.QS_ii_Product_DGV.Rows[i]);                                    
                    i = QS_ii_Product_DGV.Rows.Count;
                }
            }
            #endregion
        }

        private void Product_多選button_Click(object sender, EventArgs e)
        {
            #region  內容
            Quotes_Detail_Modify(Product_多選button);            
            #endregion            
        }

        private void QS_ii_歷史查詢button_Click(object sender, EventArgs e)
        {
            start_status(QS_ii_歷史查詢button);
            Quotes_HQuery();        //歷史記錄查詢

        }

        private void QS_ii_Query_CUST_NO_Click(object sender, EventArgs e)          //客戶編號快速查詢
        {
            Query_CUST_NO();        //客戶編號快速查詢
        }

        private void QS_ii_Query_CUST_NAME_Click(object sender, EventArgs e)        //客戶名稱快速查詢
        {
            Query_CUST_NAME();      //客戶名稱快速查詢
        }

        private void QS_ii_Query_VAT_NO_Click(object sender, EventArgs e)           //客戶統一編號快速查詢
        {
            Query_VAT_NO();         //客戶統一編號快速查詢
        }

        private void QS_ii_HQuery_CUST_NO_Click(object sender, EventArgs e)         //歷史查詢-客戶編號查詢
        {
            //Query_CUST("客戶編號");        //客戶查詢
            HQuery_CUST_NO("客戶編號");        //歷史記錄查詢-客戶編號查詢
        }

        private void QS_ii_HQuery_item_NO_Click(object sender, EventArgs e)         //歷史查詢-商品編號查詢
        {
            HQuery_Item_NO("商品編號");       //歷史記錄查詢-商品編號查詢
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
                Query_CUST_NO();        //客戶編號快速查詢
                //QS_ii_客戶_Open();
            }            
        }

        private void QS_ii_HQuery_DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)       //QS_ii_HQuery_DGV雙擊二下
        {
            if (e.RowIndex >= 0 )
            {
                if (Status_info.Text == "瀏覽")
                {
                    QT_NO = QS_ii_HQuery_DGV.CurrentRow.Cells[0].Value.ToString();
                    CUST_NO = QS_ii_HQuery_DGV.CurrentRow.Cells[1].Value.ToString();
                    DataTable_SETColumnExpression();            //設定DataTable的Column.Expression
                    Quotes_HQueryDoubleClick();
                }
                else
                {
                    MessageBox.Show("你目前的狀態:《" + Status_info.Text+"》\n所以無法載入歷史報價記錄!!",this.Text);
                }
                
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
            //QS_iiQ_add.tb_PROD_TYPE.Text = tb_CUST_TYPE.Text;       //客戶類別
            QS_iiQ_add.tb_PROD_TYPE.Text = CUST_TYPE;       //客戶類別
            QS_iiQ_add.tb_CUST_NO.Text = CUST_NO;           //客戶編號
            QS_iiQ_add.tb_CUST_NAME.Text = CUST_NAME;       //客戶名稱
            QS_iiQ_add.tb_VAT_NO.Text = VAT_NO;             //統一編號
            QS_iiQ_add.tb_CHAIN_NO.Text = CHAIN_NO;       //通路名稱
            QS_iiQ_add.tb_CONT_TITLE.Text = CONT_TITLE;     //連絡人職稱
            QS_iiQ_add.tb_CONTACT.Text = CONTACT;           //連絡人
            QS_iiQ_add.tb_CONT_TEL.Text = CONT_TEL;         //連絡人電話
            QS_iiQ_add.tb_FAX.Text = FAX;                   //傳真
            QS_iiQ_add.tb_CUST_MAIL.Text = CUST_MAIL;       //客戶MAIL
            QS_iiQ_add.tb_CUST_ADDR.Text = CUST_ADDR;       //公司地址
            QS_iiQ_add.tb_DELI_ADDR_NO.Text = DELI_ADDR_NO;       //郵地區號
            QS_iiQ_add.tb_DELI_ADDR.Text = DELI_ADDR;             //送貨地址
            QS_iiQ_add.tb_PAY_METH.Text = PAY_METH;               //付款方式
            QS_iiQ_add.tb_HQuery_CUST_NO.Text = CUST_NO;           //客戶編號
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
            try 
            {
                QS_iiQ_add.QS_ii_PriceDataBinding(QS_iiQ_add.QSiiDB.QS_ii_QProduct);           //datatable的欄位與Text綁定資料
                QS_iiQ_add.DataTable_SETColumnExpression();                 //設定DataTable的Column.Expression
                DataView QS_ii_QDView = new DataView(QS_iiQ_add.QSiiDB.QS_ii_QProduct);
                QS_ii_QDView.RowFilter = "item_NO = '" + tb_item_NO.Text + "'";
                if (QS_ii_QDView.Count == 0)
                {
                    DataRow QS_ii_dr = QS_iiQ_add.QSiiDB.QS_ii_QProduct.NewRow();
                    QS_ii_dr["Check"] = "0";
                    QS_ii_dr["QT_NO"] = QS_iiQ_add.tb_QT_NO.Text;
                    QS_ii_dr["item_NO"] = tb_item_NO.Text;
                    QS_ii_dr["item_NAME"] = tb_item_NAME.Text;
                    QS_ii_dr["SPEC"] = tb_SPEC.Text;
                    QS_ii_dr["UNIT"] = tb_UNIT.Text;
                    QS_ii_dr["QTY"] = 1;
                    QS_ii_dr["UNIT_PRICE"] = Convert.ToSingle(tb_UNIT_PRICE.Text.Trim());
                    QS_iiQ_add.QSiiDB.QS_ii_QProduct.Rows.Add(QS_ii_dr);
                }
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);

            }
            
            #endregion
        }
        
    }

    public class QS_ii_TQueryDGV : QS_ii_QueryDGV       //報價單新增商品-查詢
    {
        QS_ii_Quotes_add QS_iiQ_add;

        public QS_ii_TQueryDGV(QS_ii_Quotes_add x)
        {
            this.QS_iiQ_add = x;
        }

        public override void QS_ii_QueryDGV_DGView1()         //把選取資料對應到TextBox
        {
            #region 內容
            try
            {
                QS_iiQ_add.QS_ii_PriceDataBinding(QS_iiQ_add.QSiiDB.QS_ii_QProduct);           //datatable的欄位與Text綁定資料
                QS_iiQ_add.DataTable_SETColumnExpression();                 //設定DataTable的Column.Expression
                DataView QS_ii_QDView = new DataView(QS_iiQ_add.QSiiDB.QS_ii_QProduct);
                QS_ii_QDView.RowFilter = "item_NO = '" + QS_ii_DGView1.CurrentRow.Cells["商品編號"].Value.ToString() +"'";
                if (QS_ii_QDView.Count == 0)
                {
                    DataRow QS_ii_dr = QS_iiQ_add.QSiiDB.QS_ii_QProduct.NewRow();
                    QS_ii_dr["Check"] = "0";
                    QS_ii_dr["QT_NO"] = QS_iiQ_add.tb_QT_NO.Text;
                    QS_ii_dr["item_NO"] = QS_ii_DGView1.CurrentRow.Cells["商品編號"].Value.ToString();
                    QS_ii_dr["item_NAME"] = QS_ii_DGView1.CurrentRow.Cells["商品名稱"].Value.ToString();
                    QS_ii_dr["SPEC"] = QS_ii_DGView1.CurrentRow.Cells["規格"].Value.ToString();
                    QS_ii_dr["UNIT"] = QS_ii_DGView1.CurrentRow.Cells["單位"].Value.ToString();
                    QS_ii_dr["QTY"] = 1;
                    QS_ii_dr["UNIT_PRICE"] = Convert.ToSingle(QS_ii_DGView1.CurrentRow.Cells["單價"].Value.ToString());
                    QS_iiQ_add.QSiiDB.QS_ii_QProduct.Rows.Add(QS_ii_dr);
                }
                
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
            QS_ii_QueryDGV_Column1.DataPropertyName = "Check";
            QS_iiQ_add.Product_Query(QS_ii_QueryDGv_PID, QS_iiQ_add.QSiiDB.QS_ii_Product, QS_ii_DGView1);        //商品主檔查詢            
        }       
        
        public override void QS_ii_QueryDGV_加入button()      //報價單明細檔多選的加入button//
        {
            #region 內容
            QS_iiQ_add.QS_ii_PriceDataBinding(QS_iiQ_add.QSiiDB.QS_ii_QProduct);           //datatable的欄位與Text綁定資料
            QS_iiQ_add.DataTable_SETColumnExpression();                 //設定DataTable的Column.Expression
            DataView QS_ii_DView = new DataView(QS_iiQ_add.QSiiDB.QS_ii_Product);
            DataView QS_ii_QDView = new DataView(QS_iiQ_add.QSiiDB.QS_ii_QProduct);
            QS_ii_DView.RowFilter = "Check = '1'";
            
            foreach (DataRowView DView in QS_ii_DView)
            {
                QS_ii_QDView.RowFilter = "item_NO = '" + DView["商品編號"].ToString() + "'";
                if (QS_ii_QDView.Count == 0)
                {
                    DataRow QS_ii_dr = QS_iiQ_add.QSiiDB.QS_ii_QProduct.NewRow();
                    QS_ii_dr["Check"] = "0";
                    QS_ii_dr["QT_NO"] = QS_iiQ_add.tb_QT_NO.Text;
                    QS_ii_dr["item_NO"] = DView["商品編號"];
                    QS_ii_dr["item_NAME"] = DView["商品名稱"];
                    QS_ii_dr["SPEC"] = DView["規格"];
                    QS_ii_dr["UNIT"] = DView["單位"];
                    QS_ii_dr["QTY"] = 1;
                    QS_ii_dr["UNIT_PRICE"] = DView["單價"];
                    QS_iiQ_add.QSiiDB.QS_ii_QProduct.Rows.Add(QS_ii_dr);

                }
                //DataRowView QS_ii_dr = QS_ii_QDView.AddNew();
                //QS_ii_dr["Check"] = "0";
                //QS_ii_dr["QT_NO"] = QS_iiQ_add.tb_QT_NO.Text;
                //QS_ii_dr["item_NO"] = DView["商品編號"];
                //QS_ii_dr["item_NAME"] = DView["商品名稱"];
                //QS_ii_dr["SPEC"] = DView["規格"];
                //QS_ii_dr["UNIT"] = DView["單位"];
                //QS_ii_dr["QTY"] = 1;
                //QS_ii_dr["UNIT_PRICE"] = DView["單價"];
                //QS_ii_dr.EndEdit();
            }
            #endregion
        }
    }

    public class QS_ii_TQuery_CUST : QS_ii_QueryDGV     //報價單-客戶查詢 
    {
        QS_ii_Quotes_add QS_iiQ_add;

        public QS_ii_TQuery_CUST(QS_ii_Quotes_add x)
        {
            this.QS_iiQ_add = x;
        }

        public override void QS_ii_QueryDGV_DGView1()       //把選取資料對應到TextBox
        {
            #region 內容
            #region 加到DataTable=>QS_ii_QCustomer
            QS_iiQ_add.QSiiDB.QS_ii_QCustomer.Clear();
            DataRow QS_ii_dr = QS_iiQ_add.QSiiDB.QS_ii_QCustomer.NewRow();
            QS_ii_dr["CUST_NO"] = QS_ii_DGView1.CurrentRow.Cells["客戶編號"].Value.ToString();
            QS_ii_dr["CUST_NAME"] = QS_ii_DGView1.CurrentRow.Cells["客戶名稱"].Value.ToString();
            QS_ii_dr["CUST_TYPE"] = QS_ii_DGView1.CurrentRow.Cells["客戶類別"].Value.ToString();
            QS_ii_dr["CONTACT"] = QS_ii_DGView1.CurrentRow.Cells["聯絡人"].Value.ToString();
            QS_ii_dr["CONT_TITLE"] = QS_ii_DGView1.CurrentRow.Cells["聯絡人職稱"].Value.ToString();
            QS_ii_dr["CONT_TEL"] = QS_ii_DGView1.CurrentRow.Cells["聯絡人電話"].Value.ToString();
            QS_ii_dr["FAX"] = QS_ii_DGView1.CurrentRow.Cells["傳真"].Value.ToString();
            QS_ii_dr["VAT_NO"] = QS_ii_DGView1.CurrentRow.Cells["統一編號"].Value.ToString();
            QS_ii_dr["CUST_ADDR"] = QS_ii_DGView1.CurrentRow.Cells["客戶地址"].Value.ToString();
            QS_ii_dr["CUST_MAIL"] = QS_ii_DGView1.CurrentRow.Cells["客戶MAIL"].Value.ToString();
            QS_ii_dr["DELI_ADDR_NO"] = QS_ii_DGView1.CurrentRow.Cells["送貨郵地區號"].Value.ToString();
            QS_ii_dr["DELI_ADDR"] = QS_ii_DGView1.CurrentRow.Cells["送貨地址"].Value.ToString();
            QS_ii_dr["PAY_METH"] = QS_ii_DGView1.CurrentRow.Cells["付款方式"].Value.ToString();
            QS_ii_dr["CHAIN_NO"] = QS_ii_DGView1.CurrentRow.Cells["主要通路"].Value.ToString();
            QS_ii_dr["DEL_FALG"] = QS_ii_DGView1.CurrentRow.Cells["DEL_FALG"].Value.ToString();
            QS_iiQ_add.QSiiDB.QS_ii_QCustomer.Rows.Add(QS_ii_dr);
            #endregion
            #region 加到報價單表頭
            QS_iiQ_add.tb_HQuery_CUST_NO.Text = QS_ii_DGView1.CurrentRow.Cells["客戶編號"].Value.ToString();        //客戶編號
            QS_iiQ_add.tb_CUST_NO.Text = QS_ii_DGView1.CurrentRow.Cells["客戶編號"].Value.ToString();           //客戶編號
            QS_iiQ_add.tb_CUST_NAME.Text = QS_ii_DGView1.CurrentRow.Cells["客戶名稱"].Value.ToString();         //客戶名稱
            QS_iiQ_add.tb_PROD_TYPE.Text = QS_ii_DGView1.CurrentRow.Cells["客戶類別"].Value.ToString();         //客戶類別
            QS_iiQ_add.tb_CONTACT.Text = QS_ii_DGView1.CurrentRow.Cells["聯絡人"].Value.ToString();             //聯絡人
            QS_iiQ_add.tb_CONT_TITLE.Text = QS_ii_DGView1.CurrentRow.Cells["聯絡人職稱"].Value.ToString();      //聯絡人職稱
            QS_iiQ_add.tb_CONT_TEL.Text = QS_ii_DGView1.CurrentRow.Cells["聯絡人電話"].Value.ToString();        //聯絡人電話
            QS_iiQ_add.tb_FAX.Text = QS_ii_DGView1.CurrentRow.Cells["傳真"].Value.ToString();                   //傳真
            QS_iiQ_add.tb_VAT_NO.Text = QS_ii_DGView1.CurrentRow.Cells["統一編號"].Value.ToString();            //統一編號
            QS_iiQ_add.tb_CUST_ADDR.Text = QS_ii_DGView1.CurrentRow.Cells["客戶地址"].Value.ToString();         //客戶地址
            QS_iiQ_add.tb_CUST_MAIL.Text = QS_ii_DGView1.CurrentRow.Cells["客戶MAIL"].Value.ToString();         //客戶MAIL
            QS_iiQ_add.tb_DELI_ADDR_NO.Text = QS_ii_DGView1.CurrentRow.Cells["送貨郵地區號"].Value.ToString();  //送貨郵地區號
            QS_iiQ_add.tb_DELI_ADDR.Text = QS_ii_DGView1.CurrentRow.Cells["送貨地址"].Value.ToString();         //送貨地址
            QS_iiQ_add.tb_PAY_METH.Text = QS_ii_DGView1.CurrentRow.Cells["付款方式"].Value.ToString();          //付款方式            
            QS_iiQ_add.tb_CHAIN_NO.Text = QS_ii_DGView1.CurrentRow.Cells["主要通路"].Value.ToString();          //通路名稱
            #endregion
            #endregion
        }

        public override void QS_ii_QueryDGV_QueryButton()       //查詢Button
        {
            #region 內容
            //QS_ii_QueryDGV_Column1.Visible = false;
            //QS_ii_QueryDGV_Column1.DataPropertyName = "Check";
            if (NOID_Value == "客戶編號:")
            {
                
                QS_iiQ_add.CUST_Query("客戶編號", QS_ii_QueryDGv_PID, QS_iiQ_add.QSiiDB.QS_ii_Customer, QS_ii_DGView1);          //依客戶編號-查詢客戶主檔
            }
            else if (NOID_Value == "客戶名稱:")
            {
                QS_iiQ_add.CUST_Query("客戶名稱", QS_ii_QueryDGv_PID, QS_iiQ_add.QSiiDB.QS_ii_Customer, QS_ii_DGView1);          //依客戶名稱-查詢客戶主檔
            }
            else if (NOID_Value == "統一編號:")
            {
                QS_iiQ_add.CUST_Query("統一編號", QS_ii_QueryDGv_PID, QS_iiQ_add.QSiiDB.QS_ii_Customer, QS_ii_DGView1);          //依統一編號-查詢客戶主檔
            }
            #endregion

        }       
    }

    public class QS_ii_THQuery : QS_ii_QueryDGV         //歷史記錄查詢
    {
        QS_ii_Quotes_add QS_iiQ_add;

        public QS_ii_THQuery(QS_ii_Quotes_add x)        
        {
            this.QS_iiQ_add = x;
        }

        public override void QS_ii_QueryDGV_DGView1()       //把選取資料對應到TextBox
        {
            #region 內容
            if (NOID_Value == "客戶編號:")
            {
                QS_iiQ_add.tb_HQuery_CUST_NO.Text = QS_ii_DGView1.CurrentRow.Cells["客戶編號"].Value.ToString();        //客戶編號
            }
            else if (NOID_Value == "商品編號:")
            {
                QS_iiQ_add.tb_HQuery_item_NO.Text = QS_ii_DGView1.CurrentRow.Cells["商品編號"].Value.ToString();        //商品編號
            }
            #endregion
        }

        public override void QS_ii_QueryDGV_QueryButton()       //查詢Button
        {
            #region 內容
            //QS_ii_QueryDGV_Column1.Visible = false;
            //QS_ii_QueryDGV_Column1.DataPropertyName = "Check";            
            if (NOID_Value == "客戶編號:")
            {
                QS_iiQ_add.CUST_Query("客戶編號", QS_ii_QueryDGv_PID, QS_iiQ_add.QSiiDB.QS_ii_Customer, QS_ii_DGView1);          //依客戶編號-查詢客戶主檔
            }
            else if (NOID_Value == "商品編號:")
            {
                QS_iiQ_add.Product_Query(QS_ii_QueryDGv_PID, QS_iiQ_add.QSiiDB.QS_ii_Product, QS_ii_DGView1);        //依商品編號-查詢商品主檔
            }
            
            #endregion
        }

    }
}
