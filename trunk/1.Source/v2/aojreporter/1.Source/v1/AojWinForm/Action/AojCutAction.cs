#region 翱捷报表软件
/**********************************************
 * 版权：Copyright @2009 翱捷报表
 * 
 * 
 * 描述：对工作区域的对象进行剪切动作
 * 
 * 
 * 日期：
 * 
 **********************************************/
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using AojReport.AojWinForm.Common;
using AojReport.AojWinForm.ReportObjects;

namespace AojReport.AojWinForm.Action
{
    /// <summary>
    /// 对工作区域的对象进行剪切动作
    /// </summary>
    public class AojCutAction : IAojAction
    {
        #region IAojAction Members

        /// <summary>
        /// 对指定的工作区域的对象进行剪切的详细处理动作
        /// </summary>
        /// <param name="drawWorkspace">指定的工作区域</param>
        public void PerformAction(DrawWorkSpace drawWorkspace)
        {
            #region 将指定的自定义格式的相关数据存到剪贴板上

            //报表设计器区域被选中的对象
            List<AojReportObject> lstObjectSelected = drawWorkspace.GraphicsList.ListObjectSelected;
            //将相关数据存到剪贴板上
            AojCommonFnc.SaveObjectToClipBoard(lstObjectSelected);

            #endregion

            #region 对工作区域选中的对象进行删除动作
            AojDeleteAction deleteAction = new AojDeleteAction();
            deleteAction.PerformAction(drawWorkspace);
            #endregion
        }

        #endregion
    }
}
