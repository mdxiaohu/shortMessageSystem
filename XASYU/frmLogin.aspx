<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="XASYU.frmLogin" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"> 
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>DBB-短信发送系统</title>
    <link id="Link1" href="~/LoginStyle/style/alogin.css" runat="server" rel="Stylesheet" type="text/css" />
    <link id="Link2" href="~/LoginStyle/style/code.css"  runat="server" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="LoginStyle/JS/code.js"></script>
    <script type="text/javascript">
        // 本页面一定是顶层窗口，不会嵌在IFrame中
        if (top.window != window) {
            top.window.location.href = "./frmLogin.aspx";
        }

        // 将 localhost 转换为 localhost/default.aspx
        if (window.location.href.indexOf('/frmLogin.aspx') < 0) {
            window.location.href = "./frmLogin.aspx";
        }
    </script>
    
</head>
<body onload="createCode();">
    <form id="form1" runat="server"  onsubmit="return checkNULL()">
    <div id="Div1" class="Main" runat="server">
        <ul>
            <li id="Li1" class="top" runat="server"></li>
            <li id="Li2" class="top2" runat="server"></li>
            <li id="Li3" class="topA" runat="server"></li>
            <li id="Li4" class="topB" runat="server"><span>
                <asp:Image ID="Image2" runat="server" ImageUrl="~/LoginStyle/images/login/logo.gif"/>
            </span></li>
            <li id="Li5" class="topC" runat="server"></li>
            <li id="Li6" class="topD" runat="server">
                <ul id="Ul1" class="login" runat="server">
                    <li>
                        <span class="left">用户名：</span> 
                        <span>
                        <asp:TextBox ID="tbxUserName" runat="server" class="txt"></asp:TextBox>
                        </span>
                    </li>
                    <li><span class="left">密 码：</span> 
                        <span>
                        <asp:TextBox ID="tbxPassword" runat="server" class="txt" TextMode="Password"></asp:TextBox>
                        </span>
                    </li>
                         <li><span class="left">验证码：</span>
                              <span>
                    <asp:TextBox id="tbxuserCode"  runat="server" class="txtCode"> </asp:TextBox>
                    <asp:TextBox id="tbxcheckCode"  runat="server" class="txtCodeYZM" ReadOnly="true"> </asp:TextBox>
                                  <a href="#" onclick="createCode()">刷新</a> 
                    </span>
                    </li>      
                </ul>
            </li>
            <li class="topE"></li>
            <li class="middle_A"></li>
            <li class="middle_B"></li>
            <li class="middle_C">
            <span class="btn">         
                <asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="~/LoginStyle/images/login/btnlogin.gif" OnClick="btnSubmit_Click"/>         
          &nbsp; 
                <img id="Img1" runat="server" alt="" src="~/LoginStyle/images/login/btnReset.png" OnClick="formReset()"/>     
            </span>

            </li>
            <li class="middle_D"></li>
            <li class="bottom_A"><span class="leftBottom">CopyRight @2018 Dababa-短信发送系统</span></li>
            <li class="bottom_B"></li>
        </ul>
    </div>
    </form>
</body>
</html>

