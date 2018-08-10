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
    public partial class frmTABLE_SMSXX : PageBase
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

                if (Request.QueryString["SMS_ID"] != null && Request.QueryString["SMS_ID"].ToString().Trim() != "")
                {
                    XASYU.MODEL.TABLE_SMSModel temp = new XASYU.MODEL.TABLE_SMSModel();
                    temp.SMS_id = int.Parse(Request.QueryString["SMS_ID"].ToString().Trim());
                    int iCount = -1;
                    DataSet ds = XASYU.BLL.DataBaseQuery.query_TABLE_SMS(userBean, temp, ref iCount, 0, 10);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        lblhiddenSMS_id.Text = dr["SMS_id"].ToString();
                        lbltxtSMS_jsr.Text = dr["SMS_jsr"].ToString();
                        lbltxtSMS_nr.Text = dr["SMS_nr"].ToString();
                        lblddlSMS_ljfs.Text = dr["SMS_ljfs"].ToString();
                        lbldthSMS_fstime.Text = dr["SMS_fstime"].ToString();
                        lbldthSMS_dstime.Text = dr["SMS_dstime"].ToString();
                        lbltxtSMS_dxlx.Text = dr["SMS_dxlx"].ToString();
                        lblddlSMS_dxzt.Text = dr["SMS_dxzt"].ToString();
                        lblddlSMS_hzzt.Text = dr["SMS_hzzt"].ToString();
                        lbltxtSMS_wapdx.Text = dr["SMS_wapdx"].ToString();
                        lblddlSMS_fjname.Text = dr["SMS_fjname"].ToString();
                        lblddlSMS_zchf.Text = dr["SMS_zchf"].ToString();
                        lblddlSMS_ztbg.Text = dr["SMS_ztbg"].ToString();
                        lblddlSMS_hftx.Text = dr["SMS_hftx"].ToString();
                        lbltxtSMS_hmd.Text = dr["SMS_hmd"].ToString();
                        lblddlSMS_sfzf.Text = dr["SMS_sfzf"].ToString();
                        lblddlSMS_delete.Text = dr["SMS_delete"].ToString();
                    }
                }
            }
        }
        #endregion
    }
}