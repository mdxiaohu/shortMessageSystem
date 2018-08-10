using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using FineUI;
using CykjSoft.UserPermissionManager.Utils;

namespace XASYU.admin
{
    public partial class power_new : PageBase
    {
        #region ViewPower

        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "CorePowerNew";
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

        }

        #endregion

        #region Events

        private void SaveItem()
        {      
            PowerModel.Name = tbxName.Text.Trim();
            PowerModel.GroupName = tbxGroupName.Text.Trim();
            PowerModel.Title = tbxTitle.Text.Trim();
            PowerModel.Remark = tbxRemark.Text.Trim();
            PowerModel.OpType = DataOperationType.Add;
            if (XASYU.BLL.DataBaseManager.op_SYS_POWERS(userBean, PowerModel) == 0)
            {
                Alert.Show("添加成功！", String.Empty, ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.Show("添加失败！", String.Empty, ActiveWindow.GetHidePostBackReference());
            }
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            SaveItem();
            //Alert.Show("添加成功！", String.Empty, ActiveWindow.GetHidePostBackReference());
            //PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
        #endregion

    }
}
