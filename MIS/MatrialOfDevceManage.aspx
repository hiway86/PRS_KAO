<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MatrialOfDevceManage.aspx.cs" Inherits="MIS_MatrialOfDevceManage" %>
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
                <asp:HiddenField ID="hidden_DeviceID" runat="server" />
                <br />
                <div class='container'>
                    <fieldset>
                        <legend>管理設備零件</legend>
                        <div>
                            <table style="width: 100%;">
                                <tr>
                                    <td>&nbsp;零件名稱：
                                         <asp:DropDownList ID="cbo_MaterialID" runat="server" AppendDataBoundItems="True">
                                             <asp:ListItem Value="-1">--請選擇--</asp:ListItem>
                                         </asp:DropDownList>
                                        &nbsp;</td>
                                    <td>&nbsp;
                                       
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                   
                                    </td>
                                    <td></td>
                                    <td>&nbsp;
                                        <asp:Button ID="btn_MateralAdd" runat="server" Text="新增" CssClass="btn btn-small btn-primary" OnClick="btn_MateralAdd_Click"  />
                                        <asp:Button ID="btn_MateralClear" runat="server" Text="清空" CssClass="btn btn-small btn-primary" OnClick="btn_MateralClear_Click"  />
                                    </td>
                                </tr>

                            </table>
                        </div>
                        <asp:GridView ID="gv_Material" runat="server" AllowPaging="False" CssClass="table table-hover table-condensed "
                            GridLines="None" AutoGenerateColumns="False" CellPadding="4" CellSpacing="1" OnRowCommand="gv_Material_RowCommand1" OnRowDataBound="gv_Material_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="NO" HeaderText="項目" />
                                <asp:BoundField DataField="Device_ID" HeaderText="設備名稱" />
                                <asp:BoundField DataField="Material_NO" HeaderText="零件編號" />
                                <asp:BoundField DataField="MaterialName" HeaderText="零件名稱" />
                               <%-- <asp:BoundField DataField="CheckDate" HeaderText="檢核日期" />--%>
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
                    <asp:Button ID="btn_saveAll" runat="server" Text="新增存檔"  CssClass="btn btn-small btn-primary" Visible="false" OnClick="btn_saveAll_Click"></asp:Button>
                    <asp:Button ID="btn_cancel" runat="server" Text="回上一頁" CssClass="btn btn-small btn-primary" OnClick="btn_cancel_Click" OnClientClick="location.href='EquipmentDataList.aspx'"></asp:Button>
                </div></center>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

