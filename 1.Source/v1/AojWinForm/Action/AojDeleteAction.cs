#region 翱捷报表软件
/**********************************************
 * 版权：Copyright @2009 翱捷报表
 * 
 * 
 * 描述：对工作区域的对象进行删除动作
 * 
 * 
 * 日期：
 * 
 **********************************************/
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using AojReport.AojWinForm.ReportObjects;
using AojReport.AojWinForm.Common;

namespace AojReport.AojWinForm.Action
{
    /// <summary>
    /// 对工作区域的对象进行删除动作
    /// </summary>
    public class AojDeleteAction : IAojAction
    {
        #region IAojAction Members

        /// <summary>
        /// 对指定的工作区域的对象进行删除的详细处理动作
        /// </summary>
        /// <param name="drawWorkspace">指定的工作区域</param>
        public void PerformAction(DrawWorkSpace drawWorkspace)
        {
            AojReportObject objectItem;
            for (int index = drawWorkspace.GraphicsList.ListObjectSelected.Count - 1; index >= 0; index--)
            {
                objectItem = drawWorkspace.GraphicsList.ListObjectSelected[index];
                drawWorkspace.GraphicsList.Delete(objectItem);
            }

            #region 记录报表设计区域历史记录Undo的相关对象集合
            if (!AojCommonFnc.EqualsReportObject(drawWorkspace.GraphicsList, drawWorkspace.ListHistoryUndo[0]))
            {
                AojReportObjectCollection lstTemp = AojCommonFnc.CopyReportObject(drawWorkspace.GraphicsList);
                drawWorkspace.ListHistoryUndo.Insert(0, lstTemp);
            }
            #endregion

            drawWorkspace.Refresh();
        }

        #endregion
    }
}
