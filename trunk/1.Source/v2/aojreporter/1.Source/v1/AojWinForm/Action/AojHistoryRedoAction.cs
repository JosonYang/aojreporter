#region 翱捷报表软件
/**********************************************
 * 版权：Copyright @2009 翱捷报表
 * 
 * 
 * 描述：对工作区域的各对象操作的历史记录进行Redo操作
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
    /// 对工作区域的各对象操作的历史记录进行Redo操作
    /// </summary>
    public class AojHistoryRedoAction : IAojAction
    {
        #region IAojAction Members

        /// <summary>
        /// 对工作区域的各对象操作的历史记录进行Redo操作
        /// </summary>
        /// <param name="drawWorkspace">工作区域</param>
        public void PerformAction(DrawWorkSpace drawWorkspace)
        {
            if (drawWorkspace.ListHistoryRedo.Count > 0)
            {
                drawWorkspace.GraphicsList.Clear();
                AojReportObjectCollection lstTemp = AojCommonFnc.CopyReportObject(drawWorkspace.ListHistoryRedo[0]);
                drawWorkspace.GraphicsList = lstTemp;
                lstTemp = AojCommonFnc.CopyReportObject(drawWorkspace.GraphicsList);
                drawWorkspace.ListHistoryUndo.Insert(0, lstTemp);               
                //每进行一次Redo操作就从Redo历史记录中去掉一个
                drawWorkspace.ListHistoryRedo.RemoveAt(0);

                #region 对相关size进行缩放处理
                foreach (AojReportObject item in drawWorkspace.GraphicsList)
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
