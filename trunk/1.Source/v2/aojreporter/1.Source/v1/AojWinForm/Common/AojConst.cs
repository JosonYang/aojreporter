#region 翱捷报表软件
/**********************************************
 * 版权：Copyright @2009 翱捷报表
 * 
 * 
 * 描述：相关的系统要用到的共同配置信息
 * 
 * 
 * 日期：
 * 
 **********************************************/
#endregion
using System;
using System.Collections.Generic;
using System.Text;

namespace AojReport.AojWinForm.Common
{
    /// <summary>
    /// 相关的系统要用到的共同常量
    /// </summary>
    public static class AojConst
    {
        #region 绘制的各个对象的命名前缀

        /// <summary>
        /// 绘制的各个对象的命名前缀
        /// </summary>
        public static class NamePrefix
        {
            /// <summary>
            ///  绘制的Label对象的命名前缀
            /// </summary>
            public const string Label = "Label";
            /// <summary>
            ///  绘制的Table对象的命名前缀
            /// </summary>
            public const string Table = "Table";
            /// <summary>
            ///  绘制的Image对象的命名前缀
            /// </summary>
            public const string Image = "Image";
        }

        #endregion

        #region 报表区域绘制对象的类型

        /// <summary>
        /// 报表区域绘制对象的类型
        /// </summary>
        public enum DrawToolType
        {
            /// <summary>
            /// 报表绘制对象的文本工具(Label)
            /// </summary>
            Label,
            /// <summary>
            /// 报表绘制对象的表格工具(Table)
            /// </summary>
            Table,
            /// <summary>
            /// 报表绘制对象的图片工具(Image)
            /// </summary>
            Image,
            /// <summary>
            /// 没有绘制对象,既就是鼠标指针
            /// </summary>
            Pointer,
        }

        #endregion

        #region 将序列化的对象保存在剪贴板上的名称

        /// <summary>
        /// 将序列化的对象保存在剪贴板上的名称
        /// </summary>
        public static class ClipboardFormat
        {
            /// <summary>
            /// 将序列化的Label对象保存在剪贴板上的名称
            /// </summary>
            public const string Label = "AojLabelXmlFormat";
            /// <summary>
            /// 将序列化的Table对象保存在剪贴板上的名称
            /// </summary>
            public const string Table = "AojTableXmlFormat";
            /// <summary>
            /// 将序列化的Image对象保存在剪贴板上的名称
            /// </summary>
            public const string Image = "AojImageXmlFormat";
        }

        #endregion
    }
}
