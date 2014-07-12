<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XPMenu.aspx.cs" Inherits="XPMenu" %>

<%@ Register Src="XPMenuUC.ascx" TagName="XPMenuUC" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/web.css" rel="stylesheet" />
    <title>未命名頁面</title>

</head>
<body>
    <form id="form1" runat="server" target="_top">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <br />
            <table>
                <tr>
                    <td id="submenu">
                        <center>
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        </center>
                        <uc1:XPMenuUC ID="XPMenuUC" runat="server" SystemGroup="" />
                        <center>
                            <asp:LinkButton ID="LinkButton_logout" runat="server" OnClick="LinkButton_logout_Click">登出</asp:LinkButton>
                        </center>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
