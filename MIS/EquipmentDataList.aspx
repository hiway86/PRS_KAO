<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EquipmentDataList.aspx.cs"
    Inherits="MIS_EquipmentDataList" %>
<!--#INCLUDE FILE="../checkpass.inc" -->
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <link rel="Stylesheet" type="text/css" href="../css/web.css" />
    <link rel="Stylesheet" type="text/css" href="../css/impromptu.css" />
    <link href="../css/bootstrap/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap/bootstrap.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../javascript/system.js"></script>

    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>

    <title>保固設備管理-設備資料列表</title>

    <script type="text/javascript">

        function pageLoad() {

        } 
        //$(document).ready(function () {
        //    $("#ddlst_SearchType").change(
        //    function () {
        //        var SearchType = $("#ddlst_SearchType").find(':selected').val();
        //        if (SearchType == 'ContractStartDate' || SearchType == 'ContractEndDate') {
        //            $('#SearchDate').css('display', 'inline');
        //            $('#txt_Query_Reason').css('display', 'none');
        //        }
        //        else {
                    
        //            $('#SearchDate').css('display', 'none');
        //            $('#txt_Query_Reason').css('display', 'inline');
        //        }
        //    }
        //);

        //});
        

        function addSearchIcon() {
            $('#cmd_Search').prepend("<i class=\"icon-search icon-white\"></i>");
        }

        function addMapIcon() {
            $('#mapView').prepend("<i class=\"icon-map-marker icon-white\"></i>");
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
            { buttons: { 確定: true, 取消: false },
                submit: function(v, m, f) {
                    if (v) {
                        var Options = {
                            type: "POST",
                            url: "../MISWebService.asmx/DelEquipment",
                            data: "{device_id: '" + val + "'}",
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
    <form id="form1" defaultbutton="cmd_Search" runat="server">
    <center>
        <div>
            <cc1:toolkitscriptmanager id="ScriptManager1" runat="server" combinescripts="false"></cc1:toolkitscriptmanager>
            <br />
            <div>
                <asp:Panel ID="SearchPanel" runat="server">
                    <div style="float: left">
                        <asp:LinkButton ID="mapView" runat="server" CssClass="btn btn-primary" Height="22px"
                            Width="100px" OnClick="mapView_Click">地圖檢視</asp:LinkButton>
                        <asp:LinkButton ID="cmd_Search" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                            Height="22px" Width="100px" OnClick="lnkbtn_Search_Click">關鍵字搜尋</asp:LinkButton>
                        <asp:DropDownList ID="ddlst_SearchType" runat="server" CssClass="dropdown ">
                        </asp:DropDownList>
                        <asp:TextBox ID="txt_Query_Reason" runat="server" AutoCompleteType="Disabled" Width="200px"
                            placeholder="請輸入"></asp:TextBox>
                    </div>
                    <div style="float: right">
                     <%--   <asp:LinkButton ID="lnkbtn_Report" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                            Height="22px" OnClick="lnkbtn_Report_Click" Width="60px">&nbsp;&nbsp;匯出</asp:LinkButton>--%>
                        <asp:LinkButton ID="lnkbtn_Add" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                            OnClientClick="return add()" Height="22px" Width="60px" >&nbsp;&nbsp;新增</asp:LinkButton>
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
                            <img src="../images/ajax-loader2.gif"></div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:GridView ID="gv" runat="server" AllowPaging="True" CssClass="table table-hover GridHeaderColor "
                    GridLines="None" AutoGenerateColumns="False" CellPadding="4" CellSpacing="1"
                    OnPageIndexChanging="gv_PageIndexChanging" OnRowDataBound="gv_RowDataBound" 
                    PageSize="5" OnRowCommand="gv_RowCommand">
                    <Columns>
                        <asp:ButtonField ButtonType="Button" CommandName="singleMapView" Text="地圖">
                            <ControlStyle CssClass="btn btn-mini btn-success" />
                        </asp:ButtonField>
                        <asp:TemplateField HeaderImageUrl="~/images/edit.gif">
                            <ItemTemplate>
                                <asp:Button ID="cmd_Edit" runat="server" Text="修改" class="btn btn-mini btn-info" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Device_ID" HeaderText="設備編號" ReadOnly="True" />
                        <asp:TemplateField HeaderText ="設備編號">
                        <ItemTemplate>
                            <asp:HyperLink ID="hlk_equipmentID"  runat="server" NavigateUrl="ShowAccident.aspx?AID='" Target="_blank"></asp:HyperLink>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Device_Kind" HeaderText="設備種類" ReadOnly="True" />
                        <asp:BoundField DataField="AreaName" HeaderText="地區" ReadOnly="True" />
                        <asp:BoundField DataField="Location" HeaderText="路口名稱" HeaderStyle-Width="160px" ReadOnly="True" />
                        <asp:BoundField DataField="ContractName" HeaderText="設備合約" HeaderStyle-Width="160px" ReadOnly="True" />
<%--                        <asp:BoundField DataField="Status" HeaderText="設備狀態" ReadOnly="True" />--%>
                        <asp:BoundField DataField="ContractStartDate" HeaderText="保固起始日" ReadOnly="True" DataFormatString="{0:yyyy/MM/dd}"/>
                        <asp:BoundField DataField="ContractEndDate" HeaderText="保固中止日" ReadOnly="True" DataFormatString="{0:yyyy/MM/dd}"/>
                        <asp:BoundField DataField="DevicePhoto" HeaderText="設備照片檔名" ReadOnly="True" />
                        <asp:BoundField DataField="Gis_X" HeaderText="經度" ReadOnly="True" />
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
                                <asp:Button ID="cmd_AddMaterial" runat="server" Text="管理零件" class="btn btn-mini btn-info" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle Font-Bold="True" ForeColor="black" />
                    <HeaderStyle Font-Bold="True" ForeColor="black" />
                </asp:GridView>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="lnkbtn_Add" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="cmd_Search" EventName="Click" />
<%--                <asp:AsyncPostBackTrigger ControlID="lnkbtn_Report" EventName="Click" />--%>
            </Triggers>
        </asp:UpdatePanel>
    </center>
    </form>
</body>
</html>
