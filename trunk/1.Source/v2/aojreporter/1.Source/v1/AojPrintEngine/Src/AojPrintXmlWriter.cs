using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using AojReport.AojPrintEngine.AojPrintGraphicsParse;
using AojReport.AojPrintEngine.Common;

namespace AojReport.AojPrintEngine
{
    internal class AojPrintXmlWriter
    {
        XmlWriter writer;
        private string _url;
        private Encoding _encoding = Encoding.UTF8;
        protected AojPrintXmlWriter() { }
        // Summary:
        //     传入定义的流和编码来创建一个XmlTextWriter实例。
        //
        // Parameters:
        //   URL:
        //     需要写入文件的路径，如果文件存在，将会给重新写入新的内容。
        //
        //   encoding:
        //     如果编码制定为null，那么将以默认的为UTF-8
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The encoding is not supported; the filename is empty, contains only white
        //     space, or contains one or more invalid characters.
        //
        //   System.UnauthorizedAccessException:
        //     Access is denied.
        //
        //   System.ArgumentNullException:
        //     The filename is null.
        //
        //   System.IO.DirectoryNotFoundException:
        //     The directory to write to is not found.
        //
        //   System.IO.IOException:
        //     The filename includes an incorrect or invalid syntax for file name, directory
        //     name, or volume label syntax.
        //
        //   System.Security.SecurityException:
        //     The caller does not have the required permission.
        public AojPrintXmlWriter(string url)
        {
            this._url = url;
        }
        /// <summary>
        /// 初始化XmlWriter
        /// </summary>
        public void Initialize()
        {
            if(writer != null)
            {
                writer.Close();
            }

            XmlWriterSettings xmlsettings = new XmlWriterSettings();
            xmlsettings.Indent = true;
            xmlsettings.Encoding = Encoding.UTF8;
            FileInfo fi = new FileInfo(_url);
            AojFilesHelper.CreateDirectory(fi.DirectoryName);

            writer = XmlWriter.Create(this._url, xmlsettings);
            writer.WriteStartDocument();
            writer.WriteStartElement("AojReporter");
        }

        public void Save(IAojPrintObjectParse paper)
        {
            paper.Save(writer);
        }

        public void Close()
        {
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            writer.Close();
        }
    }
}
