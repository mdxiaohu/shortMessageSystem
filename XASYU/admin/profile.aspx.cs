using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FineUI;
using System.Linq;
using System.Data;

namespace XASYU.admin
{
    public partial class profile : PageBase
    {
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

        }

        #endregion

        #region 定义对象
        int V_ITOTALCOUNT = -1;
        private XASYU.MODEL.SYS_USERSModel UserModel = new MODEL.SYS_USERSModel();
        CykjSoft.Bean.UserBean userBean = new CykjSoft.Bean.UserBean();
        #endregion

        #region Events

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            // 检查当前密码是否正确
            string oldPass = tbxOldPassword.Text.Trim();
            string newPass = tbxNewPassword.Text.Trim();
            string confirmNewPass = tbxConfirmNewPassword.Text.Trim();

            if (newPass != confirmNewPass)
            {
                tbxConfirmNewPassword.MarkInvalid("确认密码和新密码不一致！");
                return;
            }

            UserModel.ID = int.Parse(getUserID(GetIdentityName()));
            DataSet ds = XASYU.BLL.DataBaseQuery.query_SYS_USERS(userBean, UserModel, ref  V_ITOTALCOUNT, 0, 20);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                if (!PasswordUtil.ComparePasswords(ds.Tables[0].Rows[0]["Password"].ToString(), oldPass))
                {
                    tbxOldPassword.MarkInvalid("当前密码不正确！");
                    return;
                }
                string NewPassword = PasswordUtil.CreateDbPassword(newPass);
                string strWhere = "ID=" + UserModel.ID;
                if (Common.UpdateTable("sys_Users", new string[] { "Password" }, new string[,] { { "" + NewPassword + "", "1" } }, strWhere) == 0)
                {
                    Alert.ShowInTop("修改密码成功！");
                }
                else
                {
                    Alert.ShowInTop("修改密码失败！");
                }
            }
 
        }

        #endregion

    }
}
