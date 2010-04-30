#region 翱捷报表软件
/**********************************************
 * 版权：Copyright @2009 翱捷报表
 * 
 * 
 * 描述：对工作区域的各对象操作的历史记录全部清除
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
    /// 对工作区域的各对象操作的历史记录全部清除
    /// </summary>
    public class AojHistoryClearAction : IAojAction
    {
        #region IAojAction Members

        /// <summary>
        /// 对工作区域的各对象操作的历史记录全部清除
        /// </summary>
        /// <param name="drawWorkspace">工作区域</param>
        public void PerformAction(DrawWorkSpace drawWorkspace)
        {
            //记录报表设计区域历史记录Redo的相关对象集合
            drawWorkspace.ListHistoryRedo.Clear();
            //记录报表设计区域历史记录Undo的相关对象集合
            drawWorkspace.ListHistoryUndo.Clear();
            /*
             * 将历史记录清除后，就意味着历史记录从现在开始记录。*/
            AojReportObjectCollection lstTemp = AojCommonFnc.CopyReportObject(drawWorkspace.GraphicsList);
            drawWorkspace.ListHistoryUndo.Insert(0, lstTemp);
        }

        #endregion
    }
}
