using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Main : System.Web.UI.Page
{
    public string systemGroup = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["sg"] != null)
        {
            systemGroup = Request.QueryString["sg"];
        }

    }
}
