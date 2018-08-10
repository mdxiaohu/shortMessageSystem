using CykjSoft.UserPermissionManager.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XASYU.MODEL
{
    [Serializable]
    public class TABLE_DXHFModel
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
        /// 字段名：DXHF_id
        /// 类型名：int
        /// 字段长：10
        /// 描述：
        /// </summary>
        private int _DXHF_ID = 0;
        public int DXHF_id
        {
            get { return _DXHF_ID; }
            set { _DXHF_ID = value; }
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
        /// 字段名：DXHF_hfrmobile
        /// 类型名：varchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _DXHF_HFRMOBILE = "";
        public string DXHF_hfrmobile
        {
            get { return _DXHF_HFRMOBILE; }
            set { _DXHF_HFRMOBILE = value; }
        }

        /// <summary>
        /// 字段名：DXHF_nr
        /// 类型名：varchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _DXHF_NR = "";
        public string DXHF_nr
        {
            get { return _DXHF_NR; }
            set { _DXHF_NR = value; }
        }

        /// <summary>
        /// 字段名：DXHF_time
        /// 类型名：varchar
        /// 字段长：0
        /// 描述：
        /// </summary>
        private string _DXHF_TIME = "";
        public string DXHF_time
        {
            get { return _DXHF_TIME; }
            set { _DXHF_TIME = value; }
        }

    }
}
