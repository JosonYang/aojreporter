#region 翱捷报表软件
/**********************************************
 * 版权：Copyright @2009 翱捷报表
 * 
 * 
 * 描述：对Label属性的相关设置
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
using AojReport.AojWinForm.ReportObjects;
using AojReport.AojWinForm.Common;

namespace AojReport.AojWinForm.ObjectProperties
{
    /// <summary>
    /// 对Label属性的相关设置
    /// </summary>
    public partial class AojLabelProperties : Form
    {
        #region Constructor(构造函数)

        /// <summary>
        /// Constructor(构造函数)
        /// </summarys
        public AojLabelProperties()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor(构造函数)
        /// </summary>
        /// <param name="lbItem">设置的Label对象</param>
        public AojLabelProperties(AojLabel lbItem)
        {
            InitializeComponent();

            #region 初始化
            DataTable dtAlignmentFormatData = AojCommonFnc.GetAlignmentFormatData();
            this.cmbAlignment.DisplayMember = "formatname";
            this.cmbAlignment.ValueMember = "formatvalue";
            this.cmbAlignment.DataSource = dtAlignmentFormatData;
            DataTable dtLineAlignmentFormatData = AojCommonFnc.GetLineAlignmentFormatData();
            this.cmbLineAlignment.DisplayMember = "formatname";
            this.cmbLineAlignment.ValueMember = "formatvalue";
            this.cmbLineAlignment.DataSource = dtLineAlignmentFormatData;
            #endregion

            this.SetDefaultPropertyValue(lbItem);
        }

        #endregion

        #region Field(变量)

        //设置的Label对象
        private AojLabel lbObject = null;
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
        //获取或设置对象宽度
        private Single objectWidth = 0;
        //获取或设置对象高度
        private Single objectHeight = 0;

        #endregion

        #region Property(属性)

     
        #endregion

        #region Event(事件)

        /// <summary>
        /// 获取或设置显示文本的字体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFont_Click(object sender, EventArgs e)
        {
            this.fontDialogForm.Font = new Font(this.textFamilyName, this.textFontSize, this.textFontStyle);
            if (DialogResult.OK == this.fontDialogForm.ShowDialog())
            {
                Font textFont = this.fontDialogForm.Font;
                this.textFamilyName = textFont.FontFamily.Name;
                this.textFontSize = textFont.Size;
                this.textFontStyle = textFont.Style;
                this.txtFont.Text = textFont.ToString();
            }
        }

        /// <summary>
        /// 获取或设置显示文本颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnColor_Click(object sender, EventArgs e)
        {
            this.colorDialogForm.Color = this.textColor;
            if (DialogResult.OK == this.colorDialogForm.ShowDialog())
            {
                this.textColor = this.colorDialogForm.Color;
                this.txtColor.BackColor = this.textColor;
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
        /// 选择文本对齐的方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbAlignment_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.objectAlignment = (StringAlignment)Enum.Parse(typeof(StringAlignment), this.cmbAlignment.SelectedValue.ToString());
        }

        /// <summary>
        ///  选择文本对齐的方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbLineAlignment_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.objectLineAlignment = (StringAlignment)Enum.Parse(typeof(StringAlignment), this.cmbLineAlignment.SelectedValue.ToString());
        }

        /// <summary>
        /// 对输入的对象长度信息进行确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWidth_Validated(object sender, EventArgs e)
        {
            bool isRightFlag = false;
            float fWidth;
            isRightFlag = float.TryParse(this.txtWidth.Text, out fWidth);
            if (!isRightFlag)
            {
                this.txtWidth.Text = this.objectWidth.ToString();
            }
        }

        /// <summary>
        /// 对输入的对象长度信息进行确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHeight_Validated(object sender, EventArgs e)
        {
            bool isRightFlag = false;
            float fHeight;
            isRightFlag = float.TryParse(this.txtHeight.Text, out fHeight);
            if (!isRightFlag)
            {
                this.txtHeight.Text = this.objectHeight.ToString();
            }
        }     

        #endregion

        #region Method(方法)

        /// <summary>
        /// 获得要设置的Label对象的默认属性
        /// </summary>
        /// <param name="lbItem">Label对象</param>
        private void SetDefaultPropertyValue(AojLabel lbItem)
        {
            this.lbObject = lbItem;
            //Label对象的名称
            this.txtName.Text = lbItem.Name;

            #region 显示文本
            this.strText = lbItem.Text;
            this.txtConent.Text = this.strText;
            #endregion

            #region 字体
            //字体名称
            this.textFamilyName = lbItem.TextFamilyName;
            //字体大小
            this.textFontSize = lbItem.TextFontSize;
            //字体风格
            this.textFontStyle = lbItem.TextFontStyle;
            this.txtFont.Text = lbItem.TextFont.ToString();
            #endregion

            #region 文本颜色
            this.textColor = lbItem.TextColor;
            this.txtColor.BackColor = this.textColor;
            #endregion

            #region 文本对齐
            this.objectLineAlignment = lbItem.ObjectLineAlignment;
            this.cmbLineAlignment.SelectedValue = this.objectLineAlignment.ToString();
            this.objectAlignment = lbItem.ObjectAlignment;
            this.cmbAlignment.SelectedValue = this.objectAlignment.ToString();
            #endregion

            #region 长度
            this.objectWidth = lbItem.Width;
            this.txtWidth.Text = this.objectWidth.ToString();
            this.objectHeight = lbItem.Height;
            this.txtHeight.Text = this.objectHeight.ToString();
            #endregion
        }

        /// <summary>
        /// 设置的Label对象的相关属性
        /// </summary>
        private void SetPropertyValue()
        {
            //显示文本
            lbObject.Text = this.txtConent.Text;

            #region 字体
            lbObject.TextFamilyName = this.textFamilyName;
            lbObject.TextFontSize = this.textFontSize;
            lbObject.TextFontStyle = this.textFontStyle;
            #endregion

            #region 文本颜色
            lbObject.TextColor = this.textColor;
            #endregion

            #region 文本对齐
            lbObject.ObjectLineAlignment = this.objectLineAlignment;
            lbObject.ObjectAlignment = this.objectAlignment;
            #endregion

            #region 长度
            lbObject.Width = float.Parse(this.txtWidth.Text);
            lbObject.Height = float.Parse(this.txtHeight.Text);
            #endregion
        }

        #endregion 
    }
}
