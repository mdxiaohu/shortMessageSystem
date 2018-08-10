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
    public partial class frmTABLE_SJXEdit : PageBase
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
        private XASYU.MODEL.TABLE_SJXModel model = new XASYU.MODEL.TABLE_SJXModel();
        CykjSoft.Bean.UserBean userBean = new CykjSoft.Bean.UserBean();
        #endregion

        #region 页面加载

        protected override void OnLoad(EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
                if (Request.QueryString["SJX_ID"] != null && Request.QueryString["SJX_ID"].ToString().Trim() != "")
                {
                    XASYU.MODEL.TABLE_SJXModel temp = new XASYU.MODEL.TABLE_SJXModel();
                    temp.SJX_id = int.Parse(Request.QueryString["SJX_ID"].ToString().Trim());
                    int iCount = -1;
                    DataSet ds = XASYU.BLL.DataBaseQuery.query_TABLE_SJX(userBean, temp, ref iCount, 0, 10);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        this.hiddenSJX_id.Text = dr["SJX_id"].ToString();
                        this.txtSJX_mobile.Text = dr["SJX_mobile"].ToString();
                        this.txtSJX_nr.Text = dr["SJX_nr"].ToString();
                        this.dthSJX_jstime.SelectedDate = DateTime.Parse(dr["SJX_jstime"].ToString());
                    }
                    else
                    {
                        //this.hiddenSJX_id.Value ="0" ;
                        this.dthSJX_jstime.SelectedDate = DateTime.Now;
                    }
                }
                else
                {
                    //this.hiddenSJX_id.Value ="0" ;
                    this.dthSJX_jstime.SelectedDate = DateTime.Now;
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
                model.SJX_id = int.Parse(this.hiddenSJX_id.Text.Trim());
                model.SJX_mobile = this.txtSJX_mobile.Text;
                model.SJX_nr = this.txtSJX_nr.Text;
                model.SJX_jstime = DateTime.Parse(this.dthSJX_jstime.Text.ToString());

                model.OpType = DataOperationType.Modify;
                if (XASYU.BLL.DataBaseManager.op_TABLE_SJX(userBean, model) == 0)
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