#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\App_Code\Entity\MIS\Staff.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AE8216BC6375A07037AE09C41230DB844878F37C"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\App_Code\Entity\MIS\Staff.cs"
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
/// Staff 的摘要描述
/// 員工相關資訊
/// </summary>
public class Staff:SQLDB
{

    //---------------------properity--------------------------//

    public int Staff_ID
    {
        get;
        set;
    }
    public string Staff_Number
    {
        get;
        set;
    }
    public string User_ID
    {
        get;
        set;
    }

    public string Staff_Name
    {
        get;
        set;
    }

    public string Tel
    {
        get;
        set;
    }

    public string Tel2
    {
        get;
        set;
    }

    public string Mobile
    {
        get;
        set;
    }

    public string Mobile2
    {
        get;
        set;
    }

    public string Address
    {
        get;
        set;
    }

    public string Identify_ID
    {
        get;
        set;
    }

    public bool Gender
    {
        get;
        set;
    }

    public string Birthday
    {
        get;
        set;
    }

    public string Email
    {
        get;
        set;
    }

    public string Arrive_Date
    {
        get;
        set;
    }

    public string Employment_Date
    {
        get;
        set;
    }

    public string Separation_Date
    {
        get;
        set;
    }

    public string Emer_Contact
    {
        get;
        set;
    }

    public string Emer_Mobile
    {
        get;
        set;
    }

    public string Emer_Tel
    {
        get;
        set;
    }

    public int Department_ID
    {
        get;
        set;
    }

    public int Staff_Type_ID
    {
        get;
        set;
    }
    public int Company_ID
    {
        get;
        set;
    }
    public int Station_ID
    {
        get;
        set;
    }
    public string Route_Group_ID
    {
        get;
        set;
    }
    public int Education_ID
    {
        get;
        set;
    }

    public string School
    {
        get;
        set;
    }

    public string Exam
    {
        get;
        set;
    }

    public string Rank_ID
    {
        get;
        set;
    }

    public string Salary
    {
        get;
        set;
    }

    public string Car_Licence_ID
    {
        get;
        set;
    }

    public string Car_Licence_Exp
    {
        get;
        set;
    }

    public string Licence_ID
    {
        get;
        set;
    }

    public string Licence
    {
        get;
        set;
    }

    public string Staff_Status_ID
    {
        get;
        set;
    }

    public string Comment
    {
        get;
        set;
    }
    public int Runtask_Group_ID { get; set; }

    //--------------------------------------------------------------------//

    public Staff()
    {
        this.dbKey = "PTBus";
        this.tableName = "Staff";
    }

    public Staff(string _tablename)
    {
        if (_tablename.Length > 0)
        {
            this.tableName = _tablename;
        }
        else
            this.tableName = "Staff";
    }

    public bool Add()
    {
        bool suc = false;
        DataSet DS = this.Select("1<>1");

        DataRow DR = DS.Tables[0].NewRow();

        DR["Staff_ID"] = this.Staff_ID;
        DR["Staff_Name"] = this.Staff_Name;
        DR["Staff_Number"] = this.Staff_Number;
        DR["User_ID"] = this.User_ID;
        DR["Tel"] = this.Tel;
        DR["Tel2"] = this.Tel2;
        DR["Mobile"] = this.Mobile;
        DR["Mobile2"] = this.Mobile2;
        DR["Address"] = this.Address;
        DR["Identify_ID"] = this.Identify_ID;
        DR["Gender"] = this.Gender;
        DR["Birthday"] = this.Birthday;
        DR["Email"] = this.Email;
        DR["Arrive_Date"] = this.Arrive_Date;
        DR["Employment_Date"] = this.Employment_Date;
        DR["Separation_Date"] = this.Separation_Date;
        DR["Emer_Contact"] = this.Emer_Contact;
        DR["Emer_Mobile"] = this.Emer_Mobile;
        DR["Emer_Tel"] = this.Emer_Tel;
        DR["Company_ID"] = this.Company_ID;
        DR["Department_ID"] = this.Department_ID;
        DR["Staff_Type_ID"] = this.Staff_Type_ID;
        DR["Station_ID"] = this.Station_ID;
        DR["Education_ID"] = this.Education_ID;
        DR["School"] = this.School;
        DR["Exam"] = this.Exam;
        DR["Staff_ID"] = this.Staff_ID;
        DR["Rank_ID"] = this.Rank_ID;
        DR["Salary"] = this.Salary;
        DR["Car_Licence_ID"] = this.Car_Licence_ID;
        DR["Car_Licence_Exp"] = this.Car_Licence_Exp;
        DR["Licence_ID"] = this.Licence_ID;
        DR["Licence"] = this.Licence;
        DR["Staff_Status_ID"] = this.Staff_Status_ID;
        DR["Route_Group_ID"] = this.Route_Group_ID;
        DR["Runtask_Group_ID"] = this.Runtask_Group_ID;
        DR["Comment"] = this.Comment;

        DS.Tables[0].Rows.Add(DR);

        DataSet DSChange = DS.GetChanges();

        suc = this.Insert(DSChange);
        return suc;
    }

    public DataSet GetSearch(string name, string department, string type)
    {
        DataSet ds = null;
        string query = "SELECT a.*, b.Department_Name, c.Staff_Type, d.Education_Name, e.Rank_Name, f.Car_Licence_Name, g.Licence_Name, h.Staff_Status " +
                       "FROM Staff AS a LEFT OUTER JOIN Department AS b ON a.Department_ID = b.Department_ID LEFT OUTER JOIN Staff_Type AS c ON a.Staff_Type_ID = c.Staff_Type_ID " +
                       "LEFT OUTER JOIN Education AS d ON a.Education_ID = d.Education_ID LEFT OUTER JOIN Rank AS e ON a.Rank_ID = e.Rank_ID " +
                       "LEFT OUTER JOIN Car_Licence AS f ON a.Car_Licence_ID = f.Car_Licence_ID LEFT OUTER JOIN Licence AS g ON a.Licence_ID = g.Licence_ID " +
                       "LEFT OUTER JOIN Staff_Status AS h ON a.Staff_Status_ID = h.Staff_Status_ID ";

        string rowfilter = "";

        if (!name.Equals(""))
            rowfilter += " a.Staff_Name LIKE '%" + name + "%' AND ";
        if (!department.Equals("null"))
            rowfilter += " a.Department_ID = '" + department + "' AND ";
        if (!type.Equals("null"))
            rowfilter += " a.Staff_Type_ID = '" + type + "' AND ";

        if (rowfilter.Equals(""))
            ds = this.SelectQuery(query + " ORDER BY a.Staff_Status_ID ", "Staff");
        else
        {
            rowfilter = rowfilter.Substring(0, rowfilter.Length - 4);
            rowfilter = " where " + rowfilter;
            ds = this.SelectQuery(query + rowfilter + " ORDER BY a.Staff_Status_ID ", "Staff");
        }

        return ds;
    }

    public DataSet GetStaffByID(string staff_id)
    {
        return this.Select("Staff_ID = '" + staff_id + "'");
    }

    public Staff GetStaffLoginInfoByID(string staff_id)
    {
        Staff staff = new Staff();
        DataSet ds = this.Select("Staff_ID = '" + staff_id + "'");
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            staff.Staff_ID = Convert.ToInt32(dr["Staff_ID"]);
            staff.Staff_Name = dr["Staff_Name"].ToString();
            staff.Staff_Number = dr["Staff_Number"].ToString();
            staff.Staff_Status_ID = dr["Staff_Status_ID"].ToString();
            staff.Staff_Type_ID = Convert.ToInt32(dr["Staff_Type_ID"]);
            staff.Company_ID = Convert.ToInt32(dr["Company_ID"]);
            //staff.Station_ID = Convert.ToInt32(dr["Station_ID"]);
        }
        return staff;
    }

    public bool DelStaff(int staffid)
    {
        return this.Delete("Staff_ID = '" + staffid + "' ");
    }
}


#line default
#line hidden
