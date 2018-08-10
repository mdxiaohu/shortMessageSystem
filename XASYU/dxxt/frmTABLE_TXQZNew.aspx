﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmTABLE_TXQZNew.aspx.cs" Inherits="XASYU.dxxt.frmTABLE_TXQZNew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>TABLE_TXQZ编辑</title>
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
                                <f:HiddenField ID="hiddenTXQZ_id" runat="server" />
                                <f:TextBox ID="txtTXQZ_name" runat="server" Label="群组名"></f:TextBox>
                                <f:TextBox ID="txtTXQZ_sjid"  runat="server" Label="上级群组"></f:TextBox>
		            </Items>
                </f:SimpleForm>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
