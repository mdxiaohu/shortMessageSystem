<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_KytzEdit.aspx.cs" 
    Inherits="XASYU.Jbxx.frm_KytzEdit" %>

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
                        <f:TextBox ID="tbxTzmc" runat="server" Label="通知名称" Required="true" ShowRedStar="true">
                        </f:TextBox>
                        <f:TextArea ID="tbxTznr" Label="通知内容" Height="200px" runat="server" Required="true" ShowRedStar="true">
                        </f:TextArea>
                        <f:TextBox ID="tbxTzr" runat="server" Label="发布人" Required="true" ShowRedStar="true">
                        </f:TextBox>
                        <f:DatePicker ID="startDate" runat="server" Label="开始时间" Required="true" ShowRedStar="true"></f:DatePicker>
                        <f:DatePicker ID="endDate" runat="server" Label="结束时间"   Required="true" ShowRedStar="true"></f:DatePicker>
                         <f:TextArea ID="tbxBz" Label="备注" runat="server">
                        </f:TextArea>
                    </Items>
                </f:SimpleForm>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
