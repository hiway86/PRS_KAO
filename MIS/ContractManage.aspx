<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ContractManage.aspx.cs" Inherits="MIS_ContractManage" %>
<!--#INCLUDE FILE="../checkpass.inc" -->
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/bootstrap/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../css/manage.css" rel="stylesheet" type="text/css" />
    
    <link href="../css/impromptu.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>

    <title>保固設備管理-合約資料維護</title>

    <script type="text/javascript">

        $(document).ready(function() {
            //To control calendar visible or not
            $('#Calendar_contractStartDate').addClass('hidden');
            $('#Calendar_contractEndDate').addClass('hidden');
            $('#txt_contractStartDate').click(function() {
                $('#Calendar_contractStartDate').removeClass('hidden');
            });
            $('#Calendar_contractStartDate').click(function() {
                $('#Calendar_contractStartDate').addClass('hidden');
            });
            $('#txt_contractEndDate').click(function() {
                $('#Calendar_contractEndDate').removeClass('hidden');
            });
            $('#Calendar_contractEndDate').click(function() {
                $('#Calendar_contractEndDate').addClass('hidden');
            });
            //
            $('#cmd_Save').bind("click", function() { return saveClick(); });
            $('#cmd_Back').bind("click", function() { return backClick(); });
        });

        function saveClick() {
            return true;
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
            location.href = "ContractList.aspx";
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
        <cc1:ToolkitScriptManager ID="ScriptManager1" runat="server" CombineScripts="false"></cc1:ToolkitScriptManager>
    </div>
    <asp:HiddenField ID="hidden_Action" runat="server" />
    <asp:HiddenField ID="hidden_EquipmentKindId" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <div class="container">
        <h3>
            合約種類維護</h3>
        <!--資料分隔請複製我，更改內文即可-->
        <div class="devide-line">
            <p>
                合約資料</p>
            <hr />
        </div>
        <!--end-->
        <div class="control-group">
            <label class="control-label"><b >*</b>
                合約識別碼</label>
            <div class="controls">
                <asp:TextBox ID="txt_contractId" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                    placeholder="請輸入"></asp:TextBox>
            </div>
            <label class="control-label"><b >*</b>
                合約編號</label>
            <div class="controls">
                <asp:TextBox ID="txt_contractNum" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                    placeholder="請輸入"></asp:TextBox>
            </div>
            <label class="control-label"><b >*</b>
                合約名稱</label>
            <div class="controls">
                <asp:TextBox ID="txt_contractName" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                    placeholder="請輸入"></asp:TextBox>
            </div>
            <label class="control-label"><b >*</b>
                合約簡稱</label>
            <div class="controls">
                <asp:TextBox ID="txt_contractShortName" runat="server" AutoCompleteType="Disabled"
                    CssClass="span3" placeholder="請輸入"></asp:TextBox>
            </div>
            <label class="control-label">
                分標名稱</label>
            <div class="controls">
                <asp:TextBox ID="txt_subContractName" runat="server" AutoCompleteType="Disabled"
                    CssClass="span3" placeholder="請輸入"></asp:TextBox>
            </div>
            <label class="control-label"><b >*</b>
                得標廠商</label>
            <div class="controls">
                <asp:DropDownList ID="ddl_company" AppendDataBoundItems="true" runat="server">
                    <asp:ListItem Value="0">==請選擇==</asp:ListItem>
                </asp:DropDownList>
            </div>
            <label class="control-label"><b >*</b>
                保固起始日</label>
            <div class="controls">
                <asp:TextBox ID="txt_contractStartDate" runat="server" Enabled="false" AutoCompleteType="Disabled"
                    CssClass="span3" placeholder="請輸入"></asp:TextBox>
                <asp:Image ID="imgCalander4" runat="server" ImageUrl="../images/calendar.png" />
                <cc1:calendarextender id="txt_Car_Licence_Exp_CalendarExtender1" runat="server" popupbuttonid="imgCalander4"
                    targetcontrolid="txt_contractStartDate" format="yyyy/MM/dd">
                        </cc1:calendarextender>
               
            </div>
            <label class="control-label"><b >*</b>
                保固中止日</label>
            <div class="controls">
                <asp:TextBox ID="txt_contractEndDate" runat="server" Enabled="false" AutoCompleteType="Disabled"
                    CssClass="span3" placeholder="請輸入"></asp:TextBox>
                    <asp:Image ID="imgCalander5" runat="server" ImageUrl="../images/calendar.png" />
                    <cc1:calendarextender id="txt_Car_Licence_Exp_CalendarExtender2" runat="server" popupbuttonid="imgCalander5"
                    targetcontrolid="txt_contractEndDate" format="yyyy/MM/dd">
                        </cc1:calendarextender>
               
            </div>
            <label class="control-label">
                備註</label>
            <div class="controls">
                <asp:TextBox ID="txt_note" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                    placeholder="請輸入"></asp:TextBox>
            </div>
            <%--<label class="control-label">
                顯示與否</label>
            <div class="controls">
                <asp:DropDownList ID="ddl_display" runat="server">
                    <asp:ListItem Selected="True" Value="True">是</asp:ListItem>
                    <asp:ListItem Value="False">否</asp:ListItem>
                </asp:DropDownList>
            </div>--%>
        </div>
    </div>
    <asp:Button ID="cmd_Save" runat="server" Text="確認" CssClass="btn btn-large btn-primary"
        OnClick="cmd_Save_Click1" />
    <asp:Button ID="cmd_Back" runat="server" Text="取消" CssClass="btn btn-large btn-primary" />
    </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="cmd_Back" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="cmd_Save" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    </form>
</body>
</html>
