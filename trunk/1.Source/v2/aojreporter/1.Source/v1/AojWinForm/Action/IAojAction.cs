#region 翱捷报表软件
/**********************************************
 * 版权：Copyright @2009 翱捷报表
 * 
 * 
 * 描述：定义在报表设计工作区所进行的一些基本动作的接口
 *       如：工作区缩放，历史操作等等
 * 
 * 日期：
 * 
 **********************************************/
#endregion
using System;
using System.Collections.Generic;
using System.Text;

namespace AojReport.AojWinForm.Action
{
    /// <summary>
    /// 定义在报表设计工作区所进行的一些基本动作的接口
    ///     如：工作区缩放，历史操作等等
    /// </summary>
    public interface IAojAction
    {
        /// <summary>
        /// 定义在报表设计工作区所进行的基本动作的方法
        /// </summary>
        /// <param name="drawWorkspace"></param>
        void PerformAction(DrawWorkSpace drawWorkspace);
    }
}
