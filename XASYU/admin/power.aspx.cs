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
    public partial class power : PageBase
    {
        #region ViewPower

        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "CorePowerView";
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
            // 权限检查
            CheckPowerWithButton("CorePowerNew", btnNew);
            //CheckPowerDeleteWithButton(btnDeleteSelected);

            //ResolveDeleteButtonForGrid(btnDeleteSelected, Grid1);

            btnNew.OnClientClick = Window1.GetShowReference("~/admin/power_new.aspx", "新增权限");

            
            // 每页记录数
            Grid1.PageSize = PageBase.PageSize;
            ddlGridPageSize.SelectedValue = PageBase.PageSize.ToString();

            
            BindGrid();
        }

        private void BindGrid()
        {
            if (!String.IsNullOrEmpty(this.ttbSearchMessage.Text.Trim()))
            {
                PowerModel.Name = this.ttbSearchMessage.Text.Trim();
            }
              /*以上代码实现查询赋值*/
            string sortField = Grid1.SortField;
            string sortDirection = Grid1.SortDirection;
            DataTable table = new DataTable();
            int pageIndex = Grid1.PageIndex * Grid1.PageSize;
            int pageSize = Grid1.PageSize;
            DataSet ds = XASYU.BLL.DataBaseQuery.query_SYS_POWERS(userBean, PowerModel, ref  V_ITOTALCOUNT, pageIndex, pageSize);
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
            CheckPowerWithWindowField("CorePowerEdit", Grid1, "editField");
            CheckPowerWithLinkButtonField("CorePowerDelete", Grid1, "deleteField");
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

        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            int VL_ITOTALCOUNT = -1;
            int powerID = GetSelectedDataKeyID(Grid1);

            if (e.CommandName == "Delete")
            {
                // 在操作之前进行权限检查
                if (!CheckPower("CorePowerDelete"))
                {
                    CheckPowerFailWithAlert();
                    return;
                }
                RolePowerModel.PowerID = powerID;
                DataSet ds = XASYU.BLL.DataBaseQuery.query_SYS_ROLEPOWERS(userBean, RolePowerModel, ref  VL_ITOTALCOUNT, 0, 20);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    Alert.ShowInTop("删除失败！需要先清空使用此权限的角色！");
                    return;
                }
                PowerModel.ID = powerID;
                PowerModel.OpType = DataOperationType.Delete;
                //将Role表中的角色删除
                XASYU.BLL.DataBaseManager.op_SYS_POWERS(userBean, PowerModel);

                PowerModel.ID = 0;

                BindGrid();
            }
        }


        protected void Window1_Close(object sender, EventArgs e)
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
