﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MaterialType_AM.aspx.cs" Inherits="Inventory_MaterialType_AM" %>
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

    <title>保固設備管理-耗材種類編輯</title>

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
            location.href = "MaterialType_QD.aspx";
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
    <form id="form1" runat="server"  class="form-signin form-horizontal-50">
    <div>
        <cc1:ToolkitScriptManager ID="ScriptManager1" runat="server" CombineScripts="false"></cc1:ToolkitScriptManager>
    </div>
    <asp:HiddenField ID="hidden_Action" runat="server" />
    <asp:HiddenField ID="hidden_regionId" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <div class="container">
        <h3>耗材種類資料維護</h3>
        
        <!--資料分隔請複製我，更改內文即可-->
        <div class="devide-line">
            <p>耗材種類資料</p>
            <hr />
        </div>
        <!--end-->        
         <div class="control-group">
         <label class="control-label">
                耗材編碼</label>
            <div class="controls">
                <asp:TextBox ID="txt_materialTypeID" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                    placeholder="請輸入"></asp:TextBox>
           </div>       
            <label class="control-label"><b >*</b>
                耗材名稱</label>
            <div class="controls">
                <asp:TextBox ID="txt_materialTypeName" runat="server" AutoCompleteType="Disabled" CssClass="span3"
                    placeholder="請輸入"></asp:TextBox>
            </div>
        </div>
        
      </div>
        <asp:Button ID="cmd_Save" runat="server" Text="確認" 
            CssClass="btn btn-large btn-primary" onclick="cmd_Save_Click1" />
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
