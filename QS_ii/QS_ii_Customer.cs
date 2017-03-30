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
    public partial class QS_ii_Customer : Form
    {
        QS_ii_function fun = new QS_ii_function();

        public QS_ii_Customer()
        {
            InitializeComponent();
        }
        private string QueryDB
        {
            set;
            get;
        }

        public void GetSQL(string x)        //DB語法
        {
            if (x == "新增")
            {
                #region 內容
                QueryDB = @"EXEC [TEST_SLSYHI].[dbo].[SLS_QS_CUST_Insert] '" + tb_CUST_NAME.Text.Trim() +       //客戶名稱
                         @"','" + tb_CUST_TYPE.Text.Trim() +           //客戶分類/類別
                         @"','" + tb_CONTACT.Text.Trim() +         //連絡人
                         @"','" + tb_CONT_TITLE.Text.Trim() +         //連絡人職稱
                         @"','" + tb_CONT_TEL.Text.Trim() +         //連絡人電話
                         @"','" + tb_FAX.Text.Trim() +        //傳真
                         @"','" + tb_VAT_NO.Text.Trim() +          //統一編號
                         @"','" + tb_CUST_ADDR.Text.Trim() +          //客戶地址
                         @"','" + tb_CUST_MAIL.Text.Trim() +          //客戶MAIL
                         @"','" + tb_DELI_ADDR_NO.Text.Trim() +          //送貨郵地區號
                         @"','" + tb_DELI_ADDR.Text.Trim() +           //送貨地址
                         @"','" + tb_PAY_METH.Text.Trim() +          //付款方式 
                         @"','" + tb_CHAIN_NAME.Text.Trim() +          //主要通路                                                 
                         @"','" + USER_ID.Text + "'";                //使用者ID
                #endregion
            }
            else if(x == "修改")
            {
                #region 內容
                QueryDB = @"EXEC [TEST_SLSYHI].[dbo].[SLS_QS_CUST_Update] '" + tb_CUST_NO.Text +       //客戶編號 
                         @"','" + tb_CUST_NAME.Text.Trim() +           //客戶名稱
                         @"','" + tb_CUST_TYPE.Text.Trim() +           //客戶分類/類別
                         @"','" + tb_CONTACT.Text.Trim() +         //連絡人
                         @"','" + tb_CONT_TITLE.Text.Trim() +         //連絡人職稱
                         @"','" + tb_CONT_TEL.Text.Trim() +         //連絡人電話
                         @"','" + tb_FAX.Text.Trim() +        //傳真
                         @"','" + tb_VAT_NO.Text.Trim() +          //統一編號
                         @"','" + tb_CUST_ADDR.Text.Trim() +          //客戶地址
                         @"','" + tb_CUST_MAIL.Text.Trim() +          //客戶MAIL
                         @"','" + tb_DELI_ADDR_NO.Text.Trim() +          //送貨郵地區號
                         @"','" + tb_DELI_ADDR.Text.Trim() +           //送貨地址
                         @"','" + tb_PAY_METH.Text.Trim() +          //付款方式 
                         @"','" + tb_CHAIN_NAME.Text.Trim() +          //主要通路                                                 
                         @"','" + USER_ID.Text + "'";                //使用者ID
                #endregion
            }
            else if (x == "查詢")
            {
                #region 內容

                #endregion
            }
        }

        public void default_status()
        {
            this.Text = "客戶主檔";
            //this.MaximizeBox = true;       //最大化
            //this.MinimizeBox = true;       //最小化
            this.FormBorderStyle = FormBorderStyle.FixedSingle;     //限制使用者改變form大小
            this.AutoSize = false;          //自動調整大小
            //this.Size = new System.Drawing.Size(1249, 882);      //設定Form大小            
            fun.EoD_Panel_txt(QS_ii_Customer_panel3, true);     //QS_ii_Head_panel內的TextBox設定唯讀
            fun.EoD_Panel_btnVisible(QS_ii_Customer_panel1, true);      //QS_ii_Customer_panel1內的button設定顯示
            QS_ii_Customer_儲存Button.Visible = false;
            QS_ii_Customer_取消Button.Visible = false;
            Customer_Status_info.Visible = false;

        }

        public void start_status(Button x)      //啟動狀態
        {
            if (x == QS_ii_Customer_新增Button)
            {
                Customer_Status_info.Visible = true;
                Customer_Status_info.Text = "新增";
                tb_CUST_NO.ReadOnly = true;
                fun.clearAir(QS_ii_Customer_panel2);
                fun.clearAir(QS_ii_Customer_panel3);
                fun.EoD_Panel_txt(QS_ii_Customer_panel3, false);     //QS_ii_Head_panel內的TextBox設定可讀寫
                fun.EoD_Panel_btn(QS_ii_Customer_panel1, false);      //QS_ii_Customer_panel1內的button設定關
                QS_ii_Customer_儲存Button.Visible = true;
                QS_ii_Customer_取消Button.Visible = true;
                QS_ii_Customer_儲存Button.Enabled = true;
                QS_ii_Customer_取消Button.Enabled = true;               
            }
            else if (x == QS_ii_Customer_修改Button)
            {
                Customer_Status_info.Visible = true;
                Customer_Status_info.Text = "新增";
                tb_CUST_NO.ReadOnly = true;
                fun.EoD_Panel_txt(QS_ii_Customer_panel3, false);     //QS_ii_Head_panel內的TextBox設定唯讀
                fun.EoD_Panel_btn(QS_ii_Customer_panel1, false);      //QS_ii_Customer_panel1內的button設定關
                QS_ii_Customer_儲存Button.Visible = true;
                QS_ii_Customer_取消Button.Visible = true;
                QS_ii_Customer_儲存Button.Enabled = true;
                QS_ii_Customer_取消Button.Enabled = true;
            }
            else if (x == QS_ii_Customer_刪除Button)
            {                

            }
            else if (x == QS_ii_Customer_查詢Button)
            {

            }
            else if (x == QS_ii_Customer_儲存Button)
            {
                Customer_Status_info.Text = "";
                Customer_Status_info.Visible = false;
                fun.clearAir(QS_ii_Customer_panel2);
                fun.clearAir(QS_ii_Customer_panel3);
                fun.EoD_Panel_txt(QS_ii_Customer_panel3, true);
                QS_ii_Customer_儲存Button.Visible = false;
                QS_ii_Customer_取消Button.Visible = false;

            }
            else if (x == QS_ii_Customer_取消Button)
            {
                Customer_Status_info.Text = "";
                Customer_Status_info.Visible = false;
                tb_CUST_NO.ReadOnly = false;
                fun.EoD_Panel_txt(QS_ii_Customer_panel3, true);     //QS_ii_Head_panel內的TextBox設定唯讀
                fun.EoD_Panel_btn(QS_ii_Customer_panel1, true);      //QS_ii_Customer_panel1內的button設定開
                QS_ii_Customer_儲存Button.Visible = false;
                QS_ii_Customer_取消Button.Visible = false;
            }

        }

        private void Customer_Add()           //客戶主檔新增
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
                    start_status(QS_ii_Customer_儲存Button);
                }
            }
            #endregion
        }

        private void Customer_Modify()        //客戶主檔修改
        {
            #region 內容
            if (MessageBox.Show("確定要修改？", "警告!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                fun.Check_error = false;
                GetSQL("修改");
                fun.QS_ii_insert(QueryDB);
                if (fun.Check_error == false)
                {
                    MessageBox.Show("資料《修改》成功!!", this.Text);
                    start_status(QS_ii_Customer_儲存Button);
                }

            }


            #endregion

        }

        private void Customer_delete()        //客戶主檔刪除
        {

        }

        private void Customer_Query()         //客戶主檔查詢
        {

        }


        private void QS_ii_Customer_Load(object sender, EventArgs e)
        {
            default_status();
        }        

        private void QS_ii_Customer_新增Button_Click(object sender, EventArgs e)
        {
            start_status(QS_ii_Customer_新增Button);
        }

        private void QS_ii_Customer_修改Button_Click(object sender, EventArgs e)
        {
            start_status(QS_ii_Customer_修改Button);

        }

        private void QS_ii_Customer_刪除Button_Click(object sender, EventArgs e)
        {
            start_status(QS_ii_Customer_刪除Button);
        }

        private void QS_ii_Customer_查詢Button_Click(object sender, EventArgs e)
        {
            start_status(QS_ii_Customer_查詢Button);
        }

        private void QS_ii_Customer_儲存Button_Click(object sender, EventArgs e)
        {
            if (Customer_Status_info.Text == "新增")
            {
                Customer_Add();         //客戶主檔新增
            }
            else if (Customer_Status_info.Text == "修改")
            {
                Customer_Modify();        //客戶主檔修改

            }
            
        }

        private void QS_ii_Customer_取消Button_Click(object sender, EventArgs e)
        {
            start_status(QS_ii_Customer_取消Button);
        }

        
    }
}
