using System;
using System.Text;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Collections.Generic;
using AojReport.AojPrintEngine.AojPrintGraphicsParse;
using System.Drawing.Imaging;


namespace AojReport.AojPrintEngine.Common
{
    public class AojGrapicsHelper
    {
        public AojGrapicsHelper() { }

        public static Rectangle GetRectangle(AojPrintPropertySystem propertySystem)
        {
            return AojGrapicsHelper.GetRectangle(propertySystem.X, propertySystem.Y, propertySystem.Width, propertySystem.Height);
        }

        /// <summary>
        /// 创建一个矩形对象
        /// </summary>
        /// <param name="x">横坐标</param>
        /// <param name="y">纵坐标</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <returns></returns>
        public static Rectangle GetRectangle(int x, int y, int width, int height)
        {
            Rectangle rt = new Rectangle(x, y, width, height);
            return rt;
        }

        /// <summary>
        ///  获取显示的文本垂直和水平的对齐信息
        /// </summary>
        /// <param name="alignment">显示对齐的字符串</param>
        /// <returns></returns>
        public static StringFormat GetStringFormatAlignment(AojPrintPropertySystem propertySystem)
        {
            //文本文字显示和布局的信息
            StringFormat stringFormat = new StringFormat();

            //排序方向
            AlignmentFlags alignmentFlags = AojUnitConvert.GetEnumType<AlignmentFlags,string>(propertySystem.Alignment);

            #region 文本在区域内打印的地方
            /**
             *  Alignment      获取或设置垂直面上的文本对齐信息
             *  LineAlignment  获取或设置水平面上的行对齐信息。 
             */
            switch (alignmentFlags)
            {
                case AlignmentFlags.LeftTop:
                    {
                        //左上
                        stringFormat.Alignment = StringAlignment.Near;
                        stringFormat.LineAlignment = StringAlignment.Near;
                        propertySystem.RealX = propertySystem.X;
                        propertySystem.RealY = propertySystem.Y;
                    }
                    break;
                case AlignmentFlags.LeftMiddle:
                    {
                        //左中
                        stringFormat.Alignment = StringAlignment.Near;
                        stringFormat.LineAlignment = StringAlignment.Center;
                        propertySystem.RealX = propertySystem.X;
                        propertySystem.RealY = propertySystem.Y + propertySystem.Height / 2;
                    }
                    break;
                case AlignmentFlags.LeftBottom:
                    {
                        //左下
                        stringFormat.Alignment = StringAlignment.Near;
                        stringFormat.LineAlignment = StringAlignment.Far;
                        propertySystem.RealX = propertySystem.X;
                        propertySystem.RealY = propertySystem.Y + propertySystem.Height;
                    }
                    break;
                case AlignmentFlags.RightTop:
                    {
                        //右上
                        stringFormat.Alignment = StringAlignment.Far;
                        stringFormat.LineAlignment = StringAlignment.Near;
                        propertySystem.RealX = propertySystem.X + propertySystem.Width;
                        propertySystem.RealY = propertySystem.Y;
                    }
                    break;
                case AlignmentFlags.RightMiddle:
                    {
                        //右中
                        stringFormat.Alignment = StringAlignment.Far;
                        stringFormat.LineAlignment = StringAlignment.Center;
                        propertySystem.RealX = propertySystem.X + propertySystem.Width;
                        propertySystem.RealY = propertySystem.Y + propertySystem.Height / 2;
                    }
                    break;
                case AlignmentFlags.RightBottom:
                    {
                        //右下
                        stringFormat.Alignment = StringAlignment.Far;
                        stringFormat.LineAlignment = StringAlignment.Far;
                        propertySystem.RealX = propertySystem.X + propertySystem.Width;
                        propertySystem.RealY = propertySystem.Y + propertySystem.Height;
                    }
                    break;
                case AlignmentFlags.CenterTop:
                    {
                        //中上
                        stringFormat.Alignment = StringAlignment.Center;
                        stringFormat.LineAlignment = StringAlignment.Near;
                        propertySystem.RealX = propertySystem.X + propertySystem.Width / 2;
                        propertySystem.RealY = propertySystem.Y;
                    }
                    break;
                case AlignmentFlags.Defualt:
                case AlignmentFlags.CenterMiddle:
                    {
                        //中中
                        stringFormat.Alignment = StringAlignment.Center;
                        stringFormat.LineAlignment = StringAlignment.Center;
                        propertySystem.RealX = propertySystem.X + propertySystem.Width / 2;
                        propertySystem.RealY = propertySystem.Y + propertySystem.Height / 2;
                    }
                    break;
                case AlignmentFlags.CenterBottom:
                    {
                        //中下
                        stringFormat.Alignment = StringAlignment.Center;
                        stringFormat.LineAlignment = StringAlignment.Far;
                        propertySystem.RealX = propertySystem.X + propertySystem.Width / 2;
                        propertySystem.RealY = propertySystem.Y + propertySystem.Height;
                    }
                    break;
            }
            #endregion

            return stringFormat;
        }

        /// <summary>
        /// 获取网页格式的颜色模式
        /// </summary>
        /// <param name="strColor"></param>
        /// <returns></returns>
        public static Color GetColor(string strColor)
        {
            Color color = ColorTranslator.FromHtml(strColor);
            return color;
        }

        /// <summary>
        /// 定义填充笔刷
        /// </summary>
        /// <param name="strColor"></param>
        /// <returns></returns>
        public static SolidBrush GetBrush(string strColor)
        {
            try
            {
                SolidBrush sb = new SolidBrush(AojGrapicsHelper.GetColor(strColor));
                return sb;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 绘制图像
        /// </summary>
        /// <param name="g">图片</param>
        /// <param name="propertySystem">属性系统</param>
        public static void DrawImage(Graphics g, AojPrintPropertySystem propertySystem)
        {
            try
            {
                Rectangle r = AojGrapicsHelper.GetRectangle(AojUnitConvert.SafeRound(propertySystem.X + propertySystem.BorderWidth)
                    , AojUnitConvert.SafeRound(propertySystem.Y + propertySystem.BorderWidth)
                    , AojUnitConvert.SafeRound(propertySystem.Width - propertySystem.BorderWidth * 2)
                    , AojUnitConvert.SafeRound(propertySystem.Height - propertySystem.BorderWidth * 2));
                //对图片进行流读取后打印到图像上
                g.DrawImage(propertySystem.ImgPrint, r);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        /// <summary>
        /// 描绘图形区域
        /// </summary>
        /// <param name="g"></param>
        /// <param name="propertySystem"></param>
        public static void DrawRectangle(Graphics g, AojPrintPropertySystem propertySystem)
        {
            #region 描绘图形边线
            _drawBorderRectangle(g, propertySystem);
            #endregion

            #region 填充图形区域
            BackgroundStyle bakStyle = AojUnitConvert.GetEnumType<BackgroundStyle,object>(propertySystem.BackgroundStyle);
            switch (bakStyle)
            {
                case BackgroundStyle.None:
                    break;
                case BackgroundStyle.Solid:
                    {
                        //填充图形
                        _drawFillRectangle(g, propertySystem);
                    }
                    break;
            }
            #endregion
        }

        /// <summary>
        /// 描绘直线
        /// </summary>
        /// <param name="g"></param>
        /// <param name="propertySystem"></param>
        public static void DrawLine(Graphics g, AojPrintPropertySystem propertySystem)
        {
            
        }

        /// <summary>
        /// 绘画文本，如果有特殊的处理如转换格式等均在此处做转换处理后输出
        /// </summary>
        /// <param name="g">画板</param>
        /// <param name="propertySystem">属性</param>
        public static void DrawString(Graphics g, AojPrintPropertySystem propertySystem)
        {
            //文本为空时，不进行打印
            if (string.IsNullOrEmpty(propertySystem.Value))
            {
                return;
            }
            //检查打印的字符串是否需要进行格式转换
            if (propertySystem.ViewFormat != 0)
            {
                _formatString(propertySystem);
            }
            //如果Font不为空时进行打印
            if (propertySystem.GetFont() != null)
            {
                //读取字体的显示模式
                FontDisplayFormat fontDisplayFormat= AojUnitConvert.GetEnumType<FontDisplayFormat,string>(propertySystem.FontDisplayFormat);
                switch (fontDisplayFormat)
                {
                    case FontDisplayFormat.NoFormat:
                        _drawNoFormat(g,propertySystem);
                        break;
                    case FontDisplayFormat.AutoSize:
                        _drawAutoSize(g, propertySystem);
                        break;
                    case FontDisplayFormat.AutoFormat:
                    default:
                        break;
                }
            }
        }

        public static void ImageSave(Image image)
        {
            image.Save(@"c:\Aojtest\" +  DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString() + ".jpg", ImageFormat.Emf);
        }

        #region 私有方法
        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="propertySystem"></param>
        private static void _drawBorderRectangle(Graphics g, AojPrintPropertySystem propertySystem)
        {
            try
            {
                Rectangle r = AojGrapicsHelper.GetRectangle(propertySystem);
                //获取本标签中的图形标示属性
                BackgroundShape shape = AojUnitConvert.GetEnumType<BackgroundShape,string>(propertySystem.BackgroundShape);
                switch (shape)
                {
                    case BackgroundShape.None:
                        //TODO:Draw Line
                        break;
                    //长方形区域
                    case BackgroundShape.Rectangle:
                        {
                            //描绘图形
                            g.DrawRectangle(propertySystem.GetPen(), r);
                        }
                        break;
                    //圆形区域
                    case BackgroundShape.Ellipse:
                        {
                            //描绘图形
                            g.DrawEllipse(propertySystem.GetPen(), r);
                        }
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        /// <summary>
        /// 填充图形
        /// </summary>
        /// <param name="g"></param>
        /// <param name="propertySystem"></param>
        private static void _drawFillRectangle(Graphics g, AojPrintPropertySystem propertySystem)
        {
            Rectangle r;
            try
            {
                r = AojGrapicsHelper.GetRectangle(AojUnitConvert.SafeRound(propertySystem.X + propertySystem.BorderWidth)
                    ,AojUnitConvert.SafeRound(propertySystem.Y + propertySystem.BorderWidth)
                    ,AojUnitConvert.SafeRound(propertySystem.Width - propertySystem.BorderWidth*2)
                    ,AojUnitConvert.SafeRound(propertySystem.Height - propertySystem.BorderWidth*2));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            //获取本标签中的填充属性
            BackgroundShape shape = AojUnitConvert.GetEnumType<BackgroundShape,string>(propertySystem.BackgroundShape);

            switch (shape)
            {
                case BackgroundShape.None:
                    //Draw Line
                    break;
                //长方形区域
                case BackgroundShape.Rectangle:
                    {

                        //填充图形
                        g.FillRectangle(AojGrapicsHelper.GetBrush(propertySystem.BackgroundColor), r);
                    }
                    break;
                //圆形区域
                case BackgroundShape.Ellipse:
                    {
                        //填充图形
                        g.FillEllipse(AojGrapicsHelper.GetBrush(propertySystem.BackgroundColor), AojGrapicsHelper.GetRectangle(propertySystem));
                    }
                    break;
            }
        }

        /// <summary>
        /// 没有任何显示格式限制下的打印
        /// </summary>
        /// <param name="g"></param>
        /// <param name="propertySystem"></param>
        private static void _drawNoFormat(Graphics g, AojPrintPropertySystem propertySystem)
        {
            StringFormat sf = GetStringFormatAlignment(propertySystem);
            g.DrawString(propertySystem.Value, propertySystem.GetFont(), GetBrush(propertySystem.FontColor)
                , propertySystem.RealX, propertySystem.RealY, sf);
        }

        /// <summary>
        /// 自适应区域宽高度进行打印
        /// </summary>
        /// <param name="g">图像区域</param>
        /// <param name="propertySystem"></param>
        private static void _drawAutoSize(Graphics g, AojPrintPropertySystem propertySystem)
        {
            Font _currentFont = propertySystem.GetFont();
            while (true)
            {
                SizeF size = g.MeasureString(propertySystem.Value, _currentFont);
                //如果算出来的大小均在指定的范围内则跳出循环，打印出来
                if ((size.Width < propertySystem.Width) && (size.Height < propertySystem.Height))
                {
                    break;
                }
                if (_currentFont.Size - 0.1f < 0)
                {
                    //Throw Exception 
                    _currentFont = null;
                    break;
                }
                _currentFont = new Font(_currentFont.FontFamily, _currentFont.Size - 0.1f, _currentFont.Style);
            }
            if (_currentFont != null)
            {
                StringFormat sf = GetStringFormatAlignment(propertySystem);
                g.DrawString(propertySystem.Value, _currentFont, GetBrush(propertySystem.FontColor)
                , propertySystem.RealX, propertySystem.RealY, sf);
            }
         
        }

        /// <summary>
        /// 对要印刷的字符串进行格式化后输出
        /// </summary>
        /// <param name="propertySystem"></param>
        private static void _formatString(AojPrintPropertySystem propertySystem)
        {
               //对字符串进行格式化处理
        }
        #endregion
    }
}
