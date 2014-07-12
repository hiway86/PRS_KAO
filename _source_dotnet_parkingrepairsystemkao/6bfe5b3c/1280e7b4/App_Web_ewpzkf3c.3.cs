#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\MainMenu.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "712E4A0BF8F46B2432EDF1FD4319F7854BEDAB19"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\MainMenu.aspx.cs"
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class MainMenu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)Session["LoginAuthority"];
        if (dt != null)
        {
            if (dt.Select("System_Folder_Name IN ('Report')").Length == 0)
            {
                Panel_Report.Visible = false;
            }

            if (dt.Select("System_Folder_Name IN ('MIS')").Length == 0)
            {
                Panel_MIS.Visible = false;
            }

            if (dt.Select("System_Folder_Name IN ('Statistics')").Length == 0)
            {
                Panel_Statistics.Visible = false;
            }

            if (dt.Select("System_Folder_Name IN ('System')").Length == 0)
            {
                Panel_System.Visible = false;
            }

            if (dt.Select("System_Folder_Name IN ('Inventory')").Length == 0)
            {
                Panel_System.Visible = false;
            }

        }
    }
  
}


#line default
#line hidden
