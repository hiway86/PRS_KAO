#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\MIS\EquipmentDataList.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EE69DF0062B6F6648A3CB15AA3EDBA5BE7BFF609"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\MIS\EquipmentDataList.aspx.cs"
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

public partial class MIS_EquipmentDataList : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ScriptManager1.IsInAsyncPostBack)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "addSearchIcon();addMapIcon();", true);
            //隱藏照片檔名欄位
            GridViewHidden(this.gv, 10);
            GridViewHidden(this.gv, 13);
            //GridViewHidden(this.gv, 1);
            //GridViewHidden(this.gv, 7);
            //隱藏經度與緯度資料欄位，因搜尋經度與緯度欄位使用like查詢會搜尋無資料。
            GridViewHidden(this.gv, 11);
            GridViewHidden(this.gv, 12);

            InitData();
            SearchData(); 
            GridViewHidden(this.gv, 2);
        }
    }

    protected override void InitData()
    {
        for (int i = 0; i < this.gv.Columns.Count; i++)
        {
            if (this.gv.Columns[i] is BoundField && gv.Columns[i].HeaderStyle.CssClass != "gridviewhiddenrow")
            {
                ListItem item = new ListItem();
                item.Text = gv.Columns[i].HeaderText;
                item.Value = ((BoundField)gv.Columns[i]).DataField;
                this.ddlst_SearchType.Items.Add(item);
            }
        }
    }

    protected void SearchData()
    {
        //string query_company = GetCompanyScope();
        Staff _operator = new Staff("View_DeviceConfig");
        string conditionName = ddlst_SearchType.SelectedValue;
        string condition = "";
        //若查詢日期則把模糊查詢like改為=
        if (conditionName == "ContractStartDate" || conditionName == "ContractEndDate")
        {
            condition = (txt_Query_Reason.Text.Trim().Length > 0 ? " " + conditionName + " = '" + txt_Query_Reason.Text.Trim() + "' " : "");
        }
        else
        {
            condition = (txt_Query_Reason.Text.Trim().Length > 0 ? " " + conditionName + " like '%" + txt_Query_Reason.Text.Trim() + "%' " : "");
        }
        DataSet ds = _operator.Select(condition, "", "View_DeviceConfig");
        Session["DS_MIS"] = ds;
        gv.DataSource = ds;
        gv.DataBind();
        if (ds.Tables[0].Rows.Count == 0)
        {
            ShowMsg2(UpdatePanel1, "查詢無資料");
        }
        //for (int i = 0; i < gv.Rows.Count; i++)
        //{
        //    if (gv.Rows[i].Cells[10].Text.Trim().Equals("True"))
        //        gv.Rows[i].Cells[10].Text = "男";
        //    else
        //        gv.Rows[i].Cells[10].Text = "女";

        //}
    }


    protected void lnkbtn_Search_Click(object sender, EventArgs e)
    {
        SearchData();
    }

    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gv.PageIndex = e.NewPageIndex;
        DataSet ds = (DataSet)Session["DS_MIS"];
        this.gv.DataSource = ds;
        this.gv.DataBind();

    }
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ((Button)e.Row.Cells[0].FindControl("cmd_Edit")).Attributes.Add("onClick", "edit('" + e.Row.Cells[2].Text.Trim() + "');return false;");
            ((Button)e.Row.Cells[15].FindControl("cmd_AddMaterial")).Attributes.Add("onClick", "AddMaterial('" + e.Row.Cells[2].Text.Trim() + "');return false;");
            ((ImageButton)e.Row.Cells[1].FindControl("cmd_Delete")).Attributes.Add("onClick", "del('" + e.Row.Cells[2].Text.Trim() + "');return false;");
            if (e.Row.Cells[13].Text.Length > 6)
            {
                ((HyperLink)e.Row.Cells[13].FindControl("HyperLink1")).Visible = true;
                ((HyperLink)e.Row.Cells[13].FindControl("HyperLink1")).NavigateUrl = ConfigurationManager.AppSettings["imagesUrl"] + e.Row.Cells[13].Text.Trim();
                ((HyperLink)e.Row.Cells[13].FindControl("HyperLink1")).Text = "檢視 " + e.Row.Cells[2].Text.Trim() + " 照片";
            }
            if (e.Row.Cells[2].Text.Length > 0)
            {
                ((HyperLink)e.Row.Cells[3].FindControl("hlk_equipmentid")).NavigateUrl = "Equipment_Show.aspx?EID=" + e.Row.Cells[2].Text;
                ((HyperLink)e.Row.Cells[3].FindControl("hlk_equipmentid")).Text = e.Row.Cells[2].Text;
            }
        } 

    }
    protected void mapView_Click(object sender, EventArgs e)
    {
        Response.Redirect("mapViewer.aspx?type=Device&id=0");
    }
    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "singleMapView") {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gv.Rows[index];
            string id = row.Cells[2].Text;
            Response.Redirect("mapViewer.aspx?type=Device&id=" + id);
        }
    }
    protected void lnkbtn_Report_Click(object sender, EventArgs e)
    {
        //ExportTOExcel();
    }


    //private void ExportTOExcel()
    //{

    //    ExcelReport report = null;
    //    try
    //    {
    //        report = new ExcelReport("MIS/EquipmentData");

    //        DataSet ds = (DataSet)Session["DS_MIS"];

    //        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
    //        {
    //            report.FillData(j + 3, 1, ds.Tables[0].Rows[j]["DeviceID"].ToString(), 1);
    //            report.FillData(j + 3, 2, ds.Tables[0].Rows[j]["DeviceModelName"].ToString(), 1);
    //            report.FillData(j + 3, 3, ds.Tables[0].Rows[j]["RegionName"].ToString(), 1);
    //            report.FillData(j + 3, 4, ds.Tables[0].Rows[j]["SectorName"].ToString(), 1);
    //            report.FillData(j + 3, 5, ds.Tables[0].Rows[j]["TCModel"].ToString(), 1);
    //            report.FillData(j + 3, 6, ds.Tables[0].Rows[j]["ContractName"].ToString(), 1);
    //            report.FillData(j + 3, 7, ds.Tables[0].Rows[j]["DeviceStatus"].ToString(), 1);
    //            report.FillData(j + 3, 8, ds.Tables[0].Rows[j]["DeviceNote"].ToString(), 1);
    //            report.FillData(j + 3, 9, ds.Tables[0].Rows[j]["Longitude"].ToString(), 1);
    //            report.FillData(j + 3, 10, ds.Tables[0].Rows[j]["Latitude"].ToString(), 1);
    //            //report.FillData(j + 1, 2, ds.Tables[0].Rows[j]["DevicePhoto"].ToString(), 1);
    //        }


    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "newprintwindow2", "open_new_window(\"../Temp/" + report.Report() + "\");", true);
    //    }
    //    catch (Exception e)
    //    {
    //        if (report != null)
    //        {
    //            ScriptManager.RegisterStartupScript(this, this.GetType(), "newprintwindow2", "open_new_window(\"../Temp/" + report.Report() + "\");", true);
    //        }

    //    }
    //    finally
    //    {
    //        try
    //        {
    //            report.Close();
    //        }
    //        catch (Exception ex)
    //        {
    //        }
    //    }

    //}
}


#line default
#line hidden
