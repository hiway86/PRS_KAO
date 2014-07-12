#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\System\RoleManage.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1B97CE83E0E39E20CEA5201F39B3D7FAFB5C28C6"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\System\RoleManage.aspx.cs"
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

public partial class System_RoleManage : PageBase
{
    protected SQLDB region = new SQLDB("Role");
    DataSet DS;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ScriptManager1.IsInAsyncPostBack)
        {
            Session["DS_Mis"] = null;
            try
            {
                if (Request.QueryString["act"] != null)
                {

                    hidden_Action.Value = Request.QueryString["act"].Trim();
                    //InitData();
                    //
                    if (hidden_Action.Value.Equals("add"))
                    {
                        
                        BtnEdit("新增存檔");
                        FieldEdit(true);
                    }
                    else if (hidden_Action.Value.Equals("edit"))
                    {
                        if (Request.QueryString["id"] != null)
                        {
                            hidden_RoleId.Value = Request.QueryString["id"].Trim();
                            //
                            if (LoadData())
                            {
                                txt_roleId.Enabled = false;
                                BtnEdit("修改存檔");
                                FieldEdit(false);
                            }
                            else
                            {
                                ReDirect("資料讀取錯誤!!");
                            }
                        }
                        else
                        {
                            ReDirect("參數錯誤!!");
                        }
                    }
                }
                else
                {
                    ReDirect("參數錯誤!!");
                }
            }
            catch (Exception ex)
            {
                ReDirect("異常錯誤發生!!");
            }

        }
    }

    protected void ReDirect(string msg)
    {
        ShowMsgAndRedirect(UpdatePanel1, msg, "../System/RoleList.aspx");
    }

    protected void ShowPageMsg(string msg)
    {
        ShowMsg2(UpdatePanel1, msg);
    }

    protected void BtnEdit(string btnName)
    {
        bool visible = false;
        if (btnName.Trim().Length > 0)
        {
            visible = true;
        }
        cmd_Save.Visible = visible;
        cmd_Save.Text = btnName.Trim();
    }

    protected override void InitData()
    {

    }

    protected void FieldEdit(bool val)
    {

    }


    protected bool LoadData()
    {
        FieldEdit(false);
        bool suc = false;
        string rowfilter = "Role_ID='" + hidden_RoleId.Value + "'";

        //直接去資料庫抓
        DS = region.Select(rowfilter);

        if (DS.Tables[0].Rows.Count == 1)
        {
            DataTable dt = DS.Tables[0];
            DataRow dr = dt.Rows[0];

            txt_roleId.Text = dr["Role_id"].ToString();
            txt_roleName.Text = dr["Role_Name"].ToString();
            Session["DS_Mis"] = DS;
            suc = true;
        }
        return suc;
    }

    public void UpdateServerData()
    {
        Application["App_Role"] = CommonLib.GetRole();
    }

    protected void txt_Car_Licence_Exp_TextChanged(object sender, EventArgs e)
    {

    }
    protected void cmd_Save_Click1(object sender, EventArgs e)
    {
        if (txt_roleId.Text.Length == 0)
        {
            ShowPageMsg("請輸入角色代號");
            return;
        }
        if (txt_roleName.Text.Length == 0)
        {
             ShowPageMsg("請輸入角色名稱");
            return;
        }
        if (hidden_Action.Value.Equals("add"))
        {
            DataSet DS = new DataSet();
            DataTable DT = new DataTable("Role");
            DT.Columns.Add("Role_ID");
            DT.Columns.Add("Role_Name");
            DS.Tables.Add(DT);
            DataRow DR = DS.Tables[0].NewRow();
            DR["Role_ID"] = txt_roleId.Text;
            DR["Role_Name"] = txt_roleName.Text;
            DS.Tables[0].Rows.Add(DR);
            DataSet _changed = DS.GetChanges();
            if (region.Insert(_changed))
            {
                ReDirect("新增成功");
            }
            else
            {
                ReDirect("新增失敗");
            }
        }
        else if (hidden_Action.Value.Equals("edit"))
        {
            DataSet ds = (DataSet)Session["DS_Mis"];
            if (ds != null)
            {
                ds.Tables[0].Rows[0]["Role_Name"] = txt_roleName.Text;
                if (region.Update(ds))
                {
                    ReDirect("修改成功");
                }
                else
                {
                    ReDirect("修改失敗");
                }
            }
        }
    }
}


#line default
#line hidden
