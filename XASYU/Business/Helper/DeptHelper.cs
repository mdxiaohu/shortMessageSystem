using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using XASYU.MODEL;
using System.Data;
using System.Reflection;

namespace XASYU
{
    public class DeptHelper
    {
        private  XASYU.MODEL.SYS_DEPTSModel DeptsModel = new MODEL.SYS_DEPTSModel();
        private  XASYU.MODEL.SYS_USERSModel UserModel = new MODEL.SYS_USERSModel();
         CykjSoft.Bean.UserBean userBean = new CykjSoft.Bean.UserBean();
         int V_ITOTALCOUNT = -1;
         int V_SSTARTINDEX = 0;
         int V_SPERPAGESIZE = 1000;
        private  List<SYS_DEPTSModel> _depts;

        public  List<SYS_DEPTSModel> Depts
        {
            get
            {
                if (_depts == null)
                {
                    InitDepts();
                }
                return _depts;
            }
        }

        public  void Reload()
        {
            _depts = null;
        }

        private  void InitDepts()
        {
            _depts = new List<SYS_DEPTSModel>();

            /*以下代码实现目录列表 List<dbDepts>*/
            List<SYS_DEPTSModel> dbDepts = new List<SYS_DEPTSModel>();
            DeptsModel.StartDate = DateTime.Parse("1900-01-01");
            DeptsModel.EndDate = DateTime.Now;
            DataTable table = new DataTable();
            DataSet ds = XASYU.BLL.DataBaseQuery.query_SYS_DEPTS(userBean, DeptsModel, ref  V_ITOTALCOUNT, V_SSTARTINDEX, V_SPERPAGESIZE);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                dbDepts = DataSetToIList<SYS_DEPTSModel>(ds, 0);//利用反射机制实现DataSet和List之间数据转换              
            }
            /*以下代码实现功能是在menus节点中增加Parent节点，以方便实现树形目录*/
            for (int i = 0; i < dbDepts.Count; i++)
            {
                if (dbDepts[i].ParentID != 0)
                {
                    SYS_DEPTSModel MenuTemp = dbDepts.Find(delegate(SYS_DEPTSModel p) { return p.ID == dbDepts[i].ParentID; });
                    dbDepts[i].Parent = MenuTemp;
                }
            }
            ResolveDeptCollection(dbDepts, null, 0);
        }

        /// <summary> 
        /// DataSet装换为泛型集合 
        /// </summary> 
        /// <typeparam name="T"></typeparam> 
        /// <param name="p_DataSet">DataSet</param> 
        /// <param name="p_TableIndex">待转换数据表索引</param> 
        /// <returns></returns> 
        public static List<T> DataSetToIList<T>(DataSet p_DataSet, int p_TableIndex)
        {
            if (p_DataSet == null || p_DataSet.Tables.Count < 0)
                return null;
            if (p_TableIndex > p_DataSet.Tables.Count - 1)
                return null;
            if (p_TableIndex < 0)
                p_TableIndex = 0;

            DataTable p_Data = p_DataSet.Tables[p_TableIndex];
            // 返回值初始化 
            List<T> result = new List<T>();
            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                T _t = (T)Activator.CreateInstance(typeof(T));
                PropertyInfo[] propertys = _t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    for (int i = 0; i < p_Data.Columns.Count; i++)
                    {
                        // 属性与字段名称一致的进行赋值 
                        if (pi.Name.Equals(p_Data.Columns[i].ColumnName))
                        {
                            // 数据库NULL值单独处理 
                            if (p_Data.Rows[j][i] != DBNull.Value)
                                pi.SetValue(_t, p_Data.Rows[j][i], null);
                            else
                                pi.SetValue(_t, null, null);
                            break;
                        }
                    }
                }
                result.Add(_t);
            }
            return result;
        }

        private  int ResolveDeptCollection(List<SYS_DEPTSModel> dbDepts, SYS_DEPTSModel parentDept, int level)
        {
            int count = 0;
            foreach (var dept in dbDepts.Where(d => d.Parent == parentDept))
            {
                count++;

                _depts.Add(dept);
                dept.TreeLevel = level;
                dept.IsTreeLeaf = true;
                dept.Enabled = true;

                level++;
                // 如果这个节点下没有子节点，则这是个终结节点
                int childCount = ResolveDeptCollection(dbDepts, dept, level);
                if (childCount != 0)
                {
                    dept.IsTreeLeaf = false;
                }
                level--;

            }

            return count;
        }

    }
}
