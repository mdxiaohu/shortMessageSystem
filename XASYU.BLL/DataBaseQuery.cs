using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CykjSoft.Bean;

namespace XASYU.BLL
{
    public class DataBaseQuery
    {
        #region XASYU系统框架所用

        #region XASYU.BLL层查询方法 query_SYS_USERS
        /// <summary>
        /// 查询SYS_USERS
        /// query_SYS_USERS
        /// 参数类名:SYS_USERSModel
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet query_SYS_USERS(
              CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.SYS_USERSModel SYS_USERS
            , ref int V_ITOTALCOUNT //记录数
            , int V_SSTARTINDEX 	//开始索引
            , int V_SPERPAGESIZE 	//页大小
            )
        {
            return XASYU.DBBusiness.DataBaseQuery.query_SYS_USERS(
              userBean.YHDLM  //用户登陆名
            , ref V_ITOTALCOUNT 	//记录数
            , V_SSTARTINDEX 		//开始索引
            , V_SPERPAGESIZE 		//页大小
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
            , SYS_USERS.StartDate  			//开始时间
            , SYS_USERS.EndDate  	 		//结束时间
            );
        }
        #endregion

        #region XASYU.BLL层查询方法 query_SYS_CONFIGS
        /// <summary>
        /// 查询SYS_CONFIGS
        /// query_SYS_CONFIGS
        /// 参数类名:SYS_CONFIGSModel
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet query_SYS_CONFIGS(
              CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.SYS_CONFIGSModel SYS_CONFIGS
            , ref int V_ITOTALCOUNT //记录数
            , int V_SSTARTINDEX 	//开始索引
            , int V_SPERPAGESIZE 	//页大小
            )
        {
            return XASYU.DBBusiness.DataBaseQuery.query_SYS_CONFIGS(
              userBean.YHDLM  //用户登陆名
            , ref V_ITOTALCOUNT 	//记录数
            , V_SSTARTINDEX 		//开始索引
            , V_SPERPAGESIZE 		//页大小
            , SYS_CONFIGS.ID		//ID 
            , SYS_CONFIGS.ConfigKey		//ConfigKey 
            , SYS_CONFIGS.ConfigValue		//ConfigValue 
            , SYS_CONFIGS.Remark		//Remark 
            , SYS_CONFIGS.StartDate  			//开始时间
            , SYS_CONFIGS.EndDate  	 		//结束时间
            );
        }
        #endregion

        #region XASYU.BLL层查询方法 query_SYS_DEPTS
        /// <summary>
        /// 查询SYS_DEPTS
        /// query_SYS_DEPTS
        /// 参数类名:SYS_DEPTSModel
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet query_SYS_DEPTS(
              CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.SYS_DEPTSModel SYS_DEPTS
            , ref int V_ITOTALCOUNT //记录数
            , int V_SSTARTINDEX 	//开始索引
            , int V_SPERPAGESIZE 	//页大小
            )
        {
            return XASYU.DBBusiness.DataBaseQuery.query_SYS_DEPTS(
              userBean.YHDLM  //用户登陆名
            , ref V_ITOTALCOUNT 	//记录数
            , V_SSTARTINDEX 		//开始索引
            , V_SPERPAGESIZE 		//页大小
            , SYS_DEPTS.ID		//ID 
            , SYS_DEPTS.Name		//Name 
            , SYS_DEPTS.SortIndex		//SortIndex 
            , SYS_DEPTS.Remark		//Remark 
            , SYS_DEPTS.ParentID		//ParentID 
            , SYS_DEPTS.DeptLeader		//DeptLeader 
            , SYS_DEPTS.DeptTel		//DeptTel 
            , SYS_DEPTS.StartDate  			//开始时间
            , SYS_DEPTS.EndDate  	 		//结束时间
            );
        }

        public static DataSet query_TABLE_SJX(UserBean userBean, object temp, ref object iCount, int v1, int v2)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region XASYU.BLL层查询方法 query_SYS_LOGS
        /// <summary>
        /// 查询SYS_LOGS
        /// query_SYS_LOGS
        /// 参数类名:SYS_LOGSModel
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet query_SYS_LOGS(
              CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.SYS_LOGSModel SYS_LOGS
            , ref int V_ITOTALCOUNT //记录数
            , int V_SSTARTINDEX 	//开始索引
            , int V_SPERPAGESIZE 	//页大小
            )
        {
            return XASYU.DBBusiness.DataBaseQuery.query_SYS_LOGS(
              userBean.YHDLM  //用户登陆名
            , ref V_ITOTALCOUNT 	//记录数
            , V_SSTARTINDEX 		//开始索引
            , V_SPERPAGESIZE 		//页大小
            , SYS_LOGS.ID		//ID 
            , SYS_LOGS.Level		//Level 
            , SYS_LOGS.Logger		//Logger 
            , SYS_LOGS.Message		//Message 
            , SYS_LOGS.Exception		//Exception 
            , SYS_LOGS.LogTime		//LogTime 
            , SYS_LOGS.StartDate  			//开始时间
            , SYS_LOGS.EndDate  	 		//结束时间
            );
        }
        #endregion

        #region XASYU.BLL层查询方法 query_SYS_MENUS
        /// <summary>
        /// 查询SYS_MENUS
        /// query_SYS_MENUS
        /// 参数类名:SYS_MENUSModel
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet query_SYS_MENUS(
              CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.SYS_MENUSModel SYS_MENUS
            , ref int V_ITOTALCOUNT //记录数
            , int V_SSTARTINDEX 	//开始索引
            , int V_SPERPAGESIZE 	//页大小
            )
        {
            return XASYU.DBBusiness.DataBaseQuery.query_SYS_MENUS(
              userBean.YHDLM  //用户登陆名
            , ref V_ITOTALCOUNT 	//记录数
            , V_SSTARTINDEX 		//开始索引
            , V_SPERPAGESIZE 		//页大小
            , SYS_MENUS.ID		//ID 
            , SYS_MENUS.Name		//Name 
            , SYS_MENUS.ImageUrl		//ImageUrl 
            , SYS_MENUS.NavigateUrl		//NavigateUrl 
            , SYS_MENUS.Remark		//Remark 
            , SYS_MENUS.SortIndex		//SortIndex 
            , SYS_MENUS.ParentID		//ParentID 
            , SYS_MENUS.ViewPowerID		//ViewPowerID 
            , SYS_MENUS.StartDate  			//开始时间
            , SYS_MENUS.EndDate  	 		//结束时间
            );
        }
        #endregion

        #region XASYU.BLL层查询方法 query_SYS_ONLINES
        /// <summary>
        /// 查询SYS_ONLINES
        /// query_SYS_ONLINES
        /// 参数类名:SYS_ONLINESModel
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet query_SYS_ONLINES(
              CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.SYS_ONLINESModel SYS_ONLINES
            , ref int V_ITOTALCOUNT //记录数
            , int V_SSTARTINDEX 	//开始索引
            , int V_SPERPAGESIZE 	//页大小
            )
        {
            return XASYU.DBBusiness.DataBaseQuery.query_SYS_ONLINES(
              userBean.YHDLM  //用户登陆名
            , ref V_ITOTALCOUNT 	//记录数
            , V_SSTARTINDEX 		//开始索引
            , V_SPERPAGESIZE 		//页大小
            , SYS_ONLINES.ID		//ID 
            , SYS_ONLINES.IPAdddress		//IPAdddress 
            , SYS_ONLINES.LoginTime		//LoginTime 
            , SYS_ONLINES.UpdateTime		//UpdateTime 
            , SYS_ONLINES.UserID		//UserID 
            , SYS_ONLINES.StartDate  			//开始时间
            , SYS_ONLINES.EndDate  	 		//结束时间
            );
        }
        #endregion

        #region XASYU.BLL层查询方法 query_SYS_POWERS
        /// <summary>
        /// 查询SYS_POWERS
        /// query_SYS_POWERS
        /// 参数类名:SYS_POWERSModel
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet query_SYS_POWERS(
              CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.SYS_POWERSModel SYS_POWERS
            , ref int V_ITOTALCOUNT //记录数
            , int V_SSTARTINDEX 	//开始索引
            , int V_SPERPAGESIZE 	//页大小
            )
        {
            return XASYU.DBBusiness.DataBaseQuery.query_SYS_POWERS(
              userBean.YHDLM  //用户登陆名
            , ref V_ITOTALCOUNT 	//记录数
            , V_SSTARTINDEX 		//开始索引
            , V_SPERPAGESIZE 		//页大小
            , SYS_POWERS.ID		//ID 
            , SYS_POWERS.Name		//Name 
            , SYS_POWERS.GroupName		//GroupName 
            , SYS_POWERS.Title		//Title 
            , SYS_POWERS.Remark		//Remark 
            , SYS_POWERS.StartDate  			//开始时间
            , SYS_POWERS.EndDate  	 		//结束时间
            );
        }
        #endregion

        #region XASYU.BLL层查询方法 query_SYS_ROLEPOWERS
        /// <summary>
        /// 查询SYS_ROLEPOWERS
        /// query_SYS_ROLEPOWERS
        /// 参数类名:SYS_ROLEPOWERSModel
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet query_SYS_ROLEPOWERS(
              CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.SYS_ROLEPOWERSModel SYS_ROLEPOWERS
            , ref int V_ITOTALCOUNT //记录数
            , int V_SSTARTINDEX 	//开始索引
            , int V_SPERPAGESIZE 	//页大小
            )
        {
            return XASYU.DBBusiness.DataBaseQuery.query_SYS_ROLEPOWERS(
              userBean.YHDLM  //用户登陆名
            , ref V_ITOTALCOUNT 	//记录数
            , V_SSTARTINDEX 		//开始索引
            , V_SPERPAGESIZE 		//页大小
            , SYS_ROLEPOWERS.RoleID		//RoleID 
            , SYS_ROLEPOWERS.PowerID		//PowerID 
            , SYS_ROLEPOWERS.StartDate  			//开始时间
            , SYS_ROLEPOWERS.EndDate  	 		//结束时间
            );
        }
        #endregion

        #region XASYU.BLL层查询方法 query_SYS_ROLES
        /// <summary>
        /// 查询SYS_ROLES
        /// query_SYS_ROLES
        /// 参数类名:SYS_ROLESModel
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet query_SYS_ROLES(
              CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.SYS_ROLESModel SYS_ROLES
            , ref int V_ITOTALCOUNT //记录数
            , int V_SSTARTINDEX 	//开始索引
            , int V_SPERPAGESIZE 	//页大小
            )
        {
            return XASYU.DBBusiness.DataBaseQuery.query_SYS_ROLES(
              userBean.YHDLM  //用户登陆名
            , ref V_ITOTALCOUNT 	//记录数
            , V_SSTARTINDEX 		//开始索引
            , V_SPERPAGESIZE 		//页大小
            , SYS_ROLES.ID		//ID 
            , SYS_ROLES.Name		//Name 
            , SYS_ROLES.Remark		//Remark 
            , SYS_ROLES.StartDate  			//开始时间
            , SYS_ROLES.EndDate  	 		//结束时间
            );
        }
        #endregion

        #region XASYU.BLL层查询方法 query_SYS_ROLEUSERS
        /// <summary>
        /// 查询SYS_ROLEUSERS
        /// query_SYS_ROLEUSERS
        /// 参数类名:SYS_ROLEUSERSModel
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet query_SYS_ROLEUSERS(
              CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.SYS_ROLEUSERSModel SYS_ROLEUSERS
            , ref int V_ITOTALCOUNT //记录数
            , int V_SSTARTINDEX 	//开始索引
            , int V_SPERPAGESIZE 	//页大小
            )
        {
            return XASYU.DBBusiness.DataBaseQuery.query_SYS_ROLEUSERS(
              userBean.YHDLM  //用户登陆名
            , ref V_ITOTALCOUNT 	//记录数
            , V_SSTARTINDEX 		//开始索引
            , V_SPERPAGESIZE 		//页大小
            , SYS_ROLEUSERS.RoleID		//RoleID 
            , SYS_ROLEUSERS.UserID		//UserID 
            , SYS_ROLEUSERS.StartDate  			//开始时间
            , SYS_ROLEUSERS.EndDate  	 		//结束时间
            );
        }
        #endregion

        #region XASYU.BLL层查询方法 query_SYS_TITLES
        /// <summary>
        /// 查询SYS_TITLES
        /// query_SYS_TITLES
        /// 参数类名:SYS_TITLESModel
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet query_SYS_TITLES(
              CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.SYS_TITLESModel SYS_TITLES
            , ref int V_ITOTALCOUNT //记录数
            , int V_SSTARTINDEX 	//开始索引
            , int V_SPERPAGESIZE 	//页大小
            )
        {
            return XASYU.DBBusiness.DataBaseQuery.query_SYS_TITLES(
              userBean.YHDLM  //用户登陆名
            , ref V_ITOTALCOUNT 	//记录数
            , V_SSTARTINDEX 		//开始索引
            , V_SPERPAGESIZE 		//页大小
            , SYS_TITLES.ID		//ID 
            , SYS_TITLES.Name		//Name 
            , SYS_TITLES.Remark		//Remark 
            , SYS_TITLES.StartDate  			//开始时间
            , SYS_TITLES.EndDate  	 		//结束时间
            );
        }
        #endregion

        #region XASYU.BLL层查询方法 query_SYS_TITLEUSERS
        /// <summary>
        /// 查询SYS_TITLEUSERS
        /// query_SYS_TITLEUSERS
        /// 参数类名:SYS_TITLEUSERSModel
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet query_SYS_TITLEUSERS(
              CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.SYS_TITLEUSERSModel SYS_TITLEUSERS
            , ref int V_ITOTALCOUNT //记录数
            , int V_SSTARTINDEX 	//开始索引
            , int V_SPERPAGESIZE 	//页大小
            )
        {
            return XASYU.DBBusiness.DataBaseQuery.query_SYS_TITLEUSERS(
              userBean.YHDLM  //用户登陆名
            , ref V_ITOTALCOUNT 	//记录数
            , V_SSTARTINDEX 		//开始索引
            , V_SPERPAGESIZE 		//页大小
            , SYS_TITLEUSERS.TitleID		//TitleID 
            , SYS_TITLEUSERS.UserID		//UserID 
            , SYS_TITLEUSERS.StartDate  			//开始时间
            , SYS_TITLEUSERS.EndDate  	 		//结束时间
            );
        }
        #endregion

        #region XASYU.BLL层查询方法 query_SYS_USERS_TITLE
        /// <summary>
        /// 查询SYS_TITLEUSERS
        /// query_SYS_TITLEUSERS
        /// 参数类名:SYS_TITLEUSERSModel
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet query_SYS_USERS_TITLE(
              CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.SYS_USERS_TITLEModel SYS_USERS_TITLE
            , ref int V_ITOTALCOUNT //记录数
            , int V_SSTARTINDEX 	//开始索引
            , int V_SPERPAGESIZE 	//页大小
            )
        {
            return XASYU.DBBusiness.DataBaseQuery.query_SYS_USERS_TITLE(
              userBean.YHDLM  //用户登陆名
            , ref V_ITOTALCOUNT 	//记录数
            , V_SSTARTINDEX 		//开始索引
            , V_SPERPAGESIZE 		//页大小
            , SYS_USERS_TITLE.TitleID		//TitleID 
            , SYS_USERS_TITLE.TitleName
            , SYS_USERS_TITLE.UserID		//UserID 
            , SYS_USERS_TITLE.UserName
            , SYS_USERS_TITLE.StartDate  			//开始时间
            , SYS_USERS_TITLE.EndDate  	 		//结束时间
            );
        }
        #endregion

        #region XASYU.BLL层查询方法 query_SYS_USERS_DEPT
        /// <summary>
        /// 查询SYS_TITLEUSERS
        /// query_SYS_TITLEUSERS
        /// 参数类名:SYS_TITLEUSERSModel
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet query_SYS_USERS_DEPT(
              CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.SYS_USERS_DEPTModel SYS_USERS_DEPT
            , ref int V_ITOTALCOUNT //记录数
            , int V_SSTARTINDEX 	//开始索引
            , int V_SPERPAGESIZE 	//页大小
            )
        {
            return XASYU.DBBusiness.DataBaseQuery.query_SYS_USERS_DEPT(
              userBean.YHDLM  //用户登陆名
            , ref V_ITOTALCOUNT 	//记录数
            , V_SSTARTINDEX 		//开始索引
            , V_SPERPAGESIZE 		//页大小
            , SYS_USERS_DEPT.DeptID		//DeptID 
            , SYS_USERS_DEPT.DeptName
            , SYS_USERS_DEPT.UserID		//UserID 
            , SYS_USERS_DEPT.UserName
            , SYS_USERS_DEPT.StartDate  			//开始时间
            , SYS_USERS_DEPT.EndDate  	 		//结束时间
            );
        }
        #endregion

        #region XASYU.BLL层查询方法 query_SYS_USERS_ROLE
        /// <summary>
        /// 查询SYS_ROLEUSERS
        /// query_SYS_TITLEUSERS
        /// 参数类名:SYS_TITLEUSERSModel
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet query_SYS_USERS_ROLE(
              CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.SYS_USERS_ROLEModel SYS_USERS_ROLE
            , ref int V_ITOTALCOUNT //记录数
            , int V_SSTARTINDEX 	//开始索引
            , int V_SPERPAGESIZE 	//页大小
            )
        {
            return XASYU.DBBusiness.DataBaseQuery.query_SYS_USERS_ROLE(
              userBean.YHDLM  //用户登陆名
            , ref V_ITOTALCOUNT 	//记录数
            , V_SSTARTINDEX 		//开始索引
            , V_SPERPAGESIZE 		//页大小
            , SYS_USERS_ROLE.RoleID		//RoleID 
            , SYS_USERS_ROLE.RoleName
            , SYS_USERS_ROLE.UserID		//UserID 
            , SYS_USERS_ROLE.UserName
            , SYS_USERS_ROLE.StartDate  			//开始时间
            , SYS_USERS_ROLE.EndDate  	 		//结束时间
            );
        }
        #endregion

        #endregion

        #region XASYU.BLL层查询方法 query_TABLE_KYTZ
        /// <summary>
        /// 查询TABLE_KYTZ
        /// query_TABLE_KYTZ
        /// 参数类名:TABLE_KYTZModel
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet query_TABLE_KYTZ(
              CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.TABLE_KYTZModel TABLE_KYTZ
            , ref int V_ITOTALCOUNT //记录数
            , int V_SSTARTINDEX 	//开始索引
            , int V_SPERPAGESIZE 	//页大小
            )
        {
            return XASYU.DBBusiness.DataBaseQuery.query_TABLE_KYTZ(
              userBean.YHDLM  //用户登陆名
            , ref V_ITOTALCOUNT 	//记录数
            , V_SSTARTINDEX 		//开始索引
            , V_SPERPAGESIZE 		//页大小
            , TABLE_KYTZ.SerialNO		//SerialNO 
            , TABLE_KYTZ.tzmc		//tzmc 
            , TABLE_KYTZ.tznr		//tznr 
            , TABLE_KYTZ.tzsj		//tzsj 
            , TABLE_KYTZ.tz_enddate		//tz_enddate 
            , TABLE_KYTZ.tzr		//tzr 
                //, TABLE_KYTZ.tzfj		//tzfj 
            , TABLE_KYTZ.tz_remark1		//tz_remark1 
            , TABLE_KYTZ.tz_remark2		//tz_remark2 
            , TABLE_KYTZ.StartDate  			//开始时间
            , TABLE_KYTZ.EndDate  	 		//结束时间
            );
        }
        #endregion

        #region XASYU.BLL层查询方法 query_TABLE_STUDENT
        /// <summary>
        /// 查询TABLE_STUDENT
        /// query_TABLE_STUDENT
        /// 参数类名:TABLE_STUDENTModel
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet query_TABLE_STUDENT(
              CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.TABLE_STUDENTModel TABLE_STUDENT
            , ref int V_ITOTALCOUNT //记录数
            , int V_SSTARTINDEX 	//开始索引
            , int V_SPERPAGESIZE 	//页大小
            )
        {
            return XASYU.DBBusiness.DataBaseQuery.query_TABLE_STUDENT(
              userBean.YHDLM  //用户登陆名
            , ref V_ITOTALCOUNT 	//记录数
            , V_SSTARTINDEX 		//开始索引
            , V_SPERPAGESIZE 		//页大小
            , TABLE_STUDENT.Stu_NO		//Stu_NO 
            , TABLE_STUDENT.Stu_Name		//Stu_Name 
            , TABLE_STUDENT.Stu_Age		//Stu_Age 
            , TABLE_STUDENT.Stu_Zy		//Stu_Zy 
            , TABLE_STUDENT.StartDate  			//开始时间
            , TABLE_STUDENT.EndDate  	 		//结束时间
            );
        }
        #endregion

        #region XASYU.BLL层查询方法 query_TABLE_CYSMS
        /// <summary>
        /// 查询TABLE_CYSMS
        /// query_TABLE_CYSMS
        /// 参数类名:TABLE_CYSMSModel
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet query_TABLE_CYSMS(
              CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.TABLE_CYSMSModel TABLE_CYSMS
            , ref int V_ITOTALCOUNT //记录数
            , int V_SSTARTINDEX     //开始索引
            , int V_SPERPAGESIZE    //页大小
            )
        {
            return XASYU.DBBusiness.DataBaseQuery.query_TABLE_CYSMS(
              userBean.YHDLM  //用户登陆名
            , ref V_ITOTALCOUNT     //记录数
            , V_SSTARTINDEX         //开始索引
            , V_SPERPAGESIZE        //页大小
            , TABLE_CYSMS.CySms_id      //CySms_id 
            , TABLE_CYSMS.CySms_nr      //CySms_nr 
            , TABLE_CYSMS.CySms_lx      //CySms_lx 
            , TABLE_CYSMS.StartDate             //开始时间
            , TABLE_CYSMS.EndDate           //结束时间
            );
        }
        #endregion

        #region XASYU.BLL层查询方法 query_TABLE_SMS
        /// <summary>
        /// 查询TABLE_SMS
        /// query_TABLE_SMS
        /// 参数类名:TABLE_SMSModel
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet query_TABLE_SMS(
              CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.TABLE_SMSModel TABLE_SMS
            , ref int V_ITOTALCOUNT //记录数
            , int V_SSTARTINDEX     //开始索引
            , int V_SPERPAGESIZE    //页大小
            )
        {
            return XASYU.DBBusiness.DataBaseQuery.query_TABLE_SMS(
              userBean.YHDLM  //用户登陆名
            , ref V_ITOTALCOUNT     //记录数
            , V_SSTARTINDEX         //开始索引
            , V_SPERPAGESIZE        //页大小
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
            , TABLE_SMS.StartDate           //开始时间
            , TABLE_SMS.EndDate             //结束时间
            );
        }
        #endregion

        #region XASYU.BLL层查询方法 query_TABLE_SJX
        /// <summary>
        /// 查询TABLE_SJX
        /// query_TABLE_SJX
        /// 参数类名:TABLE_SJXModel
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet query_TABLE_SJX(
              CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.TABLE_SJXModel TABLE_SJX
            , ref int V_ITOTALCOUNT //记录数
            , int V_SSTARTINDEX     //开始索引
            , int V_SPERPAGESIZE    //页大小
            )
        {
            return XASYU.DBBusiness.DataBaseQuery.query_TABLE_SJX(
              userBean.YHDLM  //用户登陆名
            , ref V_ITOTALCOUNT     //记录数
            , V_SSTARTINDEX         //开始索引
            , V_SPERPAGESIZE        //页大小
            , TABLE_SJX.SJX_id      //SJX_id 
            , TABLE_SJX.SJX_mobile      //SJX_mobile 
            , TABLE_SJX.SJX_nr      //SJX_nr 
            , TABLE_SJX.SJX_jstime      //SJX_jstime 
            , TABLE_SJX.StartDate           //开始时间
            , TABLE_SJX.EndDate             //结束时间
            );
        }
        #endregion

        #region XASYU.BLL层查询方法 query_TABLE_DXHF
        /// <summary>
        /// 查询TABLE_DXHF
        /// query_TABLE_DXHF
        /// 参数类名:TABLE_DXHFModel
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet query_TABLE_DXHF(
              CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.TABLE_DXHFModel TABLE_DXHF
            , ref int V_ITOTALCOUNT //记录数
            , int V_SSTARTINDEX     //开始索引
            , int V_SPERPAGESIZE    //页大小
            )
        {
            return XASYU.DBBusiness.DataBaseQuery.query_TABLE_DXHF(
              userBean.YHDLM  //用户登陆名
            , ref V_ITOTALCOUNT     //记录数
            , V_SSTARTINDEX         //开始索引
            , V_SPERPAGESIZE        //页大小
            , TABLE_DXHF.DXHF_id        //DXHF_id 
            , TABLE_DXHF.SMS_id     //SMS_id 
            , TABLE_DXHF.DXHF_hfrmobile     //DXHF_hfrmobile 
            , TABLE_DXHF.DXHF_nr        //DXHF_nr 
            , TABLE_DXHF.DXHF_time      //DXHF_time 
            , TABLE_DXHF.StartDate              //开始时间
            , TABLE_DXHF.EndDate            //结束时间
            );
        }
        #endregion

        #region XASYU.BLL层查询方法 query_TABLE_TXQZ
        /// <summary>
        /// 查询TABLE_TXQZ
        /// query_TABLE_TXQZ
        /// 参数类名:TABLE_TXQZModel
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet query_TABLE_TXQZ(
              CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.TABLE_TXQZModel TABLE_TXQZ
            , ref int V_ITOTALCOUNT //记录数
            , int V_SSTARTINDEX     //开始索引
            , int V_SPERPAGESIZE    //页大小
            )
        {
            return XASYU.DBBusiness.DataBaseQuery.query_TABLE_TXQZ(
              userBean.YHDLM  //用户登陆名
            , ref V_ITOTALCOUNT     //记录数
            , V_SSTARTINDEX         //开始索引
            , V_SPERPAGESIZE        //页大小
            , TABLE_TXQZ.TXQZ_id        //TXQZ_id 
            , TABLE_TXQZ.TXQZ_name      //TXQZ_name 
            , TABLE_TXQZ.TXQZ_sjid      //TXQZ_sjid 
            , TABLE_TXQZ.StartDate              //开始时间
            , TABLE_TXQZ.EndDate            //结束时间
            );
        }
        #endregion

        #region XASYU.BLL层查询方法 query_TABLE_LXR
        /// <summary>
        /// 查询TABLE_LXR
        /// query_TABLE_LXR
        /// 参数类名:TABLE_LXRModel
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet query_TABLE_LXR(
              CykjSoft.Bean.UserBean userBean
            , XASYU.MODEL.TABLE_LXRModel TABLE_LXR
            , ref int V_ITOTALCOUNT //记录数
            , int V_SSTARTINDEX     //开始索引
            , int V_SPERPAGESIZE    //页大小
            )
        {
            return XASYU.DBBusiness.DataBaseQuery.query_TABLE_LXR(
              userBean.YHDLM  //用户登陆名
            , ref V_ITOTALCOUNT     //记录数
            , V_SSTARTINDEX         //开始索引
            , V_SPERPAGESIZE        //页大小
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
            , TABLE_LXR.StartDate           //开始时间
            , TABLE_LXR.EndDate             //结束时间
            );
        }
        #endregion

    }
}
