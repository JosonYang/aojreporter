using System;

namespace AojReport.AojPrintEngine.AojPrintGraphicsParse
{
    internal enum ImageFlags
    {
        //直接读取存储在硬盘上的图片文件
        File = 1,
        //存储文件中二进制的字符串
        Cache = 2,
    }
}