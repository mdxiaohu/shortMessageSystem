<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dept.aspx.cs" Inherits="XASYU.admin.dept" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
        <f:Panel ID="Panel1" runat="server" BodyPadding="5px" 
            ShowBorder="false" ShowHeader="false" Layout="Fit">
            <Items>
                <f:Grid ID="Grid1" runat="server" ShowBorder="true" ShowHeader="false" EnableCheckBoxSelect="false"
                    DataKeyNames="ID" OnPreDataBound="Grid1_PreDataBound"
                    OnRowCommand="Grid1_RowCommand" EnableMultiSelect="false">
                    <Toolbars>
                        <f:Toolbar ID="Toolbar1" Position="Top" runat="server">
                            <Items>
                                <f:ToolbarFill ID="ToolbarFill1" runat="server">
                                </f:ToolbarFill>
                                <f:Button ID="btnNew" runat="server" Icon="Add" EnablePostBack="false" Text="新增部门">
                                </f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    
                    <Columns>
                        <f:RowNumberField />
                        <f:BoundField DataField="Name" HeaderText="部门名称" DataSimulateTreeLevelField="TreeLevel"
                            Width="150px" />
                        <f:BoundField DataField="DeptLeader" HeaderText="部门负责人"/>
                        <f:BoundField DataField="DeptTel" HeaderText="部门电话"/>
                        <f:BoundField DataField="Remark" HeaderText="部门描述" ExpandUnusedSpace="true" />
                        <f:BoundField DataField="SortIndex" HeaderText="排序" Width="80px" />
                        <f:WindowField ColumnID="editField" TextAlign="Center" Icon="Pencil" ToolTip="编辑"
                            WindowID="Window1" Title="编辑" DataIFrameUrlFields="ID" DataIFrameUrlFormatString="~/admin/dept_edit.aspx?id={0}"
                            Width="50px" />
                        <f:LinkButtonField ColumnID="deleteField" TextAlign="Center" Icon="Delete" ToolTip="删除"
                            ConfirmText="确定删除此记录？" ConfirmTarget="Top" CommandName="Delete" Width="50px" />
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
        <f:Window ID="Window1" CloseAction="Hide" runat="server" IsModal="true" Hidden="true"
            Target="Top" EnableResize="true" EnableMaximize="true" EnableIFrame="true" IFrameUrl="about:blank"
            Width="900px" Height="500px" OnClose="Window1_Close">
        </f:Window>
    </form>
</body>
</html>
