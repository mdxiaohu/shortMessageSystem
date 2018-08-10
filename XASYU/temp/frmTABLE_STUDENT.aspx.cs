using CykjSoft.UserPermissionManager.Utils;
using FineUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XASYU.temp
{
    public partial class frmTABLE_STUDENT : PageBase
    {
        #region 浏览权限
        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "";
            }
        }
        #endregion

        #region 定义对象
        int V_ITOTALCOUNT = -1;
        int V_SSTARTINDEX = 0;
        int V_SPERPAGESIZE = 1000;
        private XASYU.MODEL.TABLE_STUDENTModel model = new XASYU.MODEL.TABLE_STUDENTModel();
        CykjSoft.Bean.UserBean userBean = new CykjSoft.Bean.UserBean();
        #endregion

        #region 页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //手动添加需要绑定的内容
                LoadData();
            }
        }
        #endregion

        #region 手动添加需要绑定的内容
        private void LoadData()
        {
            CheckPowerWithButton("CoreKytzDelete", btnDeleteSelected);
            CheckPowerWithButton("CoreKytzNew", btnNew);
            //删除按钮提示事件
            ResolveDeleteButtonForGrid(btnDeleteSelected, Grid1);

            btnNew.OnClientClick = Window1.GetShowReference("frmTABLE_STUDENTNew.fx", "");

            // 每页记录数
            Grid1.PageSize = PageBase.PageSize;
            ddlGridPageSize.SelectedValue = PageBase.PageSize.ToString();

            BindGrid();
        }
        //数据绑定
        private void BindGrid()
        {
            try
            {
                //给搜索条件赋值
                if (!string.IsNullOrEmpty(this.ttbSearchMessage.Text.ToString()))
                {

                }
                // 1.设置总项数（特别注意：数据库分页一定要设置总记录数RecordCount）
                Grid1.RecordCount = GetTotalCount();
                // 2.获取当前分页数据
                DataTable table = GetPagedDataTable();
                // 3.绑定到Grid
                Grid1.DataSource = table;
                Grid1.DataBind();
            }
            catch (Exception ex)
            {
                Alert.ShowInTop(ex.Message);
            }
        }
        //获取数据将数据存入DataTable，分页自动完成，其余页面只需要将新数据赋给DataTable
        protected DataTable GetDataTable()
        {
            model.StartDate = DateTime.Parse("1900-01-01");
            model.EndDate = DateTime.Now;
            DataTable table = new DataTable();
            DataSet ds = XASYU.BLL.DataBaseQuery.query_TABLE_STUDENT(userBean, model, ref  V_ITOTALCOUNT, V_SSTARTINDEX, V_SPERPAGESIZE);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                table = ds.Tables[0];
            }
            return table;
        }
        //返回总项数
        private int GetTotalCount()
        {
            return GetDataTable().Rows.Count;
        }

        //数据库分页
        private DataTable GetPagedDataTable()
        {
            int pageIndex = Grid1.PageIndex;
            int pageSize = Grid1.PageSize;
            string sortField = Grid1.SortField;
            string sortDirection = Grid1.SortDirection;
            DataTable table2 = GetDataTable();
            DataView view2 = table2.DefaultView;
            view2.Sort = String.Format("{0} {1}", sortField, sortDirection);
            DataTable table = view2.ToTable();
            DataTable paged = table.Clone();
            int rowbegin = pageIndex * pageSize;
            int rowend = (pageIndex + 1) * pageSize;
            if (rowend > table.Rows.Count)
            {
                rowend = table.Rows.Count;
            }
            for (int i = rowbegin; i < rowend; i++)
            {
                paged.ImportRow(table.Rows[i]);
            }
            return paged;
        }

        #endregion

        #region 控件事件

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
            // 数据绑定之前，进行权限检查，主要针对Grid中的删除、编辑、删除
            CheckPowerWithWindowField("CoreKytzEdit", Grid1, "editField");
            CheckPowerWithLinkButtonField("CoreKytzDelete", Grid1, "deleteField");
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
            if (!CheckPower("CoreKytzDelete"))
            {
                CheckPowerFailWithAlert();
                return;
            }
            // 从每个选中的行中获取ID（在Grid1中定义的DataKeyNames）
            List<string> ids = GetSelectedDataKeyIDString(Grid1);
            // 执行数据库操作
            foreach (string id in ids)
            {
                model.Stu_NO = id;
                model.OpType = DataOperationType.Delete;
                XASYU.BLL.DataBaseManager.op_TABLE_STUDENT(userBean, model);
            }
            // 重新绑定表格
            //删除成功后，给ID重新初始化，否则ID的值仍然是刚删除记录之后的ID，会出错!
            model.Stu_NO = "";
            BindGrid();
        }
        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            //int ID = GetSelectedDataKeyID(Grid1);
            string ID = GetSelectedDataKey(Grid1, 0);
            if (e.CommandName == "Delete")
            {
                // 在操作之前进行权限检查
                if (!CheckPower("CoreKytzDelete"))
                {
                    CheckPowerFailWithAlert();
                    return;
                }
                model.Stu_NO = ID;
                model.OpType = DataOperationType.Delete;
                if (XASYU.BLL.DataBaseManager.op_TABLE_STUDENT(userBean, model) == 0)
                {   //删除成功后，给ID重新初始化，否则ID的值仍然是刚删除记录之后的ID，会出错!
                    model.Stu_NO = "";
                    BindGrid();//重新绑定
                    Alert.ShowInTop("删除成功！");
                }
                else
                {
                    Alert.ShowInTop("删除失败!");
                }
            }
            if (e.CommandName == "ViewXQ")
            {
                string URL = "~/frmTABLE_STUDENTXQ.fx?id=" + ID;
                PageContext.RegisterStartupScript("Open_TabTest('test','" + URL + "','test');");
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