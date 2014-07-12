<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DoorSill_AM.aspx.cs" Inherits="VDCheck_DoorSill_AM" %>
<!--#INCLUDE FILE="../checkpass.inc" -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../css/bootstrap/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../css/manage.css" rel="stylesheet" type="text/css" />
    <link href="../css/impromptu.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>

    <title>VD資料檢核-門檻值編輯</title>

    <script type="text/javascript">

        $(document).ready(function () {
            $('#cmd_Save').bind("click", function () { return saveClick(); });
            $('#cmd_Back').bind("click", function () { return backClick(); });
        });

        function saveClick() {
            /*
                        if ($('#txt_Company_ID').val().trim().length == 0) {//判斷是否有輸入資料
                            alert('請輸入客運業者代碼');
                            return false;
                        }
                        if ($('#txt_Company_Name').val().trim().length == 0) {
                            alert('請輸入客運業者名稱');
                            return false;
                        }
            */
        }

        function backClick() {
            location.href = "DoorSill_Q.aspx";
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server"  class="form-signin form-horizontal-50">
    <div>
        <cc1:ToolkitScriptManager ID="ScriptManager1" runat="server" CombineScripts="false"></cc1:ToolkitScriptManager>
    </div>
    <asp:HiddenField ID="hidden_Action" runat="server" />
    <asp:HiddenField ID="hidden_Id" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <div class="container">
        <h3>門檻值維護</h3>
        <div class="devide-line">
            <hr />
        </div>
        <!--end-->        
         <div class="control-group">
             <label class="control-label">
                設備編號</label>
            <div class="controls">
                 <asp:DropDownList ID="ddlst_Device"  runat="server" AppendDataBoundItems="True" CssClass="dropdown span3">
                                 <asp:ListItem Value="0">請選擇</asp:ListItem>
                     </asp:DropDownList>
               <%-- <asp:TextBox ID="txt_DeviceID" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                    placeholder="請輸入" TargetControlID="txt_flowUpBound"></asp:TextBox>--%>
           </div>      
            <label class="control-label">
                流量上限</label>
            <div class="controls">
                <asp:TextBox ID="txt_flowUpBound" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                    placeholder="請輸入" TargetControlID="txt_flowUpBound"></asp:TextBox>
                 <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers" TargetControlID="txt_flowUpBound"></cc1:FilteredTextBoxExtender>     
           </div>      
            <label class="control-label">
                流量下限</label>
            <div class="controls">
                <asp:TextBox ID="txt_flowLowBound" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                    placeholder="請輸入"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers" 
                    TargetControlID="txt_flowLowBound"></cc1:FilteredTextBoxExtender>     
            </div>
              <label class="control-label">
                速度上限</label>
            <div class="controls">
                <asp:TextBox ID="txt_SpeedUpBound" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                    placeholder="請輸入"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Numbers" 
                    TargetControlID="txt_SpeedUpBound"></cc1:FilteredTextBoxExtender> 
            </div>
              <label class="control-label">
                速度下限</label>
            <div class="controls">
                <asp:TextBox ID="txt_SpeedLowBound" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                    placeholder="請輸入"></asp:TextBox>
                 <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterType="Numbers" 
                    TargetControlID="txt_SpeedLowBound"></cc1:FilteredTextBoxExtender>
            </div>
              <label class="control-label">
                佔有率上限</label>
            <div class="controls">
                <asp:TextBox ID="txt_OccupyUpBound" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                    placeholder="請輸入"></asp:TextBox>
                 <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" FilterType="Numbers" 
                    TargetControlID="txt_OccupyUpBound"></cc1:FilteredTextBoxExtender>
            </div>
              <label class="control-label">
                佔有率下限</label>
            <div class="controls">
                <asp:TextBox ID="txt_OccupyLowBound" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                    placeholder="請輸入"></asp:TextBox>
                 <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" FilterType="Numbers" 
                    TargetControlID="txt_OccupyLowBound"></cc1:FilteredTextBoxExtender>
            </div>
        </div>
        
      </div>
        <asp:Button ID="cmd_Save" runat="server" Text="確認" 
            CssClass="btn btn-large btn-primary" onclick="cmd_Save_Click1" />
        <asp:Button ID="cmd_Back" runat="server" Text="取消" CssClass="btn btn-large btn-primary" />
        <asp:Button ID="cmd_SaveAll" runat="server" Visible="false" Text="自動設定所有門檻值" 
            CssClass="btn btn-large btn-primary" OnClick="cmd_SaveAll_Click"  />
    </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="cmd_Back" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="cmd_Save" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    </form>
</body>
</html>
