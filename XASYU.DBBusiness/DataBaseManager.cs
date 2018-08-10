using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDBOSQL;

namespace XASYU.DBBusiness
{
    public class DataBaseManager
    {
        #region XASYU系统框架所用

        #region XASYU.DBBusiness层 操作方法 op_SYS_USERS
        public static void op_SYS_USERS(
              string V_YHDLM  //用户名
            , ref int V_IRESULT //返回值
            , ref int V_IERRCD  //返回错误号
            , ref string V_SERRMSG //返回错误信息
            , string V_SOP //操作类型
            , int V_ID		//ID 
            , string V_Name		//Name 
            , string V_Email		//Email 
            , string V_Password		//Password 
            , bool V_Enabled		//Enabled 
            , string V_Gender		//Gender 
            , string V_ChineseName		//ChineseName 
            , string V_Nation		//Nation 
            , string V_IdentityCard		//IdentityCard 
            , string V_XueLi		//XueLi 
            , string V_XueWei		//XueWei 
            , string V_ZhiWu		//ZhiWu 
            , string V_Political		//Political 
            , string V_YjFx		//YjFx 
            , string V_Address		//Address 
            , string V_EnglishName		//EnglishName 
            , string V_Photo		//Photo 
            , string V_QQ		//QQ 
            , string V_CompanyEmail		//CompanyEmail 
            , string V_OfficePhone		//OfficePhone 
            , string V_OfficePhoneExt		//OfficePhoneExt 
            , string V_HomePhone		//HomePhone 
            , string V_CellPhone		//CellPhone 
            , string V_Remark		//Remark 
            , DateTime V_Birthday		//Birthday 
            , DateTime V_TakeOfficeTime		//TakeOfficeTime 
            , DateTime V_LastLoginTime		//LastLoginTime 
            , DateTime V_CreateTime		//CreateTime 
            , int V_DeptID		//DeptID 
            )
        {
            string mConn = IConfiguration.getParameter("connectString");
            IDBOSQL.IDBO dbo = IDBOSQL.IDBO.getIDBO(mConn);
            try
            {
                dbo.openDatabase();
                dbo.BeginTransaction();
                IPrameter[] pms = new IPrameter[34];
                pms[0] = new IPrameter("@YHDLM", IDataType.VarChar, ParameterDirection.Input);
                pms[0].Value = V_YHDLM;
                pms[1] = new IPrameter("@IRESULT", IDataType.Number, ParameterDirection.Output);
                pms[1].Size = 4;
                pms[2] = new IPrameter("@IERRCD", IDataType.Number, ParameterDirection.Output);
                pms[2].Size = 4;
                pms[3] = new IPrameter("@SERRMSG", IDataType.VarChar, ParameterDirection.Output);
                pms[3].Size = 1024;
                pms[4] = new IPrameter("@SOP", IDataType.VarChar, ParameterDirection.Input);
                pms[4].Value = V_SOP;

                int i = 4;
                i = i + 1;
                pms[i] = new IPrameter("@ID", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_ID;
                i = i + 1;
                pms[i] = new IPrameter("@Name", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_Name;
                i = i + 1;
                pms[i] = new IPrameter("@Email", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_Email;
                i = i + 1;
                pms[i] = new IPrameter("@Password", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_Password;
                i = i + 1;
                pms[i] = new IPrameter("@Enabled", IDataType.Bit, ParameterDirection.Input);
                pms[i].Value = V_Enabled;
                i = i + 1;
                pms[i] = new IPrameter("@Gender", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_Gender;
                i = i + 1;
                pms[i] = new IPrameter("@ChineseName", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_ChineseName;
                i = i + 1;
                pms[i] = new IPrameter("@Nation", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_Nation;
                i = i + 1;
                pms[i] = new IPrameter("@IdentityCard", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_IdentityCard;
                i = i + 1;
                pms[i] = new IPrameter("@XueLi", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_XueLi;
                i = i + 1;
                pms[i] = new IPrameter("@XueWei", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_XueWei;
                i = i + 1;
                pms[i] = new IPrameter("@ZhiWu", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_ZhiWu;
                i = i + 1;
                pms[i] = new IPrameter("@Political", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_Political;
                i = i + 1;
                pms[i] = new IPrameter("@YjFx", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_YjFx;
                i = i + 1;
                pms[i] = new IPrameter("@Address", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_Address;
                i = i + 1;
                pms[i] = new IPrameter("@EnglishName", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_EnglishName;
                i = i + 1;
                pms[i] = new IPrameter("@Photo", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_Photo;
                i = i + 1;
                pms[i] = new IPrameter("@QQ", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_QQ;
                i = i + 1;
                pms[i] = new IPrameter("@CompanyEmail", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_CompanyEmail;
                i = i + 1;
                pms[i] = new IPrameter("@OfficePhone", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_OfficePhone;
                i = i + 1;
                pms[i] = new IPrameter("@OfficePhoneExt", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_OfficePhoneExt;
                i = i + 1;
                pms[i] = new IPrameter("@HomePhone", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_HomePhone;
                i = i + 1;
                pms[i] = new IPrameter("@CellPhone", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_CellPhone;
                i = i + 1;
                pms[i] = new IPrameter("@Remark", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_Remark;
                i = i + 1;
                pms[i] = new IPrameter("@Birthday", IDataType.DateTime, ParameterDirection.Input);
                pms[i].Value = V_Birthday;
                i = i + 1;
                pms[i] = new IPrameter("@TakeOfficeTime", IDataType.DateTime, ParameterDirection.Input);
                pms[i].Value = V_TakeOfficeTime;
                i = i + 1;
                pms[i] = new IPrameter("@LastLoginTime", IDataType.DateTime, ParameterDirection.Input);
                pms[i].Value = V_LastLoginTime;
                i = i + 1;
                pms[i] = new IPrameter("@CreateTime", IDataType.DateTime, ParameterDirection.Input);
                pms[i].Value = V_CreateTime;
                i = i + 1;
                pms[i] = new IPrameter("@DeptID", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_DeptID;

                dbo.executeFunction("op_sys_Users", pms);
                dbo.CommitTransaction();
                V_IRESULT = int.Parse(pms[1].Value.ToString());
                V_IERRCD = int.Parse(pms[2].Value.ToString());
                V_SERRMSG = pms[3].Value.ToString();
            }
            catch (Exception e)
            {
                //iLog.Error(e.Message.ToString());
                //throw e;
                V_IRESULT = -1;
                V_IERRCD = -1;
                V_SERRMSG = e.Message.ToString();
                return;
            }
            finally
            {
                dbo.closeDatabase();
            }
        }
        #endregion

        #region XASYU.DBBusiness层 操作方法 op_SYS_CONFIGS
        public static void op_SYS_CONFIGS(
              string V_YHDLM  //用户名
            , ref int V_IRESULT //返回值
            , ref int V_IERRCD  //返回错误号
            , ref string V_SERRMSG //返回错误信息
            , string V_SOP //操作类型
            , int V_ID		//ID 
            , string V_ConfigKey		//ConfigKey 
            , string V_ConfigValue		//ConfigValue 
            , string V_Remark		//Remark 
            )
        {
            string mConn = IConfiguration.getParameter("connectString");
            IDBOSQL.IDBO dbo = IDBOSQL.IDBO.getIDBO(mConn);
            try
            {
                dbo.openDatabase();
                dbo.BeginTransaction();
                IPrameter[] pms = new IPrameter[9];
                pms[0] = new IPrameter("@YHDLM", IDataType.VarChar, ParameterDirection.Input);
                pms[0].Value = V_YHDLM;
                pms[1] = new IPrameter("@IRESULT", IDataType.Number, ParameterDirection.Output);
                pms[1].Size = 4;
                pms[2] = new IPrameter("@IERRCD", IDataType.Number, ParameterDirection.Output);
                pms[2].Size = 4;
                pms[3] = new IPrameter("@SERRMSG", IDataType.VarChar, ParameterDirection.Output);
                pms[3].Size = 1024;
                pms[4] = new IPrameter("@SOP", IDataType.VarChar, ParameterDirection.Input);
                pms[4].Value = V_SOP;

                int i = 4;
                i = i + 1;
                pms[i] = new IPrameter("@ID", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_ID;
                i = i + 1;
                pms[i] = new IPrameter("@ConfigKey", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_ConfigKey;
                i = i + 1;
                pms[i] = new IPrameter("@ConfigValue", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_ConfigValue;
                i = i + 1;
                pms[i] = new IPrameter("@Remark", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_Remark;

                dbo.executeFunction("op_sys_Configs", pms);
                dbo.CommitTransaction();
                V_IRESULT = int.Parse(pms[1].Value.ToString());
                V_IERRCD = int.Parse(pms[2].Value.ToString());
                V_SERRMSG = pms[3].Value.ToString();
            }
            catch (Exception e)
            {
                //iLog.Error(e.Message.ToString());
                //throw e;
                V_IRESULT = -1;
                V_IERRCD = -1;
                V_SERRMSG = e.Message.ToString();
                return;
            }
            finally
            {
                dbo.closeDatabase();
            }
        }
        #endregion

        #region XASYU.DBBusiness层 操作方法 op_SYS_DEPTS
        public static void op_SYS_DEPTS(
              string V_YHDLM  //用户名
            , ref int V_IRESULT //返回值
            , ref int V_IERRCD  //返回错误号
            , ref string V_SERRMSG //返回错误信息
            , string V_SOP //操作类型
            , int V_ID		//ID 
            , string V_Name		//Name 
            , int V_SortIndex		//SortIndex 
            , string V_Remark		//Remark 
            , int V_ParentID		//ParentID 
            , string V_DeptLeader		//DeptLeader 
            , string V_DeptTel		//DeptTel 
            )
        {
            string mConn = IConfiguration.getParameter("connectString");
            IDBOSQL.IDBO dbo = IDBOSQL.IDBO.getIDBO(mConn);
            try
            {
                dbo.openDatabase();
                dbo.BeginTransaction();
                IPrameter[] pms = new IPrameter[12];
                pms[0] = new IPrameter("@YHDLM", IDataType.VarChar, ParameterDirection.Input);
                pms[0].Value = V_YHDLM;
                pms[1] = new IPrameter("@IRESULT", IDataType.Number, ParameterDirection.Output);
                pms[1].Size = 4;
                pms[2] = new IPrameter("@IERRCD", IDataType.Number, ParameterDirection.Output);
                pms[2].Size = 4;
                pms[3] = new IPrameter("@SERRMSG", IDataType.VarChar, ParameterDirection.Output);
                pms[3].Size = 1024;
                pms[4] = new IPrameter("@SOP", IDataType.VarChar, ParameterDirection.Input);
                pms[4].Value = V_SOP;

                int i = 4;
                i = i + 1;
                pms[i] = new IPrameter("@ID", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_ID;
                i = i + 1;
                pms[i] = new IPrameter("@Name", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_Name;
                i = i + 1;
                pms[i] = new IPrameter("@SortIndex", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_SortIndex;
                i = i + 1;
                pms[i] = new IPrameter("@Remark", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_Remark;
                i = i + 1;
                pms[i] = new IPrameter("@ParentID", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_ParentID;
                i = i + 1;
                pms[i] = new IPrameter("@DeptLeader", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_DeptLeader;
                i = i + 1;
                pms[i] = new IPrameter("@DeptTel", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_DeptTel;

                dbo.executeFunction("op_sys_Depts", pms);
                dbo.CommitTransaction();
                V_IRESULT = int.Parse(pms[1].Value.ToString());
                V_IERRCD = int.Parse(pms[2].Value.ToString());
                V_SERRMSG = pms[3].Value.ToString();
            }
            catch (Exception e)
            {
                //iLog.Error(e.Message.ToString());
                //throw e;
                V_IRESULT = -1;
                V_IERRCD = -1;
                V_SERRMSG = e.Message.ToString();
                return;
            }
            finally
            {
                dbo.closeDatabase();
            }
        }
        #endregion

        #region XASYU.DBBusiness层 操作方法 op_SYS_LOGS
        public static void op_SYS_LOGS(
              string V_YHDLM  //用户名
            , ref int V_IRESULT //返回值
            , ref int V_IERRCD  //返回错误号
            , ref string V_SERRMSG //返回错误信息
            , string V_SOP //操作类型
            , int V_ID		//ID 
            , string V_Level		//Level 
            , string V_Logger		//Logger 
            , string V_Message		//Message 
            , string V_Exception		//Exception 
            , DateTime V_LogTime		//LogTime 
            )
        {
            string mConn = IConfiguration.getParameter("connectString");
            IDBOSQL.IDBO dbo = IDBOSQL.IDBO.getIDBO(mConn);
            try
            {
                dbo.openDatabase();
                dbo.BeginTransaction();
                IPrameter[] pms = new IPrameter[11];
                pms[0] = new IPrameter("@YHDLM", IDataType.VarChar, ParameterDirection.Input);
                pms[0].Value = V_YHDLM;
                pms[1] = new IPrameter("@IRESULT", IDataType.Number, ParameterDirection.Output);
                pms[1].Size = 4;
                pms[2] = new IPrameter("@IERRCD", IDataType.Number, ParameterDirection.Output);
                pms[2].Size = 4;
                pms[3] = new IPrameter("@SERRMSG", IDataType.VarChar, ParameterDirection.Output);
                pms[3].Size = 1024;
                pms[4] = new IPrameter("@SOP", IDataType.VarChar, ParameterDirection.Input);
                pms[4].Value = V_SOP;

                int i = 4;
                i = i + 1;
                pms[i] = new IPrameter("@ID", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_ID;
                i = i + 1;
                pms[i] = new IPrameter("@Level", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_Level;
                i = i + 1;
                pms[i] = new IPrameter("@Logger", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_Logger;
                i = i + 1;
                pms[i] = new IPrameter("@Message", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_Message;
                i = i + 1;
                pms[i] = new IPrameter("@Exception", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_Exception;
                i = i + 1;
                pms[i] = new IPrameter("@LogTime", IDataType.DateTime, ParameterDirection.Input);
                pms[i].Value = V_LogTime;

                dbo.executeFunction("op_sys_Logs", pms);
                dbo.CommitTransaction();
                V_IRESULT = int.Parse(pms[1].Value.ToString());
                V_IERRCD = int.Parse(pms[2].Value.ToString());
                V_SERRMSG = pms[3].Value.ToString();
            }
            catch (Exception e)
            {
                //iLog.Error(e.Message.ToString());
                //throw e;
                V_IRESULT = -1;
                V_IERRCD = -1;
                V_SERRMSG = e.Message.ToString();
                return;
            }
            finally
            {
                dbo.closeDatabase();
            }
        }
        #endregion

        #region XASYU.DBBusiness层 操作方法 op_SYS_MENUS
        public static void op_SYS_MENUS(
              string V_YHDLM  //用户名
            , ref int V_IRESULT //返回值
            , ref int V_IERRCD  //返回错误号
            , ref string V_SERRMSG //返回错误信息
            , string V_SOP //操作类型
            , int V_ID		//ID 
            , string V_Name		//Name 
            , string V_ImageUrl		//ImageUrl 
            , string V_NavigateUrl		//NavigateUrl 
            , string V_Remark		//Remark 
            , int V_SortIndex		//SortIndex 
            , int V_ParentID		//ParentID 
            , int V_ViewPowerID		//ViewPowerID 
            )
        {
            string mConn = IConfiguration.getParameter("connectString");
            IDBOSQL.IDBO dbo = IDBOSQL.IDBO.getIDBO(mConn);
            try
            {
                dbo.openDatabase();
                dbo.BeginTransaction();
                IPrameter[] pms = new IPrameter[13];
                pms[0] = new IPrameter("@YHDLM", IDataType.VarChar, ParameterDirection.Input);
                pms[0].Value = V_YHDLM;
                pms[1] = new IPrameter("@IRESULT", IDataType.Number, ParameterDirection.Output);
                pms[1].Size = 4;
                pms[2] = new IPrameter("@IERRCD", IDataType.Number, ParameterDirection.Output);
                pms[2].Size = 4;
                pms[3] = new IPrameter("@SERRMSG", IDataType.VarChar, ParameterDirection.Output);
                pms[3].Size = 1024;
                pms[4] = new IPrameter("@SOP", IDataType.VarChar, ParameterDirection.Input);
                pms[4].Value = V_SOP;

                int i = 4;
                i = i + 1;
                pms[i] = new IPrameter("@ID", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_ID;
                i = i + 1;
                pms[i] = new IPrameter("@Name", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_Name;
                i = i + 1;
                pms[i] = new IPrameter("@ImageUrl", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_ImageUrl;
                i = i + 1;
                pms[i] = new IPrameter("@NavigateUrl", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_NavigateUrl;
                i = i + 1;
                pms[i] = new IPrameter("@Remark", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_Remark;
                i = i + 1;
                pms[i] = new IPrameter("@SortIndex", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_SortIndex;
                i = i + 1;
                pms[i] = new IPrameter("@ParentID", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_ParentID;
                i = i + 1;
                pms[i] = new IPrameter("@ViewPowerID", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_ViewPowerID;

                dbo.executeFunction("op_sys_Menus", pms);
                dbo.CommitTransaction();
                V_IRESULT = int.Parse(pms[1].Value.ToString());
                V_IERRCD = int.Parse(pms[2].Value.ToString());
                V_SERRMSG = pms[3].Value.ToString();
            }
            catch (Exception e)
            {
                //iLog.Error(e.Message.ToString());
                //throw e;
                V_IRESULT = -1;
                V_IERRCD = -1;
                V_SERRMSG = e.Message.ToString();
                return;
            }
            finally
            {
                dbo.closeDatabase();
            }
        }
        #endregion

        #region XASYU.DBBusiness层 操作方法 op_SYS_ONLINES
        public static void op_SYS_ONLINES(
              string V_YHDLM  //用户名
            , ref int V_IRESULT //返回值
            , ref int V_IERRCD  //返回错误号
            , ref string V_SERRMSG //返回错误信息
            , string V_SOP //操作类型
            , int V_ID		//ID 
            , string V_IPAdddress		//IPAdddress 
            , DateTime V_LoginTime		//LoginTime 
            , DateTime V_UpdateTime		//UpdateTime 
            , int V_UserID		//UserID 
            )
        {
            string mConn = IConfiguration.getParameter("connectString");
            IDBOSQL.IDBO dbo = IDBOSQL.IDBO.getIDBO(mConn);
            try
            {
                dbo.openDatabase();
                dbo.BeginTransaction();
                IPrameter[] pms = new IPrameter[10];
                pms[0] = new IPrameter("@YHDLM", IDataType.VarChar, ParameterDirection.Input);
                pms[0].Value = V_YHDLM;
                pms[1] = new IPrameter("@IRESULT", IDataType.Number, ParameterDirection.Output);
                pms[1].Size = 4;
                pms[2] = new IPrameter("@IERRCD", IDataType.Number, ParameterDirection.Output);
                pms[2].Size = 4;
                pms[3] = new IPrameter("@SERRMSG", IDataType.VarChar, ParameterDirection.Output);
                pms[3].Size = 1024;
                pms[4] = new IPrameter("@SOP", IDataType.VarChar, ParameterDirection.Input);
                pms[4].Value = V_SOP;

                int i = 4;
                i = i + 1;
                pms[i] = new IPrameter("@ID", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_ID;
                i = i + 1;
                pms[i] = new IPrameter("@IPAdddress", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_IPAdddress;
                i = i + 1;
                pms[i] = new IPrameter("@LoginTime", IDataType.DateTime, ParameterDirection.Input);
                pms[i].Value = V_LoginTime;
                i = i + 1;
                pms[i] = new IPrameter("@UpdateTime", IDataType.DateTime, ParameterDirection.Input);
                pms[i].Value = V_UpdateTime;
                i = i + 1;
                pms[i] = new IPrameter("@UserID", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_UserID;

                dbo.executeFunction("op_sys_Onlines", pms);
                dbo.CommitTransaction();
                V_IRESULT = int.Parse(pms[1].Value.ToString());
                V_IERRCD = int.Parse(pms[2].Value.ToString());
                V_SERRMSG = pms[3].Value.ToString();
            }
            catch (Exception e)
            {
                //iLog.Error(e.Message.ToString());
                //throw e;
                V_IRESULT = -1;
                V_IERRCD = -1;
                V_SERRMSG = e.Message.ToString();
                return;
            }
            finally
            {
                dbo.closeDatabase();
            }
        }
        #endregion

        #region XASYU.DBBusiness层 操作方法 op_SYS_POWERS
        public static void op_SYS_POWERS(
              string V_YHDLM  //用户名
            , ref int V_IRESULT //返回值
            , ref int V_IERRCD  //返回错误号
            , ref string V_SERRMSG //返回错误信息
            , string V_SOP //操作类型
            , int V_ID		//ID 
            , string V_Name		//Name 
            , string V_GroupName		//GroupName 
            , string V_Title		//Title 
            , string V_Remark		//Remark 
            )
        {
            string mConn = IConfiguration.getParameter("connectString");
            IDBOSQL.IDBO dbo = IDBOSQL.IDBO.getIDBO(mConn);
            try
            {
                dbo.openDatabase();
                dbo.BeginTransaction();
                IPrameter[] pms = new IPrameter[10];
                pms[0] = new IPrameter("@YHDLM", IDataType.VarChar, ParameterDirection.Input);
                pms[0].Value = V_YHDLM;
                pms[1] = new IPrameter("@IRESULT", IDataType.Number, ParameterDirection.Output);
                pms[1].Size = 4;
                pms[2] = new IPrameter("@IERRCD", IDataType.Number, ParameterDirection.Output);
                pms[2].Size = 4;
                pms[3] = new IPrameter("@SERRMSG", IDataType.VarChar, ParameterDirection.Output);
                pms[3].Size = 1024;
                pms[4] = new IPrameter("@SOP", IDataType.VarChar, ParameterDirection.Input);
                pms[4].Value = V_SOP;

                int i = 4;
                i = i + 1;
                pms[i] = new IPrameter("@ID", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_ID;
                i = i + 1;
                pms[i] = new IPrameter("@Name", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_Name;
                i = i + 1;
                pms[i] = new IPrameter("@GroupName", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_GroupName;
                i = i + 1;
                pms[i] = new IPrameter("@Title", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_Title;
                i = i + 1;
                pms[i] = new IPrameter("@Remark", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_Remark;

                dbo.executeFunction("op_sys_Powers", pms);
                dbo.CommitTransaction();
                V_IRESULT = int.Parse(pms[1].Value.ToString());
                V_IERRCD = int.Parse(pms[2].Value.ToString());
                V_SERRMSG = pms[3].Value.ToString();
            }
            catch (Exception e)
            {
                //iLog.Error(e.Message.ToString());
                //throw e;
                V_IRESULT = -1;
                V_IERRCD = -1;
                V_SERRMSG = e.Message.ToString();
                return;
            }
            finally
            {
                dbo.closeDatabase();
            }
        }
        #endregion

        #region XASYU.DBBusiness层 操作方法 op_SYS_ROLEPOWERS
        public static void op_SYS_ROLEPOWERS(
              string V_YHDLM  //用户名
            , ref int V_IRESULT //返回值
            , ref int V_IERRCD  //返回错误号
            , ref string V_SERRMSG //返回错误信息
            , string V_SOP //操作类型
            , int V_RoleID		//RoleID 
            , int V_PowerID		//PowerID 
            )
        {
            string mConn = IConfiguration.getParameter("connectString");
            IDBOSQL.IDBO dbo = IDBOSQL.IDBO.getIDBO(mConn);
            try
            {
                dbo.openDatabase();
                dbo.BeginTransaction();
                IPrameter[] pms = new IPrameter[7];
                pms[0] = new IPrameter("@YHDLM", IDataType.VarChar, ParameterDirection.Input);
                pms[0].Value = V_YHDLM;
                pms[1] = new IPrameter("@IRESULT", IDataType.Number, ParameterDirection.Output);
                pms[1].Size = 4;
                pms[2] = new IPrameter("@IERRCD", IDataType.Number, ParameterDirection.Output);
                pms[2].Size = 4;
                pms[3] = new IPrameter("@SERRMSG", IDataType.VarChar, ParameterDirection.Output);
                pms[3].Size = 1024;
                pms[4] = new IPrameter("@SOP", IDataType.VarChar, ParameterDirection.Input);
                pms[4].Value = V_SOP;

                int i = 4;
                i = i + 1;
                pms[i] = new IPrameter("@RoleID", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_RoleID;
                i = i + 1;
                pms[i] = new IPrameter("@PowerID", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_PowerID;

                dbo.executeFunction("op_sys_RolePowers", pms);
                dbo.CommitTransaction();
                V_IRESULT = int.Parse(pms[1].Value.ToString());
                V_IERRCD = int.Parse(pms[2].Value.ToString());
                V_SERRMSG = pms[3].Value.ToString();
            }
            catch (Exception e)
            {
                //iLog.Error(e.Message.ToString());
                //throw e;
                V_IRESULT = -1;
                V_IERRCD = -1;
                V_SERRMSG = e.Message.ToString();
                return;
            }
            finally
            {
                dbo.closeDatabase();
            }
        }
        #endregion

        #region XASYU.DBBusiness层 操作方法 op_SYS_ROLES
        public static void op_SYS_ROLES(
              string V_YHDLM  //用户名
            , ref int V_IRESULT //返回值
            , ref int V_IERRCD  //返回错误号
            , ref string V_SERRMSG //返回错误信息
            , string V_SOP //操作类型
            , int V_ID		//ID 
            , string V_Name		//Name 
            , string V_Remark		//Remark 
            )
        {
            string mConn = IConfiguration.getParameter("connectString");
            IDBOSQL.IDBO dbo = IDBOSQL.IDBO.getIDBO(mConn);
            try
            {
                dbo.openDatabase();
                dbo.BeginTransaction();
                IPrameter[] pms = new IPrameter[8];
                pms[0] = new IPrameter("@YHDLM", IDataType.VarChar, ParameterDirection.Input);
                pms[0].Value = V_YHDLM;
                pms[1] = new IPrameter("@IRESULT", IDataType.Number, ParameterDirection.Output);
                pms[1].Size = 4;
                pms[2] = new IPrameter("@IERRCD", IDataType.Number, ParameterDirection.Output);
                pms[2].Size = 4;
                pms[3] = new IPrameter("@SERRMSG", IDataType.VarChar, ParameterDirection.Output);
                pms[3].Size = 1024;
                pms[4] = new IPrameter("@SOP", IDataType.VarChar, ParameterDirection.Input);
                pms[4].Value = V_SOP;

                int i = 4;
                i = i + 1;
                pms[i] = new IPrameter("@ID", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_ID;
                i = i + 1;
                pms[i] = new IPrameter("@Name", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_Name;
                i = i + 1;
                pms[i] = new IPrameter("@Remark", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_Remark;

                dbo.executeFunction("op_sys_Roles", pms);
                dbo.CommitTransaction();
                V_IRESULT = int.Parse(pms[1].Value.ToString());
                V_IERRCD = int.Parse(pms[2].Value.ToString());
                V_SERRMSG = pms[3].Value.ToString();
            }
            catch (Exception e)
            {
                //iLog.Error(e.Message.ToString());
                //throw e;
                V_IRESULT = -1;
                V_IERRCD = -1;
                V_SERRMSG = e.Message.ToString();
                return;
            }
            finally
            {
                dbo.closeDatabase();
            }
        }
        #endregion

        #region XASYU.DBBusiness层 操作方法 op_SYS_ROLEUSERS
        public static void op_SYS_ROLEUSERS(
              string V_YHDLM  //用户名
            , ref int V_IRESULT //返回值
            , ref int V_IERRCD  //返回错误号
            , ref string V_SERRMSG //返回错误信息
            , string V_SOP //操作类型
            , int V_RoleID		//RoleID 
            , int V_UserID		//UserID 
            )
        {
            string mConn = IConfiguration.getParameter("connectString");
            IDBOSQL.IDBO dbo = IDBOSQL.IDBO.getIDBO(mConn);
            try
            {
                dbo.openDatabase();
                dbo.BeginTransaction();
                IPrameter[] pms = new IPrameter[7];
                pms[0] = new IPrameter("@YHDLM", IDataType.VarChar, ParameterDirection.Input);
                pms[0].Value = V_YHDLM;
                pms[1] = new IPrameter("@IRESULT", IDataType.Number, ParameterDirection.Output);
                pms[1].Size = 4;
                pms[2] = new IPrameter("@IERRCD", IDataType.Number, ParameterDirection.Output);
                pms[2].Size = 4;
                pms[3] = new IPrameter("@SERRMSG", IDataType.VarChar, ParameterDirection.Output);
                pms[3].Size = 1024;
                pms[4] = new IPrameter("@SOP", IDataType.VarChar, ParameterDirection.Input);
                pms[4].Value = V_SOP;

                int i = 4;
                i = i + 1;
                pms[i] = new IPrameter("@RoleID", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_RoleID;
                i = i + 1;
                pms[i] = new IPrameter("@UserID", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_UserID;

                dbo.executeFunction("op_sys_RoleUsers", pms);
                dbo.CommitTransaction();
                V_IRESULT = int.Parse(pms[1].Value.ToString());
                V_IERRCD = int.Parse(pms[2].Value.ToString());
                V_SERRMSG = pms[3].Value.ToString();
            }
            catch (Exception e)
            {
                //iLog.Error(e.Message.ToString());
                //throw e;
                V_IRESULT = -1;
                V_IERRCD = -1;
                V_SERRMSG = e.Message.ToString();
                return;
            }
            finally
            {
                dbo.closeDatabase();
            }
        }
        #endregion

        #region XASYU.DBBusiness层 操作方法 op_SYS_TITLES
        public static void op_SYS_TITLES(
              string V_YHDLM  //用户名
            , ref int V_IRESULT //返回值
            , ref int V_IERRCD  //返回错误号
            , ref string V_SERRMSG //返回错误信息
            , string V_SOP //操作类型
            , int V_ID		//ID 
            , string V_Name		//Name 
            , string V_Remark		//Remark 
            )
        {
            string mConn = IConfiguration.getParameter("connectString");
            IDBOSQL.IDBO dbo = IDBOSQL.IDBO.getIDBO(mConn);
            try
            {
                dbo.openDatabase();
                dbo.BeginTransaction();
                IPrameter[] pms = new IPrameter[8];
                pms[0] = new IPrameter("@YHDLM", IDataType.VarChar, ParameterDirection.Input);
                pms[0].Value = V_YHDLM;
                pms[1] = new IPrameter("@IRESULT", IDataType.Number, ParameterDirection.Output);
                pms[1].Size = 4;
                pms[2] = new IPrameter("@IERRCD", IDataType.Number, ParameterDirection.Output);
                pms[2].Size = 4;
                pms[3] = new IPrameter("@SERRMSG", IDataType.VarChar, ParameterDirection.Output);
                pms[3].Size = 1024;
                pms[4] = new IPrameter("@SOP", IDataType.VarChar, ParameterDirection.Input);
                pms[4].Value = V_SOP;

                int i = 4;
                i = i + 1;
                pms[i] = new IPrameter("@ID", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_ID;
                i = i + 1;
                pms[i] = new IPrameter("@Name", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_Name;
                i = i + 1;
                pms[i] = new IPrameter("@Remark", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_Remark;

                dbo.executeFunction("op_sys_Titles", pms);
                dbo.CommitTransaction();
                V_IRESULT = int.Parse(pms[1].Value.ToString());
                V_IERRCD = int.Parse(pms[2].Value.ToString());
                V_SERRMSG = pms[3].Value.ToString();
            }
            catch (Exception e)
            {
                //iLog.Error(e.Message.ToString());
                //throw e;
                V_IRESULT = -1;
                V_IERRCD = -1;
                V_SERRMSG = e.Message.ToString();
                return;
            }
            finally
            {
                dbo.closeDatabase();
            }
        }
        #endregion

        #region XASYU.DBBusiness层 操作方法 op_SYS_TITLEUSERS
        public static void op_SYS_TITLEUSERS(
              string V_YHDLM  //用户名
            , ref int V_IRESULT //返回值
            , ref int V_IERRCD  //返回错误号
            , ref string V_SERRMSG //返回错误信息
            , string V_SOP //操作类型
            , int V_TitleID		//TitleID 
            , int V_UserID		//UserID 
            )
        {
            string mConn = IConfiguration.getParameter("connectString");
            IDBOSQL.IDBO dbo = IDBOSQL.IDBO.getIDBO(mConn);
            try
            {
                dbo.openDatabase();
                dbo.BeginTransaction();
                IPrameter[] pms = new IPrameter[7];
                pms[0] = new IPrameter("@YHDLM", IDataType.VarChar, ParameterDirection.Input);
                pms[0].Value = V_YHDLM;
                pms[1] = new IPrameter("@IRESULT", IDataType.Number, ParameterDirection.Output);
                pms[1].Size = 4;
                pms[2] = new IPrameter("@IERRCD", IDataType.Number, ParameterDirection.Output);
                pms[2].Size = 4;
                pms[3] = new IPrameter("@SERRMSG", IDataType.VarChar, ParameterDirection.Output);
                pms[3].Size = 1024;
                pms[4] = new IPrameter("@SOP", IDataType.VarChar, ParameterDirection.Input);
                pms[4].Value = V_SOP;

                int i = 4;
                i = i + 1;
                pms[i] = new IPrameter("@TitleID", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_TitleID;
                i = i + 1;
                pms[i] = new IPrameter("@UserID", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_UserID;

                dbo.executeFunction("op_sys_TitleUsers", pms);
                dbo.CommitTransaction();
                V_IRESULT = int.Parse(pms[1].Value.ToString());
                V_IERRCD = int.Parse(pms[2].Value.ToString());
                V_SERRMSG = pms[3].Value.ToString();
            }
            catch (Exception e)
            {
                //iLog.Error(e.Message.ToString());
                //throw e;
                V_IRESULT = -1;
                V_IERRCD = -1;
                V_SERRMSG = e.Message.ToString();
                return;
            }
            finally
            {
                dbo.closeDatabase();
            }
        }
        #endregion

        #region XASYU.DBBusiness层 操作方法 op_SYS_USERS_ROLE
        public static void op_SYS_USERS_ROLE(
              string V_YHDLM  //用户名
            , ref int V_IRESULT //返回值
            , ref int V_IERRCD  //返回错误号
            , ref string V_SERRMSG //返回错误信息
            , string V_SOP //操作类型
            , int V_RoleID		//RoleID 
            , int V_UserID		//UserID 
            )
        {
            string mConn = IConfiguration.getParameter("connectString");
            IDBOSQL.IDBO dbo = IDBOSQL.IDBO.getIDBO(mConn);
            try
            {
                dbo.openDatabase();
                dbo.BeginTransaction();
                IPrameter[] pms = new IPrameter[7];
                pms[0] = new IPrameter("@YHDLM", IDataType.VarChar, ParameterDirection.Input);
                pms[0].Value = V_YHDLM;
                pms[1] = new IPrameter("@IRESULT", IDataType.Number, ParameterDirection.Output);
                pms[1].Size = 4;
                pms[2] = new IPrameter("@IERRCD", IDataType.Number, ParameterDirection.Output);
                pms[2].Size = 4;
                pms[3] = new IPrameter("@SERRMSG", IDataType.VarChar, ParameterDirection.Output);
                pms[3].Size = 1024;
                pms[4] = new IPrameter("@SOP", IDataType.VarChar, ParameterDirection.Input);
                pms[4].Value = V_SOP;

                int i = 4;
                i = i + 1;
                pms[i] = new IPrameter("@RoleID", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_RoleID;
                i = i + 1;
                pms[i] = new IPrameter("@UserID", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_UserID;

                dbo.executeFunction("op_sys_Users_Role", pms);
                dbo.CommitTransaction();
                V_IRESULT = int.Parse(pms[1].Value.ToString());
                V_IERRCD = int.Parse(pms[2].Value.ToString());
                V_SERRMSG = pms[3].Value.ToString();
            }
            catch (Exception e)
            {
                //iLog.Error(e.Message.ToString());
                //throw e;
                V_IRESULT = -1;
                V_IERRCD = -1;
                V_SERRMSG = e.Message.ToString();
                return;
            }
            finally
            {
                dbo.closeDatabase();
            }
        }
        #endregion

        #region XASYU.DBBusiness层 操作方法 op_SYS_USERS_TITLE
        public static void op_SYS_USERS_TITLE(
              string V_YHDLM  //用户名
            , ref int V_IRESULT //返回值
            , ref int V_IERRCD  //返回错误号
            , ref string V_SERRMSG //返回错误信息
            , string V_SOP //操作类型
            , int V_TitleID		//PowerID 
            , int V_UserID		//UserID 
            )
        {
            string mConn = IConfiguration.getParameter("connectString");
            IDBOSQL.IDBO dbo = IDBOSQL.IDBO.getIDBO(mConn);
            try
            {
                dbo.openDatabase();
                dbo.BeginTransaction();
                IPrameter[] pms = new IPrameter[7];
                pms[0] = new IPrameter("@YHDLM", IDataType.VarChar, ParameterDirection.Input);
                pms[0].Value = V_YHDLM;
                pms[1] = new IPrameter("@IRESULT", IDataType.Number, ParameterDirection.Output);
                pms[1].Size = 4;
                pms[2] = new IPrameter("@IERRCD", IDataType.Number, ParameterDirection.Output);
                pms[2].Size = 4;
                pms[3] = new IPrameter("@SERRMSG", IDataType.VarChar, ParameterDirection.Output);
                pms[3].Size = 1024;
                pms[4] = new IPrameter("@SOP", IDataType.VarChar, ParameterDirection.Input);
                pms[4].Value = V_SOP;

                int i = 4;
                i = i + 1;
                pms[i] = new IPrameter("@TitleID", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_TitleID;
                i = i + 1;
                pms[i] = new IPrameter("@UserID", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_UserID;

                dbo.executeFunction("op_sys_Users_Title", pms);
                dbo.CommitTransaction();
                V_IRESULT = int.Parse(pms[1].Value.ToString());
                V_IERRCD = int.Parse(pms[2].Value.ToString());
                V_SERRMSG = pms[3].Value.ToString();
            }
            catch (Exception e)
            {
                //iLog.Error(e.Message.ToString());
                //throw e;
                V_IRESULT = -1;
                V_IERRCD = -1;
                V_SERRMSG = e.Message.ToString();
                return;
            }
            finally
            {
                dbo.closeDatabase();
            }
        }
        #endregion

        #endregion

        #region XASYU.DBBusiness层 操作方法 op_TABLE_KYTZ
        public static void op_TABLE_KYTZ(
              string V_YHDLM  //用户名
            , ref int V_IRESULT //返回值
            , ref int V_IERRCD  //返回错误号
            , ref string V_SERRMSG //返回错误信息
            , string V_SOP //操作类型
            , long V_SerialNO		//SerialNO 
            , string V_tzmc		//tzmc 
            , string V_tznr		//tznr 
            , DateTime V_tzsj		//tzsj 
            , DateTime V_tz_enddate		//tz_enddate 
            , string V_tzr		//tzr 
            //, byte[] V_tzfj		//tzfj 
            , string V_tz_remark1		//tz_remark1 
            , string V_tz_remark2		//tz_remark2 
            )
        {
            string mConn = IConfiguration.getParameter("connectString");
            IDBOSQL.IDBO dbo = IDBOSQL.IDBO.getIDBO(mConn);
            try
            {
                dbo.openDatabase();
                dbo.BeginTransaction();
                IPrameter[] pms = new IPrameter[13];
                pms[0] = new IPrameter("@YHDLM", IDataType.VarChar, ParameterDirection.Input);
                pms[0].Value = V_YHDLM;
                pms[1] = new IPrameter("@IRESULT", IDataType.Number, ParameterDirection.Output);
                pms[1].Size = 4;
                pms[2] = new IPrameter("@IERRCD", IDataType.Number, ParameterDirection.Output);
                pms[2].Size = 4;
                pms[3] = new IPrameter("@SERRMSG", IDataType.VarChar, ParameterDirection.Output);
                pms[3].Size = 1024;
                pms[4] = new IPrameter("@SOP", IDataType.VarChar, ParameterDirection.Input);
                pms[4].Value = V_SOP;

                int i = 4;
                i = i + 1;
                pms[i] = new IPrameter("@SerialNO", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_SerialNO;
                i = i + 1;
                pms[i] = new IPrameter("@tzmc", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_tzmc;
                i = i + 1;
                pms[i] = new IPrameter("@tznr", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_tznr;
                i = i + 1;
                pms[i] = new IPrameter("@tzsj", IDataType.DateTime, ParameterDirection.Input);
                pms[i].Value = V_tzsj;
                i = i + 1;
                pms[i] = new IPrameter("@tz_enddate", IDataType.DateTime, ParameterDirection.Input);
                pms[i].Value = V_tz_enddate;
                i = i + 1;
                pms[i] = new IPrameter("@tzr", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_tzr;
                //i=i+1;
                //pms[i] = new IPrameter("@tzfj", IDataType.Binary, ParameterDirection.Input);
                //pms[i].Value = V_tzfj;
                i = i + 1;
                pms[i] = new IPrameter("@tz_remark1", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_tz_remark1;
                i = i + 1;
                pms[i] = new IPrameter("@tz_remark2", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_tz_remark2;

                dbo.executeFunction("op_Table_KYTZ", pms);
                dbo.CommitTransaction();
                V_IRESULT = int.Parse(pms[1].Value.ToString());
                V_IERRCD = int.Parse(pms[2].Value.ToString());
                V_SERRMSG = pms[3].Value.ToString();
            }
            catch (Exception e)
            {
                //iLog.Error(e.Message.ToString());
                //throw e;
                V_IRESULT = -1;
                V_IERRCD = -1;
                V_SERRMSG = e.Message.ToString();
                return;
            }
            finally
            {
                dbo.closeDatabase();
            }
        }
        #endregion

        #region XASYU.DBBusiness层 操作方法 op_TABLE_STUDENT
        public static void op_TABLE_STUDENT(
              string V_YHDLM  //用户名
            , ref int V_IRESULT //返回值
            , ref int V_IERRCD  //返回错误号
            , ref string V_SERRMSG //返回错误信息
            , string V_SOP //操作类型
            , string V_Stu_NO		//Stu_NO 
            , string V_Stu_Name		//Stu_Name 
            , int V_Stu_Age		//Stu_Age 
            , string V_Stu_Zy		//Stu_Zy 
            )
        {
            string mConn = IConfiguration.getParameter("connectString");
            IDBOSQL.IDBO dbo = IDBOSQL.IDBO.getIDBO(mConn);
            try
            {
                dbo.openDatabase();
                dbo.BeginTransaction();
                IPrameter[] pms = new IPrameter[9];
                pms[0] = new IPrameter("@YHDLM", IDataType.VarChar, ParameterDirection.Input);
                pms[0].Value = V_YHDLM;
                pms[1] = new IPrameter("@IRESULT", IDataType.Number, ParameterDirection.Output);
                pms[1].Size = 4;
                pms[2] = new IPrameter("@IERRCD", IDataType.Number, ParameterDirection.Output);
                pms[2].Size = 4;
                pms[3] = new IPrameter("@SERRMSG", IDataType.VarChar, ParameterDirection.Output);
                pms[3].Size = 1024;
                pms[4] = new IPrameter("@SOP", IDataType.VarChar, ParameterDirection.Input);
                pms[4].Value = V_SOP;

                int i = 4;
                i = i + 1;
                pms[i] = new IPrameter("@Stu_NO", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_Stu_NO;
                i = i + 1;
                pms[i] = new IPrameter("@Stu_Name", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_Stu_Name;
                i = i + 1;
                pms[i] = new IPrameter("@Stu_Age", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_Stu_Age;
                i = i + 1;
                pms[i] = new IPrameter("@Stu_Zy", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_Stu_Zy;

                dbo.executeFunction("op_Table_Student", pms);
                dbo.CommitTransaction();
                V_IRESULT = int.Parse(pms[1].Value.ToString());
                V_IERRCD = int.Parse(pms[2].Value.ToString());
                V_SERRMSG = pms[3].Value.ToString();
            }
            catch (Exception e)
            {
                //iLog.Error(e.Message.ToString());
                //throw e;
                V_IRESULT = -1;
                V_IERRCD = -1;
                V_SERRMSG = e.Message.ToString();
                return;
            }
            finally
            {
                dbo.closeDatabase();
            }
        }
        #endregion

        #region XASYU.DBBusiness层 操作方法 op_TABLE_CYSMS
        public static void op_TABLE_CYSMS(
              string V_YHDLM  //用户名
            , ref int V_IRESULT //返回值
            , ref int V_IERRCD  //返回错误号
            , ref string V_SERRMSG //返回错误信息
            , string V_SOP //操作类型
            , int V_CySms_id        //CySms_id 
            , string V_CySms_nr     //CySms_nr 
            , string V_CySms_lx     //CySms_lx 
            )
        {
            string mConn = IConfiguration.getParameter("connectString");
            IDBOSQL.IDBO dbo = IDBOSQL.IDBO.getIDBO(mConn);
            try
            {
                dbo.openDatabase();
                dbo.BeginTransaction();
                IPrameter[] pms = new IPrameter[8];
                pms[0] = new IPrameter("@YHDLM", IDataType.VarChar, ParameterDirection.Input);
                pms[0].Value = V_YHDLM;
                pms[1] = new IPrameter("@IRESULT", IDataType.Number, ParameterDirection.Output);
                pms[1].Size = 4;
                pms[2] = new IPrameter("@IERRCD", IDataType.Number, ParameterDirection.Output);
                pms[2].Size = 4;
                pms[3] = new IPrameter("@SERRMSG", IDataType.VarChar, ParameterDirection.Output);
                pms[3].Size = 1024;
                pms[4] = new IPrameter("@SOP", IDataType.VarChar, ParameterDirection.Input);
                pms[4].Value = V_SOP;

                int i = 4;
                i = i + 1;
                pms[i] = new IPrameter("@CySms_id", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_CySms_id;
                i = i + 1;
                pms[i] = new IPrameter("@CySms_nr", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_CySms_nr;
                i = i + 1;
                pms[i] = new IPrameter("@CySms_lx", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_CySms_lx;

                dbo.executeFunction("op_Table_CySms", pms);
                dbo.CommitTransaction();
                V_IRESULT = int.Parse(pms[1].Value.ToString());
                V_IERRCD = int.Parse(pms[2].Value.ToString());
                V_SERRMSG = pms[3].Value.ToString();
            }
            catch (Exception e)
            {
                //iLog.Error(e.Message.ToString());
                //throw e;
                V_IRESULT = -1;
                V_IERRCD = -1;
                V_SERRMSG = e.Message.ToString();
                return;
            }
            finally
            {
                dbo.closeDatabase();
            }
        }
        #endregion

        #region XASYU.DBBusiness层 操作方法 op_TABLE_SMS
        public static void op_TABLE_SMS(
              string V_YHDLM  //用户名
            , ref int V_IRESULT //返回值
            , ref int V_IERRCD  //返回错误号
            , ref string V_SERRMSG //返回错误信息
            , string V_SOP //操作类型
            , int V_SMS_id      //SMS_id 
            , string V_SMS_jsr      //SMS_jsr 
            , string V_SMS_nr       //SMS_nr 
            , bool V_SMS_ljfs       //SMS_ljfs 
            , DateTime V_SMS_fstime     //SMS_fstime 
            , DateTime V_SMS_dstime     //SMS_dstime 
            , string V_SMS_dxlx     //SMS_dxlx 
            , bool V_SMS_dxzt       //SMS_dxzt 
            , bool V_SMS_hzzt       //SMS_hzzt 
            , string V_SMS_wapdx        //SMS_wapdx 
            , bool V_SMS_fjname     //SMS_fjname 
            , bool V_SMS_zchf       //SMS_zchf 
            , bool V_SMS_ztbg       //SMS_ztbg 
            , bool V_SMS_hftx       //SMS_hftx 
            , string V_SMS_hmd      //SMS_hmd 
            , bool V_SMS_sfzf       //SMS_sfzf 
            , bool V_SMS_delete     //SMS_delete 
            )
        {
            string mConn = IConfiguration.getParameter("connectString");
            IDBOSQL.IDBO dbo = IDBOSQL.IDBO.getIDBO(mConn);
            try
            {
                dbo.openDatabase();
                dbo.BeginTransaction();
                IPrameter[] pms = new IPrameter[22];
                pms[0] = new IPrameter("@YHDLM", IDataType.VarChar, ParameterDirection.Input);
                pms[0].Value = V_YHDLM;
                pms[1] = new IPrameter("@IRESULT", IDataType.Number, ParameterDirection.Output);
                pms[1].Size = 4;
                pms[2] = new IPrameter("@IERRCD", IDataType.Number, ParameterDirection.Output);
                pms[2].Size = 4;
                pms[3] = new IPrameter("@SERRMSG", IDataType.VarChar, ParameterDirection.Output);
                pms[3].Size = 1024;
                pms[4] = new IPrameter("@SOP", IDataType.VarChar, ParameterDirection.Input);
                pms[4].Value = V_SOP;

                int i = 4;
                i = i + 1;
                pms[i] = new IPrameter("@SMS_id", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_SMS_id;
                i = i + 1;
                pms[i] = new IPrameter("@SMS_jsr", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_SMS_jsr;
                i = i + 1;
                pms[i] = new IPrameter("@SMS_nr", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_SMS_nr;
                i = i + 1;
                pms[i] = new IPrameter("@SMS_ljfs", IDataType.Bit, ParameterDirection.Input);
                pms[i].Value = V_SMS_ljfs;
                i = i + 1;
                pms[i] = new IPrameter("@SMS_fstime", IDataType.DateTime, ParameterDirection.Input);
                pms[i].Value = V_SMS_fstime;
                i = i + 1;
                pms[i] = new IPrameter("@SMS_dstime", IDataType.DateTime, ParameterDirection.Input);
                pms[i].Value = V_SMS_dstime;
                i = i + 1;
                pms[i] = new IPrameter("@SMS_dxlx", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_SMS_dxlx;
                i = i + 1;
                pms[i] = new IPrameter("@SMS_dxzt", IDataType.Bit, ParameterDirection.Input);
                pms[i].Value = V_SMS_dxzt;
                i = i + 1;
                pms[i] = new IPrameter("@SMS_hzzt", IDataType.Bit, ParameterDirection.Input);
                pms[i].Value = V_SMS_hzzt;
                i = i + 1;
                pms[i] = new IPrameter("@SMS_wapdx", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_SMS_wapdx;
                i = i + 1;
                pms[i] = new IPrameter("@SMS_fjname", IDataType.Bit, ParameterDirection.Input);
                pms[i].Value = V_SMS_fjname;
                i = i + 1;
                pms[i] = new IPrameter("@SMS_zchf", IDataType.Bit, ParameterDirection.Input);
                pms[i].Value = V_SMS_zchf;
                i = i + 1;
                pms[i] = new IPrameter("@SMS_ztbg", IDataType.Bit, ParameterDirection.Input);
                pms[i].Value = V_SMS_ztbg;
                i = i + 1;
                pms[i] = new IPrameter("@SMS_hftx", IDataType.Bit, ParameterDirection.Input);
                pms[i].Value = V_SMS_hftx;
                i = i + 1;
                pms[i] = new IPrameter("@SMS_hmd", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_SMS_hmd;
                i = i + 1;
                pms[i] = new IPrameter("@SMS_sfzf", IDataType.Bit, ParameterDirection.Input);
                pms[i].Value = V_SMS_sfzf;
                i = i + 1;
                pms[i] = new IPrameter("@SMS_delete", IDataType.Bit, ParameterDirection.Input);
                pms[i].Value = V_SMS_delete;

                dbo.executeFunction("op_Table_Sms", pms);
                dbo.CommitTransaction();
                V_IRESULT = int.Parse(pms[1].Value.ToString());
                V_IERRCD = int.Parse(pms[2].Value.ToString());
                V_SERRMSG = pms[3].Value.ToString();
            }
            catch (Exception e)
            {
                //iLog.Error(e.Message.ToString());
                //throw e;
                V_IRESULT = -1;
                V_IERRCD = -1;
                V_SERRMSG = e.Message.ToString();
                return;
            }
            finally
            {
                dbo.closeDatabase();
            }
        }
        #endregion

        #region XASYU.DBBusiness层 操作方法 op_TABLE_SJX
        public static void op_TABLE_SJX(
              string V_YHDLM  //用户名
            , ref int V_IRESULT //返回值
            , ref int V_IERRCD  //返回错误号
            , ref string V_SERRMSG //返回错误信息
            , string V_SOP //操作类型
            , int V_SJX_id      //SJX_id 
            , string V_SJX_mobile       //SJX_mobile 
            , string V_SJX_nr       //SJX_nr 
            , DateTime V_SJX_jstime     //SJX_jstime 
            )
        {
            string mConn = IConfiguration.getParameter("connectString");
            IDBOSQL.IDBO dbo = IDBOSQL.IDBO.getIDBO(mConn);
            try
            {
                dbo.openDatabase();
                dbo.BeginTransaction();
                IPrameter[] pms = new IPrameter[9];
                pms[0] = new IPrameter("@YHDLM", IDataType.VarChar, ParameterDirection.Input);
                pms[0].Value = V_YHDLM;
                pms[1] = new IPrameter("@IRESULT", IDataType.Number, ParameterDirection.Output);
                pms[1].Size = 4;
                pms[2] = new IPrameter("@IERRCD", IDataType.Number, ParameterDirection.Output);
                pms[2].Size = 4;
                pms[3] = new IPrameter("@SERRMSG", IDataType.VarChar, ParameterDirection.Output);
                pms[3].Size = 1024;
                pms[4] = new IPrameter("@SOP", IDataType.VarChar, ParameterDirection.Input);
                pms[4].Value = V_SOP;

                int i = 4;
                i = i + 1;
                pms[i] = new IPrameter("@SJX_id", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_SJX_id;
                i = i + 1;
                pms[i] = new IPrameter("@SJX_mobile", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_SJX_mobile;
                i = i + 1;
                pms[i] = new IPrameter("@SJX_nr", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_SJX_nr;
                i = i + 1;
                pms[i] = new IPrameter("@SJX_jstime", IDataType.DateTime, ParameterDirection.Input);
                pms[i].Value = V_SJX_jstime;

                dbo.executeFunction("op_Table_Sjx", pms);
                dbo.CommitTransaction();
                V_IRESULT = int.Parse(pms[1].Value.ToString());
                V_IERRCD = int.Parse(pms[2].Value.ToString());
                V_SERRMSG = pms[3].Value.ToString();
            }
            catch (Exception e)
            {
                //iLog.Error(e.Message.ToString());
                //throw e;
                V_IRESULT = -1;
                V_IERRCD = -1;
                V_SERRMSG = e.Message.ToString();
                return;
            }
            finally
            {
                dbo.closeDatabase();
            }
        }
        #endregion

        #region XASYU.DBBusiness层 操作方法 op_TABLE_DXHF
        public static void op_TABLE_DXHF(
              string V_YHDLM  //用户名
            , ref int V_IRESULT //返回值
            , ref int V_IERRCD  //返回错误号
            , ref string V_SERRMSG //返回错误信息
            , string V_SOP //操作类型
            , int V_DXHF_id     //DXHF_id 
            , int V_SMS_id      //SMS_id 
            , string V_DXHF_hfrmobile       //DXHF_hfrmobile 
            , string V_DXHF_nr      //DXHF_nr 
            , string V_DXHF_time        //DXHF_time 
            )
        {
            string mConn = IConfiguration.getParameter("connectString");
            IDBOSQL.IDBO dbo = IDBOSQL.IDBO.getIDBO(mConn);
            try
            {
                dbo.openDatabase();
                dbo.BeginTransaction();
                IPrameter[] pms = new IPrameter[10];
                pms[0] = new IPrameter("@YHDLM", IDataType.VarChar, ParameterDirection.Input);
                pms[0].Value = V_YHDLM;
                pms[1] = new IPrameter("@IRESULT", IDataType.Number, ParameterDirection.Output);
                pms[1].Size = 4;
                pms[2] = new IPrameter("@IERRCD", IDataType.Number, ParameterDirection.Output);
                pms[2].Size = 4;
                pms[3] = new IPrameter("@SERRMSG", IDataType.VarChar, ParameterDirection.Output);
                pms[3].Size = 1024;
                pms[4] = new IPrameter("@SOP", IDataType.VarChar, ParameterDirection.Input);
                pms[4].Value = V_SOP;

                int i = 4;
                i = i + 1;
                pms[i] = new IPrameter("@DXHF_id", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_DXHF_id;
                i = i + 1;
                pms[i] = new IPrameter("@SMS_id", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_SMS_id;
                i = i + 1;
                pms[i] = new IPrameter("@DXHF_hfrmobile", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_DXHF_hfrmobile;
                i = i + 1;
                pms[i] = new IPrameter("@DXHF_nr", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_DXHF_nr;
                i = i + 1;
                pms[i] = new IPrameter("@DXHF_time", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_DXHF_time;

                dbo.executeFunction("op_Table_Dxhf", pms);
                dbo.CommitTransaction();
                V_IRESULT = int.Parse(pms[1].Value.ToString());
                V_IERRCD = int.Parse(pms[2].Value.ToString());
                V_SERRMSG = pms[3].Value.ToString();
            }
            catch (Exception e)
            {
                //iLog.Error(e.Message.ToString());
                //throw e;
                V_IRESULT = -1;
                V_IERRCD = -1;
                V_SERRMSG = e.Message.ToString();
                return;
            }
            finally
            {
                dbo.closeDatabase();
            }
        }
        #endregion

        #region XASYU.DBBusiness层 操作方法 op_TABLE_TXQZ
        public static void op_TABLE_TXQZ(
              string V_YHDLM  //用户名
            , ref int V_IRESULT //返回值
            , ref int V_IERRCD  //返回错误号
            , ref string V_SERRMSG //返回错误信息
            , string V_SOP //操作类型
            , int V_TXQZ_id     //TXQZ_id 
            , string V_TXQZ_name        //TXQZ_name 
            , int V_TXQZ_sjid       //TXQZ_sjid 
            )
        {
            string mConn = IConfiguration.getParameter("connectString");
            IDBOSQL.IDBO dbo = IDBOSQL.IDBO.getIDBO(mConn);
            try
            {
                dbo.openDatabase();
                dbo.BeginTransaction();
                IPrameter[] pms = new IPrameter[8];
                pms[0] = new IPrameter("@YHDLM", IDataType.VarChar, ParameterDirection.Input);
                pms[0].Value = V_YHDLM;
                pms[1] = new IPrameter("@IRESULT", IDataType.Number, ParameterDirection.Output);
                pms[1].Size = 4;
                pms[2] = new IPrameter("@IERRCD", IDataType.Number, ParameterDirection.Output);
                pms[2].Size = 4;
                pms[3] = new IPrameter("@SERRMSG", IDataType.VarChar, ParameterDirection.Output);
                pms[3].Size = 1024;
                pms[4] = new IPrameter("@SOP", IDataType.VarChar, ParameterDirection.Input);
                pms[4].Value = V_SOP;

                int i = 4;
                i = i + 1;
                pms[i] = new IPrameter("@TXQZ_id", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_TXQZ_id;
                i = i + 1;
                pms[i] = new IPrameter("@TXQZ_name", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_TXQZ_name;
                i = i + 1;
                pms[i] = new IPrameter("@TXQZ_sjid", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_TXQZ_sjid;

                dbo.executeFunction("op_Table_Txqz", pms);
                dbo.CommitTransaction();
                V_IRESULT = int.Parse(pms[1].Value.ToString());
                V_IERRCD = int.Parse(pms[2].Value.ToString());
                V_SERRMSG = pms[3].Value.ToString();
            }
            catch (Exception e)
            {
                //iLog.Error(e.Message.ToString());
                //throw e;
                V_IRESULT = -1;
                V_IERRCD = -1;
                V_SERRMSG = e.Message.ToString();
                return;
            }
            finally
            {
                dbo.closeDatabase();
            }
        }
        #endregion

        #region XASYU.DBBusiness层 操作方法 op_TABLE_LXR
        public static void op_TABLE_LXR(
              string V_YHDLM  //用户名
            , ref int V_IRESULT //返回值
            , ref int V_IERRCD  //返回错误号
            , ref string V_SERRMSG //返回错误信息
            , string V_SOP //操作类型
            , int V_LXR_id      //LXR_id 
            , string V_LXR_name     //LXR_name 
            , string V_LXR_mobile       //LXR_mobile 
            , string V_LXR_sex      //LXR_sex 
            , string V_LXR_phone        //LXR_phone 
            , string V_LXR_email        //LXR_email 
            , string V_LXR_gzdw     //LXR_gzdw 
            , string V_LXR_sfzid        //LXR_sfzid 
            , string V_LXR_zw       //LXR_zw 
            , string V_LXR_bz       //LXR_bz 
            , bool V_LXR_sfjrwh     //LXR_sfjrwh 
            , DateTime V_LXR_csrq       //LXR_csrq 
            , bool V_LXR_sfsrwh     //LXR_sfsrwh 
            , DateTime V_LXR_gj01       //LXR_gj01 
            , string V_LXR_gj01nr       //LXR_gj01nr 
            , DateTime V_LXR_gj02       //LXR_gj02 
            , string V_LXR_gj02nr       //LXR_gj02nr 
            , DateTime V_LXR_gj03       //LXR_gj03 
            , string V_LXR_gj03nr       //LXR_gj03nr 
            )
        {
            string mConn = IConfiguration.getParameter("connectString");
            IDBOSQL.IDBO dbo = IDBOSQL.IDBO.getIDBO(mConn);
            try
            {
                dbo.openDatabase();
                dbo.BeginTransaction();
                IPrameter[] pms = new IPrameter[24];
                pms[0] = new IPrameter("@YHDLM", IDataType.VarChar, ParameterDirection.Input);
                pms[0].Value = V_YHDLM;
                pms[1] = new IPrameter("@IRESULT", IDataType.Number, ParameterDirection.Output);
                pms[1].Size = 4;
                pms[2] = new IPrameter("@IERRCD", IDataType.Number, ParameterDirection.Output);
                pms[2].Size = 4;
                pms[3] = new IPrameter("@SERRMSG", IDataType.VarChar, ParameterDirection.Output);
                pms[3].Size = 1024;
                pms[4] = new IPrameter("@SOP", IDataType.VarChar, ParameterDirection.Input);
                pms[4].Value = V_SOP;

                int i = 4;
                i = i + 1;
                pms[i] = new IPrameter("@LXR_id", IDataType.Number, ParameterDirection.Input);
                pms[i].Value = V_LXR_id;
                i = i + 1;
                pms[i] = new IPrameter("@LXR_name", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_LXR_name;
                i = i + 1;
                pms[i] = new IPrameter("@LXR_mobile", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_LXR_mobile;
                i = i + 1;
                pms[i] = new IPrameter("@LXR_sex", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_LXR_sex;
                i = i + 1;
                pms[i] = new IPrameter("@LXR_phone", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_LXR_phone;
                i = i + 1;
                pms[i] = new IPrameter("@LXR_email", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_LXR_email;
                i = i + 1;
                pms[i] = new IPrameter("@LXR_gzdw", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_LXR_gzdw;
                i = i + 1;
                pms[i] = new IPrameter("@LXR_sfzid", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_LXR_sfzid;
                i = i + 1;
                pms[i] = new IPrameter("@LXR_zw", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_LXR_zw;
                i = i + 1;
                pms[i] = new IPrameter("@LXR_bz", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_LXR_bz;
                i = i + 1;
                pms[i] = new IPrameter("@LXR_sfjrwh", IDataType.Bit, ParameterDirection.Input);
                pms[i].Value = V_LXR_sfjrwh;
                i = i + 1;
                pms[i] = new IPrameter("@LXR_csrq", IDataType.DateTime, ParameterDirection.Input);
                pms[i].Value = V_LXR_csrq;
                i = i + 1;
                pms[i] = new IPrameter("@LXR_sfsrwh", IDataType.Bit, ParameterDirection.Input);
                pms[i].Value = V_LXR_sfsrwh;
                i = i + 1;
                pms[i] = new IPrameter("@LXR_gj01", IDataType.DateTime, ParameterDirection.Input);
                pms[i].Value = V_LXR_gj01;
                i = i + 1;
                pms[i] = new IPrameter("@LXR_gj01nr", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_LXR_gj01nr;
                i = i + 1;
                pms[i] = new IPrameter("@LXR_gj02", IDataType.DateTime, ParameterDirection.Input);
                pms[i].Value = V_LXR_gj02;
                i = i + 1;
                pms[i] = new IPrameter("@LXR_gj02nr", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_LXR_gj02nr;
                i = i + 1;
                pms[i] = new IPrameter("@LXR_gj03", IDataType.DateTime, ParameterDirection.Input);
                pms[i].Value = V_LXR_gj03;
                i = i + 1;
                pms[i] = new IPrameter("@LXR_gj03nr", IDataType.VarChar, ParameterDirection.Input);
                pms[i].Value = V_LXR_gj03nr;

                dbo.executeFunction("op_Table_Lxr", pms);
                dbo.CommitTransaction();
                V_IRESULT = int.Parse(pms[1].Value.ToString());
                V_IERRCD = int.Parse(pms[2].Value.ToString());
                V_SERRMSG = pms[3].Value.ToString();
            }
            catch (Exception e)
            {
                //iLog.Error(e.Message.ToString());
                //throw e;
                V_IRESULT = -1;
                V_IERRCD = -1;
                V_SERRMSG = e.Message.ToString();
                return;
            }
            finally
            {
                dbo.closeDatabase();
            }
        }
        #endregion
    }
}
