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
    public partial class frmTABLE_DXHFEdit : PageBase
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
        private XASYU.MODEL.TABLE_DXHFModel model = new XASYU.MODEL.TABLE_DXHFModel();
        CykjSoft.Bean.UserBean userBean = new CykjSoft.Bean.UserBean();
        #endregion

        #region 页面加载

        protected override void OnLoad(EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
                if (Request.QueryString["DXHF_ID"] != null && Request.QueryString["DXHF_ID"].ToString().Trim() != "")
                {
                    XASYU.MODEL.TABLE_DXHFModel temp = new XASYU.MODEL.TABLE_DXHFModel();
                    temp.DXHF_id = int.Parse(Request.QueryString["DXHF_ID"].ToString().Trim());
                    int iCount = -1;
                    DataSet ds = XASYU.BLL.DataBaseQuery.query_TABLE_DXHF(userBean, temp, ref iCount, 0, 10);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        this.hiddenDXHF_id.Text = dr["DXHF_id"].ToString();
                        this.txtSMS_id.Text = dr["SMS_id"].ToString();
                        this.txtDXHF_hfrmobile.Text = dr["DXHF_hfrmobile"].ToString();
                        this.txtDXHF_nr.Text = dr["DXHF_nr"].ToString();
                        this.txtDXHF_time.Text = dr["DXHF_time"].ToString();
                    }
                    else
                    {
                        //this.hiddenDXHF_id.Value ="0" ;
                    }
                }
                else
                {
                    //this.hiddenDXHF_id.Value ="0" ;
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
                model.DXHF_id = int.Parse(this.hiddenDXHF_id.Text.Trim());
                model.SMS_id = int.Parse(this.txtSMS_id.Text.Trim());
                model.DXHF_hfrmobile = this.txtDXHF_hfrmobile.Text;
                model.DXHF_nr = this.txtDXHF_nr.Text;
                model.DXHF_time = this.txtDXHF_time.Text;

                model.OpType = DataOperationType.Modify;
                if (XASYU.BLL.DataBaseManager.op_TABLE_DXHF(userBean, model) == 0)
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