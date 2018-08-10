using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using FineUI;
using CykjSoft.UserPermissionManager.Utils;

namespace XASYU.Jbxx
{
    public partial class frm_KytzNew : PageBase
    {
        #region ViewPower

        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "CoreKytzNew";
            }
        }

        #endregion

        #region 初始化变量
        int V_ITOTALCOUNT = -1;
        int V_SSTARTINDEX = 0;
        int V_SPERPAGESIZE = 1000;
        private XASYU.MODEL.TABLE_KYTZModel Table_XYBM = new MODEL.TABLE_KYTZModel();
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
            this.tbxTzr.Text=GetIdentityName();//获取当前登录用户名
            btnClose.OnClientClick = ActiveWindow.GetHideReference();
        }

        #endregion

        #region Events

        private void SaveItem()
        {
            try
            {
                Table_XYBM.tzmc = this.tbxTzmc.Text.Trim();
                Table_XYBM.tznr = this.tbxTznr.Text.Trim();
                Table_XYBM.tzr = this.tbxTzr.Text.Trim();
                Table_XYBM.tzsj = DateTime.Parse(this.startDate.Text.ToString());
                Table_XYBM.tz_enddate = DateTime.Parse(this.endDate.Text.ToString());
                Table_XYBM.tz_remark1 = this.tbxBz.Text.Trim();
                Table_XYBM.OpType = DataOperationType.Add;
                if (XASYU.BLL.DataBaseManager.op_TABLE_KYTZ(userBean, Table_XYBM) == 0)
                {
                    Alert.ShowInTop("新增成功！");
                }
                else
                {
                    Alert.ShowInTop("新增失败!");
                }
            }
            catch (Exception ex)
            {
                Alert.ShowInTop(ex.Message);
            }

        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            SaveItem();
            //Alert.Show("添加成功！", String.Empty, ActiveWindow.GetHidePostBackReference());
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        #endregion
    }
}