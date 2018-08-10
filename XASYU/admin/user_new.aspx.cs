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
    public partial class user_new : PageBase
    {
        #region 初始化变量
        private XASYU.MODEL.SYS_USERSModel UserModel = new MODEL.SYS_USERSModel();
        private XASYU.MODEL.SYS_ROLEUSERSModel RoleUserModel = new MODEL.SYS_ROLEUSERSModel();
        private XASYU.MODEL.SYS_TITLEUSERSModel TitleUserModel = new MODEL.SYS_TITLEUSERSModel();
        CykjSoft.Bean.UserBean userBean = new CykjSoft.Bean.UserBean();
        #endregion

        #region ViewPower

        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "CoreUserNew";
            }
        }

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

            // 初始化用户所属角色
            InitUserRole();

            // 初始化用户所属部门
            InitUserDept();

            // 初始化用户所属职称
            InitUserTitle();

            //  初始化学历、学位、政治面貌、民族
            Common.BindDropDownList(this.ddlNation, "sys_Dic", "Dic_NAME", "Dic_CODE", "Dic_DM='MZ'");
            Common.BindDropDownList(this.ddlXL, "sys_Dic", "Dic_NAME", "Dic_CODE", "Dic_DM='XL'");
            Common.BindDropDownList(this.ddlXW, "sys_Dic", "Dic_NAME", "Dic_CODE", "Dic_DM='XW'");
            Common.BindDropDownList(this.ddlPolitical, "sys_Dic", "Dic_NAME", "Dic_CODE", "Dic_DM='ZZMM'");
        }
     #endregion

        #region InitUserRole

        private void InitUserDept()
        {
            // 打开编辑窗口
            string selectDeptURL = String.Format("./user_select_dept.aspx?ids=<script>{0}</script>", hfSelectedDept.GetValueReference());
            tbSelectedDept.OnClientTriggerClick = Window1.GetSaveStateReference(hfSelectedDept.ClientID, tbSelectedDept.ClientID)
                    + Window1.GetShowReference(selectDeptURL, "选择用户所属的部门");

        }

        #endregion

        #region InitUserRole
        private void InitUserRole()
        {
            // 打开编辑角色的窗口
            string selectRoleURL = String.Format("./user_select_role.aspx?ids=<script>{0}</script>", hfSelectedRole.GetValueReference());
            tbSelectedRole.OnClientTriggerClick = Window1.GetSaveStateReference(hfSelectedRole.ClientID, tbSelectedRole.ClientID)
                    + Window1.GetShowReference(selectRoleURL, "选择用户所属的角色");

        }
        #endregion

        #region InitUserJobTitle
        private void InitUserTitle()
        {
            // 打开编辑角色的窗口
            string selectJobTitleURL = String.Format("./user_select_title.aspx?ids=<script>{0}</script>", hfSelectedTitle.GetValueReference());
            tbSelectedTitle.OnClientTriggerClick = Window1.GetSaveStateReference(hfSelectedTitle.ClientID, tbSelectedTitle.ClientID)
                    + Window1.GetShowReference(selectJobTitleURL, "选择用户拥有的职称");

        }
        #endregion

        #endregion

        #region Events

        #region SaveItem
        private void SaveItem()
        {    
            UserModel.Name = tbxName.Text.Trim();
            UserModel.Password = PasswordUtil.CreateDbPassword(tbxPassword.Text.Trim());
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

            // 添加所有部门
            if (!String.IsNullOrEmpty(hfSelectedDept.Text))
            {
                int deptID = Convert.ToInt32(hfSelectedDept.Text);
                UserModel.DeptID = deptID;
            }
            UserModel.OpType = DataOperationType.Add;

           //将基本信息添加入User表中
            XASYU.BLL.DataBaseManager.op_SYS_USERS(userBean, UserModel);

            int UserID = int.Parse(getUserID(tbxName.Text.Trim()));
            // 添加所有角色，将信息添加到RoleUsers表中
            if (!String.IsNullOrEmpty(hfSelectedRole.Text))
            {
                int[] roleIDs = StringUtil.GetIntArrayFromString(hfSelectedRole.Text);
                    for (int i = 0; i < roleIDs.Length; i++)
                    {
                        RoleUserModel.UserID = UserID;
                        RoleUserModel.RoleID=roleIDs[i];
                        RoleUserModel.OpType = DataOperationType.Add;
                        //将基本信息添加入RoleUser表中
                        XASYU.BLL.DataBaseManager.op_SYS_ROLEUSERS(userBean, RoleUserModel);
                    }
    
            }

            // 添加所有职称,将信息添加到TitleUsers表中
            if (!String.IsNullOrEmpty(hfSelectedTitle.Text))
            {
                int[] titleIDs = StringUtil.GetIntArrayFromString(hfSelectedTitle.Text);   
                    for (int i = 0; i < titleIDs.Length; i++)
                    {
                        TitleUserModel.UserID = UserID;
                        TitleUserModel.TitleID = titleIDs[i];
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
                string inputUserName = tbxName.Text.Trim();
                int V_ITOTALCOUNT = -1;
                int V_SSTARTINDEX = 0;
                int V_SPERPAGESIZE = 1000;
                UserModel.Name = tbxName.Text.Trim();
                UserModel.StartDate = DateTime.Parse("1900-01-01");
                UserModel.EndDate = DateTime.Now;
                DataSet ds = XASYU.BLL.DataBaseQuery.query_SYS_USERS(userBean, UserModel, ref  V_ITOTALCOUNT, V_SSTARTINDEX, V_SPERPAGESIZE);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    Alert.Show("用户 " + inputUserName + " 已经存在！");
                    return;
                }
                SaveItem();
                Alert.Show("新增成功！", String.Empty, ActiveWindow.GetHidePostBackReference());
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
