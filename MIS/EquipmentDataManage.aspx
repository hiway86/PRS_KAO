<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EquipmentDataManage.aspx.cs"
    Inherits="MIS_EquipmentDataManage" %>
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

    <title>保固設備管理-設備資料維護</title>

    <script type="text/javascript">

        $(document).ready(function() {
            $('#cmd_Save').bind("click", function() { return saveClick(); });
            $('#cmd_Back').bind("click", function() { return backClick(); });
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
            location.href = "EquipmentDataList.aspx";
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
        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" CombineScripts="false"></cc1:ToolkitScriptManager> 
    </div>
    <asp:HiddenField ID="hidden_Action" runat="server" />
    <asp:HiddenField ID="hidden_Device_ID" runat="server" />
    <div class="container">
        <h3>
            設備資料維護</h3>
        <div class="control-group ">
            <label class="control-label"><b >*</b>
                設備編號</label>
            <div class="controls">
                <asp:TextBox ID="txt_Device_ID" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                    placeholder="請輸入"></asp:TextBox>
            </div>
        </div>
         <div class="control-group">
            <label class="control-label"><b >*</b>
                設備種類</label>
            <div class="controls">
                <asp:DropDownList ID="cbo_DeviceModel" runat="server" AppendDataBoundItems="True">
                    <asp:ListItem Value="null">--請選擇--</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label"><b >*</b>
                通訊伺服器IP</label>
            <div class="controls">
                <asp:TextBox ID="txt_Comm_Server_IP" runat="server" AutoCompleteType="Disabled" CssClass="span4"
                    placeholder="請輸入"></asp:TextBox>
            </div>
        </div>
        <%--<div class="control-group">
            <label class="control-label">
                設備種類</label>
            <div class="controls">
                <asp:DropDownList ID="cbo_deviceModel" runat="server" AppendDataBoundItems="True">
                    <asp:ListItem Value="null">--請選擇--</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>--%>
        <div class="control-group">
            <label class="control-label"><b >*</b>
                地區</label>
            <div class="controls">
                <asp:DropDownList ID="cbo_region" runat="server" AppendDataBoundItems="True">
                    <asp:ListItem Value="null">--請選擇--</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label"><b >*</b>
                路口名稱</label>
            <div class="controls">
                <asp:TextBox ID="txt_sectorName" runat="server" AutoCompleteType="Disabled" CssClass="span4"
                    placeholder="請輸入"></asp:TextBox>
            </div>
        </div>
       <%-- <div class="control-group">
            <label class="control-label">
                控制器型號</label>
            <div class="controls">
                <asp:TextBox ID="txt_tcModel" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                    placeholder="請輸入"></asp:TextBox>
            </div>
        </div>--%>
        <div class="control-group">
            <label class="control-label">
                設備合約編號</label>
            <div class="controls">
                <asp:DropDownList ID="cbo_deviceContractID" runat="server" CssClass="span4" AppendDataBoundItems="True">
                    <asp:ListItem Value="null">--請選擇--</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
       <%-- <div class="control-group">
            <label class="control-label">
                設備狀態</label>
            <div class="controls">
                <asp:TextBox ID="txt_deviceStatus" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                    placeholder="請輸入"></asp:TextBox>
            </div>
        </div>--%>
       <%-- <div class="control-group">
            <label class="control-label">
                設備備註</label>
            <div class="controls">
                <asp:TextBox ID="txt_deviceNote" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                    placeholder="請輸入"></asp:TextBox>
            </div>
        </div>--%>
        <div class="control-group">
            <label class="control-label"><b >*</b>經度</label>
            <div class="controls">
                <asp:TextBox ID="txt_longitude" runat="server" AutoCompleteType="Disabled" CssClass="span3" placeholder="請輸入"></asp:TextBox>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label"><b >*</b>緯度</label>
            <div class="controls">
                <asp:TextBox ID="txt_latitude" runat="server" AutoCompleteType="Disabled" CssClass="span3" placeholder="請輸入"></asp:TextBox>
            </div>
        </div>
        <%--<div class="control-group">
            <label class="control-label">
                設備照片</label>
            <div class="controls">
                <asp:FileUpload ID="imageFile" runat="server" /><br />
                上傳檔案大小4MB, 檔案結尾限.jpg/.png/.gif類型圖檔<br />
                <asp:Image ID="image" runat="server" style="max-width:400px;" />
            </div>
        </div>--%>
        <%--<div class="control-group">
            <label class="control-label"><b >*</b>
                設備ID</label>
            <div class="controls">
                <asp:TextBox ID="txt_Equipment_ID" runat="server" AutoCompleteType="Disabled" CssClass="span4"
                    placeholder="請輸入"></asp:TextBox>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label"><b >*</b>
               屬性</label>
            <div class="controls">
                <asp:TextBox ID="txt_Attribute" runat="server" AutoCompleteType="Disabled" CssClass="span4"
                    placeholder="請輸入"></asp:TextBox>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label"><b >*</b>
                狀態</label>
            <div class="controls">
                <asp:TextBox ID="txt_Status" runat="server" AutoCompleteType="Disabled" CssClass="span4"
                    placeholder="請輸入"></asp:TextBox>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label"><b >*</b>
                接收Port</label>
            <div class="controls">
                <asp:TextBox ID="txt_Receive_Port" runat="server" AutoCompleteType="Disabled" CssClass="span4"
                    placeholder="請輸入"></asp:TextBox>
                 <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" 
                     TargetControlID="txt_Receive_Port" FilterType="Numbers"></cc1:FilteredTextBoxExtender>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label"><b >*</b>
                遠端IP</label>
            <div class="controls">
                <asp:TextBox ID="txt_Remote_IP" runat="server" AutoCompleteType="Disabled" CssClass="span4"
                    placeholder="請輸入"></asp:TextBox>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label"><b >*</b>
                遠端Port</label>
            <div class="controls">
                <asp:TextBox ID="txt_Remote_Port" runat="server" AutoCompleteType="Disabled" CssClass="span4"
                    placeholder="請輸入"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" 
                    TargetControlID="txt_Remote_Port" FilterType="Numbers"></cc1:FilteredTextBoxExtender>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label"><b >*</b>
                電話號碼</label>
            <div class="controls">
                <asp:TextBox ID="txt_Phone_Number" runat="server" AutoCompleteType="Disabled" CssClass="span4"
                    placeholder="請輸入"></asp:TextBox>
            </div>
        </div>--%>
        <asp:Button ID="cmd_Save" runat="server" Text="確認" CssClass="btn btn-large btn-primary"
            OnClick="cmd_Save_Click" />
        <asp:Button ID="cmd_Back" runat="server" Text="取消" CssClass="btn btn-large btn-primary" />
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
