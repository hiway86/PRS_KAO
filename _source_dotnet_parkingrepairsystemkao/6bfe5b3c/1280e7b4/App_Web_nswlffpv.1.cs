#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\MIS\DeviceKindPhoto.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5153DF12EBD5CE483EEFFC037668D83F4EDD3DC3"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\MIS\DeviceKindPhoto.aspx.cs"
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MIS_DeviceKindPhoto : System.Web.UI.Page
{
    protected string iconPath = "../img/mapicons/";
    protected void Page_Load(object sender, EventArgs e)
    {
        //hidd_devicekindid.Value = Request.QueryString["id"].Trim();
    }
    protected void File_Upload(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
    {
        string devicekindid = Session["DeviceKindid"].ToString();
        //string devicekindid = "13";
        AjaxFileUpload1.SaveAs(Server.MapPath(iconPath + devicekindid + ".gif"));

    }
       
    
    protected void cmd_Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("KindsOfEquipmentList.aspx");
    }
}

#line default
#line hidden
