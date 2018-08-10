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
    public partial class menu_edit : PageBase
    {
        #region ViewPower

        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "CoreMenuEdit";
            }
        }

        #endregion

        #region 定义对象
        private MenuHelper menuHelp = new MenuHelper();
        private XASYU.MODEL.SYS_MENUSModel menusModel = new MODEL.SYS_MENUSModel();
        private XASYU.MODEL.SYS_POWERSModel PowerModel = new MODEL.SYS_POWERSModel();
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

            int id = GetQueryIntValue("id");
            SYS_MENUSModel current = menuHelp.Menus
                .Where(m => m.ID == id).FirstOrDefault();
            if (current == null)
            {
                // 参数错误，首先弹出Alert对话框然后关闭弹出窗口
                Alert.Show("参数错误！", String.Empty, ActiveWindow.GetHideReference());
                return;
            }

            tbxName.Text = current.Name;
            tbxUrl.Text = current.NavigateUrl;
            tbxSortIndex.Text = current.SortIndex.ToString();
            tbxIcon.Text = current.ImageUrl;
            tbxRemark.Text = current.Remark;
            if (current.ViewPower != null)
            {
                tbxViewPower.Text = current.ViewPower.Name;
            }


            // 绑定上级菜单下拉列表
            BindDDL(current);

            // 预置图标列表
            InitIconList(iconList);

            if (!String.IsNullOrEmpty(current.ImageUrl))
            {
                iconList.SelectedValue = current.ImageUrl;
            }

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

        private void BindDDL(SYS_MENUSModel current)
        {
            List<SYS_MENUSModel> mys = ResolveDDL<SYS_MENUSModel>(menuHelp.Menus, current.ID);

            // 绑定到下拉列表（启用模拟树功能和不可选择项功能）
            ddlParent.EnableSimulateTree = true;
            ddlParent.DataTextField = "Name";
            ddlParent.DataValueField = "ID";
            ddlParent.DataSimulateTreeLevelField = "TreeLevel";
            ddlParent.DataEnableSelectField = "Enabled";
            ddlParent.DataSource = mys;
            ddlParent.DataBind();

            if (current.Parent != null)
            {
                // 选中当前节点的父节点
                ddlParent.SelectedValue = current.Parent.ID.ToString();
            }
        }

        #endregion

        #region Events

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            int id = GetQueryIntValue("id");
            menusModel.ID = id;
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
                menusModel.ViewPowerID = getPowerID(viewPowerName);
            }
            menusModel.OpType = DataOperationType.Modify;
            if (XASYU.BLL.DataBaseManager.op_SYS_MENUS(userBean, menusModel) == 0)
            {
                Alert.Show("编辑成功！", String.Empty, ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.Show("编辑失败！", String.Empty, ActiveWindow.GetHidePostBackReference());
            }

            //FineUI.Alert.Show("保存成功！", String.Empty, FineUI.Alert.DefaultIcon, FineUI.ActiveWindow.GetHidePostBackReference());
            //PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }


        #endregion

    }
}
