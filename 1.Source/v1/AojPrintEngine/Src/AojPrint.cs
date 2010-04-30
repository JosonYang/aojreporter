using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Threading;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using AojReport.AojPrintEngine.AojPrintGraphicsParse;
using AojReport.AojPrintEngine.Common;

namespace AojReport.AojPrintEngine
{
    /// <summary>
    /// 包含数据的入口
    /// </summary>
    public class AojPrint
    {
        #region 变量定义
        PrintDocument printdocument = null;
        AojMainPrinter aojPrint;
        PrintPreviewState State = PrintPreviewState.Print;
        PreviewForm PF = null;
        #endregion

        #region 属性封装
        private int _currentPage = 0;
        /// <summary>
        /// 当前页面
        /// </summary>
        public int CurrentPage
        {
            get { return _currentPage; }
            set { _currentPage = value; }
        }
        /// <summary>
        /// 总数
        /// </summary>
        public int TotalPage
        {
            get { return this.aojPrint.GraphicsObjectList.Count; }
        }
        #endregion

        #region 构造函数
        public AojPrint() 
        {
            aojPrint = new AojMainPrinter();
            printdocument = new PrintDocument();
            printdocument.QueryPageSettings += new QueryPageSettingsEventHandler(printdocument_QueryPageSettings);
            printdocument.PrintPage += new PrintPageEventHandler(printdocument_PrintPage);
            printdocument.BeginPrint += new PrintEventHandler(printdocument_BeginPrint);
            printdocument.EndPrint += new PrintEventHandler(printdocument_EndPrint);
        }
        #endregion

        #region 数据操作
        public void PrintDataTable(string postion, object paper, DataTable dtSource,bool isList)
        {
            if (isList)
            {
                aojPrint.PrintDataTableToList(postion, paper, dtSource);
            }
            else
            {
                aojPrint.PrintDataTableToPoint(postion, paper, dtSource);
            }
        }
        public void PrintDataTableValue(string position, string value, int npaper)
        {
            aojPrint.SetPrintValueByPosition(position, value, npaper, false);
        }
        public void PrintDataTableSrc(string position, string src, int npaper)
        {
            aojPrint.SetPrintValueByPosition(position, src, npaper, true);
        }
        public void PrintDataTableImage(string position,Image image,int npaper)
        {
            aojPrint.SetPrintImageByPosition(position, image, npaper);
        }
        #region 当前模板打印全局设定
        public void SetStaticPropertyByPosition(string position, string value, object paper)
        {
            aojPrint.SetStaticPropertyByPosition(position, value, paper, false);
        }
        public void SetStaticPropertyByPosition(string position, Image Image, object paper)
        {
            aojPrint.SetStaticPropertyByPosition(position, Image, paper);
        }
        public void SetStaticImageSrcByPosition(string position, string src, object paper)
        {
            aojPrint.SetStaticPropertyByPosition(position, src, paper, true);
        }
        #endregion
        #endregion

        #region 打印功能
        public void Parse(string url)
        {
            aojPrint.Parse(url);
        }
        public void Parse(string[] urls)
        {
            aojPrint.Parse(urls);
        }
        public void Preview()
        {
            if (this.IsPreView())
            {
                State = PrintPreviewState.Preview;
                printdocument.PrintController = new AojPrintController();
                PF = new PreviewForm(printdocument, this);
                PF.Preview();
            }
        }
        public void Print()
        {
            try
            {
                if (this.IsPrint())
                {
                    printdocument.PrintController = new StandardPrintController();
                    this.CurrentPage = 0;
                    PrintForm pf = new PrintForm(printdocument.DefaultPageSettings);
                    pf.ShowDialog();
                    if (pf.Result == PrintDialogResult.Cancel
                        || pf.Result == PrintDialogResult.None)
                    {
                        return;
                    }
                    State = PrintPreviewState.Print;
                    printdocument.Print();
                    if (PF != null)
                    {
                        PF.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        protected virtual bool IsPrint()
        {
            return true;
        }
        protected virtual bool IsPreView()
        {
            return true;
        }
        #endregion

        #region 打印文档设定
        void printdocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Point;
            switch (State)
            {
                case PrintPreviewState.Print:
                    {
                        AojPrintPaper ap = null;
                        ap = this.aojPrint.GetCurrentPaper(this.CurrentPage);

                        if (ap != null)
                        {
                            ap.Print(e.Graphics);
                        }
                        if (this.CurrentPage + 1 < this.TotalPage)
                        {
                            this.CurrentPage += 1;
                            e.HasMorePages = true;
                        }
                        else 
                        {
                            e.HasMorePages = false;
                        }
                    }
                    break;
                case PrintPreviewState.Preview:
                    {
                        //获取当前Paper
                        AojPrintPaper ap = this.aojPrint.GetCurrentPaper(this.CurrentPage);
                        if (ap != null)
                        {
                            ap.Print(e.Graphics);
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                        e.HasMorePages = false;
                    }
                    break;

            }
        }
        void printdocument_QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
        {           
            //获取当前Paper
            AojPrintPaper ap = this.aojPrint.GetCurrentPaper(this.CurrentPage);
            if (ap != null)
            {
                bool isOrientation = (ap.Orientation.Equals("Landscape", StringComparison.CurrentCultureIgnoreCase) ? true : false);
                //边距
                e.PageSettings.Margins = new Margins(ap.Margin, ap.Margin, ap.Margin, ap.Margin);
                {
                    PaperSize paperSize = new PaperSize();
                    e.PageSettings.PaperSize = this.GetPrintPageSize(ap.PaperSizeName, isOrientation);
                }
                //设置打印纸方向
                e.PageSettings.Landscape = isOrientation;
            }
        }
        void printdocument_BeginPrint(object sender, PrintEventArgs e)
        {
           
        }
        void printdocument_EndPrint(object sender, PrintEventArgs e)
        {
             
        }
        private PaperSize GetPrintPageSize(string strPaperSizeName, bool isOrientation)
        {
            PaperSize paperSize = null;
            foreach (PaperSize size in this.printdocument.PrinterSettings.PaperSizes)
            {
                if (strPaperSizeName == size.PaperName)
                {
                    paperSize = size;
                }
            }
            return paperSize;
        }
        #endregion

        #region inner enum

        private enum PrintPreviewState
        {
            Print = 0,
            Preview = 1,
        }
        #endregion

    }
    #region PrintState
    public enum PrintDialogResult
    {
        None = 0,
        //关闭
        Cancel = 1,
        //最终打印的状态
        Yes = 2,
        //打印中的状态
        Set = 3,
    }
    #endregion
}
