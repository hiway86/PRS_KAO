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
/// Role 的摘要描述
/// </summary>
public class Role: SQLDB
{

	public Role()
	{
        this.tableName = "Role";
	}
    public Role(string _tableName)
    {
        if (_tableName.Trim().Length > 0)
            this.tableName = _tableName;
        else
            this.tableName = "Role";
    }

    public string RoleID { get; set; }
    public string Role_Name { get; set; }

    public bool Add()
    {
        DataSet DS = new DataSet();
        DataTable DT = new DataTable("Role");
       
        DT.Columns.Add("Role_ID");
        DT.Columns.Add("Role_Name");
        DS.Tables.Add(DT);
        DataRow DR = DS.Tables[0].NewRow();
        //
        DR["Role_ID"] = this.RoleID;
        DR["Role_Name"] = this.Role_Name;
        DS.Tables[0].Rows.Add(DR);
        //
        DataSet DSChange = DS.GetChanges();
        return Insert(DSChange);
    }

    /// <summary>
    /// 刪除角色
    /// </summary>
    public bool DelRole(string role)
    {
        return this.Delete(" Role_ID = '" + role + "'");
    }

   

}
