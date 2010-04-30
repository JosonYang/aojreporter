using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using AojReport.AojPrintEngine.Common;
using System.Xml;

namespace AojReport.AojPrintEngine.AojPrintGraphicsParse
{
    internal class AojPrintPaper 
        : IAojPrintObjectParse,
        ICloneable,
        IDisposable
    {
        #region  属性定义
        private string _id;
        /// <summary>
        /// Tag的唯一ID
        /// </summary>
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _width = 596;
        /// <summary>
        /// 打印区域宽度
        /// </summary>
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }
        
        private int _height = 840;
        /// <summary>
        /// 打印区域高度
        /// </summary>
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }
        
        private string _paperSizeName = "A4";
        /// <summary>
        /// 打印纸类型
        /// </summary>
        public string PaperSizeName
        {
            get { return _paperSizeName; }
            set { _paperSizeName = value; }
        }
        
        private string _orientation = "Portrait";
        /*
           Unknown 将此功能（其选项由此枚举表示）设置为未在Print Schema中定义的选项。 
           Landscape 将成像区域的内容从标准（纵向）方向逆时针方向旋转 90 。 
           Portrait 标准方向。 
           ReverseLandscape 将成像区域的内容从标准（纵向）方向顺时针方向旋转 90 。 
           ReversePortrait 将成像区域的内容倒置（相对于标准（纵向）方向）。 
         */
        /// <summary>
        /// 指定如何在打印介质上确定内容页的方向。
        /// </summary>
        public string Orientation
        {
            get { return _orientation; }
            set { _orientation = value; }
        }
        
        private int _margin = 1;
        /// <summary>
        /// 页面边缘宽度
        /// </summary>
        public int Margin
        {
            get { return _margin; }
            set { _margin = value; }
        }
        
        //TODO:未使用
        private float _pageScale = 1.0f;
        //PageScale默认为1.0f;
        public float PageScale
        {
            get { return _pageScale; }
            set { _pageScale = value; }
        }
        
        private ArrayList _objectArray;
        /// <summary>
        /// 本Paper内基础对象集合
        /// </summary>
        public ArrayList ObjectArray
        {
            get { return _objectArray; }
        }

        private Bitmap _image;

        public Bitmap Image
        {
            get { return _image; }
            set { _image = value; }
        }
        #endregion

        #region  构造函数
        public AojPrintPaper() 
        {
            _objectArray = new ArrayList();
        }
        protected AojPrintPaper(AojPrintPaper obj)
        {
            _objectArray = new ArrayList();
            this._id = obj.Id;
            this._width = obj.Width;
            this._height = obj.Height;
            this._paperSizeName = obj.PaperSizeName;
            this._orientation = obj.Orientation;
            this._margin = obj.Margin;
            this._pageScale = obj.PageScale;
            foreach (object o in obj.ObjectArray)
            {
                this._objectArray.Add(((ICloneable)o).Clone());
            }
        }
        #endregion

        #region 接口实现
        #region IAojPrintObjectParse Members
        public void Save(XmlWriter writer)
        {
            writer.WriteStartElement("AojPaper");
            writer.WriteAttributeString("Id", this.Id);
            writer.WriteAttributeString("Width", this.Width.ToString());
            writer.WriteAttributeString("Height", this.Height.ToString());
            writer.WriteAttributeString("PaperSizeName", this.PaperSizeName);
            writer.WriteAttributeString("Orientation", this.Orientation);
            writer.WriteAttributeString("Margin", this.Margin.ToString());

            foreach (Object obj in this._objectArray)
            {
                if (obj is IAojPrintObjectParse)
                {
                    ((IAojPrintObjectParse)obj).Save(writer);
                }

            }
            writer.WriteEndElement();
        }

        public bool Parse(AojPrintXmlReader aojXmlReader)
        {
            //Paper节点访问后得到的属性
            Hashtable hstPaper = aojXmlReader.Attributes;
            //如果本paper没有Id则默认为Group
            this._id = AojUnitConvert.SafeToString(hstPaper, "Id", "PaperGroup");
            this._width = AojUnitConvert.SafeToInt(hstPaper, "Width", 596);
            this._height = AojUnitConvert.SafeToInt(hstPaper, "Height", 840);
            this._paperSizeName = AojUnitConvert.SafeToString(hstPaper, "PaperSizeName", "A4");
            this._orientation = AojUnitConvert.SafeToString(hstPaper, "Orientation", "Portrait");
            this._margin = AojUnitConvert.SafeToInt(hstPaper, "Margin", 1);

            while (aojXmlReader.Read())
            {
                //当读取器读到结束节点为AojPaper时，说明一张页面已经读取完毕
                //然后由AojPrint类，继续读取进行下一轮的Paper创建
                if (aojXmlReader.IsEndElement("AojPaper"))
                {
                    break;
                }
                switch (aojXmlReader.TagName)
                {
                    case "Label":
                        {
                            //读到Label节点时，进行Label节点属性的读取
                            AojPrintLabel printLabel = new AojPrintLabel();
                            printLabel.Parse(aojXmlReader);
                            this._objectArray.Add(printLabel);
                        }
                        break;
                    case "Image":
                        {
                            //读到Image节点时，进行Image节点属性的读取
                            AojPrintImage printImage = new AojPrintImage();
                            printImage.Parse(aojXmlReader);
                            this._objectArray.Add(printImage);
                        }
                        break;
                    case "Table":
                        {
                            //读到Table节点时，进行Table节点属性的读取
                            AojPrintTable printTable = new AojPrintTable();
                            printTable.Parse(aojXmlReader);
                            this._objectArray.Add(printTable);
                        }
                        break;
                    default:  //查找自定义插件中的对象
                        {
                            AojPrintSettings settings= AojPrintSettings.CreateInstance();
                            KeyValuePair<string,object> CurrentPlugin =settings.lstPlugin.Find((plk) => plk.Key == aojXmlReader.TagName);
                            if (CurrentPlugin.Value is IAojPrintObjectParse)
                            {
                                IAojPrintObjectParse aojPluginObject= (IAojPrintObjectParse)CurrentPlugin.Value;
                                //用此类库Parse完后保存在对象集合中
                                aojPluginObject.Parse(aojXmlReader);
                                this._objectArray.Add(aojPluginObject);
                                //因为该类对象的所有操作后，属性系统都为引用，因此要Clone一下
                                this._objectArray = (ArrayList)this._objectArray.Clone();
                            }
                        }
                        break;
                }
            }
            return true;
        }

        public void Print(Graphics g)
        {
            foreach (object obj in _objectArray)
            {
                if (obj is IAojPrintObjectParse)
                {
                    /**
                     * 本DLL类所有可绘画对象均继承基础接口IAojPrintObjectParse
                     * 这个类中定义了读写格式文件和打印所需要的方法。
                     * 
                     */
                    ((IAojPrintObjectParse)obj).Print(g);
                }
            }
        }
        #endregion
    
        #region ICloneable Members

        public object Clone()
        {
            AojPrintPaper printpaper = new AojPrintPaper(this);
            return printpaper;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            _objectArray.Clear();
            GC.Collect();
            this.Dispose();
        }

        #endregion
        #endregion

        #region 逻辑封装
        /// <summary>
        /// 创建空白图像用于纸张打印
        /// 
        /// 读取Paper基本属性，用于进行打印
        /// </summary>
        /// <param name="aojXmlReader">XML文件读取器</param>
        /// <returns></returns>
        public Graphics CreateGraphics(AojPrintPaper paper)
        {
            //创建一块空白的图像区域
            paper.Image = new Bitmap(paper.Width, paper.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            //图像对象的创建
            Graphics g = Graphics.FromImage(paper.Image);
            g.PageUnit = GraphicsUnit.Pixel;
            g.PageScale = AojUnitConvert.SafeToSingle(this._pageScale);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.FillRectangle(AojGrapicsHelper.GetBrush("#FFFFFF"), 0f, 0f, paper.Width, paper.Height);
            
            return g;
        }
        #endregion
    }
}
