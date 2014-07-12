#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\MIS\KindsOfEquipmentManage.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FC14DC1DDAE7B77301C43CF969C52BF639D72227"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\MIS\KindsOfEquipmentManage.aspx.cs"
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
using System.Text.RegularExpressions;
using System.IO;

public partial class MIS_KindsOfEquipmentManage : PageBase
{
    DataSet deviceModelDS;
    protected string iconPath = "../img/mapicons/";
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
                        txt_equipmentKindId.Enabled = false;
                        BtnEdit("新增存檔");
                        FieldEdit(true);
                    }
                    else if (hidden_Action.Value.Equals("edit"))
                    {
                        if (Request.QueryString["id"] != null)
                        {
                            hidden_EquipmentKindId.Value = Request.QueryString["id"].Trim();
                            //
                            if (LoadData())
                            {
                                txt_equipmentKindId.Enabled = false;
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
        ShowMsgAndRedirect(UpdatePanel1, msg, "../MIS/KindsOfEquipmentList.aspx");
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
        SQLDB deviceModel = new SQLDB("DeviceKind");
        FieldEdit(false);
        bool suc = false;
        string rowfilter = "DeviceKindId=" + hidden_EquipmentKindId.Value;

        //直接去資料庫抓
        deviceModelDS = deviceModel.Select(rowfilter);
       
        if (deviceModelDS.Tables[0].Rows.Count == 1) {
            DataTable dt = deviceModelDS.Tables[0];
            DataRow dr = dt.Rows[0];

            txt_equipmentKindId.Text = dr["DeviceKindId"].ToString();
            txt_equipmentKind.Text = dr["DeviceKind"].ToString();
            txt_DeviceKindName.Text = dr["DeviceKindName"].ToString();
            image.ImageUrl = iconPath + dr["DeviceKindId"].ToString() + ".gif";
            Session["DS_Mis"] = deviceModelDS;
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
        SQLDB deviceModel = new SQLDB("DeviceKind");
        if (hidden_Action.Value.Equals("add")) {
            DataSet DS = new DataSet();
            DataTable DT = new DataTable("DeviceKind");
            DT.Columns.Add("DeviceKindId");
            DT.Columns.Add("DeviceKind");
            DT.Columns.Add("DeviceKindName");
            DS.Tables.Add(DT);
            DataRow DR = DS.Tables[0].NewRow();
            DR["DeviceKindId"] = deviceModel.Select().Tables[0].Rows.Count + 1;
            DR["DeviceKind"] = txt_equipmentKind.Text;
            DR["DeviceKindName"] = txt_DeviceKindName.Text;
            DS.Tables[0].Rows.Add(DR);
            DataSet _changed = DS.GetChanges();
            if (deviceModel.Insert(_changed))
            {
                ReDirect("新增成功");
            }
            else {
                ReDirect("新增失敗");
            }
        }
        else if (hidden_Action.Value.Equals("edit")){
            DataSet ds = (DataSet)Session["DS_Mis"];
            if (ds != null){
                ds.Tables[0].Rows[0]["DeviceKind"] = txt_equipmentKind.Text;
                ds.Tables[0].Rows[0]["DeviceKindName"] = txt_DeviceKindName.Text;
                DataSet DSChange = ds.GetChanges(DataRowState.Modified);
                if (deviceModel.Update(DSChange))
                {
                    ReDirect("修改成功");
                }
                else {
                    ReDirect("修改失敗");
                }
            }
        }
    }

}


#line default
#line hidden
