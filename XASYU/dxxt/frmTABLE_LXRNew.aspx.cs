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
    public partial class frmTABLE_LXRNew : PageBase
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
        private XASYU.MODEL.TABLE_LXRModel model = new XASYU.MODEL.TABLE_LXRModel();
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
                model.LXR_name = this.txtLXR_name.Text;
                model.LXR_mobile = this.txtLXR_mobile.Text;
                model.LXR_sex = this.txtLXR_sex.Text;
                model.LXR_phone = this.txtLXR_phone.Text;
                model.LXR_email = this.txtLXR_email.Text;
                model.LXR_gzdw = this.txtLXR_gzdw.Text;
                model.LXR_sfzid = this.txtLXR_sfzid.Text;
                model.LXR_zw = this.txtLXR_zw.Text;
                model.LXR_bz = this.txtLXR_bz.Text;
                model.LXR_sfjrwh = bool.Parse(this.ddlLXR_sfjrwh.SelectedValue.ToString());
                model.LXR_csrq = DateTime.Parse(this.dthLXR_csrq.Text.ToString());
                model.LXR_sfsrwh = bool.Parse(this.ddlLXR_sfsrwh.SelectedValue.ToString());
                model.LXR_gj01 = DateTime.Parse(this.dthLXR_gj01.Text.ToString());
                model.LXR_gj01nr = this.txtLXR_gj01nr.Text;
                model.LXR_gj02 = DateTime.Parse(this.dthLXR_gj02.Text.ToString());
                model.LXR_gj02nr = this.txtLXR_gj02nr.Text;
                model.LXR_gj03 = DateTime.Parse(this.dthLXR_gj03.Text.ToString());
                model.LXR_gj03nr = this.txtLXR_gj03nr.Text;

                model.OpType = DataOperationType.Add;
                if (XASYU.BLL.DataBaseManager.op_TABLE_LXR(userBean, model) == 0)
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