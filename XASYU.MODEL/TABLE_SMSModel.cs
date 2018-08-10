using CykjSoft.UserPermissionManager.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XASYU.MODEL
{
    [Serializable]
    public class TABLE_SMSModel
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
        /// 字段名：SMS_id
        /// 类型名：int
        /// 字段长：10
        /// 描述：
        /// </summary>
        private int _SMS_ID = 0;
        public int SMS_id
        {
            get { return _SMS_ID; }
            set { _SMS_ID = value; }
        }

        /// <summary>
        /// 字段名：SMS_jsr
        /// 类型名：varchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _SMS_JSR = "";
        public string SMS_jsr
        {
            get { return _SMS_JSR; }
            set { _SMS_JSR = value; }
        }

        /// <summary>
        /// 字段名：SMS_nr
        /// 类型名：varchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _SMS_NR = "";
        public string SMS_nr
        {
            get { return _SMS_NR; }
            set { _SMS_NR = value; }
        }

        /// <summary>
        /// 字段名：SMS_ljfs
        /// 类型名：bit
        /// 字段长：1
        /// 描述：
        /// </summary>
        private bool _SMS_LJFS = false;
        public bool SMS_ljfs
        {
            get { return _SMS_LJFS; }
            set { _SMS_LJFS = value; }
        }

        /// <summary>
        /// 字段名：SMS_fstime
        /// 类型名：datetime
        /// 字段长：23
        /// 描述：
        /// </summary>
        private DateTime _SMS_FSTIME = DateTime.Parse("1900-01-01");
        public DateTime SMS_fstime
        {
            get { return _SMS_FSTIME; }
            set { _SMS_FSTIME = value; }
        }

        /// <summary>
        /// 字段名：SMS_dstime
        /// 类型名：datetime
        /// 字段长：23
        /// 描述：
        /// </summary>
        private DateTime _SMS_DSTIME = DateTime.Parse("1900-01-01");
        public DateTime SMS_dstime
        {
            get { return _SMS_DSTIME; }
            set { _SMS_DSTIME = value; }
        }

        /// <summary>
        /// 字段名：SMS_dxlx
        /// 类型名：varchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _SMS_DXLX = "";
        public string SMS_dxlx
        {
            get { return _SMS_DXLX; }
            set { _SMS_DXLX = value; }
        }

        /// <summary>
        /// 字段名：SMS_dxzt
        /// 类型名：bit
        /// 字段长：1
        /// 描述：
        /// </summary>
        private bool _SMS_DXZT = false;
        public bool SMS_dxzt
        {
            get { return _SMS_DXZT; }
            set { _SMS_DXZT = value; }
        }

        /// <summary>
        /// 字段名：SMS_hzzt
        /// 类型名：bit
        /// 字段长：1
        /// 描述：
        /// </summary>
        private bool _SMS_HZZT = false;
        public bool SMS_hzzt
        {
            get { return _SMS_HZZT; }
            set { _SMS_HZZT = value; }
        }

        /// <summary>
        /// 字段名：SMS_wapdx
        /// 类型名：varchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _SMS_WAPDX = "";
        public string SMS_wapdx
        {
            get { return _SMS_WAPDX; }
            set { _SMS_WAPDX = value; }
        }

        /// <summary>
        /// 字段名：SMS_fjname
        /// 类型名：bit
        /// 字段长：1
        /// 描述：
        /// </summary>
        private bool _SMS_FJNAME = false;
        public bool SMS_fjname
        {
            get { return _SMS_FJNAME; }
            set { _SMS_FJNAME = value; }
        }

        /// <summary>
        /// 字段名：SMS_zchf
        /// 类型名：bit
        /// 字段长：1
        /// 描述：
        /// </summary>
        private bool _SMS_ZCHF = false;
        public bool SMS_zchf
        {
            get { return _SMS_ZCHF; }
            set { _SMS_ZCHF = value; }
        }

        /// <summary>
        /// 字段名：SMS_ztbg
        /// 类型名：bit
        /// 字段长：1
        /// 描述：
        /// </summary>
        private bool _SMS_ZTBG = false;
        public bool SMS_ztbg
        {
            get { return _SMS_ZTBG; }
            set { _SMS_ZTBG = value; }
        }

        /// <summary>
        /// 字段名：SMS_hftx
        /// 类型名：bit
        /// 字段长：1
        /// 描述：
        /// </summary>
        private bool _SMS_HFTX = false;
        public bool SMS_hftx
        {
            get { return _SMS_HFTX; }
            set { _SMS_HFTX = value; }
        }

        /// <summary>
        /// 字段名：SMS_hmd
        /// 类型名：varchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _SMS_HMD = "";
        public string SMS_hmd
        {
            get { return _SMS_HMD; }
            set { _SMS_HMD = value; }
        }

        /// <summary>
        /// 字段名：SMS_sfzf
        /// 类型名：bit
        /// 字段长：1
        /// 描述：
        /// </summary>
        private bool _SMS_SFZF = false;
        public bool SMS_sfzf
        {
            get { return _SMS_SFZF; }
            set { _SMS_SFZF = value; }
        }

        /// <summary>
        /// 字段名：SMS_delete
        /// 类型名：bit
        /// 字段长：1
        /// 描述：
        /// </summary>
        private bool _SMS_DELETE = false;
        public bool SMS_delete
        {
            get { return _SMS_DELETE; }
            set { _SMS_DELETE = value; }
        }

    }
}
