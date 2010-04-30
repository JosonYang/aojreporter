using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace AojReport.AojWinForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #region 启动一个新线程
            Thread threadInfo = new Thread(OpenProgramStartingForm);
            threadInfo.Start();          
            Thread.Sleep(300);
            threadInfo.Abort();
            #endregion

            #region 启动报表设计器
            if (args == null || args.Length == 0)
            {
                Application.Run(new MainForm());
            }
            else
            {
                #region 报表设计器将要打开的文件地址
                string strDocumentPath = string.Empty;
                for (int index = 0; index < args.Length; index++)
                {
                    strDocumentPath += " " + args[index].ToString();
                }
                #endregion

                Application.Run(new MainForm(strDocumentPath));
            }
            #endregion
        }

        #region Method(方法)

        /// <summary>
        /// 报表设计器窗体初始化加载时候的效果窗体
        /// </summary>
        private static void OpenProgramStartingForm()
        {
            ProgramStarting frmStarting = new ProgramStarting();
            frmStarting.ShowDialog();
        }

        #endregion
    }
}
