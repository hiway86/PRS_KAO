#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\Statistics\StudyFileUpload_A.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BC619C101CAC63DA73EBEB78D14C7F3C2A1B0887"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\Statistics\StudyFileUpload_A.aspx.cs"
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Statistics_StudyFileUpload_A : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void File_Upload(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
    {

        string filename = e.FileName;
        string strDestPath = Server.MapPath("../Temp/");
        //將資料存到網站
        AjaxFileUpload1.SaveAs(@strDestPath + filename);
        //將資料存到DB
        SQLDB _operator = new SQLDB();
        DataSet ds = _operator.Select("1=0", "", "StudyFileUpload");
        DataRow dr = ds.Tables[0].NewRow();
        dr["FileName"] =  filename;
        dr["UpdateTime"] = DateTime.Now;
        ds.Tables[0].Rows.Add(dr);
        DataSet DSChange = ds.GetChanges();
        _operator.Insert(DSChange);
    }
    protected void cmd_Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("StudyFileUpload_Q.aspx");
    }
}

#line default
#line hidden
