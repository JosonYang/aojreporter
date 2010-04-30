using System;
using System.Collections.Generic;
using System.Text;
using AojReport.AojPrintEngine.Common;
using System.Collections;
using System.Xml;

namespace AojReport.AojPrintEngine.AojPrintGraphicsParse
{
    internal partial class AojPrintTable
    {
        internal sealed class Cell : AojPrintPropertySystem, IAojPrintObjectParse, ICloneable
        {
            #region 属性定义
            private int _colSpan = 1;
            /// <summary>
            /// 合并单元格数
            /// </summary>
            public int ColSpan
            {
                get { return _colSpan; }
                set { _colSpan = value; }
            }

            private int _currentRow = 0;
            /// <summary>
            /// 当前所在行
            /// </summary>
            public int CurrentRow
            {
                get { return _currentRow; }
                set { _currentRow = value; }
            }

            private int _currentColumn = 0;
            /// <summary>
            /// 当前所在列
            /// </summary>
            public int CurrentColumn
            {
                get { return _currentColumn; }
                set { _currentColumn = value; }
            }
            #endregion

            #region  构造函数
            public Cell() { }
            protected Cell(Cell obj)
                : base(obj)
            {
                this._colSpan = obj.ColSpan;
                this._currentColumn = obj.CurrentColumn;
                this._currentRow = obj.CurrentRow;
            }
            #endregion

            #region IAojPrintObjectParse Members

            public void Save(XmlWriter writer)
            {
                writer.WriteStartElement("Cell");
                writer.WriteAttributeString("Id", this.Id.ToString());
                writer.WriteAttributeString("ColSpan", this.ColSpan.ToString());
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
                #region  对传进来的读取器包含的Cell属性进行赋值
                //对传进来的读取器包含的Cell属性进行赋值
                Hashtable hstCell = aojXmlReader.Attributes;
                this.Id = AojUnitConvert.SafeToString(hstCell, "Id", "CellGroup");
                this.X = AojUnitConvert.SafeToInt(hstCell, "PositionX", 0);
                this.Y = AojUnitConvert.SafeToInt(hstCell, "PositionY", 0);
                this.Width = AojUnitConvert.SafeToInt(hstCell, "Width", 0);
                this.Height = AojUnitConvert.SafeToInt(hstCell, "Height", 0);

                this.ColSpan = AojUnitConvert.SafeToInt(hstCell, "ColSpan", 1);

                this.BorderStyle = AojUnitConvert.SafeToString(hstCell, "BorderStyle", this.BorderStyle);
                this.BorderWidth = AojUnitConvert.SafeToSingle(hstCell, "BorderWidth", this.BorderWidth);
                this.BorderColor = AojUnitConvert.SafeToString(hstCell, "BorderColor", this.BorderColor);
                this.BackgroundStyle = AojUnitConvert.SafeToString(hstCell, "BackStyle", this.BackgroundStyle);
                this.BackgroundColor = AojUnitConvert.SafeToString(hstCell, "BackColor", this.BackgroundColor);
                this.BackgroundShape = AojUnitConvert.SafeToString(hstCell, "Shape", this.BackgroundShape);

                this.Alignment = AojUnitConvert.SafeToString(hstCell, "Alignment", this.Alignment);
                this.FontDisplayFormat = AojUnitConvert.SafeToString(hstCell, "Format", this.FontDisplayFormat);
                #endregion

                while (aojXmlReader.Read())
                {
                    //碰到结束节点说明，本Cell的Tag已经读取结束
                    if (aojXmlReader.IsEndElement("Cell"))
                    {
                        break;
                    }
                    switch (aojXmlReader.TagType)
                    {
                        //读取Cell节点下的文本内容
                        case XmlNodeType.Text:
                            {
                                this.Value = aojXmlReader.TagContent;
                            }
                            break;
                        //读取Cell节点下的子节点下的属性
                        //Cell下面的Tag有:
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

            public void Print(System.Drawing.Graphics g)
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

            #region ICloneable Members

            public object Clone()
            {
                Cell cell = new Cell(this);
                return cell;
            }

            #endregion
        }
    }
}
