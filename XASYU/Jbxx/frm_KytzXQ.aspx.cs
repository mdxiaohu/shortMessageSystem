using System;
using System.Data;
using FineUI;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using FineUI;
using CykjSoft.UserPermissionManager.Utils;
using System.Data;

namespace XASYU.Jbxx
{
    public partial class frm_KytzXQ : PageBase
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

        #region 初始化变量
        int V_ITOTALCOUNT = -1;
        int V_SSTARTINDEX = 0;
        int V_SPERPAGESIZE = 1000;
        private XASYU.MODEL.TABLE_KYTZModel Table_XYBM = new MODEL.TABLE_KYTZModel();
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

        private void LoadData()
        {
            btnClose.OnClientClick = ActiveWindow.GetHideReference();

            int id = GetQueryIntValue("id");
            Table_XYBM.SerialNO = id;
            Table_XYBM.StartDate = DateTime.Parse("1900-01-01");
            Table_XYBM.EndDate = DateTime.Now;
            DataTable table = new DataTable();
            DataSet ds = XASYU.BLL.DataBaseQuery.query_TABLE_KYTZ(userBean, Table_XYBM, ref  V_ITOTALCOUNT, V_SSTARTINDEX, V_SPERPAGESIZE);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                table = ds.Tables[0];
            }

            this.lblTzmc.Text = table.Rows[0]["tzmc"].ToString();
            this.lblTznr.Text = table.Rows[0]["tznr"].ToString();
            this.lblTzr.Text = table.Rows[0]["tzr"].ToString();
            this.lblstartDate.Text = table.Rows[0]["tzsj"].ToString();
            this.lblendDate.Text = table.Rows[0]["tz_enddate"].ToString();
            this.lblBz.Text = table.Rows[0]["tz_remark1"].ToString();
        }


        #endregion

       
    }
}