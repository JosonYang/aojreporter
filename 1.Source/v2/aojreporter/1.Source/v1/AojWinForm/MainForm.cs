#region 翱捷报表软件
/**********************************************
 * 版权：Copyright @2009 翱捷报表
 * 
 * 
 * 描述：报表设计器窗体
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
using System.Xml;
using System.IO;
using System.Diagnostics;
using AojReport.AojWinForm.Common;
using AojReport.AojWinForm.ReportObjects;
using AojReport.AojWinForm.Action;

namespace AojReport.AojWinForm
{
    /// <summary>
    /// 报表设计器窗体
    /// </summary>
    public partial class MainForm : Form
    {
        #region Constructor(构造函数)

        /// <summary>
        /// Constructor(构造函数)
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            //初始化panel中的相关事件
            this.InitializePanleEvent();
            //初始化页面可以放大或者缩小的百分比
            this.InitializePagesizePercentInfo();
            //初始化报表设计器可绘制的纸张大小数据信息
            this.InitializePageLayoutInfo();
            //根据电脑显示屏幕的显示率来设定报表设计器窗体的初始大小
            this.InitializeFormSize();
            //对报表设计器中将要用到的一些动作类进行初始化,比如工作区缩放，历史操作等等
            this.InitializeActionToolsInfo();
        }

        /// <summary>
        /// Constructor(构造函数)
        /// </summary>
        /// <param name="strXmlDocumentPath">报表格式XML文件</param>
        public MainForm(string strXmlDocumentPath)
        {
            InitializeComponent();
            //初始化panel中的相关事件
            this.InitializePanleEvent();
            //报表的设计区域
            this.drawWorkSpace = new DrawWorkSpace();
            this.splitContainerDesign.Panel1.Controls.Add(this.drawWorkSpace);
            //初始化对象集合
            this.drawWorkSpace.GraphicsList = new AojReportObjectCollection();

            #region 记录报表设计区域历史记录Undo的相关对象集合
            if (this.drawWorkSpace.ListHistoryUndo != null)
            {
                AojReportObjectCollection lstTemp = AojCommonFnc.CopyReportObject(this.drawWorkSpace.GraphicsList);
                this.drawWorkSpace.ListHistoryUndo.Insert(0, lstTemp);
            }
            #endregion

            //初始化页面可以放大或者缩小的百分比
            this.InitializePagesizePercentInfo();
            //初始化报表设计器可绘制的纸张大小数据信息
            this.InitializePageLayoutInfo();
            //根据电脑显示屏幕的显示率来设定报表设计器窗体的初始大小
            this.InitializeFormSize();
            //对报表设计器中将要用到的一些动作类进行初始化,比如工作区缩放，历史操作等等
            this.InitializeActionToolsInfo();

            #region 载入报表格式XML文件,同时对报表设计器进行初始化
            this.OpenReportDocument(strXmlDocumentPath);
            #endregion

            #region 记录报表设计区域历史记录Undo的相关对象集合
            if (this.drawWorkSpace.ListHistoryUndo != null)
            {
                AojReportObjectCollection lstHistoryUndo = AojCommonFnc.CopyReportObject(this.drawWorkSpace.GraphicsList);
                this.drawWorkSpace.ListHistoryUndo.Insert(0, lstHistoryUndo);
            }
            #endregion

            this.IsParameterExisted = true;
        }

        #endregion

        #region Field(变量)

        //报表设计器初始化时是否要调用新建报表窗体
        private bool IsParameterExisted = false;
        //报表的设计区域
        private DrawWorkSpace drawWorkSpace = null;
        //报表设计器可绘制的纸张的显示方式
        private string strPageStyle = string.Empty;
        /// <summary>
        /// 对工作区域的对象进行删除动作
        /// </summary>
        private AojDeleteAction deleteAction;
        /// <summary>
        /// 对工作区域的对象进行全部选中动作
        /// </summary>
        private AojSelectAllAction selectallAction;
        /// <summary>
        /// 对工作区域的对象进行剪切动作
        /// </summary>
        private AojCutAction cutAction;
        /// <summary>
        /// 对工作区域的对象进行复制动作
        /// </summary>
        private AojCopyAction copyAction;
        /// <summary>
        /// 对工作区域的对象进行粘贴动作
        /// </summary>
        private AojPasteAction pasteAction;
        /// <summary>
        /// 对工作区域的各对象操作的历史记录进行Redo操作
        /// </summary>
        private AojHistoryRedoAction redoAction;
        /// <summary>
        /// 对工作区域的各对象操作的历史记录进行Undo操作
        /// </summary>
        private AojHistoryUndoAction undoAction;

        #endregion

        #region Event(事件)

        /// <summary>
        /// 报表设计器panel进行缩放时候的处理操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.drawWorkSpace != null)
            {
                this.splitContainerDesign.Panel1.AutoScroll = false;
                this.DoBusinessAboutResizedFormSize();
                this.splitContainerDesign.Panel1.AutoScroll = true;
            }
        }

        /// <summary>
        /// 在报表区域内不进行任何对象的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbPointer_Click(object sender, EventArgs e)
        {
            this.drawWorkSpace.ActiveTool = AojConst.DrawToolType.Pointer;
            this.tsbLabel.Checked = false;
            this.tsbImage.Checked = false;
            this.tsbTable.Checked = false;
        }

        /// <summary>
        /// 在报表设计器区域绘制Label对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmLabel_Click(object sender, EventArgs e)
        {
            this.drawWorkSpace.ActiveTool = AojConst.DrawToolType.Label;
        }

        /// <summary>
        /// 在报表设计器区域绘制Label对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbLabel_Click(object sender, EventArgs e)
        {
            this.drawWorkSpace.ActiveTool = AojConst.DrawToolType.Label;
            this.tsbPointer.Checked = false;
            this.tsbImage.Checked = false;
            this.tsbTable.Checked = false;
        }

        /// <summary>
        /// 在报表设计器区域绘制Table对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmTable_Click(object sender, EventArgs e)
        {
            this.drawWorkSpace.ActiveTool = AojConst.DrawToolType.Table;
        }

        /// <summary>
        /// 在报表设计器区域绘制Table对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbTable_Click(object sender, EventArgs e)
        {
            this.drawWorkSpace.ActiveTool = AojConst.DrawToolType.Table;
            this.tsbPointer.Checked = false;
            this.tsbImage.Checked = false;
            this.tsbLabel.Checked = false;
        }

        /// <summary>
        /// 在报表设计器区域绘制Image对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmImage_Click(object sender, EventArgs e)
        {
            this.drawWorkSpace.ActiveTool = AojConst.DrawToolType.Image;
        }

        /// <summary>
        /// 在报表设计器区域绘制Image对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbImage_Click(object sender, EventArgs e)
        {
            this.drawWorkSpace.ActiveTool = AojConst.DrawToolType.Image;
            this.tsbPointer.Checked = false;
            this.tsbLabel.Checked = false;
            this.tsbTable.Checked = false;
        }

        /// <summary>
        /// 报表设计器中选择需要绘制的纸张的大小时候的处理动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbCmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.drawWorkSpace != null)
            {
                this.drawWorkSpace.PaperSizeName = this.tsbCmbPage.ComboBox.Text;
                string strSelectedValue = this.tsbCmbPage.ComboBox.SelectedValue.ToString();
                //根据选择的纸张大小对绘制的纸张大小进行重新设置
                this.ResetDrawWorkSpaceSize(strSelectedValue);
            }
        }

        /// <summary>
        /// 根据选择的倍率对绘制的纸张大小进行重新设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbCmbZoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.drawWorkSpace != null)
            {
                //获得用户选择的倍率信息
                this.GetSelectedPagesizePercent();
                //根据选择的倍率对绘制的纸张大小进行重新设置
                this.SetDrawWorkSpaceSizeByPagesizePercent();
            }
        }

        /// <summary>
        /// 报表设计器新建报表窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (!IsParameterExisted)
            {
                this.ShowNewWorkSpaceForm();
            }
        }

        /// <summary>
        /// 当活动窗体变为活动窗体时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Activated(object sender, EventArgs e)
        {
            AojHotKey.RegisterHotKeyToForm(Handle);
        }

        /// <summary>
        /// 当活动窗体变为非活动窗体时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            AojHotKey.UnregisterHotKeyFromForm(Handle);
        }

        /// <summary>
        /// 报表设计器新建报表窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmNew_Click(object sender, EventArgs e)
        {
            this.ShowNewWorkSpaceForm();
        }

        /// <summary>
        /// 报表设计器新建报表窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbNew_Click(object sender, EventArgs e)
        {
            this.ShowNewWorkSpaceForm();
        }

        /// <summary>
        /// 对工作区域的各对象操作的历史记录进行Undo操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmUndo_Click(object sender, EventArgs e)
        {
            undoAction.PerformAction(this.drawWorkSpace);
        }

        /// <summary>
        /// 对工作区域的各对象操作的历史记录进行Redo操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmRedo_Click(object sender, EventArgs e)
        {
            redoAction.PerformAction(this.drawWorkSpace);
        }

        /// <summary>
        /// 对工作区域的对象进行剪切动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmCut_Click(object sender, EventArgs e)
        {
            cutAction.PerformAction(this.drawWorkSpace);
        }

        /// <summary>
        /// 对工作区域的对象进行复制动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmCopy_Click(object sender, EventArgs e)
        {
            copyAction.PerformAction(this.drawWorkSpace);
        }

        /// <summary>
        /// 对工作区域的对象进行粘贴动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmPaste_Click(object sender, EventArgs e)
        {
            pasteAction.PerformAction(this.drawWorkSpace);
        }

        /// <summary>
        /// 对工作区域的对象进行删除动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmDelete_Click(object sender, EventArgs e)
        {
            deleteAction.PerformAction(this.drawWorkSpace);
        }

        /// <summary>
        /// 对工作区域的对象进行全部选中动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmSelectAll_Click(object sender, EventArgs e)
        {
            selectallAction.PerformAction(this.drawWorkSpace);
        }

        /// <summary>
        /// 编辑菜单被打开时候的处理动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmEdit_DropDownOpened(object sender, EventArgs e)
        {
            this.SetEditMenuEnabled();
        }

        /// <summary>
        /// 视图菜单被打开时候的处理动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmView_DropDownOpened(object sender, EventArgs e)
        {
            #region 设置视图菜单选择项的显示情况
            if (this.drawWorkSpace == null)
            {
                this.tsmView.DropDownItems["tsmReportDocument"].Enabled = false;
            }
            else
            {
                this.tsmView.DropDownItems["tsmReportDocument"].Enabled = true;
            }
            #endregion
        }

        /// <summary>
        /// 对象菜单被打开时候的处理动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmObject_DropDownOpened(object sender, EventArgs e)
        {
            #region 设置对象菜单选择项的显示情况
            if (this.drawWorkSpace == null)
            {
                this.SetObjectMenuEnabled(false);
            }
            else
            {
                this.SetObjectMenuEnabled(true);
            }
            #endregion
        }

        /// <summary>
        /// 文件菜单被打开时候的处理动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmFile_DropDownOpened(object sender, EventArgs e)
        {
            #region 设置对象菜单选择项的显示情况
            if (this.drawWorkSpace == null)
            {
                this.tsmFile.DropDownItems["tsmSave"].Enabled = false;
            }
            else
            {
                this.tsmFile.DropDownItems["tsmSave"].Enabled = true;
            }
            #endregion
        }

        /// <summary>
        /// 退出报表设计器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 打开报表设计文件进行文件的加载处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmOpen_Click(object sender, EventArgs e)
        {
            this.OpenFile();
        }

        /// <summary>
        /// 打开报表设计文件进行文件的加载处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbOpen_Click(object sender, EventArgs e)
        {
            this.OpenFile();
        }

        /// <summary>
        /// 对报表设计文件进行保存相关处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmSave_Click(object sender, EventArgs e)
        {
            //对报表设计文件进行保存相关处理
            this.SaveReportDocument();
        }

        /// <summary>
        /// 对报表设计文件进行保存相关处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbSave_Click(object sender, EventArgs e)
        {
            //对报表设计文件进行保存相关处理
            this.SaveReportDocument();
        }

        /// <summary>
        /// 报表设计区域是否是网格布局模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbGridStyle_Click(object sender, EventArgs e)
        {
            bool checkedFlag = this.tsbGridStyle.Checked;
            this.tsbTxtGridStyle.Enabled = checkedFlag;
            this.tsbAutoCompute.Checked = checkedFlag;
            this.tsbAutoCompute.Enabled = checkedFlag;

            #region 网格布局(GridStyle)
            if (this.drawWorkSpace != null)
            {
                this.drawWorkSpace.GridStyleFlag = checkedFlag;
                this.tsbAutoCompute.Checked = checkedFlag;
                if (checkedFlag)
                {
                    this.drawWorkSpace.NormalDistanceAboutGridStyle = Convert.ToInt32(this.tsbTxtGridStyle.Text);
                    this.drawWorkSpace.DistanceAboutGridStyle = (int)(this.drawWorkSpace.NormalDistanceAboutGridStyle * this.drawWorkSpace.PagesizePercent);
                }
                this.drawWorkSpace.Refresh();
            }
            #endregion
        }

        /// <summary>
        /// 网格布局(GridStyle)时各点的距离
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbTxtGridStyle_Validated(object sender, EventArgs e)
        {
            #region 输入后的判断
            int normalDistance = 0;
            bool isRight = Int32.TryParse(this.tsbTxtGridStyle.Text, out normalDistance);
            if (isRight)
            {
                #region 设置时的最小值
                if (normalDistance < 5)
                {
                    this.tsbTxtGridStyle.Text = "5";
                }
                #endregion

                #region 设置时的最大值
                if (normalDistance > 100)
                {
                    this.tsbTxtGridStyle.Text = "100";
                }
                #endregion
            }
            else
            {
                #region 错误时的默认值
                this.tsbTxtGridStyle.Text = "10";
                #endregion
            }
            #endregion

            #region 对精度的设置
            if (this.tsbGridStyle.Checked)
            {
                #region 网格布局(GridStyle)
                if (this.drawWorkSpace != null)
                {
                    this.drawWorkSpace.NormalDistanceAboutGridStyle = Convert.ToInt32(this.tsbTxtGridStyle.Text);
                    this.drawWorkSpace.DistanceAboutGridStyle = (int)(this.drawWorkSpace.NormalDistanceAboutGridStyle * this.drawWorkSpace.PagesizePercent);
                    this.drawWorkSpace.Refresh();
                }
                #endregion
            }
            #endregion
        }

        /// <summary>
        /// 指定报表设计器在绘制对象的时候是否参照网格布局(GridStyle)时各点的距离
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbAutoCompute_Click(object sender, EventArgs e)
        {
            if (this.drawWorkSpace != null)
            {
                this.drawWorkSpace.DrawByGridStyle = this.tsbAutoCompute.Checked;
            }
        }

        /// <summary>
        /// 查看报表设计文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmReportDocument_Click(object sender, EventArgs e)
        {
            if (this.drawWorkSpace != null)
            {
                ProcessStartInfo Info = new ProcessStartInfo();
                Info.FileName = "notepad.exe";
                string strFileURL = AojCommonFnc.GetXMLDoumentPath("AojReportDocument.aojx");
                Info.Arguments = strFileURL;
                AojCommonFnc.SaveReportDocument(strFileURL, this.drawWorkSpace);
                Process.Start(Info);
            }
        }

        #endregion

        #region Method(方法)

        /// <summary>
        /// 按相应的快捷键后执行的动作
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            //按相应的快捷键后执行的动作
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        //Ctrl+N
                        case AojHotKey.HotKeyID.hotKeyID_New:
                            //报表设计器新建报表窗体
                            this.ShowNewWorkSpaceForm();
                            break;
                        //Ctrl+O
                        case AojHotKey.HotKeyID.hotKeyID_Open:
                            //打开报表设计文件进行文件的加载处理
                            this.OpenFile();
                            break;
                        //Ctrl+S
                        case AojHotKey.HotKeyID.hotKeyID_Save:
                            //对报表设计文件进行保存相关处理
                            this.SaveReportDocument();
                            break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// 根据电脑显示屏幕的显示率来设定报表设计器窗体的初始大小
        /// </summary>
        private void InitializeFormSize()
        {
            Rectangle screenWorkingArea = Screen.PrimaryScreen.WorkingArea;
            //根据电脑显示屏幕的显示率来设定报表设计器窗体的初始大小
            this.Width = screenWorkingArea.Width;
            this.Height = screenWorkingArea.Height;
            if (this.drawWorkSpace != null)
            {
                //指定控件布局时放大倍率为100%时候的正常宽度
                this.drawWorkSpace.NormalWidth = this.drawWorkSpace.Width;
                //指定控件布局时放大倍率为100%时候的正常高度
                this.drawWorkSpace.NormalHeight = this.drawWorkSpace.Height;

                #region 设置报表纸张的显示方式
                if (!string.IsNullOrEmpty(this.drawWorkSpace.PageStyle)
                        && this.drawWorkSpace.PageStyle.Equals("1"))
                {
                    if (this.drawWorkSpace.NormalWidth < this.drawWorkSpace.NormalHeight)
                    {
                        int spaceWidth = this.drawWorkSpace.NormalWidth;
                        this.drawWorkSpace.NormalWidth = this.drawWorkSpace.NormalHeight;
                        this.drawWorkSpace.NormalHeight = spaceWidth;
                    }                   
                }
                #endregion
            }    
        }

        /// <summary>
        /// 初始化页面可以放大或者缩小的百分比
        /// </summary>
        private void InitializePagesizePercentInfo()
        {
            //获得放大或者缩小的数据信息 
            DataTable dtPagesizeInit = AojCommonFnc.GetPagesizePercentData();

            #region 将数据填充到指定的控件中
            this.tsbCmbZoom.DropDownStyle = ComboBoxStyle.DropDownList;
            this.tsbCmbZoom.ComboBox.ValueMember = "percentValue";
            this.tsbCmbZoom.ComboBox.DisplayMember = "percentName";
            this.tsbCmbZoom.ComboBox.DataSource = dtPagesizeInit;
            #endregion

            this.tsbCmbZoom.ComboBox.SelectedValue = "1.0";
        }

        /// <summary>
        /// 初始化报表设计器可绘制的纸张大小数据信息
        /// </summary>
        private void InitializePageLayoutInfo()
        {
            //获得报表设计器可绘制的纸张大小数据信息 
            DataTable dtPageLayoutInit = AojCommonFnc.GetPageLayoutData();

            #region 将数据填充到指定的控件中
            this.tsbCmbPage.DropDownStyle = ComboBoxStyle.DropDownList;
            this.tsbCmbPage.ComboBox.ValueMember = "lauoutSize";
            this.tsbCmbPage.ComboBox.DisplayMember = "lauoutName";
            this.tsbCmbPage.ComboBox.DataSource = dtPageLayoutInit;
            #endregion
        }

        /// <summary>
        /// 报表设计器panel进行缩放时候的处理操作
        /// </summary>
        private void DoBusinessAboutResizedFormSize()
        {
            #region 获取相关的size信息

            #region 获得报表设计器绘制区域的size信息
            int drawWorkSpaceWidth = this.drawWorkSpace.Width;
            int drawWorkSpaceHeight = this.drawWorkSpace.Height;
            #endregion

            #region 获得报表设计器绘制区域的父控件的size信息
            int mainWidth = this.splitContainerDesign.Panel1.Width;
            int mainHeight = this.splitContainerDesign.Panel1.Height;
            #endregion

            #endregion

            #region 相关处理详细

            /*
             * 说明:当报表设计器绘制区域的父控件的size的宽大于报表设计
             *      器绘制区域的size的宽的时候,将指定绘制区域离父控件的左边距离.*/
            if (mainWidth > drawWorkSpaceWidth)
            {
                #region 左边距离
                if (mainHeight < drawWorkSpaceHeight)
                {
                    this.drawWorkSpace.AojLeft = (mainWidth - drawWorkSpaceWidth - SystemInformation.VerticalScrollBarWidth) / 2;
                }
                else
                {
                    this.drawWorkSpace.AojLeft = (mainWidth - drawWorkSpaceWidth) / 2;
                }
                #endregion
            }
            else
            {
                #region 左边距离
                this.drawWorkSpace.AojLeft = 0;
                #endregion
            }

            /*
             * 说明:当报表设计器绘制区域的父控件的size的高大于报表设计
             *      器绘制区域的size的高的时候,将指定绘制区域离父控件的上边距离.*/
            if (mainHeight > drawWorkSpaceHeight)
            {
                #region 上边距离
                if (mainWidth < drawWorkSpaceWidth)
                {
                    this.drawWorkSpace.AojTop = (mainHeight - drawWorkSpaceHeight - SystemInformation.HorizontalScrollBarHeight) / 2;
                }
                else
                {
                    this.drawWorkSpace.AojTop = (mainHeight - drawWorkSpaceHeight) / 2;
                }
                #endregion
            }
            else
            {
                #region 上边距离
                this.drawWorkSpace.AojTop = 0;
                #endregion
            }

            #endregion
        }

        /// <summary>
        /// 根据选择的纸张大小对绘制的纸张大小进行重新设置
        /// </summary>
        /// <param name="strPagesize">选择的纸张大小信息</param>
        private void ResetDrawWorkSpaceSize(string strPagesize)
        {
            int drawWorkSpaceWidth;
            int drawWorkSpaceHeight;
            //判断用户在XML文件中设置的纸张大小信息是否符合要求
            int flag = strPagesize.IndexOf('*');

            #region 符合要求
            if (flag != -1)
            {
                #region 设置的纸张的宽和高
                string strWidth = strPagesize.Substring(0, flag);
                string strHeight = strPagesize.Substring(flag + 1);
                #endregion

                #region 设置的纸张大小
                bool IsWidthRight = false;
                bool IsHeightRight = false;
                //判断用户在XML文件中设置的纸张大小是否可以顺利转化为整形数据
                IsWidthRight = Int32.TryParse(strWidth, out drawWorkSpaceWidth);
                IsHeightRight = Int32.TryParse(strHeight, out drawWorkSpaceHeight);
                #endregion

                #region 顺利转化为整形数据
                if (IsWidthRight && IsHeightRight)
                {
                    //指定控件布局时放大倍率为100%时候的正常宽度
                    this.drawWorkSpace.NormalWidth = drawWorkSpaceWidth;
                    //指定控件布局时放大倍率为100%时候的正常高度
                    this.drawWorkSpace.NormalHeight = drawWorkSpaceHeight;

                    #region 设置报表纸张的显示方式
                    if (!string.IsNullOrEmpty(this.drawWorkSpace.PageStyle)
                            && this.drawWorkSpace.PageStyle.Equals("1"))
                    {
                        if (this.drawWorkSpace.NormalWidth < this.drawWorkSpace.NormalHeight)
                        {
                            int spaceWidth = this.drawWorkSpace.NormalWidth;
                            this.drawWorkSpace.NormalWidth = this.drawWorkSpace.NormalHeight;
                            this.drawWorkSpace.NormalHeight = spaceWidth;
                        }
                    }
                    #endregion

                    //获得用户选择的倍率信息
                    this.GetSelectedPagesizePercent();

                    #region 根据选择的倍率对绘制的纸张大小进行重新设置
                    this.SetDrawWorkSpaceSizeByPagesizePercent();
                    #endregion
                }
                #endregion
            }
            #endregion
        }

        /// <summary>
        /// 获得用户选择的倍率信息
        /// </summary>
        /// <returns>用户选择的倍率信息</returns>
        private void GetSelectedPagesizePercent()
        {
            string strValue = this.tsbCmbZoom.ComboBox.SelectedValue.ToString();
            float percentInfo;
            if (float.TryParse(strValue, out percentInfo))
            {
                this.drawWorkSpace.PagesizePercent = percentInfo;
            }
            else
            {
                this.drawWorkSpace.PagesizePercent = 1f;
            }
        }

        /// <summary>
        /// 根据选择的倍率对绘制的纸张大小进行重新设置
        /// </summary>
        private void SetDrawWorkSpaceSizeByPagesizePercent()
        {
            #region 根据选择的倍率对绘制的纸张大小进行重新设置
            float pagePercent = this.drawWorkSpace.PagesizePercent;
            this.drawWorkSpace.Width = (int)(this.drawWorkSpace.NormalWidth * pagePercent);
            this.drawWorkSpace.Height = (int)(this.drawWorkSpace.NormalHeight * pagePercent);
            #endregion

            //报表设计器panel进行缩放时候的处理操作
            this.DoBusinessAboutResizedFormSize();
        }

        /// <summary>
        /// 报表设计器新建报表窗体
        /// </summary>
        private void ShowNewWorkSpaceForm()
        {
            NewWorkSpace frmNew = new NewWorkSpace();

            if (DialogResult.OK == frmNew.ShowDialog())
            {
                #region 创建成功

                #region 报表预设情报
                string pageSize = frmNew.PageSize;
                string pageStyle = frmNew.PageStyle;
                #endregion

                if (!string.IsNullOrEmpty(pageSize))
                {
                    #region 新建报表的设计区域
                    this.NewDrawWorkSpace();
                    #endregion

                    this.drawWorkSpace.PageStyle = pageStyle;

                    #region 绘制的纸张大小
                    if (!this.tsbCmbPage.ComboBox.SelectedValue.ToString().Equals(pageSize))
                    {
                        this.tsbCmbPage.ComboBox.SelectedValue = pageSize;
                    }
                    else
                    {
                        //根据选择的纸张大小对绘制的纸张大小进行重新设置
                        this.ResetDrawWorkSpaceSize(pageSize);
                        this.drawWorkSpace.PaperSizeName = this.tsbCmbPage.ComboBox.Text;
                    }
                    #endregion

                    #region 网格布局(GridStyle)
                    bool checkedFlag = this.tsbGridStyle.Checked;
                    this.drawWorkSpace.GridStyleFlag = checkedFlag;
                    if (checkedFlag)
                    {
                        this.drawWorkSpace.NormalDistanceAboutGridStyle = Convert.ToInt32(this.tsbTxtGridStyle.Text);
                        this.drawWorkSpace.DistanceAboutGridStyle = (int)(this.drawWorkSpace.NormalDistanceAboutGridStyle * this.drawWorkSpace.PagesizePercent);
                        this.drawWorkSpace.DrawByGridStyle = this.tsbAutoCompute.Checked;
                    }
                    #endregion
                }

                #endregion

                //根据情况激活工具栏
                this.ShowTools(true);
            }
            else
            {
                //根据情况激活工具栏
                this.ShowTools(false);
            }
        }
        
        /// <summary>
        /// 新建报表绘制区域
        /// </summary>
        private void NewDrawWorkSpace()
        {
            this.drawWorkSpace = new DrawWorkSpace();

            #region 新建报表设计区域
            if (this.splitContainerDesign.Panel1.Controls.Count > 0)
            {
                this.splitContainerDesign.Panel1.Controls.RemoveAt(0);
            }
            this.splitContainerDesign.Panel1.Controls.Add(this.drawWorkSpace);
            #endregion

            //初始化对象集合
            this.drawWorkSpace.GraphicsList = new AojReportObjectCollection();

            #region 记录报表设计区域历史记录Undo的相关对象集合
            if (this.drawWorkSpace.ListHistoryUndo != null)
            {
                AojReportObjectCollection lstTemp = AojCommonFnc.CopyReportObject(this.drawWorkSpace.GraphicsList);
                this.drawWorkSpace.ListHistoryUndo.Insert(0, lstTemp);
            }
            #endregion
        }

        /// <summary>
        /// 对报表设计器中将要用到的一些动作类进行初始化,比如工作区缩放，历史操作等等
        /// </summary>
        private void InitializeActionToolsInfo()
        {
            //对工作区域的对象进行删除动作
            deleteAction = new AojDeleteAction();
            //对工作区域的对象进行全部选中动作
            selectallAction = new AojSelectAllAction();
            //对工作区域的对象进行剪切动作
            cutAction = new AojCutAction();
            //对工作区域的对象进行复制动作
            copyAction = new AojCopyAction();
            //对工作区域的对象进行粘贴动作
            pasteAction = new AojPasteAction();
            //对工作区域的各对象操作的历史记录进行Redo操作
            redoAction = new AojHistoryRedoAction();
            //对工作区域的各对象操作的历史记录进行Undo操作
            undoAction = new AojHistoryUndoAction();
        }

        /// <summary>
        /// 设置编辑菜单选择项的显示情况
        /// </summary>
        private void SetEditMenuEnabled()
        {
            if (this.drawWorkSpace != null)
            {
                #region Undo
                if (this.drawWorkSpace.ListHistoryUndo.Count > 1)
                {
                    this.tsmUndo.Enabled = true;
                }
                else
                {
                    this.tsmUndo.Enabled = false;
                }
                #endregion

                #region Redo
                if (this.drawWorkSpace.ListHistoryRedo.Count > 0)
                {
                    this.tsmRedo.Enabled = true;
                }
                else
                {
                    this.tsmRedo.Enabled = false;
                }
                #endregion

                #region #region Copy|Cut|Delete|SelectAll
                if (this.drawWorkSpace.GraphicsList != null && this.drawWorkSpace.GraphicsList.Count > 0)
                {
                    #region Copy|Cut|Delete|SelectAll
                    int lstSelectedCount = this.drawWorkSpace.GraphicsList.ListObjectSelected.Count;
                    if (lstSelectedCount <= 0)
                    {
                        this.tsmCopy.Enabled = false;
                        this.tsmCut.Enabled = false;
                        this.tsmDelete.Enabled = false;
                    }
                    else
                    {
                        this.tsmCopy.Enabled = true;
                        this.tsmCut.Enabled = true;
                        this.tsmDelete.Enabled = true;
                    }
                    this.tsmSelectAll.Enabled = true;
                    #endregion
                }
                else
                {
                    #region Copy|Cut|Delete|SelectAll
                    this.tsmCopy.Enabled = false;
                    this.tsmCut.Enabled = false;
                    this.tsmDelete.Enabled = false;
                    this.tsmSelectAll.Enabled = false;
                    #endregion
                }
                #endregion

                #region Paste
                if (AojClipboard.ContainsData(AojConst.ClipboardFormat.Label)
                     || AojClipboard.ContainsData(AojConst.ClipboardFormat.Image)
                        || AojClipboard.ContainsData(AojConst.ClipboardFormat.Table))
                {
                    this.tsmPaste.Enabled = true;
                }
                else
                {
                    this.tsmPaste.Enabled = false;
                }
                #endregion
            }
            else
            {
                #region Undo|Redo|Copy|Paste|Cut|Delete|SelectAll
                this.tsmUndo.Enabled = false;
                this.tsmRedo.Enabled = false;
                this.tsmCopy.Enabled = false; 
                this.tsmPaste.Enabled = false;
                this.tsmCut.Enabled = false;
                this.tsmDelete.Enabled = false;
                this.tsmSelectAll.Enabled = false;
                #endregion
            }
        }

        /// <summary>
        /// 设置编辑菜单选择项的显示情况
        /// </summary>
        /// <param name="bFlag">true,false</param>
        private void SetObjectMenuEnabled(bool bFlag)
        {
            for (int index = 0; index < this.tsmObject.DropDownItems.Count; index++)
            {
                this.tsmObject.DropDownItems[index].Enabled = bFlag;
            }
        }

        /// <summary>
        /// 初始化panel中的相关事件
        /// </summary>
        private void InitializePanleEvent()
        {
           
        }

        /// <summary>
        /// 打开报表设计文件进行文件的加载处理
        /// </summary>
        /// <param name="strXmlDocumentPath">报表格式XML文件</param>
        private void OpenReportDocument(string strXmlDocumentPath)
        {
            try
            {
                this.tsbCmbZoom.ComboBox.SelectedValue = "1.0";
                //新建报表绘制区域
                this.NewDrawWorkSpace();
                AojXmlHelper xmlHelper = new AojXmlHelper(strXmlDocumentPath);
                XmlNode rootNode = xmlHelper.objXmlDoc.SelectSingleNode("AojPaper");
                if (rootNode != null)
                {
                    #region 对报表设计器环境进行初始化设置
                    this.drawWorkSpace.Width = int.Parse(rootNode.Attributes["Width"].Value);
                    this.drawWorkSpace.Height = int.Parse(rootNode.Attributes["Height"].Value);
                    string strPaperSizeName = rootNode.Attributes["PaperSizeName"].Value;
                    this.tsbCmbPage.ComboBox.Text = strPaperSizeName;
                    this.drawWorkSpace.PaperSizeName = strPaperSizeName;          
                    this.drawWorkSpace.PageStyle = rootNode.Attributes["PageStyle"].Value;
                    bool bGridStyleFlag = Boolean.Parse(rootNode.Attributes["GridStyleFlag"].Value);
                    this.drawWorkSpace.GridStyleFlag = bGridStyleFlag;
                    this.tsbGridStyle.Checked = bGridStyleFlag;
                    bool bDrawByGridStyleFlag = Boolean.Parse(rootNode.Attributes["DrawByGridStyle"].Value);
                    this.drawWorkSpace.DrawByGridStyle = bDrawByGridStyleFlag;
                    this.tsbAutoCompute.Checked = bDrawByGridStyleFlag;
                    int intDistanceAboutGridStyle = int.Parse(rootNode.Attributes["DistanceAboutGridStyle"].Value);
                    this.drawWorkSpace.DistanceAboutGridStyle = intDistanceAboutGridStyle;
                    this.tsbTxtGridStyle.Text = intDistanceAboutGridStyle.ToString();
                    //根据选择的纸张大小对绘制的纸张大小进行重新设置
                    this.ResetDrawWorkSpaceSize(this.tsbCmbPage.ComboBox.SelectedValue.ToString());       
                    #endregion

                    //获得报表区域的相关的对象
                    AojCommonFnc.OpenFromReportDocument(this.drawWorkSpace, strXmlDocumentPath);
                }
            }
            catch {
                //根据选择的纸张大小对绘制的纸张大小进行重新设置
                this.ResetDrawWorkSpaceSize(this.tsbCmbPage.ComboBox.SelectedValue.ToString());
                this.drawWorkSpace.PaperSizeName = this.tsbCmbPage.ComboBox.Text;
            }

            this.drawWorkSpace.ReportDocumentURL = strXmlDocumentPath;
        }

        /// <summary>
        /// 对报表设计文件进行保存相关处理
        /// </summary>
        private void SaveReportDocument()
        {
            if (this.drawWorkSpace != null)
            {
                if (string.IsNullOrEmpty(this.drawWorkSpace.ReportDocumentURL))
                {
                    if (DialogResult.OK == this.aojSaveFileDialog.ShowDialog(this))
                    {
                        this.drawWorkSpace.ReportDocumentURL = this.aojSaveFileDialog.FileName;
                        FileStream fs = new FileStream(this.drawWorkSpace.ReportDocumentURL, FileMode.Create);
                        fs.Close();
                        fs.Dispose();
                    }
                }
                if (!string.IsNullOrEmpty(this.drawWorkSpace.ReportDocumentURL))
                {
                    AojCommonFnc.SaveReportDocument(this.drawWorkSpace.ReportDocumentURL, this.drawWorkSpace);
                }                
            }
        }

        /// <summary>
        /// 打开报表设计文件
        /// </summary>
        private void OpenFile()
        {
            if (DialogResult.OK == this.aojOopenFileDialog.ShowDialog(this))
            {
                this.OpenReportDocument(this.aojOopenFileDialog.FileName);
            }
        }

        /// <summary>
        /// 根据情况激活工具栏
        /// </summary>
        /// <param name="bEnabled">是否激活标志</param>
        private void ShowTools(bool bEnabled)
        {
            this.tsbSave.Enabled = bEnabled;
            this.tsbPointer.Enabled = bEnabled;
            this.tsbLabel.Enabled = bEnabled;
            this.tsbTable.Enabled = bEnabled;
            this.tsbImage.Enabled = bEnabled;
        }
        
        #endregion 
    }
}
