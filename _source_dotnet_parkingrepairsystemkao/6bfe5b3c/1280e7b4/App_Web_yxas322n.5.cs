#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\Report\ReportReturnList.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "05D224F657A4BA70FB1D1B859D7BF51FD6E8D37D"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\Report\ReportReturnList.aspx.cs"
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

public partial class Report_ReportReturnList : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ScriptManager1.IsInAsyncPostBack)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "addSearchIcon();", true);
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
        //string query_company = GetCompanyScope();
        Staff _operator = new Staff("View_ParkingRepairMaintainList");
        string conditionName = ddlst_SearchType.SelectedValue;
        string condition = "";
        if (txt_Query_Reason.Text.Trim().Length > 0)
        {
            condition = conditionName + " like '%" + txt_Query_Reason.Text.Trim() + "%' and Status != '結案' ";
        }
        else
        {
            condition = "Status != '結案'";
        }
        //string condition = (txt_Query_Reason.Text.Trim().Length > 0 ? " " + conditionName + " like '%" + txt_Query_Reason.Text.Trim() + "%' " : "");
        //condition += " Status != '結案'";
        string sort = "NotifyDate DESC";
        //condition += query_company;
        DataSet ds = _operator.Select(condition, sort);
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
         //案件底色將採用淺綠、淺黃、淺紅三種方式表示，維修剩餘天數大於兩天為淺綠，介於兩天跟一天之間為淺黃，小於一天為淺紅
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.CssClass = "info";
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (!e.Row.Cells[9].Text.Equals("&nbsp;"))
            {
                DateTime dt = Convert.ToDateTime(e.Row.Cells[9].Text);
                TimeSpan end = new TimeSpan(dt.Ticks - DateTime.Now.Ticks);
                if (end.TotalDays > 2)
                {
                    e.Row.CssClass = "success";
                    //e.Row.Cells[9].BackColor = System.Drawing.Color.SpringGreen;
                }
                else if (end.TotalDays <= 2 && end.TotalDays > 1)
                {
                    e.Row.CssClass = "warning";
                }
                else
                    e.Row.CssClass = "error";
            }
            ((Button)e.Row.Cells[0].FindControl("cmd_Edit")).Attributes.Add("onClick", "edit('" + e.Row.Cells[1].Text.Trim() + "');return false;");
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
    //        report = new ExcelReport("Report/RepairMaintainList");

    //        DataSet ds = (DataSet)Session["DS_MIS"];

    //        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
    //        {
    //            report.FillData(j + 3, 1, ds.Tables[0].Rows[j]["CaseID"].ToString(), 1);
    //            report.FillData(j + 3, 2, ds.Tables[0].Rows[j]["DeviceID"].ToString(), 1);
    //            report.FillData(j + 3, 3, ds.Tables[0].Rows[j]["DeviceModel"].ToString(), 1);
    //            report.FillData(j + 3, 4, ds.Tables[0].Rows[j]["FaultDescribe"].ToString(), 1);
    //            report.FillData(j + 3, 5, ds.Tables[0].Rows[j]["RegionName"].ToString(), 1);
    //            report.FillData(j + 3, 6, ds.Tables[0].Rows[j]["SectorName"].ToString(), 1);
    //            report.FillData(j + 3, 7, ds.Tables[0].Rows[j]["WarrantyCompany"].ToString(), 1);
    //            report.FillData(j + 3, 8, ds.Tables[0].Rows[j]["NotifyDate"].ToString(), 1);
    //            report.FillData(j + 3, 9, ds.Tables[0].Rows[j]["RepairDeadline"].ToString(), 1);

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
