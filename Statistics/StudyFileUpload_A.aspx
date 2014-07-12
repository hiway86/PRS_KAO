﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudyFileUpload_A.aspx.cs" Inherits="Statistics_StudyFileUpload_A" %>
<!--#INCLUDE FILE="../checkpass.inc" -->
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/bootstrap/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../css/manage.css" rel="stylesheet" type="text/css" />
    <link href="../css/impromptu.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>
    <title>統計與查詢-檢修技術查詢</title>

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
</head>
<body>
    <form id="form1" runat="server" class="form-signin form-horizontal-50">
        <div class="container">
        <h3>檢修技術資料上傳</h3>
        
        <!--資料分隔請複製我，更改內文即可-->
        <div class="devide-line">
            <hr />
        </div>
        <!--end-->        
         <div class="control-group">
         <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>
         <ajaxToolkit:AjaxFileUpload ID="AjaxFileUpload1" runat="server" AllowedFileTypes="jpg,jpeg,png,gif,pdf,doc,docx"
                            MaximumNumberOfFiles="10" OnUploadComplete="File_Upload"
                            Width="500px" />
        </div>
        <asp:Button ID="cmd_Back" runat="server" Text="回到上一頁" CssClass="btn btn-large btn-primary" OnClick="cmd_Back_Click" />
      </div>
       
    
    </div>
    </form>
</body>
</html>
