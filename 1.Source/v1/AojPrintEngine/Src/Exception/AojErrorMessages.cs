using System;
using System.Collections.Generic;
using System.Text;

namespace AojReport.AojPrintEngine.Common
{
    internal class AojErrorMessages
    {
        /// <summary>
        /// 路径尚未初始化
        /// </summary>
        public static readonly string NULLPATHURL = "路径没有初始化，翱捷数据文件无法输出到指定目录！";

        /// <summary>
        /// 打印状态为Close的时候进行了编辑节点等操作
        /// </summary>
        public static readonly string PRINTNOTOPEN = "打印未初始化,请先使用Parse(url)初始化！";

        public static readonly string PRINTNOPRINTING = "打印状态不对，请在BeginPrint和EndPrint编辑完后进行打印！";
    }
}
