<%
 if(Session["LOGIN"]=="OK")
    {
        //登入成功，取得session
            
    }
    else
    {
        //沒有登入或是沒取得session
		Response.Write("<script>");
		Response.Write("window.alert('操作逾時，請重新登入');");
		Response.Write("window.open('../Index.aspx','_top')");
		Response.Write("</script>"); 
       // Response.Redirect("../Login.aspx");
    }
%>