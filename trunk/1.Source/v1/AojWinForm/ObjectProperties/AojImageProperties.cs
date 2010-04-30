#region 翱捷报表软件
/**********************************************
 * 版权：Copyright @2009 翱捷报表
 * 
 * 
 * 描述：对Image属性的相关设置
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

namespace AojReport.AojWinForm.ObjectProperties
{
    /// <summary>
    /// 对Image属性的相关设置
    /// </summary>
    public partial class AojImageProperties : Form
    {
        #region Constructor(构造函数)

        /// <summary>
        /// Constructor(构造函数)
        /// </summarys
        public AojImageProperties()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor(构造函数)
        /// </summary>
        /// <param name="imgItem">设置的Image对象</param>
        public AojImageProperties(AojImage imgItem)
        {
            InitializeComponent();
            this.SetDefaultPropertyValue(imgItem);
        }

        #endregion

        #region Field(变量)

        //设置的Image对象
        private AojImage imgObject = null;
        //获取或设置显示图片路径
        private string strSrc = string.Empty;
        //获取或设置对象宽度
        private Single objectWidth = 0;
        //获取或设置对象高度
        private Single objectHeight = 0;

        #endregion

        #region Property(属性)

     
        #endregion

        #region Event(事件)

        /// <summary>
        /// 获取或设置显示图片路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == this.openFileDialogForm.ShowDialog())
            {
                this.strSrc = this.openFileDialogForm.FileName;
                this.txtSrc.Text = this.strSrc;
                this.picView.ImageLocation = this.strSrc;
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
        /// 获得要设置的Image对象的默认属性
        /// </summary>
        /// <param name="imgItem">Image对象</param>
        private void SetDefaultPropertyValue(AojImage imgItem)
        {
            this.imgObject = imgItem;
            //Image对象的名称
            this.txtName.Text = imgItem.Name;

            #region 显示图片路径
            this.strSrc = imgItem.ImagePath;
            this.txtSrc.Text = this.strSrc;
            if (!string.IsNullOrEmpty(this.strSrc))
            {
                this.picView.Image = Image.FromFile(this.strSrc);
            }
            #endregion
           
            #region 长度
            this.objectWidth = imgItem.Width;
            this.txtWidth.Text = this.objectWidth.ToString();
            this.objectHeight = imgItem.Height;
            this.txtHeight.Text = this.objectHeight.ToString();
            #endregion
        }

        /// <summary>
        /// 设置的Image对象的相关属性
        /// </summary>
        private void SetPropertyValue()
        {
            //显示图片路径
            imgObject.ImagePath = this.strSrc;

            #region 长度
            imgObject.Width = float.Parse(this.txtWidth.Text);
            imgObject.Height = float.Parse(this.txtHeight.Text);
            #endregion
        }

        #endregion
    }
}
