#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\System\AuthList.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ED57B4C809CA0068CBB009145F9D83869E32D4DE"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\System\AuthList.aspx.cs"
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

public partial class System_AuthList : PageBase
{
    UserRole _operator = new UserRole();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Security sec = GetPagePermit();
        if (!ScriptManager1.IsInAsyncPostBack)
        {
            //////設定權限
            //if (sec == null || !sec.EnableBrowser)
            //{
            //    ShowErrorMsg(this.UpdatePanel1, "操作逾時，請重新登入", "../Login.aspx");
            //    return;
            //}
            //else
            //{
            //    this.body.Attributes.Add("onLoad", "setPermit(" + sec.EnableBrowser.ToString().ToLower() + ", " + sec.EnableQuery.ToString().ToLower() + ", " + sec.EnableAdd.ToString().ToLower() + ", " + sec.EnableEdit.ToString().ToLower() + ", " + sec.EnableDelete.ToString().ToLower() + ", " + sec.EnablePrint.ToString().ToLower() + ", " + sec.EnableEditSave.ToString().ToLower() + ", " + sec.EnableNewSave.ToString().ToLower() + ");");
            //}

            InitData();
            //GridViewHidden(this.gv, 1);
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
    protected void lnkbtn_Search_Click(object sender, EventArgs e)
    {
        SearchData();
    }

    protected void SearchData()
    {
        gv.DataSource = null;
        gv.DataBind();
        string conditionName = ddlst_SearchType.SelectedValue;
        string condition = (txt_Query_Reason.Text.Trim().Length > 0 ? " " + conditionName + " like '%" + txt_Query_Reason.Text.Trim() + "%'  " : "");
        DataSet ds = _operator.GetUserRole(condition, "");
        int idx = 0;
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            dr["Status"] = dr["Status"].ToString().Equals("True") ? "啟用" : "停用";
            //第一行不適用
            if (ds.Tables[0].Rows.IndexOf(dr) > 0)
            {
                //如果此dr與前dr的user_id相同，將資料塞入前dr
                if (ds.Tables[0].Rows[idx]["User_ID"].ToString().Equals(dr["User_ID"].ToString()))
                {
                    ds.Tables[0].Rows[idx]["Role_ID"] = ds.Tables[0].Rows[idx]["Role_ID"] + ", " + dr["Role_ID"].ToString();
                    ds.Tables[0].Rows[idx]["Role_Name"] = ds.Tables[0].Rows[idx]["Role_Name"] + ", " + dr["Role_Name"].ToString();
                    dr.Delete();
                }
                else//表示此dr與前dr不同
                {
                    idx = ds.Tables[0].Rows.IndexOf(dr);
                }
            }
        }
        gv.DataSource = ds;
        gv.DataBind();

    }

    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ((Button)e.Row.Cells[0].FindControl("cmd_edit")).Attributes.Add("onClick", "edit('" + e.Row.Cells[2].Text.Trim() + "');return false;");
        }
    }

    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gv.PageIndex = e.NewPageIndex;
        SearchData();
    }
}

#line default
#line hidden
