<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Project_AM.aspx.cs" Inherits="MIS_Project_AM" %>
<!--#INCLUDE FILE="../checkpass.inc" -->
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../css/bootstrap/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../css/manage.css" rel="stylesheet" type="text/css" />
    <link href="../css/impromptu.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>
    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>
    <title>保固設備管理-廠商資料維護</title>

    <script type="text/javascript">

        $(document).ready(function () {
            $('#cmd_Save').bind("click", function () { return saveClick(); });
            $('#cmd_Back').bind("click", function () { return backClick(); });
        });

        function saveClick() {

            //            if ($('#txt_Company_ID').val().trim().length == 0) {//判斷是否有輸入資料
            //                alert('請輸入客運業者代碼');
            //                return false;
            //            }
            //            if ($('#txt_Company_Name').val().trim().length == 0) {
            //                alert('請輸入客運業者名稱');
            //                return false;
            //            }
        }

        function backClick() {
            location.href = "Project_QD.aspx";
            return false;
        }
    </script>

</head>
<body>
    <form id="form1" runat="server" class="form-signin form-horizontal-50">
        <div>
            <cc1:ToolkitScriptManager ID="ScriptManager1" runat="server" CombineScripts="false"></cc1:ToolkitScriptManager>
        </div>
        <asp:HiddenField ID="hidden_Action" runat="server" />
        <asp:HiddenField ID="hidden_projectno" runat="server" />
        <div class="container">
            <h3>計畫資料維護</h3>
            <div class="control-group ">
                <label class="control-label">
                    計畫編號</label>
                <div class="controls">
                    <asp:TextBox ID="txt_projectId" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                        placeholder="請輸入"></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="txt_projectId_FilteredTextBoxExtender" runat="server" FilterType="Numbers" TargetControlID="txt_projectId">
                    </ajaxToolkit:FilteredTextBoxExtender>
                </div>
                <label class="control-label">
                    計畫名稱</label>
                <div class="controls">
                    <asp:TextBox ID="txt_projectName" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                        placeholder="請輸入"></asp:TextBox>
                </div>
                <label class="control-label">
                    業主名稱</label>
                <div class="controls">
                    <asp:TextBox ID="txt_client" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                        placeholder="請輸入"></asp:TextBox>
                </div>
                <label class="control-label">
                    起始日期</label>
                <div class="controls">
                    <asp:TextBox ID="txt_startDate" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                        placeholder="請輸入"></asp:TextBox>
                     <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Enabled="True" TargetControlID="txt_startDate" UserDateFormat="YearMonthDay" UserTimeFormat="TwentyFourHour" MaskType="DateTime" Mask="9999/99/99 99:99:99">
                                        </cc1:MaskedEditExtender>
                                        <cc1:MaskedEditValidator
                                            ID="MaskedEditValidator2"
                                            runat="server"
                                            ControlToValidate="txt_startDate"
                                            ControlExtender="MaskedEditExtender1"
                                            IsValidEmpty="false"
                                            EmptyValueMessage="不可為空"
                                            InvalidValueMessage="格式不正確" Display="Static"></cc1:MaskedEditValidator>
                </div>
                <label class="control-label">
                    結束日期</label>
                <div class="controls">
                    <asp:TextBox ID="txt_endDate" runat="server" AutoCompleteType="Disabled"
                        CssClass="span3" placeholder="請輸入"></asp:TextBox>
                     <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Enabled="True" TargetControlID="txt_endDate" UserDateFormat="YearMonthDay" UserTimeFormat="TwentyFourHour" MaskType="DateTime" Mask="9999/99/99 99:99:99">
                                        </cc1:MaskedEditExtender>
                                        <cc1:MaskedEditValidator
                                            ID="MaskedEditValidator1"
                                            runat="server"
                                            ControlToValidate="txt_endDate"
                                            ControlExtender="MaskedEditExtender2"
                                            IsValidEmpty="false"
                                            EmptyValueMessage="不可為空"
                                            InvalidValueMessage="格式不正確" Display="Static"></cc1:MaskedEditValidator>
                </div>
                <label class="control-label">
                    保固起始日期</label>
                <div class="controls">
                    <asp:TextBox ID="txt_warStartDate" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                        placeholder="請輸入"></asp:TextBox>
                     <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Enabled="True" TargetControlID="txt_warStartDate" UserDateFormat="YearMonthDay" UserTimeFormat="TwentyFourHour" MaskType="DateTime" Mask="9999/99/99 99:99:99">
                                        </cc1:MaskedEditExtender>
                                        <cc1:MaskedEditValidator
                                            ID="MaskedEditValidator3"
                                            runat="server"
                                            ControlToValidate="txt_warStartDate"
                                            ControlExtender="MaskedEditExtender3"
                                            IsValidEmpty="false"
                                            EmptyValueMessage="不可為空"
                                            InvalidValueMessage="格式不正確" Display="Static"></cc1:MaskedEditValidator>
                </div>
                <label class="control-label">
                    保固結束日期</label>
                <div class="controls">
                    <asp:TextBox ID="txt_warEndDate" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                        placeholder="請輸入"></asp:TextBox>
                     <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" Enabled="True" TargetControlID="txt_warEndDate" UserDateFormat="YearMonthDay" UserTimeFormat="TwentyFourHour" MaskType="DateTime" Mask="9999/99/99 99:99:99">
                                        </cc1:MaskedEditExtender>
                                        <cc1:MaskedEditValidator
                                            ID="MaskedEditValidator4"
                                            runat="server"
                                            ControlToValidate="txt_warEndDate"
                                            ControlExtender="MaskedEditExtender4"
                                            IsValidEmpty="false"
                                            EmptyValueMessage="不可為空"
                                            InvalidValueMessage="格式不正確" Display="Static"></cc1:MaskedEditValidator>
                </div>
               
                <div class="controls" >
                    <asp:Button ID="cmd_Save" runat="server" Text="確認"
                        CssClass="btn btn-large btn-primary " OnClick="cmd_Save_Click1" />
                    <asp:Button ID="cmd_Back" runat="server" Text="取消" CssClass="btn btn-large btn-primary" />
                </div>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="cmd_Back" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="cmd_Save" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>
