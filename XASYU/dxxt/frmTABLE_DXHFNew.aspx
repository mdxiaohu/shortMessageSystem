<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmTABLE_DXHFNew.aspx.cs" Inherits="XASYU.dxxt.frmTABLE_DXHFNew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>TABLE_DXHF编辑</title>
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
                                <f:HiddenField ID="hiddenDXHF_id" runat="server" />
                                <f:TextBox ID="txtSMS_id"  runat="server" Label="发送短信序号"></f:TextBox>
                                <f:TextBox ID="txtDXHF_hfrmobile" runat="server" Label="回复人"></f:TextBox>
                                <f:TextBox ID="txtDXHF_nr" runat="server" Label="内容"></f:TextBox>
                                <f:TextBox ID="txtDXHF_time" runat="server" Label="回复时间"></f:TextBox>
		            </Items>
                </f:SimpleForm>
            </Items>
        </f:Panel>
    </form>
</body>
</html>