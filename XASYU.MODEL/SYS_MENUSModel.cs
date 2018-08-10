#region XASYU.MODEL层

#region SYS_MENUSModel 实体类

using System;
using System.Collections.Generic;
using System.Text;
using CykjSoft.UserPermissionManager.Utils;
namespace XASYU.MODEL
{

    [Serializable]
    public class SYS_MENUSModel : ICustomTree, IKeyID, ICloneable
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
        /// 字段名：ImageUrl
        /// 类型名：nvarchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _IMAGEURL = "";
        public string ImageUrl
        {
            get { return _IMAGEURL; }
            set { _IMAGEURL = value; }
        }

        /// <summary>
        /// 字段名：NavigateUrl
        /// 类型名：nvarchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _NAVIGATEURL = "";
        public string NavigateUrl
        {
            get { return _NAVIGATEURL; }
            set { _NAVIGATEURL = value; }
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

        /// <summary>
        /// 字段名：SortIndex
        /// 类型名：int
        /// 字段长：10
        /// 描述：
        /// </summary>
        private int _SORTINDEX = 0;
        public int SortIndex
        {
            get { return _SORTINDEX; }
            set { _SORTINDEX = value; }
        }

        /// <summary>
        /// 字段名：ParentID
        /// 类型名：int
        /// 字段长：10
        /// 描述：
        /// </summary>
        private int _PARENTID = 0;
        public int ParentID
        {
            get { return _PARENTID; }
            set { _PARENTID = value; }
        }

        /// <summary>
        /// 字段名：ViewPowerID
        /// 类型名：int
        /// 字段长：10
        /// 描述：
        /// </summary>
        private int _VIEWPOWERID = 0;
        public int ViewPowerID
        {
            get { return _VIEWPOWERID; }
            set { _VIEWPOWERID = value; }
        }
        public bool IsTreeLeaf { get; set; }
        public virtual ICollection<SYS_MENUSModel> Children { get; set; }
        public int TreeLevel { get; set; }
        public bool Enabled { get; set; }
        public virtual SYS_MENUSModel Parent { get; set; }
        public virtual SYS_POWERSModel ViewPower { get; set; }
        public object Clone()
        {
            SYS_MENUSModel menu = new SYS_MENUSModel
            {
                ID = ID,
                Name = Name,
                ImageUrl = ImageUrl,
                NavigateUrl = NavigateUrl,
                Remark = Remark,
                SortIndex = SortIndex,
                TreeLevel = TreeLevel,
                Enabled = Enabled,
                IsTreeLeaf = IsTreeLeaf
            };
            return menu;
        }
    }
}

#endregion

#endregion