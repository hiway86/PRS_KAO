#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\App_Code\Util\CommonLib.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "72994ED02D236733103B27A8394B95F8A2A8DCDA"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\App_Code\Util\CommonLib.cs"
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Timers;
using System.Collections;

/// <summary>
/// CommonLib 的摘要描述
/// </summary>
public class CommonLib
{
	public CommonLib()
	{

	}

    //取得廠商資料
    public static DataSet GetCompany()
    {
        SQLDB db = new SQLDB("Company");
        return db.Select();
    }

    //取得廠商群組資料
    public static DataSet GetCompanyGroup()
    {
        SQLDB db = new SQLDB("CompanyGroup");
        return db.Select();
    }

    //取得設備資料
    public static DataSet GetDevice()
    {
        SQLDB db = new SQLDB("View_DeviceConfig");
        return db.Select();
    }

    public static DataSet GetRegion()
    {
        SQLDB db = new SQLDB("Region");
        return db.Select();
    }

    public static DataSet GetArea()
    {
        SQLDB db = new SQLDB("Area_Data");
        return db.Select();
    }

    public static DataSet GetDeviceModel()
    {
        SQLDB db = new SQLDB("DeviceModel");
        return db.Select();
    }

    //取得設備合約資料
    public static DataSet GetContract()
    {
        SQLDB db = new SQLDB("Contract");
        return db.Select();
    }

    //取得案件通報資料
    public static DataSet GetWarrantyNotify()
    {
        SQLDB db = new SQLDB("WarrantyNotify");
        return db.Select();
    }

    //取得系統角色
    public static DataSet GetRole()
    {
        SQLDB db = new SQLDB("Role");
        return db.Select();
    }

    //取得計畫資料
    public static DataSet GetProject()
    {
        SQLDB db = new SQLDB("ICS_Project");
        return db.Select();
    }

    //取得物料管理物料
    public static DataSet GetICSMaterial()
    {
        SQLDB db = new SQLDB("ICS_Material");
        return db.Select();
    }

    //取得耗材種類資料
    public static DataSet GetMaterialType()
    {
        SQLDB db = new SQLDB("ICS_Material_Type");
        return db.Select();
    }
}


#line default
#line hidden
