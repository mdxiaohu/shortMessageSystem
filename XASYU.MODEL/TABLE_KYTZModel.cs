#region XASYU.MODEL层

#region TABLE_KYTZModel 实体类

using System;
using System.Collections.Generic;
using System.Text;
using CykjSoft.UserPermissionManager.Utils;
namespace XASYU.MODEL
{

    [Serializable]
    public class TABLE_KYTZModel
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
        /// 字段名：SerialNO
        /// 类型名：bigint
        /// 字段长：19
        /// 描述：
        /// </summary>
        private long _SERIALNO = 0;
        public long SerialNO
        {
            get { return _SERIALNO; }
            set { _SERIALNO = value; }
        }

        /// <summary>
        /// 字段名：tzmc
        /// 类型名：varchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _TZMC = "";
        public string tzmc
        {
            get { return _TZMC; }
            set { _TZMC = value; }
        }

        /// <summary>
        /// 字段名：tznr
        /// 类型名：varchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _TZNR = "";
        public string tznr
        {
            get { return _TZNR; }
            set { _TZNR = value; }
        }

        /// <summary>
        /// 字段名：tzsj
        /// 类型名：date
        /// 字段长：10
        /// 描述：
        /// </summary>
        private DateTime _TZSJ = DateTime.Parse("1900-01-01");
        public DateTime tzsj
        {
            get { return _TZSJ; }
            set { _TZSJ = value; }
        }

        /// <summary>
        /// 字段名：tz_enddate
        /// 类型名：date
        /// 字段长：10
        /// 描述：
        /// </summary>
        private DateTime _TZ_ENDDATE = DateTime.Parse("1900-01-01");
        public DateTime tz_enddate
        {
            get { return _TZ_ENDDATE; }
            set { _TZ_ENDDATE = value; }
        }

        /// <summary>
        /// 字段名：tzr
        /// 类型名：varchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _TZR = "";
        public string tzr
        {
            get { return _TZR; }
            set { _TZR = value; }
        }

        /// <summary>
        /// 字段名：tzfj
        /// 类型名：varbinary
        /// 字段长：0
        /// 描述：
        /// </summary>
        //private byte[] _TZFJ = null;
        //public byte[] tzfj
        //{
        //    get { return _TZFJ; }
        //    set { _TZFJ = value; }
        //}

        /// <summary>
        /// 字段名：tz_remark1
        /// 类型名：varchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _TZ_REMARK1 = "";
        public string tz_remark1
        {
            get { return _TZ_REMARK1; }
            set { _TZ_REMARK1 = value; }
        }

        /// <summary>
        /// 字段名：tz_remark2
        /// 类型名：varchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _TZ_REMARK2 = "";
        public string tz_remark2
        {
            get { return _TZ_REMARK2; }
            set { _TZ_REMARK2 = value; }
        }

    }
}

#endregion

#endregion

