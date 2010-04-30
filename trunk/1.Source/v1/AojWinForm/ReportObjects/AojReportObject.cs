#region 翱捷报表软件
/**********************************************
 * 版权：Copyright @2009 翱捷报表
 * 
 * 
 * 描述：各种对象的基本属性
 * 
 * 
 * 日期：
 * 
 **********************************************/
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Xml;

namespace AojReport.AojWinForm.ReportObjects
{
    /// <summary>
    /// 各种对象的基本属性
    /// </summary>
    public class AojReportObject
    {
        #region Constructor(构造函数)

        /// <summary>
        /// Constructor(构造函数)
        /// </summarys
        public AojReportObject() { }

        #endregion

        #region Field(变量)

        //获取或设置对象名称
        private string strName = string.Empty;
        //获取或设置显示文本
        private string strText = string.Empty;
        //获取或设置显示文本的字体名称
        private string textFamilyName = "宋体";
        //获取或设置文本的字体大小
        private float textFontSize = 12;
        //获取或设置显示文本的字体风格
        private FontStyle textFontStyle = FontStyle.Regular;
        //获取或设置显示文本颜色
        private Color textColor = Color.Black;
        //获取或设置垂直面上的文本对齐信息。
        private StringAlignment objectAlignment = StringAlignment.Center;
        //获取或设置水平面上的行对齐信息。
        private StringAlignment objectLineAlignment = StringAlignment.Center;
        //获取显示文本的对齐方式
        private StringFormat objectStringFormat = new StringFormat();
        //获取或设置对象是否被选择
        private bool bIsSelected = false;
        //对象选中时候的几个正方形菱角的宽
        private float aojTrackerOutsideWidth = 7f;
        private float aojTrackerInsideWidth = 4f;
        //获取或设置对象的边界区域范围
        private RectangleF _rectangle = new RectangleF();
        //记录当前对象的倍率是多少
        private float aojObjectCurrentPagesizePercent = 1f;
        //记录当前操作对象的是否是MoveDown事件
        private bool isMouseDownFlag = false;

        #endregion

        #region Property(属性)

        /// <summary>
        /// 获取或设置对象名称
        /// </summary>
        [Category("AojReport")]
        [Description("获取或设置对象名称")]
        public string Name
        {
            get
            {
                return strName;
            }
            set
            {
                strName = value;
            }
        }

        /// <summary>
        /// 获取或设置对象文本
        /// </summary>
        [Category("AojReport")]
        [Description("获取或设置对象文本")]
        public string Text
        {
            get { return strText; }
            set { strText = value; }
        }

        /// <summary>
        /// 获取或设置显示文本的字体名称
        /// </summary>
        [Category("AojReport")]
        [Description("获取或设置显示文本的字体名称")]
        public string TextFamilyName
        {
            get { return textFamilyName; }
            set { textFamilyName = value; }
        }

        /// <summary>
        /// 获取或设置文本的字体大小
        /// </summary>
        [Category("AojReport")]
        [Description("获取或设置文本的字体大小")]
        public float TextFontSize
        {
            get { return textFontSize; }
            set { textFontSize = value; }
        }

        /// <summary>
        /// 获取或设置显示文本的字体风格
        /// </summary>
        [Category("AojReport")]
        [Description("获取或设置显示文本的字体风格")]
        public FontStyle TextFontStyle
        {
            get { return textFontStyle; }
            set { textFontStyle = value; }
        }

        /// <summary>
        /// 获取显示文本字体
        /// </summary>
        [Category("AojReport")]
        [Description("获取显示文本字体")]
        public Font TextFont
        {
            get
            {
                return new Font(this.textFamilyName, this.textFontSize, this.textFontStyle);
            }
        }

        /// <summary>
        /// 获取或设置显示文本颜色
        /// </summary>
        [Category("AojReport")]
        [Description("获取或设置显示文本颜色")]
        public Color TextColor
        {
            get
            {
                return textColor;
            }
            set
            {
                textColor = value;
            }
        }

        /// <summary>
        /// 获取或设置对象是否被选择
        /// </summary>
        [Category("AojReport")]
        [Description("获取或设置对象是否被选择")]
        public bool Selected
        {
            get { return bIsSelected; }
            set { bIsSelected = value; }
        }

        /// <summary>
        /// 获取或设置垂直面上的文本对齐信息。
        /// </summary>
        [Category("AojReport")]
        [Description("获取或设置垂直面上的文本对齐信息。")]
        public StringAlignment ObjectAlignment
        {
            get { return objectAlignment; }
            set { objectAlignment = value; }
        }

        /// <summary>
        /// 获取或设置水平面上的行对齐信息。
        /// </summary>
        [Category("AojReport")]
        [Description("获取或设置水平面上的行对齐信息。")]
        public StringAlignment ObjectLineAlignment
        {
            get { return objectLineAlignment; }
            set { objectLineAlignment = value; }
        }

        /// <summary>
        /// 获取显示文本的对齐方式
        /// </summary>
        [Category("AojReport")]
        [Description("获取显示文本的对齐方式")]
        public StringFormat ObjectStringFormat
        {
            get
            {
                objectStringFormat.Alignment = objectAlignment;
                objectStringFormat.LineAlignment = objectLineAlignment;
                return objectStringFormat;
            }
        }

        /// <summary>
        /// 获取对象的边界区域范围
        /// </summary>
        [Category("AojReport")]
        [Description("获取或设置对象的边界区域范围")]
        public RectangleF ObjectRectangle
        {
            get { return this._rectangle; }
        }

        /// <summary>
        /// 获取或设置对象左端位置
        /// </summary>
        [Category("AojReport")]
        [Description("获取或设置对象左端位置")]
        public Single Left
        {
            get { return this._rectangle.X; }
            set { this._rectangle.X = value; }
        }

        /// <summary>
        /// 获取或设置对象顶端位置
        /// </summary>
        [Category("AojReport")]
        [Description("获取或设置对象顶端位置")]
        public Single Top
        {
            get { return this._rectangle.Y; }
            set { this._rectangle.Y = value; }
        }

        /// <summary>
        /// 获取或设置对象宽度
        /// </summary>
        [Category("AojReport")]
        [Description("获取或设置对象宽度")]
        public Single Width
        {
            get { return this._rectangle.Width; }
            set { this._rectangle.Width = value; }
        }

        /// <summary>
        /// 获取或设置对象高度
        /// </summary>
        [Category("AojReport")]
        [Description("获取或设置对象高度")]
        public Single Height
        {
            get { return this._rectangle.Height; }
            set { this._rectangle.Height = value; }
        }

        /// <summary>
        /// 对象选中时候的几个正方形菱角的宽
        /// </summary>
        [Category("AojReport")]
        [DefaultValue(7f)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("对象选中时候的几个正方形菱角的宽")]
        public float TrackerOutsideWidth
        {
            get { return this.aojTrackerOutsideWidth; }
            set { this.aojTrackerOutsideWidth = value; }
        }

        /// <summary>
        /// 对象选中时候的几个正方形菱角的宽
        /// </summary>
        [Category("AojReport")]
        [DefaultValue(4f)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("对象选中时候的几个正方形菱角的宽")]
        public float TrackerInsideWidth
        {
            get { return this.aojTrackerInsideWidth; }
            set { this.aojTrackerInsideWidth = value; }
        }

        /// <summary>
        /// 记录当前对象的倍率是多少
        /// </summary>
        [Category("AojReport")]
        [DefaultValue(1f)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("记录当前对象的倍率是多少")]
        public float ObjectCurrentPagesizePercent
        {
            get { return this.aojObjectCurrentPagesizePercent; }
            set 
            {
                this.aojObjectCurrentPagesizePercent = value;
            }
        }

        /// <summary>
        /// 记录当前操作对象的是否是MoveDown事件
        /// </summary>
        [Category("AojReport")]
        [DefaultValue(false)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("记录当前操作对象的是否是MoveDown事件")]
        public bool IsMouseDownFlag
        {
            get { return isMouseDownFlag; }
            set { isMouseDownFlag = value; }
        }

        #endregion

        #region Method(方法)
        
        #region Virtual(虚拟方法)

        /// <summary>
        /// 对象的绘制
        /// </summary>
        /// <param name="g">对象的绘制载体</param>
        public virtual void DesignDraw(Graphics g)
        {
            
        }

        /// <summary>
        /// 绘制对象选中时候的显示效果
        /// </summary>
        /// <param name="g">对象的绘制载体</param>
        public virtual void DrawTracker(Graphics g)
        {
            if (!this.Selected)
            {
                return;
            }
            SolidBrush brush = new SolidBrush(Color.Black);
            RectangleF tempInfo;
            for (int index = 1; index <= 8; index++)
            {
                tempInfo = GetHandleRectangle(index);
                tempInfo.X -= (tempInfo.Width / 2);
                tempInfo.Y -= (tempInfo.Height / 2);
                g.DrawRectangle(Pens.Black, tempInfo.X, tempInfo.Y, tempInfo.Width, tempInfo.Height);
                g.FillRectangle(brush, tempInfo.X + (tempInfo.Width - aojTrackerInsideWidth) / 2, tempInfo.Y + (tempInfo.Height - aojTrackerInsideWidth) / 2, aojTrackerInsideWidth, aojTrackerInsideWidth);
            }
            brush.Dispose();
        }

        /// <summary>
        /// 设置对象的范围
        /// </summary>
        /// <param name="x">坐标X</param>
        /// <param name="y">坐标Y</param>
        /// <param name="width">对象的宽</param>
        /// <param name="height">对象的高</param>
        public virtual void SetRectangle(Single x, Single y, Single width, Single height)
        {
            this._rectangle.X = x;
            this._rectangle.Y = y;
            this._rectangle.Width = width;
            this._rectangle.Height = height;
        }

        /// <summary>
        /// 获得对象的边界区域范围
        /// </summary>
        /// <param name="r">区域范围</param>
        /// <returns>对象的边界区域范围</returns>
        public virtual RectangleF GetObjectRectangle(RectangleF r)
        {
            return GetObjectRectangle(r.X, r.Y, r.X + r.Width, r.Y + r.Height);
        }

        /// <summary>
        /// 获得对象的边界区域范围
        /// </summary>
        /// <param name="x1">对象的左横坐标</param>
        /// <param name="y1">对象的上纵坐标</param>
        /// <param name="x2">对象的右上横坐标</param>
        /// <param name="y2">对象的下纵坐标</param>
        /// <returns>对象的边界区域范围</returns>
        public virtual RectangleF GetObjectRectangle(Single x1, Single y1, Single x2, Single y2)
        {
            Single tempData;
            if (x2 < x1)
            {
                tempData = x2;
                x2 = x1;
                x1 = tempData;
            }
            if (y2 < y1)
            {
                tempData = y2;
                y2 = y1;
                y1 = tempData;
            }
            return new RectangleF(x1, y1, x2 - x1, y2 - y1);
        }

        /// <summary>
        /// 获得对象的边界区域范围
        /// </summary>
        /// <param name="p1">对象的开始点</param>
        /// <param name="p2">对象的结束点</param>
        /// <returns>对象的边界区域范围</returns>
        public virtual RectangleF GetObjectRectangle(PointF p1, PointF p2)
        {
            return GetObjectRectangle(p1.X, p1.Y, p2.X, p2.Y);
        }

        /// <summary>
        /// 获得对象上的指定部分操作区域的范围
        /// </summary>
        /// <param name="handleNumber">指定操作对象上的具体区域</param>
        /// <returns>对象上的指定部分操作区域的范围</returns>
        public virtual PointF GetHandle(int handleNumber)
        {
            Single x;
            Single y;
            Single xCenter;
            Single yCenter;
            x = this._rectangle.X;
            y = this._rectangle.Y;
            xCenter = this._rectangle.X + this._rectangle.Width / 2;
            yCenter = _rectangle.Y + this._rectangle.Height / 2;

            switch (handleNumber)
            {
                case 1:
                    x = this._rectangle.X;
                    y = this._rectangle.Y;
                    break;
                case 2:
                    x = xCenter;
                    y = this._rectangle.Y;
                    break;
                case 3:
                    x = this._rectangle.Right;
                    y = this._rectangle.Y;
                    break;
                case 4:
                    x = this._rectangle.Right;
                    y = yCenter;
                    break;
                case 5:
                    x = this._rectangle.Right;
                    y = this._rectangle.Bottom;
                    break;
                case 6:
                    x = xCenter;
                    y = this._rectangle.Bottom;
                    break;
                case 7:
                    x = this._rectangle.X;
                    y = this._rectangle.Bottom;
                    break;
                case 8:
                    x = this._rectangle.X;
                    y = yCenter;
                    break;
                default:
                    break;
            }

            return new PointF(x, y);
        }

        /// <summary>
        /// 将指定的对象进行拖动操作
        /// </summary>
        /// <param name="pointf">区域范围</param>
        /// <param name="handleNumber">指定的部位</param>
        public virtual void MoveHandleTo(PointF pointf, int handleNumber)
        {
            Single left = this._rectangle.Left;
            Single top = this._rectangle.Top;
            Single right = this._rectangle.Right;
            Single bottom = this._rectangle.Bottom;

            switch (handleNumber)
            {
                case 1:
                    left = pointf.X;
                    top = pointf.Y;
                    break;
                case 2:
                    top = pointf.Y;
                    break;
                case 3:
                    right = pointf.X;
                    top = pointf.Y;
                    break;
                case 4:
                    right = pointf.X;
                    break;
                case 5:
                    right = pointf.X;
                    bottom = pointf.Y;
                    break;
                case 6:
                    bottom = pointf.Y;
                    break;
                case 7:
                    left = pointf.X;
                    bottom = pointf.Y;
                    break;
                case 8:
                    left = pointf.X;
                    break;
                default:
                    break;
            }
            SetRectangle(left, top, right - left, bottom - top);
        }

        /// <summary>
        /// 获得指定操作对象上的具体区域的范围
        /// </summary>
        /// <param name="handleNumber">指定操作对象上的具体区域</param>
        /// <returns>指定操作对象上的具体区域的范围</returns>
        public virtual RectangleF GetHandleRectangle(int handleNumber)
        {
            PointF pointf = GetHandle(handleNumber);

            return new RectangleF(pointf.X - 1, pointf.Y - 1, aojTrackerOutsideWidth, aojTrackerOutsideWidth);
        }

        /// <summary>
        /// 获得对象上的指定坐标的具体区域
        /// </summary>
        /// <param name="pointf">指定坐标</param>
        /// <returns>对象上的指定坐标的具体区域</returns>
        public virtual int GetHandleNumberByPoint(PointF pointf)
        {
            if (Selected)
            {
                for (int index = 1; index <= 8; index++)
                {
                    if (GetHandleRectangle(index).Contains(pointf))
                    {
                        return index;
                    }
                }
            }

            if (PointInObject(pointf))
            {
                return 0;
            }

            return -1;
        }

        /// <summary>
        /// 判断当前指定的坐标是否在对象中
        /// </summary>
        /// <param name="pointf">指定坐标</param>
        /// <returns>存在:True  不存在:Falses</returns>
        public virtual bool PointInObject(PointF pointf)
        {
            return this._rectangle.Contains(pointf);
        }

        /// <summary>
        /// 获得操作指定对象的特定区域时的鼠标指针状态
        /// </summary>
        /// <param name="handleNumber">指定操作对象上的具体区域</param>
        /// <returns>鼠标指针状态</returns>
        public virtual Cursor GetHandleCursor(int handleNumber)
        {
            switch (handleNumber)
            {
                case 1:
                    return Cursors.SizeNWSE;
                case 2:
                    return Cursors.SizeNS;
                case 3:
                    return Cursors.SizeNESW;
                case 4:
                    return Cursors.SizeWE;
                case 5:
                    return Cursors.SizeNWSE;
                case 6:
                    return Cursors.SizeNS;
                case 7:
                    return Cursors.SizeNESW;
                case 8:
                    return Cursors.SizeWE;
                default:
                    return Cursors.Default;
            }
        }

        /// <summary>
        /// 将对象进行拖动操作
        /// </summary>
        /// <param name="x">坐标X</param>
        /// <param name="y">坐标Y</param>
        public virtual void Move(Single x, Single y)
        {
            this._rectangle.X += x;
            this._rectangle.Y += y;
        }

        /// <summary>
        /// 将对象的设计区域进行正常化
        /// </summary>
        public virtual void Normalize()
        {
            this._rectangle = this.GetObjectRectangle(_rectangle);
        }

        /// <summary>
        /// 判断给定的区域中是否有对象与之相交
        /// </summary>
        /// <param name="rectanglef">给定的区域</param>
        /// <returns>有:True 无:False</returns>
        public virtual bool IntersectsWith(RectangleF rectanglef)
        {
            return this._rectangle.IntersectsWith(rectanglef);
        }

        /// <summary>
        /// 将对象保存进xml文档中
        /// </summary>
        public virtual XmlNode SaveToXMl()
        {
            return null;
        }

        /// <summary>
        /// 从xml文档中获得对象
        /// </summary>
        public virtual void OpenFormXML(XmlNode objNode)
        {

        }

        #endregion

        #region private(私有方法)
      
        #endregion

        #endregion       
    }
}
