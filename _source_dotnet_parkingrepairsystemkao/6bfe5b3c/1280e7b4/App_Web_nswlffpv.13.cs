#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\MIS\EquipmentDataManage.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FD2E2D099A0A3898D0CB56BC4C76638F26A331C8"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\MIS\EquipmentDataManage.aspx.cs"
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Configuration;

public partial class MIS_EquipmentDataManage : PageBase
{

    protected Equipment _operator = new Equipment();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ToolkitScriptManager1.IsInAsyncPostBack)
        {
            Session["DS_Mis"] = null;
            try
            {
                if (Request.QueryString["act"] != null)
                {
                    hidden_Action.Value = Request.QueryString["act"].Trim();
                    InitData();
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
                            hidden_Device_ID.Value = Request.QueryString["id"].Trim();
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
        ShowMsgAndRedirect(UpdatePanel1, msg, "../MIS/EquipmentDataList.aspx");
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
        SQLDB _operator = new SQLDB();
        DataSet ds_area = _operator.Select("", "", "Area_Data");
        BindDropDownListData(cbo_region, ds_area, "AreaName", "AreaID");
        //BindDropDownListData(cbo_deviceModel, (DataSet)Application["App_Mis_DeviceModel"], "DeviceModel", "DeviceModelId");
        string query_contract = " select ('('+ContractNum+')'+ContractName) as ContractCombine,* from Contract ";
        DataSet ds_contract = _operator.SelectQuery(query_contract);
        BindDropDownListData(cbo_deviceContractID, ds_contract, "ContractCombine", "ContractId");
        DataSet ds_DeviceModel = _operator.Select("", "", "DeviceKind");
        BindDropDownListData(cbo_DeviceModel, ds_DeviceModel, "DeviceKindName", "DeviceKindId");

    }

    protected void FieldEdit(bool val)
    {

    }

    protected bool LoadData()
    {
        FieldEdit(false);
        bool suc = false;
        string rowfilter = " Device_ID =  " + "'" + hidden_Device_ID.Value + "'";

        //第一種方法：直接去資料庫抓

        DataSet ds2 = _operator.Select(rowfilter, "", "Device_Config");
        if (ds2.Tables[0].Rows.Count == 1)
        {
            suc = true;
            DataTable dt = ds2.Tables[0];
            DataRow dr = dt.Rows[0];

            txt_Device_ID.Text = dr["Device_ID"].ToString();
            //if (dr["DeviceModel"].ToString().Trim().Length > 0)
            //{
            //    cbo_deviceModel.SelectedValue = dr["DeviceModel"].ToString().Trim();
            //}
            if (dr["Area_ID"].ToString().Trim().Length > 0)
            {
                cbo_region.SelectedValue = dr["Area_ID"].ToString().Trim();
            }
            txt_sectorName.Text = dr["Location"].ToString();
            //txt_tcModel.Text = dr["TCModel"].ToString();
            if (dr["DeviceContractID"].ToString().Trim().Length > 0)
            {
                cbo_deviceContractID.SelectedValue = dr["DeviceContractID"].ToString().Trim();
            }
            if (dr["DeviceModel"].ToString().Trim().Length > 0)
            {
                cbo_DeviceModel.SelectedValue = dr["DeviceModel"].ToString().Trim();
            }
            //txt_deviceStatus.Text = dr["Status"].ToString().Trim();
            //txt_deviceNote.Text = dr["DeviceNote"].ToString().Trim();
            txt_longitude.Text = dr["Gis_X"].ToString().Trim();
            txt_latitude.Text = dr["Gis_Y"].ToString().Trim();
            //image.ImageUrl = ConfigurationManager.AppSettings["imagesUrl"] + dr["DevicePhoto"].ToString().Trim();

            txt_Comm_Server_IP.Text = dr["Comm_Server_IP"].ToString();
            //txt_Equipment_ID.Text = dr["Equipment_ID"].ToString();
            //txt_Attribute.Text = dr["Attribute"].ToString();
            //txt_Status.Text = dr["Status"].ToString();
            //txt_Receive_Port.Text = dr["Receive_Port"].ToString();
            //txt_Remote_Port.Text = dr["Receive_Port"].ToString();
            //txt_Remote_IP.Text = dr["Remote_IP"].ToString();
            //txt_Remote_Port.Text = dr["Remote_Port"].ToString();
            //txt_Phone_Number.Text = dr["Phone_Number"].ToString();

            Session["DS_Mis"] = ds2;
        }

        //第二種方法：從List中所存Session找出DataSset，再找出DataRow，但無法使用DS.GETChange，因為GetDataRow後之ds已被搜尋過
        /*
        DataSet ds = (DataSet)Session["DS_Mis"];
        DataRow dr = _operator.GetDataRow(ds, rowfilter);
        if (dr != null)
        {
            suc = true;
            txt_BreakDown_Type.Text = dr["BreakDown_Type"].ToString().Trim();
        }
         */
        return suc;
    }

    public void UpdateServerData()
    {
        Application["App_Mis_Equipment"] = CommonLib.GetDevice();
    }

    protected void txt_Car_Licence_Exp_TextChanged(object sender, EventArgs e)
    {

    }
    protected void cmd_Save_Click(object sender, EventArgs e)
    {
        //_operator.Device_ID = txt_Device_ID.Text;
        ////if (cbo_deviceModel.SelectedValue != null)
        ////{
        ////    _operator.DeviceModel = Convert.ToInt32(cbo_deviceModel.SelectedValue);
        ////}
        //if (cbo_region.SelectedValue != null)
        //{
        //    _operator.Area_ID = Convert.ToInt32(cbo_region.SelectedValue);
        //}
        //_operator.Location = txt_sectorName.Text;
        ////_operator.TCModel = txt_tcModel.Text;

        //if (cbo_deviceContractID.SelectedValue != null)
        //{
        //    _operator.DeviceContractID = Convert.ToInt32(cbo_deviceContractID.SelectedValue);
        //}
        ////_operator.Status = txt_deviceStatus.Text;
        //_operator.DeviceNote = txt_deviceNote.Text;
        //if (txt_longitude.Text.Length > 0)
        //    _operator.Gis_X= txt_longitude.Text;
        //if (txt_latitude.Text.Length > 0)
        //    _operator.Gis_Y = txt_latitude.Text;
        ////if (imageFile.HasFile) {
        ////    string FileName = imageFile.FileName;
        ////    string FileType = System.IO.Path.GetExtension(FileName);
            
        ////    Match match = Regex.Match(FileType,"(jpg|png|gif|JPG|PNG|GIF)");
        ////    if (match.Success)
        ////    {
        ////        if (image.ImageUrl.Length > 0)
        ////        {
        ////            string existedFilename = System.IO.Path.GetFileName(image.ImageUrl);
        ////            System.IO.FileInfo file = new System.IO.FileInfo(ConfigurationManager.AppSettings["imageUploadFolder"] + existedFilename);
        ////            if (file.Exists)
        ////            {
        ////                file.Delete();
        ////            }
        ////        }
        ////        _operator.DevicePhoto = DateTime.Now.ToString("yyyyMMddHHmmss") + FileType;
        ////        string mappath = ConfigurationManager.AppSettings["imageUploadFolder"] + _operator.DevicePhoto;
        ////        imageFile.SaveAs(Server.MapPath(mappath));
        ////    }
        ////    else
        ////    {
        ////        ReDirect("上傳檔案格式錯誤");
        ////        return;
        ////    }
        ////}

        ////

        if (txt_Device_ID.Text.Length == 0)
        {
            ShowPageMsg("請輸入設備編號");
            return;
        }
        if (txt_Comm_Server_IP.Text.Length == 0)
        {
            ShowPageMsg("請輸入通訊伺服器IP");
            return;
        }
        if (txt_sectorName.Text.Length== 0)
        {
            ShowPageMsg("請輸入路口名稱");
            return;
        }
        if (txt_longitude.Text.Length == 0)
        {
            ShowPageMsg("請輸入經度資料");
            return;
        }
        if (txt_latitude.Text.Length==0)
        {
            ShowPageMsg("請輸入緯度資料");
            return;
        }
        if (cbo_region.SelectedValue == "null")
        {
            ShowPageMsg("請選擇地區");
            return;
        }
        if (cbo_DeviceModel.SelectedValue == "null")
        {
            ShowPageMsg("請選擇設備種類");
            return;
        }
        //if (txt_Attribute.Text.Length == 0)
        //{
        //    ShowPageMsg("請輸入屬性資料");
        //    return;
        //}
        //if (txt_Status.Text.Length == 0)
        //{
        //    ShowPageMsg("請輸入狀態");
        //    return;
        //}
        //if (txt_Receive_Port.Text.Length == 0)
        //{
        //    ShowPageMsg("請輸入接收Port");
        //    return;
        //}
        //if (txt_Remote_IP.Text.Length == 0)
        //{
        //    ShowPageMsg("請輸入遠端IP");
        //    return;
        //}
        //if (txt_Remote_Port.Text.Length == 0)
        //{
        //    ShowPageMsg("請輸入遠端Port");
        //    return;
        //}
        //if (txt_Phone_Number.Text.Length == 0)
        //{
        //    ShowPageMsg("請輸入電話號碼");
        //    return;
        //}
        //if (txt_Equipment_ID.Text.Length == 0)
        //{
        //    ShowPageMsg("請輸入設備ID");
        //    return;
        //}
        if (hidden_Action.Value.Equals("add"))
        {
            SQLDB _operator = new SQLDB();
            DataSet ds_add = _operator.Select("1=0", "", "Device_Config");
            DataRow dr = ds_add.Tables[0].NewRow();
            dr["Device_ID"] = txt_Device_ID.Text;
            if (cbo_region.SelectedValue != "null")
            {
                dr["Area_ID"] = Convert.ToInt32(cbo_region.SelectedValue);
            }
            dr["Comm_Server_IP"] = txt_Comm_Server_IP.Text;
            dr["Device_Kind"] = cbo_DeviceModel.SelectedItem.Text;
            dr["DeviceModel"] = cbo_DeviceModel.SelectedValue;
            dr["Location"] = txt_sectorName.Text;
            if (cbo_deviceContractID.SelectedValue != "null")
            {
                dr["DeviceContractID"] = cbo_deviceContractID.SelectedValue;
            }
            dr["Gis_X"] = txt_longitude.Text;
            dr["Gis_Y"] = txt_latitude.Text;
            //dr["Equipment_ID"] = txt_Equipment_ID.Text;
            //dr["Attribute"] = txt_Attribute.Text;
            //dr["Status"] = txt_Status.Text;
            //dr["Receive_Port"] = Convert.ToInt32(txt_Receive_Port.Text);
            //dr["Remote_IP"] = txt_Remote_IP.Text;
            //dr["Remote_Port"] = Convert.ToInt32(txt_Remote_Port.Text);
            //dr["Phone_Number"] = txt_Phone_Number.Text;
            ds_add.Tables[0].Rows.Add(dr);
            DataSet DSChange = ds_add.GetChanges();
            if (_operator.Insert(DSChange))
            {
                ReDirect("新增成功");
                UpdateServerData();
            }
            else
            {
                ShowPageMsg("新增失敗");
            }
        }
        else if (hidden_Action.Value.Equals("edit"))
        {
            bool suc = false;

            //第一種方法，直接GetChange

            DataSet ds = _operator.Select("Device_ID = '" + hidden_Device_ID.Value + "'", "", "Device_Config");
            if (ds != null)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                dr["Device_ID"] = txt_Device_ID.Text;
                dr["Comm_Server_IP"] = txt_Comm_Server_IP.Text;
                //dr["DeviceModel"] = _operator.DeviceModel;
                dr["Area_ID"] = cbo_region.SelectedValue;
                dr["Location"] = txt_sectorName.Text;
                //dr["TCModel"] = _operator.TCModel;
                dr["DeviceContractID"] = cbo_deviceContractID.SelectedValue;
                //dr["Status"] = _operator.Status;
                //dr["DeviceNote"] = _operator.DeviceNote;
                dr["Gis_X"] = txt_longitude.Text;
                dr["Gis_Y"] = txt_latitude.Text;
                //if(imageFile.HasFile)
                //    dr["DevicePhoto"] = _operator.DevicePhoto;
                //dr["Equipment_ID"] = txt_Equipment_ID.Text;
                //dr["Attribute"] = txt_Attribute.Text;
                //dr["Status"] = txt_Status.Text;
                //dr["Receive_Port"] = Convert.ToInt32(txt_Receive_Port.Text);
                //dr["Remote_IP"] = txt_Remote_IP.Text;
                //dr["Remote_Port"] = Convert.ToInt32(txt_Remote_Port.Text);
                //dr["Phone_Number"] = txt_Phone_Number.Text;
                dr["Device_Kind"] = cbo_DeviceModel.SelectedItem.Text;
                dr["DeviceModel"] = cbo_DeviceModel.SelectedValue;
                DataSet DSChange = ds.GetChanges(DataRowState.Modified);
                suc = _operator.Update(DSChange);

            }


            //第二種方法，直接傳資料給class檔，至資料庫抓資料再更新
            //_operator.Breakdown_Type_ID = Convert.ToInt32(hidden_BreakDown_Type_ID.Value);
            //_operator.Breakdown_Type = txt_BreakDown_Type.Text.Trim();
            //suc = _operator.EditBreakDownType(_operator);
            if (suc)
            {
                ReDirect("修改成功");
                UpdateServerData();
            }
            else
            {
                ShowPageMsg("修改失敗");
            }
        }
    }
}



#line default
#line hidden
