<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inventory_Q_Test.aspx.cs" Inherits="Inventory_Inventory_Q_Test" %>

<!DOCTYPE html>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>物料基本資料</title>
    <link rel="Stylesheet" type="text/css" href="../css/web.css" />
    <link rel="Stylesheet" type="text/css" href="../css/impromptu.css" />
    <link href="../css/bootstrap/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap/bootstrap.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>
    <script type="text/javascript" src="../javascript/authority.js"></script>
    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
                物料管理系統
            </p>
            <p>
                物料名稱 :
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </p>
            <p>
                物料編號 :
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="搜尋"
            OnClick="Button1_Click" />
            </p>
        </div>
        <div>
            <cc1:ToolkitScriptManager ID="ScriptManager1" runat="server"  CombineScripts="false" ></cc1:ToolkitScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" GridLines="None" AutoGenerateColumns="False"
                        CellPadding="4" CellSpacing="1" DataKeyNames="MaterialID" CssClass="table table-hover table-striped " Width="100%" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit">
                        <Columns>
                            <asp:BoundField DataField="MaterialName" HeaderText="名稱" SortExpression="MaterialName">
                                <ControlStyle Width="50%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PurchaseUnit" HeaderText="採購計量單位" SortExpression="PurchaseUnit">
                                <ControlStyle Width="50%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ConsumeUnit" HeaderText="領用計量單位" SortExpression="ConsumeUnit">
                                <ControlStyle Width="50%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ConversionFactor" HeaderText="轉換係數" SortExpression="ConversionFactor">
                                <ControlStyle Width="50%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MaterialSafeQuantity" HeaderText="安全存量" SortExpression="MaterialSafeQuantity">
                                <ControlStyle Width="50%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MaterialTypeID" HeaderText="項次別序號" SortExpression="MaterialTypeID">
                                <ControlStyle Width="50%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MaterialUnit" HeaderText="物料單位" SortExpression="MaterialUnit">
                                <ControlStyle Width="50%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Active" HeaderText="有效(停用)" SortExpression="Active">
                                <ControlStyle Width="50%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MaterialID" HeaderText="ID" SortExpression="MaterialID">
                                <ControlStyle Width="50%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderImageUrl="~/images/edit.gif">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="更新"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Edit" Text="編輯"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderImageUrl="~/images/delete.gif">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Delete" Text="刪除" ImageUrl="~/images/x.jpg" OnClientClick="return confirm('再次確認是否刪除?')"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <strong><span style="font-size: 16pt; color: #ff0000">查無資料!!</span></strong>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
