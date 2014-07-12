using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class CheckDevice_CheckCycle : PageBase
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
        Staff _operator = new Staff("CD_CheckCycle");
        string conditionName = ddlst_SearchType.SelectedValue;
        string condition = (txt_Query_Reason.Text.Trim().Length > 0 ? "  " + conditionName + " like '%" + txt_Query_Reason.Text.Trim() + "%' " : "");
        DataSet ds = _operator.Select(condition);
        Session["DS_CD"] = ds;
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
        DataSet ds = (DataSet)Session["DS_CD"];
        this.gv.DataSource = ds;
        this.gv.DataBind();
    }

    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gv.EditIndex = e.NewEditIndex;
        SearchData();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SQLDB db = new SQLDB();
        string deviceKind = gv.Rows[e.RowIndex].Cells[1].Text;
        TextBox checkcycle;
        checkcycle = (TextBox)gv.Rows[e.RowIndex].Cells[2].Controls[0];

        if (!IsNumeric(checkcycle.Text))
        {
            ShowMsg2(UpdatePanel1, "請輸入數字");
            return;
        }

        //檢查更新是否成功
        string updatestring = "Update  CD_CheckCycle set cycle= '" + checkcycle.Text + "'  where Devicekind = '" + deviceKind + "'";
        if (db.ExecuteStatement(updatestring))
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

    private bool UpdateICS_Material(String my_MaterialID, String my_MaterialName, String my_SystemQuantity, TextBox checkcycle, String my_MaterialCost)
    {
        Staff _operator = new Staff("Company");
        float a = Convert.ToSingle(my_SystemQuantity);
        float b = Convert.ToSingle(checkcycle.Text);
        float c = Convert.ToSingle(my_MaterialCost);
        int mat = Convert.ToInt32(my_MaterialID);
        string sql = "INSERT INTO [MROS].[dbo].[ICS_ReInventory]([MaterialID],[MaterialName],[SystemQuantity],[RealQuantity],[RelnventoryQuantity],[MaterialCost],[RelnventoryCost],[RelnventoryDate],[UpdateTime],[UpdateUser]) " +
                     " VALUES('" + mat + "','" + my_MaterialName + "','" + my_SystemQuantity + "','" + checkcycle.Text + "','" + (a - b) + "','" + my_MaterialCost + "' ,'" + (b * c) + " ',getdate(),getdate(),'admin')";
        return _operator.ExecuteStatement(sql);
    }

    protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
    {
        gv.EditIndex = -1;
        InitData();
        SearchData();
    }

    public bool IsNumeric(String strNumber)
    {
        Regex NumberPattern = new Regex("[^0-9.-]");
        return !NumberPattern.IsMatch(strNumber);
    }

    protected void CustomersGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }

}