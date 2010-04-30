#region 翱捷报表软件
/**********************************************
 * 版权：Copyright @2009 翱捷报表
 * 
 * 
 * 描述：对工作区域的各对象操作的历史记录进行Undo操作
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
using AojReport.AojWinForm.ReportObjects;
using AojReport.AojWinForm.Common;

namespace AojReport.AojWinForm.Action
{
    /// <summary>
    /// 对工作区域的各对象操作的历史记录进行Undo操作
    /// </summary>
    public class AojHistoryUndoAction : IAojAction
    {
        #region IAojAction Members

        /// <summary>
        /// 对工作区域的各对象操作的历史记录进行Undo操作
        /// </summary>
        /// <param name="drawWorkspace">工作区域</param>
        public void PerformAction(DrawWorkSpace drawWorkspace)
        {
            int countOfListHistoryUndo = drawWorkspace.ListHistoryUndo.Count;
            if (countOfListHistoryUndo > 0)
            {
                drawWorkspace.GraphicsList.Clear();
                if (countOfListHistoryUndo > 1)
                {
                    #region 回到上一个历史记录的状态
                    AojReportObjectCollection lstTemp = AojCommonFnc.CopyReportObject(drawWorkspace.ListHistoryUndo[1]);
                    drawWorkspace.GraphicsList = lstTemp;
                    //记录报表设计区域历史记录Redo的相关对象集合
                    lstTemp = AojCommonFnc.CopyReportObject(drawWorkspace.ListHistoryUndo[0]);
                    drawWorkspace.ListHistoryRedo.Insert(0, lstTemp); 
                    //每进行一次Undo操作就从Undo历史记录中去掉一个
                    drawWorkspace.ListHistoryUndo.RemoveAt(0);
                    #endregion
                }
                else
                {
                    //回到历史记录的初始状态
                    AojReportObjectCollection lstTemp = AojCommonFnc.CopyReportObject(drawWorkspace.ListHistoryUndo[0]);
                    drawWorkspace.GraphicsList = lstTemp;
                }

                #region 对相关size进行缩放处理
                foreach (AojReportObject item in  drawWorkspace.GraphicsList)
                {
                    SetObjectSizeByPagesizePercent(item, drawWorkspace.PagesizePercent);
                }
                #endregion

                drawWorkspace.Refresh();
            }
        }

        #endregion

        #region Private(私有方法)

        /// <summary>
        /// 根据选择的倍率对指定对象的相关size进行缩放处理
        /// </summary>
        /// <param name="objectItem">指定对象</param>
        /// <param name="pagesizePercent">选择的倍率</param>
        private void SetObjectSizeByPagesizePercent(AojReportObject objectItem, float pagesizePercent)
        {
            float objectCurrentPagesizePercent = objectItem.ObjectCurrentPagesizePercent;

            #region 根据选择的倍率对相关size进行缩放的详细处理
            //对象顶端位置
            objectItem.Top = objectItem.Top / objectCurrentPagesizePercent * pagesizePercent;
            //对象左端位置
            objectItem.Left = objectItem.Left / objectCurrentPagesizePercent * pagesizePercent;
            //对象宽度
            objectItem.Width = objectItem.Width / objectCurrentPagesizePercent * pagesizePercent;
            //对象高度
            objectItem.Height = objectItem.Height / objectCurrentPagesizePercent * pagesizePercent;
            //文本的字体大小
            objectItem.TextFontSize = objectItem.TextFontSize / objectCurrentPagesizePercent * pagesizePercent;
            #endregion

            objectItem.ObjectCurrentPagesizePercent = pagesizePercent;
        }

        #endregion
    }
}
