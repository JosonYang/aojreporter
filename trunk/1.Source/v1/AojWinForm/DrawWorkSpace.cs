#region 翱捷报表软件
/**********************************************
 * 版权：Copyright @2009 翱捷报表
 * 
 * 
 * 描述：报表设计区的设计区域
 * 
 * 
 * 日期：
 * 
 **********************************************/
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using AojReport.AojWinForm.ReportObjects;
using AojReport.AojWinForm.Common;
using AojReport.AojWinForm.Tools;
using AojReport.AojWinForm.Action;
using AojReport.AojWinForm.ObjectProperties;

namespace AojReport.AojWinForm
{
    /// <summary>
    /// 报表设计区的设计区域
    /// </summary>
    public partial class DrawWorkSpace : UserControl
    {
        #region Constructor(构造函数)

        /// <summary>
        /// Constructor(构造函数)
        /// </summary>
        public DrawWorkSpace()
        {
            InitializeComponent();
            //解决由于重绘而导致的刷屏问题
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            //在控件接收焦点时发生。 
            this.GotFocus += new EventHandler(DrawWorkSpace_GotFocus);
            //当控件失去焦点时发生。
            this.LostFocus += new EventHandler(DrawWorkSpace_LostFocus);
            //对报表设计器中将要用到的一些动作类进行初始化,比如工作区缩放，历史操作等等
            this.InitializeActionToolsInfo();
        }
       
        #endregion

        #region Field(变量)

        //当前选中对象用于设置对象的相关属性
        private AojReportObject objectCurrentSelected = null;
        //报表设计区域的对象集合
        private AojReportObjectCollection _graphicsList;
        //记录报表设计区域历史记录Redo的相关对象集合
        private List<AojReportObjectCollection> listHistoryRedo = new List<AojReportObjectCollection>();
        //记录报表设计区域历史记录Undo的相关对象集合
        private List<AojReportObjectCollection> listHistoryUndo = new List<AojReportObjectCollection>();
        //当前设计区域正要绘制或活动的对象
        private AojConst.DrawToolType _activeTool = AojConst.DrawToolType.Pointer;
        //当没有选择任何要绘制的对象时的标志
        private bool bDrawBlankNetFlag = false;
        //当没有选择任何要绘制的对象时，鼠标在设计器区域移动的区域范围
        private RectangleF _blankNetRectangle;
        //报表设计器可绘制的纸张的显示方式
        private string strPageStyle = "0";
        //记录当前报表设计区域的放大倍率
        private float pagesizePercent = 1f;
        //指定控件布局时放大倍率为100%时候的正常宽度
        private int pageNormalWidth;
        //指定控件布局时放大倍率为100%时候的正常高度
        private int pageNormalHeight;
        //指定报表设计区域是否需要网格布局(GridStyle)
        private bool gridStyleFlag = true;
        //指定控件布局时放大倍率为100%时网格布局(GridStyle)时各点的正常距离
        private int aojNormalDistanceAboutGridStyle = 10;
        //指定报表设计区域为网格布局(GridStyle)时各点的距离
        private int distanceAboutGridStyle = 10;
        //指定报表设计器在绘制对象的时候是否参照网格布局(GridStyle)时各点的距离
        private bool drawByGridStyle = true;
        //报表设计器绘制的纸张的大小名称
        private string strPaperSizeName = string.Empty;
        //报表设计器文件的保存地址
        private string strReportDocumentURL = string.Empty;
        /// <summary>
        /// 用来执行报表设计器上一切操作的工具
        /// </summary>
        private AojTool baseTool = new AojTool();
        /// <summary>
        /// 对工作区域的对象进行缩放动作
        /// </summary>
        private AojZoomInOrOutAction zoomInOrOutAction;
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

        #region Const(常量)

        #endregion

        #region Enum(枚举)

        #endregion

        #region Property(属性)

        /// <summary>
        /// 报表设计区域的对象集合
        /// </summary>
        [Category("AojReport")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("报表设计区域的对象集合")]
        public AojReportObjectCollection GraphicsList
        {
            get
            {
                return _graphicsList;
            }
            set
            {
                this._graphicsList = value;
            }
        }

        /// <summary>
        /// 记录报表设计区域历史记录Redo的相关对象集合
        /// </summary>
        [Category("AojReport")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("记录报表设计区域历史记录Redo的相关对象集合")]
        public List<AojReportObjectCollection> ListHistoryRedo
        {
            get
            {
                return listHistoryRedo;
            }
            set
            {
                this.listHistoryRedo = value;
            }
        }

        /// <summary>
        /// 记录报表设计区域历史记录Undo的相关对象集合
        /// </summary>
        [Category("AojReport")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("记录报表设计区域历史记录Undo的相关对象集合")]
        public List<AojReportObjectCollection> ListHistoryUndo
        {
            get
            {
                return listHistoryUndo;
            }
            set
            {
                this.listHistoryUndo = value;
            }
        }

        /// <summary>
        /// 当前设计区域正要绘制或活动的对象
        /// </summary>
        [Category("AojReport")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(AojConst.DrawToolType.Pointer)]
        [Description("当前设计区域正要绘制或活动的对象")]
        public AojConst.DrawToolType ActiveTool
        {
            get
            {
                return _activeTool;
            }
            set
            {
                this._activeTool = value;
            }
        }

        /// <summary>
        /// 当没有选择任何要绘制的对象时的标志
        /// </summary>
        [Category("AojReport")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(true)]
        [Description("当没有选择任何要绘制的对象时的标志")]
        public bool DrawBlankNetFlag
        {
            get
            {
                return bDrawBlankNetFlag;
            }
            set
            {
                this.bDrawBlankNetFlag = value;
            }
        }

        /// <summary>
        /// 当没有选择任何要绘制的对象时，鼠标在设计器区域移动的区域范围
        /// </summary>
        [Category("AojReport")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("当没有选择任何要绘制的对象时，鼠标在设计器区域移动的区域范围")]
        public RectangleF BlankNetRectangle
        {
            get
            {
                return _blankNetRectangle;
            }
            set
            {
                this._blankNetRectangle = value;
            }
        }

        /// <summary>
        /// 指定控件布局时离父控件的上边距离
        /// </summary>
        [Category("AojReport")]
        [Browsable(false)]
        [Description("指定控件布局时离父控件的上边距离")]
        public int AojTop
        {
            get
            {
                return this.Top;
            }
            set
            {
                this.Top = value;
            }
        }

        /// <summary>
        /// 指定控件布局时离父控件的左边距离
        /// </summary>
        [Category("AojReport")]
        [Browsable(false)]
        [Description("指定控件布局时离父控件的左边距离")]
        public int AojLeft
        {
            get
            {
                return this.Left;
            }
            set
            {
                this.Left = value;
            }
        }

        /// <summary>
        /// 记录当前报表设计区域的放大倍率
        /// </summary>
        [Category("AojReport")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("记录当前报表设计区域的放大倍率")]
        public float PagesizePercent
        {
            get
            {
                return this.pagesizePercent;
            }
            set
            {
                if (this.pagesizePercent != value)
                {
                    this.pagesizePercent = value;
                    //对工作区域的对象进行缩放动作
                    zoomInOrOutAction.PerformAction(this);
                }
            }
        }

        /// <summary>
        /// 指定控件布局时放大倍率为100%时候的正常宽度
        /// </summary>
        [Category("AojReport")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("指定控件布局时放大倍率为100%时候的正常宽度")]
        public int NormalWidth
        {
            get
            {
                return this.pageNormalWidth;
            }
            set
            {
                this.pageNormalWidth = value;
            }
        }

        /// <summary>
        /// 指定控件布局时放大倍率为100%时候的正常高度
        /// </summary>
        [Category("AojReport")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("指定控件布局时放大倍率为100%时候的正常高度")]
        public int NormalHeight
        {
            get
            {
                return this.pageNormalHeight;
            }
            set
            {
                this.pageNormalHeight = value;
            }
        }

        /// <summary>
        /// 指定报表设计区域是否需要网格布局(GridStyle)
        /// </summary>
        [Category("AojReport")]
        [DefaultValue(true)]
        [Description("指定报表设计区域是否需要网格布局(GridStyle)")]
        public bool GridStyleFlag
        {
            get
            {
                return this.gridStyleFlag;
            }
            set
            {
                this.gridStyleFlag = value;
                this.drawByGridStyle = value;
            }
        }

        /// <summary>
        /// 指定报表设计区域为网格布局(GridStyle)时各点的距离
        /// </summary>
        [Category("AojReport")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(10)]
        [Description("指定报表设计区域为网格布局(GridStyle)时各点的距离")]
        public int DistanceAboutGridStyle
        {
            get
            {
                return this.distanceAboutGridStyle;
            }
            set
            {
                this.distanceAboutGridStyle = value;
            }
        }

        /// <summary>
        /// 指定控件布局时放大倍率为100%时网格布局(GridStyle)时各点的正常距离
        /// </summary>
        [Category("AojReport")]
        [DefaultValue(10)]
        [Description("指定控件布局时放大倍率为100%时网格布局(GridStyle)时各点的正常距离")]
        public int NormalDistanceAboutGridStyle
        {
            get
            {
                return this.aojNormalDistanceAboutGridStyle;
            }
            set
            {
                this.aojNormalDistanceAboutGridStyle = value;
            }
        }

        /// <summary>
        /// 指定报表设计器在绘制对象的时候是否参照网格布局(GridStyle)时各点的距离
        /// </summary>
        [Category("AojReport")]
        [DefaultValue(true)]
        [Description("指定报表设计器在绘制对象的时候是否参照网格布局(GridStyle)时各点的距离")]
        public bool DrawByGridStyle
        {
            get
            {
                return this.drawByGridStyle;
            }
            set
            {
                this.drawByGridStyle = value;
            }
        }

        /// <summary>
        /// 报表设计器可绘制的纸张的显示方式
        /// </summary>
        [Category("AojReport")]
        [Description("报表设计器可绘制的纸张的显示方式")]
        public string PageStyle
        {
            get 
            { 
                return strPageStyle; 
            }
            set
            { 
                strPageStyle = value;
            }
        }

        /// <summary>
        /// 报表设计器绘制的纸张的大小名称
        /// </summary>
        [Category("AojReport")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("报表设计器绘制的纸张的大小名称")]
        public string PaperSizeName
        {
            get
            {
                return this.strPaperSizeName;
            }
            set
            {
                strPaperSizeName = value;
            }
        }

        /// <summary>
        /// 报表设计器文件的保存地址
        /// </summary>
        [Category("AojReport")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("报表设计器文件的保存地址")]
        public string ReportDocumentURL
        {
            get
            {
                return this.strReportDocumentURL;
            }
            set
            {
                strReportDocumentURL = value;
            }
        }

        #endregion

        #region Event(事件)

        /// <summary>
        /// 报表设计器区域的相关对象绘制事件
        /// </summary>
        /// <param name="sender">报表设计器区域对象</param>
        /// <param name="e">鼠标事件参数</param>
        private void DrawWorkSpace_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush br = new SolidBrush(Color.White);
            e.Graphics.FillRectangle(br, this.ClientRectangle);

            #region 进行绘制报表器的设计区域的标尺
            if (this.gridStyleFlag)
            {
                //设定报表设计区域为网格布局(GridStyle)
                this.SetLayoutToGridStyle(this.ClientSize.Width, this.ClientSize.Height, e.Graphics);
            }            
            #endregion

            if (this._graphicsList != null && this._graphicsList.Count > 0)
            {
                this._graphicsList.DesignDraw(e.Graphics);
            }
            DrawNetSelection(e.Graphics);
            br.Dispose();
        }

        /// <summary>
        /// 报表设计器区域鼠标的MouseDown操作
        /// </summary>
        /// <param name="sender">报表设计器区域对象</param>
        /// <param name="e">鼠标事件参数</param>
        private void DrawWorkSpace_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                baseTool.PerFormMouseDown(this, e);
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.ContextMenuStrip = cmsMenu;
                //当前鼠标指针的坐标位置
                PointF pointf = new PointF(e.X, e.Y);
                //报表设计器区域鼠标的MouseDown操作(MouseButtons.Right)
                this.DoRightMouseDownBusiness(pointf);
            }
        }

        /// <summary>
        /// 报表设计器区域鼠标的MouseMove操作
        /// </summary>
        /// <param name="sender">报表设计器区域对象</param>
        /// <param name="e">鼠标事件参数</param>
        private void DrawWorkSpace_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.None)
            {
                baseTool.PerFormMouseMove(this, e);
            }
        }

        /// <summary>
        /// 报表设计器区域鼠标的MouseUp操作
        /// </summary>
        /// <param name="sender">报表设计器区域对象</param>
        /// <param name="e">鼠标事件参数</param>
        private void DrawWorkSpace_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.ContextMenuStrip = null;
                baseTool.PerFormMouseUp(this, e);

                #region 记录报表设计区域历史记录Undo的相关对象集合
                if (!AojCommonFnc.EqualsReportObject(this._graphicsList,this.listHistoryUndo[0]))
                {
                    AojReportObjectCollection lstTemp = AojCommonFnc.CopyReportObject(this._graphicsList);
                    this.listHistoryUndo.Insert(0, lstTemp);
                }               
                #endregion
            }
        }

        /// <summary>
        /// 当控件失去焦点时发生。
        /// </summary>
        /// <param name="sender">报表设计器区域对象</param>
        /// <param name="e">事件参数</param>
        private void DrawWorkSpace_LostFocus(object sender, EventArgs e)
        {
            AojHotKey.UnregisterHotKeyFromDrawSpace(Handle);
        }

        /// <summary>
        /// 在控件接收焦点时发生。 
        /// </summary>
        /// <param name="sender">报表设计器区域对象</param>
        /// <param name="e">事件参数</param>
        private void DrawWorkSpace_GotFocus(object sender, EventArgs e)
        {
            AojHotKey.RegisterHotKeyToDrawSpace(Handle);
        }

        /// <summary>
        /// 对工作区域的对象进行复制动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmCopy_Click(object sender, EventArgs e)
        {
            copyAction.PerformAction(this);
        }

        /// <summary>
        /// 对工作区域的对象进行粘贴动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmPaste_Click(object sender, EventArgs e)
        {
            pasteAction.PerformAction(this);
        }

        /// <summary>
        /// 对工作区域的对象进行剪切动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmCut_Click(object sender, EventArgs e)
        {
            cutAction.PerformAction(this);
        }

        /// <summary>
        /// 对工作区域的对象进行删除动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmDelete_Click(object sender, EventArgs e)
        {
            deleteAction.PerformAction(this);
        }

        /// <summary>
        /// 对工作区域的对象进行相关属性设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmProperties_Click(object sender, EventArgs e)
        {
            if (this.objectCurrentSelected != null)
            {
                AojConst.DrawToolType objectType = AojCommonFnc.GetObjectType<AojReportObject>(this.objectCurrentSelected);
                switch (objectType)
                {
                    case AojConst.DrawToolType.Label:
                        AojLabelProperties lbPropertiesForm = new AojLabelProperties((AojLabel)this.objectCurrentSelected);
                        lbPropertiesForm.ShowDialog(this);
                        break;
                    case AojConst.DrawToolType.Table:
                        AojTableProperties tbPropertiesForm = new AojTableProperties((AojTable)objectCurrentSelected);
                        tbPropertiesForm.ShowDialog(this);
                        break;
                    case AojConst.DrawToolType.Image:
                        AojImageProperties imgPropertiesForm = new AojImageProperties((AojImage)this.objectCurrentSelected);
                        imgPropertiesForm.ShowDialog(this);
                        break;
                    default:
                        break;
                }
                this.Refresh();
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
                        //Ctrl+Z
                        case AojHotKey.HotKeyID.hotKeyID_Undo:
                            //对工作区域的各对象操作的历史记录进行Undo操作
                            undoAction.PerformAction(this);
                            break;
                        //Ctrl+Y
                        case AojHotKey.HotKeyID.hotKeyID_Redo:
                            //对工作区域的各对象操作的历史记录进行Redo操作
                            redoAction.PerformAction(this);
                            break;
                        //Ctrl+X
                        case AojHotKey.HotKeyID.hotKeyID_Cut:
                            //对工作区域的对象进行剪切动作
                            cutAction.PerformAction(this);
                            break;
                        //Ctrl+C
                        case AojHotKey.HotKeyID.hotKeyID_Copy:
                            //对工作区域的对象进行复制动作
                            copyAction.PerformAction(this);
                            break;
                        //Ctrl+V
                        case AojHotKey.HotKeyID.hotKeyID_Paste:
                            //对工作区域的对象进行粘贴动作
                            pasteAction.PerformAction(this);
                            break;
                        //Del
                        case AojHotKey.HotKeyID.hotKeyID_Delete:
                            //对工作区域的对象进行删除动作
                            deleteAction.PerformAction(this);
                            break;
                        //Ctrl+A
                        case AojHotKey.HotKeyID.hotKeyID_SelectAll:
                            //对工作区域的对象进行全部选中动作
                            selectallAction.PerformAction(this);
                            break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// 当没有选择任何要绘制的对象时，鼠标在设计器区域移动的处理操作
        /// </summary>
        /// <param name="g">对象的绘制载体</param>
        public void DrawNetSelection(Graphics g)
        {
            if (this.bDrawBlankNetFlag == false)
            {
                return;
            }
            else
            {
                g.DrawRectangle(Pens.Black, _blankNetRectangle.X, _blankNetRectangle.Y, _blankNetRectangle.Width, _blankNetRectangle.Height);
            }
        }

        /// <summary>
        /// 设定报表设计区域为网格布局(GridStyle)
        /// </summary>
        public void SetLayoutToGridStyle(int width, int height, Graphics graphicsHander)
        {
            for (int indexWidth = this.distanceAboutGridStyle; indexWidth < width; indexWidth = indexWidth + this.distanceAboutGridStyle)
            {
                for (int indexHeight = this.distanceAboutGridStyle; indexHeight < height; indexHeight = indexHeight + this.distanceAboutGridStyle)
                {
                    graphicsHander.FillRectangle(Brushes.Black, indexWidth, indexHeight, 1, 1);
                }
            }
        }

        /// <summary>
        /// 对报表设计器中将要用到的一些动作类进行初始化,比如工作区缩放，历史操作等等
        /// </summary>
        private void InitializeActionToolsInfo()
        {
            //对工作区域的对象进行缩放动作
            zoomInOrOutAction = new AojZoomInOrOutAction();
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
        /// 报表设计器区域鼠标的MouseDown操作(MouseButtons.Right)
        /// </summary>
        /// <param name="pointf">当前鼠标指针的坐标位置</param>
        private void DoRightMouseDownBusiness(PointF pointf)
        {
            if (this._graphicsList != null && this._graphicsList.Count > 0)
            {
                #region Properties
                bool bCurrentSelectedFlag = false;
                foreach (AojReportObject objectItem in this._graphicsList)
                {
                    bCurrentSelectedFlag = objectItem.PointInObject(pointf);
                    if (bCurrentSelectedFlag)
                    {
                        this.objectCurrentSelected = objectItem;
                        if (!objectItem.Selected)
                        {
                            objectItem.Selected = true;
                            this._graphicsList.ListObjectSelected.Insert(0, objectItem);
                        }
                        break;
                    }
                }
                if (!bCurrentSelectedFlag)
                {
                    this.tsmProperties.Enabled = false;
                }
                else
                {
                    this.tsmProperties.Enabled = true;
                }
                #endregion

                #region Copy|Cut|Delete
                int lstSelectedCount = this._graphicsList.ListObjectSelected.Count;
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
                #endregion
            }
            else
            {
                #region Copy|Cut|Delete|Properties
                this.tsmCopy.Enabled = false;
                this.tsmCut.Enabled = false;
                this.tsmDelete.Enabled = false;
                this.tsmProperties.Enabled = false;
                #endregion
            }

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

            this.Refresh();
        }

        #endregion       
    }
}
