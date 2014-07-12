#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\Statistics\InventoryCost_Q.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "96087D539BF70ADA32ADF2073C773D9553173918"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\Statistics\InventoryCost_Q.aspx.cs"
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
using System.Web.UI.DataVisualization.Charting;

public partial class Statistics_InventoryCost_Q : PageBase
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
        ddlst_SearchType.Items.Clear();

        for (int i = 0; i < this.gv.Columns.Count; i++)
        {
            if (this.gv.Columns[i] is BoundField && gv.Columns[i].HeaderStyle.CssClass != "gridviewhiddenrow")
            {
                ListItem item = new ListItem();
                item.Text = gv.Columns[i].HeaderText;
                item.Value = ((BoundField)gv.Columns[i]).DataField;
                if (item.Value != "counts")
                    this.ddlst_SearchType.Items.Add(item);
            }
        }
    }

    protected void SearchData()
    {
        gv.DataSource = null;
        gv.DataBind();

        SQLDB db = new SQLDB();
        StringBuilder query = new StringBuilder("  select *  ");
        query.Append(" from View_ICS_InventoryCost ");
        string conditionName = ddlst_SearchType.SelectedValue;
        StringBuilder condition = new StringBuilder();
        bool isquery = false;
        if (txt_Query_Reason.Text.Trim().Length > 0)
        {
            condition.Append(conditionName + " like '%" + txt_Query_Reason.Text.Trim() + "%' and");
            isquery = true;
        }
        if (txt_startDateTime.Text.Length > 0)
        {
            condition.Append(" si.UpdateTime >= '" + txt_startDateTime.Text + "' and");
            isquery = true;
        }
        if (txt_endDateTime.Text.Length > 0)
        {
            condition.Append(" si.UpdateTime <= '" + txt_endDateTime.Text + "'  and");
            isquery = true;
        }
        if (isquery)
        {
            query.Append(" WHERE " + condition.ToString().Substring(0, condition.ToString().Length - 3));
        }
        DataSet ds = db.SelectQuery(query.ToString());
        //Session["DS_MIS"] = ds;
        gv.DataSource = ds;
        gv.DataBind();

        if (ds.Tables[0].Rows.Count == 0)
        {
            ShowMsg2(UpdatePanel1, "查詢無資料");
        }


    }
    protected DataTable GetData()
    {
        gv.DataSource = null;
        gv.DataBind();

        SQLDB db = new SQLDB();
        StringBuilder query = new StringBuilder("  select top 20 *  ");
        query.Append(" from View_ICS_InventoryCost ");
        string conditionName = ddlst_SearchType.SelectedValue;
        StringBuilder condition = new StringBuilder();
        bool isquery = false;
        if (txt_Query_Reason.Text.Trim().Length > 0)
        {
            condition.Append(conditionName + " like '%" + txt_Query_Reason.Text.Trim() + "%' and");
            isquery = true;
        }
        if (txt_startDateTime.Text.Length > 0)
        {
            condition.Append(" si.UpdateTime >= '" + txt_startDateTime.Text + "' and");
            isquery = true;
        }
        if (txt_endDateTime.Text.Length > 0)
        {
            condition.Append(" si.UpdateTime <= '" + txt_endDateTime.Text + "'  and");
            isquery = true;
        }
        if (isquery)
        {
            query.Append(" WHERE " + condition.ToString().Substring(0, condition.ToString().Length - 3));
        }
        DataSet ds = db.SelectQuery(query.ToString());
        //Session["DS_MIS"] = ds;


        if (ds.Tables[0].Rows.Count == 0)
        {
            ShowMsg2(UpdatePanel1, "查詢無資料");
        }
        return ds.Tables[0];


    }


    protected void lnkbtn_Search_Click(object sender, EventArgs e)
    {
        SearchData();
    }
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;
        SearchData();
    }


    protected void lnkbtn_Add_Click(object sender, EventArgs e)
    {
        RunChart();
    }

    private void RunChart()
    {
        DataTable dt = GetData();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            Chart1.Series["入庫成本"].Points.AddXY(dt.Rows[i]["ProjectName"].ToString(), Convert.ToDouble(dt.Rows[i]["stockincost"].ToString()));
            Chart1.Series["入庫成本"].IsValueShownAsLabel = true;
            Chart1.Series["出庫成本"].Points.AddXY(dt.Rows[i]["ProjectName"].ToString(), Convert.ToDouble(dt.Rows[i]["stockoutcost"].ToString()));
            Chart1.Series["出庫成本"].IsValueShownAsLabel = true;
            Chart1.Series["損益成本"].Points.AddXY(dt.Rows[i]["ProjectName"].ToString(), Convert.ToDouble(dt.Rows[i]["analysisCost"].ToString()));
            Chart1.Series["損益成本"].IsValueShownAsLabel = true;
        }

       
            Chart1.Legends.Add(new Legend("Legend1"));
            Chart1.Legends.Add(new Legend("Legend2"));
            Chart1.Legends.Add(new Legend("Legend3"));

            //Chart1.ChartAreas.Add("ChartArea1");
            //Chart1.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = false;
            //Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.IsStaggered = true;
    }
}

#line default
#line hidden
