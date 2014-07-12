<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Systemmaster.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<head runat="server">
    <title>維運管理系統</title>
    <link href="./css/impromptu.css" rel="Stylesheet" type="text/css" />
    <link href="./css/login.css" rel="stylesheet" type="text/css" />
    <link href="./css/bootstrap/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="./css/bootstrap/bootstrap.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="javascript/jquery-1.3.2.js"></script>
    <script type="text/javascript" src="javascript/jquery-impromptu.2.8.min.js"></script>
     <script type="text/javascript">
         window.onload = function () {
             document.documentElement.style.overflowY = 'hidden';
             document.body.style.overflowY = 'hidden';
         }
    </script>
</head>
<body>
    <div id="header">
        <h1>
            <img src="./images/ceci_logo2.png" alt="CECI" style="width: auto; height: 20%;" />維運管理系統</h1>
    </div>
    <form id="form1" runat="server" style="height: 80%">
        <table style="width: 100%; height: 100%">
             <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>&nbsp; 歡迎登入</td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="登出" OnClick="Button1_Click" />
                </td>
            </tr>

            <tr>
                <td style="width: 15%" valign="top">
                    <asp:TreeView ID="TreeView1" runat="server">
                        <Nodes>
                            <asp:TreeNode Text="維運管理系統" Value="系統管理" ShowCheckBox="False" Target="Right">
                                <asp:TreeNode NavigateUrl="~/System/AuthList.aspx" Text="使用者權限管理" Value="新節點" ShowCheckBox="False" Target="Right">
                                    <asp:TreeNode NavigateUrl="~/System/Loginchpwd.aspx" Target="Right" Text="使用者變更密碼" Value="使用者變更密碼"></asp:TreeNode>
                                </asp:TreeNode>
                                <asp:TreeNode NavigateUrl="~/System/RoleProgramManage.aspx" Text="功能權限列表" Value="新節點" Target="Right"></asp:TreeNode>
                                <asp:TreeNode NavigateUrl="~/System/RoleList.aspx" Text="系統角色管理" Value="系統角色管理" Target="Right"></asp:TreeNode>
                            </asp:TreeNode>
                        </Nodes>
                    </asp:TreeView>
                </td>
                <td colspan="2">
                    <iframe id="Right" name="Right" class="outset-table" width="100%" height="500" frameborder="NO" border="1" framespacing="0" noresize align="middle"></iframe>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
