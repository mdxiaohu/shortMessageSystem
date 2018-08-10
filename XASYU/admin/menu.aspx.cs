using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using FineUI;
using XASYU.MODEL;
using CykjSoft.UserPermissionManager.Utils;
using System.Data;


namespace XASYU.admin
{
    public partial class menu : PageBase
    {
        #region ViewPower

        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "CoreMenuView";
            }
        }

        #endregion

        #region 定义对象
        private MenuHelper menuHelp = new MenuHelper();
        private XASYU.MODEL.SYS_MENUSModel menusModel=new MODEL.SYS_MENUSModel();
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
            CheckPowerWithButton("CoreMenuNew", btnNew);


            btnNew.OnClientClick = Window1.GetShowReference("~/admin/menu_new.aspx", "新增菜单");


            BindGrid();
        }

        private void BindGrid()
        {
            List<SYS_MENUSModel> menus = menuHelp.Menus;
            Grid1.DataSource = menus;
            Grid1.DataBind();
        }


        protected string GetModuleName(object moduleNameObj)
        {
            string moduleName = moduleNameObj.ToString();
            if (moduleName == "None")
            {
                return String.Empty;
            }
            return moduleName;
        }

        #endregion

        #region Events

        protected void Grid1_PreDataBound(object sender, EventArgs e)
        {
            // 数据绑定之前，进行权限检查
            CheckPowerWithWindowField("CoreMenuEdit", Grid1, "editField");
            CheckPowerWithLinkButtonField("CoreMenuDelete", Grid1, "deleteField");
        }


        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            int menuID = GetSelectedDataKeyID(Grid1);

            if (e.CommandName == "Delete")
            {
                // 在操作之前进行权限检查
                if (!CheckPower("CoreMenuDelete"))
                {
                    CheckPowerFailWithAlert();
                    return;
                }

                int VL_ITOTALCOUNT = -1;
                int VL_SSTARTINDEX = 0;
                int VL_SPERPAGESIZE = 20;
                menusModel.ParentID = menuID;
                DataSet ds1 = XASYU.BLL.DataBaseQuery.query_SYS_MENUS(userBean, menusModel, ref  VL_ITOTALCOUNT, VL_SSTARTINDEX, VL_SPERPAGESIZE);
                if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0] != null && ds1.Tables[0].Rows.Count > 0)
                {
                    Alert.ShowInTop("删除失败！请先删除子菜单！");
                    return;
                }
                menusModel.ID = menuID;
                menusModel.OpType = DataOperationType.Delete;
                XASYU.BLL.DataBaseManager.op_SYS_MENUS(userBean, menusModel);

                menuHelp.Reload();
                BindGrid();
            }
        }

        protected void Window1_Close(object sender, EventArgs e)
        {
            menuHelp.Reload();
            BindGrid();
        }

        #endregion

    }
}
