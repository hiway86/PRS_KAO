#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\MIS\RegionManage.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E0C5527346B8339041C26A5A4769806F207E7AD2"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\MIS\RegionManage.aspx.cs"
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

public partial class MIS_RegionManage : PageBase
{
    protected SQLDB region = new SQLDB("Area_Data");
    DataSet regionDS;
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
                        txt_regionCode.Enabled = false;
                        BtnEdit("新增存檔");
                        FieldEdit(true);
                    }
                    else if (hidden_Action.Value.Equals("edit"))
                    {
                        if (Request.QueryString["id"] != null)
                        {
                            hidden_regionId.Value = Request.QueryString["id"].Trim();
                            //
                            if (LoadData())
                            {
                                txt_regionCode.Enabled = false;
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
        ShowMsgAndRedirect(UpdatePanel1, msg, "../MIS/RegionList.aspx");
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
        string rowfilter = "AreaID=" + hidden_regionId.Value;

        //直接去資料庫抓
        regionDS = region.Select(rowfilter);

        if (regionDS.Tables[0].Rows.Count == 1)
        {
            DataTable dt = regionDS.Tables[0];
            DataRow dr = dt.Rows[0];

            txt_regionCode.Text = dr["AreaID"].ToString();
            txt_region.Text = dr["AreaName"].ToString();
            Session["DS_Mis"] = regionDS;
            suc = true;
        }
        return suc;
    }

    public void UpdateServerData()
    {
        // Application["App_Mis_Company"] = CommonLib.GetCompany();
    }

    protected void txt_Car_Licence_Exp_TextChanged(object sender, EventArgs e)
    {

    }
    protected void cmd_Save_Click1(object sender, EventArgs e)
    {
        if (txt_region.Text.Length == 0)
        {
            ShowPageMsg("請輸入地區名稱");
            return;
        }
        if (hidden_Action.Value.Equals("add"))
        {
            DataSet DS = new DataSet();
            DataTable DT = new DataTable("Area_Data");
            DT.Columns.Add("AreaID");
            DT.Columns.Add("AreaName");
            DS.Tables.Add(DT);
            DataRow DR = DS.Tables[0].NewRow();
            DR["AreaID"] = region.Select().Tables[0].Rows.Count + 1;
            DR["AreaName"] = txt_region.Text;
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
                ds.Tables[0].Rows[0]["AreaName"] = txt_region.Text;
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
