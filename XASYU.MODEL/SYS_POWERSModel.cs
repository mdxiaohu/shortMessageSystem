#region XASYU.MODEL层

#region SYS_POWERSModel 实体类

using System;
using System.Collections.Generic;
using System.Text;
using CykjSoft.UserPermissionManager.Utils;
namespace XASYU.MODEL
{

    [Serializable]
    public class SYS_POWERSModel
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
        /// 字段名：Name
        /// 类型名：nvarchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _NAME = "";
        public string Name
        {
            get { return _NAME; }
            set { _NAME = value; }
        }

        /// <summary>
        /// 字段名：GroupName
        /// 类型名：nvarchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _GROUPNAME = "";
        public string GroupName
        {
            get { return _GROUPNAME; }
            set { _GROUPNAME = value; }
        }

        /// <summary>
        /// 字段名：Title
        /// 类型名：nvarchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _TITLE = "";
        public string Title
        {
            get { return _TITLE; }
            set { _TITLE = value; }
        }

        /// <summary>
        /// 字段名：Remark
        /// 类型名：nvarchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _REMARK = "";
        public string Remark
        {
            get { return _REMARK; }
            set { _REMARK = value; }
        }

    }
}

#endregion

#endregion