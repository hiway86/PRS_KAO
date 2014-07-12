<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DoorSill_Q.aspx.cs" Inherits="VDCheck_DoorSill_Q" %>
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
    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>

    <title>VD資料檢核-門檻值設定</title>

    <script type="text/javascript">

        function addSearchIcon() {
            $('#cmd_Search').prepend("<i class=\"icon-search icon-white\"></i>");
        }

        function add() {
            location.href = "DoorSill_AM.aspx?act=add&id=0";
            return false;
        }
        //修改
        function edit(val) {
            location.href = "DoorSill_AM.aspx?act=edit&id=" + val;
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
                            url: "../MISWebService.asmx/DelCompany",
                            data: "{companyid: '" + val + "'}",
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
                <div >
                    <asp:GridView ID="gv" runat="server" AllowPaging="True" CssClass="table table-hover "
                        GridLines="None" AutoGenerateColumns="False" CellPadding="4" CellSpacing="1"
                        OnPageIndexChanging="gv_PageIndexChanging" OnRowDataBound="gv_RowDataBound" PageSize="10" OnRowCommand="gv_RowCommand" >
                        <Columns>
                            <asp:TemplateField HeaderImageUrl="~/images/edit.gif">
                                <ItemTemplate>
                                    <asp:Button ID="cmd_Edit" runat="server" Text="修改" CssClass="btn btn-mini btn-info"  />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ID" HeaderText="編號" ReadOnly="True" />
                            <asp:BoundField DataField="DeviceID" HeaderText="設備編號" ReadOnly="True" />
                            <asp:BoundField DataField="SpeedTop" HeaderText="速度上限" ReadOnly="True" />
                            <asp:BoundField DataField="SpeedBottom" HeaderText="速度下限" ReadOnly="True" />
                            <asp:BoundField DataField="OccupyTop" HeaderText="佔有率上限" ReadOnly="True" />
                            <asp:BoundField DataField="OccupyBottom" HeaderText="佔有率下限" ReadOnly="True" />
                            <asp:BoundField DataField="FlowTop" HeaderText="流量上限" ReadOnly="True" />
                            <asp:BoundField DataField="FlowBottom" HeaderText="流量下限" ReadOnly="True" />
                            <asp:BoundField DataField="Description" HeaderText="備註" ReadOnly="True" />
                            <asp:ButtonField HeaderText="刪除" ButtonType="Button" CommandName="cmd_delete" ControlStyle-CssClass="btn btn-mini  btn-info" Text="刪除">
                        </asp:ButtonField>
                        </Columns>
                        <FooterStyle Font-Bold="True" ForeColor="black" />
                        <HeaderStyle Font-Bold="True" ForeColor="black" />
                    </asp:GridView>
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
