using CykjSoft.UserPermissionManager.Utils;
using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XASYU.dxxt
{
    public partial class frmTABLE_SMSNew : PageBase
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
                model.SMS_jsr = this.txtSMS_jsr.Text;
                model.SMS_nr = this.txtSMS_nr.Text;
                model.SMS_ljfs = bool.Parse(this.ddlSMS_ljfs.SelectedValue.ToString());
                model.SMS_fstime = DateTime.Parse(this.dthSMS_fstime.Text.ToString());
                model.SMS_dstime = DateTime.Parse(this.dthSMS_dstime.Text.ToString());
                model.SMS_dxlx = this.txtSMS_dxlx.Text;
                model.SMS_dxzt = bool.Parse(this.ddlSMS_dxzt.SelectedValue.ToString());
                model.SMS_hzzt = bool.Parse(this.ddlSMS_hzzt.SelectedValue.ToString());
                model.SMS_wapdx = this.txtSMS_wapdx.Text;
                model.SMS_fjname = bool.Parse(this.ddlSMS_fjname.SelectedValue.ToString());
                model.SMS_zchf = bool.Parse(this.ddlSMS_zchf.SelectedValue.ToString());
                model.SMS_ztbg = bool.Parse(this.ddlSMS_ztbg.SelectedValue.ToString());
                model.SMS_hftx = bool.Parse(this.ddlSMS_hftx.SelectedValue.ToString());
                model.SMS_hmd = this.txtSMS_hmd.Text;
                model.SMS_sfzf = bool.Parse(this.ddlSMS_sfzf.SelectedValue.ToString());
                model.SMS_delete = bool.Parse(this.ddlSMS_delete.SelectedValue.ToString());

                model.OpType = DataOperationType.Add;
                if (XASYU.BLL.DataBaseManager.op_TABLE_SMS(userBean, model) == 0)
                {
                    Alert.ShowInTop("新增成功！");
                }
                else
                {
                    Alert.ShowInTop("新增失败!");
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