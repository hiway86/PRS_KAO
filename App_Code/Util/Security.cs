using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Security.Cryptography;




/// <summary>
/// Security 的摘要描述
/// </summary>
public class Security : SQLDB
{
    public string SystemFolderName
    {
        get;
        set;
    }

    public string ProgramName
    {
        get;
        set;
    }

    public bool EnableBrowser
    {
        get;
        set;
    }

    public bool EnableQuery
    {
        get;
        set;
    }

    public bool EnableAdd
    {
        get;
        set;
    }

    public bool EnableEdit
    {
        get;
        set;
    }

    public bool EnableDelete
    {
        get;
        set;
    }

    public bool EnablePrint
    {
        get;
        set;
    }

    public bool EnableEditSave
    {
        get;
        set;
    }

    public bool EnableNewSave
    {
        get;
        set;
    }

    public Security()
	{
        this.dbKey = "MROS";
        this.tableName = "View_Authority";
	}

    public DataTable GetAuthority(string _userID)
    {
        DataTable dt = null;
        try
        {
            dt = this.SelectQuery("SELECT System_Folder_Name, Program_Name, Enable_Browser, Enable_Query, Enable_Add, Enable_Edit, Enable_Delete, Enable_Print, Enable_Edit_Save, Enable_New_Save FROM View_Authority WHERE User_ID = '" + _userID + "'").Tables[0];
        }
        catch
        {
            dt = null;
        }

        return dt;
    }

    public Hashtable GetPageAuthority(string _userID)
    {
        Hashtable ht = new Hashtable();
        try
        {
            DataTable dt = GetAuthority(_userID);
            foreach (DataRow dr in dt.Rows)
            {
                Security sec = new Security();
                sec.SystemFolderName = dr["System_Folder_Name"].ToString();
                sec.ProgramName = dr["Program_Name"].ToString();
                sec.EnableBrowser = Convert.ToBoolean(dr["Enable_Browser"]);
                sec.EnableQuery = Convert.ToBoolean(dr["Enable_Query"]);
                sec.EnableAdd = Convert.ToBoolean(dr["Enable_Add"]);
                sec.EnableEdit = Convert.ToBoolean(dr["Enable_Edit"]);
                sec.EnableDelete = Convert.ToBoolean(dr["Enable_Delete"]);
                sec.EnablePrint = Convert.ToBoolean(dr["Enable_Print"]);
                sec.EnableEditSave = Convert.ToBoolean(dr["Enable_Edit_Save"]);
                sec.EnableNewSave = Convert.ToBoolean(dr["Enable_New_Save"]);
                if (!ht.ContainsKey(sec.ProgramName))
                {
                    ht.Add(sec.ProgramName, sec);
                }
            }
        }
        catch
        {
        }

        return ht;
    }

    public string GetStaffID(string _userID, string _password)
    {
        DataTable dt = new DataTable();

        _userID = _userID.Replace("1=1", "BADSTRING!@").Trim();
        _userID = _userID.Replace("--", "BADSTRING!@").Trim();
        _password = _password.Replace("1=1", "BADSTRING!@").Trim();
        _password = _password.Replace("--", "BADSTRING!@").Trim();
        
        /*
        var utf8 = Encoding.UTF8;
        byte[] utfBytes = utf8.GetBytes(_password);
        _password = utf8.GetString(utfBytes, 0, utfBytes.Length);                      
        */

        Users user = new Users();
        string encrypPassword = user.GetEncryptPassword(_password);

        string staffID = "";
        //string encrypPassword = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(_password, "SHA1").ToLower();

        try
        {
            dt = this.SelectQuery("SELECT TOP 1 * FROM View_Authority WHERE User_ID = '" + _userID + "' AND Status = 'True'").Tables[0];
        }
        catch
        {
            dt = null;
        }

        foreach (DataRow dr in dt.Rows)
        {
            if (dr["User_Password"].ToString().Equals(encrypPassword))
            {
                staffID = dr["User_ID"].ToString();
            }
        }
        return staffID;

    }

    public List<Menu> GetAllMenu(string _staffID)
    {
        List<Menu> list = null;
        DataSet ds = this.SelectQuery("SELECT * FROM View_Authority WHERE User_ID = '" + _staffID + "' AND Enable_Browser = 1 ORDER BY System_Group_ID, Program_Order");
        if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
        {
            list = new List<Menu>();
            DataTable dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                Menu menu = new Menu();
                menu.System_Group_ID = row["System_Group_ID"].ToString();
                menu.System_Group_Name = row["System_Group_Name"].ToString();
                menu.System_Folder_Name = row["System_Folder_Name"].ToString();
                menu.Program_Name = row["Program_Name"].ToString();
                menu.Program_CName = row["Program_CName"].ToString();
                list.Add(menu);
            }

        }
        return list;
    }

    public List<Menu> GetSystemGroupMenu(string _systemGroup, string _staffid)
    {
        List<Menu> list = null;
        DataSet ds = this.SelectQuery("SELECT DISTINCT Program_Name, Program_CName, System_Group_ID, System_Group_Name, System_Folder_Name, Program_Order FROM View_Authority WHERE System_Folder_Name = '" + _systemGroup + "' AND Enable_Browser = 1 AND Staff_ID = '" + _staffid + "' ORDER BY Program_Order");
        if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
        {
            list = new List<Menu>();
            DataTable dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                Menu menu = new Menu();
                menu.System_Group_ID = row["System_Group_ID"].ToString();
                menu.System_Group_Name = row["System_Group_Name"].ToString();
                menu.System_Folder_Name = row["System_Folder_Name"].ToString();
                menu.Program_Name = row["Program_Name"].ToString();
                menu.Program_CName = row["Program_CName"].ToString();
                list.Add(menu);
            }

        }
        return list;
    }

    public DataSet GetCompanyScope(string _staffID)
    {
        DataSet ds = null;
        try
        {
            ds = this.SelectQuery("SELECT * FROM View_Company_Scope WHERE Staff_ID = '" + _staffID + "'");
        }
        catch
        {
            ds = null;
        }

        return ds;
    }

    public DataSet GetCompanyDetailScope(string _staffID)
    {
        DataSet ds = null;
        try
        {
            ds = this.SelectQuery("SELECT * FROM View_Company_Detail_Scope WHERE Company_ID IN (SELECT Company_ID FROM View_Company_Scope WHERE Staff_ID = '" + _staffID + "')");
        }
        catch
        {
            ds = null;
        }

        return ds;
    }

    public bool SaveLog(string userid, string action, string target, string info, string createuser)
    {
        if (createuser == null || createuser.Length == 0)
        {
            createuser = "System";
        }
        string sql = "INSERT INTO System_Log (User_ID, Action, Target, Info, Time, Create_User) Values ('" + userid + "','" + action + "','" + target + "','" + info + "', GETDATE(), '" + createuser + "');";
        return this.ExecuteStatement(sql);
    }


    /// <summary>
    /// 更新登入者密碼
    /// </summary>
    /// <returns>true:更新成功；false:更新失敗</returns>
    public bool Updateuserpwd(string userid, string pwd)
    {
        bool success = false;
        if (userid == null || userid.Length == 0 || pwd == null || pwd.Length == 0)
        {
             success=false;
        }
        else
        {
            Users user = new Users();
            string encrypPassword = user.GetEncryptPassword(pwd);      
            string sql = "UPDATE Users SET User_Password='" + encrypPassword + "' ,Update_Time = getdate() WHERE User_ID='" + userid + "'";
             success=this.ExecuteStatement(sql);

        }
        return success;
    }


}
