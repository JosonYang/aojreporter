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
using AojReport.AojWinForm.ReportObjects;

namespace AojReport.AojWinForm.Tools
{
    /// <summary>
    /// 各种对象的基本行为
    /// </summary>
    public interface IAojObjectActive
    {
        #region Method(方法)

        /// <summary>
        /// 报表设计器区域鼠标的MouseDown操作
        /// </summary>
        /// <param name="drawWorkspace">报表设计器区域对象</param>
        /// <param name="e">鼠标事件参数</param>
        void PerFormMouseDown(DrawWorkSpace drawWorkspace, MouseEventArgs e);

        /// <summary>
        /// 报表设计器区域鼠标的MouseMove操作
        /// </summary>
        /// <param name="drawWorkspace">报表设计器区域对象</param>
        /// <param name="e">鼠标事件参数</param>
        void PerFormMouseMove(DrawWorkSpace drawWorkspace, MouseEventArgs e);

        /// <summary>
        /// 报表设计器区域鼠标的MouseUp操作
        /// </summary>
        /// <param name="drawWorkspace">报表设计器区域对象</param>
        /// <param name="e">鼠标事件参数</param>
        void PerFormMouseUp(DrawWorkSpace drawWorkspace, MouseEventArgs e);

        /// <summary>
        /// 向报表设计器区域中加入当前绘制的对象
        /// </summary>
        /// <param name="drawWorkspace">报表设计器区域</param>
        /// <param name="objectInfo">要操作的对象</param>
        void AddNewObject(DrawWorkSpace drawWorkspace, AojReportObject objectInfo);

        #endregion
    }
}
