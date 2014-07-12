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


public partial class InventoryAQM : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ScriptManager1.IsInAsyncPostBack)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "addSearchIcon();", true);
            //隱藏顯示欄位
            GridViewHidden(this.gv, 3);
            GridViewHidden(this.gv, 4);
            GridViewHidden(this.gv, 5);
            GridViewHidden(this.gv, 7);
            GridViewHidden(this.gv, 9);
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
        //this.ddlst_SearchType.Items.Add(new ListItem("11", "台北市"));
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gv.EditIndex = e.NewEditIndex;

        InitData();
        SearchData();
    }

    protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
    {
        gv.EditIndex = -1;
        InitData();
        SearchData();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox my_MaterialName, my_PurchaseUnit, my_ConsumeUnit, my_ConversionFactor, my_MaterialSafeQuantity, my_MaterialTypeID, my_MaterialUnit, my_Active;

        String my_NO = gv.DataKeys[e.RowIndex].Value.ToString();
        my_MaterialName = (TextBox)gv.Rows[e.RowIndex].Cells[2].Controls[0];
        my_PurchaseUnit = (TextBox)gv.Rows[e.RowIndex].Cells[3].Controls[0];
        my_ConsumeUnit = (TextBox)gv.Rows[e.RowIndex].Cells[4].Controls[0];
        my_ConversionFactor = (TextBox)gv.Rows[e.RowIndex].Cells[5].Controls[0];
        my_MaterialSafeQuantity = (TextBox)gv.Rows[e.RowIndex].Cells[6].Controls[0];
        my_MaterialTypeID = (TextBox)gv.Rows[e.RowIndex].Cells[7].Controls[0];
        my_MaterialUnit = (TextBox)gv.Rows[e.RowIndex].Cells[8].Controls[0];
        my_Active = (TextBox)gv.Rows[e.RowIndex].Cells[9].Controls[0];

        //檢查更新是否成功
        if (UpdateICS_Material(my_NO, my_MaterialName, my_PurchaseUnit, my_ConsumeUnit, my_ConversionFactor, my_MaterialSafeQuantity, my_MaterialTypeID, my_MaterialUnit, my_Active))
        {
            ShowMsg2(UpdatePanel1, "更新成功");
        }
        else 
        {
            ShowMsg2(UpdatePanel1, "更新失敗");
        }

        gv.EditIndex = -1;
        InitData();
        SearchData();
    }

    private bool UpdateICS_Material(String my_NO, TextBox my_MaterialName, TextBox my_PurchaseUnit, TextBox my_ConsumeUnit, TextBox my_ConversionFactor, TextBox my_MaterialSafeQuantity, TextBox my_MaterialTypeID, TextBox my_MaterialUnit, TextBox my_Active)
    {
        Staff _operator = new Staff("Company");
        string sql = " UPDATE ICS_Material SET MaterialName = '" + my_MaterialName.Text + "', MaterialSafeQuantity = '" + my_MaterialSafeQuantity.Text + "'"+
                     " , MaterialUnit = '" + my_MaterialUnit.Text + "', Active = '" + my_Active.Text + "' " +
                     " WHERE NO = '" + my_NO + "' ";
        return _operator.ExecuteStatement(sql);
    }

    protected void CustomersGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        String my_NO = gv.DataKeys[e.RowIndex].Value.ToString();
        if (DELICS_Material(my_NO))
        {
            ShowMsg2(UpdatePanel1, "刪除成功");
        }
        else
        {
            ShowMsg2(UpdatePanel1, "刪除失敗");
        }

        gv.EditIndex = -1;
        InitData();
        SearchData();
    }

    private bool DELICS_Material(String my_NO)
    {
        Staff _operator = new Staff("Company");
        string sql = "DELETE FROM ICS_Material WHERE NO = '" + my_NO + "'  ";
        return _operator.ExecuteStatement(sql);
    }

    protected void SearchData()
    {
        
        Staff _operator = new Staff("Company");
        string conditionName = ddlst_SearchType.SelectedValue;
        string condition = (txt_Query_Reason.Text.Trim().Length > 0 ? " " + conditionName + " like '%" + txt_Query_Reason.Text.Trim() + "%' " : "");
        //condition += query_company;
        DataSet ds = _operator.Select(condition,"" ,"ICS_Material");
        Session["DS_INT"] = ds;
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
        DataSet ds = (DataSet)Session["DS_INT"];
        this.gv.DataSource = ds;
        this.gv.DataBind();


    }
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //((Button)e.Row.Cells[0].FindControl("cmd_Edit")).Attributes.Add("onClick", "edit('" + e.Row.Cells[1].Text.Trim() + "');return false;");
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
    //        report = new ExcelReport("Inventory/Inventory");

    //        DataSet ds = (DataSet)Session["DS_INT"];

    //        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
    //        {
    //            report.FillData(j + 3, 1, ds.Tables[0].Rows[j]["NO"].ToString(), 1);
    //            report.FillData(j + 3, 2, ds.Tables[0].Rows[j]["MaterialName"].ToString(), 1);
    //            report.FillData(j + 3, 3, ds.Tables[0].Rows[j]["MaterialTypeID"].ToString(), 1);
    //            report.FillData(j + 3, 4, ds.Tables[0].Rows[j]["MaterialUnit"].ToString(), 1);
    //            report.FillData(j + 3, 5, ds.Tables[0].Rows[j]["PurchaseUnit"].ToString(), 1);
    //            report.FillData(j + 3, 6, ds.Tables[0].Rows[j]["ConsumeUnit"].ToString(), 1);
    //            report.FillData(j + 3, 7, ds.Tables[0].Rows[j]["ConversionFactor"].ToString(), 1);
    //            report.FillData(j + 3, 8, ds.Tables[0].Rows[j]["MaterialSafeQuantity"].ToString(), 1);
    //            report.FillData(j + 3, 9, ds.Tables[0].Rows[j]["Active"].ToString(), 1);

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

