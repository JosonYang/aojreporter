#region 翱捷报表软件
/**********************************************
 * 版权：Copyright @2009 翱捷报表
 * 
 * 
 * 描述：报表绘制对象的图像工具(Image)
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
using System.Xml;
using System.ComponentModel;
using AojReport.AojWinForm.Common;

namespace AojReport.AojWinForm.ReportObjects
{
    /// <summary>
    /// 报表绘制对象的图像工具(Image)
    /// </summary>
    public class AojImage : AojReportObject
    {
        #region Constructor(构造函数)

        /// <summary>
        /// Constructor(构造函数)
        /// </summary>
        public AojImage() { }

        /// <summary>
        /// Constructor(构造函数)
        /// </summary>
        /// <param name="name">图像命名</param>
        /// <param name="value">图像的初始值</param>
        /// <param name="x">坐标X</param>s
        /// <param name="y">坐标Y</param>
        /// <param name="width">图像的宽度</param>
        /// <param name="height">图像的高度</param>
        public AojImage(string name, string value, Single x, Single y, Single width, Single height)
        {
            //图像命名
            this.Name = name;
            //图像的显示文本
            this.Text = value;

            #region 对象的边界区域范围
            this.Left = x;
            this.Top = y;
            this.Width = width;
            this.Height = height;
            #endregion
        }

        #endregion

        #region Field(变量)

        //图像的图片地址
        private string strImagePath = string.Empty;

        #endregion

        #region Property(属性)

        /// <summary>
        /// 获取或设置图像的图片地址
        /// </summary>
        [Category("AojReport")]
        [Description("获取或设置图像的图片地址")]
        public string ImagePath
        {
            get { return this.strImagePath; }
            set { this.strImagePath = value; }
        }

        #endregion

        #region Method(方法)

        #region Override(继承重写)

        /// <summary>
        /// 对象的绘制
        /// </summary>
        /// <param name="g">对象的绘制载体</param>
        public override void DesignDraw(Graphics g)
        {
            Brush brush = new SolidBrush(this.TextColor);
            RectangleF recf = GetObjectRectangle(this.ObjectRectangle);
            if (this.IsMouseDownFlag || !this.Selected)
            {
                g.DrawRectangle(Pens.Black, recf.X, recf.Y, recf.Width, recf.Height);
            }
            Image newImage = new Bitmap(10, 10);
            g.DrawImage(newImage, recf);
            brush.Dispose();
        }

        /// <summary>
        /// 将对象保存进xml文档中
        /// </summary>
        public override XmlNode SaveToXMl()
        {
            AojXmlHelper xmlHelper = new AojXmlHelper();
            xmlHelper.objXmlDoc.LoadXml("<Image></Image>");
            Dictionary<string, string> dicObjectParentSetting = this.GetObjectParentSetting();
            xmlHelper.InsertAttribute("Image", dicObjectParentSetting);
            Dictionary<string, string> dicObjectChildSetting = this.GetObjectChildSetting();
            xmlHelper.InsertNode("Image", "Text", null, dicObjectChildSetting);
            return xmlHelper.objXmlDoc.SelectSingleNode("Image");
        }

        /// <summary>
        /// 从xml文档中获得对象
        /// </summary>
        public override void OpenFormXML(XmlNode objNode)
        {
            if (objNode != null)
            {
                #region 对象的相关属性
                this.Name = objNode.Attributes["Id"].Value;
                this.Left = float.Parse(objNode.Attributes["PositionX"].Value);
                this.Top = float.Parse(objNode.Attributes["PositionY"].Value);
                this.Width = float.Parse(objNode.Attributes["Width"].Value);
                this.Height = float.Parse(objNode.Attributes["Height"].Value);
                #endregion

                #region 子对象相关属性
                XmlNode xmlChildNode = objNode.SelectSingleNode("Text");
                this.ImagePath = xmlChildNode.Attributes["Src"].Value;
                #endregion
            }
        }

        #endregion

        #region private(私有方法)

        /// <summary>
        /// 获得对象的相关属性集合
        /// </summary>
        /// <param name="drawWorkSpace">指定的工作区域</param>
        /// <returns>对象的相关属性集合</returns>
        private Dictionary<string, string> GetObjectParentSetting()
        {
            Dictionary<string, string> dicObjectSetting = new Dictionary<string, string>();
            dicObjectSetting.Add("Id", this.Name);
            dicObjectSetting.Add("PositionX", (this.Left / this.ObjectCurrentPagesizePercent).ToString());
            dicObjectSetting.Add("PositionY", (this.Top / this.ObjectCurrentPagesizePercent).ToString());
            dicObjectSetting.Add("Width", (this.Width / this.ObjectCurrentPagesizePercent).ToString());
            dicObjectSetting.Add("Height", (this.Height / this.ObjectCurrentPagesizePercent).ToString());
            return dicObjectSetting;
        }

        /// <summary>
        /// 获得对象的相关属性集合
        /// </summary>
        /// <param name="drawWorkSpace">指定的工作区域</param>
        /// <returns>对象的相关属性集合</returns>
        private Dictionary<string, string> GetObjectChildSetting()
        {
            Dictionary<string, string> dicObjectSetting = new Dictionary<string, string>();
            dicObjectSetting.Add("Src", this.ImagePath);
            return dicObjectSetting;
        }

        #endregion

        #endregion
    }
}
