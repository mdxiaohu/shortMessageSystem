using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using FineUI;
using XASYU.MODEL;
using CykjSoft.UserPermissionManager.Utils;


namespace XASYU.admin
{
    public partial class menu_new : PageBase
    {
        #region ViewPower

        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "CoreMenuNew";
            }
        }

        #endregion

        #region 定义对象
        private MenuHelper menuHelp = new MenuHelper();
        private XASYU.MODEL.SYS_MENUSModel menusModel = new MODEL.SYS_MENUSModel();
        private XASYU.MODEL.SYS_POWERSModel PowerModel = new SYS_POWERSModel();
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

            //// 模块名称列表
            //ddlModules.DataSource = ModuleTypeHelper.GetAppModules();
            //ddlModules.DataBind();

            //ddlModules.SelectedValue = ModuleTypeHelper.Module2String(ModuleType.None);

            BindDDL();

            InitIconList(iconList);
        }

        public void InitIconList(FineUI.RadioButtonList iconList)
        {
            string[] icons = new string[] { "tag_yellow", "tag_red", "tag_purple", "tag_pink", "tag_orange", "tag_green", "tag_blue" };
            foreach (string icon in icons)
            {
                string value = String.Format("~/res/icon/{0}.png", icon);
                string text = String.Format("<img style=\"vertical-align:bottom;\" src=\"{0}\" />&nbsp;{1}", ResolveUrl(value), icon);

                iconList.Items.Add(new RadioItem(text, value));
            }
        }

        private void BindDDL()
        {
            List<SYS_MENUSModel> menus = ResolveDDL<SYS_MENUSModel>(menuHelp.Menus);

            // 绑定到下拉列表（启用模拟树功能）
            ddlParent.EnableSimulateTree = true;
            ddlParent.DataTextField = "Name";
            ddlParent.DataValueField = "ID";
            ddlParent.DataSimulateTreeLevelField = "TreeLevel";
            ddlParent.DataSource = menus;
            ddlParent.DataBind();

            // 选中根节点
            ddlParent.SelectedValue = "0";
        }

        #endregion

        #region Events

        private void SaveItem()
        {
            menusModel.Name = tbxName.Text.Trim();
            menusModel.NavigateUrl = tbxUrl.Text.Trim();
            menusModel.SortIndex = Convert.ToInt32(tbxSortIndex.Text.Trim());
            menusModel.Remark = tbxRemark.Text.Trim();
            menusModel.ImageUrl = tbxIcon.Text.Trim();

            int parentID = Convert.ToInt32(ddlParent.SelectedValue);
            if (parentID == -1)
            {
                menusModel.Parent = null;
            }
            else
            {
                menusModel.ParentID = parentID;
            }

            string viewPowerName = tbxViewPower.Text.Trim();
            if (String.IsNullOrEmpty(viewPowerName))
            {
                menusModel.ViewPower = null;
            }
            else
            {
                menusModel.ViewPowerID=getPowerID(viewPowerName);
            }
            menusModel.OpType = DataOperationType.Add;
            if (XASYU.BLL.DataBaseManager.op_SYS_MENUS(userBean, menusModel) == 0)
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
