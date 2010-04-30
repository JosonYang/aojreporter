#region 翱捷报表软件
/**********************************************
 * 版权：Copyright @2009 翱捷报表
 * 
 * 
 * 描述：报表设计器新建报表窗体
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
using System.Windows.Forms;
using AojReport.AojWinForm.Common;

namespace AojReport.AojWinForm
{
    /// <summary>
    /// 报表设计器新建报表窗体
    /// </summary>
    public partial class NewWorkSpace : Form
    {
        #region Constructor(构造函数)

        /// <summary>
        /// Constructor(构造函数)
        /// </summary>
        public NewWorkSpace()
        {
            InitializeComponent();
            //初始化报表设计器可绘制的纸张大小数据信息
            InitializePageLayoutInfo();
            //初始化报表设计器可绘制的纸张的显示方式
            InitializePageStyleInfo();
        }

        #endregion

        #region Field(变量)

        //报表设计器可绘制的纸张大小
        private string strPageSize = string.Empty;
        //报表设计器可绘制的纸张的显示方式
        private string strPageStyle = string.Empty;

        #endregion

        #region Property(属性)

        /// <summary>
        /// 报表设计器可绘制的纸张大小
        /// </summary>
        [Category("AojReport")]
        [Description("报表设计器可绘制的纸张大小")]
        public string PageSize
        {
            get { return strPageSize;}
            set { strPageSize = value;}
        }

        /// <summary>
        /// 报表设计器可绘制的纸张的显示方式
        /// </summary>
        [Category("AojReport")]
        [Description("报表设计器可绘制的纸张的显示方式")]
        public string PageStyle
        {
            get { return strPageStyle; }
            set { strPageStyle = value; }
        }

        #endregion

        #region Event(事件)

        /// <summary>
        /// 新建报表的设计区域
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            this.strPageSize = this.cmbPage.SelectedValue.ToString();
            this.strPageStyle = this.cmbStyle.SelectedValue.ToString();
            this.Close();
        }

        #endregion

        #region Method(方法)

        /// <summary>
        /// 初始化报表设计器可绘制的纸张大小数据信息
        /// </summary>
        private void InitializePageLayoutInfo()
        {
            //获得报表设计器可绘制的纸张大小数据信息 
            DataTable dtPageLayoutInit = AojCommonFnc.GetPageLayoutData();

            #region 将数据填充到指定的控件
            this.cmbPage.ValueMember = "lauoutSize";
            this.cmbPage.DisplayMember = "lauoutName";
            this.cmbPage.DataSource = dtPageLayoutInit;
            #endregion
        }

        /// <summary>
        /// 初始化报表设计器可绘制的纸张的显示方式
        /// </summary>
        private void InitializePageStyleInfo()
        {
            #region 纸张的显示方式数据信息
            DataTable dtPageStyleInit = new DataTable();
            DataColumn colName = new DataColumn("styleName", typeof(string));
            dtPageStyleInit.Columns.Add(colName);
            DataColumn colValue = new DataColumn("styleValue", typeof(int));
            dtPageStyleInit.Columns.Add(colValue);
            DataRow drInfo = dtPageStyleInit.NewRow();
            drInfo["styleName"] = "横";
            drInfo["styleValue"] = 1;
            dtPageStyleInit.Rows.Add(drInfo);
            drInfo = dtPageStyleInit.NewRow();
            drInfo["styleName"] = "纵";
            drInfo["styleValue"] = 0;
            dtPageStyleInit.Rows.Add(drInfo);
          
            #endregion

            #region 将数据填充到指定的控件
            this.cmbStyle.ValueMember = "styleValue";
            this.cmbStyle.DisplayMember = "styleName";
            this.cmbStyle.DataSource = dtPageStyleInit;
            #endregion
        }

        #endregion
    }
}
