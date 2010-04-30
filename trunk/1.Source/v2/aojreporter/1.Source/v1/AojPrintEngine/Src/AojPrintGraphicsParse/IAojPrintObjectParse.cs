using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml;

namespace AojReport.AojPrintEngine.AojPrintGraphicsParse
{
    /// <summary>
    /// Parse用来读取报表文件，并且读取报表节点属性
    /// 
    /// print用来进行打印 
    /// </summary>
    public interface IAojPrintObjectParse
    {
        void Save(XmlWriter writer);
        bool Parse(AojPrintXmlReader aojXmlReader);
        void Print(Graphics g);
    }
}
