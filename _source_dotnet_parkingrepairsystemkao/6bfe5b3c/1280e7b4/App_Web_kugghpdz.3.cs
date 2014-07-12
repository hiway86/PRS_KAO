#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\Main.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AB2C94F9A053AA1CE7E8978899A4DBC897EE1C5D"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\Main.aspx.cs"
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


#line default
#line hidden
