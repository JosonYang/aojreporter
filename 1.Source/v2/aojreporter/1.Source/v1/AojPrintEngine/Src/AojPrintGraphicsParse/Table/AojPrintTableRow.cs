using System;
using System.Collections.Generic;
using System.Text;

namespace AojReport.AojPrintEngine.AojPrintGraphicsParse
{
    internal partial class AojPrintTable
    {
        internal sealed class Row :ICloneable
        {

            #region 表格列宽
            private int _height = 20;
            /// <summary>
            /// 文字及边框区域宽度
            /// </summary>
            public int Height
            {
                get { return _height; }
                set { _height = value; }
            }
            #endregion
            public Row()
            {

            }
            protected Row(Row obj)
            {
                this._height = obj.Height;
            }
            #region ICloneable Members

            public object Clone()
            {
                Row r = new Row(this);
                return r;
            }

            #endregion
        }
    }
}
