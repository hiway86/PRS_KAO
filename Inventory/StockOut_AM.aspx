<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StockOut_AM.aspx.cs" Inherits="Inventory_StockOut_AM" %>
<!--#INCLUDE FILE="../checkpass.inc" -->
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
                        <legend>出庫單</legend>
                        <div>
                            <table style="width: 100%;">
                                <tr>

                                    <td>&nbsp;工單編號:
                                    </td>
                                    <td>&nbsp;
                                        <asp:DropDownList ID="ddl_WarrantyNotify" runat="server" AppendDataBoundItems="true">
                                            <asp:ListItem Value="-1">==請選擇==</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;計畫編號:
                                    </td>
                                    <td>&nbsp;
                                    <asp:DropDownList ID="ddl_ProjectName" runat="server" AppendDataBoundItems="true">
                                        <asp:ListItem Value="-1">==請選擇==</asp:ListItem>
                                    </asp:DropDownList>
                                        <td>&nbsp;地區:
                                        </td>
                                        <td>&nbsp;
                                   <asp:DropDownList ID="ddl_Region" runat="server" AppendDataBoundItems="true">
                                       <asp:ListItem Value="-1">==請選擇==</asp:ListItem>
                                   </asp:DropDownList>
                                        </td>
                                        <td></td>
                                        <td>&nbsp;
                                    
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;
                                        </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;出庫時間：
                                    </td>
                                    <td>&nbsp;
                                    <asp:TextBox ID="txt_StockOutTime" runat="server"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="txt_StockOutTime_MaskedEditExtender" runat="server" Enabled="True" TargetControlID="txt_StockOutTime" UserDateFormat="YearMonthDay" UserTimeFormat="TwentyFourHour" MaskType="DateTime" Mask="9999/99/99 99:99:99">
                                        </cc1:MaskedEditExtender>
                                        <cc1:MaskedEditValidator
                                            ID="MaskedEditValidator1"
                                            runat="server"
                                            ControlToValidate="txt_StockOutTime"
                                            ControlExtender="txt_StockOutTime_MaskedEditExtender"
                                            IsValidEmpty="false"
                                            EmptyValueMessage="不可為空"
                                            InvalidValueMessage="格式不正確" Display="Static"></cc1:MaskedEditValidator>
                                    </td>

                                </tr>

                            </table>
                        </div>
                        </legend>
                    </fieldset>
                </div>
                <br />
                <div class='container'>
                    <fieldset>
                        <legend>出庫物料</legend>
                        <div>
                            <table style="width: 100%;">
                                <tr>
                                    <td>&nbsp;物料名稱：<asp:DropDownList ID="ddl_MateriName" runat="server" AppendDataBoundItems="true">
                                        <asp:ListItem Value="-1">==請選擇==</asp:ListItem>
                                    </asp:DropDownList>
                                        &nbsp;</td>
                                    <td>&nbsp;
                                       
                                    </td>
                                    <td>&nbsp;領用數量:
                                    </td>
                                    <td>&nbsp;
                                    <asp:TextBox ID="txt_ConsumeQuantity" runat="server"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="txt_ConsumeQuantity_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txt_ConsumeQuantity">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                    <td></td>
                                    <td>&nbsp;
                                        <asp:Button ID="btn_StockOutSave" runat="server" Text="新增" CssClass="btn btn-small btn-primary" OnClick="btn_StockOutSave_Click" />
                                        <asp:Button ID="btn_StockoutCancel" runat="server" Text="清空" CssClass="btn btn-small btn-primary" OnClick="btn_StockoutCancel_Click" />
                                    </td>
                                </tr>

                            </table>
                        </div>
                        <asp:GridView ID="gv_stockOut_Item" runat="server" AllowPaging="False" CssClass="table table-hover table-condensed "
                            GridLines="None" DataKeyNames="rowindex" AutoGenerateColumns="False" CellPadding="4" CellSpacing="1"  OnRowCommand="gv_stockOut_Item_RowCommand" OnRowDataBound="gv_stockOut_Item_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="rowindex" HeaderText="項目" />
                                <asp:BoundField DataField="MaterialID" HeaderText="物料編號" />
                                <asp:BoundField DataField="MaterialName" HeaderText="物料名稱" />
                                <asp:BoundField DataField="Quantity" HeaderText="庫存數量" />
                                <asp:BoundField DataField="ConsumeQuantity" HeaderText="領用數量" />
                                <asp:BoundField DataField="MaterialCost" HeaderText="料價" />
                                <asp:BoundField DataField="StockOutCost" HeaderText="領用成本" />
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
                    <asp:Button ID="btn_cancel" runat="server" Text="回上一頁" CssClass="btn btn-small btn-primary" OnClick="btn_cancel_Click" OnClientClick="location.href='StockOut_QD.aspx'"></asp:Button>
                </div></center>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
