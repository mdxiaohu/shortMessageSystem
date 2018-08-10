using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using FineUI;
using System.Data;

namespace XASYU.admin
{
    public partial class user_select_role : PageBase
    {
        #region ViewPower

        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "CoreRoleView";
            }
        }

        #endregion

        #region 定义对象
        private XASYU.MODEL.SYS_ROLESModel RoleModel=new MODEL.SYS_ROLESModel();
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

            string ids = GetQueryValue("ids");
            
            // 绑定角色复选框列表
            BindDDLRole();

            // 初始化角色复选框列表的选择项
            cblRole.SelectedValueArray = ids.Split(',');
        }

        private void BindDDLRole()
        {
            int V_ITOTALCOUNT = -1;
            int V_SSTARTINDEX = 0;
            int V_SPERPAGESIZE = 1000;
            List<string> powerlist = new List<string>();
            RoleModel.StartDate = DateTime.Parse("1900-01-01");
            RoleModel.EndDate = DateTime.Now;
            DataTable dt = new DataTable();
            DataSet ds = XASYU.BLL.DataBaseQuery.query_SYS_ROLES(userBean, RoleModel, ref  V_ITOTALCOUNT, V_SSTARTINDEX, V_SPERPAGESIZE);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
                cblRole.DataTextField = "Name";
                cblRole.DataValueField = "ID";
                cblRole.DataSource = dt;
                cblRole.DataBind();
            }
           
        }

        #endregion

        #region Events

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            string roleValues = String.Join(",", cblRole.SelectedItemArray.Select(c => c.Value));
            string roleTexts = String.Join(",", cblRole.SelectedItemArray.Select(c => c.Text));

            PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference(roleValues, roleTexts)
                + ActiveWindow.GetHideReference());
        }

        #endregion

    }
}
