#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\App_Code\Entity\System\UserRole.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E1CDE4AA5750CA355FB6769BBDC97E8D9582872B"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\App_Code\Entity\System\UserRole.cs"
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Bus 的摘要描述
/// 公車相關資訊
/// </summary>
public class UserRole : SQLDB
{

    //---------------------properity--------------------------//

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

    public string Status
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

    public string Role_ID
    {
        get;
        set;
    }

    public string Role_Name
    {
        get;
        set;
    }


    //--------------------------------------------------------------------//

    public UserRole()
    {
        //
        // TODO: Add constructor logic here
        //
       
        this.tableName = "User_Role";
    }

    public bool AddUser() 
    {
        bool suc = false;
        DataSet DS = this.SelectQuery("SELECT * FROM Users WHERE 1 <> 1", "Users");

        DataRow DR = DS.Tables[0].NewRow();

        DR["User_ID"] = this.User_ID;
        DR["User_Name"] = this.User_Name;
        DR["User_Password"] = this.User_Password;
        DR["Create_Time"] = DateTime.Now;
        DR["Status"] = this.Status;

        DS.Tables[0].Rows.Add(DR);

        DataSet DSChange = DS.GetChanges();

        suc = this.Insert(DSChange);
        return suc;
    }

    public bool AddUserRole()
    {
        bool suc = false;
        DataSet DS = this.SelectQuery("SELECT * FROM User_Role WHERE 1 <> 1", "User_Role");

        DataRow DR = DS.Tables[0].NewRow();

        DR["User_ID"] = this.User_ID;
        DR["Role_ID"] = this.Role_ID;

        DS.Tables[0].Rows.Add(DR);

        DataSet DSChange = DS.GetChanges();

        suc = this.Insert(DSChange);
        return suc;
    }


    public bool AddRole()   
    {
        bool suc = false;
        DataSet DS = this.SelectQuery("SELECT * FROM Role WHERE 1 <> 1", "Role");

        DataRow DR = DS.Tables[0].NewRow();

        DR["Role_ID"] = this.Role_ID;
        DR["Role_Name"] = this.Role_Name;

        DS.Tables[0].Rows.Add(DR);

        DataSet DSChange = DS.GetChanges();

        suc = this.Insert(DSChange);
        return suc;
    }

    public bool DeleteUser(string user_id)
    {
        bool success = true;
        string sql = "";
        try
        {
            //delete user
            sql = " DELETE FROM Users WHERE User_ID = '" + user_id + "' ";
            success = success && this.ExecuteStatement(sql);
            //delete user_role
            sql = " DELETE FROM User_Role WHERE User_ID = '" + user_id + "' ";
            this.ExecuteStatement(sql);
            //update staff
            sql = " UPDATE Staff SET User_ID = NULL WHERE User_ID = '" + user_id + "' ";
            this.ExecuteStatement(sql);
        }
        catch
        {
            success = false;
        }

        return success;
    }
    
    public bool DeleteRole(string role_id)
    {
        bool success = true;
        string sql = "";
        try
        {
            //delete user
            sql = " DELETE FROM Role WHERE Role_ID = '" + role_id + "' ";
            success = success && this.ExecuteStatement(sql);
            //delete user_role
            sql = " DELETE FROM User_Role WHERE Role_ID = '" + role_id + "' ";
            this.ExecuteStatement(sql);
        }
        catch
        {
            success = false;
        }

        return success;
    }

    /// <summary>
    /// 刪除User Role的資料
    /// </summary>
    public bool DeleteUserRole(string userid)
    {
        bool success = true;
        string sql = "";
        try
        {
            //delete user
            sql = " DELETE FROM User_Role WHERE User_ID = '" + userid + "' ";
            success = this.ExecuteStatement(sql);
        }
        catch
        {
            success = false;
        }

        return success;
    }
    
    /// <summary>
    /// 取得Role的資料
    /// </summary>
    public DataSet GetRole(string _rowFilter)
    {
        return this.Select(_rowFilter, "Role_ID", "Role");
    }

    /// <summary>
    /// 取得UserRole的資料
    /// </summary>
    /// 
    public DataSet GetUserRole(string rowfilter, string order)
    {
        string sql = "SELECT DISTINCT Role_ID, Role_Name,  User_Name, User_ID, User_Password, Status,phone,email,departmentid FROM View_Authority";
        if (rowfilter.Length > 0)
        {
            sql += " WHERE " + rowfilter;
        }
        if (order.Length > 0)
        {
            sql += " ORDER BY " + order;
        }
        else
        {
            sql += " ORDER BY Role_ID";
        }
        return this.SelectQuery(sql, "User_ID, Role_ID");
    }


    /// <summary>
    /// 取得View_Authority的資料
    /// </summary>
    public DataSet GetUserRoleByUser(string userid)
    {
        string sql = " SELECT distinct Role_ID, Role_Name,  CASE WHEN User_ID IS NULL THEN 'false' ELSE 'true' END AS Allow " +
                     " FROM view_authority " +
                     " where Role_ID is not null";
        return this.SelectQuery(sql, "User_Role");
    }

    public DataSet GetUserByID(string user_id)
    {
        return this.SelectQuery("SELECT * FROM Users WHERE User_ID = '" + user_id + "'", "Users");
    }
}


#line default
#line hidden
