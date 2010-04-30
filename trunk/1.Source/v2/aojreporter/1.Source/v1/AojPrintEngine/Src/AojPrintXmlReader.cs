using System;
using System.Xml;                
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using AojReport.AojPrintEngine.CustomException;

namespace AojReport.AojPrintEngine
{
    public class AojPrintXmlReader
    {
        private string _url;
        /// <summary>
        /// 节点类型
        /// </summary>
        public XmlNodeType TagType = XmlNodeType.None;
        /// <summary>
        /// 节点名称
        /// </summary>
        public string TagName = string.Empty;
        /// <summary>
        /// 节点Text
        /// </summary>
        public string TagContent = string.Empty;
        /// <summary>
        /// 节点属性集合
        /// </summary>
        public Hashtable Attributes
        {
            get 
            {
                return this.GetCurrentNodeAttributes();
            }
        }
        /// <summary>
        /// Xml读取器
        /// </summary>
        protected XmlTextReader reader;

        protected AojPrintXmlReader() { }

        public AojPrintXmlReader(string url)
        {
            _url = url;
        }

        /// <summary>
        /// 初始化XML读取器
        /// </summary>
        public void Initialize()
        {
            if (reader != null)
            {
                /**
                 * 此方法还释放读取时占有的任何资源。
                 * 如果此读取器是用流构造的，则此方法还对基础流调用 Close。
                 * 
                 * 如果已调用 Close，则不执行任何操作。
                 */
                reader.Close();
            }

            reader = new XmlTextReader(this._url);
            //TODO:空白处理，有待改进
            try
            { 
                //尝试读取，测试是否会产生异常
                while(reader.Read());
                reader = new XmlTextReader(this._url);
            }
            catch(XmlOperateException ex)
            {
                //产生异常后输出信息
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exception object Line, pos: (" + ex.LineNumber + "," + ex.LinePosition + ")");
                Console.WriteLine("Exception source URI: (" + ex.SourceUri + ")");
                Console.WriteLine("XmlReader Line, pos: (" + reader.LineNumber + "," + reader.LinePosition + ")");
                reader = null;
            }

        }

        /// <summary>
        /// XML读取器
        /// </summary>
        /// <returns>是否可以向前读取</returns>
        public bool Read()
        {
            if (reader == null)
            {
                //如果读取器为空时，返回False
                return false;
            }
            bool result = false;
            while (result = reader.Read())
            {
                switch (reader.NodeType)
                {
                    //忽略空白和Xml定义
                    case XmlNodeType.Whitespace:
                    case XmlNodeType.XmlDeclaration:
                        {
                            continue;
                        }
                        break;
                    default:
                        //保存节点类型，节点名称，节点内容信息
                        this.TagType = reader.NodeType;
                        this.TagName = reader.Name;
                        this.TagContent = reader.Value;
                        return result;
                }

            }
            return result;
        }

        /// <summary>
        /// 获取包含当前节点属性的集合
        /// </summary>
        /// <returns></returns>
        private Hashtable GetCurrentNodeAttributes()
        {
            //创建属性表实例
            Hashtable NodeAttribute = new Hashtable();
            //是否含有属性
            if (reader.HasAttributes)
            {
                while (reader.MoveToNextAttribute())
                {
                    //将属性加入到属性表中
                    NodeAttribute.Add(reader.Name, reader.Value);
                }
            }
            return NodeAttribute;
        }

        /// <summary>
        /// 是否为结束节点
        /// </summary>
        /// <returns></returns>
        public bool IsEndElement(string strNodeName)
        {
            if(this.TagType == XmlNodeType.EndElement
                && this.TagName.ToLower() == strNodeName.ToLower())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
