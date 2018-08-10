<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_edit.aspx.cs" Inherits="XASYU.admin.user_edit" %>

<!DOCTYPE html>
<html>
<head runat="server">
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
                        <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                        </f:ToolbarSeparator>
                        <f:Button ID="btnSaveClose" ValidateForms="SimpleForm1" Icon="SystemSaveClose" OnClick="btnSaveClose_Click"
                            runat="server" Text="保存后关闭">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:Form ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server" BodyPadding="10px"
                     Title="SimpleForm">
                    <Rows>
                        <f:FormRow ID="FormRow1" runat="server">
                            <Items>
                                <f:Label ID="labName" runat="server" Label="用户名">
                                </f:Label>
                                <f:TextBox ID="tbxRealName" runat="server" Label="中文名" Required="true" ShowRedStar="true">
                                </f:TextBox>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow2" runat="server">
                            <Items>
                                <f:RadioButtonList ID="ddlGender" Label="性别" Required="true" ShowRedStar="true" runat="server">
                                    <f:RadioItem Text="男" Value="男" />
                                    <f:RadioItem Text="女" Value="女" />
                                </f:RadioButtonList>
                                <f:CheckBox ID="cbxEnabled" runat="server" Label="是否启用">
                                </f:CheckBox>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow5" runat="server">
                            <Items>
                                <f:DatePicker ID="date_stu_birth"    Label="出生日期" Enabled="true" Required="true" ShowRedStar="true"   runat="server"></f:DatePicker>
                                <f:DropDownList ID="ddlNation"   Label="民族" runat="server">  </f:DropDownList>
                            </Items>
                        </f:FormRow>

                        <f:FormRow ID="FormRow6" runat="server">
                            <Items>
                                <f:DropDownList ID="ddlXL" runat="server"  Label="学历" Required="true" ShowRedStar="true">
                                </f:DropDownList>
                                 <f:DropDownList ID="ddlXW" runat="server"  Label="学位" Required="true" ShowRedStar="true">
                                </f:DropDownList>
                            </Items>
                        </f:FormRow>
                         <f:FormRow ID="FormRow4" runat="server">
                            <Items>
                               
                                <f:TextBox ID="txtPosion" runat="server" Label="职务">
                                </f:TextBox>
                                <f:TextBox ID="txtQQ" runat="server" Label="QQ">
                                </f:TextBox>
                            </Items>
                        </f:FormRow>
                         <f:FormRow ID="FormRow7" runat="server">
                            <Items>
                                <f:DropDownList ID="ddlPolitical" runat="server" Label="政治面貌" Required="true" ShowRedStar="true">
                                </f:DropDownList>
                                <f:TextBox ID="tbxEmail" runat="server" Label="邮箱" Required="true" ShowRedStar="true"
                                    RegexPattern="EMAIL">
                                </f:TextBox>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow3" runat="server">
                            <Items>
                                <f:TextBox ID="tbxOfficePhone" runat="server" Label="工作电话">
                                </f:TextBox>
                                    <f:TextBox ID="tbxCellPhone" runat="server" Label="手机号">
                                </f:TextBox>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow8" runat="server">
                            <Items>
                                <f:TextBox ID="txtYjfx" runat="server" Label="研究方向">
                                </f:TextBox>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow9" runat="server">
                            <Items>
                                <f:TriggerBox ID="tbSelectedRole" EnableEdit="false" EnablePostBack="false" TriggerIcon="Search"
                                    Label="所属角色" runat="server">
                                </f:TriggerBox>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow10" runat="server">
                            <Items>
                                <f:TriggerBox ID="tbSelectedDept" EnableEdit="false" EnablePostBack="false" TriggerIcon="Search"
                                    Label="所属部门" runat="server">
                                </f:TriggerBox>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow11" runat="server">
                            <Items>
                                <f:TriggerBox ID="tbSelectedTitle" EnableEdit="false" EnablePostBack="false" TriggerIcon="Search"
                                    Label="拥有职称" runat="server">
                                </f:TriggerBox>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow12" runat="server">
                            <Items>
                                <f:TextArea ID="tbxRemark" runat="server" Label="备注">
                                </f:TextArea>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
            </Items>
        </f:Panel>
        <f:HiddenField ID="hfSelectedRole" runat="server">
        </f:HiddenField>
        <f:HiddenField ID="hidPassword" runat="server">
        </f:HiddenField>
        <f:HiddenField ID="hfSelectedDept" runat="server">
        </f:HiddenField>
        <f:HiddenField ID="hfSelectedTitle" runat="server">
        </f:HiddenField>
        <f:Window ID="Window1" Title="编辑" Hidden="true" EnableIFrame="true" runat="server"
            EnableMaximize="true" EnableResize="true" Target="Top" IsModal="True" Width="550px"
            Height="350px">
        </f:Window>
    </form>
</body>
</html>
