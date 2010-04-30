#region 翱捷报表软件
/**********************************************
 * 版权：Copyright @2009 翱捷报表
 * 
 * 
 * 描述：对Table属性的相关设置
 * 
 * 
 * 日期：
 * 
 **********************************************/
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using AojReport.AojWinForm.ReportObjects;
using AojReport.AojWinForm.Common;

namespace AojReport.AojWinForm.ObjectProperties
{
    /// <summary>
    /// 对Table属性的相关设置
    /// </summary>
    public partial class AojTableProperties : Form
    {
        #region Constructor(构造函数)

        /// <summary>
        /// Constructor(构造函数)
        /// </summarys
        public AojTableProperties()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor(构造函数)
        /// </summary>
        /// <param name="tbItem">设置的Table对象</param>
        public AojTableProperties(AojTable tbItem)
        {
            InitializeComponent();

            #region 初始化
            DataTable dtAlignmentFormatData = AojCommonFnc.GetAlignmentFormatData();
            this.cmbCellAlignment.DisplayMember = "formatname";
            this.cmbCellAlignment.ValueMember = "formatvalue";
            this.cmbCellAlignment.DataSource = dtAlignmentFormatData;
            DataTable dtLineAlignmentFormatData = AojCommonFnc.GetLineAlignmentFormatData();
            this.cmbCellLineAlignment.DisplayMember = "formatname";
            this.cmbCellLineAlignment.ValueMember = "formatvalue";
            this.cmbCellLineAlignment.DataSource = dtLineAlignmentFormatData;
            #endregion

            this.SetDefaultPropertyValue(tbItem);
        }

        #endregion

        #region Field(变量)

        //要设置相关属性的Table对象
        private AojTable tbObject = null;
        //设置的Table对象的副本
        private AojTable tbTempObject = new AojTable();
        //当前进行操作的表格列
        private Column columnCurrent = null;
        //当前进行操作的表格行
        private Row rowCurrent = null;
        //当前进行操作的单元格
        private Cell cellCurrent = null;
       
        #endregion

        #region Property(属性)

        /// <summary>
        /// 要设置相关属性的Table对象
        /// </summary>
        [Category("AojReport")]
        [Description("要设置相关属性的Table对象")]
        public AojTable TableObject
        {
            get { return tbObject; }
            set { tbObject = value; }
        }
     
        #endregion

        #region Event(事件)

        /// <summary>
        /// 对表格中的列进行选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lisBoxColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            Column columnInfo = (Column)this.lisBoxColumn.SelectedValue;
            this.columnCurrent = columnInfo;

            if (columnInfo != null)
            {
                #region 列
                this.txtColumnName.Text = columnInfo.ColumnID;
                this.txtColumnWidth.Text = columnInfo.ColumnWidth.ToString();
                #endregion
            }
            else
            {
                #region 列
                this.txtColumnName.Text = string.Empty;
                this.txtColumnWidth.Text = string.Empty;
                #endregion
            }
        }

        /// <summary>
        /// 对表格中的行进行选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxRow_SelectedIndexChanged(object sender, EventArgs e)
        {
            Row rowInfo = (Row)this.listBoxRow.SelectedValue;
            this.rowCurrent = rowInfo;
            if (rowInfo != null)
            {
                #region 行
                this.txtRowName.Text = rowInfo.RowID;
                this.txtRowHeight.Text = rowInfo.RowHeight.ToString();
                #endregion

                this.listBoxCell.DisplayMember = "columnname";
                this.listBoxCell.ValueMember = "columnvalue";
                this.listBoxCell.DataSource = this.GetCellData(rowInfo);
            }
            else
            {
                #region 行
                this.txtRowName.Text = string.Empty;
                this.txtRowHeight.Text = string.Empty;
                #endregion

                this.listBoxCell.DataSource = null;
            }
        }

        /// <summary>
        /// 对表格中的单元格进行选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxCell_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cell cellInfo = (Cell)this.listBoxCell.SelectedValue;
            this.cellCurrent = cellInfo;

            if (cellInfo != null)
            {
                #region 单元格
                this.txtCellName.Text = cellInfo.CellID;
                this.txtCellConent.Text = cellInfo.Text;
                this.txtCellFont.Text = cellInfo.TextFont.ToString();
                this.txtCellColor.BackColor = cellInfo.TextColor;
                this.cmbCellAlignment.SelectedValue = cellInfo.ObjectAlignment;
                this.cmbCellLineAlignment.SelectedValue = cellInfo.ObjectLineAlignment;
                #endregion
            }
            else
            {
                #region 单元格
                this.txtCellName.Text = string.Empty;
                this.txtCellConent.Text = string.Empty;
                this.txtCellFont.Text = string.Empty;
                this.txtCellColor.BackColor = Color.Black;
                this.cmbCellAlignment.SelectedIndex = 0;
                this.cmbCellLineAlignment.SelectedIndex = 0;
                #endregion
            }
        }

        /// <summary>
        /// 设置表格单元格的显示内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCellConent_TextChanged(object sender, EventArgs e)
        {
            if (this.cellCurrent != null)
            {
                this.cellCurrent.Text = this.txtCellConent.Text;
            }
        }

        /// <summary>
        /// 进行对象属性的相关设置完毕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.SetPropertyValue();
            this.Close();
        }

        /// <summary>
        /// 取消对属性的相关设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 获取或设置单元格显示文本的字体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCellFont_Click(object sender, EventArgs e)
        {
            if (this.cellCurrent != null)
            {
                this.fontDialogForm.Font = new Font(this.cellCurrent.TextFamilyName, this.cellCurrent.TextFontSize, this.cellCurrent.TextFontStyle);
                if (DialogResult.OK == this.fontDialogForm.ShowDialog())
                {
                    Font textFont = this.fontDialogForm.Font;
                    this.cellCurrent.TextFamilyName = textFont.FontFamily.Name;
                    this.cellCurrent.TextFontSize = textFont.Size;
                    this.cellCurrent.TextFontStyle = textFont.Style;
                    this.txtCellFont.Text = textFont.ToString();
                }
            }
        }

        /// <summary>
        /// 获取或设置单元格显示文本颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCellColor_Click(object sender, EventArgs e)
        {
            if (this.cellCurrent != null)
            {
                this.colorDialogForm.Color = this.cellCurrent.TextColor;
                if (DialogResult.OK == this.colorDialogForm.ShowDialog())
                {
                    this.cellCurrent.TextColor = this.colorDialogForm.Color;
                    this.txtCellColor.BackColor = this.cellCurrent.TextColor;
                }
            }
        }

        /// <summary>
        /// 选择单元格文本对齐的方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCellAlignment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cellCurrent != null)
            {
                this.cellCurrent.ObjectAlignment = (StringAlignment)Enum.Parse(typeof(StringAlignment), this.cmbCellAlignment.SelectedValue.ToString());
            }
        }

        /// <summary>
        /// 选择单元格文本对齐的方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCellLineAlignment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cellCurrent != null)
            {
                this.cellCurrent.ObjectLineAlignment = (StringAlignment)Enum.Parse(typeof(StringAlignment), this.cmbCellLineAlignment.SelectedValue.ToString());
            }
        }

        /// <summary>
        /// 设置表格列的显示名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtColumnName_TextChanged(object sender, EventArgs e)
        {
            if (this.columnCurrent != null)
            {
                this.columnCurrent.ColumnID = this.txtColumnName.Text;
            }
        }

        /// <summary>
        /// 设置表格列的宽度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtColumnWidth_Validated(object sender, EventArgs e)
        {
            if (this.columnCurrent != null)
            {
                float currentWidth = this.columnCurrent.ColumnWidth;
                float objectWidth;
                bool isRightFlag = float.TryParse(this.txtColumnWidth.Text, out objectWidth);
                if (isRightFlag)
                {
                    if (currentWidth != objectWidth)
                    {
                        float increaseValue = objectWidth - currentWidth;
                        this.columnCurrent.ColumnWidth = objectWidth;
                        this.tbTempObject.Width += increaseValue;
                        this.txtTableWidth.Text = this.tbTempObject.Width.ToString();
                        //设置表格中每列的比例
                        this.SetColumnRatioInfo();
                    }
                }
                else
                {
                    this.txtColumnWidth.Text = currentWidth.ToString();
                }
            }
        }

        /// <summary>
        /// 设置表格行的显示名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRowName_TextChanged(object sender, EventArgs e)
        {
            if (this.rowCurrent != null)
            {
                this.rowCurrent.RowID = this.txtRowName.Text;
            }
        }

        /// <summary>
        /// 设置表格行的高度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRowHeight_Validated(object sender, EventArgs e)
        {
            if (this.rowCurrent != null)
            {
                float currentHeight = this.rowCurrent.RowHeight;
                float objectHeight;
                bool isRightFlag = float.TryParse(this.txtRowHeight.Text, out objectHeight);
                if (isRightFlag)
                {
                    if (currentHeight != objectHeight)
                    {
                        float increaseValue = objectHeight - currentHeight;
                        this.rowCurrent.RowHeight = objectHeight;
                        this.tbTempObject.Height += increaseValue;
                        this.txtTableHeight.Text = this.tbTempObject.Height.ToString();
                        //设置表格中每行的比例
                        this.SetRowRatioInfo();
                    }
                }
                else
                {
                    this.txtRowHeight.Text = currentHeight.ToString();
                }
            }
        }

        /// <summary>
        /// 设置表格的宽度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTableWidth_Validated(object sender, EventArgs e)
        {
            float objectWidth;
            bool isRightFlag = float.TryParse(this.txtTableWidth.Text, out objectWidth);
            if (isRightFlag)
            {
                this.tbTempObject.Width = objectWidth;
                //根据比例重新设置每列的宽度
                this.ResetColumnWidthInfo();
            }
            else
            {
                this.txtTableWidth.Text = this.tbTempObject.Width.ToString();
            }
        }

        /// <summary>
        /// 设置表格的高度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTableHeight_Validated(object sender, EventArgs e)
        {
            float objectHeight;
            bool isRightFlag = float.TryParse(this.txtTableHeight.Text, out objectHeight);
            if (isRightFlag)
            {
                this.tbTempObject.Height = objectHeight;
                //根据比例重新设置每行的高度
                this.ResetRowHeightInfo();
            }
            else
            {
                this.txtTableHeight.Text = this.tbTempObject.Height.ToString();
            }
        }

        /// <summary>
        /// 删除表格列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteColumn_Click(object sender, EventArgs e)
        {
            if (this.columnCurrent != null)
            {
                if (this.tbTempObject.MyDocument.ColumnCollection.Count > 1)
                {
                    string strColId = this.lisBoxColumn.Text;
                    this.tbTempObject.MyDocument.DeleteColumn(strColId);
                    this.tbTempObject.Width -= this.columnCurrent.ColumnWidth;
                    this.txtTableWidth.Text = this.tbTempObject.Width.ToString();
                    //设置表格中每列的比例
                    this.SetColumnRatioInfo();
                    this.DoBusinessAboutDeleteColumn(strColId);

                    #region 表格列
                    this.lisBoxColumn.DataSource = this.GetColumnData(this.tbTempObject);
                    #endregion

                    #region 表格行
                    this.listBoxRow.SelectedIndex = -1;
                    #endregion
                }
            }
        }

        /// <summary>
        /// 添加表格列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddColumn_Click(object sender, EventArgs e)
        {
            string columnId = "w"+this.GetColumnCountInfo().ToString();
            Column colNew = new Column();
            colNew.ColumnID = columnId;
            colNew.ColumnWidth = 30;
            this.tbTempObject.MyDocument.ColumnCollection.Add(columnId, colNew);
            this.tbTempObject.Width += colNew.ColumnWidth;
            this.txtTableWidth.Text = this.tbTempObject.Width.ToString();
            this.SetColumnRatioInfo();
            this.DoBusinessAboutAddColumn(columnId);

            #region 表格列
            this.lisBoxColumn.DataSource = this.GetColumnData(this.tbTempObject);
            #endregion

            #region 表格行
            this.listBoxRow.SelectedIndex = -1;
            #endregion
        }

        /// <summary>
        /// 删除表格行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            if (this.rowCurrent != null)
            {
                if (this.tbTempObject.MyDocument.RowCollection.Count > 1)
                {
                    string strRowId = this.listBoxRow.Text;
                    this.tbTempObject.MyDocument.DeleteRow(strRowId);
                    this.tbTempObject.Height -= this.rowCurrent.RowHeight;
                    this.txtTableHeight.Text = this.tbTempObject.Height.ToString();

                    //设置表格中每行的比例
                    this.SetRowRatioInfo();

                    #region 表格行
                    this.listBoxRow.DataSource = this.GetRowData(this.tbTempObject);
                    #endregion
                }
            }
        }

        /// <summary>
        /// 添加表格行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            string rowId = "h" + this.GetRowCountInfo().ToString();
            Row rowNew = new Row();
            rowNew.RowID = rowId;
            rowNew.RowHeight = 30;
            this.tbTempObject.MyDocument.RowCollection.Add(rowId, rowNew);
            this.tbTempObject.Height += rowNew.RowHeight;
            this.txtTableHeight.Text = this.tbTempObject.Height.ToString();
            this.SetRowRatioInfo();
            this.DoBusinessAboutAddRow(rowNew);

            #region 表格行
            this.listBoxRow.DataSource = this.GetRowData(this.tbTempObject);
            #endregion
        }

        #endregion

        #region Method(方法)

        /// <summary>
        /// 获得要设置的Table对象的默认属性
        /// </summary>
        /// <param name="tbItem">Table对象</param>
        private void SetDefaultPropertyValue(AojTable tbItem)
        {
            this.tbObject = tbItem;
            this.CopyObject(tbItem, this.tbTempObject);

            #region 表格
            this.txtTableName.Text = tbTempObject.Name;
            this.txtTableWidth.Text = tbTempObject.Width.ToString();
            this.txtTableHeight.Text = tbTempObject.Height.ToString();
            #endregion

            #region 表格列
            this.lisBoxColumn.DataSource = this.GetColumnData(tbTempObject);
            #endregion            

            #region 表格行
            this.listBoxRow.DataSource = this.GetRowData(tbTempObject);
            #endregion
        }

        /// <summary>
        /// 设置的Table对象的相关属性
        /// </summary>
        private void SetPropertyValue()
        {
            this.CopyObject(tbTempObject, this.tbObject);
        }

        /// <summary>
        /// 获得指定表格对象的所有列
        /// </summary>
        /// <param name="tbItem">Table对象</param>
        /// <returns>所有列</returns>
        private DataTable GetColumnData(AojTable tbItem)
        {
            DataTable dtColumnData = new DataTable();

            #region 列
            DataColumn colName = new DataColumn("columnname", typeof(string));
            dtColumnData.Columns.Add(colName);
            colName = new DataColumn("columnvalue", typeof(Column));
            dtColumnData.Columns.Add(colName);
            #endregion

            #region 行
            DataRow drNew;
            foreach (string strID in tbItem.MyDocument.ColumnCollection.Keys)
            {
                drNew = dtColumnData.NewRow();
                drNew["columnname"] = strID;
                drNew["columnvalue"] = tbItem.MyDocument.ColumnCollection[strID];
                dtColumnData.Rows.Add(drNew);
            }
            #endregion

            return dtColumnData;
        }

        /// <summary>
        /// 获得指定表格对象的所有行
        /// </summary>
        /// <param name="tbItem">Table对象</param>
        /// <returns>所有行</returns>
        private DataTable GetRowData(AojTable tbItem)
        {
            DataTable dtRowData = new DataTable();

            #region 列
            DataColumn colName = new DataColumn("columnname", typeof(string));
            dtRowData.Columns.Add(colName);
            colName = new DataColumn("columnvalue", typeof(Row));
            dtRowData.Columns.Add(colName);
            #endregion

            #region 行
            DataRow drNew;
            foreach (string strID in tbItem.MyDocument.RowCollection.Keys)
            {
                drNew = dtRowData.NewRow();
                drNew["columnname"] = strID;
                drNew["columnvalue"] = tbItem.MyDocument.RowCollection[strID];
                dtRowData.Rows.Add(drNew);
            }
            #endregion

            return dtRowData;
        }

        /// <summary>
        /// 获得指定表格行对象中的所有列
        /// </summary>
        /// <param name="rowItem">表格行对象</param>
        /// <returns>所有列</returns>
        private DataTable GetCellData(Row rowItem)
        {
            DataTable dtCellData = new DataTable();

            #region 列
            DataColumn colName = new DataColumn("columnname", typeof(string));
            dtCellData.Columns.Add(colName);
            colName = new DataColumn("columnvalue", typeof(Cell));
            dtCellData.Columns.Add(colName);
            #endregion

            #region 行
            DataRow drNew;
            foreach (Cell cellItem in rowItem)
            {
                drNew = dtCellData.NewRow();
                drNew["columnname"] = cellItem.CellID;
                drNew["columnvalue"] = cellItem;
                dtCellData.Rows.Add(drNew);
            }
            #endregion

            return dtCellData;
        }

        /// <summary>
        /// 将Table对象复制一份
        /// </summary>
        private void CopyObject(AojTable tbObjectFrom, AojTable tbObjectTo)
        {
            #region 表格
            tbObjectTo.Name = tbObjectFrom.Name;
            tbObjectTo.Left = tbObjectFrom.Left;
            tbObjectTo.Top = tbObjectFrom.Top;
            tbObjectTo.Width = tbObjectFrom.Width;
            tbObjectTo.Height = tbObjectFrom.Height;
            tbObjectTo.MyDocument = new CellDocument(true);
            #endregion

            #region 表格列
            Column colItem;
            Column colNewItem;
            foreach (string strColId in tbObjectFrom.MyDocument.ColumnCollection.Keys)
            {
                colItem = tbObjectFrom.MyDocument.ColumnCollection[strColId];
                colNewItem = new Column();
                colNewItem.ColumnID = colItem.ColumnID;
                colNewItem.ColumnRatio = colItem.ColumnRatio;
                colNewItem.ColumnWidth = colItem.ColumnWidth;
                tbObjectTo.MyDocument.ColumnCollection.Add(strColId, colNewItem);
            }
            #endregion

            #region 表格行
            Row rowItem;
            Row rowNewItem;
            Cell cellNewItem;
            foreach (string strRowId in tbObjectFrom.MyDocument.RowCollection.Keys)
            {
                rowItem = tbObjectFrom.MyDocument.RowCollection[strRowId];
                rowNewItem = new Row();
                rowNewItem.RowID = rowItem.RowID;
                rowNewItem.RowHeight = rowItem.RowHeight;
                rowNewItem.RowRatio = rowItem.RowRatio;
                tbObjectTo.MyDocument.RowCollection.Add(strRowId, rowNewItem);

                #region 单元格
                int index = 0;
                foreach (string strColId in tbObjectFrom.MyDocument.ColumnCollection.Keys)
                {
                    colItem = tbObjectFrom.MyDocument.ColumnCollection[strColId];
                    cellNewItem = new Cell();
                    cellNewItem.ColumnID = colItem.ColumnID;
                    cellNewItem.RowID = rowItem[index].RowID;
                    cellNewItem.Text = rowItem[index].Text;
                    cellNewItem.TextFamilyName = rowItem[index].TextFamilyName;
                    cellNewItem.TextFontSize = rowItem[index].TextFontSize;
                    cellNewItem.TextFontStyle = rowItem[index].TextFontStyle;
                    cellNewItem.TextColor = rowItem[index].TextColor;
                    cellNewItem.ObjectAlignment = rowItem[index].ObjectAlignment;
                    cellNewItem.ObjectLineAlignment = rowItem[index].ObjectLineAlignment;
                    rowNewItem.Add(cellNewItem);
                    ++index;
                }
                #endregion
            }
            #endregion        
        }

        /// <summary>
        /// 设置表格中每行的比例
        /// </summary>
        private void SetRowRatioInfo()
        {
            float currentTableHeight = this.tbTempObject.Height;
            Row rowItem;
            foreach (string strRowId in this.tbTempObject.MyDocument.RowCollection.Keys)
            {
                rowItem = this.tbTempObject.MyDocument.RowCollection[strRowId];
                rowItem.RowRatio = rowItem.RowHeight / currentTableHeight;
            }
        }

        /// <summary>
        /// 设置表格中每列的比例
        /// </summary>
        private void SetColumnRatioInfo()
        {
            float currentTableWidth = this.tbTempObject.Width;
            Column colItem;
            foreach (string strColId in this.tbTempObject.MyDocument.ColumnCollection.Keys)
            {
                colItem = this.tbTempObject.MyDocument.ColumnCollection[strColId];
                colItem.ColumnRatio = colItem.ColumnWidth / currentTableWidth;
            }
        }

        /// <summary>
        /// 根据比例重新设置每行的高度
        /// </summary>
        private void ResetRowHeightInfo()
        {
            float currentTableHeight = this.tbTempObject.Height;
            Row rowItem;
            foreach (string strRowId in this.tbTempObject.MyDocument.RowCollection.Keys)
            {
                rowItem = this.tbTempObject.MyDocument.RowCollection[strRowId];
                rowItem.RowHeight = currentTableHeight * rowItem.RowRatio;
            }
            if (this.rowCurrent != null)
            {
                this.txtRowHeight.Text = this.rowCurrent.RowHeight.ToString();
            }
        }

        /// <summary>
        /// 根据比例重新设置每列的宽度
        /// </summary>
        private void ResetColumnWidthInfo()
        {
            float currentTableWidth = this.tbTempObject.Width;
            Column colItem;
            foreach (string strColId in this.tbTempObject.MyDocument.ColumnCollection.Keys)
            {
                colItem = this.tbTempObject.MyDocument.ColumnCollection[strColId];
                colItem.ColumnWidth = currentTableWidth * colItem.ColumnRatio;
            }
            if (this.columnCurrent != null)
            {
                this.txtColumnWidth.Text = this.columnCurrent.ColumnWidth.ToString();
            }
        }

        /// <summary>
        /// 为新加的表格列自动获取ID号
        /// </summary>
        private int GetColumnCountInfo()
        {
            int countInfo = 0;
            int columnCount = this.tbTempObject.MyDocument.ColumnCollection.Count;
            if (columnCount > 0)
            {
                #region 获得对象的相关序号
                List<Int32> lstNumber = new List<Int32>();
                int lengthAboutPrefix = 1;
                int tempInfo;
                foreach (string strColId in this.tbTempObject.MyDocument.ColumnCollection.Keys)
                {
                    string number = strColId.Substring(lengthAboutPrefix);
                    if (Int32.TryParse(number, out tempInfo))
                    {
                        lstNumber.Add(tempInfo);
                    }
                }
                #endregion

                #region 将当前对象的命名进行重新设置
                for (int index = 1; index <= columnCount; index++)
                {
                    if (!lstNumber.Contains(index))
                    {
                        countInfo = index;
                        break;
                    }
                }

                if (countInfo == 0)
                {
                    countInfo = columnCount + 1;
                }
                #endregion
            }
            else
            {
                countInfo = 1;
            }
            return countInfo;
        }

        /// <summary>
        /// 为新加的表格行自动获取ID号
        /// </summary>
        /// <returns></returns>
        private int GetRowCountInfo()
        {
            int countInfo = 0;
            int rowCount = this.tbTempObject.MyDocument.RowCollection.Count;
            if (rowCount > 0)
            {
                #region 获得对象的相关序号
                List<Int32> lstNumber = new List<Int32>();
                int lengthAboutPrefix = 1;
                int tempInfo;
                foreach (string strRowId in this.tbTempObject.MyDocument.RowCollection.Keys)
                {
                    string number = strRowId.Substring(lengthAboutPrefix);
                    if (Int32.TryParse(number, out tempInfo))
                    {
                        lstNumber.Add(tempInfo);
                    }
                }
                #endregion

                #region 将当前对象的命名进行重新设置
                for (int index = 1; index <= rowCount; index++)
                {
                    if (!lstNumber.Contains(index))
                    {
                        countInfo = index;
                        break;
                    }
                }

                if (countInfo == 0)
                {
                    countInfo = rowCount + 1;
                }
                #endregion
            }
            else
            {
                countInfo = 1;
            }
            return countInfo;
        }

        /// <summary>
        /// 添加表格列的时候,给每行添加相关的单元格
        /// </summary>
        /// <param name="colId">新增的表格列对象ID</param>
        private void DoBusinessAboutAddColumn(string colId)
        {
            Cell cellItem;
            foreach (Row rowItem in this.tbTempObject.MyDocument.RowCollection.Values)
            {
                cellItem = new Cell();
                cellItem.RowID = rowItem.RowID;
                cellItem.ColumnID = colId;
                rowItem.Add(cellItem);
            }
        }

        /// <summary>
        /// 删除表格列的时候,给每行删除相关的单元格
        /// </summary>
        /// <param name="colId">删除表格列对象ID</param>
        private void DoBusinessAboutDeleteColumn(string colId)
        {
            foreach (Row rowItem in this.tbTempObject.MyDocument.RowCollection.Values)
            {
                for (int index = 0; index < rowItem.Count; index++)
                {
                    if (rowItem[index].ColumnID.Equals(colId))
                    {
                        rowItem.RemoveAt(index);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 添加表格行时候,给每列添加相关的单元格
        /// </summary>
        /// <param name="row">新增的表格行对象</param>
        private void DoBusinessAboutAddRow(Row row)
        {
            Cell cellItem;
            foreach (Column colItem in this.tbTempObject.MyDocument.ColumnCollection.Values)
            {
                cellItem = new Cell();
                cellItem.RowID = row.RowID;
                cellItem.ColumnID = colItem.ColumnID;
                row.Add(cellItem);
            }
        }

        #endregion 
    }
}
