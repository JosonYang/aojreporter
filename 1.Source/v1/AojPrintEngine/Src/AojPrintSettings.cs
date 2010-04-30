using System;
using System.Collections.Generic;
using System.Text;

namespace AojReport.AojPrintEngine
{
    public class AojPrintSettings
    {
        private static AojPrintSettings settings = null;

        private string _aojdPath;
        /// <summary>
        /// 翱捷报表数据文件存储路径
        /// </summary>
        public string AojdPath
        {
            get { return _aojdPath; }
            set { _aojdPath = value; }
        }

        /// <summary>
        /// 自定义插件集合
        /// </summary>
        public List<KeyValuePair<string, object>> lstPlugin = new List<KeyValuePair<string, object>>();

        protected AojPrintSettings() { }

        public static AojPrintSettings CreateInstance()
        {
            if (settings == null)
            {
                settings = new AojPrintSettings();
            }
            return settings;
        }

    }
}
