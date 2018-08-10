using FineUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XASYU.dxxt
{
    public partial class frmTABLE_LXRXX : PageBase
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

        #region 页面加载    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetHideReference();

                if (Request.QueryString["LXR_ID"] != null && Request.QueryString["LXR_ID"].ToString().Trim() != "")
                {
                    XASYU.MODEL.TABLE_LXRModel temp = new XASYU.MODEL.TABLE_LXRModel();
                    temp.LXR_id = int.Parse(Request.QueryString["LXR_ID"].ToString().Trim());
                    int iCount = -1;
                    DataSet ds = XASYU.BLL.DataBaseQuery.query_TABLE_LXR(userBean, temp, ref iCount, 0, 10);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        lblhiddenLXR_id.Text = dr["LXR_id"].ToString();
                        lbltxtLXR_name.Text = dr["LXR_name"].ToString();
                        lbltxtLXR_mobile.Text = dr["LXR_mobile"].ToString();
                        lbltxtLXR_sex.Text = dr["LXR_sex"].ToString();
                        lbltxtLXR_phone.Text = dr["LXR_phone"].ToString();
                        lbltxtLXR_email.Text = dr["LXR_email"].ToString();
                        lbltxtLXR_gzdw.Text = dr["LXR_gzdw"].ToString();
                        lbltxtLXR_sfzid.Text = dr["LXR_sfzid"].ToString();
                        lbltxtLXR_zw.Text = dr["LXR_zw"].ToString();
                        lbltxtLXR_bz.Text = dr["LXR_bz"].ToString();
                        lblddlLXR_sfjrwh.Text = dr["LXR_sfjrwh"].ToString();
                        lbldthLXR_csrq.Text = dr["LXR_csrq"].ToString();
                        lblddlLXR_sfsrwh.Text = dr["LXR_sfsrwh"].ToString();
                        lbldthLXR_gj01.Text = dr["LXR_gj01"].ToString();
                        lbltxtLXR_gj01nr.Text = dr["LXR_gj01nr"].ToString();
                        lbldthLXR_gj02.Text = dr["LXR_gj02"].ToString();
                        lbltxtLXR_gj02nr.Text = dr["LXR_gj02nr"].ToString();
                        lbldthLXR_gj03.Text = dr["LXR_gj03"].ToString();
                        lbltxtLXR_gj03nr.Text = dr["LXR_gj03nr"].ToString();
                    }
                }
            }
        }
        #endregion
    }
}