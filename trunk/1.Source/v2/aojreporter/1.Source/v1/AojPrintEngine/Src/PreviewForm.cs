using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using AojReport.AojPrintEngine.AojPrintGraphicsParse;

namespace AojReport.AojPrintEngine
{
    public partial class PreviewForm : Form
    {
        AojPrint aojPrint;

        #region 构造函数
        public PreviewForm(PrintDocument printdocument,AojPrint aojprint)
        {
            InitializeComponent();
            this.InitControl();
            this.aojPrint = aojprint;
            this.aojPrintPreviewControl.Document = printdocument;
            this.tlsbZoom.SelectedIndexChanged += new EventHandler(tlsbZoom_SelectedIndexChanged);
            this.tlsbPrint.Click += new System.EventHandler(this.tlsbtnPrint_Click);
            this.tlsbPrv.Click += new EventHandler(tlsbtnPre_Click);
            this.tlsbPrvStart.Click += new EventHandler(tlsbPrvStart_Click);
            this.tlsbNext.Click += new EventHandler(tlsbtnNext_Click);
            this.tlsbNextEnd.Click += new EventHandler(tlsbNextEnd_Click);
            this.lblCurrentPage.Text = (aojprint.CurrentPage+1).ToString();
            this.lblAllPage.Text = aojprint.TotalPage.ToString();
        }

        void tlsbNextEnd_Click(object sender, EventArgs e)
        {
            if (aojPrint.CurrentPage >= aojPrint.TotalPage - 1)
            {
                return;
            }
            aojPrint.CurrentPage = aojPrint.TotalPage-1;
            this.aojPrintPreviewControl.InvalidatePreview();
            this.lblCurrentPage.Text = (aojPrint.CurrentPage + 1).ToString();
        }

        void tlsbPrvStart_Click(object sender, EventArgs e)
        {
            if (0 >= aojPrint.CurrentPage)
            {
                return;
            }
            aojPrint.CurrentPage = 0;
            this.aojPrintPreviewControl.InvalidatePreview();
            this.lblCurrentPage.Text = (aojPrint.CurrentPage + 1).ToString();
        }

        #endregion

        #region 画面初始化
        private void InitControl()
        {
            #region  Zoom的初始化
            this.tlsbZoom.Items.AddRange(new string[] { "400%", "200%", "100%", "50%", "Fit" });
            this.tlsbZoom.Text = "100%";
            #endregion
        }
        #endregion

        #region 方法封装
        /// <summary>
        /// 预览
        /// </summary>
        public void Preview()
        {
            this.aojPrintPreviewControl.Zoom = 1;
            this.aojPrintPreviewControl.InvalidatePreview();
            this.ShowDialog();
        }
        /// <summary>
        /// 打印
        /// </summary>
        private void Print()
        {
            if (aojPrint == null)
            {
                return;
            }
            aojPrint.Print();
        }
        /// <summary>
        /// 向前翻页
        /// </summary>
        private void PageNext()
        {
            if (aojPrint.CurrentPage >= aojPrint.TotalPage - 1)
            {
                return;
            }
            aojPrint.CurrentPage += 1;
            this.aojPrintPreviewControl.InvalidatePreview();
            this.lblCurrentPage.Text = (aojPrint.CurrentPage + 1).ToString();
        }
        /// <summary>
        /// 向后翻页
        /// </summary>
        private void PagePre()
        {
            if (0 >= aojPrint.CurrentPage)
            {
               return;
            }
            aojPrint.CurrentPage -= 1;
            this.aojPrintPreviewControl.InvalidatePreview();
            this.lblCurrentPage.Text = (aojPrint.CurrentPage + 1).ToString();
        }

        #endregion

        #region 事件封装
        private void tlsbtnPre_Click(object sender, EventArgs e)
        {
            this.PagePre();
        }

        private void tlsbtnNext_Click(object sender, EventArgs e)
        {
            this.PageNext();
        }

        private void tlsbtnPrint_Click(object sender, EventArgs e)
        {
            this.Print();
        }

        void tlsbZoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strTlsbZoomText = tlsbZoom.Text.Replace("%", string.Empty);
            switch (strTlsbZoomText)
            {
                case "400":
                    this.aojPrintPreviewControl.Zoom = 4;
                    break;
                case "200":
                    this.aojPrintPreviewControl.Zoom = 2;
                    break;
                case "100":
                    this.aojPrintPreviewControl.Zoom = 1;
                    break;
                case "75":
                    this.aojPrintPreviewControl.Zoom = 0.75;
                    break;
                case "50":
                    this.aojPrintPreviewControl.Zoom = 0.5;
                    break;
                case "Fit":
                    this.aojPrintPreviewControl.AutoZoom = true;
                    this.aojPrintPreviewControl.Refresh();
                    break;
                default:
                    {
                        int nTempScale;
                        if (!int.TryParse(strTlsbZoomText, out nTempScale))
                        {
                            nTempScale = 100;
                        }
                        this.aojPrintPreviewControl.Zoom = nTempScale / 100f;
                    }
                    break;
                /* 
                case "左右分屏":
                    this.aojPrintPreviewControl.Columns = 2;
                    break;
                case "显示四个":
                    this.aojPrintPreviewControl.Columns = 2;
                    this.aojPrintPreviewControl.Rows = 2;
                    break;
                */
            }
        }
        #endregion
    }
}
