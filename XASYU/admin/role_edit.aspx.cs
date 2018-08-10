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
    public partial class role_edit : PageBase
    {
        #region ViewPower

        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "CoreRoleEdit";
            }
        }

        #endregion

        #region 初始化变量
        int V_ITOTALCOUNT = -1;
        private XASYU.MODEL.SYS_ROLESModel RoleModel = new MODEL.SYS_ROLESModel();
        private XASYU.MODEL.SYS_ROLEUSERSModel RoleUserModel = new MODEL.SYS_ROLEUSERSModel();
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
            RoleModel.ID = id;
            DataSet ds = XASYU.BLL.DataBaseQuery.query_SYS_ROLES(userBean, RoleModel, ref  V_ITOTALCOUNT, 0, 20);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                tbxName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                tbxRemark.Text = ds.Tables[0].Rows[0]["Remark"].ToString();
            }
            else
            {
                Alert.Show("参数错误！", String.Empty, ActiveWindow.GetHideReference());
                return;
            }
          
           

        }

     
        #endregion

        #region Events

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            int id = GetQueryIntValue("id");
            RoleModel.ID = id;
            RoleModel.Name = tbxName.Text.Trim();
            RoleModel.Remark = tbxRemark.Text.Trim();
            RoleModel.OpType = DataOperationType.Modify;
            if (XASYU.BLL.DataBaseManager.op_SYS_ROLES(userBean, RoleModel) == 0)
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
