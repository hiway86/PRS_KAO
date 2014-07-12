<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StockIn_Q.aspx.cs" Inherits="Inventory_StockIn_Q" %>
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

    <title>物料管理-入庫作業</title>

    <script type="text/javascript">

        function pageLoad() {
      
        }

        function addSearchIcon() {
            $('#cmd_Search').prepend("<i class=\"icon-search icon-white\"></i>");
        }

        function add() {
            location.href = "StockIn_ADM.aspx?act=add&id=0";
            return false;
        }
        //修改
        function edit(val) {
            location.href = "StockIn_ADM.aspx?act=edit&id=" + val;
            return false;
        }
        function del(val) {
            $.prompt('確定要刪除此筆資料?',
            {
                buttons: { 確定: true, 取消: false },
                submit: function (v, m, f) {
                    if (v) {
                        var Options = {
                            type: "POST",
                            url: "../MISWebService.asmx/DelProject",
                            data: "{projectno: '" + val + "'}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            error: function (error) {
                                $.prompt('錯誤');
                            },
                            timeout: function (error) {
                                $.prompt('連線逾時');
                            },
                            success: function (response) {
                                if (response.d) {
                                    $.prompt('刪除成功');
                                    __doPostBack('lnkbtn_Search', '');
                                }
                            }
                        };
                        $.ajax(Options);
                    }
                }
            });
        }
    </script>

</head>
<body id="body" runat="server">
    <form id="form1" defaultbutton="cmd_Search" runat="server">
        <center>
            <div>
                <cc1:toolkitscriptmanager id="ScriptManager1" runat="server" combinescripts="false"></cc1:toolkitscriptmanager>
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
                    <asp:HiddenField ID="hid_stockinid" runat="server" />
                    <div style="padding-right: 40px">
                        <asp:GridView ID="gv" runat="server" AllowPaging="True" CssClass="table table-hover  "
                            GridLines="None" AutoGenerateColumns="False" CellPadding="4" CellSpacing="1"
                            OnPageIndexChanging="gv_PageIndexChanging" PageSize="5" OnRowDataBound="gv_RowDataBound" OnRowCommand="gv_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderImageUrl="~/images/edit.gif">
                                    <ItemTemplate>
                                        <asp:Button ID="btn_Search" runat="server" Text="查詢" CommandName="Search" cssclass="btn btn-mini btn-primary" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="StockInID" HeaderText="入庫單編號" SortExpression="ProjectNO" />
                                <asp:BoundField DataField="UpdateTime" HeaderText="入庫時間" SortExpression="ProjectID" />
                                <asp:BoundField DataField="UpdateUser" HeaderText="更新人員" SortExpression="ProjectName" />
                                <asp:BoundField DataField="Description" HeaderText="備註" SortExpression="Client" />
                                <%--<asp:TemplateField HeaderImageUrl="~/images/edit.gif">
                                    <ItemTemplate>
                                        <asp:Button ID="btn_edit" runat="server" Text="修改" class="btn btn-mini"
                                            onmouseover="this.className='btn btn-mini'" onmouseout="this.className='btn btn-mini'" />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderImageUrl="~/images/delete.gif">
                                    <ItemTemplate>
                                        <asp:Button ID="btn_Delete" runat="server" Text="刪除" CommandName="btnDelete"  cssclass="btn btn-mini btn-primary" />
                                       <%-- <asp:ImageButton ID="cmd_Delete" runat="server" EnableViewState="False" ImageUrl="~/images/x.jpg" />--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle Font-Bold="True" ForeColor="black" />
                            <HeaderStyle Font-Bold="True" ForeColor="black" />
                        </asp:GridView>
                    </div>
                    <div class='container-fluid'>
                        <div class="row-fluid">
                            <div class="span8">
                                <fieldset>
                                    <asp:Label ID="lbl_stockitem" runat="server" Text="入庫單內容" Visible="False" CssClass="alert alert-info"></asp:Label>
                                    <asp:GridView ID="gv_stockitem" runat="server" AllowPaging="True" CssClass="table table-hover  "
                                        GridLines="None" AutoGenerateColumns="False" CellPadding="4" CellSpacing="1" PageSize="3" OnPageIndexChanging="gv_stockitem_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField DataField="StockItemID" HeaderText="序號" />
                                            <asp:BoundField DataField="StockInID" HeaderText="入庫單編號" />
                                            <asp:BoundField DataField="MaterialID" HeaderText="物料編號" />
                                            <asp:BoundField DataField="MaterialName" HeaderText="物料名稱" />
                                            <asp:BoundField DataField="StockIn_Quantity" HeaderText="入庫數量" />
                                            <asp:BoundField DataField="Material_Single_Value" HeaderText="單價" />
                                            <asp:BoundField DataField="StockIn_Cost" HeaderText="小記" />
                                            <asp:BoundField DataField="Stock_Location" HeaderText="存放位置" />
                                            <asp:BoundField DataField="CompanyID" HeaderText="廠商編號" />
                                            <asp:BoundField DataField="ComapnyName" HeaderText="廠商名稱" />
                                            <asp:BoundField DataField="MaterialBrand" HeaderText="廠牌" />
                                            <asp:BoundField DataField="UpdateTime" HeaderText="更新時間" />
                                            <asp:BoundField DataField="UpdateUser" HeaderText="更新者" />
                                        </Columns>
                                        <FooterStyle Font-Bold="True" ForeColor="black" />
                                        <HeaderStyle Font-Bold="True" ForeColor="black" />
                                    </asp:GridView>
                                </fieldset>
                            </div>
                            <div class='span4'>
                                <fieldset>
                                    <div class="row-fluid">
                                    </div>
                                    <asp:Label ID="lbl_stockproject" runat="server" Text="入庫單計畫分攤" CssClass="alert alert-info" Visible="False"></asp:Label>
                                    <asp:GridView ID="gv_stock_project" runat="server" AllowPaging="True" CssClass="table table-hover  "
                                        GridLines="None" AutoGenerateColumns="False" CellPadding="4" CellSpacing="1" OnPageIndexChanging="gv_stock_project_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField DataField="StockInProID" HeaderText="序號" />
                                            <asp:BoundField DataField="StockInID" HeaderText="入庫單編號" />
                                            <asp:BoundField DataField="ProjectID" HeaderText="計畫編號" />
                                            <asp:BoundField DataField="ProjectName" HeaderText="計畫名稱" />
                                            <asp:BoundField DataField="ContractCost" HeaderText="分攤成本" />
                                            <asp:BoundField DataField="UpdateTime" HeaderText="更新時間" />
                                            <asp:BoundField DataField="UpdateUser" HeaderText="更新者" />
                                        </Columns>
                                        <FooterStyle Font-Bold="True" ForeColor="black" />
                                        <HeaderStyle Font-Bold="True" ForeColor="black" />
                                    </asp:GridView>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="lnkbtn_Add" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="cmd_Search" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </center>
    </form>
</body>
</html>
