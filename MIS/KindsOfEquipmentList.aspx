<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KindsOfEquipmentList.aspx.cs" Inherits="MIS_KindsOfEquipmentList" %>
<!--#INCLUDE FILE="../checkpass.inc" -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="Stylesheet" type="text/css" href="../css/web.css" />
    <link rel="Stylesheet" type="text/css" href="../css/impromptu.css" />
    <link href="../css/bootstrap/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap/bootstrap.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../javascript/system.js"></script>
    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>
    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>
    <title>保固設備管理-設備種類維護</title>
    
     <script type="text/javascript">


         function pageLoad() {
         }

         function addSearchIcon() {
             $('#cmd_Search').prepend("<i class=\"icon-search icon-white\"></i>");
         }


        function add() {
            location.href = "KindsOfEquipmentManage.aspx?act=add&id=0";
            return false;
        }
        //個人資料修改(應於menu)
        function privateadd() {
            location.href = "KindsOfEquipmentManage.aspx?act=private&id=26";
            return false;
        }
        //修改
        function edit(val) {
            location.href = "KindsOfEquipmentManage.aspx?act=edit&id=" + val;
            return false;
        }
        function kindphoto(val) {
            location.href = "DeviceKindPhoto.aspx?id=" + val;
            return false;
        }
        function del(val) {
            $.prompt('確定要刪除此筆資料?',
            { buttons: { 確定: true, 取消: false },
                submit: function(v, m, f) {
                    if (v) {
                        var Options = {
                            type: "POST",
                            url: "../MISWebService.asmx/DelDevieKind",
                            data: "{DevieKindid: '" + val + "'}",
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
<body>
    <form id="form1" runat="server">
    <div>
    <center>
    <!--上半部控制項[搜尋, 新增]-->
        <div>
            <cc1:toolkitscriptmanager id="ScriptManager1" runat="server" combinescripts="false"></cc1:toolkitscriptmanager>
            <br />
            <div>
                <asp:Panel ID="SearchPanel" runat="server">
                
                    <div style="float: left">
                        <asp:LinkButton ID="cmd_Search" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                            Height="22px" Width="100px" OnClick="lnkbtn_Search_Click">關鍵字搜尋</asp:LinkButton>
                        <asp:DropDownList ID="ddlst_SearchType" runat="server" CssClass="dropdown">
                        </asp:DropDownList>
                        <asp:TextBox ID="txt_Query_Reason" runat="server" AutoCompleteType="Disabled" Width="200px" placeholder="請輸入"></asp:TextBox>
                    </div>
                    
                    <div style="float: right">
                  <%--  <asp:LinkButton ID="lnkbtn_Report" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                                Height="22px" Width="60px" OnClick="lnkbtn_Report_Click">&nbsp;&nbsp;匯出</asp:LinkButton>--%>
                        <asp:LinkButton ID="lnkbtn_Add" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                            OnClientClick="return add()" Height="22px" Width="60px">&nbsp;&nbsp;新增</asp:LinkButton>
                    </div>
                    
                </asp:Panel>
            </div>
        </div>
        
        <!--資料列表-->
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="2">
                  <%--  <ProgressTemplate>
                        <div class="progressBackgroundLayer">
                        </div>
                        <div class="fixedCenter">
                            <img src="../images/ajax-loader2.gif"></div>
                    </ProgressTemplate>--%>
                </asp:UpdateProgress>
                <asp:GridView ID="gv" runat="server" AllowPaging="True" CssClass="table table-hover "
                    GridLines="None" AutoGenerateColumns="False" CellPadding="4" CellSpacing="1"
                    OnPageIndexChanging="gv_PageIndexChanging" OnRowDataBound="gv_RowDataBound" OnRowCommand="gv_RowCommand"
                    PageSize="13">
                    <Columns>
                        <asp:TemplateField HeaderImageUrl="~/images/edit.gif">
                            <ItemTemplate>
                                <asp:Button ID="cmd_Edit" runat="server" Text="修改" class="btn btn-mini btn-info" />
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                        <asp:BoundField DataField="DeviceKindId" HeaderText="設備種類編號" ReadOnly="True" />
                        <asp:BoundField DataField="DeviceKind" HeaderText="設備種類" ReadOnly="True" />
                        <asp:BoundField DataField="DeviceKindName" HeaderText="設備種類名稱" ReadOnly="True" /> 
                        <asp:ButtonField HeaderText="變更圖示" ButtonType="Button" CommandName="cmd_KindPhoto" ControlStyle-CssClass="btn btn-mini  btn-info" Text="變更圖示">
                        </asp:ButtonField>
                        <asp:TemplateField HeaderImageUrl="~/images/delete.gif">
                            <ItemTemplate>
                                <asp:ImageButton ID="cmd_Delete" runat="server" EnableViewState="False" ImageUrl="~/images/x.jpg" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle  Font-Bold="True" ForeColor="black" />
                    <HeaderStyle  Font-Bold="True" ForeColor="black" />
                </asp:GridView>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="lnkbtn_Add" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="cmd_Search" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </center>
    </div>
    </form>
</body>
</html>
