using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Inventorymaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LOGIN"] != null)
        {
            if (Session["LOGIN"].ToString() != "OK")
            {
                Response.Redirect("Index.aspx");
            }
            else
            {
                string LOGINID = Session["UserID"].ToString();
                Label1.Text = LOGINID.ToString();
            }
        }
        else
        {
            Response.Redirect("Index.aspx");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("Index.aspx");
    }
}