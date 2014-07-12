<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeviceCheck_Q.aspx.cs" Inherits="MIS_DeviceCheck_Q" %>

<!--#INCLUDE FILE="../checkpass.inc" -->
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <link rel="Stylesheet" type="text/css" href="../css/web.css" />
    <link rel="Stylesheet" type="text/css" href="../css/impromptu.css" />
    <link href="../css/bootstrap/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap/bootstrap.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>

    <title>保固設備管理-設備檢修列表</title>

    <script type="text/javascript">

        function pageLoad() {
        }

        function addSearchIcon() {
            $('#cmd_Search').prepend("<i class=\"icon-search icon-white\"></i>");
        }

        function addCheckIcon() {
            $('#lnkbtn_Add').prepend("<i class=\"icon-calendar icon-white\"></i>");
        }

        function add() {
            location.href = "EquipmentDataManage.aspx?act=add&id=0";
            return false;
        }
        //修改
        function edit(val) {
            location.href = "EquipmentDataManage.aspx?act=edit&id=" + val;
            return false;
        }

        function AddMaterial(val) {
            location.href = "MatrialOfDevceManage.aspx?act=edit&DID=" + val;
            return false;
        }
        function map(val) {
            location.href = "mapViewer.aspx?type=Device&id=" + val;
            return false;
        }
        function del(val) {
            $.prompt('確定要刪除此筆資料?',
            {
                buttons: { 確定: true, 取消: false },
                submit: function (v, m, f) {
                    if (v) {
                        var Options = {
                            type: "POST",
                            url: "../MISWebService.asmx/DelEquipment",
                            data: "{device_id: '" + val + "'}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            error: function (error) {
                                $.prompt('錯誤');
                            },
                            timeout: function (error) {
                                $.prompt('連線逾時');
                            },
                            success: function (response) {
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
    <form id="form1" defaultbutton="cmd_Search" runat="server">
        <center>
            <div>
                <cc1:ToolkitScriptManager ID="ScriptManager1" runat="server" CombineScripts="false"></cc1:ToolkitScriptManager>

                <br />
                <div>
                    <asp:Panel ID="SearchPanel" runat="server">
                        <div style="float: left">
                            <asp:LinkButton ID="cmd_Search" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                                Height="22px" Width="100px" OnClick="lnkbtn_Search_Click">關鍵字搜尋</asp:LinkButton>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlst_SearchType" AutoPostBack="true" runat="server" CssClass="dropdown span2 " OnSelectedIndexChanged="ddlst_SearchType_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txt_Query_Reason" runat="server" AutoCompleteType="Disabled" Width="200px"
                                        placeholder="請輸入"></asp:TextBox>

                                    <asp:TextBox ID="txt_StartDate" Visible="false" runat="server" Enabled="false" AutoCompleteType="Disabled"
                                        CssClass="span2" placeholder="請輸入"></asp:TextBox>
                                    <asp:Image ID="imgCalander4" runat="server" Visible="false" ImageUrl="../images/calendar.png" />
                                    <cc1:CalendarExtender ID="txt_Car_Licence_Exp_CalendarExtender1" runat="server" PopupButtonID="imgCalander4"
                                        TargetControlID="txt_StartDate" Format="yyyy/MM/dd">
                                    </cc1:CalendarExtender>
                                    <asp:Label ID="lbl_startToEnd" runat="server" Visible="false" Text="~"></asp:Label>

                                    <asp:TextBox ID="txt_EndDate" runat="server" Enabled="false" Visible="false" AutoCompleteType="Disabled"
                                        CssClass="span2" placeholder="請輸入"></asp:TextBox>
                                    <asp:Image ID="imgCalander5" runat="server" Visible="false" ImageUrl="../images/calendar.png" />
                                    <cc1:CalendarExtender ID="txt_Car_Licence_Exp_CalendarExtender2" runat="server" PopupButtonID="imgCalander5"
                                        TargetControlID="txt_EndDate" Format="yyyy/MM/dd">
                                    </cc1:CalendarExtender>

                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlst_SearchType" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                        <div style="float: right">
                            <%--   <asp:LinkButton ID="lnkbtn_Report" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                            Height="22px" OnClick="lnkbtn_Report_Click" Width="60px">&nbsp;&nbsp;匯出</asp:LinkButton>--%>
                            <asp:LinkButton ID="lnkbtn_Add" runat="server" CausesValidation="False" CssClass="btn btn-primary span2"
                                OnClientClick="if (confirm('重新計算將舊有檢修日期刪除，確定計算嗎?')==false) {return false;}"
                                OnClick="lnkbtn_Add_Click"> 重新計算檢修週期</asp:LinkButton>
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
                    <asp:GridView ID="gv" runat="server" AllowPaging="True" CssClass="table table-hover "
                        GridLines="None" AutoGenerateColumns="False" CellPadding="4" CellSpacing="1"
                        OnPageIndexChanging="gv_PageIndexChanging" OnRowDataBound="gv_RowDataBound"
                        PageSize="5" OnRowCommand="gv_RowCommand">
                        <Columns>
                            <asp:ButtonField ButtonType="Button" CommandName="singleMapView" Text="地圖">
                                <ControlStyle CssClass="btn btn-mini btn-success" />
                            </asp:ButtonField>
                            <asp:TemplateField HeaderImageUrl="~/images/edit.gif">
                                <ItemTemplate>
                                    <asp:Button ID="btn_Search" runat="server" Text="查詢檢修紀錄" CommandName="Search" class="btn btn-mini btn-info" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Device_ID" HeaderText="設備編號" ReadOnly="True" />
                            <asp:TemplateField HeaderText="設備編號">
                                <ItemTemplate>
                                    <asp:HyperLink ID="hlk_equipmentID" runat="server" NavigateUrl="ShowAccident.aspx?AID='" Target="_blank"></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Device_Kind" HeaderText="設備種類" ReadOnly="True" />
                            <asp:BoundField DataField="AreaName" HeaderText="地區" ReadOnly="True" />
                            <asp:BoundField DataField="Location" HeaderText="路口名稱" ReadOnly="True" />
                            <asp:BoundField DataField="ContractName" HeaderText="設備合約" ReadOnly="True" />
                            <%-- <asp:BoundField DataField="Status" HeaderText="設備狀態" ReadOnly="True" />--%>
                            <asp:BoundField DataField="ContractStartDate" HeaderText="保固起始日" ReadOnly="True" DataFormatString="{0:yyyy/MM/dd}" />
                            <asp:BoundField DataField="ContractEndDate" HeaderText="保固中止日" ReadOnly="True" DataFormatString="{0:yyyy/MM/dd}" />
                            <asp:BoundField DataField="CheckDate" HeaderText="近期檢修日" ReadOnly="True" DataFormatString="{0:yyyy/MM/dd}" />

                            <%-- <asp:BoundField DataField="DevicePhoto" HeaderText="設備照片檔名" ReadOnly="True" />--%>
                            <%-- <asp:BoundField DataField="Gis_X" HeaderText="經度" ReadOnly="True" />
                        <asp:BoundField DataField="Gis_Y" HeaderText="緯度" ReadOnly="True" />
                        <asp:TemplateField HeaderText="照片">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="" Text="" Visible="False"
                                    Target="_blank"></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderImageUrl="~/images/delete.gif">
                            <ItemTemplate>
                                <asp:ImageButton ID="cmd_Delete" runat="server" EnableViewState="False" OnClientClick = "if (confirm('您確定要刪除嗎?')==false) {return false;}"  ImageUrl="~/images/x.jpg" />
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderImageUrl="~/images/edit.gif">
                            <ItemTemplate>
                                <asp:Button ID="cmd_AddMaterial" runat="server" Text="管理零件" class="btn btn-mini" onmouseover="this.className='btn btn-mini'"
                                    onmouseout="this.className='btn btn-mini'" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        </Columns>
                        <FooterStyle Font-Bold="True" ForeColor="black" />
                        <HeaderStyle Font-Bold="True" ForeColor="black" BackColor="#3399ff" />
                    </asp:GridView>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="lnkbtn_Add" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="cmd_Search" EventName="Click" />
                    <%--                <asp:AsyncPostBackTrigger ControlID="lnkbtn_Report" EventName="Click" />--%>
                </Triggers>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="gv3" runat="server" AllowPaging="True" CssClass="table table-hover "
                        GridLines="None" AutoGenerateColumns="False" CellPadding="4" CellSpacing="1"
                        PageSize="5" OnPageIndexChanging="gv3_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="Device_ID" HeaderText="設備編號" ReadOnly="True" />
                            <asp:BoundField DataField="CheckDate" DataFormatString="{0:yyyy/MM/dd}" HeaderText="檢修日期" ReadOnly="True" />
                        </Columns>
                        <FooterStyle Font-Bold="True" ForeColor="black" />
                        <HeaderStyle Font-Bold="True" ForeColor="black" BackColor="#3399ff" />
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </center>
    </form>
</body>
</html>
