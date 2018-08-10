<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_KytzXQ.aspx.cs" Inherits="XASYU.Jbxx.frm_KytzXQ" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
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
                        <f:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                        </f:ToolbarSeparator>
                     
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
                    BodyPadding="10px"  Title="SimpleForm">
                    <Items>
                        <f:Label ID="lblTzmc" runat="server" Label="通知名称" >
                        </f:Label>
                        <f:Label ID="lblTznr" Label="通知内容"  runat="server">
                        </f:Label>
                        <f:Label ID="lblTzr" runat="server" Label="发布人" >
                        </f:Label>
                        <f:Label ID="lblstartDate" runat="server" Label="开始时间"></f:Label>
                        <f:Label ID="lblendDate" runat="server" Label="结束时间"></f:Label>
                         <f:Label ID="lblBz" Label="备注" runat="server">
                        </f:Label>
                    </Items>
                </f:SimpleForm>
            </Items>
        </f:Panel>
    </form>
</body>
</html>