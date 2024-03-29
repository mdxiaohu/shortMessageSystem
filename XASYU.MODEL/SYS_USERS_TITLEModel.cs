﻿using System;
using System.Collections.Generic;
using System.Text;
using CykjSoft.UserPermissionManager.Utils;
namespace XASYU.MODEL
{
    [Serializable]
    public class SYS_USERS_TITLEModel
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
        /// 字段名：TitleID
        /// 类型名：int
        /// 字段长：10
        /// 描述：
        /// </summary>
        private int _TITLEID = 0;
        public int TitleID
        {
            get { return _TITLEID; }
            set { _TITLEID = value; }
        }

        /// <summary>
        /// 字段名：TitleName
        /// 类型名：nvarchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _TITLENAME = "";
        public string TitleName
        {
            get { return _TITLENAME; }
            set { _TITLENAME = value; }
        }

        /// <summary>
        /// 字段名：UserID
        /// 类型名：int
        /// 字段长：10
        /// 描述：
        /// </summary>
        private int _USERID = 0;
        public int UserID
        {
            get { return _USERID; }
            set { _USERID = value; }
        }

        /// <summary>
        /// 字段名：UserName
        /// 类型名：nvarchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _USERNAME = "";
        public string UserName
        {
            get { return _USERNAME; }
            set { _USERNAME = value; }
        }    
    }
}
