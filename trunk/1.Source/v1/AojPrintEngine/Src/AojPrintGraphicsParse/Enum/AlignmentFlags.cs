using System;

namespace AojReport.AojPrintEngine.AojPrintGraphicsParse
{
    /// <summary>
    /// 排列方向
    /// </summary>
    internal enum AlignmentFlags
    {
        //
        // Summary:
        //     默认为中心位置。
        Defualt = 0,
        //
        // Summary:
        //     左上
        LeftTop = 1,
        //
        // Summary:
        //     左中
        LeftMiddle = 2,
        //
        // Summary:
        //     左下
        LeftBottom =3,
        //
        // Summary:
        //     中上
        CenterTop = 4,
        //
        // Summary:
        //     中间
        CenterMiddle =5,
        //
        // Summary:
        //     中下
        CenterBottom =6,
        //
        // Summary:
        //     右上
        RightTop=7,
        //
        // Summary:
        //     右中
        RightMiddle = 8,
        //
        // Summary:
        //     右下
        RightBottom = 9,
    }
}