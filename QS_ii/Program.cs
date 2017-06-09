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
                
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new QS_ii_Quotes_add());
            Application.Run(new QS_ii_LOGIN());
        }
    }
}
