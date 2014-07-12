#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\Systemmaster.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0AD2F3C2F35BBC8C69ED4F4A8A7CD7DAF96096C9"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\Systemmaster.aspx.cs"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
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

#line default
#line hidden
