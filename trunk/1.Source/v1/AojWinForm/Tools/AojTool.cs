#region 翱捷报表软件
/**********************************************
 * 版权：Copyright @2009 翱捷报表
 * 
 * 
 * 描述：各种对象的基本行为
 * 
 * 
 * 日期：
 * 
 **********************************************/
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using AojReport.AojWinForm;
using AojReport.AojWinForm.ReportObjects;
using AojReport.AojWinForm.Common;

namespace AojReport.AojWinForm.Tools
{
    /// <summary>
    /// 各种对象的基本行为
    /// </summary>
    public class AojTool : IAojObjectActive
    {
        #region Constructor(构造函数)

        /// <summary>
        /// Constructor(构造函数)
        /// </summarys
        public AojTool() { }

        #endregion

        #region Field(变量)

        //在绘制对象时,指针的显示状态
        private Cursor _cursor;        
        //当前鼠标指针的操作状态
        private SelectionMode selectMode = SelectionMode.None;
        //当前鼠标指针的操作对象
        private AojReportObject aojObjectInfo;
        //记录操作对象的具体部位
        private int objectHandle;
        //开始坐标
        private PointF lastPoint = new PointF(0, 0);
        //结束坐标
        private PointF startPoint = new PointF(0, 0);
        //上一次鼠标按键按下时鼠标光标位置
        private PointF LastMousePosition = new PointF(-1, -1);

        #endregion

        #region Enum(枚举)

        /// <summary>
        /// 鼠标指针的操作状态
        /// </summary>
        public enum SelectionMode
        {
            None,
            BlankNetSelection,
            Move,
            Size
        }

        #endregion

        #region Method(方法)

        /// <summary>
        /// 报表设计器区域鼠标的MouseDown操作
        /// </summary>
        /// <param name="drawWorkspace">报表设计器区域</param>
        /// <param name="e">鼠标事件参数</param>
        public void PerFormMouseDown(DrawWorkSpace drawWorkspace, MouseEventArgs e)
        {
            #region 给绘制对象定义相关size信息
            //对象左端位置
            Single objectLeft;
            //对象顶端位置
            Single objectTop;
            #endregion

            switch (drawWorkspace.ActiveTool)
            {
                case AojConst.DrawToolType.Label:
                    int countLabelInfo = drawWorkspace.GraphicsList.GetSpecialObjectCountInfo(AojConst.DrawToolType.Label);
                    //对象左端位置
                    objectLeft = this.GetDrawSizeByGridStyle(drawWorkspace, e.X);
                    //对象顶端位置
                    objectTop = this.GetDrawSizeByGridStyle(drawWorkspace, e.Y);
                    AojLabel lbTool = new AojLabel(AojConst.NamePrefix.Label + countLabelInfo, AojConst.NamePrefix.Label + countLabelInfo, objectLeft, objectTop, 100, 25);
                    lbTool.IsMouseDownFlag = true;
                    lbTool.ObjectCurrentPagesizePercent = drawWorkspace.PagesizePercent;
                    AddNewObject(drawWorkspace, lbTool);
                    break;
                case AojConst.DrawToolType.Table:
                    int countTableInfo = drawWorkspace.GraphicsList.GetSpecialObjectCountInfo(AojConst.DrawToolType.Table);
                    //对象左端位置
                    objectLeft = this.GetDrawSizeByGridStyle(drawWorkspace, e.X);
                    //对象顶端位置
                    objectTop = this.GetDrawSizeByGridStyle(drawWorkspace, e.Y);
                    AojTable tbTool = new AojTable(AojConst.NamePrefix.Table + countTableInfo, AojConst.NamePrefix.Table + countTableInfo, objectLeft, objectTop, 50, 25);
                    tbTool.IsMouseDownFlag = true;
                    tbTool.ObjectCurrentPagesizePercent = drawWorkspace.PagesizePercent;
                    AddNewObject(drawWorkspace, tbTool);
                    break;
                case AojConst.DrawToolType.Image:
                    int countImageInfo = drawWorkspace.GraphicsList.GetSpecialObjectCountInfo(AojConst.DrawToolType.Image);
                    //对象左端位置
                    objectLeft = this.GetDrawSizeByGridStyle(drawWorkspace, e.X);
                    //对象顶端位置
                    objectTop = this.GetDrawSizeByGridStyle(drawWorkspace, e.Y);
                    AojImage imgTool = new AojImage(AojConst.NamePrefix.Image + countImageInfo, AojConst.NamePrefix.Image + countImageInfo, objectLeft, objectTop, 80, 100);
                    imgTool.IsMouseDownFlag = true;
                    imgTool.ObjectCurrentPagesizePercent = drawWorkspace.PagesizePercent;
                    AddNewObject(drawWorkspace, imgTool);
                    break;
                case AojConst.DrawToolType.Pointer:
                    //报表设计器区域没有要绘制的对象时,鼠标的MouseDown操作
                    this.DoPointerMouseDown(drawWorkspace, e);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 报表设计器区域鼠标的MouseMove操作
        /// </summary>
        /// <param name="drawWorkspace">报表设计器区域</param>
        /// <param name="e">鼠标事件参数</param>
        public void PerFormMouseMove(DrawWorkSpace drawWorkspace, MouseEventArgs e)
        {
            #region 给绘制对象定义相关size信息
            //对象左端位置
            Single objectLeft;
            //对象顶端位置
            Single objectTop;
            #endregion

            switch (drawWorkspace.ActiveTool)
            {
                case AojConst.DrawToolType.Label:
                case AojConst.DrawToolType.Table:
                case AojConst.DrawToolType.Image:
                    //在绘制对象时,设置指针的显示状态
                    this.SetDrawWorkspaceCursor(drawWorkspace);
                    if (e.Button == MouseButtons.Left)
                    {
                        //对象左端位置
                        objectLeft = this.GetDrawSizeByGridStyle(drawWorkspace, e.X);
                        //对象顶端位置
                        objectTop = this.GetDrawSizeByGridStyle(drawWorkspace, e.Y);

                        PointF pointf = new PointF(objectLeft, objectTop);
                        drawWorkspace.GraphicsList.ListObjectSelected[0].MoveHandleTo(pointf, 5);
                        drawWorkspace.Refresh();
                    }
                    break;
                case AojConst.DrawToolType.Pointer:
                    drawWorkspace.Cursor = null;
                    //报表设计器区域没有要绘制的对象时,鼠标的MouseMove操作
                    this.DoPointerMouseMove(drawWorkspace, e);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 报表设计器区域鼠标的MouseUp操作
        /// </summary>
        /// <param name="drawWorkspace">报表设计器区域</param>
        /// <param name="e">鼠标事件参数</param>
        public void PerFormMouseUp(DrawWorkSpace drawWorkspace, MouseEventArgs e)
        {
            switch (drawWorkspace.ActiveTool)
            {
                case AojConst.DrawToolType.Label:
                case AojConst.DrawToolType.Table:
                case AojConst.DrawToolType.Image:
                    AojReportObject objectSelected = drawWorkspace.GraphicsList.ListObjectSelected[0];
                    objectSelected.IsMouseDownFlag = false;
                    objectSelected.Normalize();
                    drawWorkspace.Capture = false;
                    drawWorkspace.Refresh();
                    break;
                case AojConst.DrawToolType.Pointer:
                    /*
                     * 说明:如果现在鼠标表现出来的状态是,没有对设计器区域中的任何一个对象进行操作,而是
                     *      自己在设计器区域中画空白的区域,则此时应该选中包含在所画区域中的所有对象.*/
                    if (selectMode == SelectionMode.BlankNetSelection)
                    {
                        drawWorkspace.GraphicsList.SelectInRectangle(drawWorkspace.BlankNetRectangle);
                        selectMode = SelectionMode.None;
                        drawWorkspace.DrawBlankNetFlag = false;
                    }

                    /*
                     * 说明:如果此时鼠标操作的对象不为NULL,则应该释放掉*/
                    if (aojObjectInfo != null)
                    {
                        aojObjectInfo.Left = this.GetDrawSizeByGridStyle(drawWorkspace, (int)aojObjectInfo.Left);
                        aojObjectInfo.Top = this.GetDrawSizeByGridStyle(drawWorkspace, (int)aojObjectInfo.Top);
                        aojObjectInfo.IsMouseDownFlag = false;
                        aojObjectInfo.Normalize();
                        aojObjectInfo = null;
                    }

                    drawWorkspace.Capture = false;
                    drawWorkspace.Refresh();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 向报表设计器区域中加入当前绘制的对象
        /// </summary>
        /// <param name="drawWorkspace">报表设计器区域</param>
        /// <param name="objectInfo">当前绘制的对象</param>
        public void AddNewObject(DrawWorkSpace drawWorkspace, AojReportObject objectInfo)
        {
            drawWorkspace.GraphicsList.UnselectAll();
            drawWorkspace.GraphicsList.Add(objectInfo);
            drawWorkspace.Capture = true;
            drawWorkspace.Refresh();
        }

        /// <summary>
        /// 在绘制对象时,设置指针的显示状态
        /// </summary>
        /// <param name="drawWorkspace">报表设计器区域</param>
        private void SetDrawWorkspaceCursor(DrawWorkSpace drawWorkspace)
        {
            string strApplicationPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            strApplicationPath = strApplicationPath.Substring(0, strApplicationPath.Length - 10);
            string strCursorPath = string.Concat(strApplicationPath, @"Images\Cursor\Rectangle.cur");
            this._cursor = new Cursor(strCursorPath);
            drawWorkspace.Cursor = this._cursor;
        }

        /// <summary>
        /// 报表设计器区域没有要绘制的对象时,鼠标的MouseDown操作
        /// </summary>
        /// <param name="drawArea">报表设计器区域</param>
        /// <param name="e">鼠标事件参数</param>
        private void DoPointerMouseDown(DrawWorkSpace drawWorkspace, MouseEventArgs e)
        {
            //将鼠标指针的操作状态变为:SelectionMode.None
            selectMode = SelectionMode.None;
            //当前鼠标指针的坐标位置
            PointF pointf = new PointF(e.X, e.Y);
            //将当前鼠标按下的坐标位置保存为上一次鼠标按下时的光标位置
            LastMousePosition = pointf;
            //获得报表设计器区域的所有对象的个数
            int objectCount = drawWorkspace.GraphicsList.Count;
            int startIndex = 0;//为开始遍历所有对象做准备
            AojReportObject tmpObject;

            #region 鼠标为指针时候,引发MouseDown事件的相关操作一

            /*******************************************************************************
             * 说明: 鼠标为指针时候,引发MouseDown事件.下面执行判断:鼠标此时操作是      
             *       不是对报表设计器区域某一对象上的具体的八个部位的其中一个进行        
             *       操作.                                                               
             *                                                                            
             *       如果是,则可以判断此时鼠标的操作是对该对象的大小进行操作,即:           
             *       SelectionMode.Size.否则,跳过。                                        
             *******************************************************************************/

            while (startIndex < objectCount)
            {
                //根据索引获得具体指定的对象
                tmpObject = drawWorkspace.GraphicsList.GetObjectByIndex(startIndex);
                //获得对象上的指定坐标的具体区域
                int handleNumber = tmpObject.GetHandleNumberByPoint(pointf);
                if (handleNumber > 0)
                {
                    //将鼠标指针的操作状态变为:SelectionMode.Size
                    selectMode = SelectionMode.Size;
                    aojObjectInfo = tmpObject;
                    //记录操作该对象的具体部位
                    objectHandle = handleNumber;
                    //释放报表设计器区域所有被选择了的对象
                    drawWorkspace.GraphicsList.UnselectAll();
                    //选中当前要操作对象
                    tmpObject.Selected = true;
                    tmpObject.IsMouseDownFlag = true;
                    //用来保存报表设计器区域被选中的对象
                    drawWorkspace.GraphicsList.ListObjectSelected.Insert(0, tmpObject);
                    break;
                }
                startIndex += 1;
            }

            #endregion

            #region 鼠标为指针时候,引发MouseDown事件的相关操作二

            /*******************************************************************************
             * 说明: 鼠标为指针时候,引发MouseDown事件.下面执行判断:鼠标此时操作是         
             *       不是对报表设计器区域某一对象进行拖动操作.                            
             *                                                                             
             *       如果是,则可以判断此时鼠标的操作是对该对象进行拖动操作,即:             
             *       SelectionMode.Move.否则,跳过。                                       
             *******************************************************************************/
            
            //若果经过上面的操作,这是鼠标还是没有进行任何操作,则进行下面的动作
            if (selectMode == SelectionMode.None)
            {
                tmpObject = null;
                startIndex = 0;//为开始遍历所有对象做准备

                while (startIndex < objectCount)
                {
                    //根据索引获得具体指定的对象
                    tmpObject = drawWorkspace.GraphicsList.GetObjectByIndex(startIndex);
                    //判断当前指定的坐标是否在对象中
                    if (tmpObject.GetHandleNumberByPoint(pointf) == 0)
                    {
                        aojObjectInfo = tmpObject;
                        break;
                    }
                    startIndex += 1;
                }

                //如果当前指定的坐标是在对象中,则可以确定此时鼠标是在对其进行拖动操作
                if (aojObjectInfo != null)
                {
                    //将鼠标指针的操作状态变为:SelectionMode.Move
                    selectMode = SelectionMode.Move;
                    if (((Control.ModifierKeys == 0) || (Keys.Control == 0)) && (!aojObjectInfo.Selected))
                    {
                        //释放报表设计器区域所有被选择了的对象
                        drawWorkspace.GraphicsList.UnselectAll();
                    }

                    //选中当前要操作对象
                    aojObjectInfo.Selected = true;
                    aojObjectInfo.IsMouseDownFlag = true;
                    //用来保存报表设计器区域被选中的对象
                    if (drawWorkspace.GraphicsList.ListObjectSelected.Contains(aojObjectInfo))
                    {
                        drawWorkspace.GraphicsList.ListObjectSelected.Remove(aojObjectInfo);
                    }
                    drawWorkspace.GraphicsList.ListObjectSelected.Insert(0, aojObjectInfo);
                    drawWorkspace.Cursor = Cursors.SizeAll;
                }
            }

            #endregion

            #region 鼠标为指针时候,引发MouseDown事件的相关操作三

            /*******************************************************************************
             * 说明: 鼠标为指针时候,引发MouseDown事件.下面执行判断:鼠标此时操作是         
             *       不是没有对报表设计器区域的任何一个对象进行操作.                       
             *                                                                            
             *       如果是,则可以判断此时鼠标没有对报表设计器区域的任何一个对象进行操作, 
             *       即:SelectionMode.BlankNetSelection.否则,跳过。                        
             *******************************************************************************/

            //若果经过上面的两种情况的操作,这是鼠标还是没有进行任何操作,则进行下面的动作
            if (selectMode == SelectionMode.None)
            {
                if (Control.ModifierKeys == 0 && Keys.Control == 0)
                {
                    //释放报表设计器区域所有被选择了的对象
                    drawWorkspace.GraphicsList.UnselectAll();
                }
                //将鼠标指针的操作状态变为:SelectionMode.BlankNetSelection
                selectMode = SelectionMode.BlankNetSelection;
                drawWorkspace.DrawBlankNetFlag = true;
            }

            #endregion

            #region 记录当前鼠标的起始位置
            lastPoint.X = e.X;
            lastPoint.Y = e.Y;
            startPoint.X = e.X;
            startPoint.Y = e.Y;
            #endregion

            drawWorkspace.Capture = true;
            AojReportObject aojBlankObject = new AojReportObject();
            drawWorkspace.BlankNetRectangle = aojBlankObject.GetObjectRectangle(startPoint, lastPoint);
            drawWorkspace.Refresh();           
        }

        /// <summary>
        /// 报表设计器区域没有要绘制的对象时,鼠标的MouseMove操作
        /// </summary>
        /// <param name="drawArea">报表设计器区域</param>
        /// <param name="e">鼠标事件参数</param>
        private void DoPointerMouseMove(DrawWorkSpace drawWorkspace, MouseEventArgs e)
        {
            //当前鼠标指针的坐标位置
            PointF pointf = new PointF(e.X, e.Y);
            //获得报表设计器区域的所有对象的个数
            int objectCount = drawWorkspace.GraphicsList.Count;
            AojReportObject tmpObject;

            /*******************************************************************************
             * 说明: 鼠标为指针时候,引发MouseMove事件.下面执行判断:鼠标此时是不是没有点击  
             *       操作.                                                                 
             *                                                                           
             *       如果是,则可以判断此时鼠标是对报表设计器区域的指定对象的大小进行操作.  
             *******************************************************************************/

            if (e.Button == MouseButtons.None)
            {
                Cursor cursor = Cursors.Default;
                int startIndex = 0;
                while (startIndex < objectCount)
                {
                    //根据索引获得具体指定的对象
                    tmpObject = drawWorkspace.GraphicsList.GetObjectByIndex(startIndex);
                    //获得对象上的指定坐标的具体区域
                    int handleNumber = tmpObject.GetHandleNumberByPoint(pointf);
                    if (handleNumber > 0)
                    {
                        //设定操作指定对象的特定区域时的鼠标指针状态
                        cursor = tmpObject.GetHandleCursor(handleNumber);
                        break;
                    }
                    startIndex += 1;
                }
                //设定此时报表设计器区域上的鼠标指针状态
                drawWorkspace.Cursor = cursor;
                return;
            }

            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            Single dx = e.X - lastPoint.X;
            Single dy = e.Y - lastPoint.Y;
            lastPoint.X = e.X;
            lastPoint.Y = e.Y;

            if (selectMode == SelectionMode.Size)
            {
                if (aojObjectInfo != null)
                {
                    pointf.X = this.GetDrawSizeByGridStyle(drawWorkspace, (int)pointf.X);
                    pointf.Y = this.GetDrawSizeByGridStyle(drawWorkspace, (int)pointf.Y);
                    aojObjectInfo.MoveHandleTo(pointf, objectHandle);
                    drawWorkspace.Refresh();
                }
            }

          /*******************************************************************************
           * 说明: 鼠标为指针时候,引发MouseMove事件.下面执行判断:鼠标此时操作是         
           *       不是对报表设计器区域某一对象进行拖动操作.                           
           *                                                                          
           *       如果是,则可以判断此时鼠标的操作是对该对象进行拖动操作,即:           
           *       SelectionMode.Move.否则,跳过。                                    
           *******************************************************************************/

            if (selectMode == SelectionMode.Move)
            {
                int index = 0;
                AojReportObject objectInfo;
                while (index < objectCount)
                {
                    objectInfo = drawWorkspace.GraphicsList.GetObjectByIndex(index);
                    if (objectInfo.Selected)
                    {
                        objectInfo.Move(dx, dy);
                    }
                    index += 1;
                }
                drawWorkspace.Cursor = Cursors.SizeAll;
                drawWorkspace.Refresh();
            }

           /*******************************************************************************
            * 说明: 鼠标为指针时候,引发MouseMove事件.下面执行判断:鼠标此时操作是     
            *       不是没有对报表设计器区域的任何一个对象进行操作.                     
            *                                                                           
            *       如果是,则可以判断此时鼠标没有对报表设计器区域的任何一个对象进行操作, 
            *       即:SelectionMode.BlankNetSelection.否则,跳过。                       
            *******************************************************************************/

            if (selectMode == SelectionMode.BlankNetSelection)
            {
                AojReportObject aojBlankObject = new AojReportObject();
                drawWorkspace.BlankNetRectangle = aojBlankObject.GetObjectRectangle(startPoint, lastPoint);
                drawWorkspace.Refresh();
                return;
            }
        }

        /// <summary>
        /// 根据指定报表设计器在绘制对象的时候是否参照网格布局(GridStyle)时各点的距离标志,
        /// 来获得当前的实际对象大小.
        /// </summary>
        /// <param name="drawWorkspace">报表设计器区域</param>
        /// <param name="sizeInfo">对象大小信息</param>
        /// <returns></returns>
        private int GetDrawSizeByGridStyle(DrawWorkSpace drawWorkspace, int sizeInfo)
        {
            //参照了网格布局(GridStyle)时各点的距离
            if (drawWorkspace.DrawByGridStyle)
            {
                //获得指定报表设计区域为网格布局(GridStyle)时各点的距离
                int distanceAboutGridStyle = drawWorkspace.DistanceAboutGridStyle;
                float tempInfo = sizeInfo % distanceAboutGridStyle;
                int halfOfdistanceAboutGridStyle = distanceAboutGridStyle / 2;
                if (tempInfo >= halfOfdistanceAboutGridStyle)
                {
                    return sizeInfo / distanceAboutGridStyle * distanceAboutGridStyle + distanceAboutGridStyle;
                }
                else
                {
                    return sizeInfo / distanceAboutGridStyle * distanceAboutGridStyle;
                }
            }
            //如果在绘制对象的时候没有参照网格布局(GridStyle)时各点的距离,则直接返回
            return sizeInfo;
        }

        #endregion
    }
}
