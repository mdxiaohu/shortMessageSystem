using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Linq;
using System.Data;
using XASYU.MODEL;
using CykjSoft.UserPermissionManager.Utils;


namespace XASYU.admin
{
    public partial class user : PageBase
    {
        #region ViewPower

        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "CoreUserView";
            }
        }

        #endregion

        #region 初始化变量
        int V_ITOTALCOUNT = -1;
        private XASYU.MODEL.SYS_USERSModel UserModel = new MODEL.SYS_USERSModel();
        CykjSoft.Bean.UserBean userBean = new CykjSoft.Bean.UserBean();
        #endregion

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    LoadData();
                }
                catch (Exception ex)
                {
                    Alert.ShowInTop(ex.Message);
                }
            }
        }

        private void LoadData()
        {
            // 权限检查
            CheckPowerWithButton("CoreUserEdit", btnChangeEnableUsers);
            CheckPowerWithButton("CoreUserDelete", btnDeleteSelected);
            CheckPowerWithButton("CoreUserNew", btnNew);



            ResolveDeleteButtonForGrid(btnDeleteSelected, Grid1);

            ResolveEnableStatusButtonForGrid(btnEnableUsers, Grid1, true);
            ResolveEnableStatusButtonForGrid(btnDisableUsers, Grid1, false);

            btnNew.OnClientClick = Window1.GetShowReference("~/admin/user_new.aspx", "新增用户");

            // 每页记录数
            Grid1.PageSize = PageBase.PageSize;
            ddlGridPageSize.SelectedValue = PageBase.PageSize.ToString();

            BindGrid();
        }

        private void ResolveEnableStatusButtonForGrid(MenuButton btn, Grid grid, bool enabled)
        {
            string enabledStr = "启用";
            if (!enabled)
            {
                enabledStr = "禁用";
            }
            btn.OnClientClick = grid.GetNoSelectionAlertInParentReference("请至少应该选择一项记录！");
            btn.ConfirmText = String.Format("确定要{1}选中的<span class=\"highlight\"><script>{0}</script></span>项记录吗？", grid.GetSelectedCountReference(), enabledStr);
            btn.ConfirmTarget = FineUI.Target.Top;
        }

        private void BindGrid()
        {
            try
            {
                if (!String.IsNullOrEmpty(this.ttbSearchMessage.Text.Trim()))
                {
                    UserModel.Name = this.ttbSearchMessage.Text.Trim();
                }
                if (this.rblEnableStatus.SelectedValue == "enabled")
                {
                    UserModel.Enabled = true;
                }
                if (this.rblEnableStatus.SelectedValue == "disabled")
                {
                    UserModel.Enabled = false;
                }
                /*以上代码实现查询赋值*/
                string sortField = Grid1.SortField;
                string sortDirection = Grid1.SortDirection;
                DataTable table = new DataTable();
                int pageIndex = Grid1.PageIndex * Grid1.PageSize;
                int pageSize = Grid1.PageSize;
                DataSet ds = XASYU.BLL.DataBaseQuery.query_SYS_USERS(userBean, UserModel, ref  V_ITOTALCOUNT, pageIndex, pageSize);
                Grid1.RecordCount = V_ITOTALCOUNT;
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {           
                    table = ds.Tables[0];
                    DataView view2 = table.DefaultView;//排序后绑定
                    view2.RowFilter = "Name <> 'admin'";//添加条件过滤掉admin
                    view2.Sort = String.Format("{0} {1}", sortField, sortDirection);
                    table = view2.ToTable();
                }
                Grid1.DataSource = table;
                Grid1.DataBind();

            }
            catch (Exception ex)
            {
                Alert.ShowInTop(ex.Message);
            }
        }

        #endregion

        #region Events

        protected void ttbSearchMessage_Trigger2Click(object sender, EventArgs e)
        {
            ttbSearchMessage.ShowTrigger1 = true;
            BindGrid();
        }

        protected void ttbSearchMessage_Trigger1Click(object sender, EventArgs e)
        {
            ttbSearchMessage.Text = String.Empty;
            ttbSearchMessage.ShowTrigger1 = false;
            BindGrid();
        }

        protected void Grid1_PreDataBound(object sender, EventArgs e)
        {
            
            // 数据绑定之前，进行权限检查
            CheckPowerWithWindowField("CoreUserEdit", Grid1, "editField");
            CheckPowerWithLinkButtonField("CoreUserDelete", Grid1, "deleteField");
            CheckPowerWithWindowField("CoreUserChangePassword", Grid1, "changePasswordField");

        }

        protected void Grid1_PreRowDataBound(object sender, FineUI.GridPreRowEventArgs e)
        {
            //User user = e.DataItem as User;
            //string userName=GetSelectedDataKey(Grid1, 1);
            SYS_USERSModel user=e.DataItem as SYS_USERSModel;

            if (user != null)
            {
                // 不能删除超级管理员
                if (user.Name == "admin")
                {
                    FineUI.LinkButtonField deleteField = Grid1.FindColumn("deleteField") as FineUI.LinkButtonField;
                    deleteField.Enabled = false;
                    deleteField.ToolTip = "不能删除超级管理员！";
                }
            }

        }

        protected void Grid1_Sort(object sender, GridSortEventArgs e)
        {
            Grid1.SortDirection = e.SortDirection;
            Grid1.SortField = e.SortField;
            BindGrid();
        }

        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            // 在操作之前进行权限检查
            if (!CheckPower("CoreUserDelete"))
            {
                CheckPowerFailWithAlert();
                return;
            }

            // 从每个选中的行中获取ID（在Grid1中定义的DataKeyNames）
            List<int> ids = GetSelectedDataKeyIDs(Grid1);
            // 执行数据库操作
            foreach (int id in ids)
            {
                UserModel.ID = id;
                UserModel.OpType = DataOperationType.Delete;
                XASYU.BLL.DataBaseManager.op_SYS_USERS(userBean, UserModel);
            }
            // 重新绑定表格
            //删除成功后，给ID重新初始化，否则ID的值仍然是刚删除记录之后的ID，会出错!
            UserModel.ID = 0;
            // 重新绑定表格
            BindGrid();
        }

        protected void btnEnableUsers_Click(object sender, EventArgs e)
        {
            SetSelectedUsersEnableStatus(true);
        }

        protected void btnDisableUsers_Click(object sender, EventArgs e)
        {
            SetSelectedUsersEnableStatus(false);
        }


        private void SetSelectedUsersEnableStatus(bool enabled)
        {
            // 在操作之前进行权限检查
            if (!CheckPower("CoreUserEdit"))
            {
                CheckPowerFailWithAlert();
                return;
            }

            // 从每个选中的行中获取ID（在Grid1中定义的DataKeyNames）
            List<int> ids = GetSelectedDataKeyIDs(Grid1);

            // 执行数据库操作
            foreach (int id in ids)
            {
                UserModel.ID = id;
                string strWhere = "ID=" + id;
                Common.UpdateTable("sys_Users", new string[] { "Enabled" }, new string[,] { { "'" + enabled + "'", "0" } }, strWhere);
            }
            UserModel.ID = 0;
            // 重新绑定表格
            BindGrid();
        }

        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            int userID = GetSelectedDataKeyID(Grid1);
            string userName = GetSelectedDataKey(Grid1, 1);

            if (e.CommandName == "Delete")
            {
                // 在操作之前进行权限检查
                if (!CheckPower("CoreUserDelete"))
                {
                    CheckPowerFailWithAlert();
                    return;
                }

                if (userName == "admin")
                {
                    Alert.ShowInTop("不能删除默认的系统管理员（admin）！");
                }
                else
                {
                    UserModel.ID = userID;
                    UserModel.OpType = DataOperationType.Delete;
                    XASYU.BLL.DataBaseManager.op_SYS_USERS(userBean, UserModel);
                    UserModel.ID = 0;
                    BindGrid();
                }
            }
        }

        protected void Window1_Close(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void rblEnableStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }


        protected void ddlGridPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            Grid1.PageSize = Convert.ToInt32(ddlGridPageSize.SelectedValue);

            BindGrid();
        }

        #endregion

    }
}
