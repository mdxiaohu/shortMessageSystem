using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using FineUI;
using CykjSoft.UserPermissionManager.Utils;
using System.Data;

namespace XASYU.Jbxx
{
    public partial class frm_KytzEdit : PageBase
    {
        #region ViewPower

        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "CoreKytzEdit";
            }
        }

        #endregion

        #region 初始化变量
        int V_ITOTALCOUNT = -1;
        int V_SSTARTINDEX = 0;
        int V_SPERPAGESIZE = 1000;
        private XASYU.MODEL.TABLE_KYTZModel Table_XYBM = new MODEL.TABLE_KYTZModel();
        //static DateTime startdate = DateTime.Parse("1900-01-01");
        //static DateTime enddate = DateTime.Now.Date.AddDays(1).AddSeconds(-1);
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
            Table_XYBM.SerialNO = id;
            Table_XYBM.StartDate = DateTime.Parse("1900-01-01");
            //DateTime.Now.AddDays(-7);
            Table_XYBM.EndDate = DateTime.Now;
            //Table_XYBM.tzfj = Num;
            DataTable table = new DataTable();
            DataSet ds = XASYU.BLL.DataBaseQuery.query_TABLE_KYTZ(userBean, Table_XYBM, ref  V_ITOTALCOUNT, V_SSTARTINDEX, V_SPERPAGESIZE);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                table = ds.Tables[0];
            }

            this.tbxTzmc.Text = table.Rows[0]["tzmc"].ToString();
            this.tbxTznr.Text = table.Rows[0]["tznr"].ToString();
            this.tbxTzr.Text = table.Rows[0]["tzr"].ToString();
            this.startDate.SelectedDate = DateTime.Parse(table.Rows[0]["tzsj"].ToString());
            this.endDate.SelectedDate = DateTime.Parse(table.Rows[0]["tz_enddate"].ToString());
            this.tbxBz.Text = table.Rows[0]["tz_remark1"].ToString();
        }


        #endregion

        #region Events

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            int id = GetQueryIntValue("id");
            try
            {
                Table_XYBM.SerialNO = id;
                Table_XYBM.tzmc = this.tbxTzmc.Text.Trim();
                Table_XYBM.tznr = this.tbxTznr.Text.Trim();
                Table_XYBM.tzr = this.tbxTzr.Text.Trim();
                Table_XYBM.tzsj = DateTime.Parse(this.startDate.Text.ToString());
                Table_XYBM.tz_enddate = DateTime.Parse(this.endDate.Text.ToString());
                Table_XYBM.tz_remark1 = this.tbxBz.Text.Trim();
                Table_XYBM.OpType = DataOperationType.Modify;
                if (XASYU.BLL.DataBaseManager.op_TABLE_KYTZ(userBean, Table_XYBM) == 0)
                {
                    Alert.ShowInTop("修改成功！");
                }
                else
                {
                    Alert.ShowInTop("修改失败!");
                }
            }
            catch (Exception ex)
            {
                Alert.ShowInTop(ex.Message);
            }

            //FineUI.Alert.Show("保存成功！", String.Empty, FineUI.Alert.DefaultIcon, FineUI.ActiveWindow.GetHidePostBackReference());
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        #endregion
    }
}