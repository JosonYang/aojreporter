#region 翱捷报表软件
/**********************************************
 * 版权：Copyright @2009 翱捷报表
 * 
 * 
 * 描述：报表绘制对象的表格工具(Table)
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
using System.ComponentModel;
using System.Xml;
using AojReport.AojWinForm.Common;

namespace AojReport.AojWinForm.ReportObjects
{
    /// <summary>
    /// 报表绘制对象的表格工具(Table)
    /// </summary>
    public class AojTable : AojReportObject
    {
        #region Constructor(构造函数)

        /// <summary>
        /// Constructor(构造函数)
        /// </summary>
        public AojTable() { }

        /// <summary>
        /// Constructor(构造函数)
        /// </summary>
        /// <param name="name">表格命名</param>
        /// <param name="value">表格的初始值</param>
        /// <param name="x">坐标X</param>s
        /// <param name="y">坐标Y</param>
        /// <param name="width">表格的宽度</param>
        /// <param name="height">表格的高度</param>
        public AojTable(string name, string value, Single x, Single y, Single width, Single height)
        {
            //表格命名
            this.Name = name;
            //表格中的显示文本
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

        //表格的网格数据结构对象
        private CellDocument myDocument = new CellDocument();

        #endregion

        #region Property(属性)

        /// <summary>
        /// 表格的网格数据结构对象
        /// </summary>
        [Category("AojReport")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("表格的网格数据结构对象")]
        public CellDocument MyDocument
        {
            get
            {
                return this.myDocument;
            }
            set
            {
                this.myDocument = value;
            }
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
            RectangleF recf = GetObjectRectangle(this.ObjectRectangle);

            #region 绘制初始化操作
            //计算当前表格的行数
            int intRowCount = this.MyDocument.RowCollection.Count;
            //计算当前表格的列数（每行的列数是一样的）
            int intCellCount = this.MyDocument.ColumnCollection.Count;

            #region 定义表格单元格的相关信息
            Cell objectCell;
            float cellLeft = 0;
            float cellTop = recf.Top;
            #endregion

            foreach (Row rowItem in this.myDocument.RowCollection.Values) 
            {
                cellLeft = recf.Left;
                int columnIndex = 0;
                foreach (Column columnItem in this.myDocument.ColumnCollection.Values)
                {
                    objectCell = rowItem[columnIndex];

                    #region 单元格的宽一
                    objectCell.Width = recf.Width * columnItem.ColumnRatio;
                    #endregion

                    #region 单元格的高一
                    objectCell.Height = recf.Height * rowItem.RowRatio;
                    #endregion

                    objectCell.Left = cellLeft;
                    objectCell.Top = cellTop;
                    columnItem.ColumnWidth = objectCell.Width;
                    cellLeft += objectCell.Width;
                    ++columnIndex;
                }

                objectCell = rowItem[0];
                rowItem.RowHeight = objectCell.Height;
                cellTop += objectCell.Height;
            }

            #endregion

            //绘制表结构时候的边框线宽
            Single BW = 1;

            #region 绘制网格的画笔
            Color intGridColor = Color.Black;
            //绘制网格的画笔对象
            Pen GridPen = null;
            if (intGridColor.A != 0)
            {
                GridPen = new Pen(intGridColor, BW);
            }
            #endregion

            #region 填充网格的画刷
            Color intGridBackColor = Color.White;
            //填充网格的画刷对象
            SolidBrush GridBrush = null;
            if (intGridBackColor.A != 0)
            {
                GridBrush = new SolidBrush(intGridBackColor);
            }
            #endregion

            //绘制文本的画刷对象
            SolidBrush TextBrush = new SolidBrush(Color.Black);

            #region 绘制的详细过程
            foreach (Row rowInfo in myDocument.RowCollection.Values)
            {
                foreach (Cell cell in rowInfo)
                {
                    //绘制文本的画刷对象
                    TextBrush = new SolidBrush(cell.TextColor);

                    //遍历所有表格行的单元格对象,对单元格进行逐个绘制
                    RectangleF bounds = cell.Bounds;

                    if (cell.Selected)
                    {
                        //若单元格处于选择状态则显示高亮度背景色
                        g.FillRectangle(SystemBrushes.Highlight, bounds);
                    }
                    else
                    {
                        //绘制单元格背景
                        if (GridBrush != null)
                        {
                            g.FillRectangle(GridBrush, bounds);
                        }
                    }
                    if (GridPen != null)
                    {
                        //绘制单元格边框
                        g.DrawRectangle(GridPen, cell.Left, cell.Top, cell.Width, cell.Height);
                    }
                    if (cell.Text != null)
                    {
                        //绘制单元格文本
                        g.DrawString(
                            cell.Text,
                            cell.TextFont,
                            cell.Selected ? SystemBrushes.HighlightText : TextBrush,
                            new RectangleF(
                            cell.Left,
                            cell.Top,
                            cell.Width,
                            cell.Height),
                            cell.ObjectStringFormat);
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// 将对象保存进xml文档中
        /// </summary>
        public override XmlNode SaveToXMl()
        {
            AojXmlHelper xmlHelper = new AojXmlHelper();
            xmlHelper.objXmlDoc.LoadXml("<Table></Table>");
            Dictionary<string, string> dicObjectParentSetting = this.GetObjectParentSetting();
            xmlHelper.InsertAttribute("Table", dicObjectParentSetting);
            XmlNode rootNode = xmlHelper.objXmlDoc.SelectSingleNode("Table");
            this.InsertChildNode(xmlHelper, rootNode);
            return rootNode;
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

                XmlNodeList lstColumn = objNode.SelectNodes("Column");
                XmlNodeList lstRow = objNode.SelectNodes("Row");

                if (lstColumn != null && lstRow != null)
                {
                    int columnCount = lstColumn.Count;
                    int rowCount = lstRow.Count;
                    if (columnCount > 0 && rowCount > 0)
                    {
                        Column colItem;
                        Row rowItem;
                        XmlNodeList lstChildNode;
                        Cell cellItem;
                        XmlNode childCellNode;

                        this.myDocument = new CellDocument(true);

                        #region 表格列
                        foreach (XmlNode nodeColumnItem in lstColumn)
                        {
                            colItem = new Column();
                            colItem.ColumnID = nodeColumnItem.Attributes["Id"].Value;
                            colItem.ColumnWidth = float.Parse(nodeColumnItem.Attributes["Width"].Value);
                            this.myDocument.AddColumn(colItem.ColumnID, colItem);

                            #region 表格行
                            foreach (XmlNode nodeRowItem in lstRow)
                            {
                                lstChildNode = nodeRowItem.SelectNodes("Cell");
                                if (lstChildNode != null && lstChildNode.Count > 0)
                                {
                                    if (columnCount == lstChildNode.Count)
                                    {
                                        rowItem = new Row();
                                        rowItem.RowID = nodeRowItem.Attributes["Id"].Value;
                                        rowItem.RowHeight = float.Parse(nodeRowItem.Attributes["Height"].Value);
                                        this.myDocument.AddRow(rowItem.RowID, rowItem);

                                        rowItem.Clear();

                                        #region 单元格
                                        foreach (XmlNode nodeCellItem in lstChildNode)
                                        {
                                            cellItem = new Cell();
                                            cellItem.ColumnID = colItem.ColumnID;
                                            cellItem.RowID = rowItem.RowID;
                                            cellItem.Width = colItem.ColumnWidth;
                                            cellItem.Height = rowItem.RowHeight;
                                            childCellNode = nodeCellItem.SelectSingleNode("Text");
                                            if (childCellNode != null)
                                            {
                                                cellItem.TextFamilyName = childCellNode.Attributes["FamilyName"].Value;
                                                cellItem.TextFontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), childCellNode.Attributes["FontStyle"].Value);
                                                cellItem.TextFontSize = float.Parse(childCellNode.Attributes["FontSize"].Value);
                                                cellItem.TextColor = ColorTranslator.FromHtml(childCellNode.Attributes["Color"].Value);
                                                cellItem.Text = childCellNode.InnerText;
                                                this.SetStringAlignmentFormat(cellItem, childCellNode.Attributes["Alignment"].Value);
                                            }
                                            rowItem.Add(cellItem);
                                        }
                                        #endregion
                                    }
                                }
                            }
                            #endregion
                        }
                        #endregion
                    }
                }

                //设置表格中每列的比例
                this.SetColumnRatioInfo();
                //设置表格中每行的比例
                this.SetRowRatioInfo();
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
            this.Left /= this.ObjectCurrentPagesizePercent;
            dicObjectSetting.Add("PositionX", this.Left.ToString());
            this.Top /= this.ObjectCurrentPagesizePercent;
            dicObjectSetting.Add("PositionY", this.Top.ToString());
            this.Width /= this.ObjectCurrentPagesizePercent;
            dicObjectSetting.Add("Width", this.Width.ToString());
            this.Height /= this.ObjectCurrentPagesizePercent;
            dicObjectSetting.Add("Height", this.Height.ToString());
            return dicObjectSetting;
        }

        /// <summary>
       /// <summary>
        /// 为节点插入子节点，包含内容，属性
        /// </summary>
        /// <param name="xmlHelper">XMl文档操作类</param>
        /// <param name="objParentNode">父节点</param>
        /// <param name="objNode">子节点</param>
        private void InsertChildNode(AojXmlHelper xmlHelper, XmlNode objParentNode)
        {
            #region 相关定义
            XmlElement xmlColumnElement;
            XmlAttribute xmlColumnAttribute;
            XmlElement xmlRowElement;
            XmlAttribute xmlRowAttribute;
            XmlElement xmlCellElement;
            XmlAttribute xmlCellAttribute;
            XmlElement xmlCellTextElement;
            XmlAttribute xmlCellTextAttribute;
            #endregion

            #region 表格列
            Column colInfo;
            foreach (string item in this.myDocument.ColumnCollection.Keys)
            {
                colInfo = this.myDocument.ColumnCollection[item];
                xmlColumnElement = xmlHelper.objXmlDoc.CreateElement("Column");
                xmlColumnAttribute = xmlHelper.objXmlDoc.CreateAttribute("Id");
                xmlColumnAttribute.Value = colInfo.ColumnID;
                xmlColumnElement.Attributes.Append(xmlColumnAttribute);
                xmlColumnAttribute = xmlHelper.objXmlDoc.CreateAttribute("Width");
                xmlColumnAttribute.Value = (this.Width * colInfo.ColumnRatio).ToString();
                xmlColumnElement.Attributes.Append(xmlColumnAttribute);
                objParentNode.AppendChild(xmlColumnElement);
            }
            #endregion

            #region 表格行
            Row rowInfo;
            foreach (string item in this.myDocument.RowCollection.Keys)
            {
                #region 表格行的相关属性
                rowInfo = this.myDocument.RowCollection[item];
                xmlRowElement = xmlHelper.objXmlDoc.CreateElement("Row");
                xmlRowAttribute = xmlHelper.objXmlDoc.CreateAttribute("Id");
                xmlRowAttribute.Value = rowInfo.RowID;
                xmlRowElement.Attributes.Append(xmlRowAttribute);
                xmlRowAttribute = xmlHelper.objXmlDoc.CreateAttribute("Height");
                xmlRowAttribute.Value = (this.Height * rowInfo.RowRatio).ToString();
                xmlRowElement.Attributes.Append(xmlRowAttribute);
                objParentNode.AppendChild(xmlRowElement);
                #endregion

                #region 单元格
                Cell cellInfo;
                for (int index = 0; index < this.myDocument.ColumnCollection.Count; index++)
                {
                    cellInfo = rowInfo[index];
                    xmlCellElement = xmlHelper.objXmlDoc.CreateElement("Cell");
                    xmlCellAttribute = xmlHelper.objXmlDoc.CreateAttribute("Id");
                    xmlCellAttribute.Value = cellInfo.CellID;
                    xmlCellElement.Attributes.Append(xmlCellAttribute);

                    #region 文本
                    xmlCellTextElement = xmlHelper.objXmlDoc.CreateElement("Text");

                    xmlCellTextAttribute = xmlHelper.objXmlDoc.CreateAttribute("FamilyName");
                    xmlCellTextAttribute.Value = cellInfo.TextFamilyName;
                    xmlCellTextElement.Attributes.Append(xmlCellTextAttribute);

                    xmlCellTextAttribute = xmlHelper.objXmlDoc.CreateAttribute("FontStyle");
                    xmlCellTextAttribute.Value = cellInfo.TextFontStyle.ToString();
                    xmlCellTextElement.Attributes.Append(xmlCellTextAttribute);

                    xmlCellTextAttribute = xmlHelper.objXmlDoc.CreateAttribute("FontSize");
                    xmlCellTextAttribute.Value = cellInfo.TextFontSize.ToString();
                    xmlCellTextElement.Attributes.Append(xmlCellTextAttribute);

                    xmlCellTextAttribute = xmlHelper.objXmlDoc.CreateAttribute("Color");
                    xmlCellTextAttribute.Value = ColorTranslator.ToHtml(cellInfo.TextColor);
                    xmlCellTextElement.Attributes.Append(xmlCellTextAttribute);

                    xmlCellTextAttribute = xmlHelper.objXmlDoc.CreateAttribute("Alignment");
                    xmlCellTextAttribute.Value = cellInfo.ObjectStringFormat.Alignment.ToString() + cellInfo.ObjectStringFormat.LineAlignment.ToString();
                    xmlCellTextElement.Attributes.Append(xmlCellTextAttribute);

                    if (!string.IsNullOrEmpty(cellInfo.Text))
                    {
                        xmlCellTextElement.InnerText = cellInfo.Text;
                    }

                    xmlCellElement.AppendChild(xmlCellTextElement);
                    #endregion

                    xmlRowElement.AppendChild(xmlCellElement);
                }
                #endregion
            }
            #endregion
        }

        /// <summary>
        /// 根据指定的格式字符串设置文本格式
        /// </summary>
        /// <param name="cellInfo">指定的表格单元格</param>
        /// <param name="strAlignmentFormat">根据指定的格式字符串</param>
        private void SetStringAlignmentFormat(Cell cellInfo, string strAlignmentFormat)
        {
            if (!string.IsNullOrEmpty(strAlignmentFormat))
            {
                if (char.IsUpper(strAlignmentFormat, 0))
                {
                    int endIndex = 0;
                    for (int index = 1; index < strAlignmentFormat.Length; index++)
                    {
                        if (char.IsUpper(strAlignmentFormat, index))
                        {
                            endIndex = index;
                            break;
                        }
                    }
                    string strAlignment = strAlignmentFormat.Substring(0, endIndex);
                    string strLineAlignment = strAlignmentFormat.Substring(endIndex);
                    cellInfo.ObjectAlignment = (StringAlignment)Enum.Parse(typeof(StringAlignment), strAlignment);
                    cellInfo.ObjectLineAlignment = (StringAlignment)Enum.Parse(typeof(StringAlignment), strLineAlignment);
                }
            }
        }

        /// <summary>
        /// 设置表格中每行的比例
        /// </summary>
        private void SetRowRatioInfo()
        {
            float currentTableHeight = this.Height;
            Row rowItem;
            foreach (string strRowId in this.MyDocument.RowCollection.Keys)
            {
                rowItem = this.MyDocument.RowCollection[strRowId];
                rowItem.RowRatio = rowItem.RowHeight / currentTableHeight;
            }
        }

        /// <summary>
        /// 设置表格中每列的比例
        /// </summary>
        private void SetColumnRatioInfo()
        {
            float currentTableWidth = this.Width;
            Column colItem;
            foreach (string strColId in this.MyDocument.ColumnCollection.Keys)
            {
                colItem = this.MyDocument.ColumnCollection[strColId];
                colItem.ColumnRatio = colItem.ColumnWidth / currentTableWidth;
            }
        }

        #endregion

        #endregion
    }

    /// <summary>
    /// 单元格对象
    /// </summary>
    public class Cell
    {
        //获取或设置显示文本的字体名称
        private string textFamilyName = "宋体";

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

        //获取或设置文本的字体大小
        private float textFontSize = 12;

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

        //获取或设置显示文本的字体风格
        private FontStyle textFontStyle = FontStyle.Regular;

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

        //获取或设置显示文本颜色
        private Color textColor = Color.Black;

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

        //获取或设置垂直面上的文本对齐信息。
        private StringAlignment objectAlignment = StringAlignment.Center;

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

        //获取或设置水平面上的行对齐信息。
        private StringAlignment objectLineAlignment = StringAlignment.Center;

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

        //获取显示文本的对齐方式
        private StringFormat objectStringFormat = new StringFormat();

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
        /// 单元格对象名称
        /// </summary>
        public string CellID
        {
            get { return this.strColumnID + this.strRowID; }
        }

        private string strText = string.Empty;

        /// <summary>
        /// 单元格文本
        /// </summary>
        public string Text
        {
            get { return strText; }
            set { strText = value; }
        }

        private bool bolSelected = false;

        /// <summary>
        /// 单元格选择标志
        /// </summary>
        public bool Selected
        {
            get { return bolSelected; }
            set { bolSelected = value; }
        }

        private Single intLeft = 0;

        /// <summary>
        /// 单元格左端位置
        /// </summary>
        public Single Left
        {
            get { return intLeft; }
            set { this.intLeft = value; }
        }

        private Single intTop = 0;

        /// <summary>
        /// 单元格顶端位置
        /// </summary>
        public Single Top
        {
            get { return intTop; }
            set { this.intTop = value; }
        }

        private Single intWidth = 0;

        /// <summary>
        /// 单元格宽度
        /// </summary>
        public Single Width
        {
            get { return intWidth; }
            set { this.intWidth = value; }
        }

        private Single intHeight = 0;

        /// <summary>
        /// 单元格高度
        /// </summary>
        public Single Height
        {
            get { return intHeight; }
            set { this.intHeight = value; }
        }

        /// <summary>
        /// 对象边界
        /// </summary>
        public System.Drawing.RectangleF Bounds
        {
            get { return new System.Drawing.RectangleF(intLeft, intTop, intWidth, intHeight); }
        }

        private string strRowID = string.Empty;

        /// <summary>
        /// 表格行纵项目名称
        /// </summary>
        public string RowID
        {
            get { return this.strRowID; }
            set { this.strRowID = value; }
        }

        private string strColumnID = string.Empty;

        /// <summary>
        /// 表格列横项目名称
        /// </summary>
        public string ColumnID
        {
            get { return this.strColumnID; }
            set { this.strColumnID = value; }
        }

        private string strAlias = string.Empty;

        /// <summary>
        /// 单元格的别名
        /// </summary>
        public string Alias
        {
            get { return this.strAlias; }
            set { this.strAlias = value; }
        }
    }

    /// <summary>
    /// 表格行对象
    /// </summary>
    public class Row : System.Collections.CollectionBase
    {
        /// <summary>
        /// 获得指定序号的单元格对象
        /// </summary>
        public Cell this[int index]
        {
            get { return (Cell)this.List[index]; }
        }

        /// <summary>
        /// 添加单元格对象
        /// </summary>
        /// <param name="cell">单元格对象</param>
        public void Add(Cell cell)
        {
            this.List.Add(cell);
        }

        /// <summary>
        /// 添加单元格对象
        /// </summary>
        /// <param name="text">新增的单元格文本</param>
        /// <returns>新增的单元格对象</returns>
        public Cell Add(string text)
        {
            Cell cell = new Cell();
            cell.Text = text;
            this.List.Add(cell);
            return cell;
        }

        private Single intRowHeight = 0;

        /// <summary>
        /// 表格行高度
        /// </summary>
        public Single RowHeight
        {
            get { return this.intRowHeight; }
            set { this.intRowHeight = value; }
        }

        private string strRowID = string.Empty;

        /// <summary>
        /// 表格行纵项目名称
        /// </summary>
        public string RowID
        {
            get { return this.strRowID; }
            set { this.strRowID = value; }
        }

        private Single intRowRatio = 0.5F;

        /// <summary>
        /// 表格行高度比率
        /// </summary>
        public Single RowRatio
        {
            get { return this.intRowRatio; }
            set { this.intRowRatio = value; }
        }
    }

    /// <summary>
    /// 表格列对象
    /// </summary>
    public class Column
    {
        private Single intColumnWidth = 0;

        /// <summary>
        /// 表格列宽度
        /// </summary>
        public Single ColumnWidth
        {
            get { return this.intColumnWidth; }
            set { this.intColumnWidth = value; }
        }

        private string strColumnID = string.Empty;

        /// <summary>
        /// 表格列横项目名称
        /// </summary>
        public string ColumnID
        {
            get { return this.strColumnID; }
            set { this.strColumnID = value; }
        }

        private Single intColumnRatio = 0.5F;

        /// <summary>
        /// 表格行宽度比率
        /// </summary>
        public Single ColumnRatio
        {
            get { return this.intColumnRatio; }
            set { this.intColumnRatio = value; }
        }
    }

    /// <summary>
    /// 网格数据结构对象
    /// </summary>
    public class CellDocument
    {
        #region Constructor(构造函数)

        /// <summary>
        /// Constructor(构造函数)
        /// </summary>
        public CellDocument()
        {
            //初始化网格数据结构对象操作
            this.InitializeTableCellDocument();
        }

        /// <summary>
        /// Constructor(构造函数)
        /// </summary>
        public CellDocument(bool bNullFlag)
        {

        }

        #endregion

        //表格行对象集合
        private Dictionary<string, Row> dicRowCollection = new Dictionary<string, Row>();

        /// <summary>
        /// 表格行对象集合
        /// </summary>
        public Dictionary<string, Row> RowCollection
        {
            get { return this.dicRowCollection; }
            set { this.dicRowCollection = value; }
        }

        //表格列对象集合
        private Dictionary<string, Column> dicColumnCollection = new Dictionary<string, Column>();

        /// <summary>
        /// 表格列对象集合
        /// </summary>
        public Dictionary<string, Column> ColumnCollection
        {
            get { return this.dicColumnCollection; }
            set { this.dicColumnCollection = value; }
        }

        /// <summary>
        /// 添加表格列
        /// </summary>
        /// <param name="strColumnID">表格列横项目名称</param>
        /// <param name="column">新增的表格列对象</param>
        public void AddColumn(string strColumnID, Column column)
        {
            if (!this.dicColumnCollection.ContainsKey(strColumnID))
            {
                this.dicColumnCollection.Add(strColumnID, column);
                //给每行添加相关的单元格
                this.DoBusinessAboutAddColumn(column);
            }
        }

        /// <summary>
        /// 删除表格列
        /// </summary>
        /// <param name="strColumnID">表格列横项目名称</param>
        public void DeleteColumn(string strColumnID)
        {
            if (this.dicColumnCollection.ContainsKey(strColumnID))
            {
                this.dicColumnCollection.Remove(strColumnID);
            }
        }

        /// <summary>
        /// 添加表格行
        /// </summary>
        /// <param name="strRowID">表格行纵项目名称</param>
        /// <param name="row">新增的表格行对象</param>
        public void AddRow(string strRowID, Row row)
        {
            if (!this.dicRowCollection.ContainsKey(strRowID))
            {
                this.dicRowCollection.Add(strRowID, row);
                //给每列添加相关的单元格
                this.DoBusinessAboutAddRow(row);
            }
        }

        /// <summary>
        /// 删除表格行
        /// </summary>
        /// <param name="strRowID">表格行纵项目名称</param>
        public void DeleteRow(string strRowID)
        {
            if (this.dicRowCollection.ContainsKey(strRowID))
            {
                this.dicRowCollection.Remove(strRowID);
            }
        }

        /// <summary>
        /// 获得指定序号的表格行对象
        /// </summary>
        /// <param name="strRowID">表格行纵项目名称</param>
        /// <returns>表格行对象</returns>
        public Row GetRowByID(string strRowID)
        {
            if (this.dicRowCollection.ContainsKey(strRowID))
            {
                return this.dicRowCollection[strRowID];
            }
            return null;
        }

        /// <summary>
        /// 获得指定序号的表格列对象
        /// </summary>
        /// <param name="strColumnID">表格列横项目名称</param>
        /// <returns>表格列对象</returns>
        public Column GetColumnByID(string strColumnID)
        {
            if (this.dicColumnCollection.ContainsKey(strColumnID))
            {
                return this.dicColumnCollection[strColumnID];
            }
            return null;
        }

        /// <summary>
        /// 添加表格行时候,给每列添加相关的单元格
        /// </summary>
        /// <param name="row">新增的表格行对象</param>
        private void DoBusinessAboutAddRow(Row row)
        {
            Cell cellItem;
            Column colInfo;
            foreach (string item in this.dicColumnCollection.Keys)
            {
                colInfo = this.dicColumnCollection[item];
                cellItem = new Cell();
                cellItem.RowID = row.RowID;
                cellItem.ColumnID = colInfo.ColumnID;
                row.Add(cellItem);
            }
        }

        /// <summary>
        /// 添加表格列的时候,给每行添加相关的单元格
        /// </summary>
        /// <param name="column">新增的表格列对象</param>
        private void DoBusinessAboutAddColumn(Column column)
        {
            Cell cellItem;
            foreach (Row rowItem in this.dicRowCollection.Values)
            {
                cellItem = new Cell();
                cellItem.RowID = rowItem.RowID;
                cellItem.ColumnID = column.ColumnID;
                rowItem.Add(cellItem);
            }
        }

        /// <summary>
        /// 初始化网格数据结构对象操作
        /// </summary>
        private void InitializeTableCellDocument()
        {
            #region 绘制表结构时候的初始化操作

            Row rowItem = new Row();
            rowItem.RowID = "h1";
            rowItem.RowRatio = 0.5f;
            this.AddRow("h1", rowItem);
            rowItem = new Row();
            rowItem.RowID = "h2";
            rowItem.RowRatio = 0.5f;
            this.AddRow("h2", rowItem);

            Column colItem = new Column();
            colItem.ColumnID = "w1";
            colItem.ColumnRatio = 0.5f;
            this.AddColumn("w1", colItem);
            colItem = new Column();
            colItem.ColumnID = "w2";
            colItem.ColumnRatio = 0.5f;
            this.AddColumn("w2", colItem);

            #endregion
        }
    }
}
