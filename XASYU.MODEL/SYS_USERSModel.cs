#region XASYU.MODEL层

#region SYS_USERSModel 实体类

using System;
using System.Collections.Generic;
using System.Text;
using CykjSoft.UserPermissionManager.Utils;
namespace XASYU.MODEL
{

    [Serializable]
    public class SYS_USERSModel
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
        /// 字段名：Email
        /// 类型名：nvarchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _EMAIL = "";
        public string Email
        {
            get { return _EMAIL; }
            set { _EMAIL = value; }
        }

        /// <summary>
        /// 字段名：Password
        /// 类型名：nvarchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _PASSWORD = "";
        public string Password
        {
            get { return _PASSWORD; }
            set { _PASSWORD = value; }
        }

        /// <summary>
        /// 字段名：Enabled
        /// 类型名：bit
        /// 字段长：1
        /// 描述：
        /// </summary>
        private bool _ENABLED = false;
        public bool Enabled
        {
            get { return _ENABLED; }
            set { _ENABLED = value; }
        }

        /// <summary>
        /// 字段名：Gender
        /// 类型名：nvarchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _GENDER = "";
        public string Gender
        {
            get { return _GENDER; }
            set { _GENDER = value; }
        }

        /// <summary>
        /// 字段名：ChineseName
        /// 类型名：nvarchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _CHINESENAME = "";
        public string ChineseName
        {
            get { return _CHINESENAME; }
            set { _CHINESENAME = value; }
        }

        /// <summary>
        /// 字段名：Nation
        /// 类型名：nvarchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _NATION = "";
        public string Nation
        {
            get { return _NATION; }
            set { _NATION = value; }
        }

        /// <summary>
        /// 字段名：IdentityCard
        /// 类型名：nvarchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _IDENTITYCARD = "";
        public string IdentityCard
        {
            get { return _IDENTITYCARD; }
            set { _IDENTITYCARD = value; }
        }

        /// <summary>
        /// 字段名：XueLi
        /// 类型名：nvarchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _XUELI = "";
        public string XueLi
        {
            get { return _XUELI; }
            set { _XUELI = value; }
        }

        /// <summary>
        /// 字段名：XueWei
        /// 类型名：nvarchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _XUEWEI = "";
        public string XueWei
        {
            get { return _XUEWEI; }
            set { _XUEWEI = value; }
        }

        /// <summary>
        /// 字段名：ZhiWu
        /// 类型名：nvarchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _ZHIWU = "";
        public string ZhiWu
        {
            get { return _ZHIWU; }
            set { _ZHIWU = value; }
        }

        /// <summary>
        /// 字段名：Political
        /// 类型名：nvarchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _POLITICAL = "";
        public string Political
        {
            get { return _POLITICAL; }
            set { _POLITICAL = value; }
        }

        /// <summary>
        /// 字段名：YjFx
        /// 类型名：nvarchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _YJFX = "";
        public string YjFx
        {
            get { return _YJFX; }
            set { _YJFX = value; }
        }

        /// <summary>
        /// 字段名：Address
        /// 类型名：nvarchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _ADDRESS = "";
        public string Address
        {
            get { return _ADDRESS; }
            set { _ADDRESS = value; }
        }

        /// <summary>
        /// 字段名：EnglishName
        /// 类型名：nvarchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _ENGLISHNAME = "";
        public string EnglishName
        {
            get { return _ENGLISHNAME; }
            set { _ENGLISHNAME = value; }
        }

        /// <summary>
        /// 字段名：Photo
        /// 类型名：nvarchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _PHOTO = "";
        public string Photo
        {
            get { return _PHOTO; }
            set { _PHOTO = value; }
        }

        /// <summary>
        /// 字段名：QQ
        /// 类型名：nvarchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _QQ = "";
        public string QQ
        {
            get { return _QQ; }
            set { _QQ = value; }
        }

        /// <summary>
        /// 字段名：CompanyEmail
        /// 类型名：nvarchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _COMPANYEMAIL = "";
        public string CompanyEmail
        {
            get { return _COMPANYEMAIL; }
            set { _COMPANYEMAIL = value; }
        }

        /// <summary>
        /// 字段名：OfficePhone
        /// 类型名：nvarchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _OFFICEPHONE = "";
        public string OfficePhone
        {
            get { return _OFFICEPHONE; }
            set { _OFFICEPHONE = value; }
        }

        /// <summary>
        /// 字段名：OfficePhoneExt
        /// 类型名：nvarchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _OFFICEPHONEEXT = "";
        public string OfficePhoneExt
        {
            get { return _OFFICEPHONEEXT; }
            set { _OFFICEPHONEEXT = value; }
        }

        /// <summary>
        /// 字段名：HomePhone
        /// 类型名：nvarchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _HOMEPHONE = "";
        public string HomePhone
        {
            get { return _HOMEPHONE; }
            set { _HOMEPHONE = value; }
        }

        /// <summary>
        /// 字段名：CellPhone
        /// 类型名：nvarchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _CELLPHONE = "";
        public string CellPhone
        {
            get { return _CELLPHONE; }
            set { _CELLPHONE = value; }
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
        /// 字段名：Birthday
        /// 类型名：datetime
        /// 字段长：23
        /// 描述：
        /// </summary>
        private DateTime _BIRTHDAY = DateTime.Parse("1900-01-01");
        public DateTime Birthday
        {
            get { return _BIRTHDAY; }
            set { _BIRTHDAY = value; }
        }

        /// <summary>
        /// 字段名：TakeOfficeTime
        /// 类型名：datetime
        /// 字段长：23
        /// 描述：
        /// </summary>
        private DateTime _TAKEOFFICETIME = DateTime.Parse("1900-01-01");
        public DateTime TakeOfficeTime
        {
            get { return _TAKEOFFICETIME; }
            set { _TAKEOFFICETIME = value; }
        }

        /// <summary>
        /// 字段名：LastLoginTime
        /// 类型名：datetime
        /// 字段长：23
        /// 描述：
        /// </summary>
        private DateTime _LASTLOGINTIME = DateTime.Parse("1900-01-01");
        public DateTime LastLoginTime
        {
            get { return _LASTLOGINTIME; }
            set { _LASTLOGINTIME = value; }
        }

        /// <summary>
        /// 字段名：CreateTime
        /// 类型名：datetime
        /// 字段长：23
        /// 描述：
        /// </summary>
        private DateTime _CREATETIME = DateTime.Parse("1900-01-01");
        public DateTime CreateTime
        {
            get { return _CREATETIME; }
            set { _CREATETIME = value; }
        }

        /// <summary>
        /// 字段名：DeptID
        /// 类型名：int
        /// 字段长：10
        /// 描述：
        /// </summary>
        private int _DEPTID = 0;
        public int DeptID
        {
            get { return _DEPTID; }
            set { _DEPTID = value; }
        }

        public virtual ICollection<SYS_ROLESModel> Roles { get; set; }
        public virtual ICollection<SYS_TITLESModel> Titles { get; set; }

        public virtual SYS_DEPTSModel Dept { get; set; }

    }
}

#endregion

#endregion
