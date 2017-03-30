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
        QS_ii_function fun = new QS_ii_function();

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

        private string ALLOW_QT     //是不核准報價
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
                ALLOW_QT = "Y";                
            }
            if (ALLOW_QT_NO.Checked)
            {
                ALLOW_QT = "N";
            }
        }

        public void GetSQL(string x)
        {
            if(x == "新增")
            {
                ALL_RB();
                QueryDB = @"EXEC [TEST_SLSYHI].[dbo].[SLS_QS_Insert] '" + QT_DATE_dTP.Text +       //--報價日期
                         @"','" + tb_CUST_NO.Text.Trim() +           //--客戶編號
                         @"','" + tb_CHAIN_NO.Text.Trim() +         //通路編號
                         @"','" + tb_EFF_DATE.Text.Trim() +         //報價有效日期(期限)
                         @"','" + tb_SALESMAN.Text.Trim() +         //報價人(業務員)
                         @"','" + tb_AMT_NOTAX.Text.Trim() +        //總金額 (未稅)
                         @"','" + tb_TAX_AMT.Text.Trim() +          //稅額
                         @"','" + tb_TOT_AMT.Text.Trim() +          //含稅金額
                         @"','" + tb_CURRENCY.Text.Trim() +          //幣別
                         @"','" + tb_TAX_AMT.Text.Trim() +          //匯率
                         @"','" + ALLOW_QT +                        //是否核准報價
                         @"','" + tb_BPM_NO.Text.Trim() +           //簽核單號
                         @"','" + tb_DELI_MODE.Text.Trim() +          //交貨方式 
                         @"','" + tb_RECEIVE.Text.Trim() +          //收貨人                                                 
                         @"','" + tb_APPROVE.Text.Trim() +          //核准人員
                         @"','" + tb_APPR_DATE.Text.Trim() +          //核准日期
                         @"','" + tb_REMARK.Text.Trim() +          //備註
                         @"','" + USER_ID.Text + "'";                //使用者ID 
            }
        }
        
        public void default_status()
        {
            this.Text = "報價系統";
            //this.MaximizeBox = true;       //最大化
            //this.MinimizeBox = true;       //最小化
            this.FormBorderStyle = FormBorderStyle.FixedSingle;     //限制使用者改變form大小
            this.AutoSize = false;          //自動調整大小
            //this.Size = new System.Drawing.Size(1249, 882);      //設定Form大小
            fun.Format_Panel_dTP(QS_ii_Head_panel, "yyyy-MM-dd");     //自訂日期格式
            fun.EoD_Panel_txt(QS_ii_Head_panel, true);     //QS_ii_Head_panel內的TextBox設定唯讀
            fun.EoD_Panel_DateTimePicker(QS_ii_Head_panel, false);       //QS_ii_Head_panel內的DateTimePicker設定唯讀
            Status_info.Visible = false;

        }

        public void start_status(Button x)      //啟動狀態
        {
            if (x == QS_ii_新增button)
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
                fun.QS_ii_insert(QueryDB);
                if (fun.Check_error == false)
                {
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

        private void Quotes_Query()         //報價單查詢
        {
            #region 內容

            #endregion
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
            Status_info.Text = "新增";
        }

        private void QS_ii_儲存button_Click(object sender, EventArgs e)
        {
            if (Status_info.Text == "新增")
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
            else if (Status_info.Text == "修改")
            {
                #region 內容
                //if (tb_DMS_DOC_NO.Text != "")
                //{
                //    if (MessageBox.Show("確定要修改？", "警告!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //    {
                //        fun.Check_error = false;
                //        GetSQL("修改", null);
                //        fun.DMS_modify(Query_DB);
                //        sample_items_other_text(tb_DMS_DOC_NO.Text.Trim());     //把其他檢驗項目的Text存到DB中
                //        //db_sum = SQL語法            
                //        //mBox = 成功執行後的訊息
                //        //FText = MessageBox.form.Text
                //        if (fun.Check_error == false)
                //        {
                //            MessageBox.Show("資料《修改》成功!!", "DMS");
                //        }
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("沒有文件編號!!不能修改", "DMS");
                //}

                #endregion
            }
            
        }

        private void QS_ii_客戶button_Click(object sender, EventArgs e)
        {

            QS_ii_Customer inSea = new QS_ii_Customer();
            //設定init_Staff 新視窗的相對位置#############
            inSea.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //############################################
            inSea.Server_ENV.Text = QS_ii_Server_ENV.Text;
            inSea.USER_ID.Text = USER_ID.Text;
            inSea.ShowDialog();
        }

        private void QS_ii_產品button_Click(object sender, EventArgs e)
        {
            QS_ii_Product inSea = new QS_ii_Product();
            //設定init_Staff 新視窗的相對位置#############
            inSea.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //############################################
            inSea.ShowDialog();
        }

        //==============================================================================================================
        #endregion

        #region 事件
        //==============================================================================================================

        //==============================================================================================================
        #endregion

        
        
        

    }
}
