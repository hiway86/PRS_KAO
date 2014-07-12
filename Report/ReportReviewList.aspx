<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportReviewList.aspx.cs"
    Inherits="Report_ReportReviewList" %>

<!--#INCLUDE FILE="../checkpass.inc" -->
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="Stylesheet" type="text/css" href="../css/web.css" />
    <link rel="Stylesheet" type="text/css" href="../css/impromptu.css" />
    <link href="../css/bootstrap/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap/bootstrap.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../javascript/system.js"></script>
    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>

    
    <link href="../css/impromptu.css" rel="Stylesheet" type="text/css" />
    <link type="text/css" href="../css/jquery1.10.2/jquery-ui.css" rel="stylesheet" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <%--<script type="text/javascript" src="../javascript/jquery-1.9.1.min.js"></script>--%>
    <script type="text/javascript" src="../javascript/jquery-ui-1.10.2.min.js"></script>
    <link href="../css/jquery-ui-timepicker-addon.css" rel="stylesheet" />
    <script type="text/javascript" src="../javascript/jquery-ui-timepicker-addon.js"></script>
    <script type='text/javascript' src='../javascript/jquery-ui-sliderAccess.js'></script>

    <title>案件通報管理-歷史通報案件資料</title>

    <script type="text/javascript">

        function pageLoad() {
        }

        var opt = {
            dateFormat: 'yy-mm-dd',
            showSecond: true,
            timeFormat: 'HH:mm:ss'
        };

        $(document).ready(function () {
            $('#txt_StartDate').datetimepicker(opt);
            $('#txt_EndDate').datetimepicker(opt);
      
            $("#ddlst_SearchType").change(
            function () {
                var SearchType = $("#ddlst_SearchType").find(':selected').val();
                if (SearchType == 'NotifyDate' || SearchType == 'RepairDeadline' || SearchType == 'RepairDate') {
                    $('#SearchDate').css('display', 'inline');
                    $('#txt_Query_Reason').css('display', 'none');
                }
                else {

                    $('#SearchDate').css('display', 'none');
                    $('#txt_Query_Reason').css('display', 'inline');
                }
            }
        );

        });

        function addSearchIcon() {
            $('#cmd_Search').prepend("<i class=\"icon-search icon-white\"></i>");
        }

        function add() {
            location.href = "ReportReturnManage.aspx?act=add&id=0";
            return false;
        }
        //修改
        function edit(val) {
            location.href = "ReportReturnManage.aspx?act=edit&id=" + val;
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
                            url: "../MISWebService.asmx/DelEquipment",
                            data: "{deviceid: '" + val + "'}",
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
                            <asp:LinkButton ID="mapView" runat="server" CssClass="btn btn-primary" Height="22px" Visible="false"
                                Width="100px" OnClick="mapView_Click">地圖檢視</asp:LinkButton>
                            <asp:LinkButton ID="cmd_Search" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                                Height="22px" Width="100px" OnClick="lnkbtn_Search_Click">關鍵字搜尋</asp:LinkButton>
                            <asp:DropDownList ID="ddlst_SearchType" runat="server" CssClass="dropdown span2">
                            </asp:DropDownList>
                            <asp:TextBox ID="txt_Query_Reason" runat="server" AutoCompleteType="Disabled" Width="200px"
                                placeholder="請輸入"></asp:TextBox>
                        </div>
                        <div id ="SearchDate" style="float:left;display: none;">
                            <asp:TextBox ID="txt_StartDate" runat="server"  placeholder="通報時間查詢" CssClass="span3"></asp:TextBox><img src="../images/calendar.png" />
                            <asp:TextBox ID="txt_EndDate" runat="server" placeholder="通報時間查詢" CssClass="span3"></asp:TextBox><img src="../images/calendar.png" />

                    </div>
                        <div style="float: right">
                            <asp:LinkButton ID="lnkbtn_Report" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                                Height="22px" OnClick="lnkbtn_Report_Click" Width="60px" Visible="false">&nbsp;&nbsp;匯出</asp:LinkButton>
                            <asp:LinkButton ID="lnkbtn_Add" runat="server" CausesValidation="False" Visible="false"
                                CssClass="btn btn-primary" OnClientClick="return add()" Height="22px" Width="60px">&nbsp;&nbsp;新增</asp:LinkButton>
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
                    <asp:GridView ID="gv" runat="server" AllowPaging="True" CssClass="table table-hover "
                        GridLines="None" AutoGenerateColumns="False" CellPadding="4" CellSpacing="1"
                        OnPageIndexChanging="gv_PageIndexChanging" OnRowDataBound="gv_RowDataBound"
                        PageSize="11" OnRowCommand="gv_RowCommand">
                        <Columns>
                            <asp:ButtonField ButtonType="Button" CommandName="singleMapView" Text="地圖檢視">
                                <ControlStyle CssClass="btn btn-mini" />
                            </asp:ButtonField>
                            <%-- <asp:TemplateField HeaderImageUrl="~/images/edit.gif">
                            <ItemTemplate>
                                <asp:Button ID="cmd_Edit" runat="server" Text="修改" class="btn btn-mini" onmouseover="this.className='btn btn-mini'"
                                    onmouseout="this.className='btn btn-mini'" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                            <asp:BoundField DataField="CaseID" HeaderText="案件編號" ReadOnly="True" />
                            <asp:BoundField DataField="DeviceID" HeaderText="設備編號" ReadOnly="True" />
                            <asp:BoundField DataField="Device_Kind" HeaderText="設備種類" ReadOnly="True" />
                            <asp:BoundField DataField="FaultDescribe" HeaderText="故障描述" ReadOnly="True" />
                            <asp:BoundField DataField="AreaName" HeaderText="地區" ReadOnly="True" />
                            <asp:BoundField DataField="Location" HeaderText="路口名稱" ReadOnly="True" />
                            <asp:BoundField DataField="WarrantyCompany" HeaderText="保固廠商" ReadOnly="True" />
                            <asp:BoundField DataField="NotifyDate" HeaderText="通知日期" ReadOnly="True" DataFormatString="{0:yyy/MM/dd HH:mm:ss}" />
                            <asp:BoundField DataField="RepairDeadline" HeaderText="修復期限" ReadOnly="True" DataFormatString="{0:yyy/MM/dd HH:mm:ss}" />
                            <asp:BoundField DataField="RepairDate" HeaderText="修復日期" ReadOnly="True"  DataFormatString="{0:yyy/MM/dd HH:mm:ss}" />
                            <asp:ButtonField HeaderText="查詢" ButtonType="Button" CommandName="cmd_materialQuery" ControlStyle-CssClass="btn btn-mini btn-info" Text="使用零件"></asp:ButtonField>
                            <%-- <asp:TemplateField HeaderImageUrl="~/images/delete.gif">
                            <ItemTemplate>
                                <asp:ImageButton ID="cmd_Delete" runat="server" EnableViewState="False" ImageUrl="~/images/x.jpg" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        </Columns>
                        <FooterStyle Font-Bold="True" ForeColor="black" />
                        <HeaderStyle Font-Bold="True" ForeColor="black" />
                    </asp:GridView>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="lnkbtn_Add" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="cmd_Search" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="lnkbtn_Report" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="gv2" runat="server" AllowPaging="True" CssClass="table table-hover "
                        GridLines="None" AutoGenerateColumns="False" CellPadding="4" CellSpacing="1" PageSize="5"
                        OnPageIndexChanging="gv2_PageIndexChanging" >
                        <Columns>
                            <asp:BoundField DataField="CaseID" HeaderText="案件編號" ReadOnly="True" />
                            <asp:BoundField DataField="MaterialName" HeaderText="耗材名稱" ReadOnly="True" />
                            <asp:BoundField DataField="UsedQuantity" HeaderText="使用數量" ReadOnly="True" />
                        </Columns>
                        <FooterStyle Font-Bold="True" ForeColor="black" />
                        <HeaderStyle Font-Bold="True" ForeColor="black" />
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </center>
    </form>
</body>
</html>
