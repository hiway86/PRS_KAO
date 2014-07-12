#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\Inventory\InventoryCheck_QM.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "63C7C837AFA4F7329691260F70E1D5F892410F37"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\Inventory\InventoryCheck_QM.aspx.cs"
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

public partial class Inventory_InventoryCheck_QM : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ScriptManager1.IsInAsyncPostBack)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "addSearchIcon();", true);
            //隱藏顯示欄位
            GridViewHidden(this.gv, 5); 
            InitData();
            SearchData();
        }
    }

    protected override void InitData()
    { 
    
    }

    protected void SearchData()
    {

        Staff _operator = new Staff("Company");
        string conditionName = ddlst_SearchType.SelectedValue;
        string condition = (txt_Query_Reason.Text.Trim().Length > 0 ? " WHERE  " + conditionName + " like '%" + txt_Query_Reason.Text.Trim() + "%' " : "");
        //condition += query_company;
        DataSet ds = _operator.SelectSQL("SELECT [MaterialID],[MaterialName],[Quantity],[MaterialCost]  FROM [View_ICS_Inventory] " + condition + " ");
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

    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gv.EditIndex = e.NewEditIndex;

        InitData();
        SearchData();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox my_RealQuantity;

        String my_MaterialID = gv.DataKeys[e.RowIndex].Value.ToString();
        String my_MaterialName = gv.Rows[e.RowIndex].Cells[2].Text;
        String my_SystemQuantity = gv.Rows[e.RowIndex].Cells[3].Text;
        my_RealQuantity = (TextBox)gv.Rows[e.RowIndex].Cells[4].Controls[0];
        String my_MaterialCost = gv.Rows[e.RowIndex].Cells[5].Text;


        if (!IsNumeric(my_RealQuantity.Text)) 
        {
            ShowMsg2(UpdatePanel1, "請輸入數字");
            return;
        }

        //檢查更新是否成功
        if (UpdateICS_Material(my_MaterialID, my_MaterialName, my_SystemQuantity, my_RealQuantity, my_MaterialCost))
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

    private bool UpdateICS_Material(String my_MaterialID, String my_MaterialName, String my_SystemQuantity, TextBox my_RealQuantity, String my_MaterialCost)
    {
        Staff _operator = new Staff("Company");
        float a = Convert.ToSingle(my_SystemQuantity);
        float b = Convert.ToSingle(my_RealQuantity.Text);
        float c = Convert.ToSingle(my_MaterialCost);
        int mat = Convert.ToInt32(my_MaterialID);
        string sql = "INSERT INTO [MROS].[dbo].[ICS_ReInventory]([MaterialID],[MaterialName],[SystemQuantity],[RealQuantity],[RelnventoryQuantity],[MaterialCost],[RelnventoryCost],[RelnventoryDate],[UpdateTime],[UpdateUser]) " +
                     " VALUES('" + mat + "','" + my_MaterialName + "','" + my_SystemQuantity + "','" + my_RealQuantity.Text + "','" + (a - b) + "','" + my_MaterialCost + "' ,'" + (b * c) + " ',getdate(),getdate(),'admin')";
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

#line default
#line hidden
