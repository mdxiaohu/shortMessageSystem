using CykjSoft.UserPermissionManager.Utils;
using FineUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XASYU.dxxt
{
    public partial class frmTABLE_LXR : PageBase
    {
        #region 浏览权限
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

        #region 定义对象
        int V_ITOTALCOUNT = -1;
        int V_SSTARTINDEX = 0;
        int V_SPERPAGESIZE = 1000;
        private XASYU.MODEL.TABLE_LXRModel model = new XASYU.MODEL.TABLE_LXRModel();
        bool s;
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

           

            btnNew.OnClientClick = Window1.GetShowReference("frmTABLE_LXRNew.aspx", "");

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
                //if (!string.IsNullOrEmpty(this.ttbSearchMessage.Text.ToString()))
                //{
                //    model.LXR_name = this.ttbSearchMessage.Text.Trim();
                //}
                if (!String.IsNullOrEmpty(this.txtName.Text))
                {
                    model.LXR_name = this.txtName.Text.Trim();
                }
                if (!string.IsNullOrEmpty(this.txtMobile.Text))
                {
                    model.LXR_mobile = this.txtMobile.Text.Trim();
                }
                if(!string.IsNullOrEmpty(this.txtGzdw.Text))
                {
                    model.LXR_gzdw = this.txtGzdw.Text.Trim();
                }
                if (!string.IsNullOrEmpty(this.txtXb.Text))
                {
                    model.LXR_sex = this.txtXb.Text.Trim();
                    //s= bool.Parse(this.txtJrwh.SelectedValue);
                    //bool.Parse(this.txtJrwh.Text.Trim());
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
            DataSet ds = XASYU.BLL.DataBaseQuery.query_TABLE_LXR(userBean, model, ref V_ITOTALCOUNT, V_SSTARTINDEX, V_SPERPAGESIZE);
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

        //protected void ttbSearchMessage_Trigger2Click(object sender, EventArgs e)
        //{
        //    ttbSearchMessage.ShowTrigger1 = true;
        //    BindGrid();
        //}

        //protected void ttbSearchMessage_Trigger1Click(object sender, EventArgs e)
        //{
        //    ttbSearchMessage.Text = String.Empty;
        //    ttbSearchMessage.ShowTrigger1 = false;
        //    BindGrid();
        //}

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
                model.LXR_id = id;
                model.OpType = DataOperationType.Delete;
                XASYU.BLL.DataBaseManager.op_TABLE_LXR(userBean, model);
            }
            // 重新绑定表格
            //删除成功后，给ID重新初始化，否则ID的值仍然是刚删除记录之后的ID，会出错!
            model.LXR_id = 0;
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
                model.LXR_id = ID;
                model.OpType = DataOperationType.Delete;
                if (XASYU.BLL.DataBaseManager.op_TABLE_LXR(userBean, model) == 0)
                {   //删除成功后，给ID重新初始化，否则ID的值仍然是刚删除记录之后的ID，会出错!
                    model.LXR_id = 0;
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
                string URL = "~/frmTABLE_LXRXQ.aspx?id=" + ID;
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

        #region 导出功能

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=联系人信息.xls");
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

        #region 短信发送
      

        /// <summary>
        /// 发送短信
        /// smsUid:用户ID
        /// smsKey:用户密码
        /// smsMob:手机号码
        /// smsText:短信内容
        /// </summary>
        public static string SmsSend(string mobile,string beizhu)
        {
            string strRet = null;
            // 用户ID
            string smsUid = "悠逸短信平台的注册账号：http://youe.smsadmin.cn/";
            // 用户密码
            string smsKey = "密码";
            // 接收短信的手机号码，多个号码用英文下的分号";"间隔，POST方式一次最多可提交1000个号码


            string smsMob  =mobile;
            //短信内容,支持长短信，最多350个字，长短信67个字/条计费
            string smsText = beizhu;
            Encoding encoding = System.Text.Encoding.GetEncoding("GB2312");
            string postData = string.Format("uid={0}&pwd={1}&mobile={2}&msg={3}&dtime=", smsUid, smsKey, smsMob, smsText);
            byte[] data = encoding.GetBytes(postData);
            // 定义 WebRequest
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("http://www.smsadmin.cn/smsmarketing/wwwroot/api/post_send/");
            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = data.Length;
            Stream newStream = myRequest.GetRequestStream();
            //发送数据
            newStream.Write(data, 0, data.Length);
            newStream.Close();
            // 得到 Response
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.Default);
            string content = reader.ReadToEnd();
            string result = content.Substring(0, 1);
            if (result == "0")
            {
                strRet = "短信发送成功！";
            }
            else if (result == "1")
            {
                strRet = "用户名或密码错误！";
            }
            else if (result == "2")
            {
                strRet = "账号余额不足！";
            }
            else if (result == "3")
            {
                strRet = "超过发送最大量！";
            }
            else if (result == "4")
            {
                strRet = "此用户不允许发送！";
            }
            else if (result == "5")
            {
                strRet = "手机号码或短信内容为空！";
            }
            else if (result == "7")
            {
                strRet = "短信内容超长！";
            }
            else if (result == "8")
            {
                strRet = "用户被冻结！";
            }
            else
            {
                strRet = content;
            }
            return strRet;
        }
 
        #endregion

        protected void Buttonfs_Click1(object sender, EventArgs e)
        {

            string mobile = GetSelectedDataKey(Grid1, 1);
            string beizhu = GetSelectedDataKey(Grid1, 2);
            string responseResults = frmTABLE_LXR.SmsSend(mobile , beizhu);
            Alert.Show(responseResults);

        }

        protected void Button2_Click(object sender, EventArgs e)//查询
        {
            BindGrid();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            this.txtName.Text = "";
            this.txtMobile.Text = "";
            BindGrid();

        }
    }
}