#region 翱捷报表软件
/**********************************************
 * 版权：Copyright @2009 翱捷报表
 * 
 * 
 * 描述：系统用到的一些公共函数
 * 
 * 
 * 日期：
 * 
 **********************************************/
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
using System.Reflection;
using System.Windows.Forms;
using AojReport.AojWinForm.ReportObjects;

namespace AojReport.AojWinForm.Common
{
    /// <summary>
    /// 系统用到的一些公共函数
    /// </summary>
    public static class AojCommonFnc
    {
        /// <summary>
        /// 将给定的数据储存到剪贴板上
        /// </summary>
        /// <param name="lstObject">给定的数据</param>
        public static void SaveObjectToClipBoard(List<AojReportObject> lstObject)
        {
            //将剪贴板上的所有信息清除
            AojClipboard.Clear();

            DataObject myDataObject = new DataObject();

            #region Label对象
            List<AojLabel> lstLabel = GetObjectByType<AojLabel>(lstObject);
            #endregion

            #region Table对象
            List<AojTable> lstTable = GetObjectByType<AojTable>(lstObject);
            #endregion

            #region Image对象
            List<AojImage> lstImage = GetObjectByType<AojImage>(lstObject);
            #endregion

            #region 序列化为XML字符串

            #region Label对象
            if (lstLabel != null && lstLabel.Count > 0)
            {
                try
                {
                    AojXmlHelper xmlLabelHelper = new AojXmlHelper();
                    xmlLabelHelper.objXmlDoc.LoadXml("<ArrayOfAojLabel></ArrayOfAojLabel>");
                    XmlNode objLabelNode;
                    foreach (AojLabel lbItem in lstLabel)
                    {
                        objLabelNode = lbItem.SaveToXMl();
                        InsertNodeToXMlDocument(xmlLabelHelper, objLabelNode);
                    }
                    myDataObject.SetData(AojConst.ClipboardFormat.Label, xmlLabelHelper.objXmlDoc.InnerXml);
                }
                catch
                {
                    string xmlLabel = AojSerializer.Serialize<List<AojLabel>>(lstLabel);
                    myDataObject.SetData(AojConst.ClipboardFormat.Label, xmlLabel);
                }
            }
            #endregion

            #region Table对象
            if (lstTable != null && lstTable.Count > 0)
            {
                try
                {
                    AojXmlHelper xmlTableHelper = new AojXmlHelper();
                    xmlTableHelper.objXmlDoc.LoadXml("<ArrayOfAojTable></ArrayOfAojTable>");
                    XmlNode objAojTableNode;
                    foreach (AojTable tbItem in lstTable)
                    {
                        objAojTableNode = tbItem.SaveToXMl();
                        InsertNodeToXMlDocument(xmlTableHelper, objAojTableNode);
                    }
                    myDataObject.SetData(AojConst.ClipboardFormat.Table, xmlTableHelper.objXmlDoc.InnerXml);
                }
                catch
                {
                    string xmlTable = AojSerializer.Serialize<List<AojTable>>(lstTable);
                    myDataObject.SetData(AojConst.ClipboardFormat.Table, xmlTable);
                }
            }
            #endregion

            #region Image对象
            if (lstImage != null && lstImage.Count > 0)
            {
                try
                {
                    AojXmlHelper xmlImageHelper = new AojXmlHelper();
                    xmlImageHelper.objXmlDoc.LoadXml("<ArrayOfAojImage></ArrayOfAojImage>");
                    XmlNode objImageNode;
                    foreach (AojImage imgItem in lstImage)
                    {
                        objImageNode = imgItem.SaveToXMl();
                        InsertNodeToXMlDocument(xmlImageHelper, objImageNode);
                    }
                    myDataObject.SetData(AojConst.ClipboardFormat.Image, xmlImageHelper.objXmlDoc.InnerXml);
                }
                catch
                {
                    string xmlImage = AojSerializer.Serialize<List<AojImage>>(lstImage);
                    myDataObject.SetData(AojConst.ClipboardFormat.Image, xmlImage);
                }
            }
            #endregion

            #endregion

            //将信息保存到剪贴板上
            AojClipboard.SetData(myDataObject, true);
        }

        /// <summary>
        /// 根据指定的数据类型从给定的数据中取出相关数据
        /// </summary>
        /// <param name="lstObject">给定的数据</param>
        public static List<T> GetObjectByType<T>(List<AojReportObject> lstObject)
            where T : AojReportObject
        {
            List<T> lstInfo = new List<T>();
            foreach (object objectItem in lstObject)
            {
                if (objectItem.GetType().Equals(typeof(T)))
                {
                    lstInfo.Add((T)objectItem);
                }
            }
            return lstInfo;
        }

        /// <summary>
        /// 获得指定对象的类型
        /// </summary>
        /// <param name="objectInfo">指定对象</param>
        /// <returns>指定对象的类型</returns>
        public static AojConst.DrawToolType GetObjectType<T>(T objectInfo)
            where T:AojReportObject
        {
            AojConst.DrawToolType objectTypeInfo = AojConst.DrawToolType.Pointer;
            if (objectInfo.GetType().Equals(typeof(AojLabel)))
            {
                objectTypeInfo = AojConst.DrawToolType.Label;
            }
            else if (objectInfo.GetType().Equals(typeof(AojTable)))
            {
                objectTypeInfo = AojConst.DrawToolType.Table;
            }
            else if (objectInfo.GetType().Equals(typeof(AojImage)))
            {
                objectTypeInfo = AojConst.DrawToolType.Image;
            }
            return objectTypeInfo;
        }

        /// <summary>
        /// 将报表设计器中的对象从一处复制到另一处
        /// </summary>
        /// <param name="from">复制源头</param>
        public static AojReportObjectCollection CopyReportObject(AojReportObjectCollection from)
        {
            AojReportObjectCollection lstTemp = new AojReportObjectCollection();
            AojReportObject tempObject = null;
            PropertyInfo[] properties;
            foreach (AojReportObject item in from)
            {
                #region 根据指定对象的类型创建实例
                AojConst.DrawToolType objectType = GetObjectType<AojReportObject>(item);
                switch (objectType)
                {
                    case AojConst.DrawToolType.Label:
                        tempObject = new AojLabel();
                        break;
                    case AojConst.DrawToolType.Table:
                        tempObject = new AojTable();
                        break;
                    case AojConst.DrawToolType.Image:
                        tempObject = new AojImage();
                        break;
                    default:
                        break;
                }
                #endregion

                #region 根据对象所拥有的属性进行复制
                properties = item.GetType().GetProperties();                
                foreach (PropertyInfo property in properties)
                {
                    if (property.CanWrite)
                    {
                        property.SetValue(tempObject, property.GetValue(item, null), null);
                    }
                }
                #endregion

                lstTemp.Add(tempObject);
            }
            return lstTemp;
        }

        /// <summary>
        /// 比较两个对象集合是否一样
        /// </summary>
        /// <param name="valueInfo1">对象集合</param>
        /// <param name="valueInfo2">对象集合</param>
        /// <returns>一样：True 不同：False</returns>
        public static bool EqualsReportObject(AojReportObjectCollection valueInfo1, AojReportObjectCollection valueInfo2)
        {
            bool IsSameFlag = true;
            if (valueInfo1.Count == valueInfo2.Count)
            {
                foreach (AojReportObject item1 in valueInfo1)
                {
                    #region 获得对象集合中相同的对象
                    AojReportObject tempObject = null;
                    foreach (AojReportObject item2 in valueInfo2)
                    {
                        if (item2.Name.Equals(item1.Name))
                        {
                            tempObject = item2;
                            break;
                        }
                    }
                    #endregion

                    if (tempObject != null)
                    {
                        #region 比较两个相同对象的值是否相等
                        PropertyInfo[] properties = item1.GetType().GetProperties();
                        foreach (PropertyInfo property in properties)
                        {
                            if (!property.Name.Equals("Selected"))
                            {
                                if (!property.GetValue(item1, null).ToString().Equals(property.GetValue(tempObject, null).ToString()))
                                {
                                    IsSameFlag = false;
                                    break;
                                }
                            }                         
                        }
                        #endregion

                        if (!IsSameFlag)
                        {
                            break;
                        }
                    }
                    else
                    {
                        IsSameFlag = false;
                        break;
                    }
                }
            }
            else
            {
                IsSameFlag = false;
            }
            return IsSameFlag;
        }

        /// <summary>
        /// 获得放大或者缩小的数据信息
        /// </summary>
        /// <returns>放大或者缩小的初始化数据信息</returns>
        public static DataTable GetPagesizePercentData()
        {
            DataTable dtPagesizeInit = new DataTable();
            DataColumn colName = new DataColumn("percentName", typeof(string));
            dtPagesizeInit.Columns.Add(colName);
            DataColumn colValue = new DataColumn("percentValue", typeof(float));
            dtPagesizeInit.Columns.Add(colValue);
            DataRow drInfo;

            #region 解析XML文件并从中获得需要的数据信息
            AojXmlHelper xmlHelper = new AojXmlHelper(GetXMLDoumentPath("AojPagesizePercent.xml"));
            XmlNodeList nodeList = xmlHelper.GetAllNodeList("AojPagesizePercent");
            if (nodeList != null)
            {
                foreach (XmlNode nodeItem in nodeList)
                {
                    if (nodeItem["Name"] != null && nodeItem["Value"] != null)
                    {
                        drInfo = dtPagesizeInit.NewRow();
                        drInfo["percentName"] = nodeItem["Name"].InnerText;
                        string strValue = nodeItem["Value"].InnerText;
                        float percentValue;
                        bool IsSucceed = float.TryParse(strValue, out percentValue);
                        if (!IsSucceed)
                        {
                            percentValue = 1;
                        }
                        drInfo["percentValue"] = percentValue;
                        dtPagesizeInit.Rows.Add(drInfo);
                    }
                }
            }
            #endregion

            return dtPagesizeInit;
        }

        /// <summary>
        /// 获得报表设计器可绘制的纸张大小数据信息
        /// </summary>
        /// <returns>纸张大小数据信息</returns>
        public static DataTable GetPageLayoutData()
        {
            DataTable dtPageLayoutInit = new DataTable();
            DataColumn colName = new DataColumn("lauoutName", typeof(string));
            dtPageLayoutInit.Columns.Add(colName);
            DataColumn colSize = new DataColumn("lauoutSize", typeof(string));
            dtPageLayoutInit.Columns.Add(colSize);
            DataRow drInfo;

            #region 解析XML文件并从中获得需要的数据信息
            AojXmlHelper xmlHelper = new AojXmlHelper(GetXMLDoumentPath("AojPageLayout.xml"));
            XmlNodeList nodeList = xmlHelper.GetAllNodeList("AojPageLayout");
            if (nodeList != null)
            {
                foreach (XmlNode nodeItem in nodeList)
                {
                    if (nodeItem["LauoutName"] != null && nodeItem["LauoutSize"] != null)
                    {
                        drInfo = dtPageLayoutInit.NewRow();
                        drInfo["lauoutName"] = nodeItem["LauoutName"].InnerText;
                        drInfo["lauoutSize"] = nodeItem["LauoutSize"].InnerText;
                        dtPageLayoutInit.Rows.Add(drInfo);
                    }
                }
            }
            #endregion

            return dtPageLayoutInit;
        }

        /// <summary>
        /// 获得记载画面放大或者缩小的数据信息的XML文件的路径
        /// </summary>
        /// <param name="strName">文件名称</param>
        /// <returns>XML文件的路径</returns>
        public static string GetXMLDoumentPath(string strName)
        {
            string strApplicationPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            strApplicationPath = strApplicationPath.Substring(0, strApplicationPath.Length - 10);
            string strXmlPath = string.Concat(strApplicationPath, @"XMLDocument\" + strName);
            return strXmlPath;
        }

        /// <summary>
        /// 获得报表设计器绘制图片时候的默认显示图片的文件路径
        /// </summary>
        /// <param name="strName">文件名称</param>
        /// <returns>图片的文件路径</returns>
        public static string GetImagePath(string strName)
        {
            string strApplicationPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            strApplicationPath = strApplicationPath.Substring(0, strApplicationPath.Length - 10);
            string strXmlPath = string.Concat(strApplicationPath, @"Images\" + strName);
            return strXmlPath;
        }

        /// <summary>
        /// 对报表设计文件进行保存相关处理
        /// </summary>
        /// <param name="strReportDocumentPath">保存文件路径</param>
        /// <param name="drawWorkSpace">指定的工作区域</param>
        public static void SaveReportDocument(string strReportDocumentPath, DrawWorkSpace drawWorkSpace)
        {
            AojXmlHelper xmlHelper = new AojXmlHelper();
            //将你要写进xml文档中的内容以字符串的形式加载进来
            xmlHelper.objXmlDoc.LoadXml("<?xml version='1.0' encoding='utf-8' ?><AojPaper></AojPaper>");           
            //保存到你想要保存的文件中
            xmlHelper.objXmlDoc.Save(strReportDocumentPath);
            xmlHelper = new AojXmlHelper(strReportDocumentPath);

            #region 将报表纸张保存进xml文档中
            Dictionary<string, string> dicPageSetting = GetPageSetting(drawWorkSpace);
            xmlHelper.InsertAttribute("AojPaper", dicPageSetting);
            #endregion          

            AojReportObject objItem;
            XmlNode objNode;
            for (int index = drawWorkSpace.GraphicsList.Count - 1; index >= 0; index--)
            {
                objItem = drawWorkSpace.GraphicsList.GetObjectByIndex(index);
                objNode = objItem.SaveToXMl();
                InsertNodeToXMlDocument(xmlHelper, objNode);
            }

            //保存XML文档到文件
            xmlHelper.Save();
        }

        /// <summary>
        /// 获得指定的报表设计纸张的相关属性集合
        /// </summary>
        /// <param name="drawWorkSpace">指定的工作区域</param>
        /// <returns>指定的报表设计区域的相关属性集合</returns>
        private static Dictionary<string, string> GetPageSetting(DrawWorkSpace drawWorkSpace)
        {
            Dictionary<string, string> dicPageSetting = new Dictionary<string, string>();
            dicPageSetting.Add("Width", drawWorkSpace.NormalWidth.ToString());
            dicPageSetting.Add("Height", drawWorkSpace.NormalHeight.ToString());
            dicPageSetting.Add("PaperSizeName", drawWorkSpace.PaperSizeName);
            dicPageSetting.Add("PageStyle", drawWorkSpace.PageStyle);            
            dicPageSetting.Add("GridStyleFlag", drawWorkSpace.GridStyleFlag.ToString());
            dicPageSetting.Add("DrawByGridStyle", drawWorkSpace.DrawByGridStyle.ToString());
            dicPageSetting.Add("DistanceAboutGridStyle", drawWorkSpace.NormalDistanceAboutGridStyle.ToString());
            return dicPageSetting;
        }

        /// <summary>
        /// 为XML文档根节点插入子节点，包含内容，属性
        /// </summary>
        /// <param name="xmlHelper">XMl文档操作类</param>
        /// <param name="objNode">指定要插入的节点</param>
        private static void InsertNodeToXMlDocument(AojXmlHelper xmlHelper, XmlNode objNode)
        {
            if (xmlHelper != null && xmlHelper.objXmlDoc != null 
                    && xmlHelper.objXmlDoc.DocumentElement != null && objNode != null)
            {
                XmlElement objCurrentNode = xmlHelper.objXmlDoc.CreateElement(objNode.Name);

                #region 属性
                if (objNode.Attributes != null)
                {
                    XmlAttribute xmlAttributeNode;
                    foreach (XmlAttribute itemAttribute in objNode.Attributes)
                    {
                        xmlAttributeNode = xmlHelper.objXmlDoc.CreateAttribute(itemAttribute.Name);
                        xmlAttributeNode.Value = itemAttribute.Value;
                        objCurrentNode.Attributes.Append(xmlAttributeNode);
                    }
                }
                #endregion

                #region 子节点
                if (objNode.HasChildNodes)
                {
                    foreach (XmlNode nodeItem in objNode.ChildNodes)
                    {
                        if (nodeItem.NodeType == XmlNodeType.Element)
                        {
                            InsertNode(xmlHelper, objCurrentNode, nodeItem);
                        }                        
                    }
                }               
                #endregion

                xmlHelper.objXmlDoc.DocumentElement.AppendChild(objCurrentNode);
            }
        }

        /// <summary>
        /// 为节点插入子节点，包含内容，属性
        /// </summary>
        /// <param name="xmlHelper">XMl文档操作类</param>
        /// <param name="objParentNode">父节点</param>
        /// <param name="objNode">子节点</param>
        private static void InsertNode(AojXmlHelper xmlHelper, XmlNode objParentNode, XmlNode objNode)
        {
            if (xmlHelper != null && xmlHelper.objXmlDoc != null 
                    && objParentNode != null && objNode != null)
            {
                XmlElement objChildNode = xmlHelper.objXmlDoc.CreateElement(objNode.Name);

                #region 属性
                if (objNode.Attributes != null)
                {
                    XmlAttribute xmlAttributeNode;
                    foreach (XmlAttribute itemAttribute in objNode.Attributes)
                    {
                        xmlAttributeNode = xmlHelper.objXmlDoc.CreateAttribute(itemAttribute.Name);
                        xmlAttributeNode.Value = itemAttribute.Value;
                        objChildNode.Attributes.Append(xmlAttributeNode);
                    }
                }
               
                #endregion

                objParentNode.AppendChild(objChildNode);

                #region 子节点
                if (objNode.HasChildNodes)
                {
                    foreach (XmlNode nodeItem in objNode.ChildNodes)
                    {
                        if (nodeItem.NodeType == XmlNodeType.Element)
                        {
                            InsertNode(xmlHelper, objChildNode, nodeItem);
                        }
                    }
                }

                #region 文本
                if (objNode.HasChildNodes
                        && objNode.ChildNodes.Count == 1
                        && objNode.ChildNodes[0].NodeType == XmlNodeType.Text)
                {
                    if (!string.IsNullOrEmpty(objNode.InnerText))
                    {
                        objChildNode.InnerText = objNode.InnerText;
                    }
                }
                #endregion

                #endregion
            }
        }

        /// <summary>
        /// 从指定的工作区域中打开报表格式XML文件
        /// </summary>
        /// <param name="drawWorkSpace">指定的工作区域</param>
        /// <param name="strXmlDocument">报表格式XML文件</param>
        public static void OpenFromReportDocument(DrawWorkSpace drawWorkSpace, string strXmlDocument)
        {
            bool isRightFormatFlag = DoXMLDocumentValidated(strXmlDocument);
            if (isRightFormatFlag)
            {
                AojXmlHelper xmlHelper = new AojXmlHelper(strXmlDocument);
                XmlNodeList lstNode = xmlHelper.objXmlDoc.DocumentElement.ChildNodes;
                if (lstNode != null)
                {
                    AojLabel lbInfo;
                    AojImage imgInfo;
                    AojTable tbInfo;
                    foreach (XmlNode nodeItem in lstNode)
                    {
                        switch (nodeItem.Name)
                        {
                            case "Label":
                                try
                                {
                                    lbInfo = new AojLabel();
                                    lbInfo.OpenFormXML(nodeItem);
                                    drawWorkSpace.GraphicsList.Add(lbInfo);
                                    lbInfo.Selected = false;
                                    drawWorkSpace.GraphicsList.ListObjectSelected.Remove(lbInfo);
                                }
                                catch { }
                                break;
                            case "Image":
                                try
                                {
                                    imgInfo = new AojImage();
                                    imgInfo.OpenFormXML(nodeItem);
                                    drawWorkSpace.GraphicsList.Add(imgInfo);
                                    imgInfo.Selected = false;
                                    drawWorkSpace.GraphicsList.ListObjectSelected.Remove(imgInfo);
                                }
                                catch { }
                                break;
                            case "Table":
                                try
                                {
                                    tbInfo = new AojTable();
                                    tbInfo.OpenFormXML(nodeItem);
                                    drawWorkSpace.GraphicsList.Add(tbInfo);
                                    tbInfo.Selected = false;
                                    drawWorkSpace.GraphicsList.ListObjectSelected.Remove(tbInfo);
                                }
                                catch { }
                                break;
                            default:
                                break;
                        }
                    }
                }
                drawWorkSpace.Refresh();
            }
        }

        /// <summary>
        /// 验证报表格式XML文件是否是正确的XML格式
        /// </summary>
        /// <param name="strXmlDocument">报表格式XML文件</param>
        /// <returns>true:正确 false:错误</returns>
        public static bool DoXMLDocumentValidated(string strXmlDocument)
        {
            bool isRightFormatFlag = true;
            try
            {
                AojXmlHelper xmlHelper = new AojXmlHelper();
                xmlHelper.objXmlDoc.Load(strXmlDocument);
            }
            catch
            {
                isRightFormatFlag = false;
            }
            return isRightFormatFlag;
        }

        /// <summary>
        /// 获得文本对齐的相关数据信息
        /// </summary>
        /// <returns>文本对齐的相关数据信息</returns>
        public static DataTable GetLineAlignmentFormatData()
        {
            DataTable dtFormatInit = new DataTable();

            #region 列
            DataColumn colName = new DataColumn("formatname", typeof(string));
            dtFormatInit.Columns.Add(colName);
            DataColumn colValue = new DataColumn("formatvalue", typeof(string));
            dtFormatInit.Columns.Add(colValue);
            #endregion

            #region 行
            DataRow drNew = dtFormatInit.NewRow();
            drNew["formatname"] = "居上";
            drNew["formatvalue"] = "Near";
            dtFormatInit.Rows.Add(drNew);
            drNew = dtFormatInit.NewRow();
            drNew["formatname"] = "居中";
            drNew["formatvalue"] = "Center";
            dtFormatInit.Rows.Add(drNew);
            drNew = dtFormatInit.NewRow();
            drNew["formatname"] = "居下";
            drNew["formatvalue"] = "Far";
            dtFormatInit.Rows.Add(drNew);
            #endregion

            return dtFormatInit;
        }

        /// <summary>
        /// 获得文本对齐的相关数据信息
        /// </summary>
        /// <returns>文本对齐的相关数据信息</returns>
        public static DataTable GetAlignmentFormatData()
        {
            DataTable dtFormatInit = new DataTable();

            #region 列
            DataColumn colName = new DataColumn("formatname", typeof(string));
            dtFormatInit.Columns.Add(colName);
            DataColumn colValue = new DataColumn("formatvalue", typeof(string));
            dtFormatInit.Columns.Add(colValue);
            #endregion

            #region 行
            DataRow drNew = dtFormatInit.NewRow();
            drNew["formatname"] = "居左";
            drNew["formatvalue"] = "Near";
            dtFormatInit.Rows.Add(drNew);
            drNew = dtFormatInit.NewRow();
            drNew["formatname"] = "居中";
            drNew["formatvalue"] = "Center";
            dtFormatInit.Rows.Add(drNew);
            drNew = dtFormatInit.NewRow();
            drNew["formatname"] = "居右";
            drNew["formatvalue"] = "Far";
            dtFormatInit.Rows.Add(drNew);
            #endregion

            return dtFormatInit;
        }
    }
}
