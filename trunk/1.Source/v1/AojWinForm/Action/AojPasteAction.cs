#region 翱捷报表软件
/**********************************************
 * 版权：Copyright @2009 翱捷报表
 * 
 * 
 * 描述：对工作区域的对象进行粘贴动作
 * 
 * 
 * 日期：
 * 
 **********************************************/
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml;
using AojReport.AojWinForm.Common;
using AojReport.AojWinForm.ReportObjects;

namespace AojReport.AojWinForm.Action
{
    /// <summary>
    /// 对工作区域的对象进行粘贴动作
    /// </summary>
    public class AojPasteAction : IAojAction
    {
        #region IAojAction Members

        /// <summary>
        /// 对指定的工作区域的对象进行粘贴的详细处理动作
        /// </summary>
        /// <param name="drawWorkspace">指定的工作区域</param>
        public void PerformAction(DrawWorkSpace drawWorkspace)
        {
            #region Label对象
            this.PasteLabelToWorkspace(drawWorkspace);
            #endregion

            #region Table对象
            this.PasteTableToWorkspace(drawWorkspace);
            #endregion

            #region Image对象
            this.PasteImageToWorkspace(drawWorkspace);
            #endregion

            #region 记录报表设计区域历史记录Undo的相关对象集合
            if (!AojCommonFnc.EqualsReportObject(drawWorkspace.GraphicsList, drawWorkspace.ListHistoryUndo[0]))
            {
                AojReportObjectCollection lstTemp = AojCommonFnc.CopyReportObject(drawWorkspace.GraphicsList);
                drawWorkspace.ListHistoryUndo.Insert(0, lstTemp);
            }
            #endregion

            drawWorkspace.Refresh();
        }

        #endregion

        #region Private(私有方法)

        /// <summary>
        /// 将剪贴或复制的Label对象粘贴到报表设计器区域中
        /// </summary>
        /// <param name="drawWorkspace">报表设计器区域</param>
        private void PasteLabelToWorkspace(DrawWorkSpace drawWorkspace)
        {
            List<AojLabel> lstObject = new List<AojLabel>();
            try
            {
                if (AojClipboard.ContainsData(AojConst.ClipboardFormat.Label))
                {
                    string strXml = AojClipboard.GetData(AojConst.ClipboardFormat.Label).ToString();
                    AojXmlHelper xmlHelper = new AojXmlHelper();
                    xmlHelper.objXmlDoc.LoadXml(strXml);
                    XmlNodeList lstNode = xmlHelper.objXmlDoc.DocumentElement.ChildNodes;
                    if (lstNode != null)
                    {
                        AojLabel lbInfo;
                        foreach (XmlNode nodeItem in lstNode)
                        {
                            lbInfo = new AojLabel();
                            lbInfo.OpenFormXML(nodeItem);
                            lstObject.Add(lbInfo);
                        }
                    }
                }
            }
            catch
            {
                lstObject = this.PasteObjectToWorkspace<AojLabel>(drawWorkspace, AojConst.ClipboardFormat.Label);
            }
            this.AddObjectToWorkspace<AojLabel>(drawWorkspace, lstObject);
        }

        /// <summary>
        /// 将剪贴或复制的Table对象粘贴到报表设计器区域中
        /// </summary>
        /// <param name="drawWorkspace">报表设计器区域</param>
        private void PasteTableToWorkspace(DrawWorkSpace drawWorkspace)
        {
            List<AojTable> lstObject = new List<AojTable>();
            try
            {
                if (AojClipboard.ContainsData(AojConst.ClipboardFormat.Table))
                {
                    string strXml = AojClipboard.GetData(AojConst.ClipboardFormat.Table).ToString();
                    AojXmlHelper xmlHelper = new AojXmlHelper();
                    xmlHelper.objXmlDoc.LoadXml(strXml);
                    XmlNodeList lstNode = xmlHelper.objXmlDoc.DocumentElement.ChildNodes;
                    if (lstNode != null)
                    {
                        AojTable tbInfo;
                        foreach (XmlNode nodeItem in lstNode)
                        {
                            tbInfo = new AojTable();
                            tbInfo.OpenFormXML(nodeItem);
                            lstObject.Add(tbInfo);
                        }
                    }
                }
            }
            catch
            {
                lstObject = this.PasteObjectToWorkspace<AojTable>(drawWorkspace, AojConst.ClipboardFormat.Table);
            }
            this.AddObjectToWorkspace<AojTable>(drawWorkspace, lstObject);
        }

        /// <summary>
        /// 将剪贴或复制的Image对象粘贴到报表设计器区域中
        /// </summary>
        /// <param name="drawWorkspace">报表设计器区域</param>
        private void PasteImageToWorkspace(DrawWorkSpace drawWorkspace)
        {
            List<AojImage> lstObject = new List<AojImage>();
            try
            {
                if (AojClipboard.ContainsData(AojConst.ClipboardFormat.Image))
                {
                    string strXml = AojClipboard.GetData(AojConst.ClipboardFormat.Image).ToString();
                    AojXmlHelper xmlHelper = new AojXmlHelper();
                    xmlHelper.objXmlDoc.LoadXml(strXml);
                    XmlNodeList lstNode = xmlHelper.objXmlDoc.DocumentElement.ChildNodes;
                    if (lstNode != null)
                    {
                        AojImage imgInfo;
                        foreach (XmlNode nodeItem in lstNode)
                        {
                            imgInfo = new AojImage();
                            imgInfo.OpenFormXML(nodeItem);
                            lstObject.Add(imgInfo);
                        }
                    }
                }
            }
            catch
            {
                lstObject = this.PasteObjectToWorkspace<AojImage>(drawWorkspace, AojConst.ClipboardFormat.Image);
            }
            this.AddObjectToWorkspace<AojImage>(drawWorkspace, lstObject);
        }

        /// <summary>
        /// 将剪贴或复制的对象粘贴到报表设计器区域中
        /// </summary>
        /// <typeparam name="T">指定的数据类型</typeparam>
        /// <param name="drawWorkspace">报表设计器区域</param>
        /// <param name="format">自定义格式</param>
        private List<T> PasteObjectToWorkspace<T>(DrawWorkSpace drawWorkspace, string format)
            where T:AojReportObject
        {
            List<T> lstObject = null;
            if (AojClipboard.ContainsData(format))
            {
                string strXml = AojClipboard.GetData(format).ToString();
                lstObject = (List<T>)AojSerializer.Deserialize(typeof(List<T>), strXml);
            }
            return lstObject;
        }

        /// <summary>
        /// 将对象加入报表设计器区域中
        /// </summary>
        /// <typeparam name="T">指定的数据类型</typeparam>
        /// <param name="drawWorkspace">报表设计器区域</param>
        /// <param name="lstObject">对象集合</param>
        private void AddObjectToWorkspace<T>(DrawWorkSpace drawWorkspace, List<T> lstObject)
            where T:AojReportObject
        {
            #region 将对象加入到报表设计器区域
            if (lstObject != null && lstObject.Count > 0)
            {
                foreach (T objectItem in lstObject)
                {
                    #region 对即将进行粘贴的对象相关信息进行确认
                    string strName = this.ResetObjectInfo<T>(drawWorkspace, objectItem);
                    objectItem.Name = strName;
                    #endregion

                    //根据选择的倍率对指定对象的相关size进行缩放处理
                    SetObjectSizeByPagesizePercent(objectItem, drawWorkspace.PagesizePercent);

                    drawWorkspace.GraphicsList.Add(objectItem);
                }
            }
            #endregion
        }
        
        /// <summary>
        /// 对即将进行粘贴的对象相关信息进行确认
        /// </summary>
        /// <typeparam name="T">指定的数据类型</typeparam>
        /// <param name="drawWorkspace">报表设计器区域</param>
        /// <param name="objectInfo">指定的数据对象</param>
        private string ResetObjectInfo<T>(DrawWorkSpace drawWorkspace, T objectInfo)
            where T : AojReportObject
        {
            #region 获得当前报表设计器区域内的所有对象
            List<AojReportObject> lstAllObject = new List<AojReportObject>();
            foreach (AojReportObject item in drawWorkspace.GraphicsList)
            {
                lstAllObject.Add(item);
            }
            #endregion

            string strName = string.Empty;

            #region 获得对象的命名前缀
            string strNamePrefix = string.Empty;
            //获得指定对象的类型
            AojConst.DrawToolType objectType = AojCommonFnc.GetObjectType<T>(objectInfo);
            switch (objectType)
            {
                case AojConst.DrawToolType.Label:
                    strNamePrefix = AojConst.NamePrefix.Label;
                    break;
                case AojConst.DrawToolType.Table:
                    strNamePrefix = AojConst.NamePrefix.Table;
                    break;
                case AojConst.DrawToolType.Image:
                    strNamePrefix = AojConst.NamePrefix.Image;
                    break;
                default:
                    break;
            }
            #endregion

            //从报表设计区域得到指定类型对象的集合
            List<T> lstObject = AojCommonFnc.GetObjectByType<T>(lstAllObject);
            if (lstObject != null && lstObject.Count > 0)
            {
                if (!string.IsNullOrEmpty(strNamePrefix))
                {
                    #region 获得对象的相关序号
                    List<Int32> lstNumber = new List<Int32>();
                    int lengthAboutPrefix = strNamePrefix.Length;
                    int tempInfo;
                    foreach (T item in lstObject)
                    {
                        string number = item.Name.Substring(lengthAboutPrefix);
                        if (Int32.TryParse(number, out tempInfo))
                        {
                            lstNumber.Add(tempInfo);
                        }
                    }
                    #endregion

                    #region 将当前对象的命名进行重新设置
                    for (int index = 1; index <= lstObject.Count; index++)
                    {
                        if (!lstNumber.Contains(index))
                        {
                            strName = strNamePrefix + index.ToString();
                            break;
                        }
                    }

                    if (string.IsNullOrEmpty(strName))
                    {
                        strName = strNamePrefix + (lstObject.Count + 1).ToString();
                    }
                    #endregion
                }
            }
            else
            {
                strName = strNamePrefix + "1";
            }

            return strName;
        }

        /// <summary>
        /// 根据选择的倍率对指定对象的相关size进行缩放处理
        /// </summary>
        /// <param name="objectItem">指定对象</param>
        /// <param name="pagesizePercent">选择的倍率</param>
        private void SetObjectSizeByPagesizePercent(AojReportObject objectItem, float pagesizePercent)
        {
            float objectCurrentPagesizePercent = objectItem.ObjectCurrentPagesizePercent;

            #region 根据选择的倍率对相关size进行缩放的详细处理
            //对象顶端位置
            objectItem.Top = objectItem.Top / objectCurrentPagesizePercent * pagesizePercent;
            //对象左端位置
            objectItem.Left = objectItem.Left / objectCurrentPagesizePercent * pagesizePercent;
            //对象宽度
            objectItem.Width = objectItem.Width / objectCurrentPagesizePercent * pagesizePercent;
            //对象高度
            objectItem.Height = objectItem.Height / objectCurrentPagesizePercent * pagesizePercent;
            //文本的字体大小
            objectItem.TextFontSize = objectItem.TextFontSize / objectCurrentPagesizePercent * pagesizePercent;
            #endregion

            objectItem.ObjectCurrentPagesizePercent = pagesizePercent;
        }

        #endregion
    }
}
