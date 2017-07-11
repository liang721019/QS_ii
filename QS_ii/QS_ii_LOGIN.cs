using LOGIN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QS_ii
{
    class QS_ii_LOGIN : Login_main
    {        
        private DataTable QS_LOGIN_DT
        {            
            get
            {
                return new DataTable();
            }
        }

        public override void V_login_SetENV()      //設定LOGIN變數
        {
            base.V_login_SetENV();
            //Query_DB = @"exec [TEST_SLSYHI].[dbo].[SLS_QS_Login] '" +
            //                ID_Login + @"','" + App_LoginPW + "'";
            Query_DB = @"select * from [dbo].[SLS_QS_LOGINTemp]('" + ID_Login + "','"+App_LoginPW+"')";            
            LOD_DT = QS_LOGIN_DT;

        }

        public override void V_login_open()      //開窗
        {
            DataView DV = new DataView(LOD_DT);
            DV.RowFilter = "QS_Login = 'Y'";
            if (DV.Count == 1)
            {
                #region 內容
                //******************************************
                QS_ii_Quotes_add QiQ = new QS_ii_Quotes_add();
                //設定init_Staff 新視窗的相對位置#############
                QiQ.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                //############################################
                //string Query_DB = @"select * from [dbo].[SLS_QS_LOGINTemp]('" + UID + "')";
                //QiQ.fun.USER_INFO(Query_DB, QiQ.QSiiDB.Tables["SLS_QS_ii_LOGIN"]);        //登入後載入使用者資訊至DS
                //LOD_DT =>this.LOD.SLS_QS_LOGIN
                DataRow QiQDR = QiQ.QSiiDB.QS_ii_LOGIN.NewRow();
                QiQDR["EMP_ID"] = LOD_DT.Rows[0]["EMP_ID"];
                QiQDR["EMP_Name"] = LOD_DT.Rows[0]["EMP_Name"];
                QiQDR["QS_Login"] = LOD_DT.Rows[0]["QS_Login"];
                QiQDR["QS_ADD"] = LOD_DT.Rows[0]["QS_ADD"];
                QiQDR["QS_Modify"] = LOD_DT.Rows[0]["QS_Modify"];
                QiQDR["QS_Del"] = LOD_DT.Rows[0]["QS_Del"];
                QiQDR["Del_Flag"] = LOD_DT.Rows[0]["Del_Flag"];
                QiQDR["Create_Date"] = LOD_DT.Rows[0]["Create_Date"];
                QiQDR["Create_Time"] = LOD_DT.Rows[0]["Create_Time"];
                QiQ.QSiiDB.QS_ii_LOGIN.Rows.Add(QiQDR);
                QiQ.QSiiDB.QS_ii_LOGIN.AcceptChanges();
                QiQ.QS_ii_Server_ENV.Text = GETServerName;
                QiQ.USER_ID.Text = UID;
                this.Hide();
                QiQ.ShowDialog(this);
                this.Close();
                //******************************************
                #endregion
            }
            else
            {
                MessageBox.Show("您沒有權限登入!!\n請找資訊部門協助",this.Text);
            }
        }
    }
}
