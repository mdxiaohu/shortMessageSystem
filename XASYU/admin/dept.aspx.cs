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
    public partial class dept : PageBase
    {
        #region ViewPower

        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "CoreDeptView";
            }
        }

        #endregion

        #region 初始化变量 
        private DeptHelper depHelp = new DeptHelper();
        private XASYU.MODEL.SYS_DEPTSModel DeptModel = new MODEL.SYS_DEPTSModel();
        private XASYU.MODEL.SYS_USERSModel UserModel = new MODEL.SYS_USERSModel();
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
            CheckPowerWithButton("CoreDeptNew", btnNew);


            btnNew.OnClientClick = Window1.GetShowReference("~/admin/dept_new.aspx", "新增部门");

         
            BindGrid();
        }

        private void BindGrid()
        {
            try
            {
                Grid1.DataSource = depHelp.Depts;
                Grid1.DataBind();
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
        }

        #endregion

        #region Events

        protected void Grid1_PreDataBound(object sender, EventArgs e)
        {
            // 数据绑定之前，进行权限检查
            CheckPowerWithWindowField("CoreDeptEdit", Grid1, "editField");
            CheckPowerWithLinkButtonField("CoreDeptDelete", Grid1, "deleteField");
        }

        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            int deptID = GetSelectedDataKeyID(Grid1);

            if (e.CommandName == "Delete")
            {
                // 在操作之前进行权限检查
                if (!CheckPower("CoreDeptDelete"))
                {
                    CheckPowerFailWithAlert();
                    return;
                }
                int V_ITOTALCOUNT = -1;
                int V_SSTARTINDEX = 0;
                int V_SPERPAGESIZE = 20;
                UserModel.DeptID = deptID;
                DataSet ds = XASYU.BLL.DataBaseQuery.query_SYS_USERS(userBean, UserModel, ref  V_ITOTALCOUNT, V_SSTARTINDEX, V_SPERPAGESIZE);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    Alert.ShowInTop("删除失败！需要先清空属于此部门的用户！");
                        return;
                }

                int VL_ITOTALCOUNT = -1;
                int VL_SSTARTINDEX = 0;
                int VL_SPERPAGESIZE = 20;
                DeptModel.ParentID = deptID;
                DataSet ds1 = XASYU.BLL.DataBaseQuery.query_SYS_DEPTS(userBean, DeptModel, ref  VL_ITOTALCOUNT, VL_SSTARTINDEX, VL_SPERPAGESIZE);
                if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0] != null && ds1.Tables[0].Rows.Count > 0)
                {
                    Alert.ShowInTop("删除失败！请先删除子部门！");
                    return;
                }

                DeptModel.ID = deptID;
                DeptModel.OpType = DataOperationType.Delete;
                XASYU.BLL.DataBaseManager.op_SYS_DEPTS(userBean, DeptModel);
                depHelp.Reload();
                BindGrid();
            }
        }

        protected void Window1_Close(object sender, EventArgs e)
        {
            depHelp.Reload();
            BindGrid();
        }

     
        #endregion

    }
}
