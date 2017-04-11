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

            
            Product_DGV_SetColumns();           //QS_ii_Product_DGV自定顯示欄位
            QS_ii_Product_DGV.DataSource = QSiiDB.QS_ii_Product;

            fun.Format_Panel_dTP(QS_ii_Head_panel, "yyyy-MM-dd");     //自訂日期格式
            fun.EoD_Panel_txt(QS_ii_Head_panel, true);     //QS_ii_Head_panel內的TextBox設定唯讀
            fun.EoD_Panel_DateTimePicker(QS_ii_Head_panel, false);       //QS_ii_Head_panel內的DateTimePicker設定唯讀
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
                QS_ii_新增button.Enabled = false;
                QS_ii_產品button.Enabled = false;
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
                QS_ii_產品button.Enabled = false;
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
                QS_ii_新增button.Enabled = true;
                QS_ii_產品button.Enabled = true;
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
                QS_ii_新增button.Enabled = true;
                QS_ii_產品button.Enabled = true;
                QS_ii_刪除button.Enabled = true;
                QS_ii_查詢button.Enabled = true;
                QS_ii_儲存button.Visible = false;
                QS_ii_取消button.Visible = false;
                QS_ii_儲存button.Enabled = false;
                QS_ii_取消button.Enabled = false;

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

        public void Product_DGV_SetColumns()           //QS_ii_Product_DGV自定顯示欄位
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

            QS_ii_TCustomer inSea = new QS_ii_TCustomer(this);            
            //設定init_Staff 新視窗的相對位置#############
            inSea.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //############################################
            inSea.Server_ENV.Text = QS_ii_Server_ENV.Text;      //server
            inSea.USER_ID.Text = USER_ID.Text;          //UID
            inSea.ShowDialog();

        }

        private void QS_ii_產品button_Click(object sender, EventArgs e)
        {
            //QS_ii_Product inQS_Product = new QS_ii_Product();
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

        }

        private void QS_ii_修改button_Click(object sender, EventArgs e)
        {

        }

        private void Product_新增button_Click(object sender, EventArgs e)
        {
            
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
            #endregion
        }

        private void Product_多選button_Click(object sender, EventArgs e)
        {

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

        
        
        //==============================================================================================================
        #endregion

    }

    public class QS_ii_TCustomer : QS_ii_Customer
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
        }
    }

    public class QS_ii_TProduct : QS_ii_Product
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

            DataRow QS_ii_dr = QS_iiQ_add.QSiiDB.QS_ii_Product.NewRow();
            QS_ii_dr["Check"] = "0";
            QS_ii_dr["item_NO"] = tb_item_NO.Text.Trim();
            QS_ii_dr["item_NAME"] = tb_item_NAME.Text.Trim();
            QS_ii_dr["UNIT"] = tb_UNIT.Text.Trim();
            QS_ii_dr["QTY"] = "1";
            QS_ii_dr["UNIT_PRICE"] = tb_UNIT_PRICE.Text.Trim();
            QS_iiQ_add.QSiiDB.QS_ii_Product.Rows.Add(QS_ii_dr);

            #endregion
        }
        
    }

}
