using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Collections;
using AojReport.AojPrintEngine.Common;

namespace AojReport.AojPrintEngine.AojPrintGraphicsParse
{
    internal class AojPrintLabel
        : AojPrintPropertySystem
        , IAojPrintObjectParse
        , ICloneable
    {
        #region 构造函数
        public AojPrintLabel() { }
        protected AojPrintLabel(AojPrintLabel obj)
            : base(obj)
        {

        }
        #endregion

        #region 接口实现
        #region IAojPrintObjectParse Members
        public void Save(XmlWriter writer)
        {
            writer.WriteStartElement("Label");
            writer.WriteAttributeString("Id", this.Id.ToString());
            writer.WriteAttributeString("PositionX", this.X.ToString());
            writer.WriteAttributeString("PositionY", this.Y.ToString());
            writer.WriteAttributeString("Width", this.Width.ToString());
            writer.WriteAttributeString("Height", this.Height.ToString());
            writer.WriteAttributeString("BorderStyle", this.BorderStyle);
            writer.WriteAttributeString("BorderWidth", this.BorderWidth.ToString());
            writer.WriteAttributeString("BorderColor", this.BorderColor);
            writer.WriteAttributeString("BackStyle", this.BackgroundStyle);
            writer.WriteAttributeString("BackColor", this.BackgroundColor);
            writer.WriteAttributeString("Shape", this.BackgroundShape);
            writer.WriteAttributeString("Alignment", this.Alignment);
            writer.WriteAttributeString("Format", this.FontDisplayFormat);

            writer.WriteStartElement("Text");
            writer.WriteAttributeString("Name", this.FontFamilyName);
            writer.WriteAttributeString("Size", this.FontSize.ToString());
            writer.WriteAttributeString("Style", this.FontStyle.ToString());
            writer.WriteAttributeString("Color", this.FontColor);
            writer.WriteAttributeString("ViewFormat", this.ViewFormat.ToString());
            writer.WriteString(this.Value);
            writer.WriteEndElement();

            writer.WriteEndElement();
        }

        public bool Parse(AojPrintXmlReader aojXmlReader)
        {
            //对传进来的读取器包含的Label属性进行赋值
            Hashtable hstLabel = aojXmlReader.Attributes;
            this.Id = AojUnitConvert.SafeToString(hstLabel, "Id", "LabelGroup");
            this.X = AojUnitConvert.SafeToInt(hstLabel, "PositionX", 0);
            this.Y = AojUnitConvert.SafeToInt(hstLabel, "PositionY", 0);
            this.Width = AojUnitConvert.SafeToInt(hstLabel, "Width", 0);
            this.Height = AojUnitConvert.SafeToInt(hstLabel, "Height", 0);

            this.BorderStyle = AojUnitConvert.SafeToString(hstLabel, "BorderStyle", this.BorderStyle);
            this.BorderWidth = AojUnitConvert.SafeToSingle(hstLabel, "BorderWidth", this.BorderWidth);
            this.BorderColor = AojUnitConvert.SafeToString(hstLabel, "BorderColor", this.BorderColor);
            this.BackgroundStyle = AojUnitConvert.SafeToString(hstLabel, "BackStyle", this.BackgroundStyle);
            this.BackgroundColor = AojUnitConvert.SafeToString(hstLabel, "BackColor", this.BackgroundColor);
            this.BackgroundShape = AojUnitConvert.SafeToString(hstLabel, "Shape", this.BackgroundShape);

            this.Alignment = AojUnitConvert.SafeToString(hstLabel, "Alignment", this.Alignment);
            this.FontDisplayFormat = AojUnitConvert.SafeToString(hstLabel, "Format", this.FontDisplayFormat);
            while (aojXmlReader.Read())
            {
                //碰到结束节点说明，本Label的Tag已经读取结束
                if (aojXmlReader.IsEndElement("Label"))
                {
                    break;
                }
                switch (aojXmlReader.TagType)
                {
                    //读取Label节点下的文本内容
                    case XmlNodeType.Text:
                        {
                            this.Value = aojXmlReader.TagContent;
                        }
                        break;
                    //读取Label节点下的子节点下的属性
                    //Label下面的Tag有:
                    //      Text
                    case XmlNodeType.Element:
                        {
                            if (aojXmlReader.TagName == "Text")
                            {
                                Hashtable hstFont = aojXmlReader.Attributes;
                                this.FontFamilyName = AojUnitConvert.SafeToString(hstFont, "Name", this.FontFamilyName);
                                this.FontSize = AojUnitConvert.SafeToSingle(hstFont, "Size", this.FontSize);
                                this.FontStyle = AojUnitConvert.SafeToInt(hstFont, "Style", this.FontStyle);
                                this.FontColor = AojUnitConvert.SafeToString(hstFont, "Color", this.FontColor);
                                this.ViewFormat = AojUnitConvert.SafeToInt(hstFont, "ViewFormat", this.ViewFormat);
                            }
                        }
                        break;
                }
            }
            return true;
        }

        public void Print(Graphics g)
        {
            //描绘文本的打印
            /*
             * 首先描绘区域，然后根据区域描绘字符
             */
            //绘制区域
            AojGrapicsHelper.DrawRectangle(g, this);
            //绘制文字
            AojGrapicsHelper.DrawString(g, this);
        }
        #endregion
        #endregion

        #region ICloneable Members

        object ICloneable.Clone()
        {
            AojPrintLabel aojprintLabel = new AojPrintLabel(this);
            return aojprintLabel;
        }

        #endregion
    }
}
