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

public partial class Inventory_MaterialType_QD : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ScriptManager1.IsInAsyncPostBack)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "addSearchIcon();", true);
            Session["DS_MIS"] = null;
            //隱藏Staff_ID
            InitData();
            SearchData();
        }
    }

    //將gridview header塞進dropbox
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
        Staff _operator = new Staff("ICS_Material_Type");
        string conditionName = ddlst_SearchType.SelectedValue;
        string condition = (txt_Query_Reason.Text.Trim().Length > 0 ? " " + conditionName + " like '%" + txt_Query_Reason.Text.Trim().Replace("'","") + "%'  " : "");
        //condition += query_company;
        DataSet ds = _operator.Select(condition);
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
            ((Button)e.Row.Cells[0].FindControl("cmd_Edit")).Attributes.Add("onClick", "edit('" + e.Row.Cells[1].Text.Trim() + "');return false;");
            //((ImageButton)e.Row.Cells[1].FindControl("cmd_Delete")).Attributes.Add("onClick", "del('" + e.Row.Cells[1].Text.Trim() + "');return false;");
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
    //        report = new ExcelReport("MIS/Region");

    //        DataSet ds = (DataSet)Session["DS_MIS"];

    //        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
    //        {
    //            report.FillData(j + 3, 1, ds.Tables[0].Rows[j]["RegionName"].ToString(), 1);
    //            report.FillData(j + 3, 2, ds.Tables[0].Rows[j]["RegionCode"].ToString(), 1);
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
    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmd_delete")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gv.Rows[index];
            string id = row.Cells[1].Text;
            string delete = " delete ICS_Material_Type where materialTypeID = '" + id + "'";
            SQLDB _operator = new SQLDB();
            if (_operator.ExecuteStatement(delete))
            {
                ShowMsg(UpdatePanel1, "刪除成功");
                Application["App_Invetory_MaterialType"] = CommonLib.GetMaterialType();
                SearchData();
            }
        }
    }
}