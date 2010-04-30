using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace AojReport.AojPrintEngine.CustomException
{
    internal class XmlOperateException : XmlException
    {
        public override string Message
        {
            get
            {
                return "Xml操作错误!-AojReportCustomException";
            }
        }

        public XmlOperateException() : base() { }

        public XmlOperateException(string message)
            :base(message)
        {
 
        }

    }
}
