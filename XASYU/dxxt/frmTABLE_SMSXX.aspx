<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmTABLE_SMSXX.aspx.cs" Inherits="XASYU.dxxt.frmTABLE_SMSXX" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>TABLE_SMS详情页面</title>
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
                                <f:Label id="lblhiddenSMS_id" runat="server" Label="发送短信序号" />
                                <f:Label id="lbltxtSMS_jsr" runat="server" Label="接收人" />
                                <f:Label id="lbltxtSMS_nr" runat="server" Label="内容" />
                                <f:Label id="lblddlSMS_ljfs" runat="server" Label="立即发送" />
                                <f:Label id="lbldthSMS_fstime" runat="server" Label="发送时间" />
                                <f:Label id="lbldthSMS_dstime" runat="server" Label="定时发送时间" />
                                <f:Label id="lbltxtSMS_dxlx" runat="server" Label="短信类型" />
                                <f:Label id="lblddlSMS_dxzt" runat="server" Label="短信状态" />
                                <f:Label id="lblddlSMS_hzzt" runat="server" Label="回执状态" />
                                <f:Label id="lbltxtSMS_wapdx" runat="server" Label="Wap短信" />
                                <f:Label id="lblddlSMS_fjname" runat="server" Label="是否附加姓名" />
                                <f:Label id="lblddlSMS_zchf" runat="server" Label="是否支持回复" />
                                <f:Label id="lblddlSMS_ztbg" runat="server" Label="状态报告" />
                                <f:Label id="lblddlSMS_hftx" runat="server" Label="回复提醒" />
                                <f:Label id="lbltxtSMS_hmd" runat="server" Label="接收人存在黑名单" />
                                <f:Label id="lblddlSMS_sfzf" runat="server" Label="短信回复后是否转发给发送人" />
                                <f:Label id="lblddlSMS_delete" runat="server" Label="是否删除" />
		            </Items>
                </f:SimpleForm>
            </Items>
        </f:Panel>
    </form>
</body>
</html>