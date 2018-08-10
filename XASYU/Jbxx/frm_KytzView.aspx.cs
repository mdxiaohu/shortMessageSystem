using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Data;
using CykjSoft.Bean;
using CykjSoft.UserPermissionManager.Bean;
using CykjSoft.UserPermissionManager.Business;
using CykjSoft.UserPermissionManager.Utils;
using System.Text;
using System.IO;

namespace XASYU.Jbxx
{
    public partial class frm_KytzView : PageBase
    {
        #region ViewPower

        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "CoreKytzView";
            }
        }

        #endregion
        
        #region //初始化变量
        int S_ID;
        int V_ITOTALCOUNT = -1;
        int V_SSTARTINDEX = 0;
        int V_SPERPAGESIZE = 1000;
        private XASYU.MODEL.TABLE_KYTZModel Table_XYBM = new MODEL.TABLE_KYTZModel();
        //static DateTime startdate = DateTime.Parse("1900-01-01");
        //static DateTime enddate = DateTime.Now.Date.AddDays(1).AddSeconds(-1);
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


        //数据加载
        private void LoadData()
        {
            // 检查新增、删除选择记录按钮权限         
            CheckPowerWithButton("CoreKytzDelete", btnDeleteSelected);
            CheckPowerWithButton("CoreKytzNew", btnNew);
            //删除按钮提示事件
            ResolveDeleteButtonForGrid(btnDeleteSelected, Grid1);

            btnNew.OnClientClick = Window1.GetShowReference("~/Jbxx/frm_KytzNew.aspx", "新增科研通知");

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
                    Table_XYBM.tzmc = this.ttbSearchMessage.Text.Trim();
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
            Table_XYBM.StartDate = DateTime.Parse("1900-01-01");
            //DateTime.Now.AddDays(-7);
            Table_XYBM.EndDate = DateTime.Now;
            //Table_XYBM.tzfj = Num;
            DataTable table = new DataTable();
            DataSet ds = XASYU.BLL.DataBaseQuery.query_TABLE_KYTZ(userBean, Table_XYBM, ref  V_ITOTALCOUNT, V_SSTARTINDEX, V_SPERPAGESIZE);
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
            List<int> ids = GetSelectedDataKeyIDs(Grid1);
            // 执行数据库操作
            foreach (int id in ids)
            {
                Table_XYBM.SerialNO = id;
                Table_XYBM.OpType = DataOperationType.Delete;
                XASYU.BLL.DataBaseManager.op_TABLE_KYTZ(userBean, Table_XYBM);
            }
            // 重新绑定表格
            //删除成功后，给ID重新初始化，否则ID的值仍然是刚删除记录之后的ID，会出错!
            Table_XYBM.SerialNO = 0;
            BindGrid();
        }

        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        { 
            int ID = GetSelectedDataKeyID(Grid1);
            //string userName = GetSelectedDataKey(Grid1, 1);
            if (e.CommandName == "Delete")
            {
                // 在操作之前进行权限检查
                if (!CheckPower("CoreKytzDelete"))
                {
                    CheckPowerFailWithAlert();
                    return;
                }
                Table_XYBM.SerialNO = ID;
                Table_XYBM.OpType = DataOperationType.Delete;
                if (XASYU.BLL.DataBaseManager.op_TABLE_KYTZ(userBean, Table_XYBM) == 0)
                {   //删除成功后，给ID重新初始化，否则ID的值仍然是刚删除记录之后的ID，会出错!
                    Table_XYBM.SerialNO = 0;
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
                string URL = "Jbxx/frm_KytzXQ.aspx?id=" + ID;
                PageContext.RegisterStartupScript("Open_TabTest('test','" + URL + "','test');");
                //btnTest.OnClientClick = "Open_TabTest('test','" + URL + "','test');";
 
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

        #region ExcelEvents

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=myexcel.xls");
            Response.ContentType = "application/excel";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Write(GetGridTableHtml(Grid1));
            Response.End();
        }

        private string GetGridTableHtml(Grid grid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<meta http-equiv=\"content-type\" content=\"application/excel; charset=UTF-8\"/>");
            sb.Append("<table cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse;\">");
            sb.Append("<tr>");
            foreach (GridColumn column in grid.Columns)
            {
                sb.AppendFormat("<td>{0}</td>", column.HeaderText);
            }
            sb.Append("</tr>");
            foreach (GridRow row in grid.Rows)
            {
                sb.Append("<tr>");
                foreach (object value in row.Values)
                {
                    string html = value.ToString();
                    if (html.StartsWith(Grid.TEMPLATE_PLACEHOLDER_PREFIX))
                    {
                        // 模板列
                        string templateID = html.Substring(Grid.TEMPLATE_PLACEHOLDER_PREFIX.Length);
                        Control templateCtrl = row.FindControl(templateID);
                        html = GetRenderedHtmlSource(templateCtrl);
                    }
                    else
                    {
                        // 处理CheckBox
                        if (html.Contains("f-grid-static-checkbox"))
                        {
                            if (html.Contains("uncheck"))
                            {
                                html = "×";
                            }
                            else
                            {
                                html = "√";
                            }
                        }

                        // 处理图片
                        if (html.Contains("<img"))
                        {
                            string prefix = Request.Url.AbsoluteUri.Replace(Request.Url.AbsolutePath, "");
                            html = html.Replace("src=\"", "src=\"" + prefix);
                        }
                    }
                    sb.AppendFormat("<td>{0}</td>", html);
                }
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            return sb.ToString();
        }

        /// <summary>
        /// 获取控件渲染后的HTML源代码
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        private string GetRenderedHtmlSource(Control ctrl)
        {
            if (ctrl != null)
            {
                using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                    {
                        ctrl.RenderControl(htw);

                        return sw.ToString();
                    }
                }
            }
            return String.Empty;
        }

        #endregion
    }
}