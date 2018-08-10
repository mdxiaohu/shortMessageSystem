<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmTABLE_SMS.aspx.cs" Inherits="XASYU.dxxt.frmTABLE_SMS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TABLE_SMS维护页面</title>
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
                                <f:TwinTriggerBox ID="ttbSearchMessage" runat="server" ShowLabel="false" EmptyText="在接收人中搜索"
                                    Trigger1Icon="Clear" Trigger2Icon="Search" ShowTrigger1="false" OnTrigger2Click="ttbSearchMessage_Trigger2Click"
                                    OnTrigger1Click="ttbSearchMessage_Trigger1Click">
                                </f:TwinTriggerBox>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
				 <f:Grid ID="Grid1" runat="server" BoxFlex="1" ShowBorder="true" ShowHeader="false"
                    EnableCheckBoxSelect="true" 
                    DataKeyNames="SMS_id" AllowSorting="true" OnSort="Grid1_Sort"  SortField="SMS_id"
                    SortDirection="DESC" AllowPaging="true" IsDatabasePaging="true" OnPreDataBound="Grid1_PreDataBound"
                    OnRowCommand="Grid1_RowCommand" OnPageIndexChange="Grid1_PageIndexChange">
                    <Toolbars>
                        <f:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                                <f:Button ID="btnNew" runat="server" Icon="Add" EnablePostBack="false" Text="新增短信发送">
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
								<f:BoundField DataField="SMS_id" SortField="SMS_id" HeaderText="发送短信序号" Width="200px" >
								</f:BoundField>
								<f:BoundField DataField="SMS_jsr" HeaderText="接收人" Width="200px">
								</f:BoundField>
								<f:BoundField DataField="SMS_nr" HeaderText="内容" Width="200px">
								</f:BoundField>
								<f:BoundField DataField="SMS_ljfs" HeaderText="立即发送" Width="200px">
								</f:BoundField>
								<f:BoundField DataField="SMS_fstime" HeaderText="发送时间"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
								</f:BoundField>
								<f:BoundField DataField="SMS_dstime" HeaderText="定时发送时间"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
								</f:BoundField>
								<f:BoundField DataField="SMS_dxlx" HeaderText="短信类型" Width="200px">
								</f:BoundField>
								<f:BoundField DataField="SMS_dxzt" HeaderText="短信状态" Width="200px">
								</f:BoundField>
								<f:BoundField DataField="SMS_hzzt" HeaderText="回执状态" Width="200px">
								</f:BoundField>
								<f:BoundField DataField="SMS_wapdx" HeaderText="Wap短信" Width="200px">
								</f:BoundField>
								<f:BoundField DataField="SMS_fjname" HeaderText="是否附加姓名" Width="200px">
								</f:BoundField>
								<f:BoundField DataField="SMS_zchf" HeaderText="是否支持回复" Width="200px">
								</f:BoundField>
								<f:BoundField DataField="SMS_ztbg" HeaderText="状态报告" Width="200px">
								</f:BoundField>
								<f:BoundField DataField="SMS_hftx" HeaderText="回复提醒" Width="200px">
								</f:BoundField>
								<f:BoundField DataField="SMS_hmd" HeaderText="接收人存在黑名单" Width="200px">
								</f:BoundField>
								<f:BoundField DataField="SMS_sfzf" HeaderText="短信回复后是否转发给发送人" Width="200px">
								</f:BoundField>
								<f:BoundField DataField="SMS_delete" HeaderText="是否删除" Width="200px">
								</f:BoundField>
                        <f:WindowField TextAlign="Center" Icon="Pencil" ToolTip="修改信息" Title="修改信息" 
                            WindowID="Window1" DataIFrameUrlFields="SMS_id" DataIFrameUrlFormatString="frmTABLE_SMSEdit.aspx?SMS_ID={0}"
                            Width="50px" HeaderText="修改"  />
                        <f:WindowField TextAlign="Center" Icon="Information" ToolTip="查看详细信息" Title="查看详细信息"
                            WindowID="Window1" DataIFrameUrlFields="SMS_id" DataIFrameUrlFormatString="frmTABLE_SMSXX.aspx?SMS_ID={0}"
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