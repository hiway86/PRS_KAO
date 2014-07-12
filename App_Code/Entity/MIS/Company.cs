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
/// Company 的摘要描述
/// </summary>
public class Company : SQLDB
{
    public int CompanyID { set; get; }
    public string CompanyName { set; get; }
    public string Contact { set; get; }
    public string ContactPhone { set; get; }
    public string ContactPhoneExet { get; set; }
    public string ContactMobile { get; set; }
    public string Contact2 { get; set; }
    public string Contact2Phone { set; get; }
    public string Contact2PhoneExet { get; set; }
    public string Contact2Mobile { get; set; }
    public string Fax { get; set; }
    public string Email { get; set; }
    public string Address { set; get; }
    public int CompanyGroup { get; set; }
    public string Note { get; set; }


    public Company()
    {
        this.tableName = "Company";
    }
    public Company(string _tableName)
    {
        if (_tableName.Trim().Length > 0)
            this.tableName = _tableName;
        else
            this.tableName = "Company";
    }

    /// <summary>
    /// 新增公司
    /// </summary>
    public bool Add()
    {
        DataSet DS = new DataSet();
        DataTable DT = new DataTable("Company");
        //
        DT.Columns.Add("CompanyID");
        DT.Columns.Add("CompanyName");
        DT.Columns.Add("Contact");
        DT.Columns.Add("ContactPhone");
        DT.Columns.Add("ContactPhoneExet");
        DT.Columns.Add("ContactMobile");
        DT.Columns.Add("Contact2");
        DT.Columns.Add("Contact2Phone");
        DT.Columns.Add("Contact2PhoneExet");
        DT.Columns.Add("Contact2Mobile");
        DT.Columns.Add("Fax");
        DT.Columns.Add("Email");
        DT.Columns.Add("Address");
        DT.Columns.Add("CompanyGroup");
        DT.Columns.Add("Note");
        //
        DS.Tables.Add(DT);
        //
        DataRow DR = DS.Tables[0].NewRow();
        //
        //DR["CompanyID"] = this.CompanyID;
        DR["CompanyName"] = this.CompanyName;
        DR["Contact"] = this.Contact;
        DR["ContactPhone"] = this.ContactPhone;
        DR["ContactPhoneExet"] = this.ContactPhoneExet;
        DR["ContactMobile"] = this.ContactMobile;
        DR["Contact2"] = this.Contact2;
        DR["Contact2Phone"] = this.Contact2Phone;
        DR["Contact2PhoneExet"] = this.Contact2PhoneExet;
        DR["Contact2Mobile"] = this.Contact2Mobile;
        DR["Fax"] = this.Fax;
        DR["Email"] = this.Email;
        DR["Address"] = this.Address;
        DR["CompanyGroup"] = this.CompanyGroup;
        DR["Note"] = this.Note;
        //
        DS.Tables[0].Rows.Add(DR);
        //
        DataSet DSChange = DS.GetChanges();
        return Insert(DSChange);
    }

    /// <summary>
    /// 刪除公司
    /// </summary>
    public bool DelCompany(int companyid)
    {
        return this.Delete(" CompanyID = " + companyid);
    }

    /// <summary>
    /// 編輯公司
    /// </summary>
    public bool EditCompany(Company company)
    {
        bool suc = false;
        string rowFilter = " CompanyID = " + company.CompanyID;
        DataSet ds = this.Select(rowFilter, "", company.tableName);
        if (ds.Tables[0].Rows.Count == 1)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            if (company.CompanyName != null) { dr["Company_Name"] = company.CompanyName; };
            if (company.Contact != null) { dr["Contact"] = company.Contact; };
            if (this.ContactPhone!=null)
            {
                dr["ContactPhone"] = this.ContactPhone;
            }
            if (this.ContactPhoneExet!=null)
            {
                dr["ContactPhoneExet"] = this.ContactPhoneExet;
            }
            if (this.ContactMobile!=null)
            {
                dr["ContactMobile"] = this.ContactMobile;
            }
            if (this.Contact2!=null)
            {
                dr["Contact2"] = this.Contact2;
            }
            if (this.Contact2Phone!=null)
            {
                dr["Contact2Phone"] = this.Contact2Phone;
            }
            if (this.Contact2PhoneExet!=null)
            {
                dr["Contact2PhoneExet"] = this.Contact2PhoneExet;
            }
            if (this.Contact2Mobile!=null)
            {
                dr["Contact2Mobile"] = this.Contact2Mobile;
            }
            if (this.Fax!=null)
            {
                dr["Fax"] = this.Fax;
            }
            if (this.Address!=null)
            {
                dr["Address"] = this.Address;    
            }
            if (this.Email!=null)
            {
                dr["Email"] = this.Email;
            }
            if (this.CompanyGroup!=null)
            {
                dr["CompanyGroup"] = this.CompanyGroup;
            }
            if (this.Note!=null)
            {
                dr["Note"] = this.Note;
            }
            DataSet DSChange = ds.GetChanges(DataRowState.Modified);
            suc = this.Update(DSChange);
        }
        return suc;
    }


}
