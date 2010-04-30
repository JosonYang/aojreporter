#region 翱捷报表软件
/**********************************************
 * 版权：Copyright @2009 翱捷报表
 * 
 * 
 * 描述：文件目录操作类库
 * 
 * 
 * 日期：
 * 
 **********************************************/
#endregion
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace AojReport.AojWinForm.Common
{
    /// <summary>
    /// 文件目录操作类库
    /// </summary>
    public class AojFilesHelper
    {
        #region 目录操作

        /// <summary>
        /// 在某目录下是否存在文件，如果有返回true，没有返回false
        /// </summary>
        /// <param name="strPath"></param>
        /// <returns></returns>
        public static bool isFileExistDirectory(string strPath)
        {
            string[] strFiles = Directory.GetFiles(strPath);
            if (strFiles.Length > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 删除目录，此删除操作，直接删除包括子目录和文件
        /// </summary>
        /// <param name="strPath">目录路径</param>
        /// <returns></returns>
        public static bool DeleteDirectory(string strPath)
        {
            if (Directory.Exists(strPath))
            {
                ///删除文件，包括子目录和文件
                Directory.Delete(strPath, true);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///  创建目录
        /// </summary>
        /// <param name="strPath"></param>
        /// <returns></returns>
        public static bool CreateDirectory(string strPath)
        {
            //创建目录
            Directory.CreateDirectory(strPath);
            if (Directory.Exists(strPath))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取当前目录地址
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentDicretory()
        {
            return Directory.GetCurrentDirectory();
        }

        /// <summary>
        /// 移动目录
        /// </summary>
        /// <param name="sourceDirectory">源地址</param>
        /// <param name="targetDirectory">目标地址</param>
        public static void MoveAll(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);//源地址
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);//目标地址

            MoveAll(diSource, diTarget);
        }

        /// <summary>
        /// 移动目录中所有东西
        /// </summary>
        /// <param name="source">源目录</param>
        /// <param name="target">目标目录</param>
        public static void MoveAll(DirectoryInfo source, DirectoryInfo target)
        {
            // 目标目录不存在,创建目录
            if (Directory.Exists(target.FullName) == false)
            {
                CreateDirectory(target.FullName);
            }

            // 移动文件
            foreach (FileInfo fi in source.GetFiles())
            {
                MoveFile(target.ToString(),fi);
            }

            //移动子目录和文件
            //这里主要是利用递归调用，进行目录和文件的移动
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                ///递归方法
                MoveAll(diSourceSubDir, nextTargetSubDir);
            }
        }

        #endregion

        #region 文件操作

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="strPath">文件完整路径</param>
        /// <returns></returns>
        public static void DeleteFiles(string strPath)
        {
            if (File.Exists(strPath))
            {
                File.Delete(strPath);
            }
        }

        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="target">目标地址</param>
        /// <param name="fi">文件信息</param>
        public static void MoveFile(string target,FileInfo fi)
        {
            fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
        }

        #endregion
    }
}