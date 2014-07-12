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
