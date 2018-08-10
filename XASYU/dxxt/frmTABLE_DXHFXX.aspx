<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmTABLE_DXHFXX.aspx.cs" Inherits="XASYU.dxxt.frmTABLE_DXHFXX" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>TABLE_DXHF详情页面</title>
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
                                <f:Label id="lblhiddenDXHF_id" runat="server" Label="短信回复序号" />
                                <f:Label id="lbltxtSMS_id" runat="server" Label="发送短信序号" />
                                <f:Label id="lbltxtDXHF_hfrmobile" runat="server" Label="回复人" />
                                <f:Label id="lbltxtDXHF_nr" runat="server" Label="内容" />
                                <f:Label id="lbltxtDXHF_time" runat="server" Label="回复时间" />
		            </Items>
                </f:SimpleForm>
            </Items>
        </f:Panel>
    </form>
</body>
</html>