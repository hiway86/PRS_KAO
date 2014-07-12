#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\App_Code\Entity\MIS\Equipment.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7AC9ACD4E51DA033EDE7A978021D737AB118A11E"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\App_Code\Entity\MIS\Equipment.cs"
using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Equipment 的摘要描述
/// </summary>
public class Equipment:SQLDB
{
    public string Device_ID { get; set; }    
    public int DeviceModel { get; set; }
    public int Area_ID { get; set; }
    public string Location { get; set; }
    public string TCModel { get; set; }
    public int DeviceContractID { get; set; }
    public string Status { get; set; }
    public string DeviceNote { get; set; }
    public string DevicePhoto { get; set; }
    public string Gis_X { get; set; }
    public string Gis_Y { get; set; }


	public Equipment()
	{
        this.tableName = "Device_Config";
	}

    public Equipment(string _tableName)
    {
        if (_tableName.Trim().Length > 0)
        {
            this.tableName = _tableName;
        }
        else
            this.tableName = "Device_Config";
    }

    /// <summary>
    /// 新增設備資料
    /// </summary>
    public bool Add()
    {
        //DataSet DS = new DataSet();
        //DataTable DT = new DataTable("Device_Config");

        //DT.Columns.Add("Device_ID");
        //DT.Columns.Add("DeviceModel");
        //DT.Columns.Add("Area_ID");
        //DT.Columns.Add("Location");
        //DT.Columns.Add("TCModel");
        //DT.Columns.Add("DeviceContractID");
        //DT.Columns.Add("Status");
        //DT.Columns.Add("DeviceNote");
        //DT.Columns.Add("Gis_X");
        //DT.Columns.Add("Gis_Y");
        //DT.Columns.Add("DevicePhoto");

        DataSet DS = new DataSet();
        DS = Select("1 =0", "", "Device_Config");
        //DS.Tables.Add(DT);
        DataRow DR = DS.Tables[0].NewRow();

        DR["Device_ID"]=this.Device_ID;
        DR["DeviceModel"]=this.DeviceModel;
        DR["Area_ID"]=this.Area_ID;
        DR["Location"]=this.Location;
        DR["TCModel"]=this.TCModel;
        DR["DeviceContractID"]=this.DeviceContractID;
        DR["Status"]=this.Status;
        DR["DeviceNote"]=this.DeviceNote;
        DR["Gis_X"] = this.Gis_X;
        DR["Gis_Y"] = this.Gis_Y;
        DR["DevicePhoto"]=this.DevicePhoto;

        DS.Tables[0].Rows.Add(DR);
        DataSet DSChange=DS.GetChanges();
        return Insert(DSChange);
    }

    public bool DelDevice(string deviceid)
    {
        return this.Delete("Device_ID=" + deviceid);
    }

    
    public bool EditDevice(Equipment equipment)
    {
        bool suc = false;
        string rowFilter = "Device_ID = " + equipment.Device_ID;
        DataSet ds = this.Select(rowFilter, "", equipment.tableName);
        if (ds.Tables[0].Rows.Count ==1)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            if (this.DeviceModel!=null)
            {
                dr["DeviceModel"] = this.DeviceModel;
            }
            if (this.Area_ID!=null)
            {
                dr["Area_ID"] = this.Area_ID;
            }
            if (this.Location!=null)
            {
                dr["Location"] = this.Location;
            }
           
            if (this.TCModel!=null)
            {
                dr["TCModel"] = this.TCModel;
            }
            if (this.DeviceContractID!=null)
            {
                dr["DeviceContractID"] = this.DeviceContractID;
            }
            if (this.Status!=null)
            {
                dr["Status"] = this.Status;
            }
            if (this.DeviceNote!=null)
            {
                dr["DeviceNote"] = this.DeviceNote;
            }
            if (this.Gis_X != null) {
                dr["Gis_X"] = this.Gis_X;
            }
            if (this.Gis_Y != null) {
                dr["Gis_Y"] = this.Gis_Y;
            }
            if (this.DevicePhoto!=null)
            {
                dr["DevicePhoto"] = this.DevicePhoto;
            }
          
            DataSet DSChange = ds.GetChanges(DataRowState.Modified);
            suc = this.Update(DSChange);
        }

        return suc;
    }






}


#line default
#line hidden
