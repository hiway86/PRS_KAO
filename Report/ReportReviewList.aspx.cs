using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Report_ReportReviewList : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ScriptManager1.IsInAsyncPostBack)
        {
            Session["DS_Material"] = null;
            Session["DS_MIS"] = null;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "addSearchIcon();", true);
            GridViewHidden(gv, 0);
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
        StringBuilder condition = new StringBuilder();
        if (conditionName.Equals("NotifyDate") || conditionName.Equals("RepairDeadline") || conditionName.Equals("RepairDate"))
        {
            if (txt_StartDate.Text.Length > 0 && txt_EndDate.Text.Length > 0)
            {
                condition.Append(conditionName + ">  '" + txt_StartDate.Text + "' AND " + conditionName + "< '" + txt_EndDate.Text + "' AND");
            }
            else
            {
                if (txt_StartDate.Text.Length > 0)
                {
                    condition.Append(conditionName + "> '" + txt_StartDate.Text + "' AND");

                }
                if (txt_EndDate.Text.Length > 0)
                {
                    condition.Append(conditionName + "< '" + txt_EndDate.Text + "' AND");
                }
            }
        }
        else
        {
            condition.Append(txt_Query_Reason.Text.Trim().Length > 0 ? " " + conditionName + " like '%" + txt_Query_Reason.Text.Trim() + "%' AND " : "");
        }

        condition.Append(" Status = '結案'");
        //condition += query_company;
        DataSet ds = _operator.Select(condition.ToString(), "NotifyDate DESC");
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
            e.Row.Cells[2].Text = "<a href=\"../MIS/Equipment_Show.aspx?EID="+ e.Row.Cells[2].Text+"\" target=\"_blank\">" + e.Row.Cells[2].Text + "</a>";
        }

    }
    protected void mapView_Click(object sender, EventArgs e)
    {
        Response.Redirect("../MIS/mapViewer.aspx?type=Case&id=0");
    }
    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "singleMapView")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gv.Rows[index];
            string id = row.Cells[1].Text;
            Response.Redirect("../MIS/mapViewer.aspx?type=Case&id=" + id);
        }
        //使用零件查詢
        if (e.CommandName == "cmd_materialQuery")
        {
            gv2.DataSource = null;
            gv2.DataBind();
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gv.Rows[index];
            string caseid = row.Cells[1].Text;
            
            SQLDB _operator = new SQLDB();
            DataSet ds = _operator.Select("caseid = '" + caseid + "'", "", "ICS_MaterialRepaired");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["DS_Material"] = ds;
                gv2.DataSource = ds;
                gv2.DataBind();
            }
            else
            {
                ShowMsg(UpdatePanel1, "無資料");
            }

        }
    }
    protected void lnkbtn_Report_Click(object sender, EventArgs e)
    {
        //ExportTOExcel();
    }

    protected void gv2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gv2.PageIndex = e.NewPageIndex;
        DataSet ds = (DataSet)Session["DS_Material"];
        this.gv2.DataSource = ds;
        this.gv2.DataBind();
    }
}
