using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
using System.Drawing.Imaging;

namespace AojReport.AojPrintEngine
{
    public partial class AojPrintPreviewControl : UserControl
    {
        #region 变量设定
        /// <summary>
        /// 新的图片加入的时候旧的图片销毁
        /// </summary>
        private bool needDisposeImage = true;

        /// <summary>
        /// 放大倍率
        /// </summary>
        private int currentScalePercent = 100;
        /// <summary>
        /// 显示所有
        /// </summary>
        private bool isAllZoom = true;

        private PrintDocument pd;

        private int mouse_x = 0;
        private int mouse_y = 0;

        private Boolean isEnter = false;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public AojPrintPreviewControl()
        {
            InitializeComponent();
            this.pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            this.AutoScroll = true;
        }
        #endregion

        #region  属性定义
        /// <summary>
        /// 设定图片显示控件
        /// </summary>
        [Bindable(false)]
        public PictureBox PictureBox
        {
            get { return this.pictureBox; }
        }

        /// <summary>
        /// 当新的图片设定时销毁旧图片
        /// </summary>
        [Bindable(true), DefaultValue(true)]
        public bool NeedDisposeImage
        {
            get { return this.needDisposeImage; }
            set { this.needDisposeImage = value; }
        }

        /// <summary>
        /// 设定在图片控件显示的图片
        /// </summary>
        [Bindable(true)]
        public Image Picture
        {
            get { return this.pictureBox.Image; }
            set
            {
                if (this.pictureBox.Image != null && this.NeedDisposeImage)
                {
                    this.pictureBox.Image.Dispose();
                }
                this.pictureBox.Image = value;
                ScalePictureBoxToFit();
            }
        }

        /// <summary>
        /// 指定的放大倍数。
        /// </summary>
        public double Zoom
        {
            set
            {
                isAllZoom = false;
                this.currentScalePercent = (int)(value * 100d);
                ScalePictureBoxToFit();
            }
        }

        /// <summary>
        /// 画面适合的Zoom
        /// </summary>
        public bool AutoZoom
        {
            set
            {
                isAllZoom = true;
                ScalePictureBoxToFit();
            }
        }

        /// <summary>
        /// 设置使用的PrintDocument
        /// </summary>
        public PrintDocument Document
        {
            set
            {
                this.pd = value;
                if (pd != null)
                {
                    AojPrintController controller = (AojPrintController)pd.PrintController;
                    controller.SetPictureBox(pictureBox);
                }
            }
            get { return this.pd; }
        }
        #endregion

        #region 外部调用
        /// <summary>
        /// 图片和控件再次描绘
        /// </summary>
        public void InvalidatePreview()
        {
            if (pd != null)
            {
                pd.Print();
            }
            ScalePictureBoxToFit();
        }
        #endregion

        #region 内部实现
        /// <summary>
        /// 计算图片控件适合当前的大小和宽度
        /// </summary>
        private void ScalePictureBoxToFit()
        {
            //如果显示控件内没有图片侧直接返回
            if (this.Picture == null)
            {
                return;
            }

            this.AutoScroll = false;

            if (isAllZoom)
            {
                this.currentScalePercent = GetMinScalePercent();
            }

            //根据当前放大倍率设置显示控件的长宽
            this.pictureBox.Width = this.Picture.Width * this.currentScalePercent / 100;
            this.pictureBox.Height = this.Picture.Height * this.currentScalePercent / 100;

            int top = (this.ClientSize.Height - this.pictureBox.Height) / 2;
            int left = (this.ClientSize.Width - this.pictureBox.Width) / 2;

            if (top < 0)
            {
                top = this.AutoScrollPosition.Y;
            }
            if (left < 0)
            {
                left = this.AutoScrollPosition.X;
            }
            this.pictureBox.Left = left;
            this.pictureBox.Top = top;
            this.AutoScroll = true;

            this.Focus();

            this.pictureBox.Invalidate();


        }

        /// <summary>
        /// 重置控件大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnResize(object sender, System.EventArgs e)
        {
            ScalePictureBoxToFit();
        }

        /// <summary>
        /// 获取当前图片的最小比率
        /// </summary>
        /// <returns>获取比例</returns>
        private int GetMinScalePercent()
        {
            if ((this.Picture == null) ||
                (this.Picture.Width <= this.ClientSize.Width) && (this.Picture.Height <= this.ClientSize.Height))
            {
                return currentScalePercent;
            }

            float minScalePercent = Math.Min((float)this.ClientSize.Width / (float)this.Picture.Width,
                                             (float)this.ClientSize.Height / (float)this.Picture.Height);
            return (int)(minScalePercent * 100.0f);
        }

        /// <summary>
        /// 获取当前图片的合适宽度
        /// </summary>
        /// <returns>fit width scale percent which is bigger than minimum scale percent</returns>
        private int GetFitWidthScalePercent()
        {
            if (this.Picture == null)
            {
                return currentScalePercent;
            }

            int fitWidthScalePercent = Math.Min(this.ClientSize.Width * 100 / this.Picture.Width, 100);
            return Math.Max(fitWidthScalePercent, GetMinScalePercent());
        }
        #endregion

        #region pictureBox的事件设置
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.isEnter = true;
                mouse_x = e.X;
                mouse_y = e.Y;

                this.Cursor = Cursors.Hand;
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (!this.isEnter)
            {
                return;
            }

            int nPosX = e.X - mouse_x;
            int nPosY = e.Y - mouse_y;

            this.AutoScrollPosition = new Point(-this.AutoScrollPosition.X - nPosX, -this.AutoScrollPosition.Y - nPosY);

            this.Cursor = Cursors.Default;

            this.isEnter = false;
        }

        /// <summary>
        /// 当大小改变时重绘控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_LocationChanged(object sender, EventArgs e)
        {
            this.pictureBox.Invalidate(false);
        }

        private void AojPrintPreviewControl_Resize(object sender, EventArgs e)
        {
            this.OnResize(sender, e);
        }
        #endregion
    }
    #region AojPrintController Class
    public class AojPrintController : PrintController
    {
        private PictureBox pic;

        private int dpi;
        private MemoryStream ms;
        public void SetPictureBox(PictureBox pic)
        {
            this.pic = pic;
            dpi = (int)Graphics.FromHwnd(pic.Handle).DpiX;
        }

        public override Graphics OnStartPage(PrintDocument document, PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(1, 1);

            Graphics bmpg = Graphics.FromImage(bmp);
            IntPtr hdc = bmpg.GetHdc();
            ms = new MemoryStream();
            Metafile meta = new Metafile(ms, hdc, EmfType.EmfPlusDual);
            bmpg.ReleaseHdc(hdc);

            this.pic.Image = meta;

            Graphics g = Graphics.FromImage(meta);

            PaperSize size = e.PageSettings.PaperSize;
            int height = size.Height * dpi / 100;
            int width = size.Width * dpi / 100;

            if (e.PageSettings.Landscape)
            {
                g.FillRectangle(Brushes.White, 0, 0, height, width);
                g.SetClip(new Rectangle(0, 0, height - 16, width - 16));
            }
            else
            {
                g.FillRectangle(Brushes.White, 0, 0, width, height);
                g.SetClip(new Rectangle(0, 0, width - 16, height - 16));
            }

            return g;
        }
        public override void OnStartPrint(PrintDocument document, PrintEventArgs e)
        {

        }

        public override void OnEndPrint(PrintDocument document, PrintEventArgs e)
        {

        }
        public override void OnEndPage(PrintDocument document, PrintPageEventArgs e)
        {
            //if (ms != null)
            //{
            //    ms.Close();
            //}
        }
    }
    #endregion
}
