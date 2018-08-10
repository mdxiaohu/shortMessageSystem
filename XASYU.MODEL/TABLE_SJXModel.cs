using CykjSoft.UserPermissionManager.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XASYU.MODEL
{
    [Serializable]
    public class TABLE_SJXModel
    {

        /// <summary>
        /// 数据操作类型,默认为浏览;
        /// </summary>
        private DataOperationType opType = DataOperationType.Browse;
        /// <summary>
        /// 数据操作类型,默认为浏览;
        /// </summary> 
        public DataOperationType OpType
        {
            get { return opType; }
            set { opType = value; }
        }

        /// <summary>
        /// 表RowID号;
        /// </summary>
        private string _DataRowID = string.Empty;
        /// <summary>
        /// 表RowID号;
        /// </summary>
        public string DataRowID
        {
            get { return _DataRowID; }
            set { _DataRowID = value; }
        }

        /// <summary>
        /// 当前路径;
        /// </summary>
        private string _CurrentNodePath = string.Empty;
        /// <summary>
        /// 当前路径;
        /// </summary>
        public string CurrentNodePath
        {
            get { return _CurrentNodePath; }
            set { _CurrentNodePath = value; }
        }

        /// <summary>
        /// 用于范围查询的开始时间;
        /// </summary>
        private DateTime _StartDate = DateTime.Parse("1900-01-01");
        /// <summary>
        /// 用于范围查询的开始时间;
        /// </summary>
        public DateTime StartDate
        {
            get { return _StartDate; }
            set { _StartDate = value; }
        }

        /// <summary>
        /// 用于范围查询的结束时间;
        /// </summary>
        private DateTime _EndDate = DateTime.Parse("1900-01-01");
        /// <summary>
        /// 用于范围查询的结束时间;
        /// </summary>
        public DateTime EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
        }

        /// <summary>
        /// 字段名：SJX_id
        /// 类型名：int
        /// 字段长：10
        /// 描述：
        /// </summary>
        private int _SJX_ID = 0;
        public int SJX_id
        {
            get { return _SJX_ID; }
            set { _SJX_ID = value; }
        }

        /// <summary>
        /// 字段名：SJX_mobile
        /// 类型名：varchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _SJX_MOBILE = "";
        public string SJX_mobile
        {
            get { return _SJX_MOBILE; }
            set { _SJX_MOBILE = value; }
        }

        /// <summary>
        /// 字段名：SJX_nr
        /// 类型名：varchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _SJX_NR = "";
        public string SJX_nr
        {
            get { return _SJX_NR; }
            set { _SJX_NR = value; }
        }

        /// <summary>
        /// 字段名：SJX_jstime
        /// 类型名：datetime
        /// 字段长：23
        /// 描述：
        /// </summary>
        private DateTime _SJX_JSTIME = DateTime.Parse("1900-01-01");
        public DateTime SJX_jstime
        {
            get { return _SJX_JSTIME; }
            set { _SJX_JSTIME = value; }
        }

    }
}
