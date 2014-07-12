<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RepairMaintainList.aspx.cs"
    Inherits="Report_RepairMaintainList" %>
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

    <title>案件通報管理-維修中案件列表</title>

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
                if (SearchType == 'NotifyDate' || SearchType == 'RepairDeadline') {
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

        function addMapIcon() {
            $('#mapView').prepend("<i class=\"icon-map-marker icon-white\"></i>");
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

        //維修回報
        function ReturnList(val) {
            location.href = "ReportReturnManage.aspx?act=edit&id=" + val;
            return false;
        }
        function del(val) {
            $.prompt('確定要刪除此筆資料?',
            { buttons: { 確定: true, 取消: false },
                submit: function(v, m, f) {
                    if (v) {
                        var Options = {
                            type: "POST",
                            url: "../MISWebService.asmx/DelWarrantyNotify",
                            data: "{caseid: '" + val + "'}",
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
            <cc1:ToolkitScriptManager ID="ScriptManager1" runat="server" CombineScripts="false"></cc1:ToolkitScriptManager>
            <br />
            <div>
                <asp:Panel ID="SearchPanel" runat="server">
                    <div style="float: left">
                        <asp:LinkButton ID="mapView" runat="server" CssClass="btn btn-primary" Height="22px"
                            Width="100px" OnClick="mapView_Click">地圖檢視</asp:LinkButton>
                        <asp:LinkButton ID="cmd_Search" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                            Height="22px" Width="100px" OnClick="lnkbtn_Search_Click">關鍵字搜尋</asp:LinkButton>
                        <asp:DropDownList ID="ddlst_SearchType" runat="server" CssClass="dropdown">
                        </asp:DropDownList>
                        <asp:TextBox ID="txt_Query_Reason" runat="server" AutoCompleteType="Disabled" Width="200px"
                            placeholder="請輸入"></asp:TextBox>
                    </div>
                    <div id ="SearchDate" style="float:left;display: none;">
                            <asp:TextBox ID="txt_StartDate" runat="server"  placeholder="通報時間查詢" CssClass="span3"></asp:TextBox><img src="../images/calendar.png" />
                            <asp:TextBox ID="txt_EndDate" runat="server" placeholder="通報時間查詢" CssClass="span3"></asp:TextBox><img src="../images/calendar.png" />

                    </div>
                    <div style="float: right">
                        <asp:LinkButton ID="lnkbtn_Report" runat="server" Visible="false" CausesValidation="False" CssClass="btn btn-primary"
                            Height="22px" OnClick="lnkbtn_Report_Click" Width="60px">&nbsp;&nbsp;匯出</asp:LinkButton>
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
                            <img src="../images/ajax-loader2.gif"></div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:GridView ID="gv" runat="server" AllowPaging="True" CssClass="table table-hover "
                    GridLines="None" AutoGenerateColumns="False" CellPadding="4" CellSpacing="1"
                    OnPageIndexChanging="gv_PageIndexChanging" OnRowDataBound="gv_RowDataBound"
                    PageSize="11" OnRowCommand="gv_RowCommand">
                    <Columns>
                        <asp:ButtonField ButtonType="Button" CommandName="singleMapView"  Text="地圖">
                            <ControlStyle CssClass="btn btn-mini btn-success" />
                        </asp:ButtonField>
                         <asp:ButtonField ButtonType="Button" CommandName="WEdit"  HeaderImageUrl="~/images/edit.gif" Text="修改">
                            <ControlStyle CssClass="btn btn-mini btn-info" />
                        </asp:ButtonField>
                         <asp:ButtonField ButtonType="Button" CommandName="WReturn"  HeaderImageUrl="~/images/edit.gif" Text="回報">
                            <ControlStyle CssClass="btn btn-mini btn-info" />
                        </asp:ButtonField>
                        <asp:BoundField DataField="CaseID" HeaderText="案件編號" ReadOnly="True" />
                        <asp:BoundField DataField="DeviceID" HeaderText="設備編號" ReadOnly="True" />
                        <asp:BoundField DataField="Device_Kind" HeaderText="設備種類" ReadOnly="True" />
                        <asp:BoundField DataField="FaultDescribe" HeaderText="故障描述" ReadOnly="True" />
                        <asp:BoundField DataField="AreaName" HeaderText="地區" ReadOnly="True" />
                        <asp:BoundField DataField="Location" HeaderText="路口名稱" ReadOnly="True" />
                        <asp:BoundField DataField="WarrantyCompany" HeaderText="保固廠商" ReadOnly="True" />
                        <asp:BoundField DataField="NotifyDate" HeaderText="通知日期" ReadOnly="True" DataFormatString="{0:yyy/MM/dd HH:mm:ss}" />
                        <asp:BoundField DataField="RepairDeadline" HeaderText="修復期限" ReadOnly="True" DataFormatString="{0:yyy/MM/dd HH:mm:ss}" />
                       <asp:ButtonField HeaderText="刪除" ButtonType="Button" CommandName="cmd_delete" ControlStyle-CssClass="btn btn-mini  btn-info" Text="刪除">
                        </asp:ButtonField>
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
    </center>
    </form>
</body>
</html>
