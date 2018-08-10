#region XASYU.MODEL层

#region SYS_LOGSModel 实体类

using System;
using System.Collections.Generic;
using System.Text;
using CykjSoft.UserPermissionManager.Utils;
namespace XASYU.MODEL
{

    [Serializable]
    public class SYS_LOGSModel
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
        /// 字段名：ID
        /// 类型名：int
        /// 字段长：10
        /// 描述：
        /// </summary>
        private int _ID = 0;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        /// <summary>
        /// 字段名：Level
        /// 类型名：nvarchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _LEVEL = "";
        public string Level
        {
            get { return _LEVEL; }
            set { _LEVEL = value; }
        }

        /// <summary>
        /// 字段名：Logger
        /// 类型名：nvarchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _LOGGER = "";
        public string Logger
        {
            get { return _LOGGER; }
            set { _LOGGER = value; }
        }

        /// <summary>
        /// 字段名：Message
        /// 类型名：nvarchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _MESSAGE = "";
        public string Message
        {
            get { return _MESSAGE; }
            set { _MESSAGE = value; }
        }

        /// <summary>
        /// 字段名：Exception
        /// 类型名：nvarchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _EXCEPTION = "";
        public string Exception
        {
            get { return _EXCEPTION; }
            set { _EXCEPTION = value; }
        }

        /// <summary>
        /// 字段名：LogTime
        /// 类型名：datetime
        /// 字段长：23
        /// 描述：
        /// </summary>
        private DateTime _LOGTIME = DateTime.Parse("1900-01-01");
        public DateTime LogTime
        {
            get { return _LOGTIME; }
            set { _LOGTIME = value; }
        }

    }
}

#endregion

#endregion