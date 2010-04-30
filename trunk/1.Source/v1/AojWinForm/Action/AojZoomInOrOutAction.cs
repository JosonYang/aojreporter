#region 翱捷报表软件
/**********************************************
 * 版权：Copyright @2009 翱捷报表
 * 
 * 
 * 描述：对工作区域的对象进行缩放动作
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
    /// 对工作区域的对象进行缩放动作
    /// </summary>
    public class AojZoomInOrOutAction : IAojAction
    {
        #region Method(方法)

        #region IAojAction Members

        /// <summary>
        /// 对指定的工作区域的对象进行缩放的详细处理动作
        /// </summary>
        /// <param name="drawWorkspace">指定的工作区域</param>
        public void PerformAction(DrawWorkSpace drawWorkspace)
        {
            //对报表设计区域为网格布局(GridStyle)时各点的距离的放大
            this.SetDistanceAboutGridStyleByPagesizePercent(drawWorkspace);
            //根据选择的倍率对报表设计区域的所有对象进行缩放处理
            this.SetReportObjectSizeByPagesizePercent(drawWorkspace);
            drawWorkspace.Refresh();
        }

        #endregion

        #region Private(私有方法)

        /// <summary>
        /// 对报表设计区域为网格布局(GridStyle)时各点的距离的放大
        /// </summary>
        /// <param name="drawWorkspace">指定的工作区域</param>
        private void SetDistanceAboutGridStyleByPagesizePercent(DrawWorkSpace drawWorkspace)
        {
            //指定报表设计区域为网格布局(GridStyle)时
            if (drawWorkspace.GridStyleFlag)
            {
                drawWorkspace.DistanceAboutGridStyle = (int)(drawWorkspace.NormalDistanceAboutGridStyle * drawWorkspace.PagesizePercent);
            }
        }

        /// <summary>
        /// 根据选择的倍率对报表设计区域的所有对象进行缩放处理
        /// </summary>
        /// <param name="drawWorkspace">指定的工作区域</param>
        private void SetReportObjectSizeByPagesizePercent(DrawWorkSpace drawWorkspace)
        {
            //对报表设计器中的所有对象进行遍历
            foreach (AojReportObject objectItem in drawWorkspace.GraphicsList)
            {
                //获得选择的倍率信息
                float pagesizePercent = drawWorkspace.PagesizePercent;
                //根据选择的倍率对指定对象的相关size进行缩放处理
                this.SetObjectSizeByPagesizePercent(objectItem, pagesizePercent);
            }
        }

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

        #endregion
    }
}
