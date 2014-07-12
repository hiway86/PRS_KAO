#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\App_Code\Entity\MIS\User.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "32C1AC07C8DA265DD0651525632CC8977BCCF64F"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\App_Code\Entity\MIS\User.cs"
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
/// User 的摘要描述
/// </summary>
public class Users : SQLDB
{

    public Users()
    {
        this.tableName = "Users";
    }

    public string User_ID
    {
        get;
        set;
    }

    public string User_Name
    {
        get;
        set;
    }

    public string User_Password
    {
        get;
        set;
    }

    public bool Status
    {
        get;
        set;
    }

    public DateTime Create_Time
    {
        get;
        set;
    }

    public DateTime Update_Time
    {
        get;
        set;
    }
    public int DepartmentID { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime Expire_Time { get; set; }


    public bool Add()
    {
        DataSet DS = this.Select("1 <> 1");
        //
        DataRow DR = DS.Tables[0].NewRow();
        //
        DR["User_ID"] = this.User_ID;
        DR["User_Name"] = this.User_Name;
        DR["User_Password"] = this.User_Password;
        DR["Status"] = this.Status;
        DR["Create_Time"] = this.Create_Time;
        DR["DepartmentID"] = this.DepartmentID;
        DR["Phone"] = this.Phone;
        DR["Email"] = this.Email;
        //
        DS.Tables[0].Rows.Add(DR);
        //
        DataSet DSChange = DS.GetChanges();
        return Insert(DSChange);
    }

    public string GetEncryptPassword(string password)
    {
        return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1").ToLower();
    }

    public bool SavePassword(string userid, string password)
    {
        bool suc = false;
        DataSet ds = this.Select("User_ID = '" + userid + "'");
        try
        {
            ds.Tables[0].Rows[0]["User_Password"] = GetEncryptPassword(password);
            if (ds.GetChanges() != null)
            {
                this.Update(ds.GetChanges());
            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    public bool EditUser(Users u)
    {

        bool suc = false;
        string rowFilter = "User_ID = '" + u.User_ID + "'";
        DataSet ds = this.Select(rowFilter, "", u.tableName);
        if (ds.Tables[0].Rows.Count == 1)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            if (this.User_ID != null)
            {
                dr["User_ID"] = this.User_ID;
            }
            if (this.DepartmentID != null)
            {
                dr["DepartmentID"] = this.DepartmentID;
            }
            if (this.User_Name != null)
            {
                dr["User_Name"] = this.User_Name;
            }

            if (this.User_Password != null)
            {
                dr["User_Password"] = this.User_Password;
            }
            if (this.Phone != null)
            {
                dr["Phone"] = this.Phone;
            }
            if (this.Email != null)
            {
                dr["Email"] = this.Email;
            }
            if (this.Status != null)
            {
                dr["Status"] = this.Status;
            }
            if (this.Create_Time != null)
            {
                dr["Create_Time"] = this.Create_Time;
            }
            if (this.Update_Time != null)
            {
                dr["Update_Time"] = this.Update_Time;
            }
            if (this.Expire_Time != null)
            {
                dr["Expire_Time"] = this.Expire_Time;
            }

            DataSet DSChange = ds.GetChanges(DataRowState.Modified);
            suc = this.Update(DSChange);
        }

        return suc;
    }
    public bool SaveStatus(string userid, string status)
    {
        bool suc = false;
        DataSet ds = this.Select("User_ID = '" + userid + "'");
        try
        {
            ds.Tables[0].Rows[0]["Status"] = status;
            if (ds.GetChanges() != null)
            {
                this.Update(ds.GetChanges());
            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}

#line default
#line hidden
