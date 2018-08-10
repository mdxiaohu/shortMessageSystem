using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Data;
using CykjSoft.Bean;
using CykjSoft.UserPermissionManager.Bean;
using CykjSoft.UserPermissionManager.Business;
using CykjSoft.UserPermissionManager.Utils;

namespace XASYU
{
    public partial class frm_ControlPanel : PageBase
    {
        #region ViewPower

        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "";
            }
        }

        #endregion

        #region //初始化变量
        int V_ITOTALCOUNT = -1;
        int V_SSTARTINDEX = 0;
        int V_SPERPAGESIZE = 1000;
        //private AppBox.MODEL.TABLE_KYTZModel Table_XYBM = new MODEL.TABLE_KYTZModel();
        //static DateTime startdate = DateTime.Parse("1900-01-01");
        //static DateTime enddate = DateTime.Now.Date.AddDays(1).AddSeconds(-1);
        CykjSoft.Bean.UserBean userBean = new CykjSoft.Bean.UserBean();
        #endregion

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        //数据加载
        private void LoadData()
        {
            //Table_XYBM.StartDate = DateTime.Parse("1900-01-01");
            ////DateTime.Now.AddDays(-7);
            //Table_XYBM.EndDate = DateTime.Now;
            ////Table_XYBM.tzfj = Num;
            //DataTable table = new DataTable();
            //DataSet ds = AppBox.BLL.DataBaseQuery.query_TABLE_KYTZ(userBean, Table_XYBM, ref  V_ITOTALCOUNT, V_SSTARTINDEX, V_SPERPAGESIZE);
            //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            //{
            //    table = ds.Tables[0];
            //}
          
        }

        #endregion
    }
}