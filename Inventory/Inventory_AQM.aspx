<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inventory_AQM.aspx.cs" Inherits="InventoryAQM" %>
<!--#INCLUDE FILE="../checkpass.inc" -->
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="Stylesheet" type="text/css" href="../css/web.css" />
    <link rel="Stylesheet" type="text/css" href="../css/impromptu.css" />
    <link href="../css/bootstrap/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap/bootstrap.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="../javascript/system.js"></script>

    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>

    <title>保固設備管理-耗材管理</title>

    <script type="text/javascript">

        function pageLoad() {
    
        }

        function addSearchIcon() {
            $('#cmd_Search').prepend("<i class=\"icon-search icon-white\"></i>");
        }

        function add() {
            location.href = "Inventoryadd_A.aspx";
            return false;
        }

    </script>

</head>
<body id="body" runat="server">
    <form id="form1" defaultbutton="cmd_Search"  runat="server">
        <center>
            <div>
                <cc1:ToolkitScriptManager ID="ScriptManager1" runat="server"  CombineScripts="false" ></cc1:ToolkitScriptManager>
                <br />
                <div>
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
                            <asp:LinkButton ID="lnkbtn_Report" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                                Height="22px" OnClick="lnkbtn_Report_Click" Visible="false" Width="60px">&nbsp;&nbsp;匯出</asp:LinkButton>
                            <asp:LinkButton ID="lnkbtn_Add" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                                OnClientClick="return add()" Height="22px" Width="60px">&nbsp;&nbsp;新增</asp:LinkButton>
                        </div>
                    </asp:Panel>
                </div>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="2">
                        <ProgressTemplate>
                            <div class="progressBackgroundLayer">
                            </div>
                            <div class="fixedCenter">
                                <img src="../images/ajax-loader2.gif">
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <div>
                        <asp:GridView ID="gv" runat="server" AllowPaging="True" CssClass="table table-hover "
                            GridLines="None" AutoGenerateColumns="False" CellPadding="4" CellSpacing="1"
                            OnPageIndexChanging="gv_PageIndexChanging" OnRowDataBound="gv_RowDataBound" PageSize="12" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="CustomersGridView_RowDeleting" DataKeyNames="NO">
                            <Columns>
                                <asp:TemplateField HeaderImageUrl="~/images/edit.gif">
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="更新"></asp:LinkButton>
                                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消"></asp:LinkButton>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Edit" Text="編輯"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="NO" HeaderText="耗材編號" ReadOnly="True"></asp:BoundField>
                                <asp:BoundField DataField="MaterialName" HeaderText="名稱" SortExpression="MaterialName">
                                    <ControlStyle Width="50%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PurchaseUnit" HeaderText="採購計量單位" SortExpression="PurchaseUnit">
                                    <ControlStyle Width="50%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ConsumeUnit" HeaderText="領用計量單位" SortExpression="ConsumeUnit">
                                    <ControlStyle Width="50%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ConversionFactor" HeaderText="轉換係數" SortExpression="ConversionFactor">
                                    <ControlStyle Width="50%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MaterialSafeQuantity" HeaderText="安全存量" SortExpression="MaterialSafeQuantity">
                                    <ControlStyle Width="50%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MaterialTypeID" HeaderText="項次別序號" SortExpression="MaterialTypeID">
                                    <ControlStyle Width="50%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MaterialUnit" HeaderText="物料單位" SortExpression="MaterialUnit">
                                    <ControlStyle Width="50%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Active" HeaderText="有效(停用)" SortExpression="Active">
                                    <ControlStyle Width="50%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderImageUrl="~/images/delete.gif">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Delete" Text="刪除" ImageUrl="~/images/x.jpg" OnClientClick="return confirm('再次確認是否刪除?')"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle Font-Bold="True" ForeColor="black" />
                            <HeaderStyle Font-Bold="True" ForeColor="black" />
                        </asp:GridView>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="lnkbtn_Add" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="cmd_Search" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="lnkbtn_Report" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </center>
    </form>
</body>
</html>
