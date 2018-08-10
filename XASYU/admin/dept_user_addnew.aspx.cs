using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using FineUI;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using XASYU.MODEL;
using System.Data;

namespace XASYU.admin
{
    public partial class dept_user_addnew : PageBase
    {
        #region ViewPower

        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "CoreDeptUserNew";
            }
        }

        #endregion

        #region 初始化变量
        int V_ITOTALCOUNT = -1;
        private DeptHelper depHelp = new DeptHelper();
        private XASYU.MODEL.SYS_DEPTSModel DeptModel = new MODEL.SYS_DEPTSModel();
        private XASYU.MODEL.SYS_USERSModel UserModel = new MODEL.SYS_USERSModel();
        private XASYU.MODEL.SYS_USERS_DEPTModel UserDeptModel = new MODEL.SYS_USERS_DEPTModel();
        CykjSoft.Bean.UserBean userBean = new CykjSoft.Bean.UserBean();
        #endregion

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
            else
            {
                // 页面回发时要同步选中的行数据到隐藏字段（在触发控件事件之前）
                SyncSelectedRowIndexArrayToHiddenField(hfSelectedIDS, Grid1);
            }
        }

        private void LoadData()
        {
            btnClose.OnClientClick = ActiveWindow.GetHideReference();

            // 每页记录数
            Grid1.PageSize = PageBase.PageSize;
            ddlGridPageSize.SelectedValue = PageBase.PageSize.ToString();


            BindGrid();
        }


        private void BindGrid()
        {
            if (!String.IsNullOrEmpty(this.ttbSearchMessage.Text.Trim()))
            {
                UserDeptModel.UserName = this.ttbSearchMessage.Text.Trim();
            }
            /*以上代码实现查询赋值*/
            //以下绑定没有部门的用户
            string sortField = Grid1.SortField;
            string sortDirection = Grid1.SortDirection;
            DataTable table = new DataTable();
            int pageIndex = Grid1.PageIndex * Grid1.PageSize;
            int pageSize = Grid1.PageSize;
            DataSet ds = XASYU.BLL.DataBaseQuery.query_SYS_USERS_DEPT(userBean, UserDeptModel, ref  V_ITOTALCOUNT, pageIndex, pageSize);
            Grid1.RecordCount = V_ITOTALCOUNT;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                table = ds.Tables[0];
                DataView view2 = table.DefaultView;//排序后绑定
                view2.Sort = String.Format("{0} {1}", sortField, sortDirection);
                table = view2.ToTable();
            }
            Grid1.DataSource = table;
            Grid1.DataBind();


            // 重新绑定表格数据之后，更新选中行
            UpdateSelectedRowIndexArray(hfSelectedIDS, Grid1);
        }

        #endregion

        #region Events

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            int deptID = GetQueryIntValue("id");

            // 从每个选中的行中获取ID（在Grid1中定义的DataKeyNames）
            List<int> ids = GetSelectedIDsFromHiddenField(hfSelectedIDS);

            foreach (int id in ids)
            {
                string strWhere = "ID=" + id;
                Common.UpdateTable("sys_Users", new string[] { "DeptID" }, new string[,] { { "'"+deptID+"'", "0" } }, strWhere);
            }
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        

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


        protected void ddlGridPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            Grid1.PageSize = Convert.ToInt32(ddlGridPageSize.SelectedValue);

            BindGrid();
        }

        #endregion


    }
}
