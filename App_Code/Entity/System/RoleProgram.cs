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
public class RoleProgram : SQLDB
{

    //---------------------properity--------------------------//

    public string Role_ID
    {
        get;
        set;
    }

    public int Program_ID
    {
        get;
        set;
    }

    public bool Enable_Browser
    {
        get;
        set;
    }

    public bool Enable_Query
    {
        get;
        set;
    }

    public bool Enable_Add
    {
        get;
        set;
    }

    public bool Enable_Edit
    {
        get;
        set;
    }

    public bool Enable_Delete
    {
        get;
        set;
    }

    public bool Enable_Print
    {
        get;
        set;
    }

    public bool Enable_Edit_Save
    {
        get;
        set;
    }

    public bool Enable_New_Save
    {
        get;
        set;
    }
    //--------------------------------------------------------------------//

    public RoleProgram()
    {
        //
        // TODO: Add constructor logic here
        //
        this.dbKey = "PTBus";
        this.tableName = "Role_Program";
    }

    public bool UpdateRoleProgram(string role_id, string program_id, bool browser, bool query, bool add, bool edit, bool delete, bool print, bool edit_save, bool new_save)
    {
        string sql = " UPDATE Role_Program SET Enable_Browser = '" + browser + "', Enable_Query = '" + query + "', Enable_Add = '" + add + "', Enable_Edit = '" + edit + "', Enable_Delete = '" + delete + "', Enable_Print = '" + print + "' " +
                     " , Enable_Edit_Save = '" + edit_save + "', Enable_New_Save = '" + new_save + "' " +
                     " WHERE Role_ID = '" + role_id + "' AND Program_ID = '" + program_id + "' ";
        return this.ExecuteStatement(sql);
    }

    public bool AddRoleProgram(string role_id, string program_id, bool browser, bool query, bool add, bool edit, bool delete, bool print, bool edit_save, bool new_save)
    {
        string sql = " INSERT INTO Role_Program (Role_ID, Program_ID, Enable_Browser, Enable_Query, Enable_Add, Enable_Edit, Enable_Delete, Enable_Print, Enable_Edit_Save, Enable_New_Save) VALUES " +
                     " ('" + role_id + "','" + program_id + "','" + browser + "','" + query + "','" + add + "','" + edit + "','" + delete + "','" + print + "','" + edit_save + "','" + new_save + "') ";
        return this.ExecuteStatement(sql);
    }

    public bool DeleteRoleProgram(string role_id, string program_id)  //delete Role_Program where program_id not in Program and role_id not in Role
    {
        string sql = " DELETE FROM Role_Program WHERE Role_ID = '" + role_id + "' AND Program_Id = '" + program_id + "' ";
        return this.ExecuteStatement(sql);
    }

    public bool ClearRoleProgram()  //delete Role_Program where program_id not in Program and role_id not in Role
    {
        string sql = " DELETE FROM Role_Program WHERE Program_Id NOT IN (SELECT Program_ID FROM Program) OR Role_ID NOT IN (SELECT Role_ID FROM Role) ";
        return this.ExecuteStatement(sql);

    }

    /// <summary>
    /// 取得Role的資料
    /// </summary>
    public DataSet GetRole(string _rowFilter)
    {
        return GetRole(_rowFilter, "");
    }

    /// <summary>
    /// 取得Role的資料
    /// </summary>
    public DataSet GetRole(string rowfilter, string order)
    {
        string sql = "SELECT ur.User_ID, s.Staff_Name AS User_Name, ur.Role_ID, r.Role_Name FROM User_Role ur LEFT JOIN Staff s on ur.User_ID = s.User_ID LEFT JOIN Role r on ur.Role_ID = r.Role_ID";
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
        return this.SelectQuery(sql, "Role");
    }

    /// <summary>
    /// 取得Role的資料
    /// </summary>
    public DataSet GetRoleProgram(string rowfilter)
    {
        DataSet ds = null;
        string sql = "SELECT * FROM View_Role_Program";

        if (rowfilter.Length > 0)
        {
            sql += " WHERE " + rowfilter;
        }

        return this.SelectQuery(sql, "RoleProgram");
    }

    public bool UpdateRoleProgramBrowser(string role_id, string program_id, int browser)
    {
        string sql = " UPDATE Role_Program SET Enable_Browser = '" + browser + "' " +
                     " WHERE Role_ID = '" + role_id + "' AND Program_ID = '" + program_id + "' ";
        return this.ExecuteStatement(sql);
    }
}
