using LOGIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QS_ii
{
    class QS_ii_LOGIN : Login_main 
    {
        public override void V_login_SetENV()      //設定LOGIN變數
        {
            base.V_login_SetENV();
            Query_DB = @"exec [TEST_SLSYHI].[dbo].[SLS_QS_Login] '" +
                            ID_Login + @"','" + App_LoginPW + "'";
        }

        public override void V_login_open()      //開窗
        {
            QS_ii_Quotes_add QiQ = new QS_ii_Quotes_add();
            //設定init_Staff 新視窗的相對位置#############
            QiQ.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //############################################
            //string Query_DB = @"select * from [dbo].[SLS_Asset_LOGINTemp]('" + UID + "')";
            //QiQ.fun.USER_INFO(Query_DB, iPO.MYDS.Tables["SLS_Asset_LOGIN"]);         //登入後載入使用者資訊至DS
            QiQ.QS_ii_Server_ENV.Text = ServerName;
            QiQ.USER_ID.Text = UID;
            this.Hide();
            QiQ.ShowDialog(this);
            this.Close();
        }
    }
}
