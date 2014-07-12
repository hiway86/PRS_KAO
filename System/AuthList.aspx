<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuthList.aspx.cs" Inherits="System_AuthList" %>
<!--#INCLUDE FILE="../checkpass.inc" -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>使用者權限</title>
    <link rel="Stylesheet" type="text/css" href="../css/web.css" />
    <link rel="Stylesheet" type="text/css" href="../css/impromptu.css" />
    <link href="../css/bootstrap/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap/bootstrap.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="../javascript/authority.js"></script>

    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>

   

    <script type="text/javascript">

       

        function add() {
            location.href = "AuthManage.aspx?act=add";
            return false;
        }

        //修改
        function edit(val) {
            location.href = "AuthManage.aspx?act=edit&id=" + val;
            return false;
        }

    </script>

</head>
<body id="body" runat="server">
    <form id="form1"  defaultbutton="cmd_Search" runat="server">
    <center>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <br />
                <div style="padding-right: 40px">
                    <asp:Panel ID="SearchPanel" runat="server">
                        <div style="float: left">
                            <asp:Label ID="Label4" runat="server" Text="請選擇查詢條件"></asp:Label>
                            <asp:DropDownList ID="ddlst_SearchType" runat="server" CssClass="dropdown ">
                            </asp:DropDownList>
                            <asp:TextBox ID="txt_Query_Reason" runat="server" AutoCompleteType="Disabled" Width="200px"
                                placeholder="請輸入"></asp:TextBox>
                            <asp:Button ID="cmd_Search" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                                OnClick="lnkbtn_Search_Click" Text="關鍵字搜尋" />
                        </div>
                        <div style="float: right">
                            <asp:LinkButton ID="lnkbtn_Add" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                                OnClientClick="return add()" Height="22px" Width="60px">&nbsp;&nbsp;新增</asp:LinkButton>
                        </div>
                    </asp:Panel>
                </div>
                <div style="padding-right: 40px">
                    <asp:GridView ID="gv" runat="server" AllowPaging="True" CssClass="table"
                        GridLines="None" AutoGenerateColumns="False" CellPadding="4" CellSpacing="1"
                        OnRowDataBound="gv_RowDataBound" PageSize="12" OnPageIndexChanging="gv_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderImageUrl="~/images/edit.gif">
                                <ItemTemplate>
                                    <asp:Button ID="cmd_Edit" runat="server" Text="修改" class="btn btn-mini  btn-info" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="User_Name" HeaderText="姓名" />
                            <asp:BoundField DataField="User_ID" HeaderText="帳號" />
                            <asp:BoundField DataField="Role_ID" HeaderText="權限" />
                            <asp:BoundField DataField="Phone" HeaderText="電話" />
                            <asp:BoundField DataField="Email" HeaderText="信箱" />
                            <asp:BoundField DataField="Role_Name" HeaderText="權限說明" />
                            <asp:BoundField DataField="Status" HeaderText="狀態" />
                        </Columns>
                        <FooterStyle Font-Bold="True" ForeColor="black" />
                        <HeaderStyle Font-Bold="True" ForeColor="black" BackColor="#507CD1"/>
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
    </form>
</body>
</html>
</html> 