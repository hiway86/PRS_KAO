<%@ Control Language="C#" AutoEventWireup="true" CodeFile="XPMenuUC.ascx.cs" Inherits="XPMenuUC" %>
<%--<link rel="stylesheet" type="text/css" href="css/menu.css">--%>
<%--<link href="./css/bootstrap/bootstrap.css" rel="stylesheet">--%>
<%--<link href="./css/bootstrap/bootstrap-responsive.css" rel="stylesheet">--%>
<link href="css/menu_new.css" rel="stylesheet" />	
	
	<!-- jQuery -->
	<script src="http://thecodeplayer.com/uploads/js/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script type="text/javascript">
/*jQuery time*/
$(document).ready(function(){
	$("#accordian h3").click(function(){
		//slide up all the link lists
		$("#accordian ul ul").slideUp();
		//slide down the link list below the h3 clicked - only if its closed
		if(!$(this).next().is(":visible"))
		{
			$(this).next().slideDown();
		}
	})
   
	$("#accordian ul ul li").click(function () {
	    $(".addClickTag").removeClass("addClickTag");
        $(this).addClass("addClickTag");
	})
})
</script>


