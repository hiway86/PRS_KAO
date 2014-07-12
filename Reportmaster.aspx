<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reportmaster.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>案件通報管理系統</title>
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
            <img src="./images/ceci_logo2.png" alt="CECI" style="width: auto; height: 20%;" />案件通報管理系統</h1>
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
                            <asp:TreeNode Text="案件通報管理" Value="系統管理" ShowCheckBox="False" Target="Right">
                                <asp:TreeNode NavigateUrl="~/Report/WarrantyNotifyAdd.aspx" Text="維修通報作業" Value="新節點" ShowCheckBox="False" Target="Right"></asp:TreeNode>
                                <asp:TreeNode NavigateUrl="~/Report/NotificationConfirmWork.aspx" Text="通知確認作業" Value="新節點" Target="Right"></asp:TreeNode>
                                <asp:TreeNode NavigateUrl="~/Report/RepairMaintainList.aspx" Text="維修中案件監控" Value="系統角色管理" Target="Right"></asp:TreeNode>
                                <asp:TreeNode NavigateUrl="~/Report/ReportReturnList.aspx" Target="Right" Text="維修中案件回報" Value="維修中案件回報"></asp:TreeNode>
                                <asp:TreeNode NavigateUrl="~/Report/ReportReviewList.aspx" Target="Right" Text="歷史通報案件" Value="歷史通報案件"></asp:TreeNode>
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
