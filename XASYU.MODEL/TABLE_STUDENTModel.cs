#region XASYU.MODEL层

#region TABLE_STUDENTModel 实体类

using System;
using System.Collections.Generic;
using System.Text;
using CykjSoft.UserPermissionManager.Utils;
namespace XASYU.MODEL
{

    [Serializable]
    public class TABLE_STUDENTModel
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
        /// 字段名：Stu_NO
        /// 类型名：varchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _STU_NO = "";
        public string Stu_NO
        {
            get { return _STU_NO; }
            set { _STU_NO = value; }
        }

        /// <summary>
        /// 字段名：Stu_Name
        /// 类型名：varchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _STU_NAME = "";
        public string Stu_Name
        {
            get { return _STU_NAME; }
            set { _STU_NAME = value; }
        }

        /// <summary>
        /// 字段名：Stu_Age
        /// 类型名：int
        /// 字段长：10
        /// 描述：
        /// </summary>
        private int _STU_AGE = 0;
        public int Stu_Age
        {
            get { return _STU_AGE; }
            set { _STU_AGE = value; }
        }

        /// <summary>
        /// 字段名：Stu_Zy
        /// 类型名：nchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _STU_ZY = "";
        public string Stu_Zy
        {
            get { return _STU_ZY; }
            set { _STU_ZY = value; }
        }

    }
}

#endregion

#endregion