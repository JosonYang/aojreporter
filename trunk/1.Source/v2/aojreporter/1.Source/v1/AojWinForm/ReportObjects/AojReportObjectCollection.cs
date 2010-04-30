using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Drawing;
using AojReport.AojWinForm.Common;
using AojReport.AojWinForm.Tools;

namespace AojReport.AojWinForm.ReportObjects
{
    /// <summary>
    /// 报表设计区域的对象集合
    /// </summary>
    public class AojReportObjectCollection : CollectionBase
    {
        #region Constructor(构造函数)

        /// <summary>
        /// Constructor(构造函数)
        /// </summary>
        public AojReportObjectCollection() : base() { }

        #endregion

        #region Field(变量)

        /// <summary>
        /// 用来保存报表设计器区域被选中的对象
        ///</summary>
        private List<AojReportObject> lstObjectSelected = new List<AojReportObject>();

        #endregion

        #region Property(属性)

        /// <summary>
        /// 用来保存报表设计器区域被选中的对象
        /// </summary>
        public List<AojReportObject> ListObjectSelected
        {
            get
            {
                return this.lstObjectSelected;
            }
            set
            {
                this.lstObjectSelected = value;
            }
        }

        #endregion

        #region Method(方法)

        /// <summary>
        /// 添加新的对象
        /// </summary>
        /// <param name="objectInfo">新的对象</param>
        public void Add(AojReportObject objectInfo)
        {
            objectInfo.Selected = true;
            this.lstObjectSelected.Insert(0, objectInfo);
            this.List.Insert(0, objectInfo);
        }

        /// <summary>
        /// 移除指定对象
        /// </summary>
        /// <param name="objectInfo">指定对象</param>
        public void Delete(AojReportObject objectInfo)
        {
            this.List.Remove(objectInfo);
            this.lstObjectSelected.Remove(objectInfo);
        }

        /// <summary>
        /// 根据索引获得具体指定的对象
        /// </summary>
        /// <param name="index">索引Index</param>
        /// <returns>具体指定的对象</returns>
        public AojReportObject GetObjectByIndex(int index)
        {
            return (AojReportObject)this.List[index];
        }

        /// <summary>
        /// 对象的绘制
        /// </summary>
        /// <param name="g">对象的绘制载体</param>
        public void DesignDraw(Graphics g)
        {
            int objectCount = this.List.Count;
            AojReportObject objInfo;
            for (int index = objectCount - 1; index >= 0; index--)
            {
                objInfo = (AojReportObject)this.List[index];
                objInfo.DesignDraw(g);
                if (objInfo.Selected && !objInfo.IsMouseDownFlag)
                {
                    objInfo.DrawTracker(g);
                }
            }
        }

        /// <summary>
        /// 释放选中的全部对象
        /// </summary>
        public void UnselectAll()
        {
            foreach (AojReportObject item in this.List)
            {
                item.Selected = false;
            }
            this.lstObjectSelected.Clear();
        }

        /// <summary>s
        /// 选中报表设计器区域的所有对象
        /// </summary>
        public void SelectAll()
        {
            foreach (AojReportObject item in this.List)
            {
                item.Selected = true;
                if (!this.lstObjectSelected.Contains(item))
                {
                    this.lstObjectSelected.Add(item);
                }
            }
        }

        /// <summary>
        /// 获得指定的对象在对象集合中的个数
        /// </summary>
        /// <param name="objectInfo">指定对象</param> 
        /// <returns>指定的对象在对象集合中的个数</returns>
        public int GetSpecialObjectCountInfo(AojConst.DrawToolType objectType)
        {
            int objectCount = 0;//指定的对象在对象集合中的个数

            #region 获得当前报表设计器区域内的所有对象
            List<AojReportObject> lstAllObject = new List<AojReportObject>();
            foreach (AojReportObject item in this.List)
            {
                lstAllObject.Add(item);
            }
            #endregion

            switch (objectType)
            {
                case AojConst.DrawToolType.Label:
                    //从报表设计区域得到指定类型对象的集合
                    List<AojLabel> lstLabelObject = AojCommonFnc.GetObjectByType<AojLabel>(lstAllObject);
                    objectCount = this.GetObjectCount(lstLabelObject, AojConst.NamePrefix.Label);
                    break;
                case AojConst.DrawToolType.Table:
                    //从报表设计区域得到指定类型对象的集合
                    List<AojTable> lstTableObject = AojCommonFnc.GetObjectByType<AojTable>(lstAllObject);
                    objectCount = this.GetObjectCount(lstTableObject, AojConst.NamePrefix.Table);
                    break;
                case AojConst.DrawToolType.Image:
                    //从报表设计区域得到指定类型对象的集合
                    List<AojImage> lstImageObject = AojCommonFnc.GetObjectByType<AojImage>(lstAllObject);
                    objectCount = this.GetObjectCount(lstImageObject, AojConst.NamePrefix.Image);
                    break;
                default:
                    break;
            }
            return objectCount;
        }

        /// <summary>
        /// 获得指定对象的类型
        /// </summary>
        /// <param name="objectInfo">指定对象</param>
        /// <returns>指定对象的类型</returns>
        public AojConst.DrawToolType GetObjectType(AojReportObject objectInfo)
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
        /// 得到指定的对象在对象集合中的个数
        /// </summary>
        /// <returns>指定的对象在对象集合中的个数</returns>
        private int GetObjectCount<T>(List<T> lstObject, string strNamePrefix)
            where T:AojReportObject
        {
            int objectCountInfo = 0;
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
                            objectCountInfo = index;
                            break;
                        }
                    }

                    if (objectCountInfo == 0)
                    {
                        objectCountInfo = lstObject.Count + 1;
                    }
                    #endregion
                }
            }
            else
            {
                objectCountInfo = 1;
            }

            return objectCountInfo;
        }

        /// <summary>
        /// 将把在给定设计区域的所有对象全部选中
        /// </summary>
        /// <param name="rectanglef">给定的区域</param>
        public void SelectInRectangle(RectangleF rectanglef)
        {
            UnselectAll();
            foreach (AojReportObject item in this.List)
            {
                if (item.IntersectsWith(rectanglef))
                {
                    item.Selected = true;

                    #region 加入报表设计器区域被选中的对象中
                    if (!this.lstObjectSelected.Contains(item))
                    {
                        this.lstObjectSelected.Add(item);
                    }
                    #endregion
                }
            }
        }

        #endregion
    }
}
