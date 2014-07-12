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
using System.Text;
using NPOI.HSSF.UserModel;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.SS.Util;

public partial class MIS_DeviceCheck_Q : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ScriptManager1.IsInAsyncPostBack)
        {
            Session["DS_MIS"] = null;
            Session["MIS_DeviceHeckDate"] = null;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "addSearchIcon();addCheckIcon();", true);
            //隱藏照片檔名欄位
            GridViewHidden(this.gv, 2);
            InitData();
            SearchData();
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
        SQLDB db = new SQLDB();
        StringBuilder selectquery = new StringBuilder("select * " +
                             " from View_DeviceConfig v left join ( " +
                             " select Device_ID,MAX(ChecKDate) ChecKDate " +
                             " FROM CD_DeviceCheckDate " +
                            " where checkdate < GETDATE()  " +
                            " group by Device_ID  " +
                            " ) t on v.Device_ID = t.device_ID ");

        string conditionName = ddlst_SearchType.SelectedValue;
        StringBuilder condition = new StringBuilder();
        //若查詢日期則把模糊查詢like改為=
        if (conditionName == "ContractStartDate" || conditionName == "ContractEndDate" || conditionName == "CheckDate")
        {
            if (txt_StartDate.Text.Length > 0 && txt_EndDate.Text.Length > 0)
            {
                condition.Append(conditionName + ">  '" + txt_StartDate.Text + "' AND " + conditionName + "< '" + txt_EndDate.Text + "'");
            }
            else
            {
                if (txt_StartDate.Text.Length > 0)
                {
                    condition.Append(conditionName + "> '" + txt_StartDate.Text + "'");

                }
                if (txt_EndDate.Text.Length > 0)
                {
                    condition.Append(conditionName + "< '" + txt_EndDate.Text + "'");
                }
            }
        }
        else
        {
            condition.Append(txt_Query_Reason.Text.Trim().Length > 0 ? " " + conditionName + " like '%" + txt_Query_Reason.Text.Trim() + "%' " : "");
        }
        if (condition.Length > 0)
        {
            selectquery.Append(" WHERE " + condition);
        }
        DataSet ds = db.SelectQuery(selectquery.ToString());
        Session["DS_MIS"] = ds;
        gv.DataSource = ds;
        gv.DataBind();
        if (ds.Tables[0].Rows.Count == 0)
        {
            ShowMsg2(UpdatePanel1, "查詢無資料");
        }

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
            //((Button)e.Row.Cells[0].FindControl("cmd_Edit")).Attributes.Add("onClick", "edit('" + e.Row.Cells[2].Text.Trim() + "');return false;");
            //((Button)e.Row.Cells[15].FindControl("cmd_AddMaterial")).Attributes.Add("onClick", "AddMaterial('" + e.Row.Cells[2].Text.Trim() + "');return false;");
            //((ImageButton)e.Row.Cells[1].FindControl("cmd_Delete")).Attributes.Add("onClick", "del('" + e.Row.Cells[2].Text.Trim() + "');return false;");
            //if (e.Row.Cells[13].Text.Length > 6)
            //{
            //    ((HyperLink)e.Row.Cells[13].FindControl("HyperLink1")).Visible = true;
            //    ((HyperLink)e.Row.Cells[13].FindControl("HyperLink1")).NavigateUrl = ConfigurationManager.AppSettings["imagesUrl"] + e.Row.Cells[13].Text.Trim();
            //    ((HyperLink)e.Row.Cells[13].FindControl("HyperLink1")).Text = "檢視 " + e.Row.Cells[2].Text.Trim() + " 照片";
            //}
            Button editButton = (Button)e.Row.Cells[1].Controls[1];
            editButton.CommandArgument = e.Row.RowIndex.ToString();

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
        SQLDB db = new SQLDB();
        if (e.CommandName == "singleMapView")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gv.Rows[index];
            string id = row.Cells[2].Text;
            Response.Redirect("mapViewer.aspx?type=Device&id=" + id);
        }

        if (e.CommandName == "Search")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            DataSet DS = db.Select("device_id = '" + gv.Rows[index].Cells[2].Text.Replace("&nbsp;", "") + "'", " CheckDate desc", "CD_DeviceCheckDate");
            //hid_deviceid.Value = gv2.Rows[index].Cells[0].Text.Replace("&nbsp;", "");
            if (DS.Tables[0].Rows.Count > 0)
            {
                Session["MIS_DeviceHeckDate"] = DS;
                gv3.DataSource = DS;
                gv3.DataBind();
            }
            else
            {
                gv3.DataSource = null;
                gv3.DataBind();
                ShowMsg2(UpdatePanel2, "無資料");
            }
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


    /// <summary>
    /// 重新計算檢修周期：以設備合約起始日期開始累加檢修週期直到合約截止
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtn_Add_Click(object sender, EventArgs e)
    {
        SQLDB db = new SQLDB();
        //先將舊有檢修日期刪除
        string deleteCheckDate = "Delete from CD_DeviceCheckDate where 1=1";
        db.ExecuteStatement(deleteCheckDate);
        
        string queryDevice = "SELECT [Device_ID],[ContractStartDate],[ContractEndDate],[Cycle] FROM [View_DeviceConfig] where [ContractStartDate] is not null and [ContractEndDate] is not null";
        DataSet ds = db.SelectQuery(queryDevice);
        DataSet ds_checkdate = db.Select("1 = 0", "", "CD_DeviceCheckDate");
        for (int i = 0; i < ds.Tables[0].Rows.Count ; i++)
        {
            string device = ds.Tables[0].Rows[i]["Device_ID"].ToString();
            DateTime start = Convert.ToDateTime(ds.Tables[0].Rows[i]["ContractStartDate"].ToString());
            DateTime end = Convert.ToDateTime(ds.Tables[0].Rows[i]["ContractEndDate"].ToString());
            TimeSpan cycle = TimeSpan.FromDays( Convert.ToDouble( ds.Tables[0].Rows[i]["cycle"].ToString()));
            while (start < end)
            {
                start += cycle;
                if (start < end)
                {
                    DataRow dr = ds_checkdate.Tables[0].NewRow();
                    dr["Device_ID"] = ds.Tables[0].Rows[i]["Device_ID"].ToString();
                    dr["CheckDate"] = start.ToString("yyyy/MM/dd HH:mm:ss");
                    ds_checkdate.Tables[0].Rows.Add(dr);
                }
            }
            
        }

        //開始將檢修日期塞到資料庫
        DataSet DSChange = ds_checkdate.GetChanges();
        if (db.Insert(DSChange))
        {
            ShowMsg(UpdatePanel1, "資料計算成功");
        }
    }
    protected void gv3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gv3.PageIndex = e.NewPageIndex;
        DataSet ds = (DataSet)Session["MIS_DeviceHeckDate"];
        this.gv3.DataSource = ds;
        this.gv3.DataBind();
    }
    protected void ddlst_SearchType_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (ddlst_SearchType.SelectedValue)
        {
            case "ContractStartDate":
                //隱藏輸入txtbox
                txt_Query_Reason.Visible = false;
                //隱藏起始日期欄位
                txt_StartDate.Visible = true;
                txt_EndDate.Visible = true;
                lbl_startToEnd.Visible = true;
                imgCalander4.Visible = true;
                imgCalander5.Visible = true;
                break;
            case "ContractEndDate":
                //隱藏輸入txtbox
                txt_Query_Reason.Visible = false;
                //隱藏起始日期欄位
                txt_StartDate.Visible = true;
                txt_EndDate.Visible = true;
                lbl_startToEnd.Visible = true;
                imgCalander4.Visible = true;
                imgCalander5.Visible = true;
                break;
            case "CheckDate":
                //隱藏輸入txtbox
                txt_Query_Reason.Visible = false;
                //隱藏起始日期欄位
                txt_StartDate.Visible = true;
                txt_EndDate.Visible = true;
                lbl_startToEnd.Visible = true;
                imgCalander4.Visible = true;
                imgCalander5.Visible = true;
                break;
            default:
                //秀輸入txtbox
                txt_Query_Reason.Visible = true;
                //隱藏起始日期欄位
                txt_StartDate.Visible = false;
                txt_EndDate.Visible = false;
                lbl_startToEnd.Visible = false;
                imgCalander4.Visible = false;
                imgCalander5.Visible = false;
                break;
        }
    }
}
