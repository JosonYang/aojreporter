using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace AojReport.AojPrintEngine.Common
{
    public class AojUnitConvert
    {
        public static int SafeRound(object obj)
        {
            int iResult;
            try
            {
                iResult = AojUnitConvert.SafeToInt(Math.Round(AojUnitConvert.SafeToSingle(obj),MidpointRounding.AwayFromZero));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                iResult = 0;
            }
            return iResult;
        }

        public static int SafeToInt(object obj)
        {
            int iResult;
            try
            {
                iResult = Int32.Parse(obj.ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                iResult = 0;
            }
            return iResult;
        }

        public static int SafeToInt(object obj, int iDefault)
        {
            int iResult;
            try
            {
                iResult = Int32.Parse(obj.ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                iResult = iDefault;
            }
            return iResult;
        }

        public static int SafeToInt(Hashtable h, object obj, int iDefault)
        {
            int iResult;
            try
            {
                if (h.ContainsKey(obj))
                {
                    iResult = Int32.Parse(h[obj].ToString());
                }
                else
                {
                    iResult = iDefault;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                iResult = iDefault;
            }
            return iResult;
        }

        public static string SafeToString(object obj,string strDefault)
        {
            string strResult;
            if (string.IsNullOrEmpty(obj.ToString()))
            {
                strResult = strDefault;
            }
            else
            {
                strResult = obj.ToString();
            }

            return strResult;
        }

        public static string SafeToString(Hashtable h, object obj, string strDefault)
        {
            string strResult;
            try
            {
                if (h.ContainsKey(obj))
                {
                    strResult = h[obj].ToString();
                }
                else
                {
                    strResult = strDefault;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                strResult = strDefault;
            }
            return strResult;
        }
        
        public static Single SafeToSingle(object obj)
        {
            Single siResult;
            try
            {
                siResult= Single.Parse(obj.ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                siResult =0f;
            }
            return siResult;
        }

        public static Single SafeToSingle(Hashtable h, object obj, Single fDefualt)
        {
            Single fResult;
            try
            {
                if (h.ContainsKey(obj))
                {
                    fResult = Single.Parse(h[obj].ToString());
                }
                else
                {
                    fResult = fDefualt;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                fResult = fDefualt;
            }
            return fResult;
        }

        /// <summary>
        /// 将base64编码后的字符串转化为图片
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Image ImageFromBase64String(string value)
        {
            Image img = null;
            try
            {
                byte[] buffer = Convert.FromBase64String(value);
                MemoryStream ms = new MemoryStream(buffer, 0, buffer.Length);
                img = Image.FromStream(ms);
                return img;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return img;
            }
        }

        /// <summary>
        /// 将图片转化为字符串
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static string ImageToBase64String(Image image)
        {
            string value = "";

            ImageConverter iconv = new ImageConverter();
            byte[] b = (byte[])iconv.ConvertTo(image, typeof(byte[]));
            value = Convert.ToBase64String(b);

            return value;
        }

        /// <summary>
        /// 从文件路径中读取图片
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static Image ImageFromFile(string path)
        {
            Image img = null;
            try
            {
                img = Image.FromFile(path);
                return img;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return img;
            }
        }

        /// <summary>
        /// 由二维中的填充点单位转化为毫米单位
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Single PointToMM(Single point)
        {
            return AojUnitConvert.SafeToSingle(point * 25.4 / 72);
        }
        
        /// <summary>
        /// 有毫米单位转化为二维图形中的填充点单位
        /// </summary>
        /// <param name="mm">毫米</param>
        /// <returns></returns>
        public static int MMToPoint(Single mm)
        {
            return AojUnitConvert.SafeToInt(mm * 72 / 25.4);
        }

        /// <summary>
        /// 将像素转换为毫米
        /// </summary>
        /// <param name="pixel"></param>
        /// <returns></returns>
        public static Single PixelToMM(int pixel)
        {
            return AojUnitConvert.SafeToSingle(pixel * 25.4 / 96);
        }

        /// <summary>
        /// 将毫米转化为像素
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public static int MMToPixel(Single mm)
        {
            return AojUnitConvert.SafeToInt(mm * 96 / 25.4);
        }

        /// <summary>
        /// 将字符串转化为已知枚举类型
        /// </summary>
        /// <param name="T">枚举类型</param>
        /// <param name="U">字符串类型，枚举的整型值或者字符串</param>
        /// <param name="u"></param>
        /// <returns></returns>
        public static T GetEnumType<T, U>(U u)
        {
            T t;
            try
            {
                t = (T)Enum.Parse(typeof(T), Convert.ToString(u));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                t = (T)Enum.Parse(typeof(T), "0");
            }
            return t;
        }
    }
}
