<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testchart.aspx.cs" Inherits="testchart" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    

        <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1">
            <Series>
                <asp:Series Name="Series1" XValueMember="CompanyName" YValueMembers="CompanyGroup">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MROSConnectionString %>" SelectCommand="SELECT * FROM [Company]"></asp:SqlDataSource>
        <asp:Chart ID="Chart2" runat="server" DataSourceID="SqlDataSource1">
            <Series>
                <asp:Series ChartType="Doughnut" Name="Series1" XValueMember="CompanyName" YValueMembers="CompanyGroup">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    

    </div>
    </form>
</body>
</html>
