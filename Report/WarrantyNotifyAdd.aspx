<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WarrantyNotifyAdd.aspx.cs"
    Inherits="Report_WarrantyNotifyAdd" %>

<!--#INCLUDE FILE="../checkpass.inc" -->
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="Stylesheet" type="text/css" href="../css/web.css" />
    <link rel="Stylesheet" type="text/css" href="../css/stylelib.css" />
    <link rel="Stylesheet" type="text/css" href="../css/impromptu.css" />
    <link href="../css/bootstrap/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap/bootstrap.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>

    <link href="../css/impromptu.css" rel="Stylesheet" type="text/css" />
    <link type="text/css" href="../css/jquery1.10.2/jquery-ui.css" rel="stylesheet" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <%--<script type="text/javascript" src="../javascript/jquery-1.9.1.min.js"></script>--%>
    <script type="text/javascript" src="../javascript/jquery-ui-1.10.2.min.js"></script>
    <link href="../css/jquery-ui-timepicker-addon.css" rel="stylesheet" />
    <script type="text/javascript" src="../javascript/jquery-ui-timepicker-addon.js"></script>
    <script type='text/javascript' src='../javascript/jquery-ui-sliderAccess.js'></script>

    <title>新增維修通報通知</title>

    <script type="text/javascript">

        function jScript() {


            var opt = {
                dateFormat: 'yy-mm-dd',
                showSecond: true,
                timeFormat: 'HH:mm:ss'
            };

            $(document).ready(function () {
                $('#TextBox_RepairDeadline_add').datetimepicker(opt);
                $('#TextBox_NotifyDate_add').datetimepicker(opt);

                $('#DropDownList_RepairDateOption_add').change(function () {
                    $("#DropDownList_RepairDateOption_add option:selected").each(function () {
                        if ($(this).val() == '3') {
                            $('#TextBox_RepairDeadline_add').removeAttr('disabled');
                        }
                        else {
                            $('#TextBox_RepairDeadline_add').attr("disabled", "disabled");
                        }
                    });
                });


            });
        }

        function validateInput() {
            TextBox_FaultDescribe_add
            var devidid = document.getElementById('TextBox_DeviceID_add').value;
            var faultDescribe = document.getElementById('TextBox_FaultDescribe_add').value;
            var faultModel = document.getElementById('DropDownList_FaultModel_add')[0].selected;
            var Company = document.getElementById('DropDownList_WarrantyCompany_add')[0].selected;
            var NotifyDate = document.getElementById('TextBox_NotifyDate_add').value;
            var RepairDateOption = document.getElementById('DropDownList_RepairDateOption_add')[0].selected;
            if (devidid == undefined || devidid == "") {
                alert("請輸入設備編號");
                return false;
            }

            if (faultDescribe == undefined || faultDescribe == "") {
                alert("請輸入故障描述");
                return false;
            }

            if (faultModel) {
                alert("請選擇故障種類");
                return false;
            }

            if (Company) {
                alert("請選擇保固廠商");
                return false;
            }

            if (NotifyDate == undefined || NotifyDate == "") {
                alert("請輸入通知日期");
                return false;
            }

            if (RepairDateOption) {
                alert("請選擇修復日期選項");
                return false;
            }

        }


    </script>
    <style type="text/css">
        b {
            color:red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <cc1:ToolkitScriptManager ID="ScriptManager1" runat="server" CombineScripts="false"></cc1:ToolkitScriptManager>
        </div>
        <script type="text/javascript" language="javascript">
            Sys.Application.add_load(jScript);
            </script>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:HiddenField ID="hidden_Action" runat="server" />
                <asp:HiddenField ID="hidden_Caseid" runat="server" />
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="2">
                    <ProgressTemplate>
                        <div class="progressBackgroundLayer">
                        </div>
                        <div class="fixedCenter">
                            <img src="../images/ajax-loader2.gif">
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <div class='container'>
                    <br />
                    <fieldset>
                        <legend>
                            <p class="text-info"><i class="icon-star"></i>通報資料查詢</p>
                        </legend>
                        <div>
                            <table style="width: 100%;">
                                <tr>
                                    <td>&nbsp;選擇設備編號：
                                    </td>
                                    <td>&nbsp;
                                    <asp:DropDownList ID="DropDownList_DeviceID" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_DeviceID_SelectedIndexChanged"
                                        AppendDataBoundItems="True">
                                        <asp:ListItem Value="0">==請選擇==</asp:ListItem>
                                    </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <asp:GridView ID="gv_deviceConfig" runat="server" CssClass="table table-hover "
                            GridLines="None" AutoGenerateColumns="False" PageSize="6" OnRowCommand="button_gridViewEdit"
                            OnPageIndexChanging="GridView1_PageIndexChanging">
                            <Columns>
                                <asp:BoundField HeaderText="設備種類" DataField="Device_Kind" />
                                <asp:BoundField HeaderText="地區" DataField="AreaName" />
                                <asp:BoundField HeaderText="路口名稱" DataField="Location" />
                                <asp:BoundField HeaderText="合約" DataField="ContractName" />
                            </Columns>
                        </asp:GridView>
                        <br />
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" CssClass="table table-hover "
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
                                <%-- <asp:BoundField HeaderText="保固查核成果" DataField="CheckResult" />
                            <asp:BoundField HeaderText="保固查核說明" DataField="CheckDescribe" />--%>
                            </Columns>
                        </asp:GridView>
                        </legend>
                    </fieldset>
                </div>
            </ContentTemplate>
            <Triggers > 
                <asp:AsyncPostBackTrigger ControlID="DropDownList_DeviceID"  />
            </Triggers>
        </asp:UpdatePanel>
        <br />
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                
                <div class='container'>
                    <fieldset>
                        <legend>
                            <p class="text-info"><i class="icon-star"></i>通報資料新增</p>
                        </legend>
                        <div>
                            <table style="width: 100%;">
                                <tr>
                                    <td>&nbsp;<b >*</b>設備編號：
                                    </td>
                                    <td>&nbsp;
                                    <asp:TextBox ID="TextBox_DeviceID_add" runat="server"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;<b >*</b>保固廠商：
                                    </td>
                                    <td>&nbsp;
                                    <asp:DropDownList ID="DropDownList_WarrantyCompany_add" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Value="0">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp; <b >*</b>故障種類：
                                    </td>
                                    <td>&nbsp;
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
                                    <td>&nbsp;指定合約：
                                    </td>
                                    <td>&nbsp;
                                    <asp:DropDownList ID="DropDownList_WarrantyContract_add" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Value="請選擇">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp; <b >*</b>故障描述：
                                    </td>
                                    <td rowspan="2">&nbsp;
                                        
                                    <asp:TextBox ID="TextBox_FaultDescribe_add" runat="server" TextMode="MultiLine"></asp:TextBox>                                  
                                    </td>
                                    <td>&nbsp;併案編號：
                                    </td>
                                    <td>&nbsp;
                                    <asp:DropDownList ID="DropDownList_ContractCombineNum" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Value="0">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;<b >*</b>通知日期：
                                    </td>
                                    <td>&nbsp;
                                    <asp:TextBox ID="TextBox_NotifyDate_add" runat="server" AutoCompleteType="Disabled"
                                        CssClass="span3" placeholder="請輸入"></asp:TextBox>
                                        <%-- <cc1:MaskedEditExtender ID="txt_StockOutTime_MaskedEditExtender" runat="server" Enabled="True" TargetControlID="TextBox_NotifyDate_add" UserDateFormat="YearMonthDay" UserTimeFormat="TwentyFourHour" MaskType="DateTime" Mask="9999/99/99 99:99:99">
                                        </cc1:MaskedEditExtender>
                                        <cc1:MaskedEditValidator
                                            ID="MaskedEditValidator1"
                                            runat="server"
                                            ControlToValidate="TextBox_NotifyDate_add"
                                            ControlExtender="txt_StockOutTime_MaskedEditExtender"
                                            IsValidEmpty="false"
                                            EmptyValueMessage="不可為空"
                                            InvalidValueMessage="格式不正確" Display="Static"></cc1:MaskedEditValidator>--%>
                                        <%-- <asp:Image ID="imgCalander1" runat="server" ImageUrl="../images/calendar.png" />
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="imgCalander1"
                                        TargetControlID="TextBox_NotifyDate_add" Format="yyyy/MM/dd">
                                    </cc1:CalendarExtender>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;重複通知說明：
                                    </td>
                                    <td rowspan="2">&nbsp;
                                    <asp:TextBox ID="TextBox_RepeatNotify_add" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;<b >*</b>修復日期選項：
                                    </td>
                                    <td>&nbsp;
                                    <asp:DropDownList ID="DropDownList_RepairDateOption_add" runat="server" AppendDataBoundItems="True"
                                        OnSelectedIndexChanged="DropDownList_RepairDateOption_add_SelectedIndexChanged">
                                        <asp:ListItem Value="0">請選擇</asp:ListItem>
                                        <asp:ListItem Value="1">請立即修復</asp:ListItem>
                                        <asp:ListItem Value="2">6小時內修復</asp:ListItem>
                                        <asp:ListItem Value="3">指定日期</asp:ListItem>
                                    </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;指定修復日期：
                                    </td>
                                    <td>&nbsp;
                                    <asp:TextBox ID="TextBox_RepairDeadline_add" runat="server" AutoCompleteType="Disabled"
                                        CssClass="span3" placeholder="請輸入" Enabled="False"></asp:TextBox>
                                        <%--  <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Enabled="True" TargetControlID="TextBox_RepairDeadline_add" UserDateFormat="YearMonthDay" UserTimeFormat="TwentyFourHour" MaskType="DateTime" Mask="9999/99/99 99:99:99">
                                        </cc1:MaskedEditExtender>--%>
                                        <%--  <cc1:MaskedEditValidator
                                            ID="MaskedEditValidator2"
                                            runat="server"
                                            ControlToValidate="TextBox_RepairDeadline_add"
                                            ControlExtender="txt_StockOutTime_MaskedEditExtender"
                                            IsValidEmpty="true"
                                            EmptyValueMessage="不可為空"
                                            InvalidValueMessage="格式不正確" Display="Static"></cc1:MaskedEditValidator>--%>
                                        <%--<asp:Image ID="imgCalander2" runat="server" ImageUrl="../images/calendar.png" Visible="False" />
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="imgCalander2"
                                        TargetControlID="TextBox_RepairDeadline_add" Format="yyyy/MM/dd">
                                    </cc1:CalendarExtender>--%>
                                    </td>
                                </tr>
                                <tr>
                                  <%--  <td>&nbsp;傳送Email通知廠商
                                    </td>--%>
                                    <td>&nbsp;
                                        <asp:CheckBox ID="chk_isSendMail" Visible="false" runat="server" />
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    <asp:Button ID="btn_Add" runat="server" Text="新增保固通知" OnClientClick="return validateInput();" OnClick="Button_add_click"
                                        CssClass="btn btn-large btn-primary" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        </legend>
                    </fieldset>
                </div>
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</body>
</html>
