<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmTABLE_SJX.aspx.cs" Inherits="XASYU.dxxt.frmTABLE_SJX" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TABLE_SJX维护页面</title>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1"  AutoSizePanelID="Panel1" runat="server" />
    <f:Panel ID="Panel1" runat="server" BodyPadding="5px"  
            ShowBorder="false" Layout="VBox" BoxConfigAlign="Stretch" BoxConfigPosition="Start"
            ShowHeader="false" Title="用户管理">
            <Items>
                <f:Form ID="Form2" runat="server" Height="36px" BodyPadding="5px" ShowHeader="false"
                    ShowBorder="false" LabelAlign="Right" >
                    <Rows>
                        <f:FormRow ID="FormRow1" runat="server">
                            <Items>
                                <f:TwinTriggerBox ID="ttbSearchMessage" runat="server" ShowLabel="false" EmptyText="在接收人手机号中搜索"
                                    Trigger1Icon="Clear" Trigger2Icon="Search" ShowTrigger1="false" OnTrigger2Click="ttbSearchMessage_Trigger2Click"
                                    OnTrigger1Click="ttbSearchMessage_Trigger1Click">
                                </f:TwinTriggerBox>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
				 <f:Grid ID="Grid1" runat="server" BoxFlex="1" ShowBorder="true" ShowHeader="false"
                    EnableCheckBoxSelect="true" 
                    DataKeyNames="SJX_id" AllowSorting="true" OnSort="Grid1_Sort"  SortField="SJX_id"
                    SortDirection="DESC" AllowPaging="true" IsDatabasePaging="true" OnPreDataBound="Grid1_PreDataBound"
                    OnRowCommand="Grid1_RowCommand" OnPageIndexChange="Grid1_PageIndexChange">
                    <Toolbars>
                        <f:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                                <f:Button ID="btnNew" runat="server" Icon="Add" EnablePostBack="false" Text="新增收件箱">
                                </f:Button>                   
                                <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                                </f:ToolbarSeparator>
                                <f:Button ID="Button1" EnableAjax="false" Icon="PageExcel" DisableControlBeforePostBack="false"
                               runat="server" Text="导出为Excel文件" OnClick="Button1_Click"> </f:Button>
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
								<f:BoundField DataField="SJX_id" SortField="SJX_id" HeaderText="收件箱序号" Width="200px">
								</f:BoundField>
								<f:BoundField DataField="SJX_mobile" HeaderText="接收人手机号" Width="200px">
								</f:BoundField>
								<f:BoundField DataField="SJX_nr" HeaderText="内容" Width="200px">
								</f:BoundField>
								<f:BoundField DataField="SJX_jstime" HeaderText="接收时间"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
								</f:BoundField>
                        <f:WindowField TextAlign="Center" Icon="Pencil" ToolTip="修改信息" Title="修改信息" 
                            WindowID="Window1" DataIFrameUrlFields="SJX_id" DataIFrameUrlFormatString="frmTABLE_SJXEdit.aspx?SJX_ID={0}"
                            Width="50px" HeaderText="修改"  />
                        <f:WindowField TextAlign="Center" Icon="Information" ToolTip="查看详细信息" Title="查看详细信息"
                            WindowID="Window1" DataIFrameUrlFields="SJX_id" DataIFrameUrlFormatString="frmTABLE_SJXXX.aspx?SJX_ID={0}"
                            Width="50px" HeaderText="详情"  />
                        <f:WindowField TextAlign="Center" Icon="Information" ToolTip="发送短信" Title="发送短信"
                            WindowID="Window1" DataIFrameUrlFields="SJX_id" DataIFrameUrlFormatString="frmTABLE_SJXdxfs.aspx?SJX_ID={0}"
                            Width="50px" HeaderText="发送短信"  />
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