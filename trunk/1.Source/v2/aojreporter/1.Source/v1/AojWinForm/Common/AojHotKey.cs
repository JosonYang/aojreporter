#region 翱捷报表软件
/**********************************************
 * 版权：Copyright @2009 翱捷报表
 * 
 * 
 * 描述：实现注册热键
 * 
 * 
 * 日期：
 * 
 **********************************************/
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AojReport.AojWinForm.Common
{
    /// <summary>
    /// 实现注册热键
    /// </summary>
    public class AojHotKey
    {
        /// <summary>
        /// 注册热键
        /// 如果函数执行成功，返回值不为0。 
        /// 如果函数执行失败，返回值为0。要得到扩展错误信息，调用GetLastError。
        /// </summary>
        /// <param name="hWnd">要定义热键的窗口的句柄</param>
        /// <param name="id">定义热键ID（不能与其它ID重复）</param>
        /// <param name="fsModifiers">标识热键是否在按Alt、Ctrl、Shift、Windows等键时才会生效</param>
        /// <param name="vk">定义热键的内容</param>
        /// <returns></returns>
        [DllImport("user32.dll ", SetLastError = true)]
        public static extern bool RegisterHotKey(
                IntPtr hWnd,
                int id,
                KeyModifiers fsModifiers,
                Keys vk
                );

        /// <summary>
        /// 取消热键
        /// </summary>
        /// <param name="hWnd">要取消热键的窗口的句柄</param>
        /// <param name="id">要取消热键的ID</param>
        /// <returns></returns>
        [DllImport("user32.dll ", SetLastError = true)]
        public static extern bool UnregisterHotKey(
                IntPtr hWnd,
                int id
                );

        /// <summary>
        /// 定义辅助键的名称
        /// </summary>
        [Flags()]
        public enum KeyModifiers
        {
            #region 单键
            None = 0,
            Alt = 1,
            Ctrl = 2,
            Shift = 4,
            WindowsKey = 8,
            #endregion

            #region 组合
            CtrlShift = 6,
            #endregion
        }

        /// <summary>
        /// 定义热键ID（不能与其它ID重复）
        /// </summary>
        public struct HotKeyID
        {
            /// <summary>
            /// Undo
            /// </summary>
            public const int hotKeyID_Undo = 100;

            /// <summary>
            /// Redo
            /// </summary>
            public const int hotKeyID_Redo = 150;

            /// <summary>
            /// Cut
            /// </summary>
            public const int hotKeyID_Cut = 200;

            /// <summary>
            /// Copy
            /// </summary>
            public const int hotKeyID_Copy = 250;

            /// <summary>
            /// Paste
            /// </summary>
            public const int hotKeyID_Paste = 300;

            /// <summary>
            /// Delete
            /// </summary>
            public const int hotKeyID_Delete = 350;

            /// <summary>
            /// SelectAll
            /// </summary>
            public const int hotKeyID_SelectAll = 400;

            /// <summary>
            /// New
            /// </summary>
            public const int hotKeyID_New = 450;

            /// <summary>
            /// Open
            /// </summary>
            public const int hotKeyID_Open = 500;

            /// <summary>
            /// Save
            /// </summary>
            public const int hotKeyID_Save = 550;
        }

        /// <summary>
        /// 注册要用到的所有热键
        /// </summary>
        /// <param name="hWnd">要定义热键的窗口的句柄</param>
        public static void RegisterHotKeyToForm(IntPtr hWnd)
        {
            #region 注册要用到的所有热键
            RegisterHotKey(hWnd, HotKeyID.hotKeyID_New, KeyModifiers.Ctrl, Keys.N);         //Ctrl+N
            RegisterHotKey(hWnd, HotKeyID.hotKeyID_Open, KeyModifiers.Ctrl, Keys.O);        //Ctrl+O
            RegisterHotKey(hWnd, HotKeyID.hotKeyID_Save, KeyModifiers.Ctrl, Keys.S);        //Ctrl+S
            #endregion
        }

        /// <summary>
        /// 注册要用到的所有热键
        /// </summary>
        /// <param name="hWnd">要定义热键的窗口的句柄</param>
        public static void RegisterHotKeyToDrawSpace(IntPtr hWnd)
        {
            #region 注册要用到的所有热键
            RegisterHotKey(hWnd, HotKeyID.hotKeyID_Undo, KeyModifiers.Ctrl, Keys.Z);        //Ctrl+Z
            RegisterHotKey(hWnd, HotKeyID.hotKeyID_Redo, KeyModifiers.Ctrl, Keys.Y);        //Ctrl+Y
            RegisterHotKey(hWnd, HotKeyID.hotKeyID_Cut, KeyModifiers.Ctrl, Keys.X);         //Ctrl+X
            RegisterHotKey(hWnd, HotKeyID.hotKeyID_Copy, KeyModifiers.Ctrl, Keys.C);        //Ctrl+C
            RegisterHotKey(hWnd, HotKeyID.hotKeyID_Paste, KeyModifiers.Ctrl, Keys.V);       //Ctrl+V
            RegisterHotKey(hWnd, HotKeyID.hotKeyID_Delete, KeyModifiers.None, Keys.Delete); //Del
            RegisterHotKey(hWnd, HotKeyID.hotKeyID_SelectAll, KeyModifiers.Ctrl, Keys.A);   //Ctrl+A
            #endregion
        }

        /// <summary>
        /// 注销所有的热键
        /// </summary>
        /// <param name="hWnd">定义热键的窗口的句柄</param>
        public static void UnregisterHotKeyFromForm(IntPtr hWnd)
        {
            #region 注销所有的热键
            UnregisterHotKey(hWnd, HotKeyID.hotKeyID_New);          //Ctrl+N
            UnregisterHotKey(hWnd, HotKeyID.hotKeyID_Open);         //Ctrl+O
            UnregisterHotKey(hWnd, HotKeyID.hotKeyID_Save);         //Ctrl+S
            #endregion
        }

        /// <summary>
        /// 注销所有的热键
        /// </summary>
        /// <param name="hWnd">定义热键的窗口的句柄</param>
        public static void UnregisterHotKeyFromDrawSpace(IntPtr hWnd)
        {
            #region 注销所有的热键
            UnregisterHotKey(hWnd, HotKeyID.hotKeyID_Undo);         //Ctrl+Z
            UnregisterHotKey(hWnd, HotKeyID.hotKeyID_Redo);         //Ctrl+Y
            UnregisterHotKey(hWnd, HotKeyID.hotKeyID_Cut);          //Ctrl+X
            UnregisterHotKey(hWnd, HotKeyID.hotKeyID_Copy);         //Ctrl+C
            UnregisterHotKey(hWnd, HotKeyID.hotKeyID_Paste);        //Ctrl+V
            UnregisterHotKey(hWnd, HotKeyID.hotKeyID_Delete);       //Del
            UnregisterHotKey(hWnd, HotKeyID.hotKeyID_SelectAll);    //Ctrl+A
            #endregion
        }
    }
}