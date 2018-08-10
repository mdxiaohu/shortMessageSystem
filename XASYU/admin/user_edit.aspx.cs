using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CykjSoft.UserPermissionManager.Utils;
using FineUI;
using XASYU.MODEL;

namespace XASYU.admin
{
    public partial class user_edit : PageBase
    {
        #region ViewPower

        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "CoreUserEdit";
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

        #region 页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    LoadData();
                    //  初始化学历、学位、政治面貌、民族
                    Common.BindDropDownList(this.ddlNation, "sys_Dic", "Dic_NAME", "Dic_CODE", "Dic_DM='MZ'");
                    Common.BindDropDownList(this.ddlXL, "sys_Dic", "Dic_NAME", "Dic_CODE", "Dic_DM='XL'");
                    Common.BindDropDownList(this.ddlXW, "sys_Dic", "Dic_NAME", "Dic_CODE", "Dic_DM='XW'");
                    Common.BindDropDownList(this.ddlPolitical, "sys_Dic", "Dic_NAME", "Dic_CODE", "Dic_DM='ZZMM'");
                }
                catch (Exception ex)
                {
                    Alert.ShowInTop(ex.Message);
                }
            }
        }
        #endregion

        #region LoadData
        private void LoadData()
        {
            int V_ITOTALCOUNT = -1;
            int V_SSTARTINDEX = 0;
            int V_SPERPAGESIZE = 20;

            btnClose.OnClientClick = ActiveWindow.GetHideReference();
            int id = GetQueryIntValue("id");
            UserModel.ID = id;
            UserModel.StartDate = DateTime.Parse("1900-01-01");
            UserModel.EndDate = DateTime.Now;
            DataSet ds = XASYU.BLL.DataBaseQuery.query_SYS_USERS(userBean, UserModel, ref  V_ITOTALCOUNT, V_SSTARTINDEX, V_SPERPAGESIZE);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Name"].ToString() == "admin" && GetIdentityName() != "admin")
                {
                    Alert.Show("你无权编辑超级管理员！", String.Empty, ActiveWindow.GetHideReference());
                    return;
                }
                //labUserName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                //labUserRealName.Text = ds.Tables[0].Rows[0]["ChineseName"].ToString();
                labName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                UserModel.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                tbxRealName.Text = ds.Tables[0].Rows[0]["ChineseName"].ToString();
                UserModel.ChineseName = ds.Tables[0].Rows[0]["ChineseName"].ToString();
                //tbxCompanyEmail.Text = current.CompanyEmail;
                tbxEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                UserModel.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                tbxCellPhone.Text = ds.Tables[0].Rows[0]["CellPhone"].ToString();
                UserModel.CellPhone = ds.Tables[0].Rows[0]["CellPhone"].ToString();
                tbxOfficePhone.Text = ds.Tables[0].Rows[0]["OfficePhone"].ToString();
                UserModel.OfficePhone = ds.Tables[0].Rows[0]["OfficePhone"].ToString();
                //tbxOfficePhoneExt.Text = current.OfficePhoneExt;
                //tbxHomePhone.Text = current.HomePhone;
                tbxRemark.Text = ds.Tables[0].Rows[0]["Remark"].ToString();
                UserModel.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                cbxEnabled.Checked = bool.Parse(ds.Tables[0].Rows[0]["Enabled"].ToString());
                UserModel.Enabled = bool.Parse(ds.Tables[0].Rows[0]["Enabled"].ToString());
                ddlGender.SelectedValue = ds.Tables[0].Rows[0]["Gender"].ToString();
                UserModel.Gender = ds.Tables[0].Rows[0]["Gender"].ToString();

                this.txtPosion.Text = ds.Tables[0].Rows[0]["ZhiWu"].ToString();
                UserModel.ZhiWu = ds.Tables[0].Rows[0]["ZhiWu"].ToString();
                this.ddlXL.SelectedValue = ds.Tables[0].Rows[0]["XueLi"].ToString();
                UserModel.XueLi = ds.Tables[0].Rows[0]["XueLi"].ToString();
                this.ddlXW.SelectedValue = ds.Tables[0].Rows[0]["XueWei"].ToString();
                UserModel.XueWei = ds.Tables[0].Rows[0]["XueWei"].ToString();
                this.ddlPolitical.SelectedValue = ds.Tables[0].Rows[0]["Political"].ToString();
                UserModel.Political = ds.Tables[0].Rows[0]["Political"].ToString();
                this.txtYjfx.Text = ds.Tables[0].Rows[0]["YjFx"].ToString();
                UserModel.YjFx = ds.Tables[0].Rows[0]["YjFx"].ToString();
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Birthday"].ToString()))
                {
                    UserModel.Birthday = DateTime.Parse(ds.Tables[0].Rows[0]["Birthday"].ToString());
                    this.date_stu_birth.SelectedDate = DateTime.Parse(ds.Tables[0].Rows[0]["Birthday"].ToString());
                }
                this.ddlNation.SelectedValue = ds.Tables[0].Rows[0]["Nation"].ToString();
                UserModel.Nation = ds.Tables[0].Rows[0]["Nation"].ToString();
                this.txtQQ.Text = ds.Tables[0].Rows[0]["QQ"].ToString();
                UserModel.QQ = ds.Tables[0].Rows[0]["QQ"].ToString();
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["DeptID"].ToString()))
                {
                    UserModel.DeptID = int.Parse(ds.Tables[0].Rows[0]["DeptID"].ToString());
                }
                this.hidPassword.Text = ds.Tables[0].Rows[0]["Password"].ToString();
            }
            else
            {
                // 参数错误，首先弹出Alert对话框然后关闭弹出窗口
                Alert.Show("参数错误！", String.Empty, ActiveWindow.GetHideReference());
                return;
            }

            // 初始化用户所属角色
            InitUserRole(UserModel);

            // 初始化用户所属部门
            InitUserDept(UserModel);

            // 初始化用户所属职称
            InitUserTitle(UserModel);
        }
        #endregion

        #region InitUserRole

        private void InitUserDept(SYS_USERSModel TempUserModel)
        {
            if (TempUserModel.DeptID != 0)
            {
                tbSelectedDept.Text = getDeptName(int.Parse(TempUserModel.DeptID.ToString()));
                hfSelectedDept.Text = TempUserModel.DeptID.ToString();
            }

            // 打开编辑窗口
            string selectDeptURL = String.Format("./user_select_dept.aspx?ids=<script>{0}</script>", hfSelectedDept.GetValueReference());
            tbSelectedDept.OnClientTriggerClick = Window1.GetSaveStateReference(hfSelectedDept.ClientID, tbSelectedDept.ClientID)
                    + Window1.GetShowReference(selectDeptURL, "选择用户所属的部门");

        }

        #endregion

        #region InitUserRole

        private void InitUserRole(SYS_USERSModel TempUserModel)
        {
            getRoleName(TempUserModel.ID);
            tbSelectedRole.Text = roleNAMEs;
            hfSelectedRole.Text = roleIDs;

            // 打开编辑角色的窗口
            string selectRoleURL = String.Format("./user_select_role.aspx?ids=<script>{0}</script>", hfSelectedRole.GetValueReference());
            tbSelectedRole.OnClientTriggerClick = Window1.GetSaveStateReference(hfSelectedRole.ClientID, tbSelectedRole.ClientID)
                    + Window1.GetShowReference(selectRoleURL, "选择用户所属的角色");

        }
        #endregion

        #region InitUserTitle

        private void InitUserTitle(SYS_USERSModel TempUserModel)
        {
            getTitleName(TempUserModel.ID);      
            tbSelectedTitle.Text = TitleNames;
            hfSelectedTitle.Text = TitleIDs;

            // 打开编辑角色的窗口
            string selectTitleURL = String.Format("./user_select_title.aspx?ids=<script>{0}</script>", hfSelectedTitle.GetValueReference());
            tbSelectedTitle.OnClientTriggerClick = Window1.GetSaveStateReference(hfSelectedTitle.ClientID, tbSelectedTitle.ClientID)
                    + Window1.GetShowReference(selectTitleURL, "选择用户拥有的职称");

        }
        #endregion


        #endregion

        #region Events

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
                    roleNameList.Add(ds.Tables[0].Rows[i]["RoleName"].ToString());
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
                    titleNameList.Add(ds.Tables[0].Rows[i]["TitleName"].ToString());
                }
                TitleIDs = String.Join(",", titleIdlist);
                TitleNames = String.Join(",", titleNameList);
            }

        }
        #endregion

        #region SaveItem
        /*首先更新基本信息表User中的信息，然后更新角色用户表RolesUser和职称用户表TitleUser*/
        private void SaveItem()
        {
            int id = GetQueryIntValue("id");
            UserModel.ID = id;
            UserModel.Name = labName.Text.Trim();
            //UserModel.Password = PasswordUtil.CreateDbPassword(tbxPassword.Text.Trim());
            UserModel.ChineseName = tbxRealName.Text.Trim();
            UserModel.Gender = ddlGender.SelectedValue;
            //item.CompanyEmail = tbxCompanyEmail.Text.Trim();
            UserModel.Email = tbxEmail.Text.Trim();
            UserModel.OfficePhone = tbxOfficePhone.Text.Trim();
            UserModel.Nation = this.ddlNation.SelectedValue;
            //.OfficePhoneExt = tbxOfficePhoneExt.Text.Trim();
            //item.HomePhone = tbxHomePhone.Text.Trim();
            UserModel.CellPhone = tbxCellPhone.Text.Trim();
            UserModel.Remark = tbxRemark.Text.Trim();
            UserModel.Enabled = cbxEnabled.Checked;
            UserModel.CreateTime = DateTime.Now;
            UserModel.ZhiWu = this.txtPosion.Text.Trim();
            UserModel.XueLi = this.ddlXL.SelectedValue.ToString();
            UserModel.XueWei = this.ddlXW.SelectedValue.ToString();
            UserModel.Political = this.ddlPolitical.SelectedValue.ToString();
            UserModel.YjFx = this.txtYjfx.Text.Trim();
            UserModel.Birthday = DateTime.Parse(this.date_stu_birth.Text.ToString());
            UserModel.QQ = this.txtQQ.Text.Trim();
            UserModel.Password = this.hidPassword.Text.Trim();

            // 选择部门
            if (!String.IsNullOrEmpty(hfSelectedDept.Text))
            {
                int deptID = Convert.ToInt32(hfSelectedDept.Text);
                UserModel.DeptID = deptID;
            }
            UserModel.OpType = DataOperationType.Modify;

            //更新基本信息User表
            XASYU.BLL.DataBaseManager.op_SYS_USERS(userBean, UserModel);

            //更新角色信息，思路是通过先删除原有角色信息，后增加新的角色信息实现
            //否则，由于表设计是多对多关联，使用常规修改情况很复杂。
            if (!String.IsNullOrEmpty(hfSelectedRole.Text))
            {
                RoleUserModel.UserID = id;
                RoleUserModel.OpType = DataOperationType.Delete;
                //将RoleUser表中的以前角色删除
                XASYU.BLL.DataBaseManager.op_SYS_ROLEUSERS(userBean, RoleUserModel);

                //将新的角色信息添加到RoleUser表中
                int[] NEW_roleIDs = StringUtil.GetIntArrayFromString(hfSelectedRole.Text);   
                for (int i = 0; i < NEW_roleIDs.Length; i++)
                    {
                        RoleUserModel.UserID = id;
                        RoleUserModel.RoleID = NEW_roleIDs[i];
                        RoleUserModel.OpType = DataOperationType.Add;
                        //将角色信息添加入RoleUser表中
                        XASYU.BLL.DataBaseManager.op_SYS_ROLEUSERS(userBean, RoleUserModel);
                    }
            }

            // 修改职称,将信息添加到TitleUsers表中
            if (!String.IsNullOrEmpty(hfSelectedTitle.Text))
            {
                TitleUserModel.UserID = id;
                TitleUserModel.OpType = DataOperationType.Delete;
                ////将TitleUser表中的以前职称删除
                XASYU.BLL.DataBaseManager.op_SYS_TITLEUSERS(userBean, TitleUserModel);

                int[] NEW_titleIDs = StringUtil.GetIntArrayFromString(hfSelectedTitle.Text);
                for (int i = 0; i < NEW_titleIDs.Length; i++)
                    {
                        TitleUserModel.UserID = id;
                        TitleUserModel.TitleID = NEW_titleIDs[i];
                        TitleUserModel.OpType = DataOperationType.Add;
                        //将基本信息添加入TitleUser表中
                        XASYU.BLL.DataBaseManager.op_SYS_TITLEUSERS(userBean, TitleUserModel);
                    }
            }
        }
        #endregion

        #region 保存关闭事件
        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            try
            {
                SaveItem();
                Alert.Show("编辑成功！", String.Empty, ActiveWindow.GetHidePostBackReference());
                //PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
            catch (Exception ex)
            {
                Alert.ShowInTop(ex.Message);
            }
        }
        #endregion

        #endregion

    }
}
