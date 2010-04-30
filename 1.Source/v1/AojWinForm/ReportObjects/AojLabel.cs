#region 翱捷报表软件
/**********************************************
 * 版权：Copyright @2009 翱捷报表
 * 
 * 
 * 描述：报表绘制对象的文本工具(Label)
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
    /// 报表绘制对象的文本工具(Label)
    /// </summary>
    public class AojLabel : AojReportObject
    {
        #region Constructor(构造函数)

        /// <summary>
        /// Constructor(构造函数)
        /// </summary>
        public AojLabel() { }

        /// <summary>
        /// Constructor(构造函数)
        /// </summary>
        /// <param name="name">文本框命名</param>
        /// <param name="value">文本框中的初始值</param>
        /// <param name="x">坐标X</param>s
        /// <param name="y">坐标Y</param>
        /// <param name="width">文本框的宽度</param>
        /// <param name="height">文本框的高度</param>
        public AojLabel(string name, string value, Single x, Single y, Single width, Single height)
        {
            //文本框命名
            this.Name = name;
            //文本框中的显示文本
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

        #endregion

        #region Property(属性)

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
            if (this.IsMouseDownFlag)
            {
                g.DrawRectangle(Pens.Black, recf.X, recf.Y, recf.Width, recf.Height);
            }
            g.DrawString(this.Text, this.TextFont, brush, recf, this.ObjectStringFormat);
            brush.Dispose();
        }

        /// <summary>
        /// 将对象保存进xml文档中
        /// </summary>
        public override XmlNode SaveToXMl()
        {
            AojXmlHelper xmlHelper = new AojXmlHelper();
            xmlHelper.objXmlDoc.LoadXml("<Label></Label>");
            Dictionary<string, string> dicObjectParentSetting = this.GetObjectParentSetting();
            xmlHelper.InsertAttribute("Label", dicObjectParentSetting);
            Dictionary<string, string> dicObjectChildSetting = this.GetObjectChildSetting();
            xmlHelper.InsertNode("Label", "Text", this.Text, dicObjectChildSetting);
            return xmlHelper.objXmlDoc.SelectSingleNode("Label");
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
                this.GetStringAlignmentFormat(objNode.Attributes["Alignment"].Value);
                #endregion

                #region 子对象相关属性
                XmlNode xmlChildNode = objNode.SelectSingleNode("Text");
                this.TextFamilyName = xmlChildNode.Attributes["FamilyName"].Value;
                this.TextFontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), xmlChildNode.Attributes["FontStyle"].Value);
                this.TextFontSize = float.Parse(xmlChildNode.Attributes["FontSize"].Value);
                this.TextColor = ColorTranslator.FromHtml(xmlChildNode.Attributes["Color"].Value);
                this.Text = xmlChildNode.InnerText;
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
            dicObjectSetting.Add("Alignment", this.ObjectStringFormat.Alignment.ToString() + this.ObjectStringFormat.LineAlignment.ToString());
            return dicObjectSetting;
        }

        /// <summary>
        /// 获得子对象的相关属性集合
        /// </summary>
        /// <param name="drawWorkSpace">指定的工作区域</param>
        /// <returns>对象的相关属性集合</returns>
        private Dictionary<string, string> GetObjectChildSetting()
        {
            Dictionary<string, string> dicObjectSetting = new Dictionary<string, string>();
            dicObjectSetting.Add("FamilyName", this.TextFamilyName);
            dicObjectSetting.Add("FontStyle", this.TextFontStyle.ToString());
            dicObjectSetting.Add("FontSize", (this.TextFontSize / this.ObjectCurrentPagesizePercent).ToString());
            dicObjectSetting.Add("Color", ColorTranslator.ToHtml(this.TextColor));
            return dicObjectSetting;
        }

        /// <summary>
        /// 根据指定的格式字符串获得文本格式
        /// </summary>
        /// <param name="strAlignmentFormat">根据指定的格式字符串</param>
        private void GetStringAlignmentFormat(string strAlignmentFormat)
        {
            if (!string.IsNullOrEmpty(strAlignmentFormat))
            {
                if (char.IsUpper(strAlignmentFormat,0))
                {
                    int endIndex = 0;
                    for (int index = 1; index < strAlignmentFormat.Length; index++)
                    {
                        if (char.IsUpper(strAlignmentFormat,index))
                        {
                            endIndex = index;
                            break;
                        }
                    }
                    string strAlignment = strAlignmentFormat.Substring(0, endIndex);
                    string strLineAlignment = strAlignmentFormat.Substring(endIndex);                    
                    this.ObjectAlignment = (StringAlignment)Enum.Parse(typeof(StringAlignment), strAlignment);
                    this.ObjectLineAlignment = (StringAlignment)Enum.Parse(typeof(StringAlignment), strLineAlignment);
                }
            }
        }

        #endregion

        #endregion
    }
}
