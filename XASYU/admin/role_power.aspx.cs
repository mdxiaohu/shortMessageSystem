using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using FineUI;
using System.Data;
using Newtonsoft.Json.Linq;
using AspNet = System.Web.UI.WebControls;
using System.Reflection;
using XASYU.MODEL;
using CykjSoft.UserPermissionManager.Utils;

namespace XASYU.admin
{
    public partial class role_power : PageBase
    {
        #region ViewPower

        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "CoreRolePowerView";
            }
        }

        #endregion

        #region 初始化变量
        private XASYU.MODEL.SYS_ROLESModel RoleModel = new MODEL.SYS_ROLESModel();
        private XASYU.MODEL.SYS_POWERSModel PowerModel = new MODEL.SYS_POWERSModel();
        private XASYU.MODEL.SYS_ROLEPOWERSModel RolePowerModel = new MODEL.SYS_ROLEPOWERSModel();
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
            // 权限检查
            CheckPowerWithButton("CoreRolePowerEdit", btnGroupUpdate);



            // 每页记录数
            Grid1.PageSize = PageBase.PageSize;
            BindGrid();

            // 默认选中第一个角色
            Grid1.SelectedRowIndex = 0;

            // 每页记录数
            Grid2.PageSize = PageBase.PageSize;
            BindGrid2();
        }

        private void BindGrid()
        {
            int V_ITOTALCOUNT = -1;
            string sortField = Grid1.SortField;
            string sortDirection = Grid1.SortDirection;
            DataTable table = new DataTable();
            DataSet ds = XASYU.BLL.DataBaseQuery.query_SYS_ROLES(userBean, RoleModel, ref  V_ITOTALCOUNT, 0, 1000);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                table = ds.Tables[0];
                DataView view2 = table.DefaultView;//排序后绑定
                view2.Sort = String.Format("{0} {1}", sortField, sortDirection);
                table = view2.ToTable();
            }

            Grid1.DataSource = table;
            Grid1.DataBind();
        }

        private Dictionary<string, bool> _currentRolePowers = new Dictionary<string, bool>();

        private void BindGrid2()
        {
            int V_ITOTALCOUNT = -1;
            int VL_ITOTALCOUNT = -1;
            int roleId = GetSelectedDataKeyID(Grid1);
            if (roleId == -1)
            {
                Grid2.DataSource = null;
                Grid2.DataBind();
            }
            else
            {
                // 当前选中角色拥有的权限列表
                _currentRolePowers.Clear();
                RolePowerModel.RoleID = roleId;
                DataSet ds = XASYU.BLL.DataBaseQuery.query_SYS_ROLEPOWERS(userBean, RolePowerModel, ref  V_ITOTALCOUNT, 0, 1000);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string powerName = ds.Tables[0].Rows[i]["Name"].ToString();
                        if (!_currentRolePowers.ContainsKey(powerName))
                        {
                            _currentRolePowers.Add(powerName, true);
                        }
                    }
                  
                }

                List<SYS_POWERSModel> dbPowers = new List<SYS_POWERSModel>();
                DataSet ds_Power = XASYU.BLL.DataBaseQuery.query_SYS_POWERS(userBean, PowerModel, ref  VL_ITOTALCOUNT, 0, 5000);
                if (ds_Power != null && ds_Power.Tables.Count > 0 && ds_Power.Tables[0] != null && ds_Power.Tables[0].Rows.Count > 0)
                {
                    //利用反射转换数据类型
                    dbPowers = DataSetToIList<SYS_POWERSModel>(ds_Power, 0);
                }

                var q = dbPowers.GroupBy(p=>p.GroupName);
                if (Grid2.SortField == "GroupName")
                {
                    if (Grid2.SortDirection == "ASC")
                    {
                        q = q.OrderBy(g => g.Key);
                    }
                    else
                    {
                        q = q.OrderByDescending(g => g.Key);
                    }
                }

                var powers = q.Select(g => new
                {
                    GroupName = g.Key,
                    Powers = g
                });


                Grid2.DataSource = powers;
                Grid2.DataBind();
            }

        }

        #endregion

        #region 数据转换
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
        #endregion

        #region Grid1 Events

        protected void Grid1_Sort(object sender, GridSortEventArgs e)
        {
            Grid1.SortDirection = e.SortDirection;
            Grid1.SortField = e.SortField;
            BindGrid();

            // 默认选中第一个角色
            Grid1.SelectedRowIndex = 0;

            BindGrid2();
        }

        protected void Grid1_RowClick(object sender, FineUI.GridRowClickEventArgs e)
        {
            BindGrid2();
        }

        #endregion

        #region Grid2 Events

        protected void Grid2_RowDataBound(object sender, FineUI.GridRowEventArgs e)
        {
            AspNet.CheckBoxList ddlPowers = (AspNet.CheckBoxList)Grid2.Rows[e.RowIndex].FindControl("ddlPowers");

            IGrouping<string, SYS_POWERSModel> powers = e.DataItem.GetType().GetProperty("Powers").GetValue(e.DataItem, null) as IGrouping<string, SYS_POWERSModel>;

            foreach (SYS_POWERSModel power in powers.ToList())
            {
                AspNet.ListItem item = new AspNet.ListItem();
                item.Value = power.ID.ToString();
                item.Text = power.Title;
                item.Attributes["data-qtip"] = power.Name;

                if (_currentRolePowers.ContainsKey(power.Name))
                {
                    item.Selected = true;
                }
                else
                {
                    item.Selected = false;
                }

                ddlPowers.Items.Add(item);
            }
        }



        protected void Grid2_Sort(object sender, GridSortEventArgs e)
        {
            Grid2.SortDirection = e.SortDirection;
            Grid2.SortField = e.SortField;
            BindGrid2();
        }

        protected void btnGroupUpdate_Click(object sender, EventArgs e)
        {
            // 在操作之前进行权限检查
            if (!CheckPower("CoreRolePowerEdit"))
            {
                CheckPowerFailWithAlert();
                return;
            }

            int roleId = GetSelectedDataKeyID(Grid1);
            if (roleId == -1)
            {
                return;
            }

            // 当前角色新的权限列表
            List<int> newPowerIDs = new List<int>();
            for (int i = 0; i < Grid2.Rows.Count; i++)
            {
                AspNet.CheckBoxList ddlPowers = (AspNet.CheckBoxList)Grid2.Rows[i].FindControl("ddlPowers");
                foreach (AspNet.ListItem item in ddlPowers.Items)
                {
                    if (item.Selected)
                    {
                        newPowerIDs.Add(Convert.ToInt32(item.Value));
                    }
                }
            }
            //先删除原来有的角色权限
            RolePowerModel.RoleID = roleId;
            RolePowerModel.OpType = DataOperationType.Delete;
            XASYU.BLL.DataBaseManager.op_SYS_ROLEPOWERS(userBean, RolePowerModel);
            //再添加新选的角色
            foreach (int ids in newPowerIDs)
            {
                RolePowerModel.RoleID = roleId;
                RolePowerModel.PowerID = ids;
                RolePowerModel.OpType = DataOperationType.Add;
                XASYU.BLL.DataBaseManager.op_SYS_ROLEPOWERS(userBean, RolePowerModel);
            }
            Alert.ShowInTop("当前角色的权限更新成功！");
        }


        #endregion

    }
}
