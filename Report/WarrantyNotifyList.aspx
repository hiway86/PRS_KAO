﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WarrantyNotifyList.aspx.cs" Inherits="Report_WarrantyNotifyList" %>
<!--#INCLUDE FILE="../checkpass.inc" -->
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="Stylesheet" type="text/css" href="../css/web.css" />
    <link rel="Stylesheet" type="text/css" href="../css/stylelib.css" />
    <link rel="Stylesheet" type="text/css" href="../css/impromptu.css" />
    <link href="../css/bootstrap/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap/bootstrap.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>
    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>

    <title>維修通報作業</title>

    <script type="text/javascript">
        function pageLoad() {
            setControlPermit();
        }

        function setControlPermit() {
            //設定權限
            if (!pagePermit.enableBrowser) {
                $.prompt('操作逾時，請重新登入',
            {
                buttons: { 確定: true },
                submit: function (v, m, f) {
                    window.location = '../Index.aspx';
                }
            });
                $('div.jqi .jqiclose').hide();
            }
            if (!pagePermit.enableQuery) {
                $('#cmd_Search').attr('disabled', 'disabled');
            }
            if (!pagePermit.enableAdd) {
                $('#lnkbtn_Add').attr('disabled', 'disabled');
            }
            if (!pagePermit.enableAdd) {
                $('#btn_Add').attr('disabled', 'disabled');
            }
            if (!pagePermit.enableEdit) {
                $("#gv :input[id$='cmd_Edit']").attr('disabled', 'disabled');
            }
            if (!pagePermit.enableDelete) {
                $("#gv :image[id$='cmd_Delete']").attr('disabled', 'disabled');
            }
        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
         <div>
             <cc1:ToolkitScriptManager ID="ScriptManager1" runat="server" CombineScripts="false"></cc1:ToolkitScriptManager>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class='container'>
                <fieldset>
                    <legend>新增維修通報</legend>
                    <div>
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    &nbsp; 設備編號：
                                </td>
                                <td>
                                   &nbsp;
                                    <asp:DropDownList ID="DropDownList_DeviceID" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_DeviceID_SelectedIndexChanged"
                                        AppendDataBoundItems="True">
                                        <asp:ListItem Value="0">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;保固廠商：
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:DropDownList ID="DropDownList_WarrantyCompany_add" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Value="0">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp; 故障種類：
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:DropDownList ID="DropDownList_FaultModel_add" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Value="0">請選擇</asp:ListItem>
                                        <asp:ListItem Value="1">裝置</asp:ListItem>
                                        <asp:ListItem Value="2">通訊</asp:ListItem>
                                        <asp:ListItem Value="3">燈頭</asp:ListItem>
                                        <asp:ListItem Value="4">行人燈</asp:ListItem>
                                        <asp:ListItem Value="5">外線</asp:ListItem>
                                        <asp:ListItem Value="6">其他</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;指定合約：
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:DropDownList ID="DropDownList_WarrantyContract_add" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Value="請選擇">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp; 故障描述：
                                </td>
                                <td rowspan="2">
                                    &nbsp;
                                    <asp:TextBox ID="TextBox_FaultDescribe_add" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;併案編號：
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:DropDownList ID="DropDownList_ContractCombineNum" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Value="0">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;通知日期：
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:TextBox ID="TextBox_NotifyDate_add" runat="server" AutoCompleteType="Disabled"
                                        CssClass="span3" placeholder="請輸入" Enabled="False"></asp:TextBox>
                                    <asp:Image ID="imgCalander1" runat="server" ImageUrl="../images/calendar.png" />
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="imgCalander1"
                                        TargetControlID="TextBox_NotifyDate_add" Format="yyyy/MM/dd">
                                    </cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;重複通知說明：
                                </td>
                                <td rowspan="2">
                                    &nbsp;
                                    <asp:TextBox ID="TextBox_RepeatNotify_add" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;修復日期選項：
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:DropDownList ID="DropDownList_RepairDateOption_add" runat="server" AppendDataBoundItems="True"
                                        OnSelectedIndexChanged="DropDownList_RepairDateOption_add_SelectedIndexChanged"
                                        AutoPostBack="True">
                                        <asp:ListItem Value="0">請選擇</asp:ListItem>
                                        <asp:ListItem Value="1">請立即修復</asp:ListItem>
                                        <asp:ListItem Value="2">6小時內修復</asp:ListItem>
                                        <asp:ListItem Value="3">指定日期</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;指定修復日期：
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:TextBox ID="TextBox_RepairDeadline_add" runat="server" AutoCompleteType="Disabled"
                                        CssClass="span3" placeholder="請輸入" Enabled="False"></asp:TextBox>
                                    <asp:Image ID="imgCalander2" runat="server" ImageUrl="../images/calendar.png" Visible="False" />
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="imgCalander2"
                                        TargetControlID="TextBox_RepairDeadline_add" Format="yyyy/MM/dd">
                                    </cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;所屬計畫：
                                </td>
                                <td>
                                     &nbsp;<asp:DropDownList ID="DropDownList_Project" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Value="0">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:Button ID="btn_Add" runat="server" Text="新增保固通知" OnClick="Button_add_click" 
                                        CssClass="btn btn-large btn-primary" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    </legend>
                </fieldset>
            </div>
            <br />
            <div class='container'>
                <br />
                <fieldset>
                    <legend>設備歷史通報紀錄</legend>
                    <div>
                       <asp:GridView ID="GridView2" runat="server" CssClass="table table-hover table-striped "
                        GridLines="None" AutoGenerateColumns="False" PageSize="6" OnRowCommand="button_gridViewEdit"
                        OnPageIndexChanging="GridView1_PageIndexChanging">
                        <Columns>
                            <asp:BoundField HeaderText="設備編號" DataField="DeviceID" />
                            <asp:BoundField HeaderText="設備種類" DataField="DeviceModelName" />
                            <asp:BoundField HeaderText="地區" DataField="RegionName" />
                            <asp:BoundField HeaderText="路口名稱" DataField="SectorName" />
                            <asp:BoundField HeaderText="備註" DataField="DeviceNote" />
                            <asp:BoundField HeaderText="控制器型號" DataField="TCModel" />
                            <asp:BoundField HeaderText="控制器合約" DataField="ContractName" />
                            <asp:BoundField HeaderText="保固狀態" DataField="DeviceStatus" />
                        </Columns>
                    </asp:GridView>
                    </div>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" CssClass="table table-hover table-striped "
                        GridLines="None" AutoGenerateColumns="False" PageSize="6" OnRowCommand="button_gridViewEdit"
                        OnPageIndexChanging="GridView1_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderImageUrl="~/images/edit.gif">
                                <ItemTemplate>
                                    <asp:Button ID="cmd_Edit" runat="server" Text="修改" class="btn btn-mini" onmouseover="this.className='btn btn-mini'"
                                        onmouseout="this.className='btn btn-mini'" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="案件編號" DataField="CaseID" />
                            <asp:BoundField HeaderText="設備編號" DataField="DeviceID" />
                            <asp:BoundField HeaderText="故障種類" DataField="FaultModel" />
                            <asp:BoundField HeaderText="故障描述" DataField="FaultDescribe" />
                            <asp:BoundField HeaderText="通知日期" DataField="NotifyDate" />
                            <asp:BoundField HeaderText="指定修復日期" DataField="RepairDeadline" />
                            <asp:BoundField HeaderText="併案編號" DataField="ContractCombineNum" />
                            <asp:BoundField HeaderText="廠商回覆內容" DataField="ReplyContent" />
                            <asp:BoundField HeaderText="保固查核成果" DataField="CheckResult" />
                            <asp:BoundField HeaderText="保固查核說明" DataField="CheckDescribe" />
                        </Columns>
                    </asp:GridView>
                    </legend>
                </fieldset>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>