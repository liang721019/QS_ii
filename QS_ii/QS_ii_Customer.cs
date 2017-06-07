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
        internal QS_ii_function fun = new QS_ii_function();        

        public QS_ii_Customer()
        {
            InitializeComponent();
            
        }

        #region 變數
        //=====================================================================        
        public string QueryDB
        {
            set;
            get;
        }       //SQL語法

        public string CUST_NO       //客戶編號
        {
            set
            {
                tb_CUST_NO.Text = value;
            }
            get
            {
                return tb_CUST_NO.Text;
            }
        }

        public string CUST_NAME     //客戶名稱
        {
            set
            {
                tb_CUST_NAME.Text = value;
            }
            get
            {
                return tb_CUST_NAME.Text;
            }
        }

        public string VAT_NO        //統一編號
        {
            set
            {
                tb_VAT_NO.Text = value;
            }
            get
            {
                return tb_VAT_NO.Text;
            }
        }

        public string CUST_TYPE         //客戶類別
        {
            set
            {
                tb_CUST_TYPE.Text = value;
            }
            get
            {
                return tb_CUST_TYPE.Text;
            }
        }

        public string CHAIN_NO        //主要通路
        {
            set
            {
                tb_CHAIN_NAME.Text = value;
            }
            get
            {
                return tb_CHAIN_NAME.Text;
            }
        }

        public string CONT_TITLE        //聯絡人職稱
        {
            set
            {
                tb_CONT_TITLE.Text = value;
            }
            get
            {
                return tb_CONT_TITLE.Text;
            }
        }

        public string CONTACT           //聯絡人
        {
            set
            {
                tb_CONTACT.Text = value;
            }
            get
            {
                return tb_CONTACT.Text;
            }
        }

        public string CONT_TEL          //聯絡人電話
        {
            set
            {
                tb_CONT_TEL.Text = value;
            }
            get
            {
                return tb_CONT_TEL.Text;
            }
        }

        public string FAX               //傳真
        {
            set
            {
                tb_FAX.Text = value;
            }
            get
            {
                return tb_FAX.Text;
            }
        }

        public string PAY_METH          //付款方式
        {
            set
            {
                tb_PAY_METH.Text = value;
            }
            get
            {
                return tb_PAY_METH.Text;
            }
        }

        public string CUST_MAIL         //客戶MAIL
        {
            set
            {
                tb_CUST_MAIL.Text = value;
            }
            get
            {
                return tb_CUST_MAIL.Text;
            }
        }

        public string CUST_ADDR         //客戶地址
        {
            set
            {
                tb_CUST_ADDR.Text = value;
            }
            get
            {
                return tb_CUST_ADDR.Text;
            }
        }

        public string DELI_ADDR_NO          //送貨郵地區號
        {
            set
            {
                tb_DELI_ADDR_NO.Text = value;
            }
            get
            {
                return tb_DELI_ADDR_NO.Text;
            }
        }

        public string DELI_ADDR             //送貨地址
        {
            set
            {
                tb_DELI_ADDR.Text = value;
            }
            get
            {
                return tb_DELI_ADDR.Text;
            }
        }

        public bool 引入Button_ToF        //設定QS_ii_Customer_引入Button顯示or隱藏
        {
            set;
            get;
        }

        private string QueryOLOD        //查詢條件變數
        {
            set;
            get;
        }   
        //=====================================================================
        #endregion        

        #region 方法

        public void GetSQL(string x)        //DB語法
        {
            QueryDB = "";
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
                QueryDB = @"select * from [TEST_SLSYHI].[dbo].[SLS_QS_CUST_QueryTemp]() where [DEL_FALG] = 'N'";

                #endregion
            }
            else if (x == "通路查詢")
            {
                #region 內容
                QueryDB = @"select [Check] = '0' ,* from [TEST_SLSYHI].[dbo].[SLS_QS_CUST_QueryCHAIN](" + USER_ID + ")" ;
                #endregion
            }
        }

        private void default_status()       //預設
        {
            this.Text = "客戶主檔";
            Customer_Status_info.Text = "瀏覽";     //狀態文字
            //this.MaximizeBox = true;       //最大化
            //this.MinimizeBox = true;       //最小化
            this.FormBorderStyle = FormBorderStyle.FixedSingle;     //限制使用者改變form大小
            this.AutoSize = false;          //自動調整大小
            //this.Size = new System.Drawing.Size(1249, 882);      //設定Form大小            
            fun.EoD_Panel_txt(QS_ii_Customer_panel3, true);     //QS_ii_Head_panel內的TextBox設定唯讀
            fun.EoD_Panel_txt(QS_ii_Customer_panel2, true);      //QS_ii_Customer_panel2內的TextBox設定唯讀  
            fun.EoD_Panel_btnVisible(QS_ii_Customer_panel1, true);      //QS_ii_Customer_panel1內的button設定顯示
            QS_ii_Customer_引入Button.Visible = 引入Button_ToF;
            QS_ii_Customer_儲存Button.Visible = false;
            QS_ii_Customer_取消Button.Visible = false;
            Customer_Status_info.Visible = false;

        }             

        private void start_status(Button x)      //啟動狀態
        {
            if (x == QS_ii_Customer_新增Button)
            {
                Customer_Status_info.Visible = true;
                Customer_Status_info.Text = "新增";                
                fun.clearAir(QS_ii_Customer_panel2);
                fun.clearAir(QS_ii_Customer_panel3);
                fun.EoD_Panel_txt(QS_ii_Customer_panel2, false);     //QS_ii_Customer_panel2內的TextBox設定可讀寫  
                fun.EoD_Panel_txt(QS_ii_Customer_panel3, false);     //QS_ii_Customer_panel3內的TextBox設定可讀寫
                tb_CUST_NO.ReadOnly = true;
                QS_ii_Customer_新增Button.Enabled = false;
                QS_ii_Customer_修改Button.Enabled = false;
                QS_ii_Customer_刪除Button.Enabled = false;
                QS_ii_Customer_查詢Button.Enabled = false;
                QS_ii_Customer_引入Button.Enabled = false;

                QS_ii_Customer_儲存Button.Visible = true;
                QS_ii_Customer_取消Button.Visible = true;
                QS_ii_Customer_儲存Button.Enabled = true;
                QS_ii_Customer_取消Button.Enabled = true;               
            }
            else if (x == QS_ii_Customer_修改Button)
            {
                Customer_Status_info.Visible = true;
                Customer_Status_info.Text = "修改";                
                fun.EoD_Panel_txt(QS_ii_Customer_panel2, false);     //QS_ii_Customer_panel2內的TextBox設定可讀寫  
                fun.EoD_Panel_txt(QS_ii_Customer_panel3, false);     //QS_ii_Customer_panel3內的TextBox設定可讀寫
                tb_CUST_NO.ReadOnly = true;
                QS_ii_Customer_新增Button.Enabled = false;
                QS_ii_Customer_修改Button.Enabled = false;
                QS_ii_Customer_刪除Button.Enabled = false;
                QS_ii_Customer_查詢Button.Enabled = false;
                QS_ii_Customer_引入Button.Enabled = false;

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
                
                fun.clearAir(QS_ii_Customer_panel2);
                fun.clearAir(QS_ii_Customer_panel3);
                fun.EoD_Panel_txt(QS_ii_Customer_panel2, false);     //QS_ii_Customer_panel2內的TextBox設定可讀寫  
                tb_CUST_NO.Focus();

            }
            else if (x == QS_ii_Customer_儲存Button)
            {
                Customer_Status_info.Text = "瀏覽";
                Customer_Status_info.Visible = false;
                fun.clearAir(QS_ii_Customer_panel2);
                fun.clearAir(QS_ii_Customer_panel3);
                fun.EoD_Panel_txt(QS_ii_Customer_panel2, false);         //QS_ii_Customer_panel2內的TextBox設定可讀寫
                fun.EoD_Panel_txt(QS_ii_Customer_panel3, true);         //QS_ii_Customer_panel3內的TextBox設定唯讀                

                QS_ii_Customer_新增Button.Enabled = true;
                QS_ii_Customer_修改Button.Enabled = true;
                QS_ii_Customer_刪除Button.Enabled = true;
                QS_ii_Customer_查詢Button.Enabled = true;
                QS_ii_Customer_引入Button.Enabled = true;

                QS_ii_Customer_儲存Button.Visible = false;
                QS_ii_Customer_取消Button.Visible = false;

            }
            else if (x == QS_ii_Customer_取消Button)
            {
                Customer_Status_info.Text = "瀏覽";
                Customer_Status_info.Visible = false;                
                fun.EoD_Panel_txt(QS_ii_Customer_panel2, false);     //QS_ii_Customer_panel2內的TextBox設定可讀寫  
                fun.EoD_Panel_txt(QS_ii_Customer_panel3, true);     //QS_ii_Customer_panel3內的TextBox設定唯讀                
                QS_ii_Customer_新增Button.Enabled = true;
                QS_ii_Customer_修改Button.Enabled = true;
                QS_ii_Customer_刪除Button.Enabled = true;
                QS_ii_Customer_查詢Button.Enabled = true;
                QS_ii_Customer_引入Button.Enabled = true;

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
            if (tb_CUST_NO.Text != "")
            {
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
            }
            else
            {

            }
            


            #endregion

        }

        private void Customer_delete()        //客戶主檔刪除
        {

        }

        private void Customer_Query(DataGridView dgv)         //客戶主檔查詢
        {
            
            GetSQL("查詢");    //語法丟進QueryDB
            Customer_Query_conditions();      //查詢客戶主檔的條件
            fun.xxx_DB(QueryDB + QueryOLOD, dgv);         //連接DB-執行DB指令
        }       

        private void Customer_Query_conditions()      //查詢客戶主檔的條件
        {
            QueryOLOD = "";
            if (tb_CUST_NO.Text != "")       //客戶編號
            {
                QueryOLOD += @"and [客戶編號] = N'" + tb_CUST_NO.Text.Trim() + "'";
            }
            if (tb_CUST_NAME.Text != "")       //客戶名稱
            {
                QueryOLOD += @"and [客戶名稱] like N'%" + tb_CUST_NAME.Text.Trim() + "%'";
            }
            if (tb_VAT_NO.Text != "")       //統一編號
            {
                QueryOLOD += @"and [統一編號] = N'" + tb_VAT_NO.Text.Trim() + "'";
            }

        }

        public virtual void Customer_import_Head()         //引入到報價單主檔表頭
        {
            
        }

        public virtual void Customer_Query_Enter()            //按enter後的方法
        {
            #region  按enter之後執行
            QS_ii_Customer_T QSQDGV = new QS_ii_Customer_T(this);
            QSQDGV.NOID_Value = "客戶編號:";
            QSQDGV.加入button_Visible = false;
            //設定init_Staff 新視窗的相對位置#############
            QSQDGV.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //############################################
            Customer_Query(QSQDGV.QS_ii_DGView1);           //客戶主檔查詢
            QSQDGV.ShowDialog();
            #endregion           
        }

        private void QS_ii_Customer_Query_CHAIN()            //通路查詢
        {
            #region 內容
            QS_ii_Customer_TQuery_CHAIN CUSTQuery = new QS_ii_Customer_TQuery_CHAIN(this);
            //設定init_Staff 新視窗的相對位置#############
            CUSTQuery.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //############################################
            CUSTQuery.加入button_Visible = false;
            CUSTQuery.QS_ii_QueryDGV_Column1.Visible = false;
            CUSTQuery.QS_ii_QueryDGV_Column1.DataPropertyName = "Check";
            CUSTQuery.NOID_Value = "通路編號:";
            GetSQL("通路查詢");    //語法丟進QueryDB            
            fun.xxx_DB(QueryDB, CUSTQuery.QS_ii_DGView1);         //連接DB-執行DB指令
            CUSTQuery.ShowDialog();

            #endregion
        }

        #endregion

        #region 按鈕

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
            if (tb_CUST_NO.Text.Trim().Length != 0)
            {
                start_status(QS_ii_Customer_修改Button);
            }
            else
            {
                MessageBox.Show("沒有客戶編號!!", this.Text);
            }
            

        }

        private void QS_ii_Customer_刪除Button_Click(object sender, EventArgs e)
        {
            start_status(QS_ii_Customer_刪除Button);
            MessageBox.Show("目前沒有權限!!",this.Text);
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

        private void QS_ii_Customer_引入Button_Click(object sender, EventArgs e)
        {
            Customer_import_Head();         //引入到報價單主檔表頭
            this.Close();
        }

        private void QS_ii_Customer_清空Button_Click(object sender, EventArgs e)
        {
            fun.clearAir(QS_ii_Customer_panel2);
            fun.clearAir(QS_ii_Customer_panel3);
        }

        private void QS_ii_Customer_通路查詢_Click(object sender, EventArgs e)
        {
            QS_ii_Customer_Query_CHAIN();            //通路查詢
        }

        #endregion

        #region 事件
        //=====================================================================
        private void tb_CUST_NO_KeyDown(object sender, KeyEventArgs e)      //客戶編號按enter後的查詢事件
        {
            if (Customer_Status_info.Text == "瀏覽")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Customer_Query_Enter();
                }
            }
            
        }

        private void tb_CUST_NAME_KeyDown(object sender, KeyEventArgs e)        //客戶名稱按enter後的查詢事件
        {
            if (Customer_Status_info.Text == "瀏覽")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Customer_Query_Enter();
                }
            }

        }

        private void tb_VAT_NO_KeyDown(object sender, KeyEventArgs e)           //統一編號按enter後的查詢事件
        {
            if (Customer_Status_info.Text == "瀏覽")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Customer_Query_Enter();
                }
            }

        }

        
        //=====================================================================
        #endregion
        
    }

    public class QS_ii_Customer_T : QS_ii_QueryDGV
    {
        QS_ii_Customer QSii;

        public QS_ii_Customer_T(QS_ii_Customer x)
        {
            this.QSii = x;
        }

        public override void QS_ii_QueryDGV_DGView1()       //把選取資料對應到TextBox
        {
            QSii.CUST_NO = QS_ii_DGView1.CurrentRow.Cells["客戶編號"].Value.ToString();
            QSii.CUST_NAME = QS_ii_DGView1.CurrentRow.Cells["客戶名稱"].Value.ToString();            
            QSii.CUST_TYPE = QS_ii_DGView1.CurrentRow.Cells["客戶類別"].Value.ToString();
            QSii.CONTACT = QS_ii_DGView1.CurrentRow.Cells["聯絡人"].Value.ToString();
            QSii.CONT_TITLE = QS_ii_DGView1.CurrentRow.Cells["聯絡人職稱"].Value.ToString();            
            QSii.CONT_TEL = QS_ii_DGView1.CurrentRow.Cells["聯絡人電話"].Value.ToString();
            QSii.FAX = QS_ii_DGView1.CurrentRow.Cells["傳真"].Value.ToString();
            QSii.VAT_NO = QS_ii_DGView1.CurrentRow.Cells["統一編號"].Value.ToString();
            QSii.CUST_ADDR = QS_ii_DGView1.CurrentRow.Cells["客戶地址"].Value.ToString();
            QSii.CUST_MAIL = QS_ii_DGView1.CurrentRow.Cells["客戶MAIL"].Value.ToString();            
            QSii.DELI_ADDR_NO = QS_ii_DGView1.CurrentRow.Cells["送貨郵地區號"].Value.ToString();
            QSii.DELI_ADDR = QS_ii_DGView1.CurrentRow.Cells["送貨地址"].Value.ToString();
            QSii.PAY_METH = QS_ii_DGView1.CurrentRow.Cells["付款方式"].Value.ToString();            
            QSii.CHAIN_NO = QS_ii_DGView1.CurrentRow.Cells["主要通路"].Value.ToString();
        }

        public override void QS_ii_QueryDGV_QueryButton()        //查詢Button
        {
            #region 內容
            QSii.GetSQL("查詢");    //語法丟進QueryDB
            if (QS_ii_QueryDGv_PID.Text != "")
            {
                QSii.QueryDB += @"and [客戶編號] = N'" + QS_ii_QueryDGv_PID.Text.Trim() + "'";
            }
            QSii.fun.xxx_DB(QSii.QueryDB, QS_ii_DGView1);         //連接DB-執行DB指令           
            #endregion
        }

    }

    public class QS_ii_Customer_TQuery_CHAIN : QS_ii_QueryDGV
    {
        QS_ii_Customer QSii;
        public QS_ii_Customer_TQuery_CHAIN(QS_ii_Customer x)
        {
            this.QSii = x;
        }

        public override void QS_ii_QueryDGV_DGView1()       //把選取資料對應到TextBox
        {
            QSii.CHAIN_NO = QS_ii_DGView1.CurrentRow.Cells["通路編號"].Value.ToString();
            
        }

        public override void QS_ii_QueryDGV_QueryButton()        //查詢Button
        {
            #region 內容
            QSii.GetSQL("通路查詢");    //語法丟進QueryDB            
            QSii.fun.xxx_DB(QSii.QueryDB, QS_ii_DGView1);         //連接DB-執行DB指令           
            #endregion
        }
    }

   
}
