using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CykjSoft.UserPermissionManager.Utils;

namespace XASYU.BLL
{
    public class DataBaseManager
    {
        #region XASYU系统框架所用

        #region XASYU.BLL层操作方法 op_SYS_USERS
        /// <summary>
        /// 增删改SYS_USERS
        /// op_SYS_USERS
        /// 参数类名:SYS_USERSModel
        /// </summary>
        /// <returns>返回数</returns>
        public static int op_SYS_USERS(
             CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.SYS_USERSModel SYS_USERS
            )
        {
            int iRESULT = 0;
            int iERRCD = 0;
            string sERRMSG = String.Empty;
            try
            {
                XASYU.DBBusiness.DataBaseManager.op_SYS_USERS(
                userBean.YHDLM  //用户登陆名
                , ref  iRESULT
                , ref  iERRCD
                , ref  sERRMSG
                , DataOperationTypeHelper.GetOperationString(SYS_USERS.OpType)
                , SYS_USERS.ID		//ID 
                , SYS_USERS.Name		//Name 
                , SYS_USERS.Email		//Email 
                , SYS_USERS.Password		//Password 
                , SYS_USERS.Enabled		//Enabled 
                , SYS_USERS.Gender		//Gender 
                , SYS_USERS.ChineseName		//ChineseName 
                , SYS_USERS.Nation		//Nation 
                , SYS_USERS.IdentityCard		//IdentityCard 
                , SYS_USERS.XueLi		//XueLi 
                , SYS_USERS.XueWei		//XueWei 
                , SYS_USERS.ZhiWu		//ZhiWu 
                , SYS_USERS.Political		//Political 
                , SYS_USERS.YjFx		//YjFx 
                , SYS_USERS.Address		//Address 
                , SYS_USERS.EnglishName		//EnglishName 
                , SYS_USERS.Photo		//Photo 
                , SYS_USERS.QQ		//QQ 
                , SYS_USERS.CompanyEmail		//CompanyEmail 
                , SYS_USERS.OfficePhone		//OfficePhone 
                , SYS_USERS.OfficePhoneExt		//OfficePhoneExt 
                , SYS_USERS.HomePhone		//HomePhone 
                , SYS_USERS.CellPhone		//CellPhone 
                , SYS_USERS.Remark		//Remark 
                , SYS_USERS.Birthday		//Birthday 
                , SYS_USERS.TakeOfficeTime		//TakeOfficeTime 
                , SYS_USERS.LastLoginTime		//LastLoginTime 
                , SYS_USERS.CreateTime		//CreateTime 
                , SYS_USERS.DeptID		//DeptID 
                );
            }
            catch (Exception ex)
            {
                iRESULT = -1;
                ex.ToString();
            }
            return iRESULT;
        }
        #endregion

        #region XASYU.BLL层操作方法 op_SYS_CONFIGS
        /// <summary>
        /// 增删改SYS_CONFIGS
        /// op_SYS_CONFIGS
        /// 参数类名:SYS_CONFIGSModel
        /// </summary>
        /// <returns>返回数</returns>
        public static int op_SYS_CONFIGS(
             CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.SYS_CONFIGSModel SYS_CONFIGS
            )
        {
            int iRESULT = 0;
            int iERRCD = 0;
            string sERRMSG = String.Empty;
            try
            {
                XASYU.DBBusiness.DataBaseManager.op_SYS_CONFIGS(
                userBean.YHDLM  //用户登陆名
                , ref  iRESULT
                , ref  iERRCD
                , ref  sERRMSG
                , DataOperationTypeHelper.GetOperationString(SYS_CONFIGS.OpType)
                , SYS_CONFIGS.ID		//ID 
                , SYS_CONFIGS.ConfigKey		//ConfigKey 
                , SYS_CONFIGS.ConfigValue		//ConfigValue 
                , SYS_CONFIGS.Remark		//Remark 
                );
            }
            catch (Exception ex)
            {
                iRESULT = -1;
                ex.ToString();
            }
            return iRESULT;
        }
        #endregion

        #region XASYU.BLL层操作方法 op_SYS_DEPTS
        /// <summary>
        /// 增删改SYS_DEPTS
        /// op_SYS_DEPTS
        /// 参数类名:SYS_DEPTSModel
        /// </summary>
        /// <returns>返回数</returns>
        public static int op_SYS_DEPTS(
             CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.SYS_DEPTSModel SYS_DEPTS
            )
        {
            int iRESULT = 0;
            int iERRCD = 0;
            string sERRMSG = String.Empty;
            try
            {
                XASYU.DBBusiness.DataBaseManager.op_SYS_DEPTS(
                userBean.YHDLM  //用户登陆名
                , ref  iRESULT
                , ref  iERRCD
                , ref  sERRMSG
                , DataOperationTypeHelper.GetOperationString(SYS_DEPTS.OpType)
                , SYS_DEPTS.ID		//ID 
                , SYS_DEPTS.Name		//Name 
                , SYS_DEPTS.SortIndex		//SortIndex 
                , SYS_DEPTS.Remark		//Remark 
                , SYS_DEPTS.ParentID		//ParentID 
                , SYS_DEPTS.DeptLeader		//DeptLeader 
                , SYS_DEPTS.DeptTel		//DeptTel 
                );
            }
            catch (Exception ex)
            {
                iRESULT = -1;
                ex.ToString();
            }
            return iRESULT;
        }
        #endregion

        #region XASYU.BLL层操作方法 op_SYS_LOGS
        /// <summary>
        /// 增删改SYS_LOGS
        /// op_SYS_LOGS
        /// 参数类名:SYS_LOGSModel
        /// </summary>
        /// <returns>返回数</returns>
        public static int op_SYS_LOGS(
             CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.SYS_LOGSModel SYS_LOGS
            )
        {
            int iRESULT = 0;
            int iERRCD = 0;
            string sERRMSG = String.Empty;
            try
            {
                XASYU.DBBusiness.DataBaseManager.op_SYS_LOGS(
                userBean.YHDLM  //用户登陆名
                , ref  iRESULT
                , ref  iERRCD
                , ref  sERRMSG
                , DataOperationTypeHelper.GetOperationString(SYS_LOGS.OpType)
                , SYS_LOGS.ID		//ID 
                , SYS_LOGS.Level		//Level 
                , SYS_LOGS.Logger		//Logger 
                , SYS_LOGS.Message		//Message 
                , SYS_LOGS.Exception		//Exception 
                , SYS_LOGS.LogTime		//LogTime 
                );
            }
            catch (Exception ex)
            {
                iRESULT = -1;
                ex.ToString();
            }
            return iRESULT;
        }
        #endregion

        #region XASYU.BLL层操作方法 op_SYS_MENUS
        /// <summary>
        /// 增删改SYS_MENUS
        /// op_SYS_MENUS
        /// 参数类名:SYS_MENUSModel
        /// </summary>
        /// <returns>返回数</returns>
        public static int op_SYS_MENUS(
             CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.SYS_MENUSModel SYS_MENUS
            )
        {
            int iRESULT = 0;
            int iERRCD = 0;
            string sERRMSG = String.Empty;
            try
            {
                XASYU.DBBusiness.DataBaseManager.op_SYS_MENUS(
                userBean.YHDLM  //用户登陆名
                , ref  iRESULT
                , ref  iERRCD
                , ref  sERRMSG
                , DataOperationTypeHelper.GetOperationString(SYS_MENUS.OpType)
                , SYS_MENUS.ID		//ID 
                , SYS_MENUS.Name		//Name 
                , SYS_MENUS.ImageUrl		//ImageUrl 
                , SYS_MENUS.NavigateUrl		//NavigateUrl 
                , SYS_MENUS.Remark		//Remark 
                , SYS_MENUS.SortIndex		//SortIndex 
                , SYS_MENUS.ParentID		//ParentID 
                , SYS_MENUS.ViewPowerID		//ViewPowerID 
                );
            }
            catch (Exception ex)
            {
                iRESULT = -1;
                ex.ToString();
            }
            return iRESULT;
        }
        #endregion

        #region XASYU.BLL层操作方法 op_SYS_ONLINES
        /// <summary>
        /// 增删改SYS_ONLINES
        /// op_SYS_ONLINES
        /// 参数类名:SYS_ONLINESModel
        /// </summary>
        /// <returns>返回数</returns>
        public static int op_SYS_ONLINES(
             CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.SYS_ONLINESModel SYS_ONLINES
            )
        {
            int iRESULT = 0;
            int iERRCD = 0;
            string sERRMSG = String.Empty;
            try
            {
                XASYU.DBBusiness.DataBaseManager.op_SYS_ONLINES(
                userBean.YHDLM  //用户登陆名
                , ref  iRESULT
                , ref  iERRCD
                , ref  sERRMSG
                , DataOperationTypeHelper.GetOperationString(SYS_ONLINES.OpType)
                , SYS_ONLINES.ID		//ID 
                , SYS_ONLINES.IPAdddress		//IPAdddress 
                , SYS_ONLINES.LoginTime		//LoginTime 
                , SYS_ONLINES.UpdateTime		//UpdateTime 
                , SYS_ONLINES.UserID		//UserID 
                );
            }
            catch (Exception ex)
            {
                iRESULT = -1;
                ex.ToString();
            }
            return iRESULT;
        }
        #endregion

        #region XASYU.BLL层操作方法 op_SYS_POWERS
        /// <summary>
        /// 增删改SYS_POWERS
        /// op_SYS_POWERS
        /// 参数类名:SYS_POWERSModel
        /// </summary>
        /// <returns>返回数</returns>
        public static int op_SYS_POWERS(
             CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.SYS_POWERSModel SYS_POWERS
            )
        {
            int iRESULT = 0;
            int iERRCD = 0;
            string sERRMSG = String.Empty;
            try
            {
                XASYU.DBBusiness.DataBaseManager.op_SYS_POWERS(
                userBean.YHDLM  //用户登陆名
                , ref  iRESULT
                , ref  iERRCD
                , ref  sERRMSG
                , DataOperationTypeHelper.GetOperationString(SYS_POWERS.OpType)
                , SYS_POWERS.ID		//ID 
                , SYS_POWERS.Name		//Name 
                , SYS_POWERS.GroupName		//GroupName 
                , SYS_POWERS.Title		//Title 
                , SYS_POWERS.Remark		//Remark 
                );
            }
            catch (Exception ex)
            {
                iRESULT = -1;
                ex.ToString();
            }
            return iRESULT;
        }
        #endregion

        #region XASYU.BLL层操作方法 op_SYS_ROLEPOWERS
        /// <summary>
        /// 增删改SYS_ROLEPOWERS
        /// op_SYS_ROLEPOWERS
        /// 参数类名:SYS_ROLEPOWERSModel
        /// </summary>
        /// <returns>返回数</returns>
        public static int op_SYS_ROLEPOWERS(
             CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.SYS_ROLEPOWERSModel SYS_ROLEPOWERS
            )
        {
            int iRESULT = 0;
            int iERRCD = 0;
            string sERRMSG = String.Empty;
            try
            {
                XASYU.DBBusiness.DataBaseManager.op_SYS_ROLEPOWERS(
                userBean.YHDLM  //用户登陆名
                , ref  iRESULT
                , ref  iERRCD
                , ref  sERRMSG
                , DataOperationTypeHelper.GetOperationString(SYS_ROLEPOWERS.OpType)
                , SYS_ROLEPOWERS.RoleID		//RoleID 
                , SYS_ROLEPOWERS.PowerID		//PowerID 
                );
            }
            catch (Exception ex)
            {
                iRESULT = -1;
                ex.ToString();
            }
            return iRESULT;
        }
        #endregion

        #region XASYU.BLL层操作方法 op_SYS_ROLES
        /// <summary>
        /// 增删改SYS_ROLES
        /// op_SYS_ROLES
        /// 参数类名:SYS_ROLESModel
        /// </summary>
        /// <returns>返回数</returns>
        public static int op_SYS_ROLES(
             CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.SYS_ROLESModel SYS_ROLES
            )
        {
            int iRESULT = 0;
            int iERRCD = 0;
            string sERRMSG = String.Empty;
            try
            {
                XASYU.DBBusiness.DataBaseManager.op_SYS_ROLES(
                userBean.YHDLM  //用户登陆名
                , ref  iRESULT
                , ref  iERRCD
                , ref  sERRMSG
                , DataOperationTypeHelper.GetOperationString(SYS_ROLES.OpType)
                , SYS_ROLES.ID		//ID 
                , SYS_ROLES.Name		//Name 
                , SYS_ROLES.Remark		//Remark 
                );
            }
            catch (Exception ex)
            {
                iRESULT = -1;
                ex.ToString();
            }
            return iRESULT;
        }
        #endregion

        #region XASYU.BLL层操作方法 op_SYS_ROLEUSERS
        /// <summary>
        /// 增删改SYS_ROLEUSERS
        /// op_SYS_ROLEUSERS
        /// 参数类名:SYS_ROLEUSERSModel
        /// </summary>
        /// <returns>返回数</returns>
        public static int op_SYS_ROLEUSERS(
             CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.SYS_ROLEUSERSModel SYS_ROLEUSERS
            )
        {
            int iRESULT = 0;
            int iERRCD = 0;
            string sERRMSG = String.Empty;
            try
            {
                XASYU.DBBusiness.DataBaseManager.op_SYS_ROLEUSERS(
                userBean.YHDLM  //用户登陆名
                , ref  iRESULT
                , ref  iERRCD
                , ref  sERRMSG
                , DataOperationTypeHelper.GetOperationString(SYS_ROLEUSERS.OpType)
                , SYS_ROLEUSERS.RoleID		//RoleID 
                , SYS_ROLEUSERS.UserID		//UserID 
                );
            }
            catch (Exception ex)
            {
                iRESULT = -1;
                ex.ToString();
            }
            return iRESULT;
        }
        #endregion

        #region XASYU.BLL层操作方法 op_SYS_TITLES
        /// <summary>
        /// 增删改SYS_TITLES
        /// op_SYS_TITLES
        /// 参数类名:SYS_TITLESModel
        /// </summary>
        /// <returns>返回数</returns>
        public static int op_SYS_TITLES(
             CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.SYS_TITLESModel SYS_TITLES
            )
        {
            int iRESULT = 0;
            int iERRCD = 0;
            string sERRMSG = String.Empty;
            try
            {
                XASYU.DBBusiness.DataBaseManager.op_SYS_TITLES(
                userBean.YHDLM  //用户登陆名
                , ref  iRESULT
                , ref  iERRCD
                , ref  sERRMSG
                , DataOperationTypeHelper.GetOperationString(SYS_TITLES.OpType)
                , SYS_TITLES.ID		//ID 
                , SYS_TITLES.Name		//Name 
                , SYS_TITLES.Remark		//Remark 
                );
            }
            catch (Exception ex)
            {
                iRESULT = -1;
                ex.ToString();
            }
            return iRESULT;
        }
        #endregion

        #region XASYU.BLL层操作方法 op_SYS_TITLEUSERS
        /// <summary>
        /// 增删改SYS_TITLEUSERS
        /// op_SYS_TITLEUSERS
        /// 参数类名:SYS_TITLEUSERSModel
        /// </summary>
        /// <returns>返回数</returns>
        public static int op_SYS_TITLEUSERS(
             CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.SYS_TITLEUSERSModel SYS_TITLEUSERS
            )
        {
            int iRESULT = 0;
            int iERRCD = 0;
            string sERRMSG = String.Empty;
            try
            {
                XASYU.DBBusiness.DataBaseManager.op_SYS_TITLEUSERS(
                userBean.YHDLM  //用户登陆名
                , ref  iRESULT
                , ref  iERRCD
                , ref  sERRMSG
                , DataOperationTypeHelper.GetOperationString(SYS_TITLEUSERS.OpType)
                , SYS_TITLEUSERS.TitleID		//TitleID 
                , SYS_TITLEUSERS.UserID		//UserID 
                );
            }
            catch (Exception ex)
            {
                iRESULT = -1;
                ex.ToString();
            }
            return iRESULT;
        }
        #endregion

        #region XASYU.BLL层操作方法 op_SYS_USERS_ROLE
        /// <summary>
        /// 增删改SYS_ROLEUSERS
        /// op_SYS_ROLEUSERS
        /// 参数类名:SYS_ROLEUSERSModel
        /// </summary>
        /// <returns>返回数</returns>
        public static int op_SYS_USERS_ROLE(
             CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.SYS_USERS_ROLEModel SYS_ROLEUSERS
            )
        {
            int iRESULT = 0;
            int iERRCD = 0;
            string sERRMSG = String.Empty;
            try
            {
                XASYU.DBBusiness.DataBaseManager.op_SYS_USERS_ROLE(
                userBean.YHDLM  //用户登陆名
                , ref  iRESULT
                , ref  iERRCD
                , ref  sERRMSG
                , DataOperationTypeHelper.GetOperationString(SYS_ROLEUSERS.OpType)
                , SYS_ROLEUSERS.RoleID		//RoleID 
                , SYS_ROLEUSERS.UserID		//UserID 
                );
            }
            catch (Exception ex)
            {
                iRESULT = -1;
                ex.ToString();
            }
            return iRESULT;
        }
        #endregion

        #region XASYU.BLL层操作方法 op_SYS_USERS_TITLE
        /// <summary>
        /// 增删改SYS_ROLEUSERS
        /// op_SYS_ROLEUSERS
        /// 参数类名:SYS_ROLEUSERSModel
        /// </summary>
        /// <returns>返回数</returns>
        public static int op_SYS_USERS_TITLE(
             CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.SYS_USERS_TITLEModel SYS_TITLEUSERS
            )
        {
            int iRESULT = 0;
            int iERRCD = 0;
            string sERRMSG = String.Empty;
            try
            {
                XASYU.DBBusiness.DataBaseManager.op_SYS_USERS_TITLE(
                userBean.YHDLM  //用户登陆名
                , ref  iRESULT
                , ref  iERRCD
                , ref  sERRMSG
                , DataOperationTypeHelper.GetOperationString(SYS_TITLEUSERS.OpType)
                , SYS_TITLEUSERS.TitleID	//RoleID 
                , SYS_TITLEUSERS.UserID		//UserID 
                );
            }
            catch (Exception ex)
            {
                iRESULT = -1;
                ex.ToString();
            }
            return iRESULT;
        }
        #endregion

        #endregion

        #region XASYU.BLL层操作方法 op_TABLE_KYTZ
        /// <summary>
        /// 增删改TABLE_KYTZ
        /// op_TABLE_KYTZ
        /// 参数类名:TABLE_KYTZModel
        /// </summary>
        /// <returns>返回数</returns>
        public static int op_TABLE_KYTZ(
             CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.TABLE_KYTZModel TABLE_KYTZ
            )
        {
            int iRESULT = 0;
            int iERRCD = 0;
            string sERRMSG = String.Empty;
            try
            {
                XASYU.DBBusiness.DataBaseManager.op_TABLE_KYTZ(
                userBean.YHDLM  //用户登陆名
                , ref  iRESULT
                , ref  iERRCD
                , ref  sERRMSG
                , DataOperationTypeHelper.GetOperationString(TABLE_KYTZ.OpType)
                , TABLE_KYTZ.SerialNO		//SerialNO 
                , TABLE_KYTZ.tzmc		//tzmc 
                , TABLE_KYTZ.tznr		//tznr 
                , TABLE_KYTZ.tzsj		//tzsj 
                , TABLE_KYTZ.tz_enddate		//tz_enddate 
                , TABLE_KYTZ.tzr		//tzr 
                    //, TABLE_KYTZ.tzfj		//tzfj 
                , TABLE_KYTZ.tz_remark1		//tz_remark1 
                , TABLE_KYTZ.tz_remark2		//tz_remark2 
                );
            }
            catch (Exception ex)
            {
                iRESULT = -1;
                ex.ToString();
            }
            return iRESULT;
        }
        #endregion

        #region XASYU.BLL层操作方法 op_TABLE_STUDENT
        /// <summary>
        /// 增删改TABLE_STUDENT
        /// op_TABLE_STUDENT
        /// 参数类名:TABLE_STUDENTModel
        /// </summary>
        /// <returns>返回数</returns>
        public static int op_TABLE_STUDENT(
             CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.TABLE_STUDENTModel TABLE_STUDENT
            )
        {
            int iRESULT = 0;
            int iERRCD = 0;
            string sERRMSG = String.Empty;
            try
            {
                XASYU.DBBusiness.DataBaseManager.op_TABLE_STUDENT(
                userBean.YHDLM  //用户登陆名
                , ref  iRESULT
                , ref  iERRCD
                , ref  sERRMSG
                , DataOperationTypeHelper.GetOperationString(TABLE_STUDENT.OpType)
                , TABLE_STUDENT.Stu_NO		//Stu_NO 
                , TABLE_STUDENT.Stu_Name		//Stu_Name 
                , TABLE_STUDENT.Stu_Age		//Stu_Age 
                , TABLE_STUDENT.Stu_Zy		//Stu_Zy 
                );
            }
            catch (Exception ex)
            {
                iRESULT = -1;
                ex.ToString();
            }
            return iRESULT;
        }
        #endregion

        #region XASYU.BLL层操作方法 op_TABLE_CYSMS
        /// <summary>
        /// 增删改TABLE_CYSMS
        /// op_TABLE_CYSMS
        /// 参数类名:TABLE_CYSMSModel
        /// </summary>
        /// <returns>返回数</returns>
        public static int op_TABLE_CYSMS(
             CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.TABLE_CYSMSModel TABLE_CYSMS
            )
        {
            int iRESULT = 0;
            int iERRCD = 0;
            string sERRMSG = String.Empty;
            try
            {
                XASYU.DBBusiness.DataBaseManager.op_TABLE_CYSMS(
                userBean.YHDLM  //用户登陆名
                , ref iRESULT
                , ref iERRCD
                , ref sERRMSG
                , DataOperationTypeHelper.GetOperationString(TABLE_CYSMS.OpType)
                , TABLE_CYSMS.CySms_id      //CySms_id 
                , TABLE_CYSMS.CySms_nr      //CySms_nr 
                , TABLE_CYSMS.CySms_lx      //CySms_lx 
                );
            }
            catch (Exception ex)
            {
                iRESULT = -1;
                ex.ToString();
            }
            return iRESULT;
        }
        #endregion

        #region XASYU.BLL层操作方法 op_TABLE_SMS
        /// <summary>
        /// 增删改TABLE_SMS
        /// op_TABLE_SMS
        /// 参数类名:TABLE_SMSModel
        /// </summary>
        /// <returns>返回数</returns>
        public static int op_TABLE_SMS(
             CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.TABLE_SMSModel TABLE_SMS
            )
        {
            int iRESULT = 0;
            int iERRCD = 0;
            string sERRMSG = String.Empty;
            try
            {
                XASYU.DBBusiness.DataBaseManager.op_TABLE_SMS(
                userBean.YHDLM  //用户登陆名
                , ref iRESULT
                , ref iERRCD
                , ref sERRMSG
                , DataOperationTypeHelper.GetOperationString(TABLE_SMS.OpType)
                , TABLE_SMS.SMS_id      //SMS_id 
                , TABLE_SMS.SMS_jsr     //SMS_jsr 
                , TABLE_SMS.SMS_nr      //SMS_nr 
                , TABLE_SMS.SMS_ljfs        //SMS_ljfs 
                , TABLE_SMS.SMS_fstime      //SMS_fstime 
                , TABLE_SMS.SMS_dstime      //SMS_dstime 
                , TABLE_SMS.SMS_dxlx        //SMS_dxlx 
                , TABLE_SMS.SMS_dxzt        //SMS_dxzt 
                , TABLE_SMS.SMS_hzzt        //SMS_hzzt 
                , TABLE_SMS.SMS_wapdx       //SMS_wapdx 
                , TABLE_SMS.SMS_fjname      //SMS_fjname 
                , TABLE_SMS.SMS_zchf        //SMS_zchf 
                , TABLE_SMS.SMS_ztbg        //SMS_ztbg 
                , TABLE_SMS.SMS_hftx        //SMS_hftx 
                , TABLE_SMS.SMS_hmd     //SMS_hmd 
                , TABLE_SMS.SMS_sfzf        //SMS_sfzf 
                , TABLE_SMS.SMS_delete      //SMS_delete 
                );
            }
            catch (Exception ex)
            {
                iRESULT = -1;
                ex.ToString();
            }
            return iRESULT;
        }
        #endregion

        #region XASYU.BLL层操作方法 op_TABLE_SJX
        /// <summary>
        /// 增删改TABLE_SJX
        /// op_TABLE_SJX
        /// 参数类名:TABLE_SJXModel
        /// </summary>
        /// <returns>返回数</returns>
        public static int op_TABLE_SJX(
             CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.TABLE_SJXModel TABLE_SJX
            )
        {
            int iRESULT = 0;
            int iERRCD = 0;
            string sERRMSG = String.Empty;
            try
            {
                XASYU.DBBusiness.DataBaseManager.op_TABLE_SJX(
                userBean.YHDLM  //用户登陆名
                , ref iRESULT
                , ref iERRCD
                , ref sERRMSG
                , DataOperationTypeHelper.GetOperationString(TABLE_SJX.OpType)
                , TABLE_SJX.SJX_id      //SJX_id 
                , TABLE_SJX.SJX_mobile      //SJX_mobile 
                , TABLE_SJX.SJX_nr      //SJX_nr 
                , TABLE_SJX.SJX_jstime      //SJX_jstime 
                );
            }
            catch (Exception ex)
            {
                iRESULT = -1;
                ex.ToString();
            }
            return iRESULT;
        }
        #endregion

        #region XASYU.BLL层操作方法 op_TABLE_DXHF
        /// <summary>
        /// 增删改TABLE_DXHF
        /// op_TABLE_DXHF
        /// 参数类名:TABLE_DXHFModel
        /// </summary>
        /// <returns>返回数</returns>
        public static int op_TABLE_DXHF(
             CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.TABLE_DXHFModel TABLE_DXHF
            )
        {
            int iRESULT = 0;
            int iERRCD = 0;
            string sERRMSG = String.Empty;
            try
            {
                XASYU.DBBusiness.DataBaseManager.op_TABLE_DXHF(
                userBean.YHDLM  //用户登陆名
                , ref iRESULT
                , ref iERRCD
                , ref sERRMSG
                , DataOperationTypeHelper.GetOperationString(TABLE_DXHF.OpType)
                , TABLE_DXHF.DXHF_id        //DXHF_id 
                , TABLE_DXHF.SMS_id     //SMS_id 
                , TABLE_DXHF.DXHF_hfrmobile     //DXHF_hfrmobile 
                , TABLE_DXHF.DXHF_nr        //DXHF_nr 
                , TABLE_DXHF.DXHF_time      //DXHF_time 
                );
            }
            catch (Exception ex)
            {
                iRESULT = -1;
                ex.ToString();
            }
            return iRESULT;
        }
        #endregion

        #region XASYU.BLL层操作方法 op_TABLE_TXQZ
        /// <summary>
        /// 增删改TABLE_TXQZ
        /// op_TABLE_TXQZ
        /// 参数类名:TABLE_TXQZModel
        /// </summary>
        /// <returns>返回数</returns>
        public static int op_TABLE_TXQZ(
             CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.TABLE_TXQZModel TABLE_TXQZ
            )
        {
            int iRESULT = 0;
            int iERRCD = 0;
            string sERRMSG = String.Empty;
            try
            {
                XASYU.DBBusiness.DataBaseManager.op_TABLE_TXQZ(
                userBean.YHDLM  //用户登陆名
                , ref iRESULT
                , ref iERRCD
                , ref sERRMSG
                , DataOperationTypeHelper.GetOperationString(TABLE_TXQZ.OpType)
                , TABLE_TXQZ.TXQZ_id        //TXQZ_id 
                , TABLE_TXQZ.TXQZ_name      //TXQZ_name 
                , TABLE_TXQZ.TXQZ_sjid      //TXQZ_sjid 
                );
            }
            catch (Exception ex)
            {
                iRESULT = -1;
                ex.ToString();
            }
            return iRESULT;
        }
        #endregion

        #region XASYU.BLL层操作方法 op_TABLE_LXR
        /// <summary>
        /// 增删改TABLE_LXR
        /// op_TABLE_LXR
        /// 参数类名:TABLE_LXRModel
        /// </summary>
        /// <returns>返回数</returns>
        public static int op_TABLE_LXR(
             CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.TABLE_LXRModel TABLE_LXR
            )
        {
            int iRESULT = 0;
            int iERRCD = 0;
            string sERRMSG = String.Empty;
            try
            {
                XASYU.DBBusiness.DataBaseManager.op_TABLE_LXR(
                userBean.YHDLM  //用户登陆名
                , ref iRESULT
                , ref iERRCD
                , ref sERRMSG
                , DataOperationTypeHelper.GetOperationString(TABLE_LXR.OpType)
                , TABLE_LXR.LXR_id      //LXR_id 
                , TABLE_LXR.LXR_name        //LXR_name 
                , TABLE_LXR.LXR_mobile      //LXR_mobile 
                , TABLE_LXR.LXR_sex     //LXR_sex 
                , TABLE_LXR.LXR_phone       //LXR_phone 
                , TABLE_LXR.LXR_email       //LXR_email 
                , TABLE_LXR.LXR_gzdw        //LXR_gzdw 
                , TABLE_LXR.LXR_sfzid       //LXR_sfzid 
                , TABLE_LXR.LXR_zw      //LXR_zw 
                , TABLE_LXR.LXR_bz      //LXR_bz 
                , TABLE_LXR.LXR_sfjrwh      //LXR_sfjrwh 
                , TABLE_LXR.LXR_csrq        //LXR_csrq 
                , TABLE_LXR.LXR_sfsrwh      //LXR_sfsrwh 
                , TABLE_LXR.LXR_gj01        //LXR_gj01 
                , TABLE_LXR.LXR_gj01nr      //LXR_gj01nr 
                , TABLE_LXR.LXR_gj02        //LXR_gj02 
                , TABLE_LXR.LXR_gj02nr      //LXR_gj02nr 
                , TABLE_LXR.LXR_gj03        //LXR_gj03 
                , TABLE_LXR.LXR_gj03nr      //LXR_gj03nr 
                );
            }
            catch (Exception ex)
            {
                iRESULT = -1;
                ex.ToString();
            }
            return iRESULT;
        }
        #endregion
    }
}
