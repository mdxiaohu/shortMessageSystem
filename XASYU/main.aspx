<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="XASYU.main" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>首页</title>
    <link href="res/css/main.css" rel="stylesheet" />
    <style type="text/css">
        .bottomtable
        {
            width: 100%;
            font-size: 12px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="regionPanel" runat="server" />
        <f:RegionPanel ID="regionPanel" ShowBorder="false" runat="server">
            <Regions>
                <f:Region ID="regionTop" CssClass="region-top" ShowBorder="false" ShowHeader="false" Position="Top"
                    Layout="Fit" runat="server">
                    <Content>
                        <div id="header">
                            <img src="./res/images/login/login_7.png" class="logo" alt="Logo" />
                            <asp:HyperLink ID="linkSystemTitle" CssClass="title" runat="server" NavigateUrl="~/main.aspx"></asp:HyperLink>
                        </div>
                    </Content>
                    <Toolbars>
                        <f:Toolbar ID="topRegionToolbar" Position="Bottom" CssClass="topbar" runat="server">
                            <Items>
                                <f:ToolbarText ID="txtUser" runat="server">
                                </f:ToolbarText>
                                <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server" />
                                <f:ToolbarText ID="txtOnlineUserCount" runat="server">
                                </f:ToolbarText>
                                <f:ToolbarSeparator ID="ToolbarSeparator2" runat="server" />
                                <f:ToolbarText ID="ToolbarText1" runat="server" Text="当前时间："></f:ToolbarText>
                                <f:ToolbarText ID="txtCurrentTime" runat="server">
                                </f:ToolbarText>
                                <f:ToolbarFill ID="ToolbarFill1" runat="server" />
                                <f:Button ID="btnRefresh" runat="server" Icon="Reload" ToolTip="刷新主区域内容" EnablePostBack="false">
                                </f:Button>
                                <f:ToolbarSeparator ID="ToolbarSeparator3" runat="server" />
                                <f:Button ID="btnHelp" EnablePostBack="false" Icon="Help" Text="帮助" runat="server">
                                </f:Button>
                                <f:ToolbarSeparator ID="ToolbarSeparator4" runat="server" />
                                <f:Button ID="btnExit" runat="server" Icon="UserRed" Text="安全退出" ConfirmText="确定退出系统？"
                                    OnClick="btnExit_Click">
                                </f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                </f:Region>
                <f:Region ID="regionLeft" Split="true"
                    EnableCollapse="true" Width="200px"
                    ShowHeader="true" Title="系统菜单" Layout="Fit" Position="Left" runat="server">
                </f:Region>
                <f:Region ID="mainRegion" ShowHeader="false" Layout="Fit" Position="Center"
                    runat="server">
                    <Items>
                        <f:TabStrip ID="mainTabStrip" EnableTabCloseMenu="true" ShowBorder="false" runat="server">
                            <Tabs>
                                <f:Tab ID="Tab1" Title="首页" EnableIFrame="true" IFrameUrl="~/frm_ControlPanel.aspx"
                                    Icon="House" runat="server">
                                </f:Tab>
                            </Tabs>
                        </f:TabStrip>
                    </Items>
                </f:Region>

                <f:Region ID="bottomPanel" RegionPosition="Bottom" ShowBorder="false" ShowHeader="false" Position="Bottom"
                    EnableCollapse="false" runat="server" Layout="Fit">
                    <Items>
                        <f:ContentPanel ID="ContentPanel1" runat="server" ShowBorder="false" ShowHeader="false">
                            <table class="bottomtable">
                                <tr>
                                    <td style="text-align: center;">Copyright 2018 &copy; Dababa-短信发送系统</td>
                                </tr>
                            </table>
                        </f:ContentPanel>
                    </Items>
                </f:Region>
            </Regions>
        </f:RegionPanel>
        <f:Window ID="Window1" runat="server" IsModal="true" Hidden="true" EnableIFrame="true"
            EnableResize="true" EnableMaximize="true" IFrameUrl="about:blank" Width="800px"
            Height="500px">
        </f:Window>
        <a id="toggleheader" href="javascript:;"></a>
    </form>
    <script src="res/js/jquery.min.js"></script>
    <script src="res/js/main.js" type="text/javascript"></script>
</body>
</html>
