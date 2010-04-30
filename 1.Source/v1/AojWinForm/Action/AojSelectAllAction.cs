#region 翱捷报表软件
/**********************************************
 * 版权：Copyright @2009 翱捷报表
 * 
 * 
 * 描述：对工作区域的对象进行全部选中动作
 * 
 * 
 * 日期：
 * 
 **********************************************/
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using AojReport.AojWinForm.Common;
using AojReport.AojWinForm.ReportObjects;

namespace AojReport.AojWinForm.Action
{
    /// <summary>
    /// 对工作区域的对象进行全部选中动作
    /// </summary>
    public class AojSelectAllAction : IAojAction
    {
        #region IAojAction Members

        /// <summary>
        /// 对指定的工作区域的对象进行全部选中的详细处理动作
        /// </summary>
        /// <param name="drawWorkspace">指定的工作区域</param>
        public void PerformAction(DrawWorkSpace drawWorkspace)
        {
            drawWorkspace.GraphicsList.SelectAll();
            drawWorkspace.Refresh();
        }

        #endregion
    }
}
