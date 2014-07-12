<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReInventory_D.aspx.cs" Inherits="Inventory_ReInventory_D" %>
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

    <title>保固設備管理-歷史盤點紀錄</title>

    <script type="text/javascript">

        function url() {
            location.href = "InventoryCheck_QM.aspx";
            return false;
        }

    </script>

</head>
<body id="body" runat="server">
    <form id="form1" runat="server">
        <center>
            <div>
                <cc1:ToolkitScriptManager ID="ScriptManager1" runat="server"  CombineScripts="false" ></cc1:ToolkitScriptManager>
                <br />
                <div>
                    <asp:Panel ID="SearchPanel" runat="server">
                        <div style="float: left">
                            <asp:LinkButton ID="cmd_Search" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                                Height="22px" Width="100px" OnClick="lnkbtn_Search_Click">搜尋系統庫存</asp:LinkButton>
                            <asp:TextBox ID="txt_Query_Reason" runat="server" AutoCompleteType="Disabled" Width="200px"
                                placeholder="請輸入物料名稱"></asp:TextBox>
                       <asp:TextBox ID="txt_contractStartDate" runat="server" AutoCompleteType="Disabled"
                    CssClass="span3" placeholder="請輸入"></asp:TextBox>
                <asp:Image ID="imgCalander4" runat="server" ImageUrl="../images/calendar.png" />
                <cc1:calendarextender id="txt_Car_Licence_Exp_CalendarExtender1" runat="server" popupbuttonid="imgCalander4"
                    targetcontrolid="txt_contractStartDate" format="yyyy/MM/dd">
                        </cc1:calendarextender>
                          <asp:TextBox ID="txt_happen_Time" runat="server" Width="70px" ToolTip="請輸入起始時間" placeholder="起始時間" Visible="false"></asp:TextBox>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt_happen_Time"
                            MaskType="Time" Mask="99:99:99" AcceptAMPM="false" MessageValidatorTip="true"
                            ErrorTooltipEnabled="true" AutoComplete="true">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender1"
                            ControlToValidate="txt_happen_Time" IsValidEmpty="False" Display="Dynamic" EmptyValueBlurredText="請輸入時、分、秒!!!"
                            InvalidValueBlurredMessage="時間格式錯誤" InvalidValueMessage="時間格式錯誤" ErrorMessage="請輸入正確時間"
                            TooltipMessage="時、分、秒"></cc1:MaskedEditValidator>
                        </div>
                        <div style="float: right">                           
                            <asp:LinkButton ID="lnkbtn_Add" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                                OnClientClick="return url()" Height="22px" Width="60px">&nbsp;&nbsp;盤點</asp:LinkButton>
                        </div>
                    </asp:Panel>
                </div>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="2">
                        <ProgressTemplate>
                            <div class="progressBackgroundLayer">
                            </div>
                            <div class="fixedCenter">
                                <img src="../images/ajax-loader2.gif">
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <div>
                        <asp:GridView ID="gv" runat="server" AllowPaging="True" CssClass="table table-hover  "
                            GridLines="None" AutoGenerateColumns="False" CellPadding="4" CellSpacing="1"
                            OnPageIndexChanging="gv_PageIndexChanging" OnRowDataBound="gv_RowDataBound" PageSize="12" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="CustomersGridView_RowDeleting" DataKeyNames="RelnventoryID">
                            <Columns>
                                <asp:TemplateField HeaderImageUrl="~/images/edit.gif" Visible="false">
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="更新"></asp:LinkButton>
                                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消"></asp:LinkButton>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Edit" Text="編輯" ></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="RelnventoryID" HeaderText="編號" ReadOnly="True"></asp:BoundField>
                                <asp:BoundField DataField="MaterialID" HeaderText="物料編號" SortExpression="MaterialID">
                                    <ControlStyle Width="50%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MaterialName" HeaderText="物料名稱" SortExpression="MaterialName">
                                    <ControlStyle Width="50%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SystemQuantity" HeaderText="系統數量" SortExpression="SystemQuantity">
                                    <ControlStyle Width="50%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RealQuantity" HeaderText="實際數量" SortExpression="RealQuantity">
                                    <ControlStyle Width="50%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RelnventoryQuantity" HeaderText="盤盈虧數量" SortExpression="RelnventoryQuantity">
                                    <ControlStyle Width="50%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MaterialCost" HeaderText="料價" SortExpression="MaterialCost">
                                    <ControlStyle Width="50%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RelnventoryCost" HeaderText="盈虧價值" SortExpression="RelnventoryCost">
                                    <ControlStyle Width="50%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RelnventoryDate" HeaderText="盤點日期" SortExpression="RelnventoryDate">
                                    <ControlStyle Width="50%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderImageUrl="~/images/delete.gif">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Delete" Text="刪除" ImageUrl="~/images/x.jpg" OnClientClick="return confirm('再次確認是否刪除?')"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle Font-Bold="True" ForeColor="black" />
                            <HeaderStyle Font-Bold="True" ForeColor="black" />
                        </asp:GridView>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="lnkbtn_Add" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="cmd_Search" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </center>
    </form>
</body>
</html>
