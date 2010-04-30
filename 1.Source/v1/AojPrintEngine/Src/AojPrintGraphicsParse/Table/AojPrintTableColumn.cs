using System;
using System.Collections.Generic;
using System.Text;

namespace AojReport.AojPrintEngine.AojPrintGraphicsParse
{
    internal partial class AojPrintTable
    {
        internal sealed class Column :ICloneable
        {
            #region 唯一标示
            private string _id;
            /// <summary>
            /// Tag的唯一ID
            /// </summary>
            public string Id
            {
                get { return _id; }
                set { _id = value; }
            }
            #endregion

            #region 表格列宽
            private int _width = 20;
            /// <summary>
            /// 文字及边框区域宽度
            /// </summary>
            public int Width
            {
                get { return _width; }
                set { _width = value; }
            }
            #endregion

            public Column()
            {
 
            }

            protected Column(Column obj)
            {
                this._id = obj.Id;
                this._width = obj.Width;
            }
            #region ICloneable Members

            public object Clone()
            {
                Column col = new Column(this);
                return col;
            }

            #endregion
        }
    }
}
