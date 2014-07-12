#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\VDCheck\DoorSill_Q.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "52B74F8321E5FDE9D155A7A566F4E65D3BBE6970"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\VDCheck\DoorSill_Q.aspx.cs"
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class VDCheck_DoorSill_Q : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ScriptManager1.IsInAsyncPostBack)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "addSearchIcon();", true);
            Session["DS_MIS"] = null;
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
        SQLDB _operator = new SQLDB("VD_DOORSILL", "KPT");
        string conditionName = ddlst_SearchType.SelectedValue;
        string condition = (txt_Query_Reason.Text.Trim().Length > 0 ? " " + conditionName + " like '%" + txt_Query_Reason.Text.Trim() + "%' " : "");
        //condition += query_company;
        DataSet ds = _operator.Select(condition);

        ////LINQ 測試
        //DataSet ds_std = _operator.Select("", "", "VD_DOORSILL");
        //DataTable dt = ds_std.Tables[0];
        //var std = (
        //    from std_table in dt.AsEnumerable()
        //    where std_table.Field<string>("DeviceID").ToString().Equals("V012441")
        //    select std_table);

        //std.Single().SetField("DeviceID", "test");

        //if (std.Any())
        //{
        //    DataTable dt_door = std.CopyToDataTable();
        //    gv.DataSource = dt_door;
        //    gv.DataBind();
        //}
        //else
        //{
        //    ShowMsg2(UpdatePanel1, "查詢無資料");
        //}

        Session["DS_MIS"] = ds;
        if (ds.Tables[0].Rows.Count > 0)
        {
            gv.DataSource = ds;
            gv.DataBind();
        }
        else
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
        }

    }

    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmd_delete")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gv.Rows[index];
            string id = row.Cells[1].Text;
            string delete = " delete VD_DOORSILL where ID = '" + id + "'";
            SQLDB _operator = new SQLDB("VD_DOORSILL","KPT");
            if (_operator.ExecuteStatement(delete))
            {
                ShowMsg(UpdatePanel1, "刪除成功");
                SearchData();
            }
        }
    }



}

#line default
#line hidden
