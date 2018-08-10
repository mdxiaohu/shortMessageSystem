using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using FineUI;
using CykjSoft.UserPermissionManager.Utils;

namespace XASYU.admin
{
    public partial class title_new : PageBase
    {
        #region ViewPower

        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "CoreTitleNew";
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
                LoadData();
            }
        }

        private void LoadData()
        {
            btnClose.OnClientClick = ActiveWindow.GetHideReference();

        }

        #endregion

        #region Events

        private void SaveJobTitle()
        {
            try
            {
                TitleModel.Name = tbxName.Text.Trim();
                TitleModel.Remark = tbxRemark.Text.Trim();
                TitleModel.OpType = DataOperationType.Add;

                if (XASYU.BLL.DataBaseManager.op_SYS_TITLES(userBean, TitleModel) == 0)
                {
                    Alert.Show("添加成功！", String.Empty, ActiveWindow.GetHidePostBackReference());
                }
                else
                {
                    Alert.Show("添加失败！", String.Empty, ActiveWindow.GetHidePostBackReference());
                }
            }
            catch (Exception ex)
            {
                Alert.ShowInTop(ex.Message);
            }

           
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            SaveJobTitle();
            //Alert.Show("添加成功！", String.Empty, ActiveWindow.GetHidePostBackReference());
            //PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
        #endregion

    }
}

