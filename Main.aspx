<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" %>

<!--#INCLUDE FILE="checkpass.inc" -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>維運管理資訊系統</title>
    <link href="css/bootstrap/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap/bootstrap.css" rel="stylesheet" type="text/css" />
</head>
<frameset rows="150,*" cols="*" border="0">
    <frame src="banner.aspx" name="banner" id="banner" scrolling="No" />
    <frameset id="frameSet" cols="190,*" frameborder="no" border="0" framespacing="0"
        class="row">
        <frame src="XPMenu.aspx?sg=<%= systemGroup %>" name="leftFrame" id="leftFrame" scrolling="No"
            class="span3" />
        <frame src="Welcome.htm" name="mainFrame" id="mainFrame" title="mainFrame"  />
    </frameset>
</frameset>
<noframes>
    <body>
        您的瀏覽器不支援框架格式</body>
</noframes>

<script src="javascript/jquery-1.3.2.js" type="text/javascript"></script>

</html>
