<%@ Page  Language="C#" AutoEventWireup="true" CodeFile="DeviceRepairTime_Q.aspx.cs" Inherits="Statistics_DeviceRepairTime_Q" %>
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
    <title>物料管理-故障因素統計</title>

    <script type="text/javascript">

        function pageLoad() {
          
        }

        function addSearchIcon() {
            $('#cmd_Search').prepend("<i class=\"icon-search icon-white\"></i>");
            $('#lnkbtn_Add').prepend("<i class=\"icon-align-left icon-white\"></i>");
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

    </script>

</head>
<body id="body" runat="server">
    <form id="form1" defaultbutton="cmd_Search" runat="server">
        <center>
            <div>
                <cc1:ToolkitScriptManager ID="ScriptManager1" runat="server"></cc1:ToolkitScriptManager>
                <br />
                <div>
                    <asp:Panel ID="SearchPanel" runat="server">
                        <div style="float: left">
                            <asp:LinkButton ID="cmd_Search" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                                Height="22px" Width="100px" OnClick="lnkbtn_Search_Click">關鍵字搜尋</asp:LinkButton>
                            <asp:DropDownList ID="ddlst_SearchType" runat="server" CssClass="dropdown span2">
                                <asp:ListItem Value="DeviceID">設備編號
                                </asp:ListItem>
                                <%--<asp:ListItem Value="counts">損壞次數</asp:ListItem>--%>
                            </asp:DropDownList>
                            <asp:TextBox ID="txt_Query_Reason" runat="server" AutoCompleteType="Disabled" Width="200px"
                                placeholder="請輸入"></asp:TextBox>
                            通報時間：
                            <asp:TextBox ID="txt_startDateTime" Enabled="false" runat="server"  placeholder="通報時間查詢" CssClass="span2"></asp:TextBox><img src="../images/calendar.png" />
                            <asp:TextBox ID="txt_endDateTime" Enabled="false" runat="server" placeholder="通報時間查詢" CssClass="span2"></asp:TextBox><img src="../images/calendar.png" />
                        </div>
                        <div style="float: right">
                            <asp:LinkButton ID="cmd_ExportExcel" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                                OnClick="cmd_ExportExcel_Click">下載報表</asp:LinkButton>
                            <asp:LinkButton ID="lnkbtn_Add" runat="server" CausesValidation="False" CssClass="btn btn-primary "
                                OnClick="lnkbtn_Add_Click">&nbsp;&nbsp;顯示圖表</asp:LinkButton>
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
                    <asp:HiddenField ID="hid_stockOutid" runat="server" />
                    <div>
                        <asp:GridView ID="gv" runat="server" AllowPaging="True" CssClass="table table-hover  "
                            GridLines="None" AutoGenerateColumns="False" CellPadding="4" CellSpacing="1"
                            OnPageIndexChanging="gv_PageIndexChanging" PageSize="5">
                            <Columns>
                                <asp:BoundField DataField="DeviceID" HeaderText="設備編號" />
                                <asp:BoundField DataField="RepairAvgDay" HeaderText="平均修復天數" />
                            </Columns>
                            <FooterStyle Font-Bold="True" ForeColor="black" />
                            <HeaderStyle Font-Bold="True" ForeColor="black" />
                        </asp:GridView>
                    </div>
                    </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="cmd_Search" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                        <asp:Chart ID="Chart1" runat="server" Width="900px">
                        <Series>
                            <asp:Series Name="Series1" YValuesPerPoint="2"></asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                                <AxisX IntervalAutoMode="VariableCount" IsLabelAutoFit="False" Title="設備編號">
                                    <LabelStyle IsStaggered="True" />
                                </AxisX>
                                <AxisY Title="平均修復天數"></AxisY>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="cmd_Search" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="lnkbtn_Add" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </center>

    </form>

</body>
</html>