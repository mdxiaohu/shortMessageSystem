using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Text;
using System.Linq;
using System.Data;
using XASYU.MODEL;

namespace XASYU.admin
{
    public partial class user_view : PageBase
    {
        #region ViewPower

        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "CoreUserView";
            }
        }

        #endregion

        #region 初始化变量
        string roleIDs = String.Empty;
        string roleNAMEs = String.Empty;
        string TitleIDs = String.Empty;
        string TitleNames = String.Empty;
        private XASYU.MODEL.SYS_USERSModel UserModel = new MODEL.SYS_USERSModel();
        private XASYU.MODEL.SYS_DEPTSModel DeptModel = new MODEL.SYS_DEPTSModel();
        private XASYU.MODEL.SYS_ROLEUSERSModel RoleUserModel = new MODEL.SYS_ROLEUSERSModel();
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

            int id = GetQueryIntValue("id");
            
            int V_ITOTALCOUNT = -1;
            int V_SSTARTINDEX = 0;
            int V_SPERPAGESIZE = 20;

            UserModel.ID = id;
            UserModel.StartDate = DateTime.Parse("1900-01-01");
            UserModel.EndDate = DateTime.Now;
            DataSet ds = XASYU.BLL.DataBaseQuery.query_SYS_USERS(userBean, UserModel, ref  V_ITOTALCOUNT, V_SSTARTINDEX, V_SPERPAGESIZE);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {

                labName.Text = ds.Tables[0].Rows[0]["Name"].ToString(); ;
                labRealName.Text = ds.Tables[0].Rows[0]["ChineseName"].ToString(); 
                labCompanyEmail.Text = ds.Tables[0].Rows[0]["CompanyEmail"].ToString();
                labEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString(); ;
                labCellPhone.Text = ds.Tables[0].Rows[0]["CellPhone"].ToString();
                labOfficePhone.Text = ds.Tables[0].Rows[0]["OfficePhone"].ToString();
                labOfficePhoneExt.Text = ds.Tables[0].Rows[0]["OfficePhoneExt"].ToString();
                labHomePhone.Text = ds.Tables[0].Rows[0]["HomePhone"].ToString();
                labRemark.Text = ds.Tables[0].Rows[0]["Remark"].ToString();
                labEnabled.Text =bool.Parse(ds.Tables[0].Rows[0]["Enabled"].ToString()) ? "启用" : "禁用";
                labGender.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["DeptID"].ToString()))
                {
                    UserModel.DeptID = int.Parse(ds.Tables[0].Rows[0]["DeptID"].ToString());
                }

            }

            // 用户所属角色
            InitUserRole(UserModel);

            // 用户所属部门
            InitUserDept(UserModel);

            // 用户所属职称
            InitUserTitle(UserModel);

        }

        #region InitUserRole

        private void InitUserDept(SYS_USERSModel TempUserModel)
        {
            if (TempUserModel.DeptID != 0)
            {
                labDept.Text = getDeptName(int.Parse(TempUserModel.DeptID.ToString()));
            }

        }

        #endregion

        #region InitUserRole

        private void InitUserRole(SYS_USERSModel TempUserModel)
        {
            getRoleName(TempUserModel.ID);
            labRole.Text = roleNAMEs;   
        }
        #endregion

        #region InitUserTitle

        private void InitUserTitle(SYS_USERSModel TempUserModel)
        {
            getTitleName(TempUserModel.ID);
            labTitle.Text = TitleNames; 
        }
        #endregion

        #region 根据部门ID查找单位部门名称
        protected string getDeptName(int DeptID)
        {
            int V_ITOTALCOUNT = -1;
            int V_SSTARTINDEX = 0;
            int V_SPERPAGESIZE = 1000;
            string DeptName = "";

            DeptModel.ID = DeptID;
            DeptModel.StartDate = DateTime.Parse("1900-01-01");
            DeptModel.EndDate = DateTime.Now;
            DataTable table = new DataTable();
            DataSet ds = XASYU.BLL.DataBaseQuery.query_SYS_DEPTS(userBean, DeptModel, ref  V_ITOTALCOUNT, V_SSTARTINDEX, V_SPERPAGESIZE);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                DeptName = ds.Tables[0].Rows[0]["Name"].ToString();
            }
            return DeptName;
        }
        #endregion

        #region 根据用户ID查找角色名称
        protected void getRoleName(int userID)
        {
            int V_ITOTALCOUNT = -1;
            int V_SSTARTINDEX = 0;
            int V_SPERPAGESIZE = 1000;

            List<string> rolelist = new List<string>();//用户角色roleID取值，存放于roleList中         
            List<string> roleNameList = new List<string>();//用户角色roleName取值
            RoleUserModel.UserID = userID;
            RoleUserModel.StartDate = DateTime.Parse("1900-01-01");
            RoleUserModel.EndDate = DateTime.Now;
            DataSet ds = XASYU.BLL.DataBaseQuery.query_SYS_ROLEUSERS(userBean, RoleUserModel, ref  V_ITOTALCOUNT, V_SSTARTINDEX, V_SPERPAGESIZE);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    rolelist.Add(ds.Tables[0].Rows[i]["RoleID"].ToString());
                    roleNameList.Add(ds.Tables[0].Rows[i]["Name"].ToString());
                }
                roleIDs = String.Join(",", rolelist);
                roleNAMEs = String.Join(",", roleNameList);
            }

        }
        #endregion

        #region 根据用户ID查找职称名称
        protected void getTitleName(int userID)
        {
            int V_ITOTALCOUNT = -1;
            int V_SSTARTINDEX = 0;
            int V_SPERPAGESIZE = 1000;

            List<string> titleIdlist = new List<string>();//用户职称ID取值，存放于roleList中         
            List<string> titleNameList = new List<string>();//用户职称Name取值
            TitleUserModel.UserID = userID;
            TitleUserModel.StartDate = DateTime.Parse("1900-01-01");
            TitleUserModel.EndDate = DateTime.Now;
            DataSet ds = XASYU.BLL.DataBaseQuery.query_SYS_TITLEUSERS(userBean, TitleUserModel, ref  V_ITOTALCOUNT, V_SSTARTINDEX, V_SPERPAGESIZE);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    titleIdlist.Add(ds.Tables[0].Rows[i]["TitleID"].ToString());
                    titleNameList.Add(ds.Tables[0].Rows[i]["Name"].ToString());
                }
                TitleIDs = String.Join(",", titleIdlist);
                TitleNames = String.Join(",", titleNameList);
            }

        }
        #endregion
        
        #endregion

    }
}
