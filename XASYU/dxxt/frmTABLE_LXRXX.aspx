<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmTABLE_LXRXX.aspx.cs" Inherits="XASYU.dxxt.frmTABLE_LXRXX" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>TABLE_LXR详情页面</title>
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
                                <f:Label id="lblhiddenLXR_id" runat="server" Label="联系人编号" />
                                <f:Label id="lbltxtLXR_name" runat="server" Label="姓名" />
                                <f:Label id="lbltxtLXR_mobile" runat="server" Label="手机号码" />
                                <f:Label id="lbltxtLXR_sex" runat="server" Label="性别" />
                                <f:Label id="lbltxtLXR_phone" runat="server" Label="电话" />
                                <f:Label id="lbltxtLXR_email" runat="server" Label="电子邮件" />
                                <f:Label id="lbltxtLXR_gzdw" runat="server" Label="工作单位" />
                                <f:Label id="lbltxtLXR_sfzid" runat="server" Label="身份证号码" />
                                <f:Label id="lbltxtLXR_zw" runat="server" Label="职务" />
                                <f:Label id="lbltxtLXR_bz" runat="server" Label="备注" />
                                <f:Label id="lblddlLXR_sfjrwh" runat="server" Label="是否节日问候" />
                                <f:Label id="lbldthLXR_csrq" runat="server" Label="出生日期" />
                                <f:Label id="lblddlLXR_sfsrwh" runat="server" Label="是否生日问候" />
                                <f:Label id="lbldthLXR_gj01" runat="server" Label="关键日期1" />
                                <f:Label id="lbltxtLXR_gj01nr" runat="server" Label="内容1" />
                                <f:Label id="lbldthLXR_gj02" runat="server" Label="关键日期2" />
                                <f:Label id="lbltxtLXR_gj02nr" runat="server" Label="内容2" />
                                <f:Label id="lbldthLXR_gj03" runat="server" Label="关键日期3" />
                                <f:Label id="lbltxtLXR_gj03nr" runat="server" Label="内容3" />
		            </Items>
                </f:SimpleForm>
            </Items>
        </f:Panel>
    </form>
</body>
</html>