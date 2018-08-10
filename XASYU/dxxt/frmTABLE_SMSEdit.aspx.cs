using CykjSoft.UserPermissionManager.Utils;
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
    public partial class frmTABLE_SMSEdit : PageBase
    {
        #region ViewPower

        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "CoreKytzNew";
            }
        }
        #endregion

        #region 定义对象
        int V_ITOTALCOUNT = -1;
        int V_SSTARTINDEX = 0;
        int V_SPERPAGESIZE = 1000;
        private XASYU.MODEL.TABLE_SMSModel model = new XASYU.MODEL.TABLE_SMSModel();
        CykjSoft.Bean.UserBean userBean = new CykjSoft.Bean.UserBean();
        #endregion

        #region 页面加载

        protected override void OnLoad(EventArgs e)
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
                        this.hiddenSMS_id.Text = dr["SMS_id"].ToString();
                        this.txtSMS_jsr.Text = dr["SMS_jsr"].ToString();
                        this.txtSMS_nr.Text = dr["SMS_nr"].ToString();
                        this.ddlSMS_ljfs.SelectedValue = dr["SMS_ljfs"].ToString();
                        this.dthSMS_fstime.SelectedDate = DateTime.Parse(dr["SMS_fstime"].ToString());
                        this.dthSMS_dstime.SelectedDate = DateTime.Parse(dr["SMS_dstime"].ToString());
                        this.txtSMS_dxlx.Text = dr["SMS_dxlx"].ToString();
                        this.ddlSMS_dxzt.SelectedValue = dr["SMS_dxzt"].ToString();
                        this.ddlSMS_hzzt.SelectedValue = dr["SMS_hzzt"].ToString();
                        this.txtSMS_wapdx.Text = dr["SMS_wapdx"].ToString();
                        this.ddlSMS_fjname.SelectedValue = dr["SMS_fjname"].ToString();
                        this.ddlSMS_zchf.SelectedValue = dr["SMS_zchf"].ToString();
                        this.ddlSMS_ztbg.SelectedValue = dr["SMS_ztbg"].ToString();
                        this.ddlSMS_hftx.SelectedValue = dr["SMS_hftx"].ToString();
                        this.txtSMS_hmd.Text = dr["SMS_hmd"].ToString();
                        this.ddlSMS_sfzf.SelectedValue = dr["SMS_sfzf"].ToString();
                        this.ddlSMS_delete.SelectedValue = dr["SMS_delete"].ToString();
                    }
                    else
                    {
                        //this.hiddenSMS_id.Value ="0" ;
                        this.dthSMS_fstime.SelectedDate = DateTime.Now;
                        this.dthSMS_dstime.SelectedDate = DateTime.Now;
                    }
                }
                else
                {
                    //this.hiddenSMS_id.Value ="0" ;
                    this.dthSMS_fstime.SelectedDate = DateTime.Now;
                    this.dthSMS_dstime.SelectedDate = DateTime.Now;
                }
            }
        }

        #endregion

        #region 保存按钮事件
        /// <summary>
        /// 保存按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            try
            {
                model.SMS_id = int.Parse(this.hiddenSMS_id.Text.Trim());
                model.SMS_jsr = this.txtSMS_jsr.Text;
                model.SMS_nr = this.txtSMS_nr.Text;
                model.SMS_ljfs = bool.Parse(this.ddlSMS_ljfs.SelectedValue.ToString());
                model.SMS_fstime = DateTime.Parse(this.dthSMS_fstime.Text.ToString());
                model.SMS_dstime = DateTime.Parse(this.dthSMS_dstime.Text.ToString());
                model.SMS_dxlx = this.txtSMS_dxlx.Text;
                model.SMS_dxzt = bool.Parse(this.ddlSMS_dxzt.SelectedValue.ToString());
                model.SMS_hzzt = bool.Parse(this.ddlSMS_hzzt.SelectedValue.ToString());
                model.SMS_wapdx = this.txtSMS_wapdx.Text;
                model.SMS_fjname =bool.Parse(this.ddlSMS_fjname.SelectedValue.ToString());
                model.SMS_zchf = bool.Parse(this.ddlSMS_zchf.SelectedValue.ToString());
                model.SMS_ztbg = bool.Parse(this.ddlSMS_ztbg.SelectedValue.ToString());
                model.SMS_hftx = bool.Parse(this.ddlSMS_hftx.SelectedValue.ToString());
                model.SMS_hmd = this.txtSMS_hmd.Text;
                model.SMS_sfzf = bool.Parse(this.ddlSMS_sfzf.SelectedValue.ToString());
                model.SMS_delete = bool.Parse(this.ddlSMS_delete.SelectedValue.ToString());

                model.OpType = DataOperationType.Modify;
                if (XASYU.BLL.DataBaseManager.op_TABLE_SMS(userBean, model) == 0)
                {
                    Alert.ShowInTop("修改成功！");
                }
                else
                {
                    Alert.ShowInTop("修改失败!");
                }
            }
            catch (Exception ex)
            {
                Alert.ShowInTop(ex.Message);
            }
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
        #endregion
    }
}