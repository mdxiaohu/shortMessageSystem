using System;
using System.Collections.Generic;
using System.Web;
using XASYU.MODEL;

using System.Linq;
using System.Data;
using System.Reflection;


namespace XASYU
{
    public class MenuHelper
    {
        private  XASYU.MODEL.SYS_MENUSModel MenuModel = new MODEL.SYS_MENUSModel();
        private  XASYU.MODEL.SYS_POWERSModel PowerModel = new MODEL.SYS_POWERSModel();
        CykjSoft.Bean.UserBean userBean = new CykjSoft.Bean.UserBean();
        int VL_ITOTALCOUNT = -1;
        int V_SSTARTINDEX = 0;
        int V_SPERPAGESIZE = 1000;
        int VP_ITOTALCOUNT = -1;
        int VP_SSTARTINDEX = 0;
        int VP_SPERPAGESIZE = 1000;
        private  List<SYS_MENUSModel> _menus;

        public  List<SYS_MENUSModel> Menus
        {
            get
            {
                if (_menus == null)
                {
                    InitMenus();
                }
                return _menus;
            }
        }

        public  void Reload()
        {
            _menus = null;
        }

        private   void InitMenus()
        {
            _menus = new List<SYS_MENUSModel>();
            /*以下代码实现构造权限列表 List<dbPowers>*/
            List<SYS_POWERSModel> dbPowers = new List<SYS_POWERSModel>();
            PowerModel.StartDate = DateTime.Parse("1900-01-01");
            PowerModel.EndDate = DateTime.Now;
            DataSet ds_Power = XASYU.BLL.DataBaseQuery.query_SYS_POWERS(userBean, PowerModel, ref  VP_ITOTALCOUNT, VP_SSTARTINDEX, VP_SPERPAGESIZE);
            if (ds_Power != null && ds_Power.Tables.Count > 0 && ds_Power.Tables[0] != null && ds_Power.Tables[0].Rows.Count > 0)
            {
                dbPowers =DataSetToIList<SYS_POWERSModel>(ds_Power, 0);//利用反射机制实现DataSet和List之间数据转换   
            }
             /*以下代码实现目录列表 List<dbMenus>*/
            List<SYS_MENUSModel> dbMenus = new List<SYS_MENUSModel>();
            MenuModel.StartDate = DateTime.Parse("1900-01-01");
            MenuModel.EndDate = DateTime.Now;
            DataTable table = new DataTable();
            DataSet ds = XASYU.BLL.DataBaseQuery.query_SYS_MENUS(userBean, MenuModel, ref  VL_ITOTALCOUNT, V_SSTARTINDEX, V_SPERPAGESIZE);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                dbMenus=DataSetToIList<SYS_MENUSModel>(ds, 0);//利用反射机制实现DataSet和List之间数据转换              
            }
            /*以下代码实现功能是在menus节点中增加Parent节点和Power权限节点，以方便实现根据拥有权限加载不同目录*/
            for (int i = 0; i < dbMenus.Count; i++)
            {
                if (dbMenus[i].ParentID != 0)
                {
                    SYS_MENUSModel MenuTemp = dbMenus.Find(delegate(SYS_MENUSModel p) { return p.ID == dbMenus[i].ParentID; });
                    dbMenus[i].Parent = MenuTemp;
                }
                if (dbMenus[i].ViewPowerID != 0)
                {
                    SYS_POWERSModel PowerTemp = dbPowers.Find(delegate(SYS_POWERSModel q) { return q.ID == dbMenus[i].ViewPowerID; });
                    dbMenus[i].ViewPower = PowerTemp;
                }
            }
            ResolveMenuCollection(dbMenus, null, 0);
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

        private  int ResolveMenuCollection(List<SYS_MENUSModel> dbMenus, SYS_MENUSModel parentMenu, int level)
        {
            int count = 0;
            foreach (var menu in dbMenus.Where(m => m.Parent == parentMenu))
            {
                count++;

                _menus.Add(menu);
                menu.TreeLevel = level;
                menu.IsTreeLeaf = false;
                menu.Enabled = true;

                level++;
                int childCount = ResolveMenuCollection(dbMenus, menu, level);
                if (childCount != 0)
                {
                    menu.IsTreeLeaf = false;
                }
                level--;
            }

                return count;
        }

    }
}
