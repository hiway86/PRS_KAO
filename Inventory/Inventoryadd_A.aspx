<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inventoryadd_A.aspx.cs" Inherits="Inventory_Inventoryadd_A" %>

<!--#INCLUDE FILE="../checkpass.inc" -->
<!DOCTYPE html>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="Stylesheet" type="text/css" href="../css/web.css" />
    <link rel="Stylesheet" type="text/css" href="../css/impromptu.css" />
    <link href="../css/bootstrap/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap/bootstrap.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="../javascript/system.js"></script>

    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>

    <script language="javascript">
    <!--
    //只可輸入整數
    function TextBoxNumCheck_Int() {
        if (event.keyCode < 48 || window.event.keyCode > 57) event.returnValue = false;
    }
    // -->
    </script>

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>耗材基本資料新增</title>
</head>
<body>
    <form id="form1" runat="server" class="form-signin form-horizontal-50">
        <div>
            <cc1:ToolkitScriptManager ID="ScriptManager1" runat="server" CombineScripts="false"></cc1:ToolkitScriptManager>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MROSConnectionString %>"></asp:SqlDataSource>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="container">
                        <h3>耗材基本資料新增</h3>
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="2">
                           <%-- <ProgressTemplate>
                                <div class="progressBackgroundLayer">
                                </div>
                                <div class="fixedCenter">
                                    <img src="../images/ajax-loader2.gif">
                                </div>
                            </ProgressTemplate>--%>
                        </asp:UpdateProgress>
                        <asp:HiddenField ID="hidden_Action" runat="server" />
                         <asp:HiddenField ID="hidden_Materialid" runat="server" />
                        耗材名稱:<asp:TextBox ID="txt_MaterialName" runat="server" MaxLength="15"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="請輸入物料名稱" ControlToValidate="txt_MaterialName" Visible="True"></asp:RequiredFieldValidator>
                        <br />
                        <br />
                        耗材種類<asp:DropDownList ID="cbo_materialType" runat="server"></asp:DropDownList>
                        <br />
                        <br />
                        耗材單位:<asp:TextBox ID="txt_MaterialUnit" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="請輸入物料單位" ControlToValidate="txt_MaterialUnit" Visible="True"></asp:RequiredFieldValidator>
                        <br /> 
                        <br />
                        安全存量:<asp:TextBox ID="txt_MaterialSafeQuantity" runat="server" MaxLength="15" OnTextChanged="TextBox4_TextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="請輸入安全存量" ControlToValidate="txt_MaterialSafeQuantity" Visible="True"></asp:RequiredFieldValidator>
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txt_MaterialSafeQuantity" ErrorMessage="安全存量請輸入數字" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                       
                        <br />
                        <br />

                        <asp:Button runat="server" Text="新增" OnClick="Button1_Click" />
                        &nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="取消" OnClick="Button2_Click" CausesValidation="False" />

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>


            <br />
        </div>
    </form>
</body>
</html>
