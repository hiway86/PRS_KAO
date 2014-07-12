using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class MIS_Equipment_Show : PageBase
{
    SQLDB db = new SQLDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ScriptManager1.IsInAsyncPostBack)
        {
            string eid = "";
            if (Request.QueryString["EID"] != null)
            {
                eid = Request.QueryString["EID"];
            }
            InitData();
            //GridViewHidden(gv, 0);  //隱藏事件編號
        }
    }


    protected override void InitData()
    {
        SearchData();
    }

    protected void SearchData()
    {
        //綁定設備資料
        DataSet ds = new DataSet();
        string eid = "";
        if (Request.QueryString["EID"] != null)
            eid = Request.QueryString["EID"];

        if (eid.Length > 0)
            ds = db.Select("Device_ID = '" + eid + "'", "", "View_DeviceConfig");
        else
            ds = db.Select("", "", "View_DeviceConfig");

        gv2.DataSource = ds;
        gv2.DataBind();

        //綁定零件資料
        DataSet ds_material = new DataSet();

        if (eid.Length > 0)
            ds = db.Select("Device_ID = '" + eid + "'", "", "CD_MaterialOfDevice");
        else
            ds = db.Select("", "", "CD_MaterialOfDevice");
        if (ds.Tables[0].Rows.Count > 0)
        {
            lbl_materialTitle.Visible = true;
        }

        gv_MaterialShow.DataSource = ds;
        gv_MaterialShow.DataBind();
        
        //綁定通報資料
        Staff _operator = new Staff("View_ParkingRepairMaintainList");
        ds = _operator.Select("DeviceID = '" + eid + "'", " CaseID desc");
        if (ds.Tables[0].Rows.Count > 0)
        {
            lbl_caseTitle.Visible = true;
        }
        Session["DS_MIS"] = ds;
        gv.DataSource = ds;
        gv.DataBind();
        if (ds.Tables[0].Rows.Count == 0)
        {
            ShowMsg2(UpdatePanel1, "查詢無資料");
        }
    }

    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gv.PageIndex = e.NewPageIndex;
        DataSet ds = (DataSet)Session["DS_MIS"];
        this.gv.DataSource = ds;
        this.gv.DataBind();
    }


}