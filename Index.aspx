<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>維運管理系統</title>
    <link rel="Stylesheet" type="text/css" href="css/stylelib.css" />
    <link rel="Stylesheet" type="text/css" href="css/impromptu.css" />
    <link href="./css/impromptu.css" rel="Stylesheet" type="text/css" />
    <link href="./css/login.css" rel="stylesheet" type="text/css" />
    <link href="./css/bootstrap/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="./css/bootstrap/bootstrap.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="javascript/jquery-impromptu.2.8.min.js"></script>

    <script type="text/javascript" language="javascript">
        function checkquery() {
            var userid = document.getElementById('<%=txt_acc.ClientID%>').value;
            var pswd = document.getElementById('<%=txt_password.ClientID%>').value;
            if (userid == "" || pswd == "") {
                alert("使用者帳號及密碼不得為空白，請重新輸入");
                return false;
            }
            if (userid.match("'") != null) {
                alert("錯誤字元，請重新輸入");
                return false;
            }
        }



    </script>

<style type="text/css">

body {
	background-image: url(images/bg_01.jpg);
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
    background-repeat:repeat-x;
}
</style>
    
</head>
<body bgcolor="#CCCCCC">
    <form id="form1" runat="server" method="post">
        <%--<div id="header">
            <h1>
                維運管理系統</h1>
        </div>--%>
            <!-- ImageReady Slices (banner.psd) -->
            <center>
                <img src="images/banner_1280_kao.jpg" style="width: 1280px; height: 150px">
            </center>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <center>
                <div id="login-form">
                    <table>
                        <tr>
                            <th colspan="2">登入<hr />
                            </th>
                        </tr>
                        <tr>
                            <td>
                                <p>
                                    帳號：
                                </p>
                            </td>
                            <td align="right">
                                <asp:TextBox ID="txt_acc" runat="server" AutoCompleteType="Disabled" OnTextChanged="txt_acc_TextChanged"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>
                                    密碼：
                                </p>
                            </td>
                            <td align="right">
                                <asp:TextBox ID="txt_password" runat="server" TextMode="Password">ceciits</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td align="right">
                                <asp:Button ID="btn_login" runat="server" Text="登入 >>"
                                    OnClientClick="return checkquery();" OnClick="btn_login_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </center>
    </form>
</body>
</html>
