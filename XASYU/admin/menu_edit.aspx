<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menu_edit.aspx.cs" Inherits="XASYU.admin.menu_edit" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
        <f:Panel ID="Panel1" ShowBorder="false" ShowHeader="false"  AutoScroll="true" runat="server">
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <f:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                            Text="关闭">
                        </f:Button>
                        <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                        </f:ToolbarSeparator>
                        <f:Button ID="btnSaveClose" ValidateForms="SimpleForm1" Icon="SystemSaveClose"
                            OnClick="btnSaveClose_Click" runat="server" Text="保存后关闭">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
                    BodyPadding="10px"  Title="SimpleForm">
                    <Items>
                        <f:TextBox ID="tbxName" runat="server" Label="菜单名称" Required="true" ShowRedStar="true">
                        </f:TextBox>
                        <f:DropDownList ID="ddlParent" Label="上级菜单" Required="true" ShowRedStar="true"
                            runat="server">
                        </f:DropDownList>
                        <f:NumberBox ID="tbxSortIndex" Label="排序" Required="true" ShowRedStar="true" runat="server">
                        </f:NumberBox>
                        <f:TextBox ID="tbxViewPower" runat="server" Label="浏览权限">
                        </f:TextBox>
                        <f:TextBox ID="tbxUrl" runat="server" Label="链接">
                        </f:TextBox>
                        <f:TextBox ID="tbxIcon" runat="server" Label="图标">
                        </f:TextBox>
                        <f:RadioButtonList ID="iconList" ColumnNumber="4" ShowEmptyLabel="true" runat="server">
                        </f:RadioButtonList>
                        <f:TextArea ID="tbxRemark" runat="server" Label="备注">
                        </f:TextArea>
                    </Items>
                </f:SimpleForm>
            </Items>
        </f:Panel>
    </form>
    <script type="text/javascript">
        F.ready(function () {
            var iconList = F('<%= iconList.ClientID %>');
            var tbxIcon = F('<%= tbxIcon.ClientID %>');

            iconList.on('change', function () {
                tbxIcon.setValue(iconList.f_getSelectedValues()[0]);
            });

            tbxIcon.on('change', function () {
                iconList.f_setValue(tbxIcon.getValue());
            });
        });
    </script>
</body>
</html>
