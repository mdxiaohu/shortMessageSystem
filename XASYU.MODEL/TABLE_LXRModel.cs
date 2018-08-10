using CykjSoft.UserPermissionManager.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XASYU.MODEL
{
    [Serializable]
    public class TABLE_LXRModel
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
        /// 字段名：LXR_id
        /// 类型名：int
        /// 字段长：10
        /// 描述：
        /// </summary>
        private int _LXR_ID = 0;
        public int LXR_id
        {
            get { return _LXR_ID; }
            set { _LXR_ID = value; }
        }

        /// <summary>
        /// 字段名：LXR_name
        /// 类型名：varchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _LXR_NAME = "";
        public string LXR_name
        {
            get { return _LXR_NAME; }
            set { _LXR_NAME = value; }
        }

        /// <summary>
        /// 字段名：LXR_mobile
        /// 类型名：varchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _LXR_MOBILE = "";
        public string LXR_mobile
        {
            get { return _LXR_MOBILE; }
            set { _LXR_MOBILE = value; }
        }

        /// <summary>
        /// 字段名：LXR_sex
        /// 类型名：varchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _LXR_SEX = "";
        public string LXR_sex
        {
            get { return _LXR_SEX; }
            set { _LXR_SEX = value; }
        }

        /// <summary>
        /// 字段名：LXR_phone
        /// 类型名：varchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _LXR_PHONE = "";
        public string LXR_phone
        {
            get { return _LXR_PHONE; }
            set { _LXR_PHONE = value; }
        }

        /// <summary>
        /// 字段名：LXR_email
        /// 类型名：varchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _LXR_EMAIL = "";
        public string LXR_email
        {
            get { return _LXR_EMAIL; }
            set { _LXR_EMAIL = value; }
        }

        /// <summary>
        /// 字段名：LXR_gzdw
        /// 类型名：varchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _LXR_GZDW = "";
        public string LXR_gzdw
        {
            get { return _LXR_GZDW; }
            set { _LXR_GZDW = value; }
        }

        /// <summary>
        /// 字段名：LXR_sfzid
        /// 类型名：char
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _LXR_SFZID = "";
        public string LXR_sfzid
        {
            get { return _LXR_SFZID; }
            set { _LXR_SFZID = value; }
        }

        /// <summary>
        /// 字段名：LXR_zw
        /// 类型名：varchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _LXR_ZW = "";
        public string LXR_zw
        {
            get { return _LXR_ZW; }
            set { _LXR_ZW = value; }
        }

        /// <summary>
        /// 字段名：LXR_bz
        /// 类型名：varchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _LXR_BZ = "";
        public string LXR_bz
        {
            get { return _LXR_BZ; }
            set { _LXR_BZ = value; }
        }

        /// <summary>
        /// 字段名：LXR_sfjrwh
        /// 类型名：bit
        /// 字段长：1
        /// 描述：
        /// </summary>
        private bool _LXR_SFJRWH = false;
        public bool LXR_sfjrwh
        {
            get { return _LXR_SFJRWH; }
            set { _LXR_SFJRWH = value; }
        }

        /// <summary>
        /// 字段名：LXR_csrq
        /// 类型名：date
        /// 字段长：10
        /// 描述：
        /// </summary>
        private DateTime _LXR_CSRQ = DateTime.Parse("1900-01-01");
        public DateTime LXR_csrq
        {
            get { return _LXR_CSRQ; }
            set { _LXR_CSRQ = value; }
        }

        /// <summary>
        /// 字段名：LXR_sfsrwh
        /// 类型名：bit
        /// 字段长：1
        /// 描述：
        /// </summary>
        private bool _LXR_SFSRWH = false;
        public bool LXR_sfsrwh
        {
            get { return _LXR_SFSRWH; }
            set { _LXR_SFSRWH = value; }
        }

        /// <summary>
        /// 字段名：LXR_gj01
        /// 类型名：datetime
        /// 字段长：23
        /// 描述：
        /// </summary>
        private DateTime _LXR_GJ01 = DateTime.Parse("1900-01-01");
        public DateTime LXR_gj01
        {
            get { return _LXR_GJ01; }
            set { _LXR_GJ01 = value; }
        }

        /// <summary>
        /// 字段名：LXR_gj01nr
        /// 类型名：varchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _LXR_GJ01NR = "";
        public string LXR_gj01nr
        {
            get { return _LXR_GJ01NR; }
            set { _LXR_GJ01NR = value; }
        }

        /// <summary>
        /// 字段名：LXR_gj02
        /// 类型名：datetime
        /// 字段长：23
        /// 描述：
        /// </summary>
        private DateTime _LXR_GJ02 = DateTime.Parse("1900-01-01");
        public DateTime LXR_gj02
        {
            get { return _LXR_GJ02; }
            set { _LXR_GJ02 = value; }
        }

        /// <summary>
        /// 字段名：LXR_gj02nr
        /// 类型名：varchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _LXR_GJ02NR = "";
        public string LXR_gj02nr
        {
            get { return _LXR_GJ02NR; }
            set { _LXR_GJ02NR = value; }
        }

        /// <summary>
        /// 字段名：LXR_gj03
        /// 类型名：datetime
        /// 字段长：23
        /// 描述：
        /// </summary>
        private DateTime _LXR_GJ03 = DateTime.Parse("1900-01-01");
        public DateTime LXR_gj03
        {
            get { return _LXR_GJ03; }
            set { _LXR_GJ03 = value; }
        }

        /// <summary>
        /// 字段名：LXR_gj03nr
        /// 类型名：varchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _LXR_GJ03NR = "";
        public string LXR_gj03nr
        {
            get { return _LXR_GJ03NR; }
            set { _LXR_GJ03NR = value; }
        }

    }
}
