using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Configuration;

public partial class MIS_mapViewer : PageBase
{
    protected string jsonString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitData();
        }    
        
    }

    protected override void InitData() {

       

        imagePath.Value = ConfigurationManager.AppSettings["imagesUrl"];

        SQLDB sectorDB = new SQLDB("View_AllLocation");
        DataSet sectorDS = sectorDB.Select();
        DataTable sectorDT = sectorDS.Tables[0];
        ListItem defaultItem = new ListItem();
        defaultItem.Text = "無";
        defaultItem.Value = "null";
        DropDownList1.Items.Add(defaultItem);
        foreach(DataRow sectorData in sectorDT.Rows){
            ListItem sector = new ListItem();
            sector.Text = sectorData["Location"].ToString();
            sector.Value = sectorData["Location"].ToString();
            DropDownList1.Items.Add(sector);
        }


        if (Request.QueryString["type"].Trim() != null && Request.QueryString["id"].Trim() != null)
        {

            dataType.Value = Request.QueryString["type"].Trim();
            string id = Request.QueryString["id"].Trim();
            string table;
            SQLDB db;
            DataSet ds;
            DataTable dt;
            if (dataType.Value.Equals("Device"))
            {
                //設定修復期限是否要顯示
                TextBox1.Visible = false;
                TextBox2.Visible = false;
                Button1.Visible = false;
                lbl_repairend.Visible = false;
                lbl2.Visible = false;
                TextBox1.Enabled = false;
                TextBox2.Enabled = false;
                Image1.Visible = false;
                Image2.Visible = false;
                table = "View_ParkingDeviceOnMap";
                db = new SQLDB(table);
                if (id.Equals("0"))
                {
                    ds = db.Select();
                    if (ds.Tables.Count == 1)
                    {
                        dt = ds.Tables[0];
                        JSONWebService jsonString = new JSONWebService();
                        jsonData.Value = jsonString.GetJson(dt);
                    }
                    else
                    {
                        jsonData.Value = "null";
                    }
                }
                else
                {
                    ds = db.Select("Device_ID='" + id + "'");
                    if (ds.Tables.Count == 1)
                    {
                        dt = ds.Tables[0];
                        JSONWebService jsonString = new JSONWebService();
                        jsonData.Value = jsonString.GetJson(dt);
                    }
                    else
                    {
                        jsonData.Value = "null";
                    }
                }
            }
            else if (dataType.Value.Equals("Case"))
            {
                Button2.Visible = false;
                table = "View_ParkingCaseOnMap";
                db = new SQLDB(table);
                if (id.Equals("0"))
                {
                    ds = db.Select("status = '維修中'");
                    dt = ds.Tables[0];
                    JSONWebService jsonString = new JSONWebService();
                    jsonData.Value = jsonString.GetJson(dt);
                }
                else
                {
                    ds = db.Select("CaseID='" + id + "'");
                    dt = ds.Tables[0];
                    JSONWebService jsonString = new JSONWebService();
                    jsonData.Value = jsonString.GetJson(dt);
                }
            }
        }
        
    }

   
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        dataType.Value = Request.QueryString["type"].Trim();
        string table;
        SQLDB db;
        DataSet ds;
        DataTable dt;
        string sqlStr = "";
        if (dataType.Value.Equals("Device"))
        {
            table = "View_ParkingDeviceOnMap";

            if (DropDownList1.SelectedValue != "null")
                sqlStr += "Location LIKE '%%" + DropDownList1.SelectedValue + "%%' ";
   
            db = new SQLDB(table);
            ds = db.Select(sqlStr);
            if (ds.Tables.Count == 1)
            {
                dt = ds.Tables[0];
                JSONWebService jsonString = new JSONWebService();
                jsonData.Value = jsonString.GetJson(dt);
            }
            else
            {
                jsonData.Value = "null";
            }

        }
        else if (dataType.Value.Equals("Case"))
        {
            table = "View_ParkingCaseOnMap";

            if (DropDownList1.SelectedValue != "null")
                sqlStr += "Location LIKE '%%" + DropDownList1.SelectedValue + "%%' ";
            if (TextBox1.Text.Length != 0)
            {
                if (sqlStr.Length != 0)
                    sqlStr += "AND ";
                sqlStr += "RepairDeadline>'" + TextBox1.Text + "' ";
            }
            if (TextBox1.Text.Length != 0)
            {
                if (sqlStr.Length != 0)
                    sqlStr += "AND ";
                sqlStr += "RepairDeadline<'" + TextBox2.Text + "' ";
            }
            db = new SQLDB(table);
            ds = db.Select(sqlStr);
            if (ds.Tables.Count == 1)
            {
                dt = ds.Tables[0];
                JSONWebService jsonString = new JSONWebService();
                jsonData.Value = jsonString.GetJson(dt);
            }
            else
            {
                jsonData.Value = "null";
            }
        }
        
    }
}
