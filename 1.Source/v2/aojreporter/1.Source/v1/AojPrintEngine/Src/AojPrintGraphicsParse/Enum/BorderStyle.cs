using System;

namespace AojReport.AojPrintEngine.AojPrintGraphicsParse
{
    internal enum BorderType
    {
        //
        // Summary:
        //     指定实线。
        Solid = 1,
        //
        // Summary:
        //     指定由划线段组成的直线。
        Dash = 2,
        //
        // Summary:
        //     指定由点构成的直线。
        Dot = 3,
        //
        // Summary:
        //     指定由重复的划线点图案构成的直线。
        DashDot = 4,
        //
        // Summary:
        //    指定由重复的划线点点图案构成的直线。
        DashDotDot = 5,
        //
        // Summary:
        //    不指定直线
        None = 0,
    }
}