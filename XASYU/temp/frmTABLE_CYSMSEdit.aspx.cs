﻿using CykjSoft.UserPermissionManager.Utils;
using FineUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XASYU.temp
{
    public partial class frmTABLE_CYSMSEdit : PageBase
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

        #region 定义对象
        int V_ITOTALCOUNT = -1;
        int V_SSTARTINDEX = 0;
        int V_SPERPAGESIZE = 1000;
        private XASYU.MODEL.TABLE_CYSMSModel model = new XASYU.MODEL.TABLE_CYSMSModel();
        CykjSoft.Bean.UserBean userBean = new CykjSoft.Bean.UserBean();
        #endregion

        #region 页面加载

        protected override void OnLoad(EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
                if (Request.QueryString["CYSMS_ID"] != null && Request.QueryString["CYSMS_ID"].ToString().Trim() != "")
                {
                    XASYU.MODEL.TABLE_CYSMSModel temp = new XASYU.MODEL.TABLE_CYSMSModel();
                    temp.CySms_id = int.Parse(Request.QueryString["CYSMS_ID"].ToString().Trim());
                    int iCount = -1;
                    DataSet ds = XASYU.BLL.DataBaseQuery.query_TABLE_CYSMS(userBean, temp, ref iCount, 0, 10);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        this.hiddenCySms_id.Text= dr["CySms_id"].ToString();
                        this.txtCySms_nr.Text = dr["CySms_nr"].ToString();
                        this.txtCySms_lx.Text = dr["CySms_lx"].ToString();
                    }
                    else
                    {
                        //this.hiddenCySms_id.Value ="0" ;
                    }
                }
                else
                {
                    //this.hiddenCySms_id.Value ="0" ;
                }
            }
        }

        #endregion

        #region 保存按钮事件
        /// <summary>
        /// 保存按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            try
            {
                model.CySms_id = int.Parse(this.hiddenCySms_id.Text.Trim());
                model.CySms_nr = this.txtCySms_nr.Text;
                model.CySms_lx = this.txtCySms_lx.Text;

                model.OpType = DataOperationType.Modify;
                if (XASYU.BLL.DataBaseManager.op_TABLE_CYSMS(userBean, model) == 0)
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
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
        #endregion
    }
}