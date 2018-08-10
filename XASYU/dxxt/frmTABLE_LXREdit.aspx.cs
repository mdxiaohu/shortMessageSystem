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
    public partial class frmTABLE_LXREdit : PageBase
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
                if (Request.QueryString["LXR_ID"] != null && Request.QueryString["LXR_ID"].ToString().Trim() != "")
                {
                    XASYU.MODEL.TABLE_LXRModel temp = new XASYU.MODEL.TABLE_LXRModel();
                    temp.LXR_id = int.Parse(Request.QueryString["LXR_ID"].ToString().Trim());
                    int iCount = -1;
                    DataSet ds = XASYU.BLL.DataBaseQuery.query_TABLE_LXR(userBean, temp, ref iCount, 0, 10);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        this.hiddenLXR_id.Text = dr["LXR_id"].ToString();
                        this.txtLXR_name.Text = dr["LXR_name"].ToString();
                        this.txtLXR_mobile.Text = dr["LXR_mobile"].ToString();
                        this.txtLXR_sex.Text = dr["LXR_sex"].ToString();
                        this.txtLXR_phone.Text = dr["LXR_phone"].ToString();
                        this.txtLXR_email.Text = dr["LXR_email"].ToString();
                        this.txtLXR_gzdw.Text = dr["LXR_gzdw"].ToString();
                        this.txtLXR_sfzid.Text = dr["LXR_sfzid"].ToString();
                        this.txtLXR_zw.Text = dr["LXR_zw"].ToString();
                        this.txtLXR_bz.Text = dr["LXR_bz"].ToString();
                        this.ddlLXR_sfjrwh.SelectedValue = dr["LXR_sfjrwh"].ToString();
                        this.dthLXR_csrq.SelectedDate = DateTime.Parse(dr["LXR_csrq"].ToString());
                        this.ddlLXR_sfsrwh.SelectedValue = dr["LXR_sfsrwh"].ToString();
                        this.dthLXR_gj01.SelectedDate = DateTime.Parse(dr["LXR_gj01"].ToString());
                        this.txtLXR_gj01nr.Text = dr["LXR_gj01nr"].ToString();
                        this.dthLXR_gj02.SelectedDate = DateTime.Parse(dr["LXR_gj02"].ToString());
                        this.txtLXR_gj02nr.Text = dr["LXR_gj02nr"].ToString();
                        this.dthLXR_gj03.SelectedDate = DateTime.Parse(dr["LXR_gj03"].ToString());
                        this.txtLXR_gj03nr.Text = dr["LXR_gj03nr"].ToString();
                    }
                    else
                    {
                        //this.hiddenLXR_id.Value ="0" ;
                        this.dthLXR_csrq.SelectedDate = DateTime.Now;
                        this.dthLXR_gj01.SelectedDate = DateTime.Now;
                        this.dthLXR_gj02.SelectedDate = DateTime.Now;
                        this.dthLXR_gj03.SelectedDate = DateTime.Now;
                    }
                }
                else
                {
                    //this.hiddenLXR_id.Value ="0" ;
                    this.dthLXR_csrq.SelectedDate = DateTime.Now;
                    this.dthLXR_gj01.SelectedDate = DateTime.Now;
                    this.dthLXR_gj02.SelectedDate = DateTime.Now;
                    this.dthLXR_gj03.SelectedDate = DateTime.Now;
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
                model.LXR_id = int.Parse(this.hiddenLXR_id.Text.Trim());
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

                model.OpType = DataOperationType.Modify;
                if (XASYU.BLL.DataBaseManager.op_TABLE_LXR(userBean, model) == 0)
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