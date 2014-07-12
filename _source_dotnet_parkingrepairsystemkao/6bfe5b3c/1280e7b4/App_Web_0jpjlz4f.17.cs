#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\Inventory\ReInventory_D.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "997C3529BD069A78D3A2CF73336B207D9C6EAE2A"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\Inventory\ReInventory_D.aspx.cs"
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

public partial class Inventory_ReInventory_D : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void InitData()
    { 
    }

    protected void lnkbtn_Search_Click(object sender, EventArgs e)
    {
        SearchData();
    }

    protected void SearchData()
    {
        String dat = txt_contractStartDate.Text;
        //String tim = txt_happen_Time.Text;

        Staff _operator = new Staff("Company");
        string condition = " WHERE 1=1";
        if (txt_Query_Reason.Text != "") 
        {
            condition += " AND MaterialName  like '%" + txt_Query_Reason.Text.Trim() + "%' ";
        }
        if (dat != "" ) 
        {
            condition += " AND (RelnventoryDate BETWEEN '" + dat + " 00:00:00' AND '" + dat + " 23:59:59')";
        }
        //condition += query_company;
        DataSet ds = _operator.SelectSQL("SELECT *  FROM [MROS].[dbo].[ICS_ReInventory] " + condition + " ORDER BY  [RelnventoryDate] DESC ");
        Session["DS_INT"] = ds;
        if (ds.Tables[0].Rows.Count == 0)
        {
            ShowMsg2(UpdatePanel1, "查詢無資料");
        }
       
            gv.DataSource = ds;
            gv.DataBind();
        
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
    
    }

    protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
    {
        gv.EditIndex = -1;
        InitData();
        SearchData();
    }

    protected void CustomersGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        String my_RelnventoryID = gv.DataKeys[e.RowIndex].Value.ToString();
        if (DELICS_Material(my_RelnventoryID))
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

    private bool DELICS_Material(String my_RelnventoryID)
    {
        Staff _operator = new Staff("Company");
        string sql = "DELETE FROM ICS_ReInventory WHERE RelnventoryID = '" + my_RelnventoryID + "'  ";
        return _operator.ExecuteStatement(sql);
    }


}

#line default
#line hidden
