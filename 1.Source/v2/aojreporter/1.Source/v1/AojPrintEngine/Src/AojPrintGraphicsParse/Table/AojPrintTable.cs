using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Drawing;
using System.Collections;
using AojReport.AojPrintEngine.Common;

namespace AojReport.AojPrintEngine.AojPrintGraphicsParse
{
    internal partial class AojPrintTable :AojPrintPropertySystem, IAojPrintObjectParse ,ICloneable
    {
        public List<Cell> Cells;
        public List<Column> Columns;
        public List<Row> Rows;

        private int _nCurrentX = 0;
        private int _nCurrentY = 0;

        public AojPrintTable() {
            Cells = new List<Cell>();
            Columns = new List<Column>();
            Rows = new List<Row>();
        }

        protected AojPrintTable(AojPrintTable obj)
            : base(obj)
        {
            Cells = new List<Cell>();
            Columns = new List<Column>();
            Rows = new List<Row>();

            foreach (Cell o in obj.Cells)
            {
                this.Cells.Add((Cell)o.Clone());
            }
            foreach (Row r in obj.Rows)
            {
                this.Rows.Add((Row)r.Clone());
            }
            foreach (Column col in obj.Columns)
            {
                this.Columns.Add((Column)col.Clone());
            }
        }

        #region IAojPrintObjectParse Members
        public void Save(XmlWriter writer)
        {
            writer.WriteStartElement("Table");
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

            foreach (Column col in this.Columns)
            {
                writer.WriteStartElement("Column");
                writer.WriteAttributeString("Id", col.Id);
                writer.WriteAttributeString("Width", col.Width.ToString());
                writer.WriteEndElement();
            }

            foreach (Row r in this.Rows)
            {
                writer.WriteStartElement("Row");
                writer.WriteAttributeString("Height", r.Height.ToString());
                List<Cell> CurrentRowCells = this.GetCurrentRowExistCell(Rows.IndexOf(r));
                foreach(Cell cell in CurrentRowCells)
                {
                    cell.Save(writer);
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        public bool Parse(AojPrintXmlReader aojXmlReader)
        {
            #region 对传进来的读取器包含的Table属性进行赋值
            //对传进来的读取器包含的Table属性进行赋值
            Hashtable hstTable = aojXmlReader.Attributes;
            this.Id = AojUnitConvert.SafeToString(hstTable, "Id", "TableGroup");
            this.X = AojUnitConvert.SafeToInt(hstTable, "PositionX", 0);
            this.Y = AojUnitConvert.SafeToInt(hstTable, "PositionY", 0);
            this.Width = AojUnitConvert.SafeToInt(hstTable, "Width", 0);
            this.Height = AojUnitConvert.SafeToInt(hstTable, "Height", 0);

            _nCurrentX = this.X;
            _nCurrentY = this.Y;

            this.BorderStyle = AojUnitConvert.SafeToString(hstTable, "BorderStyle", this.BorderStyle);
            this.BorderWidth = AojUnitConvert.SafeToSingle(hstTable, "BorderWidth", this.BorderWidth);
            this.BorderColor = AojUnitConvert.SafeToString(hstTable, "BorderColor", this.BorderColor);
            this.BackgroundStyle = AojUnitConvert.SafeToString(hstTable, "BackStyle", this.BackgroundStyle);
            this.BackgroundColor = AojUnitConvert.SafeToString(hstTable, "BackColor", this.BackgroundColor);

            #endregion

            /**
             * 需要区分行列的情况
             * 表对象的格式指定是
             * 表名.列名.行名
             * 如：G1.c1.r2
             */
            while (aojXmlReader.Read())
            {
                if (aojXmlReader.IsEndElement("Table"))
                {
                    break;
                }
                switch (aojXmlReader.TagName)
                {
                    case "Column":
                        {
                            //读取列信息
                            _parseColumn(aojXmlReader);
                        }
                        break;
                    case "Row":
                        {
                            //读取行信息
                            _parseRow(aojXmlReader);
                            //横轴复位
                            _nCurrentX = this.X;
                        }
                        break;
                }
            }
            this._validateCell();
            return true;
        }

        public void Print(Graphics g)
        {
            //绘制Table区域
            AojGrapicsHelper.DrawRectangle(g, this);

            foreach (object obj in this.Cells)
            {
                if (obj is IAojPrintObjectParse)
                {
                    /**
                     * 本DLL类所有可绘画对象均继承基础接口IAojPrintObjectParse
                     * 这个类中定义了读写格式文件和打印所需要的方法。
                     * 
                     */
                    ((IAojPrintObjectParse)obj).Print(g);
                }
            }
        }
        #endregion

        #region 私有方法
        private void _parseRow(AojPrintXmlReader _aojXmlReader)
        {
            Row r = new Row();
            Hashtable hstRow = _aojXmlReader.Attributes;
            r.Height = AojUnitConvert.SafeToInt(hstRow, "Height", 0);
            this.Rows.Add(r);

            //当前某行的单元格起始index
            int _cellStart = 0;
            
            while (_aojXmlReader.Read())
            {
                 //碰到结束节点说明，本Label的Tag已经读取结束
                if (_aojXmlReader.IsEndElement("Row"))
                {
                    break;
                }
                switch (_aojXmlReader.TagType)
                {
                    case XmlNodeType.Element:
                        {
                            Cell cell = new Cell();
                            //设定当前列
                            cell.CurrentColumn = _cellStart;
                            if (cell.Parse(_aojXmlReader))
                            {
                                cell.X = cell.X != 0 ? cell.X : _nCurrentX;
                                cell.Y = cell.Y != 0 ? cell.Y : _nCurrentY;
                                //设置宽度   考虑组合行的关系
                                //处理表格合并打印
                                //
                                if (cell.ColSpan != 1)
                                {
                                    for (int iIndex = 0; iIndex < cell.ColSpan; iIndex++)
                                    {
                                        //
                                        if (_cellStart + 1 > this.Columns.Count)
                                        {
                                            break;
                                        }
                                        //当前cell的宽度为合并的几个单元格宽度的和
                                        cell.Width += this.Columns[_cellStart].Width;
                                        _cellStart += 1;
                                    }
                                }
                                else
                                {
                                    cell.Width = this.Columns[_cellStart].Width;
                                    _cellStart += 1;
                                }
                                //横坐标根据单元格宽度增长，直到转行（新行）时复位
                                _nCurrentX += cell.Width;
                                //列高
                                cell.Height = r.Height;
                                //当前所在行
                                cell.CurrentRow = this.Rows.Count - 1;
                                this.Cells.Add(cell);
                            }
                            else
                            {
                                cell = null;
                            }
                        }
                        break;
                }
            }
            //当前Row的横坐标
            _nCurrentY += r.Height;
        }
        private void _parseColumn(AojPrintXmlReader _aojXmlReader)
        {
            if (_aojXmlReader.IsEndElement("Column"))
            {
                return;
            }
            Column col = new Column();
            Hashtable hstCol = _aojXmlReader.Attributes;
            col.Id = AojUnitConvert.SafeToString(hstCol, "Id", "ColumnGroup");
            col.Width = AojUnitConvert.SafeToInt(hstCol, "Width", 0);
            this.Columns.Add(col);
        }
        private void _validateCell()
        {
            #region 将Table自动调至最适合长宽
            int width = 0;
            int height = 0;
            //将Table自动调至最适合长宽
            foreach (Row rindex in Rows)
            {
                height += rindex.Height;
            }
            foreach (Column col in Columns)
            {
                width += col.Width;
            }
            this.Width = width;
            this.Height = height;
            #endregion
        }
        /// <summary>
        /// 获取当前行的所有单元格
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public List<Cell> GetCurrentRowExistCell(int rowIndex)
        {
            List<Cell> lstCell = new List<Cell>();
            foreach (Cell cell in Cells)
            {
                if (cell.CurrentRow == rowIndex)
                {
                    lstCell.Add(cell);
                }
            }
            return lstCell;
        }
        #endregion

        #region ICloneable Members

        object ICloneable.Clone()
        {
            AojPrintTable aojPrintTable = new AojPrintTable(this);
            return aojPrintTable;
        }

        #endregion
    }
}
