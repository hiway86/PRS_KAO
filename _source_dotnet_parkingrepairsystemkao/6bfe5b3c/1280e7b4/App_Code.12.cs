#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\App_Code\WebService\MISWebService.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B63F86971781524FBC82B8C0654C1CB304F3B1B9"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\App_Code\WebService\MISWebService.cs"
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Script.Services;
using System.Web.Services;
using AjaxControlToolkit;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System;

/// <summary>
/// MISWebService 的摘要描述
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下一行。
[System.Web.Script.Services.ScriptService]
public class MISWebService : JSONWebService
{

    public MISWebService()
    {

        //如果使用設計的元件，請取消註解下行程式碼 
        //InitializeComponent(); 
    }

    /// <summary>
    /// 刪除使用者
    /// </summary>
    [WebMethod]
    public bool DelCompany(string companyid)
    {
        bool suc = false;
        Company _operator = new Company();
        suc = _operator.DelCompany(Convert.ToInt32(companyid));
        //return _operator.Delete(" Company_ID = " + Convert.ToInt32(companyid));
        if (suc)
        {
            Application["App_Mis_Company"] = CommonLib.GetCompany();
        }
        return suc;
    }

    /// <summary>
    /// 刪除耗材資料
    /// </summary>
    [WebMethod]
    public bool DelMaterial(string materialid)
    {
        bool suc = false;
        SQLDB _operator = new SQLDB();
        string deletestring = "DELETE ICS_Material where NO= '" + materialid + "'";
        suc = _operator.ExecuteStatement(deletestring);
        return suc;
    }

    /// <summary>
    /// 刪除專案資料
    /// </summary>
    [WebMethod]
    public bool DelProject(string projectno)
    {
        bool suc = false;
        SQLDB _operator = new SQLDB("ICS_Project");
        suc = _operator.Delete("ProjectNO='" + projectno + "'");
        //if (suc)
        //{
        //    Application["App_Mis_Company"] = CommonLib.GetCompany();
        //}
        return suc;
    }

    [WebMethod]
    public bool DelRole(string roleid)
    {
        bool suc = false;
        Role _operator = new Role();
        suc = _operator.DelRole(roleid);
        //return _operator.Delete(" Company_ID = " + Convert.ToInt32(companyid));
        if (suc)
        {
            Application["App_Role"] = CommonLib.GetRole();
        }
        return suc;
    }

    /// <summary>
    /// 刪除設備
    /// </summary>
    [WebMethod]
    public bool DelEquipment(string device_id)
    {
        bool suc = false;
        device_id = "'" + device_id + "'";
        Equipment _operator = new Equipment();
        suc = _operator.DelDevice(device_id);
        //return _operator.Delete(" Company_ID = " + Convert.ToInt32(companyid));
        if (suc)
        {
            Application["App_Mis_Equipment"] = CommonLib.GetDevice();
        }
        return suc;
    }

    /// <summary>
    /// 刪除合約
    /// </summary>
    [WebMethod]
    public bool DelContract(string contractId)
    {
        SQLDB contract = new SQLDB("Contract");
        bool suc = false;
        suc = contract.Delete("contractId = '" + contractId + "'");
        //return _operator.Delete(" Company_ID = " + Convert.ToInt32(companyid));
        if (suc)
        {
            Application["App_Mis_Contract"] = CommonLib.GetContract();
        }
        return suc;
    }

    /// <summary>
    /// 取得設備-用於自動完成
    /// </summary>
    [WebMethod]
    public string[] GetEquipment(string prefixText, int count)
    {
        SQLDB _operator = new SQLDB("Device");
        _operator.RowFilter = " Device_ID like '" + prefixText + "%'";
        DataSet ds = _operator.Select();
        int rowscount = ds.Tables[0].Rows.Count;

        if (rowscount >= count)
        {
            string[] returnstr = new string[count];
            for (int i = 0; i < count; i++)
                returnstr[i] = "'" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "'";

            return returnstr;
        }
        else
        {
            string[] returnstr = new string[rowscount];
            for (int i = 0; i < rowscount; i++)
                returnstr[i] = "'" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "'";

            return returnstr;
        }


    }

    /// <summary>
    /// 刪除地區
    /// </summary>
    [WebMethod]
    public bool DelRegion(string AreaID)
    {
        SQLDB contract = new SQLDB("Area_Data");
        bool suc = false;
        suc = contract.Delete("AreaID = '" + AreaID + "'");
        if (suc)
        {
            Application["App_Mis_Region"] = CommonLib.GetRegion();
        }
        return suc;
    }

    /// <summary>
    /// 刪除設備種類
    /// </summary>
    [WebMethod]
    public bool DelDevieKind(string DevieKindid)
    {
        SQLDB contract = new SQLDB("DeviceKind");
        bool suc = false;
        suc = contract.Delete("DeviceKindId = '" + DevieKindid + "'");
        //if (suc)
        //{
        //    Application["App_Mis_Region"] = CommonLib.GetRegion();
        //}
        return suc;
    }

    /// <summary>
    /// 刪除維修通報資料
    /// </summary>
    [WebMethod]
    public bool DelWarrantyNotify(string caseid)
    {
        SQLDB contract = new SQLDB("WarrantyNotify");
        bool suc = false;
        suc = contract.Delete("CaseID = '" + caseid + "'");
        //if (suc)
        //{
        //    Application["App_Mis_Region"] = CommonLib.GetRegion();
        //}
        return suc;
    }

    ///// <summary>
    ///// 刪除場站
    ///// </summary>
    //[WebMethod]
    //public bool DelStation(string stationid)
    //{
    //    bool suc = false;
    //    Station _operator = new Station();
    //    suc = _operator.DelStation(Convert.ToInt32(stationid));
    //    if (suc)
    //    {
    //        Application["App_Mis_Station"] = CommonLib.GetStation();
    //    }
    //    return suc;
    //    //return _operator.Delete(" Station_ID = " + Convert.ToInt32(stationid));
    //}

    ///// <summary>
    ///// 刪除路線
    ///// </summary>
    //[WebMethod]
    //public bool DelRoute(string routeid)
    //{
    //    bool suc = false;
    //    Route _operator = new Route("Route");
    //    suc = _operator.DelRoute(Convert.ToInt32(routeid));
    //    if (suc)
    //    {
    //        Application["App_Mis_Route"] = CommonLib.GetRoute();
    //    }
    //    return suc;
    //    //return _operator.Delete(" Route_Group_ID = " + Convert.ToInt32(routegroupid));
    //}

    ///// <summary>
    ///// 刪除路線群組
    ///// </summary>
    //[WebMethod]
    //public bool DelRouteGroup(string routegroupid)
    //{
    //    bool suc = false;
    //    Route _operator = new Route("Route_Group");
    //    suc = _operator.DelRouteGroup(Convert.ToInt32(routegroupid));
    //    if (suc)
    //    {
    //        Application["App_Mis_RouteGroup"] = CommonLib.GetRouteGroup();
    //    }
    //    return suc;
    //    //return _operator.Delete(" Route_Group_ID = " + Convert.ToInt32(routegroupid));
    //}

    //[WebMethod]
    //public bool DelStop(string stopid)
    //{
    //    bool suc = false;
    //    Stop _operator = new Stop("Stop");
    //    suc = _operator.DelStop(Convert.ToInt32(stopid));
    //    if (suc)
    //    {
    //        Application["App_Mis_Stop"] = CommonLib.GetStop();
    //    }
    //    return suc;
    //    //return _operator.Delete(" Route_Group_ID = " + Convert.ToInt32(routegroupid));
    //}

    //[WebMethod]
    //public bool DelBus(string busid)
    //{
    //    bool suc = false;
    //    Bus _operator = new Bus("Bus");
    //    suc = _operator.DelBus(Convert.ToInt32(busid));
    //    if (suc)
    //    {
    //        Application["App_Mis_Bus"] = CommonLib.GetBus();
    //    }
    //    return suc;
    //}

    ///// <summary>
    ///// 刪除員工
    ///// </summary>
    //[WebMethod]
    //public bool DelStaff(string staffid)
    //{
    //    bool suc = false;
    //    Staff _operator = new Staff("Staff");
    //    suc = _operator.DelStaff(Convert.ToInt32(staffid));
    //    if (suc)
    //    {
    //        Application["App_Mis_Staff"] = CommonLib.GetStaff();
    //    }
    //    return suc;
    //}

    ///// <summary>
    ///// 刪除部門
    ///// </summary>
    //[WebMethod]
    //public bool DelDepartment(string departmentid)
    //{
    //    bool suc = false;
    //    Departments _operator = new Departments();
    //    suc = _operator.DelDepartment(Convert.ToInt32(departmentid));
    //    if (suc)
    //    {
    //        Application["App_Mis_Department"] = CommonLib.GetDepartment();
    //    }
    //    return suc;
    //}

    ///// <summary>
    ///// 刪除佈告欄
    ///// </summary>
    //[WebMethod]
    //public bool DelBBS(string msgid)
    //{
    //    bool suc = false;
    //    BBS _operator = new BBS();
    //    suc = _operator.DelBBS(Convert.ToInt32(msgid));
    //    return suc;
    //}

    //[WebMethod]
    //public string[] GetStop(string prefixText, int count)
    //{
    //    SQLDB m_temp = new SQLDB("TKT_Month_Stop");
    //    //m_temp.RowFilter = "Stop_Name like '%" + prefixText + "%'";

    //    DataSet ds = m_temp.Select("Stop_Name like '%" + prefixText + "%'");
    //    int rowscount = ds.Tables[0].Rows.Count;
    //    if (rowscount > count)
    //    {
    //        rowscount = count;
    //    }
    //    string[] returnstr = new string[rowscount];

    //    for (int i = 0; i < rowscount; i++)
    //    {
    //        returnstr[i] = ds.Tables[0].Rows[i]["Stop_Name"].ToString().Trim();
    //    }
    //    return returnstr;
    //}
}



#line default
#line hidden
