using System;
using System.Xml;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Printing;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using AojReport.AojPrintEngine.Common;
using System.Data;

namespace AojReport.AojPrintEngine.AojPrintGraphicsParse
{
    /// <summary>
    /// 直接读取包含数据的文件的打印
    /// 
    /// 最终返回到AojPrint中
    /// </summary>
    internal class AojMainPrinter
    {
        #region  属性定义
        private AojPrintXmlReader reader;
        private ArrayList TemplatesObjectList;
        public ArrayList GraphicsObjectList;
        //test 
        public List<Image> imglist = new List<Image>();
        #endregion

        #region 构造函数
        public AojMainPrinter()
        {
            TemplatesObjectList = new ArrayList();
            GraphicsObjectList = new ArrayList();
        }
        #endregion

        #region  方法流程

        public void Parse(string[] urlArray)
        {
            if (1 > urlArray.Length)
            {
                return;
            }
            foreach (string strPathIndex in urlArray)
            {
                this.Parse(strPathIndex);
            }
        }

        public void Parse(string url)
        {
            //创建报表Xml读取器对象
            AojPrintXmlReader reader = new AojPrintXmlReader(url);
            //使Xml读取器初始化
            reader.Initialize();
            //读取节点
            while (reader.Read())
            {
                switch (reader.TagType)
                {
                    case XmlNodeType.Element:
                        {
                            /**
                             * AojPaper代表一张新的报表画面
                             * 
                             * 一个翱捷报表存储文件里面可能包含多个AojPaper标签
                             * 它代表着可以打印出几张报表画面
                             * 
                             * 根据此节点，获取相应的纸张配置和打印信息。
                             * 对此节点下的所有内容进行打印。
                             * 
                             * 打印后的结果为图像，保存在集合中供PrintDocument使用
                             */
                            if (reader.TagName.Equals("AojPaper", StringComparison.CurrentCultureIgnoreCase))
                            {

                                AojPrintPaper currentPaper = new AojPrintPaper();
                                //开始读取，该节点下的所有信息，该信息包括含有哪些数据，如果表现这样数据
                                //这些数据都会保存在AojPrintPaper中的_objectArray中
                                if (!currentPaper.Parse(reader))
                                {
                                    continue;
                                }
                                //最终打印操作，遍历_objectArray中的对象，利用对象中自身的打印操作去描绘
                                //将创建好的图加到图像集合中去
                                this.TemplatesObjectList.Add(currentPaper);
                            }
                        }
                        break;
                }
            }
        }

        public void DoPrint()
        {
            foreach (object obj in this.GraphicsObjectList)
            {
                //if (obj is AojPrintPaper)
                {
                    /**
                     * 本DLL类所有可绘画对象均继承基础接口IAojPrintObjectParse
                     * 这个类中定义了读写格式文件和打印所需要的方法。
                     * 
                     */
                    AojPrintPaper currentPaper = obj as AojPrintPaper;
                    if (currentPaper == null)
                    {
                        continue;
                    }
                    Graphics g = currentPaper.CreateGraphics(currentPaper);
                    currentPaper.Print(g);

                    this.imglist.Add(currentPaper.Image);
                }
            }  
        }

        public void Save()
        {
            AojPrintSettings settings = AojPrintSettings.CreateInstance();
            AojPrintXmlWriter writer = new AojPrintXmlWriter(settings.AojdPath);
            writer.Initialize();
            foreach (object obj in GraphicsObjectList)
            {
                writer.Save((AojPrintPaper)obj);
            }
            writer.Close();
        }
        #endregion

        #region 绑定设置
        /// <summary>
        /// 设置某模板全局的打印
        /// </summary>
        /// <param name="postion">要写入的对象ID</param>
        /// <param name="value">赋值</param>
        /// <param name="paper">AojPrintPaper对象或者是AojPrintPaper的ID值</param>
        public void SetStaticPropertyByPosition(string postion, string value, object paper, bool isImage)
        {
            foreach (AojPrintPropertySystem apps in this.FindObjectsById(postion, GetTemplateCurrentPaper(paper)))
            {
                if (isImage)
                {
                    apps.Src = value;
                }
                else
                {
                    apps.Value = value;
                }
            }

        }
        /// <summary>
        /// 设置某模板全局的打印
        /// </summary>
        /// <param name="postion">要写入的对象ID</param>
        /// <param name="value">图像</param>
        /// <param name="paper">AojPrintPaper对象或者是AojPrintPaper的ID值</param>
        public void SetStaticPropertyByPosition(string postion, Image image, object paper)
        {
            foreach (AojPrintPropertySystem apps in this.FindObjectsById(postion, GetTemplateCurrentPaper(paper)))
            {
                apps.ImgPrint = image;
            }
        }
        /// <summary>
        ///  对绑定数据后的位置进行打印
        /// </summary>
        /// <param name="postion"></param>
        /// <param name="value"></param>
        /// <param name="paper"></param>
        public void SetPrintValueByPosition(string postion, string value, int paper,bool isImage)
        {
            foreach (AojPrintPropertySystem apps in this.FindObjectsById(postion, GetCurrentPaper(paper)))
              {
                  if (isImage)
                  {
                      apps.Src = value;
                  }
                  else
                  {
                      apps.Value = value;
                  }
              }
        }
        /// <summary>
        ///  对绑定数据后的位置进行打印
        /// </summary>
        /// <param name="postion"></param>
        /// <param name="value"></param>
        /// <param name="paper"></param>
        public void SetPrintImageByPosition(string postion, Image image, int paper)
        {
            foreach (AojPrintPropertySystem apps in this.FindObjectsById(postion, GetCurrentPaper(paper)))
            {
                apps.ImgPrint = image;
            }
        }

        /// <summary>
        /// 打印List,模版文件中Grid对应打印表，如果超数则分页
        /// </summary>
        /// <param name="dtSource">打印源数据</param>
        /// <param name="paper">当前打印模板</param>
        public void PrintDataTableToList(string postion,object paper,DataTable dtSource)
        {
            if (dtSource == null)
            {
                return;
            }
            if (1 > dtSource.Rows.Count)
            {
                return;
            }
            #region 模板取得
            AojPrintPaper aojpaper = (AojPrintPaper)this.GetTemplateCurrentPaper(paper).Clone();
            #endregion

            #region 分页计算
            AojPrintTable apt = FindObject<AojPrintTable>(aojpaper.ObjectArray, (key) => key.Id == postion)[0];

            int nPageBreak = 1;                
            //大于的时候考虑求余
            if (apt.Rows.Count < dtSource.Rows.Count)
            {
                nPageBreak = dtSource.Rows.Count / apt.Rows.Count;
                //求余有多出来的部分 加1
                if (dtSource.Rows.Count % apt.Rows.Count > 0)
                {
                    nPageBreak = nPageBreak + 1;
                }
            }
            #endregion

            #region 数据填充
            //分页
            for (int nbreak = 0; nbreak < nPageBreak; nbreak++)
            {
                AojPrintPaper printpaper = (AojPrintPaper)aojpaper.Clone();
                apt = FindObject<AojPrintTable>(printpaper.ObjectArray, (key) => key.Id == postion)[0];
                //每页多少条数据
                for (int nStart = 0; nStart < apt.Rows.Count; nStart++)
                {
                    //获取当前行所有的单元格
                    List<AojPrintTable.Cell> Cells = apt.GetCurrentRowExistCell(nStart);
                    for (int nCol = 0; nCol < apt.Columns.Count;)
                    {
                        if (dtSource.Rows.Count <= nStart + apt.Rows.Count * nbreak)
                        {
                            break;
                        }
                        //赋值 ,Column的ID值为绑定字段
                        Cells[nCol].Value = dtSource.Rows[nStart + apt.Rows.Count * nbreak][apt.Columns[nCol].Id].ToString();

                        //考虑colspan的情况
                        if (Cells[nCol].ColSpan > 1)
                        {
                            nCol += Cells[nCol].ColSpan;
                        }
                        else
                        {
                            nCol += 1;
                        }
                    }
                }
                this.GraphicsObjectList.Add(printpaper);
            }
            #endregion
        }
        /// <summary>
        /// 根据ID赋值打印，此方法与数据的关系为，单条记录就为一页
        /// </summary>
        /// <param name="postion">打印地方</param>
        /// <param name="paper">打印模板</param>
        /// <param name="dtSource">打印源数据</param>
        public void PrintDataTableToPoint(string postion, object paper, DataTable dtSource)
        {
            if (dtSource == null)
            {
                return;
            } 
        }
        /// <summary>
        /// 获取报表模板
        /// </summary>
        /// <param name="paper">AojPrintPaper object</param>
        /// <returns></returns>
        private AojPrintPaper GetTemplateCurrentPaper(object paper)
        {
            AojPrintPaper obj = paper as AojPrintPaper;
            if (obj == null)
            {
                foreach(object objIndex in this.TemplatesObjectList)
                {
                    if (paper.ToString() == ((AojPrintPaper)objIndex).Id)
                    {
                        obj = (AojPrintPaper)objIndex;
                    }
                }
            }
            return obj;
        }
        /// <summary>
        /// 根据ID找到对象
        /// </summary>
        /// <param name="strId"></param>
        /// <param name="paper"></param>
        /// <returns></returns>
        public List<AojPrintPropertySystem> FindObjectsById(string strId, AojPrintPaper paper)
        {
            List<AojPrintPropertySystem> lstapps = this.FindObject<AojPrintPropertySystem>(paper.ObjectArray
                    , (key) => key.Id == strId);
            return lstapps;
        }
        /// <summary>
        ///  获取当前打印
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public AojPrintPaper GetCurrentPaper(int page)
        {
            if (this.GraphicsObjectList.Count <= page)
            {
                return null;
            }
            return this.GraphicsObjectList[page] as AojPrintPaper;
        }
        #endregion

        #region  Inner Method
        private List<T> FindObject<T>(ArrayList array, Predicate<T> match)
          where T : class
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (match == null)
            {
                throw new ArgumentNullException("match");
            }
            List<T> lst = new List<T>();
            foreach (object obj in array)
            {
                if (obj is AojPrintTable)
                {
                    foreach (object cell in ((AojPrintTable)obj).Cells)
                    {
                        if (cell is T)
                        {
                            if (match((T)cell))
                            {
                                lst.Add((T)cell);
                            }
                        }
                    }
                }
                if (obj is T)
                {
                    if (match((T)obj))
                    {
                        lst.Add((T)obj);
                    }
                }
            }
            return lst;
        }
        #endregion

    }
}

