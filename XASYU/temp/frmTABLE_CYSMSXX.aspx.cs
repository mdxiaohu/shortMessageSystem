using FineUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XASYU.temp
{
    public partial class frmTABLE_CYSMSXX : PageBase
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
        private object hiddenCySms_id;
        #endregion

        #region 页面加载    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetHideReference();

                if (Request.QueryString["CYSMS_ID"] != null && Request.QueryString["CYSMS_ID"].ToString().Trim() != "")
                {
                    XASYU.MODEL.TABLE_CYSMSModel temp = new XASYU.MODEL.TABLE_CYSMSModel();
                    temp.CySms_id = int.Parse(Request.QueryString["CYSMS_ID"].ToString().Trim());
                    int iCount = -1;
                    DataSet ds = XASYU.BLL.DataBaseQuery.query_TABLE_CYSMS(userBean, temp, ref iCount, 0, 10);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        lblhiddenCySms_id.Text = dr["CySms_id"].ToString();
                        lbltxtCySms_nr.Text = dr["CySms_nr"].ToString();
                        lbltxtCySms_lx.Text = dr["CySms_lx"].ToString();
                    }
                }
            }
        }
        #endregion
    }
}