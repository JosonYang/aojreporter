using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using AojReport.AojPrintEngine.Common;

namespace AojReport.AojPrintEngine.AojPrintGraphicsParse
{
    public class AojPrintPropertySystem
        :IDisposable
        ,ICloneable
    {
        #region 唯一标示
        private string _id;
        /// <summary>
        /// Tag的唯一ID
        /// </summary>
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        #endregion

        #region 定位区域
        private int _x = 0;
        /// <summary>
        /// 横坐标点
        /// </summary>
        public int X
        {
            get { return _x ; }
            set { _x =value; }
        }

        private int _y = 0;
        /// <summary>
        /// 纵坐标点
        /// </summary>
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        private int _width = 0;
        /// <summary>
        /// 文字及边框区域宽度
        /// </summary>
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        private int _height = 0;
        /// <summary>
        /// 文字及边框区域高度
        /// </summary>
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        private float _realX;
        /// <summary>
        /// 真正打印的其实横坐标
        /// 
        /// 在打印的过程中会有一些局部的位置调整，这些调整都是跟属性相关的
        /// 所以设置此属性
        /// </summary>
        public float RealX
        {
            get { return _realX; }
            set { _realX = value; }
        }

        private float _realY;
        /// <summary>
        /// 真正打印的其实纵坐标
        /// </summary>
        public float RealY
        {
            get { return _realY; }
            set { _realY = value; }
        }
        #endregion

        #region 边框背景
        private string _borderStyle = "Solid";
        /// <summary>
        /// 区域边线的风格
        /// </summary>
        public string BorderStyle
        {
            get { return _borderStyle; }
            set { _borderStyle = value; }
        }

        private float _borderWidth = 0.5f;
        /// <summary>
        /// 边沿线宽度
        /// </summary>
        public float BorderWidth
        {
            get { return _borderWidth; }
            set { _borderWidth = value; }
        }

        private string _borderColor = "#FFFFFF";
        /// <summary>
        /// 区域边线绘画时的颜色
        /// </summary>
        public string BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; }
        }

        private string _backgroundStyle = "None";
        /// <summary>
        /// 区域背景的风格
        /// </summary>
        public string BackgroundStyle
        {
            get { return _backgroundStyle; }
            set { _backgroundStyle = value; }
        }

        private string _backgroundColor = "#FFFFFF";
        /// <summary>
        /// 背景的填充颜色
        /// </summary>
        public string BackgroundColor
        {
            get { return _backgroundColor; }
            set { _backgroundColor = value; }
        }

        private string _backgroundShape = "Rectangle";
        /// <summary>
        /// 背景形状
        /// </summary>
        public string BackgroundShape
        {
            get { return _backgroundShape; }
            set { _backgroundShape = value; }
        }
        #endregion

        #region  字体属性
        private string _value=string.Empty;
        /// <summary>
        /// Label上具体显示的文字
        /// </summary>
        public string Value
        {
            get { return _value;  }
            set { _value = value; }
        }

        private string _alignment = "Default";
        /// <summary>
        /// 排列方向
        /// </summary>
        public string Alignment
        {
            get { return _alignment; }
            set { _alignment = value; }
        }

        private string _fontFamilyName = "宋体";
        /// <summary>
        /// 字体名称
        /// </summary>
        public string FontFamilyName
        {
            get { return _fontFamilyName; }
            set { _fontFamilyName = value; }
        }

        private float _fontSize;
        /// <summary>
        /// 字体大小
        /// </summary>
        public float FontSize
        {
            get { return _fontSize; }
            set { _fontSize = value; }
        }

        private string _fontDisplayFormat = "AutoSize";
        /// <summary>
        /// 字体如何去显示
        /// </summary>
        public string FontDisplayFormat
        {
            get { return _fontDisplayFormat; }
            set { _fontDisplayFormat = value; }
        }

        private int _fontStyle = 0;
        /* 
            Regular普通文本。
            Bold加粗文本。
            Italic倾斜文本。
            Underline带下划线的文本。
            Strikeout中间有直线通过的文本。 
         */
        /// <summary>
        /// 指定应用到文本的字形信息。
        /// </summary>
        public int FontStyle
        {
            get { return _fontStyle; }
            set { _fontStyle = value; }
        }

        private string _fontColor = "#000000";
        /// <summary>
        /// 字体颜色
        /// </summary>
        public string FontColor
        {
            get { return _fontColor; }
            set { _fontColor = value; }
        }

        private int _viewFormat = 0;
        /// <summary>
        /// 格式化字符串
        /// </summary>
        public int ViewFormat
        {
            get { return _viewFormat; }
            set { _viewFormat = value; }
        }
        #endregion

        #region  图片信息
        private string _imageMode = "1";
        /// <summary>
        /// 图片打印时存在的方式
        /// </summary>
        public string ImageMode
        {
            get { return _imageMode; }
            set { _imageMode = value; }
        }

        private string _src = string.Empty;
        //图像路径
        public string Src
        {
            get { return _src; }
            set { _src = value; }
        }

        private System.Drawing.Image _imgPrint;
        /// <summary>
        /// 需要打印的最终Image图片
        /// </summary>
        public System.Drawing.Image ImgPrint
        {
            get { return _imgPrint; }
            set { _imgPrint = value; }
        }
        #endregion

        #region 构造函数
        public AojPrintPropertySystem() { }
        protected AojPrintPropertySystem(AojPrintPropertySystem propertySystem)
        {
            lock (new object())
            {
                this._id = propertySystem.Id;
                this._x = propertySystem.X;
                this._y = propertySystem.Y;
                this._realX = propertySystem.RealX;
                this._realY = propertySystem.RealY;
                this._width = propertySystem.Width;
                this._height = propertySystem.Height;
                this._backgroundColor = propertySystem.BackgroundColor;
                this._backgroundShape = propertySystem.BackgroundShape;
                this._backgroundStyle = propertySystem.BackgroundStyle;
                this._borderColor = propertySystem.BorderColor;
                this._borderStyle = propertySystem.BorderStyle;
                this._borderWidth = propertySystem.BorderWidth;
                this._fontColor = propertySystem.FontColor;
                this._fontDisplayFormat = propertySystem.FontDisplayFormat;
                this._fontFamilyName = propertySystem.FontFamilyName;
                this._fontSize = propertySystem.FontSize;
                this._fontStyle = propertySystem.FontStyle;
                this._src = propertySystem.Src;
                this._imgPrint = propertySystem.ImgPrint;
                this._imageMode = propertySystem.ImageMode;
                this._alignment = propertySystem.Alignment;
                this._value = propertySystem.Value;
                this._viewFormat = propertySystem._viewFormat;
            }
        }
        #endregion

        #region 方法封装
        /// <summary>
        /// 获取绘制字体的信息
        /// </summary>
        /// <param name="familyName">字体名称</param>
        /// <param name="emSize">字体大小</param>
        /// <param name="style">字体风格，如粗体，下划线等</param>
        /// <returns></returns>
        public virtual Font GetFont()
        {
            //字体中的style项可以多项相与出现
            try
            {
                FontStyle fontStyle = AojUnitConvert.GetEnumType<FontStyle,int>(this._fontStyle);
                Font f = new Font(this._fontFamilyName, this._fontSize, fontStyle);
                return f;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 定义用于绘制直线和曲线的对象
        /// </summary>
        /// <returns></returns>
        public virtual Pen GetPen()
        {
            BorderType Style =AojUnitConvert.GetEnumType<BorderType,string>(this._borderStyle);
            Pen p = new Pen(AojGrapicsHelper.GetColor(this.BorderColor), this.BorderWidth);
            p.Width = this._borderWidth;
            //笔画的风格设置
            switch (Style)
            {
                case BorderType.Solid:
                    {
                        p.DashStyle = DashStyle.Solid;
                    }
                    break;
                case BorderType.Dot:
                    {
                        p.DashStyle = DashStyle.Dot;
                    }
                    break;
                case BorderType.DashDotDot:
                    {
                        p.DashStyle = DashStyle.DashDotDot;
                    }
                    break;
                case BorderType.DashDot:
                    {
                        p.DashStyle = DashStyle.DashDot;
                    }
                    break;
                case BorderType.Dash:
                    {
                        p.DashStyle = DashStyle.Dash;
                    }
                    break;
                case BorderType.None:
                default:
                    {
                        return null;
                    }
                    break;
            }

            return p;
        }

        #endregion

        #region ICloneable Members

        public object Clone()
        {
            AojPrintPropertySystem propertySystem = new AojPrintPropertySystem(this);
            return propertySystem;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            this.Dispose();
            GC.Collect();
        }

        #endregion
    }
}
