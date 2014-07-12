<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Project_AMDQ.aspx.cs" Inherits="MIS_Project_AMD" %>
<!--#INCLUDE FILE="../checkpass.inc" -->
<!DOCTYPE html>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <link rel="Stylesheet" type="text/css" href="../css/web.css" />
    <link rel="Stylesheet" type="text/css" href="../css/impromptu.css" />
    <link href="../css/bootstrap/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap/bootstrap.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>
    <script type="text/javascript" src="../javascript/system.js"></script>
    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <cc1:ToolkitScriptManager ID="ScriptManager1" runat="server" CombineScripts="false"></cc1:ToolkitScriptManager>
            <br />
            <div >
                <asp:Panel ID="SearchPanel" runat="server">
                    <div style="float: left">
                        <asp:LinkButton ID="cmd_Search" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                            Height="22px" Width="100px" OnClick="lnkbtn_Search_Click">關鍵字搜尋</asp:LinkButton>
                        <asp:DropDownList ID="ddlst_SearchType" runat="server" CssClass="dropdown">
                        </asp:DropDownList>
                        <asp:TextBox ID="txt_Query_Reason" runat="server" AutoCompleteType="Disabled" Width="200px"
                            placeholder="請輸入"></asp:TextBox>
                    </div>
                    <div style="float: right">
                        <asp:LinkButton ID="lnkbtn_Add" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                            OnClientClick="return add()" Height="22px" Width="60px">&nbsp;&nbsp;新增</asp:LinkButton>
                    </div>
                </asp:Panel>
            </div>
        </div>
         <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="2">
                    <ProgressTemplate>
                        <div class="progressBackgroundLayer">
                        </div>
                        <div class="fixedCenter">
                            <img src="../images/ajax-loader2.gif"></div>
                    </ProgressTemplate>
                </asp:UpdateProgress>--%>
                 <div>
        <asp:GridView ID="gv" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource1" CssClass="table table-hover table-striped "
            GridLines="None" CellPadding="4" CellSpacing="1" DataKeyNames="ProjectNO">
            <Columns>
                <asp:BoundField DataField="ProjectNO" HeaderText="計畫序號" SortExpression="ProjectNO" />
                <asp:BoundField DataField="ProjectID" HeaderText="計畫編號" SortExpression="ProjectID" />
                <asp:BoundField DataField="ProjectName" HeaderText="計畫名稱" SortExpression="ProjectName" />
                <asp:BoundField DataField="Client" HeaderText="業主名稱" SortExpression="Client" />
                <asp:BoundField DataField="StartDate" HeaderText="起始日期" SortExpression="StartDate" />
                <asp:BoundField DataField="EndDate" HeaderText="結束日期" SortExpression="EndDate" />
                <asp:BoundField DataField="WarStartDate" HeaderText="保固起始日期" SortExpression="WarStartDate" />
                <asp:BoundField DataField="WarEndDate" HeaderText="保固結束日期" SortExpression="WarEndDate" />
                <asp:BoundField DataField="UpdateTime" HeaderText="更新日期" SortExpression="UpdateTime" />
                <asp:BoundField DataField="UpdateUser" HeaderText="更新人員" SortExpression="UpdateUser" />
                <asp:TemplateField ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="更新"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消"></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="編輯"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="刪除"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MROSConnectionString %>" DeleteCommand="DELETE FROM [ICS_Project] WHERE [ProjectNO] = @ProjectNO" InsertCommand="INSERT INTO [ICS_Project] ([ProjectID], [ProjectName], [Client], [StartDate], [EndDate], [WarStartDate], [WarEndDate], [UpdateTime], [UpdateUser]) VALUES (@ProjectID, @ProjectName, @Client, @StartDate, @EndDate, @WarStartDate, @WarEndDate, @UpdateTime, @UpdateUser)" SelectCommand="SELECT * FROM [ICS_Project]" UpdateCommand="UPDATE [ICS_Project] SET [ProjectID] = @ProjectID, [ProjectName] = @ProjectName, [Client] = @Client, [StartDate] = @StartDate, [EndDate] = @EndDate, [WarStartDate] = @WarStartDate, [WarEndDate] = @WarEndDate, [UpdateTime] = @UpdateTime, [UpdateUser] = @UpdateUser WHERE [ProjectNO] = @ProjectNO">
            <DeleteParameters>
                <asp:Parameter Name="ProjectNO" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ProjectID" Type="Int32" />
                <asp:Parameter Name="ProjectName" Type="String" />
                <asp:Parameter Name="Client" Type="String" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="EndDate" Type="DateTime" />
                <asp:Parameter Name="WarStartDate" Type="DateTime" />
                <asp:Parameter Name="WarEndDate" Type="DateTime" />
                <asp:Parameter Name="UpdateTime" Type="DateTime" />
                <asp:Parameter Name="UpdateUser" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="ProjectID" Type="Int32" />
                <asp:Parameter Name="ProjectName" Type="String" />
                <asp:Parameter Name="Client" Type="String" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="EndDate" Type="DateTime" />
                <asp:Parameter Name="WarStartDate" Type="DateTime" />
                <asp:Parameter Name="WarEndDate" Type="DateTime" />
                <asp:Parameter Name="UpdateTime" Type="DateTime" />
                <asp:Parameter Name="UpdateUser" Type="String" />
                <asp:Parameter Name="ProjectNO" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    
    </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="lnkbtn_Add" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="cmd_Search" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>
