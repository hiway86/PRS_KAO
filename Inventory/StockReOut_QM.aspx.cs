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

public partial class Inventory_StockReOut_QM : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ScriptManager1.IsInAsyncPostBack)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "addSearchIcon();", true);
            //隱藏顯示欄位
            GridViewHidden(this.gv, 5); //地區編號
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
        gv_stockOutitem.DataSource = null;
        gv_stockOutitem.DataBind();

        lbl_stockitem.Visible = false;
        //string query_company = GetCompanyScope();
        Staff _operator = new Staff("View_ICS_StockOut_Record");
        string conditionName = ddlst_SearchType.SelectedValue;
        StringBuilder condition = new StringBuilder(txt_Query_Reason.Text.Trim().Length > 0 ? " " + conditionName + " like '%" + txt_Query_Reason.Text.Trim() + "%' AND " : "");
        //condition += query_company;
        if (txt_startDateTime.Text.Length > 0)
        {
            condition.Append("  StockOutDate >= '" + txt_startDateTime.Text + "'  ");
        }
        if (txt_endDateTime.Text.Length > 0)
        {
            condition.Append("and StockOutDate <= '" + txt_endDateTime.Text + "' ");
        }
        DataSet ds = _operator.Select(condition.ToString(), "StockOutDate desc");
        //Session["DS_MIS"] = ds;
        gv.DataSource = ds;
        gv.DataBind();

        if (ds.Tables[0].Rows.Count == 0)
        {
            lbl_stockitem.Visible = true;
            lbl_stockitem.Text = "查詢無資料";
        }
    }


    protected void lnkbtn_Search_Click(object sender, EventArgs e)
    {
        SearchData();
    }

    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gv.PageIndex = e.NewPageIndex;
        SearchData();
    }
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //修改出庫完成顯示文字
            if (e.Row.Cells[9].Text == "False")
            {
                e.Row.Cells[9].Text = "否";
            }
            else
            {
                e.Row.Cells[9].Text = "是";
            }

            Button editButton = (Button)e.Row.Cells[0].Controls[1];
            editButton.CommandArgument = e.Row.RowIndex.ToString();
         
        }

    }

    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //利用選取入庫編號，抓取入庫內容與入庫單計畫分攤
        if (e.CommandName == "Search")
        {
            labelView(true);
            int index = Convert.ToInt32(e.CommandArgument);
            string stockinid = gv.Rows[index].Cells[1].Text.Replace("&nbsp;", "");  //入庫編號
            hid_stockOutid.Value = stockinid;
            SearchStockItemProject(stockinid);
        }

    }

    


    //顯示入庫單label與入庫單計畫分擔label
    private void labelView(bool view)
    {
        lbl_stockitem.Text = "出庫單內容";
        lbl_stockitem.Visible = view;
    }

    //搜尋出庫單內容
    private void SearchStockItemProject(string stockinid)
    {
        SQLDB _operator = new SQLDB();
        //抓取入庫內容
        DataSet DS = _operator.Select("StockOutID = '" + stockinid + "'", "", "ICS_StockOut_Item");
        if (DS.Tables[0].Rows.Count > 0)
        {
            gv_stockOutitem.DataSource = DS;
            gv_stockOutitem.DataBind();
        }
        else
        {
            gv_stockOutitem.DataSource = null;
            gv_stockOutitem.DataBind();
            ShowMsg2(UpdatePanel1, "入庫單內容無資料");
            labelView(false);
        }

    }
    protected void gv_stockitem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gv_stockOutitem.PageIndex = e.NewPageIndex;
        SearchStockItemProject(hid_stockOutid.Value);
        //DataSet ds = (DataSet)Session["DS_MIS"];
        //this.gv.DataSource = ds;
        //this.gv.DataBind();
    }
    protected void gv_stockOutitem_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gv_stockOutitem.EditIndex = e.NewEditIndex;
        SearchStockItemProject(hid_stockOutid.Value);
    }
    protected void gv_stockOutitem_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SQLDB db = new SQLDB();
        //抓出庫單序號
        string stockoutitemid = gv_stockOutitem.DataKeys[e.RowIndex].Value.ToString();
        DataSet ds = db.Select("StockOutItemID = '" + stockoutitemid + "'", "", "ICS_StockOut_Item");
        if (ds.Tables[0].Rows.Count > 0)
        {
            TextBox reStockoutQuantity;
            reStockoutQuantity = (TextBox)gv_stockOutitem.Rows[e.RowIndex].Cells[7].Controls[0];
            ds.Tables[0].Rows[0]["ReConsumeQuantity"] = Convert.ToInt32(reStockoutQuantity.Text);
            DataSet DSChane = ds.GetChanges();
            if (db.Update(DSChane))
            {
                ShowMsg2(UpdatePanel1, "退繳成功");
            }

            gv_stockOutitem.EditIndex = -1;
            SearchStockItemProject(hid_stockOutid.Value);
        }

    }
    protected void gv_stockOutitem_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gv_stockOutitem.EditIndex = -1;
        SearchStockItemProject(hid_stockOutid.Value);
    }
}