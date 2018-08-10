using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using FineUI;


namespace XASYU.admin
{
    public partial class config : PageBase
    {
        #region ViewPower

        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "CoreConfigView";
            }
        }

        #endregion

        #region 定义对象
        private XASYU.MODEL.SYS_CONFIGSModel ConfigModel = new MODEL.SYS_CONFIGSModel();
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
            CheckPowerWithButton("CoreConfigEdit", btnSave);


            tbxTitle.Text = PageBase.Title;
            nbxPageSize.Text = PageBase.PageSize.ToString();
            tbxHelpList.Text = StringUtil.GetJSBeautifyString(PageBase.HelpList);
            ddlMenuType.SelectedValue = PageBase.MenuType;
            ddlTheme.SelectedValue = PageBase.Theme;

        }

        #endregion

        #region Events

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            // 在操作之前进行权限检查
            if (!CheckPower("CoreConfigEdit"))
            {
                CheckPowerFailWithAlert();
                return;
            }

            string helpListStr = tbxHelpList.Text.Trim();
            try
            {
                JArray.Parse(helpListStr);
            }
            catch (Exception)
            {
                tbxHelpList.MarkInvalid("格式不正确，必须是JSON字符串！");

                return;
            }

            string New_Title = tbxTitle.Text.Trim();
            int New_PageSize = Convert.ToInt32(nbxPageSize.Text.Trim());
            string New_HelpList = helpListStr;
            string New_MenuType = ddlMenuType.SelectedValue;
            string New_Theme = ddlTheme.SelectedValue;
            string strTitleWhere = "ConfigKey='Title'";
            string strPageSizeWhere = "ConfigKey='PageSize'";
            string strHelpListWhere = "ConfigKey='HelpList'";
            string strMenuTypeWhere = "ConfigKey='MenuType'";
            string strThemeWhere = "ConfigKey='Theme'";
            Common.UpdateTable("sys_Configs", new string[] { "ConfigValue" }, new string[,] { { "" + New_Title + "", "1" } }, strTitleWhere);
            Common.UpdateTable("sys_Configs", new string[] { "ConfigValue" }, new string[,] { { "" + New_PageSize + "", "0" } }, strPageSizeWhere);
            Common.UpdateTable("sys_Configs", new string[] { "ConfigValue" }, new string[,] { { "" + New_HelpList + "", "1" } }, strHelpListWhere);
            Common.UpdateTable("sys_Configs", new string[] { "ConfigValue" }, new string[,] { { "" + New_MenuType + "", "1" } }, strMenuTypeWhere);
            Common.UpdateTable("sys_Configs", new string[] { "ConfigValue" }, new string[,] { { "" + New_Theme + "", "1" } }, strThemeWhere); 

            PageContext.RegisterStartupScript("top.window.location.reload(false);");
        }

        #endregion
    }
}
