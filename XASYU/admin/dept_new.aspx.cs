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
    public partial class dept_new : PageBase
    {
        #region ViewPower

        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "CoreDeptNew";
            }
        }

        #endregion

        #region 初始化变量
        private DeptHelper depHelp = new DeptHelper();
        private XASYU.MODEL.SYS_DEPTSModel DeptModel = new MODEL.SYS_DEPTSModel();      
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

            BindDDL();
        }

        private void BindDDL()
        {
            
            List<SYS_DEPTSModel> depts = ResolveDDL<SYS_DEPTSModel>(depHelp.Depts);

            // 绑定到下拉列表（启用模拟树功能）
            ddlParent.EnableSimulateTree = true;
            ddlParent.DataTextField = "Name";
            ddlParent.DataValueField = "ID";
            ddlParent.DataSimulateTreeLevelField = "TreeLevel";
            ddlParent.DataSource = depts;
            ddlParent.DataBind();

            // 选中根节点
            ddlParent.SelectedValue = "0";
        }

        #endregion

        #region Events

        private void SaveItem()
        {
            DeptModel.Name = tbxName.Text.Trim();
            DeptModel.SortIndex = Convert.ToInt32(tbxSortIndex.Text.Trim());
            DeptModel.Remark = tbxRemark.Text.Trim();
            DeptModel.DeptLeader = tbxDeptLeader.Text.Trim();
            DeptModel.DeptTel = tbxDeptTel.Text.Trim();
            int parentID = Convert.ToInt32(ddlParent.SelectedValue);
            if (parentID == -1)
            {
                DeptModel.Parent = null;
            }
            else
            {
                //Dept dept = Attach<Dept>(parentID);
                DeptModel.ParentID = parentID;
            }
            DeptModel.OpType = DataOperationType.Add;
            //XASYU.BLL.DataBaseManager.op_SYS_DEPTS(userBean, DeptModel);
            if (XASYU.BLL.DataBaseManager.op_SYS_DEPTS(userBean, DeptModel) == 0)
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
            //depHelp.Reload();
            //DeptHelper.Reload();

            //Alert.Show("添加成功！", String.Empty, ActiveWindow.GetHidePostBackReference());
            //PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        #endregion

    }
}
