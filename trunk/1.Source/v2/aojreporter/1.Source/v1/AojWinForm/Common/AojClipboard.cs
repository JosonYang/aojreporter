#region 翱捷报表软件
/**********************************************
 * 版权：Copyright @2009 翱捷报表
 * 
 * 
 * 描述：实现报表设计器中的剪贴板动作
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

namespace AojReport.AojWinForm.Common
{
    /// <summary>
    /// 实现报表设计器中的剪贴板动作
    /// </summary>
    public static class AojClipboard
    {
        #region Method(方法)

        /// <summary>
        /// 将剪贴板上的所有信息清除
        /// </summary>
        public static void Clear()
        {
            try
            {
                Clipboard.Clear();
            }
            catch 
            {
                //发生异常时候的处理 
            }
        }

        /// <summary>
        /// 在剪贴板上检查是否存在自定义格式的相关内容
        /// </summary>
        /// <param name="format">自定义格式</param>
        /// <returns>存在:True 不存在:False</returns>
        public static bool ContainsData(string format)
        {
            try
            {
                return Clipboard.ContainsData(format);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 从剪贴板上获得指定自定义格式的相关数据
        /// </summary>
        /// <param name="format">指定自定义格式</param>
        /// <returns>指定格式的相关数据</returns>
        public static object GetData(string format)
        {
            try
            {
                return Clipboard.GetData(format);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 将指定的自定义格式的相关数据存到剪贴板上
        /// </summary>
        /// <param name="data">要放置在系统剪贴板上的数据对象</param>
        /// <param name="copy">一个布尔参数，该参数指示应用程序退出时是否将数据对象保留在剪贴板中</param>
        public static void SetData(DataObject data,bool copy)
        {
            try
            {
                Clipboard.SetDataObject(data, copy);
            }
            catch
            {
                //发生异常时候的处理 
            }
        }

        #endregion
    }
}
