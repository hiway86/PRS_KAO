<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StockIn_ADM.aspx.cs" Inherits="Inventory_StockIn_ADM" %>
<!--#INCLUDE FILE="../checkpass.inc" -->
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="Stylesheet" type="text/css" href="../css/web.css" />
    <link rel="Stylesheet" type="text/css" href="../css/stylelib.css" />
    <link rel="Stylesheet" type="text/css" href="../css/impromptu.css" />
    <link href="../css/bootstrap/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap/bootstrap.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>


</head>
<body>
    <form id="form1" runat="server">
        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:HiddenField ID="hidden_Action" runat="server" />
                <asp:HiddenField ID="hidden_StockInID" runat="server" />
                <div class='container'>
                    <br />
                    <fieldset>
                        <legend>入庫單管理</legend>
                        <div>
                            <table style="width: 100%;">
                                <tr>

                                    <td>&nbsp;物料名稱:
                                    </td>
                                    <td>&nbsp;
                                        <asp:DropDownList ID="ddl_ICSMaterial" runat="server" AppendDataBoundItems="true">
                                            <asp:ListItem Value="-1">==請選擇==</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;入庫單價:
                                    </td>
                                    <td>&nbsp;
                                    <asp:TextBox ID="txt_MateralSingleValue" runat="server"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="txt_MateralSingleValue_FilteredTextBoxExtender" runat="server" Enabled="True" TargetControlID="txt_MateralSingleValue" FilterType="Numbers">
                                        </cc1:FilteredTextBoxExtender>
                                        <td>&nbsp;入庫數量：
                                        </td>
                                        <td>&nbsp;
                                    <asp:TextBox ID="txt_SotckInQuantity" runat="server"></asp:TextBox>

                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txt_SotckInQuantity">
                                            </cc1:FilteredTextBoxExtender>

                                        </td>
                                </tr>
                                <tr>

                                    <td>&nbsp;存放位置：
                                    </td>
                                    <td>&nbsp;
                                    <asp:TextBox ID="txt_StockLocation" runat="server"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;廠商名稱:
                                    </td>
                                    <td>&nbsp;
                                    <asp:DropDownList ID="ddl_CompanyID" runat="server" AppendDataBoundItems="true">
                                        <asp:ListItem Value="-1">==請選擇==</asp:ListItem>
                                    </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;廠牌名稱：
                                    </td>
                                    <td>&nbsp;
                                    <asp:TextBox ID="txt_materialBrand" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td>
                                        <asp:Button ID="btn_stockSave" runat="server" Text="新增" CssClass="btn btn-small btn-primary" OnClick="btn_stockSave_Click" />
                                        <asp:Button ID="btn_stockCancel" runat="server" Text="清空" CssClass="btn btn-small btn-primary" OnClick="btn_stockCancel_Click" />
                                    </td>
                                </tr>

                            </table>
                        </div>
                        <asp:GridView ID="gv_stockitem" runat="server" AllowPaging="True" CssClass="table table-hover table-condensed"
                            GridLines="None" AutoGenerateColumns="False" DataKeyNames="rowindex" CellPadding="4" CellSpacing="1" PageSize="5" OnPageIndexChanging="gv_stockitem_PageIndexChanging" OnRowCommand="gv_stockitem_RowCommand" OnRowDataBound="gv_stockitem_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="MaterialName" HeaderText="物料名稱" />
                                <asp:BoundField DataField="StockIn_Quantity" HeaderText="入庫數量" />
                                <asp:BoundField DataField="Quantity" HeaderText="庫存數量" />
                                <asp:BoundField DataField="Material_Single_Value" HeaderText="單價" />
                                <asp:BoundField DataField="StockIn_Cost" HeaderText="小記" />
                                <asp:BoundField DataField="Stock_Location" HeaderText="存放位置" />
                                <asp:BoundField DataField="CompanyID" HeaderText="廠商編號" />
                                <asp:BoundField DataField="ComapnyName" HeaderText="廠商名稱" />
                                <asp:BoundField DataField="MaterialBrand" HeaderText="廠牌名稱" />
                                <asp:TemplateField HeaderImageUrl="~/images/delete.gif">
                                    <ItemTemplate>
                                        <asp:Button ID="cmd_Delete" runat="server" CommandName="cmDelete" CssClass="btn btn-small btn-primary" Text="刪除" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                            <FooterStyle Font-Bold="True" ForeColor="black" />
                            <HeaderStyle Font-Bold="True" ForeColor="black" BackColor="#3399ff" />
                        </asp:GridView>
                        </legend>
                    </fieldset>
                </div>
                <br />
                <div class='container'>
                    <fieldset>
                        <legend>計畫成本</legend>
                        <div>
                            <table style="width: 100%;">
                                <tr>
                                    <td>&nbsp;計畫編號：
                                    </td>
                                    <td>&nbsp;
                                        <asp:DropDownList ID="ddl_ProjectName" runat="server" AppendDataBoundItems="true">
                                            <asp:ListItem Value="-1">==請選擇==</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;分攤成本:
                                    </td>
                                    <td>&nbsp;
                                    <asp:TextBox ID="txt_ContractCost" runat="server"></asp:TextBox>
                                    </td>
                                    <td></td>
                                    <td>&nbsp;
                                        <asp:Button ID="btn_projectSave" runat="server" Text="新增" CssClass="btn btn-small btn-primary" OnClick="btn_projectSave_Click" />
                                        <asp:Button ID="btn_projectcancel" runat="server" Text="清空" CssClass="btn btn-small btn-primary" OnClick="btn_projectcancel_Click" />
                                    </td>
                                </tr>

                            </table>
                        </div>
                        <asp:GridView ID="gv_stock_project" runat="server" AllowPaging="True" CssClass="table table-hover table-condensed "
                            GridLines="None" DataKeyNames="rowindex" AutoGenerateColumns="False" CellPadding="4" CellSpacing="1" OnPageIndexChanging="gv_stock_project_PageIndexChanging" OnRowCommand="gv_stock_project_RowCommand" OnRowDataBound="gv_stock_project_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="rowindex" HeaderText="項目" />
                                <asp:BoundField DataField="ProjectName" HeaderText="計畫名稱" />
                                <asp:BoundField DataField="ContractCost" HeaderText="分攤成本" />
                                <asp:TemplateField HeaderImageUrl="~/images/delete.gif">
                                    <ItemTemplate>
                                        <asp:Button ID="cmd_Delete" runat="server" CommandName="cmDelete" CssClass="btn btn-small btn-primary" Text="刪除" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle Font-Bold="True" ForeColor="black" />
                            <HeaderStyle Font-Bold="True" ForeColor="black" BackColor="#3399ff" />
                        </asp:GridView>
                        </legend>
                    </fieldset>
                </div>
                <center><div>
                    <asp:Button ID="btn_saveAll" runat="server" Text="新增存檔" CssClass="btn btn-small btn-primary" OnClick="btn_saveAll_Click"></asp:Button>
                    <asp:Button ID="btn_cancel" runat="server" Text="回上一頁" CssClass="btn btn-small btn-primary" OnClick="btn_cancel_Click"></asp:Button>
                </div></center>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
