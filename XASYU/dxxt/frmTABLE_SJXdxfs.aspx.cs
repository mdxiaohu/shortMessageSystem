using CykjSoft.UserPermissionManager.Utils;
using FineUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XASYU.dxxt
{
    public partial class frmTABLE_SJXdxfs : PageBase
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
            private XASYU.MODEL.TABLE_SJXModel model = new XASYU.MODEL.TABLE_SJXModel();
            CykjSoft.Bean.UserBean userBean = new CykjSoft.Bean.UserBean();
            #endregion

            #region 页面加载

            protected override void OnLoad(EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                    btnClose.OnClientClick = ActiveWindow.GetHideReference();
                    if (Request.QueryString["SJX_ID"] != null && Request.QueryString["SJX_ID"].ToString().Trim() != "")
                    {
                        XASYU.MODEL.TABLE_SJXModel temp = new XASYU.MODEL.TABLE_SJXModel();
                        temp.SJX_id = int.Parse(Request.QueryString["SJX_ID"].ToString().Trim());
                        int iCount = -1;
                        DataSet ds = XASYU.BLL.DataBaseQuery.query_TABLE_SJX(userBean, temp, ref iCount, 0, 10);
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            this.hiddenSJX_id.Text = dr["SJX_id"].ToString();
                            this.txtSJX_mobile.Text = dr["SJX_mobile"].ToString();
                            this.txtSJX_nr.Text = dr["SJX_nr"].ToString();

                        

                    }
                        else
                        {
                            //this.hiddenSJX_id.Value ="0" ;
                           
                        }
                    }
                    else
                    {
                        //this.hiddenSJX_id.Value ="0" ;
                        
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
                    model.SJX_id = int.Parse(this.hiddenSJX_id.Text.Trim());
                    model.SJX_mobile = this.txtSJX_mobile.Text;
                    model.SJX_nr = this.txtSJX_nr.Text;
                    

                    model.OpType = DataOperationType.Modify;
                    if (XASYU.BLL.DataBaseManager.op_TABLE_SJX(userBean, model) == 0)
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


            #region 短信发送


            /// <summary>
            /// 发送短信
            /// smsUid:用户ID
            /// smsKey:用户密码
            /// smsMob:手机号码
            /// smsText:短信内容
            /// </summary>
            public static  string SmsSend(string txtSJX_mobile1, string txtSJX_nr1)
            {
                string strRet = null;
                // 用户ID
                string smsUid = "悠逸短信平台的注册账号：http://youe.smsadmin.cn/";
                // 用户密码
                string smsKey = "密码";
                // 接收短信的手机号码，多个号码用英文下的分号";"间隔，POST方式一次最多可提交1000个号码
                string smsMob = txtSJX_mobile1;
                //短信内容,支持长短信，最多350个字，长短信67个字/条计费
                string smsText = txtSJX_nr1; 
                Encoding encoding = System.Text.Encoding.GetEncoding("GB2312");



                string postData = string.Format("uid={0}&pwd={1}&mobile={2}&msg={3}&dtime=", smsUid, smsKey, smsMob, smsText);
                byte[] data = encoding.GetBytes(postData);
                // 定义 WebRequest
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("http://www.smsadmin.cn/smsmarketing/wwwroot/api/post_send/");
                myRequest.Method = "POST";
                myRequest.ContentType = "application/x-www-form-urlencoded";
                myRequest.ContentLength = data.Length;
                Stream newStream = myRequest.GetRequestStream();
                //发送数据
                newStream.Write(data, 0, data.Length);
                newStream.Close();
                // 得到 Response
                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.Default);
                string content = reader.ReadToEnd();
                string result = content.Substring(0, 1);
                if (result == "0")
                {
                    strRet = "短信发送成功！";
                }
                else if (result == "1")
                {
                    strRet = "用户名或密码错误！";
                }
                else if (result == "2")
                {
                    strRet = "账号余额不足！";
                }
                else if (result == "3")
                {
                    strRet = "超过发送最大量！";
                }
                else if (result == "4")
                {
                    strRet = "此用户不允许发送！";
                }
                else if (result == "5")
                {
                    strRet = "手机号码或短信内容为空！";
                }
                else if (result == "7")
                {
                    strRet = "短信内容超长！";
                }
                else if (result == "8")
                {
                    strRet = "用户被冻结！";
                }
                else
                {
                    strRet = content;
                }
                return strRet;
            }

            #endregion

            

        protected void btnSaveClose_Click1(object sender, EventArgs e)
        {
            string txtSJX_mobile1 = this.txtSJX_mobile.Text;
            string txtSJX_nr1 = this.txtSJX_nr.Text;
            string responseResults = frmTABLE_SJXdxfs.SmsSend(txtSJX_mobile1, txtSJX_nr1);
            Alert.Show(responseResults);
        }
    }
    }
