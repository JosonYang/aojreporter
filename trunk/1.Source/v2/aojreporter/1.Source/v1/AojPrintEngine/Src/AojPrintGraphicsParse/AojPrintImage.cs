using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Drawing;
using System.Collections;
using AojReport.AojPrintEngine.Common;

namespace AojReport.AojPrintEngine.AojPrintGraphicsParse
{
    internal class AojPrintImage
        :AojPrintPropertySystem,IAojPrintObjectParse,ICloneable
    {
        public AojPrintImage() { }
        protected AojPrintImage(AojPrintImage obj)
            : base(obj)
        { }
        #region IAojPrintObjectParse Members
        public void Save(XmlWriter writer)
        {
            writer.WriteStartElement("Image");
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

            writer.WriteStartElement("Text");
            writer.WriteAttributeString("Style", this.ImageMode);
            switch (AojUnitConvert.GetEnumType<ImageFlags,string>(this.ImageMode))
            {
                case ImageFlags.File:
                    {
                        writer.WriteAttributeString("Src", this.Src);
                    }
                    break;
                case ImageFlags.Cache:
                    {
                        writer.WriteString(this.Value);
                    }
                    break;
            }
            writer.WriteEndElement();

            writer.WriteEndElement();
        }

        public bool Parse(AojPrintXmlReader aojXmlReader)
        {
            #region 属性的读取
            //对传进来的读取器包含的Image属性进行赋值
            Hashtable hstImage = aojXmlReader.Attributes;
            this.Id = AojUnitConvert.SafeToString(hstImage, "Id", "ImageGroup");
            this.X = AojUnitConvert.SafeToInt(hstImage, "PositionX", 0);
            this.Y = AojUnitConvert.SafeToInt(hstImage, "PositionY", 0);
            this.Width = AojUnitConvert.SafeToInt(hstImage, "Width", 0);
            this.Height = AojUnitConvert.SafeToInt(hstImage, "Height", 0);

            this.BorderStyle = AojUnitConvert.SafeToString(hstImage, "BorderStyle", this.BorderStyle);
            this.BorderWidth = AojUnitConvert.SafeToSingle(hstImage, "BorderWidth", this.BorderWidth);
            this.BorderColor = AojUnitConvert.SafeToString(hstImage, "BorderColor", this.BorderColor);
            this.BackgroundStyle = AojUnitConvert.SafeToString(hstImage, "BackStyle", this.BackgroundStyle);
            this.BackgroundColor = AojUnitConvert.SafeToString(hstImage, "BackColor", this.BackgroundColor);
            this.BackgroundShape = AojUnitConvert.SafeToString(hstImage, "Shape", this.BackgroundShape);

            this.ImageMode = AojUnitConvert.SafeToString(hstImage, "ImageMode", this.ImageMode);
            #endregion

            //图片存在形式是，文件路径还是base64格式的字符串
            ImageFlags imageFlags = AojUnitConvert.GetEnumType<ImageFlags,string>(this.ImageMode);

            #region 读取Base64编码的图片字符串或图片物理路径
            while (aojXmlReader.Read())
            {
                //读到Image结束节点后退出该循环
                if (aojXmlReader.IsEndElement("Image"))
                {
                    break;
                }

                switch (aojXmlReader.TagType)
                {
                    case XmlNodeType.Text:
                        {
                            //存储的图片字符串
                            this.Value = aojXmlReader.TagContent;
                        }
                        break;
                    case XmlNodeType.Element:
                        {
                             if (aojXmlReader.TagName == "Text")
                             {
                                 //存储的文件路径
                                 Hashtable hstText = aojXmlReader.Attributes;
                                 //读取路径，无效则为空
                                 this.Src = AojUnitConvert.SafeToString(hstText, "Src",string.Empty);
                             }
                        }
                        break;
                }
            }
            #endregion

            #region 读取图片并生成图片

            switch (imageFlags)
            {
                case ImageFlags.Cache:
                    {
                        //文件中Base64的存储模式
                        this.ImgPrint = AojUnitConvert.ImageFromBase64String(aojXmlReader.TagContent);
                    }
                    break;
                case ImageFlags.File:
                    {
                        //从Src中的读取图片
                        this.ImgPrint = AojUnitConvert.ImageFromFile(this.Src);
                    }
                    break;
                default:
                    {
                        this.ImgPrint = null;
                    }
                    break;
            }

            #endregion

            return true;
        }

        public void Print(Graphics g)
        {
            //绘制边框
            AojGrapicsHelper.DrawRectangle(g, this);
            //填充图像
            AojGrapicsHelper.DrawImage(g, this);
        }

        #endregion

        #region ICloneable Members

        object ICloneable.Clone()
        {
            AojPrintImage aojPrintImage = new AojPrintImage(this);
            return aojPrintImage;
        }

        #endregion
    }
}
