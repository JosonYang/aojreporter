#region 翱捷报表软件
/**********************************************
 * 版权：Copyright @2009 翱捷报表
 * 
 * 
 * 描述：XML操作类库
 * 
 * 
 * 日期：
 * 
 **********************************************/
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;

namespace AojReport.AojWinForm.Common
{
    /// <summary>
    /// XML操作类库
    /// 用于对Xml中的节点增删修改
    /// </summary>
    public class AojXmlHelper
    {
        #region 构造函数

        public AojXmlHelper() { }

        public AojXmlHelper(string XmlFile)
        {
            try
            {
                objXmlDoc.Load(XmlFile);
            }
            catch (XmlException ex)
            {
                throw ex;
            }
            strXmlFile = XmlFile;
        }

        #endregion

        #region 私有变量

        protected string strXmlFile = string.Empty;
        public XmlDocument objXmlDoc = new XmlDocument();

        #endregion

        #region 修改节点信息

        /// <summary>
        /// 给某节点附上某值
        /// </summary>
        /// <param name="strXmlNodePath">节点路径</param>
        /// <param name="Content">节点内容</param>
        public void ModifiedContent(string strXmlNodePath, string Content)
        {
            objXmlDoc.SelectSingleNode(strXmlNodePath).InnerText = Content;
        }

        /// <summary>
        /// 修改节点属性
        /// </summary>
        /// <param name="strXmlNodePath">节点路径</param>
        /// <param name="AttrArray">属性的信息，如节点是key，值是Value，传入的值为new string[]{key,value}</param>
        public void ModifiedAttribute(string strXmlNodePath,string[] AttrArray)
        {
            XmlNode objRootNode = objXmlDoc.SelectSingleNode(strXmlNodePath);
            objRootNode.Attributes[AttrArray[0].ToString()].Value = AttrArray[1].ToString(); 
        }

        #endregion

        #region 删除节点

        /// <summary>
        /// 移除某节点
        /// </summary>
        /// <param name="strNode">节点路径</param>
        public void DeleteNode(string strNode)
        {
            string strRootNode = strNode.Substring(0, strNode.LastIndexOf("/"));
            objXmlDoc.SelectSingleNode(strRootNode).RemoveChild(objXmlDoc.SelectSingleNode(strNode));
        }

        #endregion

        #region 插入节点

        /// <summary>
        /// 插入节点，包含节点内容
        /// </summary>
        /// <param name="rootNode">根节点</param>
        /// <param name="childNode">准备插入的子节点</param>
        /// <param name="Content">子节点内容</param>
        public void InsertNode(string rootNode, string childNode, string Content)
        {
            InsertNode(rootNode, childNode, Content, null);
        }

        /// <summary>
        /// 插入节点，包含节点属性
        /// </summary>
        /// <param name="rootNode">根节点</param>
        /// <param name="childNode">准备插入的子节点</param>
        /// <param name="AttrArray">子节点属性</param>
        public void InsertNode(string rootNode, string childNode, Dictionary<string, string> AttrArray)
        {
            InsertNode(rootNode, childNode, string.Empty, AttrArray);
        }

        /// <summary>
        /// 插入节点，包含内容，属性
        /// </summary>
        /// <param name="rootNode">根节点</param>
        /// <param name="childNode">准备插入的子节点</param>
        /// <param name="Content">子节点内容</param>
        /// <param name="AttrArray">子节点属性</param>
        public void InsertNode(string rootNode, string childNode, string Content, Dictionary<string,string> AttrArray)
        {
            XmlNode objRootNode = objXmlDoc.SelectSingleNode(rootNode);
            XmlElement objChildNode = objXmlDoc.CreateElement(childNode);
            if (string.Empty != Content)
            {
                objChildNode.InnerText = Content;
            }
            objRootNode.AppendChild(objChildNode);
            this.InsertAttribute(rootNode + "/" +childNode, AttrArray);
        }

        #endregion

        #region 插入节点属性

        /// <summary>
        /// 为指定的节点插入相关属性
        /// </summary>
        /// <param name="strNodeName">指定的节点名称</param>
        /// <param name="attributeInfo">相关属性</param>
        public void InsertAttribute(string strNodeName, Dictionary<string, string> attributeInfo)
        {
            XmlNode currentNode = objXmlDoc.SelectSingleNode(strNodeName);
            if (currentNode != null)
            {
                if (attributeInfo != null && attributeInfo.Count > 0)
                {
                    XmlAttribute xmlAttributeNode;
                    foreach (string itemKey in attributeInfo.Keys)
                    {
                        xmlAttributeNode = objXmlDoc.CreateAttribute(itemKey);
                        xmlAttributeNode.Value = attributeInfo[itemKey];
                        currentNode.Attributes.Append(xmlAttributeNode);
                    }
                }
            } 
        }

        #endregion

        #region 获取节点的信息

        /// <summary>
        /// 获取文档中指定节点的所有子节点
        /// </summary>
        /// <param name="strNodeName">指定节点名称</param>
        /// <returns>指定节点的所有子节点</returns>
        public XmlNodeList GetAllNodeList(string strNodeName)
        {
            XmlNode nodeParent = objXmlDoc.SelectSingleNode(strNodeName);
            XmlNodeList nodeList = null;
            if (nodeParent != null)
            {
                nodeList = nodeParent.ChildNodes;
            }       
            return nodeList;
        }

        /// <summary>
        /// 获取节点内容
        /// </summary>
        /// <param name="objNode">操作节点</param>
        /// <returns></returns>
        public string GetNodeContent(XmlNode objNode)
        {
            return objNode.InnerText;
        }

        /// <summary>
        /// 获取节点属性
        /// </summary>
        /// <param name="objNode">操作节点</param>
        /// <param name="strAttriName">属性NAME</param>
        /// <returns></returns>
        public string GetNodeAttribute(XmlNode objNode, string strAttriName)
        {
            return objNode.Attributes[strAttriName].ToString();
        }

        #endregion

        #region 保存XML文档到文件

        /// <summary>
        /// 保存XML文档到文件
        /// </summary>
        public void Save()
        {
            try
            {
                objXmlDoc.Save(strXmlFile);
            }
            catch(XmlException ex)
            {
                throw ex;
            }
            objXmlDoc = null;
        }

        #endregion
    }
}
