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
    public partial class frmTABLE_TXQZEdit : PageBase
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
        private XASYU.MODEL.TABLE_TXQZModel model = new XASYU.MODEL.TABLE_TXQZModel();
        CykjSoft.Bean.UserBean userBean = new CykjSoft.Bean.UserBean();
        #endregion

        #region 页面加载

        protected override void OnLoad(EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
                if (Request.QueryString["TXQZ_ID"] != null && Request.QueryString["TXQZ_ID"].ToString().Trim() != "")
                {
                    XASYU.MODEL.TABLE_TXQZModel temp = new XASYU.MODEL.TABLE_TXQZModel();
                    temp.TXQZ_id = int.Parse(Request.QueryString["TXQZ_ID"].ToString().Trim());
                    int iCount = -1;
                    DataSet ds = XASYU.BLL.DataBaseQuery.query_TABLE_TXQZ(userBean, temp, ref iCount, 0, 10);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        this.hiddenTXQZ_id.Text = dr["TXQZ_id"].ToString();
                        this.txtTXQZ_name.Text = dr["TXQZ_name"].ToString();
                        this.txtTXQZ_sjid.Text = dr["TXQZ_sjid"].ToString();
                    }
                    else
                    {
                        //this.hiddenTXQZ_id.Value ="0" ;
                    }
                }
                else
                {
                    //this.hiddenTXQZ_id.Value ="0" ;
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
                model.TXQZ_id = int.Parse(this.hiddenTXQZ_id.Text.Trim());
                model.TXQZ_name = this.txtTXQZ_name.Text;
                model.TXQZ_sjid = int.Parse(this.txtTXQZ_sjid.Text.Trim());

                model.OpType = DataOperationType.Modify;
                if (XASYU.BLL.DataBaseManager.op_TABLE_TXQZ(userBean, model) == 0)
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