<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmTABLE_SJXXX.aspx.cs" Inherits="XASYU.dxxt.frmTABLE_SJXXX" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>TABLE_SJX详情页面</title>
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
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
                    BodyPadding="10px"  Title="SimpleForm">
                    <Items>
                                <f:Label id="lblhiddenSJX_id" runat="server" Label="收件箱序号" />
                                <f:Label id="lbltxtSJX_mobile" runat="server" Label="发送人手机号" />
                                <f:Label id="lbltxtSJX_nr" runat="server" Label="内容" />
                                <f:Label id="lbldthSJX_jstime" runat="server" Label="接收时间" />
		            </Items>
                </f:SimpleForm>
            </Items>
        </f:Panel>
    </form>
</body>
</html>

