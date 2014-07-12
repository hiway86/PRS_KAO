<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StandardList_Q.aspx.cs" Inherits="VDCheck_StandardList_Q" %>

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
    <title>VD資料檢核-標準型態查詢</title>

    <script type="text/javascript">

        function pageLoad() {

        }

        function validateInput() {

        }

        function addSearchIcon() {
            $('#lnkbtn_calStandard').prepend("<i class=\"icon-align-left icon-white\"></i>");
        }


        function add() {
            location.href = "StockOut_AM.aspx?act=add&id=0";
            return false;
        }
        //修改
        function edit(val) {
            location.href = "StockOut_AM.aspx?act=edit&id=" + val;
            return false;
        }

    </script>

</head>
<body id="body" runat="server">
    <form id="form1" defaultbutton="lnkbtn_calStandard" runat="server">
        <center>
            <div>
                <cc1:ToolkitScriptManager ID="ScriptManager1" AsyncPostBackTimeout="3600" runat="server"></cc1:ToolkitScriptManager>
                <br />
                <div>
                    <asp:Panel ID="SearchPanel" runat="server">
                        <div style="margin: 0px 450px 20px 50px; float: left">
                            <asp:Label ID="Label1" runat="server" Text="設備編號選擇："></asp:Label>
                            <asp:DropDownList ID="ddlst_Device" runat="server" AppendDataBoundItems="True" CssClass="dropdown span2">
                                <asp:ListItem Value="0">請選擇</asp:ListItem>
                            </asp:DropDownList>
                             <asp:Label ID="Label2" runat="server" Text="偵測車道方向："></asp:Label>
                            <asp:DropDownList ID="ddlst_Vsrdir" runat="server" AppendDataBoundItems="True" CssClass="dropdown span2">
                                <asp:ListItem Value="0">同側</asp:ListItem>
                                <asp:ListItem Value="1">對側</asp:ListItem>
                            </asp:DropDownList>
                            <asp:LinkButton ID="lnkbtn_calStandard" runat="server" 
                                CausesValidation="False" CssClass="btn btn-primary" 
                                OnClientClick="return validateInput();"
                                OnClick="lnkbtn_calStandard_Click">標準型態查詢</asp:LinkButton>
                        </div>
                        <div style="float: right">
                            <%--                            <asp:LinkButton ID="cmd_ExportExcel" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                                OnClick="cmd_ExportExcel_Click">下載報表</asp:LinkButton>--%>
                            <%-- <asp:LinkButton ID="lnkbtn_Add" runat="server" CausesValidation="False" CssClass="btn btn-primary "
                                OnClick="lnkbtn_Add_Click">&nbsp;&nbsp;顯示圖表</asp:LinkButton>--%>
                        </div>
                    </asp:Panel>
                </div>
            </div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Chart ID="Chart_NormalSpeed" runat="server" Width="550px">
                        <Titles>
                            <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="" Name="Title1" ForeColor="26, 59, 105"></asp:Title>
                        </Titles>
                        <Legends>
                            <asp:Legend BackColor="Transparent" Alignment="Center" Docking="Bottom" Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Name="Default" LegendStyle="Row"></asp:Legend>
                        </Legends>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                                <AxisX IntervalAutoMode="VariableCount" IsLabelAutoFit="False">
                                    <LabelStyle IsStaggered="True" />
                                </AxisX>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                    <asp:Chart ID="Chart_WeekdaySpeed" runat="server" Width="550px">
                        <Titles>
                            <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="" Name="Title1" ForeColor="26, 59, 105"></asp:Title>
                        </Titles>
                        <Legends>
                            <asp:Legend BackColor="Transparent" Alignment="Center" Docking="Bottom" Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Name="Default" LegendStyle="Row"></asp:Legend>
                        </Legends>

                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                                <AxisX IntervalAutoMode="VariableCount" IsLabelAutoFit="False">
                                    <LabelStyle IsStaggered="True" />
                                </AxisX>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                    <asp:Chart ID="Chart_NormalFlow" runat="server" Width="550px">
                        <Titles>
                            <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="" Name="Title1" ForeColor="26, 59, 105"></asp:Title>
                        </Titles>
                        <Legends>
                            <asp:Legend BackColor="Transparent" Alignment="Center" Docking="Bottom" Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Name="Default" LegendStyle="Row"></asp:Legend>
                        </Legends>

                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                                <AxisX IntervalAutoMode="VariableCount" IsLabelAutoFit="False">
                                    <LabelStyle IsStaggered="True" />
                                </AxisX>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                    <asp:Chart ID="Chart_WeekDayflow" runat="server" Width="550px">
                        <Titles>
                            <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="" Name="Title1" ForeColor="26, 59, 105"></asp:Title>
                        </Titles>
                        <Legends>
                            <asp:Legend BackColor="Transparent" Alignment="Center" Docking="Bottom" Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Name="Default" LegendStyle="Row"></asp:Legend>
                        </Legends>

                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                                <AxisX IntervalAutoMode="VariableCount" IsLabelAutoFit="False">
                                    <LabelStyle IsStaggered="True" />
                                </AxisX>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                    <asp:Chart ID="Chart_NormalLaneOccupy" runat="server" Width="550px">
                        <Titles>
                            <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="" Name="Title1" ForeColor="26, 59, 105"></asp:Title>
                        </Titles>
                        <Legends>
                            <asp:Legend BackColor="Transparent" Alignment="Center" Docking="Bottom" Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Name="Default" LegendStyle="Row"></asp:Legend>
                        </Legends>

                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                                <AxisX IntervalAutoMode="VariableCount" IsLabelAutoFit="False">
                                    <LabelStyle IsStaggered="True" />
                                </AxisX>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                    <asp:Chart ID="Chart_WeekdayLaneOccupy" runat="server" Width="550px">
                        <Titles>
                            <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="" Name="Title1" ForeColor="26, 59, 105"></asp:Title>
                        </Titles>
                        <Legends>
                            <asp:Legend BackColor="Transparent" Alignment="Center" Docking="Bottom" Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Name="Default" LegendStyle="Row"></asp:Legend>
                        </Legends>

                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                                <AxisX IntervalAutoMode="VariableCount" IsLabelAutoFit="False">
                                    <LabelStyle IsStaggered="True" />
                                </AxisX>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="lnkbtn_calStandard" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </center>

    </form>

</body>
</html>
