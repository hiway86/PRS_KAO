<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainMenu.aspx.cs" Inherits="MainMenu" %>

<!--#INCLUDE FILE="checkpass.inc" -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>維運管理資訊系統-維修通報管理系統</title>

    <script type="text/javascript" src="javascript/system.js"></script>

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <style>
		.panel{width:150px; height:150px; float:left;}
    </style>
</head>

<body style="background-image: url(images/wallpaper.jpg); background-repeat: repeat-x;
    background-color: #b9b9b9">
    <form id="form1" runat="server">
    <br />
    <br />
    <table width="755" border="0" align="center" cellpadding="0" cellspacing="0" background="images/background.gif"
        height="485">
        <tr>
            <td>
                <div runat="server" id="Div_MIS" align="center" class="panel">
                    <asp:Panel ID="Panel_MIS" runat="server">
                        <asp:ImageButton ID="ImageButton1" runat="server" OnClientClick="window.open('./Main.aspx?sg=MIS')"
                            Height="100px" ImageUrl="~/images/mis.png" Width="100px" EnableTheming="True" /></asp:Panel>
                </div>
                <div runat="server" id="Div_Report" align="center" class="panel">
                    <asp:Panel ID="Panel_Report" runat="server">
                        <asp:ImageButton ID="ImageButton2" runat="server" OnClientClick="window.open('./Main.aspx?sg=Report')"
                            Height="100px" ImageUrl="~/images/report.png" Width="100px" /></asp:Panel>
                </div>
                <div runat="server" id="Div_System" align="center" class="panel">
                    <asp:Panel ID="Panel_System" runat="server">
                        <asp:ImageButton ID="ImageButton4" runat="server" OnClientClick="window.open('./Main.aspx?sg=System')"
                            Height="100px" ImageUrl="~/images/user.png" Width="100px" /></asp:Panel>
                </div>
                <div runat="server" id="Div_Inventory" align="center" class="panel">
                    <asp:Panel ID="Panel_Inventory" runat="server">
                        <asp:ImageButton ID="ImageButton7" runat="server" OnClientClick="window.open('./Main.aspx?sg=Inventory')"
                            Height="100px" ImageUrl="~/images/parts.gif" Width="100px" EnableTheming="True" /></asp:Panel>
                </div> 
                <div runat="server" id="Div_Statistics" align="center" class="panel">
                    <asp:Panel ID="Panel_Statistics" runat="server">
                        <asp:ImageButton ID="ImageButton3" runat="server" OnClientClick="window.open('./Main.aspx?sg=Statistics')"
                            Height="100px" ImageUrl="~/images/statistics.png" Width="100px" /></asp:Panel>
                </div>
            </td>
            
        </tr>
        
    </table>
    </form>
</body>
</html>
