#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\System\RoleProgramManage.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "16FAE4E68161F43E60638AC50683117970DF5E48"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\System\RoleProgramManage.aspx.cs"
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Globalization;



public partial class System_RoleProgramManage : PageBase
{
    RoleProgram m_operate = new RoleProgram();
    UserRole m_operate_ur = new UserRole();
    Color pre;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ScriptManager1.IsInAsyncPostBack)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "addSearchIcon();", true);

            Session["DS"] = null;
            Session["btnStatus"] = null;
            InitData();

        }
    }

    protected override void InitData()
    {
        BindDropDownListData(dl_Role, m_operate_ur.GetRole(""), "Role_Name", "Role_ID");
        BindDropDownListData(dl_System_Group, m_operate_ur.SelectQuery("SELECT * FROM System_Group", "System_Group"), "System_Group_Name", "System_Group_ID", "", "");
        BtnView(false);
    }

    protected void cmd_Search_Click(object sender, EventArgs e)
    {
        Search();
    }


    protected void cmd_Save_Click(object sender, EventArgs e)
    {
        if (this.dl_Role.SelectedValue.Equals(""))
        {
            ShowMsg("請選擇角色");
            return;
        }
        DataSet ds = (DataSet)Session["DS"];
        if (ds == null)
        {
            ShowMsg("查無資料");
            return;
        }
        bool success = true;
        foreach (GridViewRow row in gv.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                bool is_checked = ((CheckBox)row.FindControl("cb_browser")).Checked;
                if (is_checked)
                {
                    if (m_operate.UpdateRoleProgramBrowser(this.dl_Role.SelectedValue, row.Cells[0].Text, 1))
                    {
                        success = true;
                    }
                }
                else
                {
                    if (m_operate.UpdateRoleProgramBrowser(this.dl_Role.SelectedValue, row.Cells[0].Text, 0))
                    {
                        success = true;
                    }
                }
            }
        }
        if (success)
        {
            ShowMsg("修改成功");
        }
        else
        {
            ShowMsg("修改失敗");
        }
        Search();
    }


    private void BtnView(bool val)
    {
        this.Panel2.Visible = val;

    }

    protected void CancelBtn_Click(object sender, EventArgs e)
    {
        InitData();
        Search();
    }

    private void ClearField()
    {
    }

    public void CBSelector_CheckedChanged(object sender, EventArgs e)
    {
        BtnView(true);
    }

    private void Fill(string[] row_content)
    {
    }

    private DataRow FindDataRow(DataSet ds, GridView gv)
    {
        if (ds == null)
            return null;

        DataTable dt = ds.Tables[0];
        DataRow dr = null;

        for (int i = 0; i < gv.Rows.Count; i++)
        {
            bool isChecked = ((CheckBox)gv.Rows[i].FindControl("CBSelector")).Checked;
            if (isChecked)
            {
                dr = dt.Rows[i];
                break;
            }
        }
        return dr;
    }

    private void ShowMsg(string msg)
    {
        this.ShowMsg(UpdatePanel1, msg);
    }

    private void Search()
    {
        if (this.dl_Role.SelectedValue.Equals(""))
        {
            ShowMsg("請選擇角色");
            return;
        }
        DataSet ds = null;
        string sql = "";
        string select = "";
        string from = "";
        string where = "";
        string order = "";
        string dbKey = "";

        select = " SELECT p.Program_ID, p.Program_Name, p.Program_CName, p.System_Group_ID, s.System_Group_Name, rp.Role_ID, " +
          " ISNULL(rp.Enable_Browser, 'false') AS Enable_Browser, ISNULL(rp.Enable_Query, 'false') AS Enable_Query, ISNULL(rp.Enable_Add, 'false') AS Enable_Add, ISNULL(rp.Enable_Edit, 'false') AS Enable_Edit, ISNULL(rp.Enable_Delete, 'false') AS Enable_Delete, ISNULL(rp.Enable_Print, 'false') AS Enable_Print, ISNULL(rp.Enable_Edit_Save, 'false') AS Enable_Edit_Save, ISNULL(rp.Enable_New_Save, 'false') AS Enable_New_Save ";
        from = " FROM Program AS p " +
              " INNER JOIN System_Group AS s ON p.System_Group_ID = s.System_Group_ID " +
              " LEFT OUTER JOIN " +
                              " (SELECT Role_ID, Program_ID, Enable_Browser, Enable_Query, Enable_Add, Enable_Edit, Enable_Delete, Enable_Print, Enable_Edit_Save, Enable_New_Save " +
                              "  FROM Role_Program " +
                              "  WHERE (Role_ID = '" + this.dl_Role.SelectedValue + "')) AS rp ON p.Program_ID = rp.Program_ID " +
              " LEFT OUTER JOIN Role AS r ON rp.Role_ID = r.Role_ID ";
        where = " WHERE 1=1 ";
        order = " ORDER BY p.System_Group_ID, p.Program_ID, p.Program_Name";

        if (this.dl_System_Group.SelectedIndex > 0)
        {
            where += " AND p.System_Group_ID = '" + this.dl_System_Group.SelectedValue + "'";
        }

        sql = select + from + where + order;


        ds = m_operate.SelectQuery(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {

            Session["DS"] = ds;
            DataView dv = ds.Tables[0].DefaultView;

            gv.DataSource = dv;
            gv.DataBind();
            BtnView(true);
        }
        else
        {
            ShowMsg("查無資料");
        }
    }

    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[4].Text == "True")
            {
                ((CheckBox)e.Row.FindControl("cb_browser")).Checked = true;
            }
        }
    }
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gv.PageIndex = e.NewPageIndex;
        DataSet ds = (DataSet)Session["DS"];
        this.gv.DataSource = ds;
        this.gv.DataBind();
    }
    protected void gv_RowCreated(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            //要隱藏的欄位    
            e.Row.Cells[4].Visible = false;
        }

    }
}



#line default
#line hidden
