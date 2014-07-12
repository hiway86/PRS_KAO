<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NotificationConfirmWork.aspx.cs"
    Inherits="Report_NotificationConfirmWork" %>
<!--#INCLUDE FILE="../checkpass.inc" -->
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<%--    <link rel="Stylesheet" type="text/css" href="../css/web.css" />
    <link rel="Stylesheet" type="text/css" href="../css/stylelib.css" />
    <link rel="Stylesheet" type="text/css" href="../css/impromptu.css" />--%>
     <link rel="Stylesheet" type="text/css" href="../css/web.css" />
    <link href="../css/bootstrap/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap/bootstrap.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../javascript/system.js"></script>

    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>

    <title>保固通知作業</title>
    <style>
        span.radio
        {
            padding: 0px;
        }
        span.radio > input[type="radio"]
        {
            margin: 8px 0px 7px 0px;
        }
        span.radio > label
        {
        	margin: 5px 0px 7px 0px;
            float: left;
            margin-right: 5px;
            padding: 0px 5px 0px 10px;
        }
    </style>
    
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
                submit: function(v, m, f) {
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
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="2">
                    <ProgressTemplate>
                        <div class="progressBackgroundLayer">
                        </div>
                        <div class="fixedCenter">
                            <img src="../images/ajax-loader2.gif"></div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <div class='container'>
                    <br />
                    <fieldset>
                        <legend><p class="text-info"><i class="icon-star"></i>保固通知作業</p></legend>
                        <div>
                            <div class="row-fluid">
                                <div class="span2">
                                    <asp:Label ID="Label2" runat="server" Text="保固通知單列表："></asp:Label></div>
                                <div class="span7">
                                    <div class="row-fluid">
                                        <asp:RadioButtonList ID="RadioButtonList_gridviewSelectItem" runat="server" AutoPostBack="True"
                                            RepeatColumns="2" OnSelectedIndexChanged="RadioButtonList_gridviewSelectItem_SelectedIndexChanged"
                                            RepeatDirection="Horizontal" CssClass="radio" RepeatLayout="Flow">
                                            <asp:ListItem>全部保固單列表</asp:ListItem>
                                            <asp:ListItem>未確認通知列表</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                            </div>
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" CssClass="table table-hover "
                                GridLines="None" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging"
                                OnRowCommand="GridView1_RowCommand" PageSize="5" OnRowDataBound="GridView1_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderImageUrl="~/images/edit.gif">
                                        <ItemTemplate>
                                            <asp:Button ID="cmd_Edit" runat="server" Text="修改" class="btn btn-mini" onmouseover="this.className='btn btn-mini'"
                                                onmouseout="this.className='btn btn-mini'" CommandArgument="<%# Container.DataItemIndex %>"
                                                CommandName="gridviewSelect" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderImageUrl="~/images/edit.gif">
                                        <ItemTemplate>
                                            <asp:Button ID="cmd_Print" runat="server" Text="列印" class="btn btn-mini" onmouseover="this.className='btn btn-mini'"
                                                onmouseout="this.className='btn btn-mini'" CommandArgument='<%# Eval("CaseID") %>'
                                                CommandName="print" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="CaseID" HeaderText="案件編號" />
                                    <asp:BoundField DataField="DeviceID" HeaderText="設備編號" />
                                    <asp:BoundField DataField="NotifyDate" HeaderText="通知日期" DataFormatString="{0:yyyy/MM/dd}" />
                                    <asp:BoundField DataField="NotifyConfirm" HeaderText="通知確認" />
                                    <asp:BoundField DataField="NotifyContact" HeaderText="確認窗口" />
                                    <asp:BoundField DataField="PhoneConfirmDate" HeaderText="電話確認時間" DataFormatString="{0:yyyy/MM/dd}" />
                                    <asp:BoundField DataField="FaxConfirmDate" HeaderText="Fax確認時間" DataFormatString="{0:yyyy/MM/dd}" />
                                    <asp:BoundField DataField="EmailConfirmDate" HeaderText="Email確認時間" DataFormatString="{0:yyyy/MM/dd}" />
                                    <asp:BoundField DataField="Deadline" HeaderText="即期催辦時間" DataFormatString="{0:yyyy/MM/dd}" />
                                </Columns>
                            </asp:GridView>
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        &nbsp; 案件編號：
                                    </td>
                                    <td>
                                        &nbsp;
                                        <asp:TextBox ID="TextBox_CaseID" runat="server" Enabled="False"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp; 設備編號：
                                    </td>
                                    <td>
                                        &nbsp;
                                        <asp:TextBox ID="TextBox_DeviceID" runat="server" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp; 通知確認：
                                    </td>
                                    <td>
                                        &nbsp;
                                        <asp:CheckBox ID="CheckBox_NotifyConfirm" runat="server" />
                                    </td>
                                    <td>
                                        &nbsp; 確認窗口：
                                    </td>
                                    <td>
                                        &nbsp;
                                        <asp:TextBox ID="TextBox_NotifyContact" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp; 電話確認時間：
                                    </td>
                                    <td>
                                        &nbsp;
                                        <asp:TextBox ID="TextBox_PhoneConfirmDate" runat="server"></asp:TextBox>
                                        <asp:Image ID="imgCalander1" runat="server" ImageUrl="../images/calendar.png" />
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="imgCalander1"
                                            TargetControlID="TextBox_PhoneConfirmDate" Format="yyyy/MM/dd">
                                        </cc1:CalendarExtender>
                                    </td>
                                    <td>
                                        &nbsp; Fax確認時間：
                                    </td>
                                    <td>
                                        &nbsp;
                                        <asp:TextBox ID="TextBox_FaxConfirmDate" runat="server"></asp:TextBox>
                                        <asp:Image ID="imgCalander2" runat="server" ImageUrl="../images/calendar.png" />
                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="imgCalander2"
                                            TargetControlID="TextBox_FaxConfirmDate" Format="yyyy/MM/dd">
                                        </cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp; Email確認時間：
                                    </td>
                                    <td>
                                        &nbsp;
                                        <asp:TextBox ID="TextBox_EmailConfirmDate" runat="server"></asp:TextBox>
                                        <asp:Image ID="imgCalander3" runat="server" ImageUrl="../images/calendar.png" />
                                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="imgCalander3"
                                            TargetControlID="TextBox_EmailConfirmDate" Format="yyyy/MM/dd">
                                        </cc1:CalendarExtender>
                                    </td>
                                    <td>
                                        &nbsp; 即期催辦時間：
                                    </td>
                                    <td>
                                        &nbsp;
                                        <asp:TextBox ID="TextBox_Deadline" runat="server"></asp:TextBox>
                                        <asp:Image ID="imgCalander4" runat="server" ImageUrl="../images/calendar.png" />
                                        <cc1:CalendarExtender ID="CalendarExtender4" runat="server" PopupButtonID="imgCalander4"
                                            TargetControlID="TextBox_Deadline" Format="yyyy/MM/dd">
                                        </cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                        <asp:Button ID="btn_Add" runat="server" Text="更新儲存" OnClick="Button_save_Click"
                                            CssClass="btn btn-large btn-primary" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        </legend>
                    </fieldset>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
