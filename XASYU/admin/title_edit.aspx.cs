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
    public partial class title_edit : PageBase
    {
        #region ViewPower

        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "CoreTitleEdit";
            }
        }

        #endregion

        #region 初始化变量
        private XASYU.MODEL.SYS_TITLESModel TitleModel = new MODEL.SYS_TITLESModel();
        private XASYU.MODEL.SYS_TITLEUSERSModel TitleUserModel = new MODEL.SYS_TITLEUSERSModel();
        CykjSoft.Bean.UserBean userBean = new CykjSoft.Bean.UserBean();
        #endregion

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    LoadData();
                }
                catch (Exception ex)
                {
                    Alert.ShowInTop(ex.Message);
                }
            }
        }

        private void LoadData()
        {
            btnClose.OnClientClick = ActiveWindow.GetHideReference();

            int id = GetQueryIntValue("id");
            int V_ITOTALCOUNT = -1;
            int V_SSTARTINDEX = 0;
            int V_SPERPAGESIZE = 20;
            TitleModel.ID = id;
            DataSet ds = XASYU.BLL.DataBaseQuery.query_SYS_TITLES(userBean, TitleModel, ref  V_ITOTALCOUNT, V_SSTARTINDEX, V_SPERPAGESIZE);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                tbxName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                tbxRemark.Text = ds.Tables[0].Rows[0]["Remark"].ToString(); ;
            }
            else
            {
                // 参数错误，首先弹出Alert对话框然后关闭弹出窗口
                Alert.Show("参数错误！", String.Empty, ActiveWindow.GetHideReference());
                return;
            }  
        }

     
        #endregion

        #region Events

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            try
            {
                int id = GetQueryIntValue("id");
                TitleModel.ID = id;
                TitleModel.Name = tbxName.Text.Trim();
                TitleModel.Remark = tbxRemark.Text.Trim();
                TitleModel.OpType = DataOperationType.Modify;

                if (XASYU.BLL.DataBaseManager.op_SYS_TITLES(userBean, TitleModel) == 0)
                {
                    Alert.Show("编辑成功！", String.Empty, ActiveWindow.GetHidePostBackReference());
                }
                else
                {
                    Alert.Show("编辑失败！", String.Empty, ActiveWindow.GetHidePostBackReference());
                }
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
            //FineUI.Alert.Show("保存成功！", String.Empty, FineUI.Alert.DefaultIcon, FineUI.ActiveWindow.GetHidePostBackReference());
            //PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        #endregion

    }
}
