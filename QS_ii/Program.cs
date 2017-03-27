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

            public override void V_login()
            {
                QS_ii_Quotes_add QiQ = new QS_ii_Quotes_add();
                //QiQ.DMS_Service_ENV = Login_ServerCB.Text;       //server
                //QiQ.DMS_UID = Login_ID_tb.Text;          //使用者ID
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
            Application.Run(new QS_ii_Quotes_add());
        }
    }
}
