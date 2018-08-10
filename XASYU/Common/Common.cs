using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using IDBOSQL;
using System.Data.SqlClient;
using FineUI;

namespace XASYU
{
    public class Common
    {
        public Common()
        {

        }
       
        #region 初始化下拉列表
        public static void BindDropDownList(DropDownList ddl, string tableName, string text)
        {
            string mConn = IConfiguration.getParameter("connectString");
            IDBOSQL.IDBO dbo = IDBOSQL.IDBO.getIDBO(mConn);
            dbo.openDatabase();
            DataSet ds = dbo.executeSelectSql("select distinct " + text + " from " + tableName);
            ddl.DataSource = ds;
            ddl.DataTextField = text;
            ddl.DataBind();
            dbo.closeDatabase();

        }

        public static void BindDropDownList(DropDownList ddl, string tableName, string text, string value, string where)
        {
            string mConn = IConfiguration.getParameter("connectString");
            IDBOSQL.IDBO dbo = IDBOSQL.IDBO.getIDBO(mConn);
            dbo.openDatabase();
            DataSet ds = dbo.executeSelectSql("select distinct " + text + "," + value + " from " + tableName + " where " + where);
            ddl.DataSource = ds;
            ddl.DataTextField = text;
            ddl.DataValueField = value;
            ddl.DataBind();
            dbo.closeDatabase();

        }
        #endregion

        #region 查询数据是否存在
        //tablename 表名
        //colnames string[] 列名
        //values string[] 值
        //strwhere 修改条件
        public static bool checkExists(string tableName, string strWhere)
        {
            string strSql = "select cast(count(*)as varchar(10)) from " + tableName + " where " + strWhere;

            string mConn = IConfiguration.getParameter("connectString");
            IDBOSQL.IDBO dbo = IDBOSQL.IDBO.getIDBO(mConn);
            dbo.openDatabase();

            string str = dbo.executeSql(strSql);
            dbo.closeDatabase();
            if (int.Parse(str) == 0)
                return false;
            else
                return true;

        }


        #endregion

        #region 进行数据库修改

        //tablename 表名
        //colnames string[] 列名
        //values string[,] 第一个为要修改的值，第二个值的类型，0为数字，1为字符
        //strwhere 修改条件
        public static int UpdateTable(string tableName, string[] colnames, string[,] values, string strWhere)
        {
            int iRESULT = 0;
            string strSql = "update " + tableName + " set";

            for (int i = 0; i < colnames.Length; i++)
            {
                if (values[i, 1] == "0")
                    strSql = strSql + " " + colnames[i] + "=" + values[i, 0] + ",";
                else
                    strSql = strSql + " " + colnames[i] + "='" + values[i, 0] + "',";
            }
            strSql = strSql.TrimEnd(new char[] { ',' });
            strSql = strSql + " where " + strWhere;

            string mConn = IConfiguration.getParameter("connectString");
            SqlConnection myCon = new SqlConnection(mConn);
            try
            {
                myCon.Open();
                SqlCommand cmd = new SqlCommand(strSql, myCon);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                iRESULT = -1;
                ex.ToString();
            }
            return iRESULT;

        }
        //删除数据记录
        public static int Del_Table(string tableName, string strWhere)
        {
            int iRESULT = 0;
            string strSql = "delete " + tableName;

            strSql = strSql + " where " + strWhere;

            string mConn = IConfiguration.getParameter("connectString");
            SqlConnection myCon = new SqlConnection(mConn);
            try
            {
                myCon.Open();
                SqlCommand cmd = new SqlCommand(strSql, myCon);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                iRESULT = -1;
                ex.ToString();
            }
            return iRESULT;

        }

        //插入数据
        public static int Insert_GroupTable(string tableName, string Group_ID, string name, string parentid)
        {
            int iRESULT = 0;
            string strSql = "insert " + tableName;

            strSql = strSql + "(Group_ID,Group_Name,Parent_GroupID) values ('" + Group_ID + "','" + name + "','" + parentid + "')";

            string mConn = IConfiguration.getParameter("connectString");
            SqlConnection myCon = new SqlConnection(mConn);
            try
            {
                myCon.Open();
                SqlCommand cmd = new SqlCommand(strSql, myCon);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                iRESULT = -1;
                ex.ToString();
            }
            return iRESULT;

        }

        #endregion

        #region 生成编号
        public static string BuildOrderID(string strTableName, string strCodeColumn)
        {
            string mConn = IConfiguration.getParameter("connectString");
            IDBOSQL.IDBO dbo = IDBOSQL.IDBO.getIDBO(mConn);
            dbo.openDatabase();
            string strSql = "Select Max(" + strCodeColumn + ") as bh From " + strTableName;
            DataSet ds = dbo.executeSelectSql(strSql);
            if (ds.Tables[0].Rows.Count == 0)
            {
                return "1";
            }
            else
            {
                int orderid = int.Parse(ds.Tables[0].Rows[0]["bh"].ToString()) + 1;

                return orderid.ToString();
            }
        }
        #endregion

        #region  获取表
        public static DataTable GetDataTable(string strSql)
        {
            string mConn = IConfiguration.getParameter("connectString");
            IDBOSQL.IDBO dbo = IDBOSQL.IDBO.getIDBO(mConn);
            dbo.openDatabase();
            try
            {
                DataSet ds = dbo.executeSelectSql(strSql);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}