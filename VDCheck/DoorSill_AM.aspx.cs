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

public partial class VDCheck_DoorSill_AM : PageBase
{
    protected SQLDB region = new SQLDB("VD_DOORSILL", "KPT");   
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
                    InitData();
                    
                    if (hidden_Action.Value.Equals("add"))
                    {
                        BtnEdit("新增存檔");
                        FieldEdit(true);
                    }
                    else if (hidden_Action.Value.Equals("edit"))
                    {
                        if (Request.QueryString["id"] != null)
                        {
                            hidden_Id.Value = Request.QueryString["id"].Trim();
                            //
                            if (LoadData())
                            {
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
        ShowMsgAndRedirect(UpdatePanel1, msg, "../VDCheck/DoorSill_Q.aspx");
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
        SQLDB _operator = new SQLDB("VD_Info", "KPT");
        string query = "select Vdid from VD_STANDARD group by Vdid";
        DataSet ds = _operator.SelectQuery(query);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem vditem = new ListItem();
            vditem.Value = ds.Tables[0].Rows[i]["Vdid"].ToString();
            vditem.Text = ds.Tables[0].Rows[i]["Vdid"].ToString();
            ddlst_Device.Items.Add(vditem);
        }
    }

    protected void FieldEdit(bool val)
    {
        ddlst_Device.Enabled = val;
    }


    protected bool LoadData()
    {
        FieldEdit(false);
        bool suc = false;
        string rowfilter = "ID=" + hidden_Id.Value;

        //直接去資料庫抓
        DataSet  DS = region.Select(rowfilter);

        if (DS.Tables[0].Rows.Count == 1)
        {
            DataTable dt = DS.Tables[0];
            DataRow dr = dt.Rows[0];

            ddlst_Device.SelectedValue = dr["DeviceID"].ToString();
            txt_flowLowBound.Text = dr["FlowBottom"].ToString();
            txt_flowUpBound.Text = dr["FlowTop"].ToString();
            txt_OccupyLowBound.Text = dr["OccupyBottom"].ToString();
            txt_OccupyUpBound.Text = dr["OccupyTop"].ToString();
            txt_SpeedLowBound.Text = dr["SpeedBottom"].ToString();
            txt_SpeedUpBound.Text = dr["SpeedTop"].ToString();
            Session["DS_Mis"] = DS;
            suc = true;
        }
        return suc;
    }

    public void UpdateServerData()
    {
        Application["App_Invetory_MaterialType"] = CommonLib.GetMaterialType();
    }

    protected void txt_Car_Licence_Exp_TextChanged(object sender, EventArgs e)
    {

    }
    protected void cmd_Save_Click1(object sender, EventArgs e)
    {
        if (hidden_Action.Value.Equals("add"))
        {
            SQLDB _operator = new SQLDB("VD_DOORSILL", "KPT");
            DataSet DS = _operator.Select("1=0", "", "VD_DOORSILL");
            DataRow DR = DS.Tables[0].NewRow();
            DR["DeviceID"] = ddlst_Device.SelectedValue;
            DR["SpeedTop"] = txt_SpeedUpBound.Text;
            DR["SpeedBottom"] = txt_SpeedLowBound.Text;
            DR["OccupyTop"] = txt_OccupyUpBound.Text;
            DR["OccupyBottom"] = txt_OccupyLowBound.Text;
            DR["FlowTop"] = txt_flowUpBound.Text;
            DR["FlowBottom"] = txt_flowLowBound.Text;
            DS.Tables[0].Rows.Add(DR);
            DataSet _changed = DS.GetChanges();
            if (region.Insert(_changed))
            {
                ReDirect("新增成功");
                //UpdateServerData();
            }
            else
            {
                ReDirect("新增失敗");
            }
        }
        else if (hidden_Action.Value.Equals("edit"))
        {
            SQLDB _operator = new SQLDB("VD_DOORSILL", "KPT");
            DataSet DS = _operator.Select("ID = '" + hidden_Id.Value + "'", "", "VD_DOORSILL");
            if (DS.Tables[0].Rows.Count > 0)
            {
                DataRow DR = DS.Tables[0].Rows[0];
                DR["DeviceID"] = ddlst_Device.SelectedValue;
                DR["SpeedTop"] = txt_SpeedUpBound.Text;
                DR["SpeedBottom"] = txt_SpeedLowBound.Text;
                DR["OccupyTop"] = txt_OccupyUpBound.Text;
                DR["OccupyBottom"] = txt_OccupyLowBound.Text;
                DR["FlowTop"] = txt_flowUpBound.Text;
                DR["FlowBottom"] = txt_flowLowBound.Text;
                DataSet _changed = DS.GetChanges(DataRowState.Modified);
                if (region.Update(DS))
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
    protected void cmd_SaveAll_Click(object sender, EventArgs e)
    {
        SQLDB _operator = new SQLDB("VD_Info", "KPT");
        string query = "select Vdid from VD_STANDARD group by Vdid";
        DataSet ds = _operator.SelectQuery(query);
       

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DataRow dr_vd = ds.Tables[0].Rows[i];
            //SQLDB _operator = new SQLDB("VD_DOORSILL", "KPT");
            DataSet DS = _operator.Select("1=0", "", "VD_DOORSILL");
            DataRow DR = DS.Tables[0].NewRow();
            DR["DeviceID"] = dr_vd["vdid"].ToString();
            DR["SpeedTop"] = "255";
            DR["SpeedBottom"] = "0";
            DR["OccupyTop"] = "100";
            DR["OccupyBottom"] = "0";
            DR["FlowTop"] = "60";
            DR["FlowBottom"] = "0";
            DS.Tables[0].Rows.Add(DR);
            DataSet _changed = DS.GetChanges();
            region.Insert(_changed);
        }

        ReDirect("新增成功");
        //UpdateServerData();
    }
}
