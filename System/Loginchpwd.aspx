<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Loginchpwd.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>維運管理系統-變更密碼</title>
    <link href="../css/impromptu.css" rel="Stylesheet" type="text/css" />
    <link href="../css/login.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap/bootstrap.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="javascript/jquery-1.3.2.js"></script>
    <script type="text/javascript" src="javascript/system.js"></script>
    <script type="text/javascript" src="javascript/jquery-impromptu.2.8.min.js"></script>
    <script type="text/javascript" language="javascript">
        function checkquery() {

            var newpw = document.getElementById('<%=txt_newpw.ClientID%>').value;
            var newpwcheck = document.getElementById('<%=txt_newpwcheck.ClientID%>').value;



            if (newpw == "") {
                alert("新密碼不得為空白，請重新輸入");
                return false;
            }

            if (newpwcheck == "") {
                alert("確認新密碼不得為空白，請重新輸入");
                return false;
            }

            if (newpw != newpwcheck) {
                alert("新密碼需與確認新密碼相同，請調整");
                return false;
            }

            if (newpw.match("'") != null || newpwcheck.match("'") != null) {
                alert("錯誤字元，請重新輸入");
                return false;
            }

            if (document.getElementById('<%=txt_newpw.ClientID%>').value.length < 6) {
                alert("密碼長度需大於6個字元");
                return false;
            }

        }
    </script>


    <style type="text/css">
        .auto-style3 {
            width: 131px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" method="post">
       
        <cc1:ToolkitScriptManager ID="ScriptManager1" runat="server" CombineScripts="false"></cc1:ToolkitScriptManager>
        </asp:ScriptManager>
        <div id="main">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div id="login-form">
                        <table>
                            <tr>
                                <th colspan="2">變更密碼<hr />
                                </th>
                            </tr>
                            <tr>
                                <td class="auto-style3">
                                    <p>
                                        新密碼:
                                    </p>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txt_newpw" runat="server" TextMode="Password"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style3">
                                    <p>
                                        確認新密碼:
                                    </p>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txt_newpwcheck" runat="server" TextMode="Password"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style3">登入帳號:<asp:Label ID="Label1" runat="server"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="確認變更" OnClientClick="return checkquery();" />
                                </td>
                                <td align="right">
                                    <asp:Button ID="Button2" runat="server" Text="取消" OnClick="Button2_Click" Visible="False" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"></asp:AsyncPostBackTrigger>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
