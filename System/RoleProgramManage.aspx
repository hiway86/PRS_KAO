<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleProgramManage.aspx.cs" Inherits="System_RoleProgramManage" %>
<!--#INCLUDE FILE="../checkpass.inc" -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="Stylesheet" type="text/css" href="../css/web.css" />
    <link rel="Stylesheet" type="text/css" href="../css/impromptu.css" />
    <link href="../css/bootstrap/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap/bootstrap.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>
    <script type="text/javascript" src="../javascript/authority.js"></script>
    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>
    <script type="text/javascript" src="../Authority.aspx?p=RoleProgramManage.aspx"></script>
    

    <title>使用者管理-功能權限列表</title>

    <script type="text/javascript">

        function addSearchIcon() {
            $('#cmd_Search').prepend("<i class=\"icon-search icon-white\"></i>");
        }

        function add() {
            location.href = "CompanyManage.aspx?act=add&id=0";
            return false;
        }
        //修改
        function edit(val) {
            location.href = "CompanyManage.aspx?act=edit&id=" + val;
            return false;
        }
        function del(val) {
            $.prompt('確定要刪除此筆資料?',
            { buttons: { 確定: true, 取消: false },
                submit: function(v, m, f) {
                    if (v) {
                        var Options = {
                            type: "POST",
                            url: "../MISWebService.asmx/DelCompany",
                            data: "{companyid: '" + val + "'}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            error: function(error) {
                                $.prompt('錯誤');
                            },
                            timeout: function(error) {
                                $.prompt('連線逾時');
                            },
                            success: function(response) {
                                if (response.d) {
                                    $.prompt('刪除成功');
                                    __doPostBack('lnkbtn_Search', '');
                                }
                            }
                        };
                        $.ajax(Options);
                    }
                }
            });
        }

      
    </script>

</head>
<body id="body" runat="server">
    <form id="form1"  defaultbutton="cmd_Search" runat="server">
    <center>
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <br />
            <div style="padding-right:40px">
                <asp:Panel ID="SearchPanel" runat="server">
                    <div style="float: left">
                        <asp:Label ID="Label4" runat="server" Text="請選擇查詢條件"></asp:Label>
                        <asp:DropDownList ID="dl_Role" runat="server" AppendDataBoundItems="True">
                                    <asp:ListItem Value="">--角色名稱--</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="dl_System_Group" runat="server" AppendDataBoundItems="True">
                                    <asp:ListItem Value="">--系統名稱--</asp:ListItem>
                                </asp:DropDownList>
                        <asp:Button ID="cmd_Search" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                            OnClick="cmd_Search_Click" Text="關鍵字搜尋" />
                    </div>
                </asp:Panel>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            <div style="padding-right:40px">
                <asp:GridView ID="gv" runat="server" AllowPaging="True" CssClass="table table-hover table-striped "
                    GridLines="None" AutoGenerateColumns="False" CellPadding="4" CellSpacing="1"
                      OnRowDataBound="gv_RowDataBound" 
                    PageSize="12" onpageindexchanging="gv_PageIndexChanging" OnRowCreated="gv_RowCreated">
                   <Columns>
                            <asp:BoundField HeaderText="程式編號" DataField="Program_ID" />
                            <asp:BoundField HeaderText="系統名稱" DataField="System_Group_Name" />
                            <asp:BoundField HeaderText="程式" DataField="Program_Name" />
                            <asp:BoundField HeaderText="程式名稱" DataField="Program_Cname" />
                            <asp:BoundField HeaderText="Enable_Browser" DataField="Enable_Browser"  />
                            <%--<asp:BoundField HeaderText="Enable_Query" DataField="Enable_Query" />
                            <asp:BoundField HeaderText="Enable_Add" DataField="Enable_Add" />
                            <asp:BoundField HeaderText="Enable_Edit" DataField="Enable_Edit" />
                            <asp:BoundField HeaderText="Enable_Delete" DataField="Enable_Delete" />
                            <asp:BoundField HeaderText="Enable_Print" DataField="Enable_Print" />
                            <asp:BoundField HeaderText="Enable_Edit_Save" DataField="Enable_Edit_Save" />
                            <asp:BoundField HeaderText="Enable_New_Save" DataField="Enable_New_Save" />--%>
                            <asp:TemplateField HeaderText="瀏覽">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cb_browser" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                           <%-- <asp:TemplateField HeaderText="查詢">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cb_query" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="新增">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cb_add" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="修改">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cb_edit" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="刪除">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cb_delete" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="列印">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cb_print" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="修改存檔">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cb_edit_save" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="新增存檔">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cb_new_save" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                    <FooterStyle  Font-Bold="True" ForeColor="black" />
                    <HeaderStyle  Font-Bold="True" ForeColor="black" />
                </asp:GridView>
                </div>
                 <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Center">
                    <asp:Button ID="cmd_Save" runat="server" Text="存檔" Width="70px" OnClick="cmd_Save_Click" CssClass="btn btn-primary"/>
                    <asp:Button ID="CancelBtn" runat="server" Text="取消" Width="70px" UseSubmitBehavior="False" CssClass="btn btn-primary"
                        CausesValidation="False" OnClick="CancelBtn_Click" />
                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <%--<asp:AsyncPostBackTrigger ControlID="lnkbtn_Add" EventName="Click" />--%>
                <asp:AsyncPostBackTrigger ControlID="cmd_Search" EventName="Click" />
            </Triggers>
            
        </asp:UpdatePanel>
    </center>
    </form>
</body>
</html>

