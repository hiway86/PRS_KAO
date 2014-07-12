<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportReturnManage.aspx.cs"
    Inherits="Report_ReportReturnManage" EnableEventValidation="false" %>

<!--#INCLUDE FILE="../checkpass.inc" -->
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../css/bootstrap/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../css/manage.css" rel="stylesheet" type="text/css" />
    <link href="../css/web.css" rel="stylesheet" />
    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>
    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>

    <link href="../css/impromptu.css" rel="Stylesheet" type="text/css" />
    <link  type="text/css" href="../css/jquery1.10.2/jquery-ui.css" rel="stylesheet" />
    <script type="text/javascript" src="../javascript/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="../javascript/jquery-ui-1.10.2.min.js"></script>
    <link href="../css/jquery-ui-timepicker-addon.css" rel="stylesheet" />
    <script type="text/javascript" src="../javascript/jquery-ui-timepicker-addon.js"></script>
    <script type='text/javascript' src='../javascript/jquery-ui-sliderAccess.js'></script>

    <title>保固設備管理-保固案件回報</title>

    <script type="text/javascript">

        var opt = {
            dateFormat: 'yy-mm-dd',
            showSecond: true,
            timeFormat: 'HH:mm:ss'
        };

        $(document).ready(function () {
            //$('#cmd_Save').bind("click", function () { return saveClick(); });
            $('#cmd_Back').bind("click", function () { return backClick(); });
            $('#txt_repairDate').datetimepicker(opt);
        });

        function saveClick() {
            alert("新增成功");
            location.href = "RepairMaintainList.aspx";
            return false;
        }

        function backClick() {
            location.href = "RepairMaintainList.aspx";
            return false;
        }

    </script>
    <style type="text/css">
        b {
            color:red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="form-signin form-horizontal-50">
        <div>
            <cc1:ToolkitScriptManager ID="ScriptManager1" runat="server" CombineScripts="false" EnableScriptGlobalization="true"></cc1:ToolkitScriptManager>
        </div>
        <asp:HiddenField ID="hidden_Action" runat="server" />
        <asp:HiddenField ID="hidden_CaseId" runat="server" />
        <div class="container">
            <h3>保固案件回報</h3>
            <div class="control-group">
                <label class="control-label">
                    案件編號</label>
                <div class="controls">
                    <asp:DropDownList ID="cbo_caseId" runat="server" AppendDataBoundItems="True">
                        <asp:ListItem Value="null">--請選擇--</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <label class="control-label">
                    設備編號</label>
                <div class="controls">
                    <asp:DropDownList ID="cbo_deviceid" runat="server" AppendDataBoundItems="True">
                        <asp:ListItem Value="null">--請選擇--</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <label class="control-label"><b >*</b>
                    廠商回覆內容</label>
                <div class="controls">
                    <asp:TextBox ID="txt_replayContent" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                        placeholder="請輸入" TextMode="MultiLine"></asp:TextBox>
                </div>
                <label class="control-label"><b >*</b>
                    實際修復日期</label>
                <div class="controls">
                    <asp:TextBox ID="txt_repairDate" runat="server" CssClass="span3"></asp:TextBox><img src="../images/calendar.png" />
                </div>

                <label class="control-label">
                    廠商傳真回覆</label>
                <div class="controls">
                    <asp:CheckBox ID="chk_faxReplay" runat="server" CssClass="span3" />
                </div>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="2">
                    <ProgressTemplate>
                        <div class="progressBackgroundLayer">
                        </div>
                        <div class="fixedCenter">
                            <img src="../images/ajax-loader2.gif"></div>
                    </ProgressTemplate>
                </asp:UpdateProgress>--%>
                <asp:HiddenField ID="hidden_UsedMaterial" runat="server" />
                <div class="container">
                    <div class="control-group">
                        <label class="control-label">
                            耗材種類</label>
                        <div class="controls">
                            <asp:DropDownList ID="cbo_MaterialType" AutoPostBack="true" CssClass="span2" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="cbo_MaterialType_SelectedIndexChanged">
                                <asp:ListItem Value="null">--請選擇--</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="cbo_Material" CssClass="span2" runat="server" AppendDataBoundItems="True" >
                                <asp:ListItem Value="null">--請選擇--</asp:ListItem>
                            </asp:DropDownList>請輸入耗材數量：
                            <asp:TextBox ID="txt_UsedQantity" CssClass="span1" runat="server"></asp:TextBox>
                            <asp:Button ID="btn_MaterialAdd" runat="server" Text="新增" OnClick="btn_MaterialAdd_Click" />
                        </div>
                    </div>
                </div>
                <div class="controls">
                    <asp:GridView ID="gv" runat="server" AllowPaging="True" CssClass="table table-hover "
                        GridLines="None" AutoGenerateColumns="False" CellPadding="4" CellSpacing="1"
                        OnRowDeleting="CustomersGridView_RowDeleting" DataKeyNames="NO"  AutoGenerateDeleteButton="True">
                        <Columns>
                            <%--<asp:BoundField DataField="" HeaderText="編號" />--%>
                            <asp:BoundField DataField="MaterialID" HeaderText="耗材編號" />
                            <asp:BoundField DataField="MaterialName" HeaderText="耗材名稱" />
                            <asp:BoundField DataField="MaterialTypeID" HeaderText="耗材種類" />
                            <asp:BoundField DataField="UsedQuantity" HeaderText="數量" />
                        </Columns>

                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        
        <asp:Button ID="cmd_Save" runat="server" Text="確認" CssClass="btn btn-large btn-primary"
            OnClick="cmd_Save_Click1" />
        <asp:Button ID="cmd_Back" runat="server" Text="取消" CssClass="btn btn-large btn-primary" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="cmd_Back" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="cmd_Save" EventName="Click" />
            </Triggers>
            <ContentTemplate>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
