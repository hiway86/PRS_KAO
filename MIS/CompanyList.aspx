﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompanyList.aspx.cs" Inherits="MIS_CompanyList" %>
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

    <title>保固設備管理-廠商資料維護</title>

    <script type="text/javascript">

        function addSearchIcon() {
            $('#cmd_Search').prepend("<i class=\"icon-search icon-white\"></i>");
        }

        function add() {
            location.href = "CompanyManage.aspx?act=add&id=0";
            return false;
        }
        //修改
        function edit(val) {
            location.href = "CompanyManage.aspx?act=edit&id=" + val;
            return false;
        }
        function del(val) {
            $.prompt('確定要刪除此筆資料?',
            { buttons: { 確定: true, 取消: false },
                submit: function(v, m, f) {
                    if (v) {
                        var Options = {
                            type: "POST",
                            url: "../MISWebService.asmx/DelCompany",
                            data: "{companyid: '" + val + "'}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            error: function(error) {
                                $.prompt('錯誤');
                            },
                            timeout: function(error) {
                                $.prompt('連線逾時');
                            },
                            success: function(response) {
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
                            <img src="../images/ajax-loader2.gif"></div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <div >
                    <asp:GridView ID="gv" runat="server" AllowPaging="True" CssClass="table table-hover "
                        GridLines="None" AutoGenerateColumns="False" CellPadding="4" CellSpacing="1"
                        OnPageIndexChanging="gv_PageIndexChanging" OnRowDataBound="gv_RowDataBound" PageSize="12">
                        <Columns>
                            <asp:TemplateField HeaderImageUrl="~/images/edit.gif">
                                <ItemTemplate>
                                    <asp:Button ID="cmd_Edit" runat="server" Text="修改" CssClass="btn btn-mini btn-info"  />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CompanyID" HeaderText="廠商編號" ReadOnly="True" />
                            <asp:BoundField DataField="CompanyName" HeaderText="廠商名稱" ReadOnly="True" />
                            <asp:BoundField DataField="Contact" HeaderText="聯絡人" ReadOnly="True" />
                            <asp:BoundField DataField="ContactPhone" HeaderText="聯絡人電話" ReadOnly="True" />
                            <asp:BoundField DataField="ContactPhoneExet" HeaderText="聯絡人分機" ReadOnly="True" />
                            <asp:BoundField DataField="ContactMobile" HeaderText="聯絡人手機" ReadOnly="True" />
                            <asp:BoundField DataField="Contact2" HeaderText="聯絡人2" ReadOnly="True" />
                            <asp:BoundField DataField="Contact2Phone" HeaderText="聯絡人2電話" ReadOnly="True" />
                            <asp:BoundField DataField="Contact2PhoneExet" HeaderText="聯絡人2分機" ReadOnly="True" />
                            <asp:BoundField DataField="Contact2Mobile" HeaderText="聯絡人2手機" ReadOnly="True" />
                            <asp:BoundField DataField="Fax" HeaderText="傳真號碼" ReadOnly="True" />
                            <asp:BoundField DataField="Email" HeaderText="信箱" ReadOnly="True" />
                            <asp:BoundField DataField="Address" HeaderText="地址" ReadOnly="True" />
                            <asp:BoundField DataField="CompanyGroup" HeaderText="公司群組" ReadOnly="True" />
                            <asp:BoundField DataField="Note" HeaderText="備註" ReadOnly="True" />
                            <asp:TemplateField HeaderImageUrl="~/images/delete.gif">
                                <ItemTemplate>
                                    <asp:ImageButton ID="cmd_Delete" runat="server" EnableViewState="False" ImageUrl="~/images/x.jpg" />
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
