<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StockReOut_QM.aspx.cs" Inherits="Inventory_StockReOut_QM" %>
<!--#INCLUDE FILE="../checkpass.inc" -->
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="Stylesheet" type="text/css" href="../css/web.css" />
    
    <link href="../css/bootstrap/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap/bootstrap.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>
    <script type="text/javascript" src="../javascript/system.js"></script>

    <script type="text/javascript" src="../javascript/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="../javascript/jquery.dynDateTime.min.js"></script>
    <script type="text/javascript" src="../javascript/calendar-en.min.js"></script>
    <link href="../css/TimePicker/calendar-blue.css" rel="stylesheet" />
    <link rel="Stylesheet" type="text/css" href="../css/impromptu.css" />   
     <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>
    <title>物料管理-退繳作業</title>

    <script type="text/javascript">
        function pageLoad() {
           
        }

        function addSearchIcon() {
            $('#cmd_Search').prepend("<i class=\"icon-search icon-white\"></i>");
        }

        $(document).ready(function () {
            $("#<%=txt_startDateTime.ClientID %>").dynDateTime({
                showsTime: true,
                ifFormat: "%Y/%m/%d %H:%M",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });
        });

        $(document).ready(function () {
            $("#<%=txt_endDateTime.ClientID %>").dynDateTime({
                showsTime: true,
                ifFormat: "%Y/%m/%d %H:%M",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });
        });

        function add() {
            location.href = "StockOut_AM.aspx?act=add&id=0";
            return false;
        }
        //修改
        function edit(val) {
            location.href = "StockOut_AM.aspx?act=edit&id=" + val;
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
                <cc1:ToolkitScriptManager ID="ScriptManager1" runat="server" CombineScripts="false"></cc1:ToolkitScriptManager>
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
                            <asp:TextBox ID="txt_startDateTime" runat="server" CssClass="span2"></asp:TextBox><img src="../images/calendar.png" />
                            <asp:TextBox ID="txt_endDateTime" runat="server" CssClass="span2"></asp:TextBox><img src="../images/calendar.png" />
                        </div>
                        <%--<div style="float: right">
                            <asp:LinkButton ID="lnkbtn_Add" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                                OnClientClick="return add()" Height="22px" Width="60px">&nbsp;&nbsp;出庫</asp:LinkButton>
                        </div>--%>
                    </asp:Panel>
                </div>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
                <ContentTemplate>
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="2">
                    <ProgressTemplate>
                        <div class="progressBackgroundLayer">
                        </div>
                        <div class="fixedCenter">
                            <img src="../images/ajax-loader2.gif"></div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                    <asp:HiddenField ID="hid_stockOutid" runat="server" />
                    <div>
                        <asp:GridView ID="gv" runat="server" AllowPaging="True" CssClass="table table-hover  "
                            GridLines="None" AutoGenerateColumns="False" CellPadding="4" CellSpacing="1"
                            OnPageIndexChanging="gv_PageIndexChanging" PageSize="5" OnRowDataBound="gv_RowDataBound" OnRowCommand="gv_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderImageUrl="~/images/edit.gif">
                                    <ItemTemplate>
                                        <asp:Button ID="btn_Search" runat="server" Text="查詢" CommandName="Search" CssClass="btn btn-mini btn-primary" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="StockOutID" HeaderText="出庫單編號" />
                                <asp:BoundField DataField="CaseID" HeaderText="工單編號" />
                                <asp:BoundField DataField="ProjectID" HeaderText="計畫編號" />
                                <asp:BoundField DataField="ProjectName" HeaderText="計畫名稱" />
                                <asp:BoundField DataField="RegionID" HeaderText="地區編號" />
                                <asp:BoundField DataField="RegionName" HeaderText="地區" />
                                <asp:BoundField DataField="StockOutDate" HeaderText="出庫時間" />
                                <asp:BoundField DataField="StockOutUser" HeaderText="出庫者" />
                                <asp:BoundField DataField="IsOut" HeaderText="出庫完成" />
                                <asp:BoundField DataField="Description" HeaderText="備註" />
                            </Columns>
                            <FooterStyle Font-Bold="True" ForeColor="black" />
                            <HeaderStyle Font-Bold="True" ForeColor="black" />
                        </asp:GridView>
                    </div>
                    <div class='container-fluid'>
                        <div class="row-fluid">
                            <div>
                                <fieldset>
                                    <asp:Label ID="lbl_stockitem" runat="server" Text="出庫單內容" Visible="False" CssClass="alert alert-info"></asp:Label>
                                    <asp:GridView ID="gv_stockOutitem" runat="server" AllowPaging="True" CssClass="table table-hover  "
                                        GridLines="None" AutoGenerateColumns="False" CellPadding="4" CellSpacing="1" PageSize="3" OnPageIndexChanging="gv_stockitem_PageIndexChanging" OnRowCancelingEdit="gv_stockOutitem_RowCancelingEdit" OnRowEditing="gv_stockOutitem_RowEditing" OnRowUpdating="gv_stockOutitem_RowUpdating" DataKeyNames="StockOutItemID">
                                        <Columns>
                                            <asp:TemplateField HeaderImageUrl="~/images/edit.gif">
                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="更新"></asp:LinkButton>
                                                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消"></asp:LinkButton>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Edit" Text="退繳"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="StockOutItemID" HeaderText="出庫單序號" ReadOnly="True"/>
                                            <asp:BoundField DataField="StockOutID" HeaderText="出庫單編號" ReadOnly="True"/>
                                            <asp:BoundField DataField="MaterialID" HeaderText="物料編號" ReadOnly="True"/>
                                            <asp:BoundField DataField="MaterialName" HeaderText="物料名稱" ReadOnly="True"/>
                                            <asp:BoundField DataField="MaterialUnit" HeaderText="單位" ReadOnly="True"/>
                                            <asp:BoundField DataField="ConsumeQuantity" HeaderText="領用數量" ReadOnly="True"/>
                                            <asp:BoundField DataField="ReConsumeQuantity" HeaderText="退繳數量" >
                                            <ControlStyle Width="50%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="MaterialCost" HeaderText="料價" ReadOnly="True"/>
                                            <asp:BoundField DataField="StockOutCost" HeaderText="領用成本" ReadOnly="True"/>
                                            <asp:BoundField DataField="StockOutUse" HeaderText="用途" ReadOnly="True"/>
                                            <asp:BoundField DataField="UpdateTime" HeaderText="更新時間" ReadOnly="True"/>
                                            <asp:BoundField DataField="UpdateUser" HeaderText="更新者" ReadOnly="True"/>
                                        </Columns>
                                        <FooterStyle Font-Bold="True" ForeColor="black" />
                                        <HeaderStyle Font-Bold="True" ForeColor="black" />
                                    </asp:GridView>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
               
            </asp:UpdatePanel>
        </center>
    </form>
</body>
</html>

