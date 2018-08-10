<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmTABLE_LXR.aspx.cs" Inherits="XASYU.dxxt.frmTABLE_LXR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TABLE_LXR维护页面</title>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1"  AutoSizePanelID="Panel1" runat="server" />
    <f:Panel ID="Panel1" runat="server" BodyPadding="5px"  
            ShowBorder="false" Layout="VBox" BoxConfigAlign="Stretch" BoxConfigPosition="Start"
            ShowHeader="false" Title="用户管理">
            <Items>
                <f:Form ID="Form2" runat="server" Height="66px" BodyPadding="5px" ShowHeader="false"
                    ShowBorder="false" LabelAlign="Right" >
                    <Rows>
                         <f:FormRow ColumnWidths="25% 25% 25% 25%">
                            <Items>
                                  <f:TextBox ID="txtName" runat="server" Label="姓名"></f:TextBox> 
                                  <f:TextBox ID="txtMobile" runat="server" Label="手机号码"></f:TextBox>     
                               <f:Button ID="Button2" runat="server" ValidateForms="Form2" Text="查询" OnClick="Button2_Click">
                                </f:Button>                                                     
                            </Items>
                        </f:FormRow>
                        <f:FormRow ColumnWidths="25% 25% 25% 25%">
                            <Items>
                                  <f:TextBox ID="txtGzdw" runat="server" Label="工作单位"></f:TextBox> 
                                  <f:TextBox ID="txtXb" runat="server" Label="性别"></f:TextBox>                                   
                                  <f:Button ID="Button5" runat="server" Text="重置" OnClick="Button3_Click">
                                  </f:Button>                   
                            </Items>
                        </f:FormRow>

                    </Rows>
                </f:Form>
				 <f:Grid ID="Grid1" runat="server" BoxFlex="1" ShowBorder="true" ShowHeader="false"
                    EnableCheckBoxSelect="true" 
                    DataKeyNames="LXR_id,LXR_mobile,LXR_bz" AllowSorting="true" OnSort="Grid1_Sort"  SortField="LXR_id"
                    SortDirection="DESC" AllowPaging="true" IsDatabasePaging="true" OnPreDataBound="Grid1_PreDataBound"
                    OnRowCommand="Grid1_RowCommand" OnPageIndexChange="Grid1_PageIndexChange">
                    <Toolbars>
                        <f:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                                <f:Button ID="btnNew" runat="server" Icon="Add" EnablePostBack="false" Text="新增联系人">
                                </f:Button>                   
                                <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                                </f:ToolbarSeparator>
                                <f:Button ID="Button1" EnableAjax="false" Icon="PageExcel" DisableControlBeforePostBack="false"
                               runat="server" Text="导出为Excel文件" OnClick="Button1_Click"> </f:Button>
                                <f:ToolbarSeparator ID="ToolbarSeparator3" runat="server">
                                </f:ToolbarSeparator>
                                <f:Button ID="Buttonfs" runat="server" Icon="Add"  Text="短信发送" OnClick="Buttonfs_Click1">
                                </f:Button> 
                                <f:ToolbarFill ID="ToolbarFill1" runat="server">
                                </f:ToolbarFill>
                                <f:Button ID="btnDeleteSelected" Icon="Delete" runat="server" Text="删除选中记录" OnClick="btnDeleteSelected_Click">
                                </f:Button>    
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <PageItems>
                        <f:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                        </f:ToolbarSeparator>
                        <f:ToolbarText ID="ToolbarText1" runat="server" Text="每页记录数：">
                        </f:ToolbarText>
                        <f:DropDownList ID="ddlGridPageSize" Width="80px" AutoPostBack="true" OnSelectedIndexChanged="ddlGridPageSize_SelectedIndexChanged"
                            runat="server">
                            <f:ListItem Text="10" Value="10" />
                            <f:ListItem Text="20" Value="20" />
                            <f:ListItem Text="50" Value="50" />
                            <f:ListItem Text="100" Value="100" />
                        </f:DropDownList>
                    </PageItems>
					<Columns>
						<f:RowNumberField Width="35px" EnablePagingNumber="true" />
								<f:BoundField DataField="LXR_id" SortField="LXR_id" HeaderText="联系人编号" Width="200px">
								</f:BoundField>
								<f:BoundField DataField="LXR_name" SortField="LXR_name" HeaderText="姓名" Width="200px">
								</f:BoundField>
								<f:BoundField DataField="LXR_mobile" HeaderText="手机号码" Width="200px">
								</f:BoundField>
								<f:BoundField DataField="LXR_sex" HeaderText="性别" Width="200px">
								</f:BoundField>
								<f:BoundField DataField="LXR_phone" HeaderText="电话" Width="200px">
								</f:BoundField>
								<f:BoundField DataField="LXR_email" HeaderText="电子邮件" Width="200px">
								</f:BoundField>
								<f:BoundField DataField="LXR_gzdw" HeaderText="工作单位" Width="200px">
								</f:BoundField>
								<f:BoundField DataField="LXR_sfzid" HeaderText="身份证号码" Width="200px">
								</f:BoundField>
								<f:BoundField DataField="LXR_zw" HeaderText="职务" Width="200px">
								</f:BoundField>
								<f:BoundField DataField="LXR_bz" HeaderText="备注" Width="200px">
								</f:BoundField>
								<f:BoundField DataField="LXR_sfjrwh" HeaderText="是否节日问候" Width="200px">
								</f:BoundField>
								<f:BoundField DataField="LXR_csrq" HeaderText="出生日期"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
								</f:BoundField>
								<f:BoundField DataField="LXR_sfsrwh" HeaderText="是否生日问候" Width="200px">
								</f:BoundField>
								<f:BoundField DataField="LXR_gj01" HeaderText="关键日期1"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
								</f:BoundField>
								<f:BoundField DataField="LXR_gj01nr" HeaderText="内容" Width="200px">
								</f:BoundField>
								<f:BoundField DataField="LXR_gj02" HeaderText="关键日期2"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
								</f:BoundField>
								<f:BoundField DataField="LXR_gj02nr" HeaderText="内容" Width="200px">
								</f:BoundField>
								<f:BoundField DataField="LXR_gj03" HeaderText="关键日期3"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
								</f:BoundField>
								<f:BoundField DataField="LXR_gj03nr" HeaderText="内容" Width="200px">
								</f:BoundField>
                        <f:WindowField TextAlign="Center" Icon="Pencil" ToolTip="修改信息" Title="修改信息" 
                            WindowID="Window1" DataIFrameUrlFields="LXR_id" DataIFrameUrlFormatString="frmTABLE_LXREdit.aspx?LXR_ID={0}"
                            Width="50px" HeaderText="修改"  />
                        <f:WindowField TextAlign="Center" Icon="Information" ToolTip="查看详细信息" Title="查看详细信息"
                            WindowID="Window1" DataIFrameUrlFields="LXR_id" DataIFrameUrlFormatString="frmTABLE_LXRXX.aspx?LXR_ID={0}"
                            Width="50px" HeaderText="详情"  />
					</Columns>
                </f:Grid>
            </Items>
        </f:Panel>
        <f:Window ID="Window1" runat="server" IsModal="true" Hidden="true" Target="Top" EnableResize="true"
            EnableMaximize="true" EnableIFrame="true" IFrameUrl="about:blank" Width="800px"
            Height="500px" OnClose="Window1_Close">
        </f:Window>
    </form>
    <script type="text/javascript">
       var basePath = '<%=ResolveUrl("~/") %>';        
        function Open_TabTest(tabID, url, title) {
            parent.addExampleTab.apply(null, [tabID, basePath + url, title, basePath + 'res/icon/tag_blue.png', true]);
        }
        function closeActiveTab() {
                parent.removeActiveTab();
            }
   </script>
</body>
</html>