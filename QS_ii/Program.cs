using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LOGIN;
namespace QS_ii
{
    static class Program 
    {
        private class UILOG :Login_main 
        {            
            public override void V_login_Default()      //設定LOGIN變數
            {
                base.V_login_Default();
                base.Query_DB = @"exec [TEST_SLSYHI].[dbo].[SLS_QS_Login] '" +
                                ID_Login + @"','" + App_LoginPW + "'";
            }

            public override void V_login()      //開窗
            {
                QS_ii_Quotes_add QiQ = new QS_ii_Quotes_add();
                //設定init_Staff 新視窗的相對位置#############
                QiQ.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                //############################################
                QiQ.QS_ii_Server_ENV.Text = ServerName;
                QiQ.USER_ID.Text = UID;
                this.Hide();
                QiQ.ShowDialog(this);
                this.Close();
            }

        }
        
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new QS_ii_Quotes_add());
            Application.Run(new UILOG());
        }
    }
}
