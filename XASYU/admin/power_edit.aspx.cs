using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using FineUI;
using System.Data;
using CykjSoft.UserPermissionManager.Utils;

namespace XASYU.admin
{
    public partial class power_edit : PageBase
    {
        #region ViewPower

        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "CorePowerEdit";
            }
        }

        #endregion

        #region 初始化变量
        int V_ITOTALCOUNT = -1;
        private XASYU.MODEL.SYS_POWERSModel PowerModel = new MODEL.SYS_POWERSModel();
        private XASYU.MODEL.SYS_ROLEPOWERSModel RolePowerModel = new MODEL.SYS_ROLEPOWERSModel();
        CykjSoft.Bean.UserBean userBean = new CykjSoft.Bean.UserBean();
        #endregion

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            btnClose.OnClientClick = ActiveWindow.GetHideReference();

            int id = GetQueryIntValue("id");
            PowerModel.ID = id;
            DataSet ds = XASYU.BLL.DataBaseQuery.query_SYS_POWERS(userBean, PowerModel, ref  V_ITOTALCOUNT, 0, 20);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                tbxName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                tbxGroupName.Text = ds.Tables[0].Rows[0]["GroupName"].ToString();
                tbxTitle.Text = ds.Tables[0].Rows[0]["Title"].ToString();
                tbxRemark.Text = ds.Tables[0].Rows[0]["Remark"].ToString();
            }
            else
            {
                // 参数错误，首先弹出Alert对话框然后关闭弹出窗口
                Alert.Show("参数错误！", String.Empty, ActiveWindow.GetHideReference());
                return;
            }     
        }


        #endregion

        #region Events

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            int id = GetQueryIntValue("id");
            PowerModel.ID = id;
            PowerModel.Name = tbxName.Text.Trim();
            PowerModel.GroupName = tbxGroupName.Text.Trim();
            PowerModel.Title = tbxTitle.Text.Trim();
            PowerModel.Remark = tbxRemark.Text.Trim();
            PowerModel.OpType = DataOperationType.Modify;
            if (XASYU.BLL.DataBaseManager.op_SYS_POWERS(userBean, PowerModel) == 0)
            {
                Alert.Show("编辑成功！", String.Empty, ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.Show("编辑失败！", String.Empty, ActiveWindow.GetHidePostBackReference());
            }
            //FineUI.Alert.Show("保存成功！", String.Empty, FineUI.Alert.DefaultIcon, FineUI.ActiveWindow.GetHidePostBackReference());
            //PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        #endregion

    }
}
