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
    public partial class title_user : PageBase
    {
        #region ViewPower

        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "CoreTitleUserView";
            }
        }

        #endregion

        #region 初始化变量
        private XASYU.MODEL.SYS_TITLESModel TitleModel = new MODEL.SYS_TITLESModel();
        private XASYU.MODEL.SYS_USERS_TITLEModel UserTitleModel = new MODEL.SYS_USERS_TITLEModel();
        private XASYU.MODEL.SYS_TITLEUSERSModel TitleUserModel = new MODEL.SYS_TITLEUSERSModel();
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
            // 权限检查
            CheckPowerWithButton("CoreTitleUserNew", btnNew);
            CheckPowerWithButton("CoreTitleUserDelete", btnDeleteSelected);


            ResolveDeleteButtonForGrid(btnDeleteSelected, Grid2, "确定要从当前职称移除选中的{0}项记录吗？");

            BindGrid1();

            // 默认选中第一个职称
            Grid1.SelectedRowIndex = 0;

            // 每页记录数
            Grid2.PageSize = PageBase.PageSize;
            ddlGridPageSize.SelectedValue = PageBase.PageSize.ToString();

            BindGrid2();
        }

        private void BindGrid1()
        {
            string sortField = Grid1.SortField;
            string sortDirection = Grid1.SortDirection;
            int V_ITOTALCOUNT = -1;
            int V_SSTARTINDEX = 0;
            int V_SPERPAGESIZE = 1000;
            DataTable table = new DataTable();
            DataSet ds = XASYU.BLL.DataBaseQuery.query_SYS_TITLES(userBean, TitleModel, ref  V_ITOTALCOUNT, V_SSTARTINDEX, V_SPERPAGESIZE);
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

        private void BindGrid2()
        {
            int titleID = GetSelectedDataKeyID(Grid1);

            if (titleID == -1)
            {
                Grid2.RecordCount = 0;

                Grid2.DataSource = null;
                Grid2.DataBind();
            }
            else
            {
                if (!String.IsNullOrEmpty(this.ttbSearchUser.Text.Trim()))
                {
                    TitleUserModel.UserID = int.Parse(getUserID(this.ttbSearchUser.Text.Trim()));
                }
                /*以上代码实现查询赋值*/
                int V_ITOTALCOUNT = -1;
                string sortField = Grid2.SortField;
                string sortDirection = Grid2.SortDirection;   
                int pageIndex = Grid2.PageIndex * Grid2.PageSize;
                int pageSize = Grid2.PageSize;
                TitleUserModel.TitleID = titleID;
                DataTable table = new DataTable();
                DataSet ds = XASYU.BLL.DataBaseQuery.query_SYS_TITLEUSERS(userBean, TitleUserModel, ref  V_ITOTALCOUNT, pageIndex, pageSize);
                Grid2.RecordCount = V_ITOTALCOUNT;
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    table = ds.Tables[0];
                    DataView view2 = table.DefaultView;//排序后绑定
                    view2.RowFilter = "Name <> 'admin'";//添加条件过滤掉admin
                    view2.Sort = String.Format("{0} {1}", sortField, sortDirection);
                    table = view2.ToTable();
                }
                Grid2.DataSource = table;
                Grid2.DataBind();
            }

        }


        #endregion

        #region Events

        protected void ddlGridPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            Grid2.PageSize = Convert.ToInt32(ddlGridPageSize.SelectedValue);

            BindGrid2();
        }


        #endregion

        #region Grid1 Events

        protected void Grid1_Sort(object sender, GridSortEventArgs e)
        {
			Grid1.SortDirection = e.SortDirection;
            Grid1.SortField = e.SortField;
            BindGrid1();

            // 默认选中第一个职称
            Grid1.SelectedRowIndex = 0;

            BindGrid2();
        }

        protected void Grid1_RowClick(object sender, FineUI.GridRowClickEventArgs e)
        {
            BindGrid2();
        }

        #endregion

        #region Grid2 Events

        protected void ttbSearchUser_Trigger2Click(object sender, EventArgs e)
        {
            ttbSearchUser.ShowTrigger1 = true;
            BindGrid2();
        }

        protected void ttbSearchUser_Trigger1Click(object sender, EventArgs e)
        {
            ttbSearchUser.Text = String.Empty;
            ttbSearchUser.ShowTrigger1 = false;
            BindGrid2();
        }

        protected void Grid2_PreDataBound(object sender, EventArgs e)
        {
            // 数据绑定之前，进行权限检查
            CheckPowerWithLinkButtonField("CoreTitleUserDelete", Grid2, "deleteField");
        }

        protected void Grid2_Sort(object sender, GridSortEventArgs e)
        {
			Grid2.SortDirection = e.SortDirection;
            Grid2.SortField = e.SortField;
            BindGrid2();
        }

        protected void Grid2_PageIndexChange(object sender, GridPageEventArgs e)
        {
            Grid2.PageIndex = e.NewPageIndex;
            BindGrid2();
        }

        protected void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            // 在操作之前进行权限检查
            if (!CheckPower("CoreTitleUserDelete"))
            {
                CheckPowerFailWithAlert();
                return;
            }

            // 从每个选中的行中获取ID（在Grid1中定义的DataKeyNames）
            int titleID = GetSelectedDataKeyID(Grid1);
            List<int> userIDs = GetSelectedDataKeyIDs(Grid2);

            for (int i = 0; i < userIDs.Count; i++)
            {
                UserTitleModel.TitleID = titleID;
                UserTitleModel.UserID = userIDs[i];
                UserTitleModel.OpType = DataOperationType.Delete;
                XASYU.BLL.DataBaseManager.op_SYS_USERS_TITLE(userBean, UserTitleModel);
            }

                // 清空当前选中的项
                Grid2.SelectedRowIndexArray = null;
                TitleUserModel.UserID = 0;

            // 重新绑定表格
            BindGrid2();
        }


        protected void Grid2_RowCommand(object sender, GridCommandEventArgs e)
        {
            object[] values = Grid2.DataKeys[e.RowIndex];
            int userID = Convert.ToInt32(values[0]);

            if (e.CommandName == "Delete")
            {
                // 在操作之前进行权限检查
                if (!CheckPower("CoreTitleUserDelete"))
                {
                    CheckPowerFailWithAlert();
                    return;
                }

                int titleID = GetSelectedDataKeyID(Grid1);

                List<int> userIDs = GetSelectedDataKeyIDs(Grid2);

                for (int i = 0; i < userIDs.Count; i++)
                {
                    UserTitleModel.TitleID = titleID;
                    UserTitleModel.UserID = userIDs[i];
                    UserTitleModel.OpType = DataOperationType.Delete;
                    XASYU.BLL.DataBaseManager.op_SYS_USERS_TITLE(userBean, UserTitleModel);
                }

                // 清空当前选中的项
                Grid2.SelectedRowIndexArray = null;
                TitleUserModel.UserID = 0;

                BindGrid2();

            }
        }

        protected void Window1_Close(object sender, EventArgs e)
        {
            BindGrid2();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            int titleID = GetSelectedDataKeyID(Grid1);
            string addUrl = String.Format("~/admin/title_user_addnew.aspx?id={0}", titleID);

            PageContext.RegisterStartupScript(Window1.GetShowReference(addUrl, "添加用户到当前职称"));
        }

        #endregion

    }
}
