<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="XASYU._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <f:PageManager ID="PageManager1" runat="server" />
         <f:Button Text="点击弹出对话框" runat="server" ID="btnHello" OnClick="btnHello_Click"></f:Button>

    <div>
    
    </div>
    </form>
</body>
</html>
