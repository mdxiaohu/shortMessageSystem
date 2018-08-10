using CykjSoft.UserPermissionManager.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XASYU.MODEL
{
    [Serializable]
    public class TABLE_TXQZModel
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
        /// 字段名：TXQZ_id
        /// 类型名：int
        /// 字段长：10
        /// 描述：
        /// </summary>
        private int _TXQZ_ID = 0;
        public int TXQZ_id
        {
            get { return _TXQZ_ID; }
            set { _TXQZ_ID = value; }
        }

        /// <summary>
        /// 字段名：TXQZ_name
        /// 类型名：varchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _TXQZ_NAME = "";
        public string TXQZ_name
        {
            get { return _TXQZ_NAME; }
            set { _TXQZ_NAME = value; }
        }

        /// <summary>
        /// 字段名：TXQZ_sjid
        /// 类型名：int
        /// 字段长：10
        /// 描述：
        /// </summary>
        private int _TXQZ_SJID = 0;
        public int TXQZ_sjid
        {
            get { return _TXQZ_SJID; }
            set { _TXQZ_SJID = value; }
        }

    }
}
