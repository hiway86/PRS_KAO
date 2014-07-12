<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompanyManage.aspx.cs" Inherits="MIS_CompanyManage" %>
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
            location.href = "CompanyList.aspx";
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
    <asp:HiddenField ID="hidden_companyId" runat="server" />
    <div class="container">
        <h3>
            廠商資料維護</h3>
        <div class="control-group ">
            <label class="control-label">
                廠商編號</label>
            <div class="controls">
                <asp:TextBox ID="txt_companyId" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                    placeholder="請輸入"></asp:TextBox>
            </div>
            <label class="control-label"><b >*</b>
                廠商名稱</label>
            <div class="controls">
                <asp:TextBox ID="txt_companyName" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                    placeholder="請輸入"></asp:TextBox>
            </div>
            <label class="control-label">
                聯絡人</label>
            <div class="controls">
                <asp:TextBox ID="txt_contact" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                    placeholder="請輸入"></asp:TextBox>
            </div>
            <label class="control-label">
                聯絡人電話</label>
            <div class="controls">
                <asp:TextBox ID="txt_contactPhone" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                    placeholder="請輸入"></asp:TextBox>
            </div>
            <label class="control-label">
                聯絡人分機</label>
            <div class="controls">
                <asp:TextBox ID="txt_contactPhoneExet" runat="server" AutoCompleteType="Disabled"
                    CssClass="span3" placeholder="請輸入"></asp:TextBox>
            </div>
            <label class="control-label">
                聯絡人手機</label>
            <div class="controls">
                <asp:TextBox ID="txt_contactMobile" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                    placeholder="請輸入"></asp:TextBox>
            </div>
            <label class="control-label">
                聯絡人2</label>
            <div class="controls">
                <asp:TextBox ID="txt_contact2" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                    placeholder="請輸入"></asp:TextBox>
            </div>
            <label class="control-label">
                聯絡人2電話</label>
            <div class="controls">
                <asp:TextBox ID="txt_contact2Phone" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                    placeholder="請輸入"></asp:TextBox>
            </div>
            <label class="control-label">
                聯絡人2分機</label>
            <div class="controls">
                <asp:TextBox ID="txt_contact2PhoneExet" runat="server" AutoCompleteType="Disabled"
                    CssClass="span3" placeholder="請輸入"></asp:TextBox>
            </div>
            <label class="control-label">
                聯絡人2手機</label>
            <div class="controls">
                <asp:TextBox ID="txt_contact2Mobile" runat="server" AutoCompleteType="Disabled"
                    CssClass="span3" placeholder="請輸入"></asp:TextBox>
            </div>
            <label class="control-label">
                傳真號碼</label>
            <div class="controls">
                <asp:TextBox ID="txt_fax" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                    placeholder="請輸入"></asp:TextBox>
            </div>
            <label class="control-label"><b >*</b>
                信箱</label>
            <div class="controls">
                <asp:TextBox ID="txt_email" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                    placeholder="請輸入"></asp:TextBox>
            </div>
            <label class="control-label">
                地址</label>
            <div class="controls">
                <asp:TextBox ID="txt_address" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                    placeholder="請輸入"></asp:TextBox>
            </div>
            <label runat="server" visible ="false"  class="control-label">
                公司群組</label>
            <div class="controls">
                <asp:DropDownList Visible ="false" ID="cbo_companyGoup" runat="server" AppendDataBoundItems="True">
                    <asp:ListItem Value="null">--請選擇--</asp:ListItem>
                </asp:DropDownList>
            </div>
            <label class="control-label">
                備註</label>
            <div class="controls">
                <asp:TextBox ID="txt_note" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                    placeholder="請輸入"></asp:TextBox>
            </div>
        </div>
        <asp:Button ID="cmd_Save" runat="server" Text="確認" 
            CssClass="btn btn-large btn-primary" onclick="cmd_Save_Click1" />
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
