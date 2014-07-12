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

public partial class VDCheck_VDCheckError_Q : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ScriptManager1.IsInAsyncPostBack)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "addSearchIcon();", true);
           // GridViewHidden(this.gv, 6);//得標廠商id
           // GridViewHidden(this.gv, 11);//顯示與否
            InitData();
            //取得Staff列表
            //SearchData();
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
        SQLDB _operator = new SQLDB("VD_ERRORRECORD", "KPT");
        string conditionName = ddlst_SearchType.SelectedValue;
        StringBuilder condition = new StringBuilder();
        if (conditionName.Equals("RecordTime") || conditionName.Equals("UpdateTime"))
        {
            if (txt_StartDate.Text.Length > 0 && txt_EndDate.Text.Length > 0)
            {
                condition.Append(conditionName + ">  '" + txt_StartDate.Text + "' AND " + conditionName + "< '" + txt_EndDate.Text + "' ");
            }
            else
            {
                if (txt_StartDate.Text.Length > 0)
                {
                    condition.Append(conditionName + "> '" + txt_StartDate.Text + "' ");

                }
                else
                {
                    condition.Append(conditionName + "< '" + txt_EndDate.Text + "' ");
                }
            }
        }
        else
        {
            condition.Append(txt_Query_Reason.Text.Trim().Length > 0 ? " " + conditionName + " like '%" + txt_Query_Reason.Text.Trim() + "%'  " : "");
        }
        DataSet ds = _operator.Select(condition.ToString());
        Session["DS_MIS"] = ds;
        gv.DataSource = ds;
        gv.DataBind();
        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert(\"查詢無資料\");", true);
            //ShowMsg2(UpdatePanel1, "查詢無資料");
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
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    ((Button)e.Row.Cells[0].FindControl("cmd_Edit")).Attributes.Add("onClick", "edit('" + e.Row.Cells[1].Text.Trim() + "');return false;");
        //    ((ImageButton)e.Row.Cells[1].FindControl("cmd_Delete")).Attributes.Add("onClick", "del('" + e.Row.Cells[1].Text.Trim() + "');return false;");
        //}

    }


    protected void lnkbtn_Report_Click(object sender, EventArgs e)
    {
        //ExportTOExcel();
    }
}