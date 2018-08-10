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
    public partial class dept_edit : PageBase
    {
        #region ViewPower

        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "CoreDeptEdit";
            }
        }

        #endregion

        #region 定义变量
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

            int id = GetQueryIntValue("id");
            SYS_DEPTSModel current = depHelp.Depts.Where(d => d.ID == id).FirstOrDefault();
            if (current == null)
            {
                // 参数错误，首先弹出Alert对话框然后关闭弹出窗口
                Alert.Show("参数错误！", String.Empty, ActiveWindow.GetHideReference());
                return;
            }
            tbxDeptLeader.Text = current.DeptLeader;
            tbxDeptTel.Text = current.DeptTel;
            tbxName.Text = current.Name;
            tbxSortIndex.Text = current.SortIndex.ToString();
            tbxRemark.Text = current.Remark;

            // 绑定下拉列表
            BindDDL(current);
        }

        private void BindDDL(SYS_DEPTSModel current)
        {
            List<SYS_DEPTSModel> mys = ResolveDDL<SYS_DEPTSModel>(depHelp.Depts, current.ID);
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
            DeptModel.ID = id;
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
                DeptModel.ParentID = parentID;
            }
            DeptModel.OpType = DataOperationType.Modify;
            if (XASYU.BLL.DataBaseManager.op_SYS_DEPTS(userBean, DeptModel) == 0)
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
