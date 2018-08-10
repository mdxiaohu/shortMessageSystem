<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmTABLE_LXRNew.aspx.cs" Inherits="XASYU.dxxt.frmTABLE_LXRNew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>TABLE_LXR编辑</title>
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
                        <f:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
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
                                <f:HiddenField ID="hiddenLXR_id" runat="server" />
                                <f:TextBox ID="txtLXR_name" runat="server" Label="姓名"></f:TextBox>
                                <f:TextBox ID="txtLXR_mobile" runat="server" Label="手机号码"></f:TextBox>
                                <f:TextBox ID="txtLXR_sex" runat="server" Label="性别" AutoPostBack="true">
                                    
                                </f:TextBox>
                                <f:TextBox ID="txtLXR_phone" runat="server" Label="电话"></f:TextBox>
                                <f:TextBox ID="txtLXR_email" runat="server" Label="电子邮件"></f:TextBox>
                                <f:TextBox ID="txtLXR_gzdw" runat="server" Label="工作单位"></f:TextBox>
                                <f:TextBox ID="txtLXR_sfzid"  runat="server" Label="身份证号码"></f:TextBox>
                                <f:TextBox ID="txtLXR_zw" runat="server" Label="职务"></f:TextBox>
                                <f:TextBox ID="txtLXR_bz" runat="server" Label="备注"></f:TextBox>
                                <f:DropDownList ID="ddlLXR_sfjrwh"  runat="server" Label="是否节日问候" AutoPostBack="true">
                                    <f:ListItem Value="True" Text="True"></f:ListItem>
                                    <f:ListItem Value="False" Text="False"></f:ListItem>
                                </f:DropDownList>
                                <f:DatePicker ID="dthLXR_csrq" runat="server" Label="出生日期"></f:DatePicker>
                                <f:DropDownList ID="ddlLXR_sfsrwh"  runat="server" Label="是否生日问候" AutoPostBack="true">
                                    <f:ListItem Value="True" Text="True"></f:ListItem>
                                    <f:ListItem Value="False" Text="False"></f:ListItem>
                                </f:DropDownList>
                                <f:DatePicker ID="dthLXR_gj01" runat="server" Label="关键日期1"></f:DatePicker>
                                <f:TextBox ID="txtLXR_gj01nr" runat="server" Label="内容1"></f:TextBox>
                                <f:DatePicker ID="dthLXR_gj02" runat="server" Label="关键日期2"></f:DatePicker>
                                <f:TextBox ID="txtLXR_gj02nr" runat="server" Label="内容2"></f:TextBox>
                                <f:DatePicker ID="dthLXR_gj03" runat="server" Label="关键日期3"></f:DatePicker>
                                <f:TextBox ID="txtLXR_gj03nr" runat="server" Label="内容3"></f:TextBox>
		            </Items>
                </f:SimpleForm>
            </Items>
        </f:Panel>
    </form>
</body>
</html>