#region 翱捷报表软件
/**********************************************
 * 版权：Copyright @2009 翱捷报表
 * 
 * 
 * 描述：实现报表设计器中的的对象序列化和反
 *       序列化操作.
 * 
 * 日期：
 * 
 **********************************************/
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Reflection;
using AojReport.AojWinForm.ReportObjects;

namespace AojReport.AojWinForm.Common
{
    /// <summary>
    /// 实现报表设计器中的的对象序列化和反序列化操作.
    /// </summary>
    public static class AojSerializer
    {
        #region Method(方法)

        /// <summary>
        /// 序列化指定的对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="objectList">对象</param>
        /// <returns>序列化指定的对象后的XML字符串</returns>
        public static string Serialize<T>(T objectList)
        {
            using (StringWriter sw = new StringWriter())
            {
                XmlSerializer xz = new XmlSerializer(typeof(T));
                xz.Serialize(sw, objectList);
                return sw.ToString();
            }
        }

        /// <summary>
        /// 反序列化为指定的对象
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="xmlInfo">序列化指定的对象后的XML字符串</param>
        /// <returns>反序列化为指定的对象</returns>
        public static object Deserialize(Type type, string xmlInfo)
        {
            using (StringReader srInfo = new StringReader(xmlInfo))
            {
                XmlSerializer xzTool = new XmlSerializer(type);
                return xzTool.Deserialize(srInfo);
            }
        }

        #endregion
    }
}
