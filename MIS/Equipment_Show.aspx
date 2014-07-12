<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Equipment_Show.aspx.cs" Inherits="MIS_Equipment_Show" %>

<!--#INCLUDE FILE="../checkpass.inc" -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="Stylesheet" type="text/css" href="../css/web.css" />
    <link rel="Stylesheet" type="text/css" href="../css/impromptu.css" />
    <link href="../css/bootstrap/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <%--<link href="../css/bootstrap/bootstrap.css" rel="stylesheet" type="text/css" />--%>
    <link href="../css/bootstrap-3.1.1-dist/css/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript" src="../javascript/system.js"></script>
    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>

    <title>設備管理-顯示設備詳細資訊</title>

    <script type="text/javascript">

    </script>

</head>
<body id="body" runat="server">
    <form id="form1" runat="server">
        <center>
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <br />
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
                        <asp:Label ID="lbl_equipmentTitle" Font-Size="Large" runat="server" Text="設備資訊" Font-Bold="True" Font-Overline="False" Font-Underline="False"></asp:Label>
                        <asp:GridView ID="gv2" runat="server" AllowPaging="True" CssClass="table table-hover table-condensed"
                            GridLines="None" AutoGenerateColumns="False" CellPadding="4" CellSpacing="1">
                            <Columns>
                                <asp:BoundField DataField="Device_ID" HeaderText="設備編號" ReadOnly="True" />
                                <asp:BoundField DataField="Device_Kind" HeaderText="設備種類" ReadOnly="True" />
                                <asp:BoundField DataField="AreaName" HeaderText="地區" ReadOnly="True" />
                                <asp:BoundField DataField="Location" HeaderText="路口名稱" HeaderStyle-Width="160px" ReadOnly="True" />
                                <asp:BoundField DataField="ContractName" HeaderText="設備合約" HeaderStyle-Width="160px" ReadOnly="True" />
                                <%--                        <asp:BoundField DataField="Status" HeaderText="設備狀態" ReadOnly="True" />--%>
                                <asp:BoundField DataField="ContractStartDate" HeaderText="保固起始日" ReadOnly="True" DataFormatString="{0:yyyy/MM/dd}" />
                                <asp:BoundField DataField="ContractEndDate" HeaderText="保固中止日" ReadOnly="True" DataFormatString="{0:yyyy/MM/dd}" />
                                <asp:BoundField DataField="Gis_X" HeaderText="經度" ReadOnly="True" />
                                <asp:BoundField DataField="Gis_Y" HeaderText="緯度" ReadOnly="True" />
                                <%--<asp:BoundField DataField="Equipment_ID" HeaderText="設備ID" ReadOnly="True" />
                                <asp:BoundField DataField="Comm_Server_IP" HeaderText="Comm_Server_IP" ReadOnly="True" />
                                <asp:BoundField DataField="Attribute" HeaderText="屬性" ReadOnly="True" />
                                <asp:BoundField DataField="Status" HeaderText="狀態" ReadOnly="True" />
                                <asp:BoundField DataField="Receive_Port" HeaderText="接收Port" ReadOnly="True" />
                                <asp:BoundField DataField="Remote_IP" HeaderText="遠端IP" ReadOnly="True" />
                                <asp:BoundField DataField="Remote_Port" HeaderText="遠端Port" ReadOnly="True" />
                                <asp:BoundField DataField="Phone_Number" HeaderText="電話號碼" ReadOnly="True" />--%>
                            </Columns>
                            <FooterStyle Font-Bold="True" ForeColor="black" />
                            <HeaderStyle Font-Bold="True" ForeColor="black" BackColor="#3399ff" />
                        </asp:GridView>
                    <hr />
                    <asp:Label ID="lbl_materialTitle" Font-Size="Large" runat="server" Visible="false" Text="設備所屬零件" Font-Bold="True" Font-Overline="False" Font-Underline="False"></asp:Label>
                    <asp:GridView ID="gv_MaterialShow" runat="server" AllowPaging="False" CssClass="table table-hover table-condensed "
                        GridLines="None" AutoGenerateColumns="False" CellPadding="4" CellSpacing="1">
                        <Columns>
                            <asp:BoundField DataField="Device_ID" HeaderText="設備名稱" />
                            <asp:BoundField DataField="Material_NO" HeaderText="零件編號" />
                            <asp:BoundField DataField="MaterialName" HeaderText="零件名稱" />
                        </Columns>
                        <FooterStyle Font-Bold="True" ForeColor="black" />
                        <HeaderStyle Font-Bold="True" ForeColor="black" BackColor="#3399ff" />
                    </asp:GridView>
                    <br />
                    <asp:Label ID="lbl_caseTitle" Font-Size="Large" runat="server" Visible="false" Text="通報案件資訊" Font-Bold="True" Font-Overline="False" Font-Underline="False"></asp:Label>
                    <asp:GridView ID="gv" runat="server" AllowPaging="True" CssClass="table table-hover table-condensed"
                        GridLines="None" AutoGenerateColumns="False" CellPadding="4" CellSpacing="1"
                        OnPageIndexChanging="gv_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="CaseID" HeaderText="案件編號" ReadOnly="True" />
                            <asp:BoundField DataField="DeviceID" HeaderText="設備編號" ReadOnly="True" />
                            <asp:BoundField DataField="Device_Kind" HeaderText="設備種類" ReadOnly="True" />
                            <asp:BoundField DataField="FaultDescribe" HeaderText="故障描述" ReadOnly="True" />
                            <asp:BoundField DataField="AreaName" HeaderText="地區" ReadOnly="True" />
                            <asp:BoundField DataField="Location" HeaderText="路口名稱" ReadOnly="True" />
                            <asp:BoundField DataField="WarrantyCompany" HeaderText="保固廠商" ReadOnly="True" />
                            <asp:BoundField DataField="NotifyDate" HeaderText="通知日期" ReadOnly="True" />
                            <asp:BoundField DataField="RepairDeadline" HeaderText="修復期限" ReadOnly="True" />
                        </Columns>
                        <FooterStyle Font-Bold="True" ForeColor="black" />
                        <HeaderStyle Font-Bold="True" ForeColor="black" BackColor="#3399ff" />
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
      </center>
    </form>
</body>
</html>
