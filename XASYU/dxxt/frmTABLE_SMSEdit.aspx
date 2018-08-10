<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmTABLE_SMSEdit.aspx.cs" Inherits="XASYU.dxxt.frmTABLE_SMSEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>TABLE_SMS编辑</title>
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
                                <f:HiddenField ID="hiddenSMS_id" runat="server"/>
                                <f:TextBox ID="txtSMS_jsr" runat="server" Label="接收人"></f:TextBox>
                                <f:TextBox ID="txtSMS_nr" runat="server" Label="内容"></f:TextBox>
                                <f:DropDownList ID="ddlSMS_ljfs" Label="立即发送"  runat="server"
                                    AutoPostBack="true">
                                    <f:ListItem Value="True" Text="True"></f:ListItem>
                                    <f:ListItem Value="False" Text="False"></f:ListItem>
                                </f:DropDownList>
                                <f:DatePicker ID="dthSMS_fstime" runat="server" Label="发送时间"></f:DatePicker>
                                <f:DatePicker ID="dthSMS_dstime" runat="server" Label="定时发送时间"></f:DatePicker>
                                <f:TextBox ID="txtSMS_dxlx" runat="server" Label="短信类型"></f:TextBox>
                                <f:DropDownList ID="ddlSMS_dxzt"  runat="server" Label="短信状态"
                                    AutoPostBack="true">
                                    <f:ListItem Value="True" Text="True"></f:ListItem>
                                    <f:ListItem Value="False" Text="False"></f:ListItem>
                                </f:DropDownList>
                                <f:DropDownList ID="ddlSMS_hzzt"  runat="server" Label="回执状态"
                                    AutoPostBack="true">
                                     <f:ListItem Value="True" Text="True"></f:ListItem>
                                     <f:ListItem Value="False" Text="False"></f:ListItem>
                                </f:DropDownList>
                                <f:TextBox ID="txtSMS_wapdx" runat="server" Label="Wap短信"></f:TextBox>
                                <f:DropDownList ID="ddlSMS_fjname"  runat="server" Label="是否附加姓名"
                                    AutoPostBack="true">
                                     <f:ListItem Value="True" Text="True"></f:ListItem>
                                     <f:ListItem Value="False" Text="False"></f:ListItem>
                                </f:DropDownList>
                                <f:DropDownList ID="ddlSMS_zchf"  runat="server" Label="是否支持回复"
                                    AutoPostBack="true">
                                     <f:ListItem Value="True" Text="True"></f:ListItem>
                                     <f:ListItem Value="False" Text="False"></f:ListItem>
                                </f:DropDownList>
                                <f:DropDownList ID="ddlSMS_ztbg"  runat="server" Label="状态报告"
                                    AutoPostBack="true">
                                     <f:ListItem Value="True" Text="True"></f:ListItem>
                                     <f:ListItem Value="False" Text="False"></f:ListItem>
                                </f:DropDownList>
                                <f:DropDownList ID="ddlSMS_hftx"  runat="server" Label="回复提醒"
                                    AutoPostBack="true">
                                     <f:ListItem Value="True" Text="True"></f:ListItem>
                                     <f:ListItem Value="False" Text="False"></f:ListItem>
                                </f:DropDownList>
                                <f:TextBox ID="txtSMS_hmd" runat="server" Label="接收人存在黑名单"></f:TextBox>
                                <f:DropDownList ID="ddlSMS_sfzf"  runat="server" Label="短信回复后是否转发给发送人"
                                    AutoPostBack="true">
                                     <f:ListItem Value="True" Text="True"></f:ListItem>
                                     <f:ListItem Value="False" Text="False"></f:ListItem>
                                </f:DropDownList>
                                <f:DropDownList ID="ddlSMS_delete"  runat="server" Label="是否删除"
                                    AutoPostBack="true">
                                     <f:ListItem Value="True" Text="True"></f:ListItem>
                                     <f:ListItem Value="False" Text="False"></f:ListItem>
                                </f:DropDownList>
		            </Items>
                </f:SimpleForm>
            </Items>
        </f:Panel>
    </form>
</body>
</html>