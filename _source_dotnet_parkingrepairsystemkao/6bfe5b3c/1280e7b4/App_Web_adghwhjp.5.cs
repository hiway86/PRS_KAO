#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\Statistics\StudyFileUpload_Q.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "72CC606E070E9C74EA28CAC2ACD85FCFA38F7213"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\Statistics\StudyFileUpload_Q.aspx.cs"
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
using System.IO;

public partial class Statistics_StudyFileUpload_Q : PageBase
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

    //將gridview header塞進dropbox
    protected override void InitData()
    {
       
    }

    protected void SearchData()
    {
        SQLDB _operator = new SQLDB("StudyFileUpload");
        string conditionName = ddlst_SearchType.SelectedValue;
        string condition = (txt_Query_Reason.Text.Trim().Length > 0 ? " " + conditionName + " like '%" + txt_Query_Reason.Text.Trim() + "%'  " : "");
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
            ((HyperLink)e.Row.Cells[1].FindControl("HyperLink1")).Visible = true;
            ((HyperLink)e.Row.Cells[1].FindControl("HyperLink1")).NavigateUrl = "../Temp/" + e.Row.Cells[0].Text.Trim();
            ((HyperLink)e.Row.Cells[1].FindControl("HyperLink1")).Text = "檢視檔案";

        }

    }

    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmd_delete")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gv.Rows[index];
            string filename = row.Cells[0].Text;
            string delete = " delete StudyFileUpload where FileName = '" + filename + "'";
            SQLDB _operator = new SQLDB();
            if (_operator.ExecuteStatement(delete))
            {
                ShowMsg(UpdatePanel1, "刪除成功");
                SearchData();
            }

            try
            {
                string strDestPath = Server.MapPath("../Temp/");

                FileInfo TheFile = new FileInfo(@strDestPath+filename);
                if (TheFile.Exists)
                {
                    File.Delete(@strDestPath + filename);
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }

            catch (FileNotFoundException ex)
            {
                ShowMsg(UpdatePanel1, ex.Message);
            }
            catch (Exception ex)
            {
                ShowMsg(UpdatePanel1, ex.Message);
            }


        }
    }
}

#line default
#line hidden
