using System;
using System.Web;
using System.Web.Security;

using FineUI;
using System.Text;
using System.Linq;
using System.Data;
using System.Collections.Generic;

namespace XASYU
{
    public partial class frmLogin : PageBase
    {
        int V_ITOTALCOUNT = -1;
        int VL_ITOTALCOUNT = -1;
        int V_SSTARTINDEX = 0;
        int VL_SSTARTINDEX = 0;
        int V_SPERPAGESIZE = 1000;
        private XASYU.MODEL.SYS_USERSModel UserModel = new MODEL.SYS_USERSModel();
        private XASYU.MODEL.SYS_ROLEUSERSModel RoleUserModel = new MODEL.SYS_ROLEUSERSModel();
        CykjSoft.Bean.UserBean userBean = new CykjSoft.Bean.UserBean();
       
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
            // 如果用户已经登录，则重定向到管理首页
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect(FormsAuthentication.DefaultUrl);
            }

            //Window1.Title = String.Format("DaBaba-短信发送管理系统（v{0}）", GetProductVersion());

        }

        #endregion

        #region Events

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string userName = tbxUserName.Text.Trim();
            string password = tbxPassword.Text.Trim();
            UserModel.Name = userName;
            UserModel.StartDate = DateTime.Parse("1900-01-01");
            UserModel.EndDate = DateTime.Now;
            DataTable table = new DataTable();
            DataSet ds = XASYU.BLL.DataBaseQuery.query_SYS_USERS(userBean, UserModel, ref  V_ITOTALCOUNT, V_SSTARTINDEX, V_SPERPAGESIZE);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {

                if (PasswordUtil.ComparePasswords(ds.Tables[0].Rows[0]["Password"].ToString(), password))
                {
                    if (!bool.Parse(ds.Tables[0].Rows[0]["Enabled"].ToString()))
                    {
                        Response.Write("<script>alert('用户未启用，请联系管理员！')</script>");
                        //Alert.Show("用户未启用，请联系管理员！");
                    }
                    else
                    {
                         LoginSuccess(userName,int.Parse(ds.Tables[0].Rows[0]["ID"].ToString()));
                         return;
                        //Response.Write("<script>alert('登陆成功')</script>");
                        //Alert.Show("登陆成功");
                    }
                }
                else {
                    Response.Write("<script>alert('密码错误！')</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('用户名错误！')</script>");
            }

        }


        private void LoginSuccess(string userName,int userID)
        {
            RegisterOnlineUser(userID);//注册在线用户
            // 用户所属的角色字符串，以逗号分隔
            string roleIDs = String.Empty;
            List<string> rolelist = new List<string>();//用户角色roleID取值，存放于roleList中         
            RoleUserModel.UserID = userID;
            RoleUserModel.StartDate = DateTime.Parse("1900-01-01");
            RoleUserModel.EndDate = DateTime.Now;
            DataSet ds = XASYU.BLL.DataBaseQuery.query_SYS_ROLEUSERS(userBean, RoleUserModel, ref  VL_ITOTALCOUNT, VL_SSTARTINDEX, V_SPERPAGESIZE);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    rolelist.Add(ds.Tables[0].Rows[i]["RoleID"].ToString());
                }
                roleIDs = String.Join(",", rolelist);
                bool isPersistent = false;
                DateTime expiration = DateTime.Now.AddMinutes(120);
                CreateFormsAuthenticationTicket(userName, roleIDs, isPersistent, expiration);

                // 重定向到登陆后首页
                Response.Redirect(FormsAuthentication.DefaultUrl);
            }
        }


        #endregion
    }
}