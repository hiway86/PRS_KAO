#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\MIS\CompanyManage.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C0A7B1731B1B301E3E0145D56570D33D95F8FD70"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\MIS\CompanyManage.aspx.cs"
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MIS_CompanyManage : PageBase
{
    protected Company _operator = new Company();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ScriptManager1.IsInAsyncPostBack)
        {
            Session["DS_Mis"] = null;
            try
            {
                if (Request.QueryString["act"] != null)
                {
                    hidden_Action.Value = Request.QueryString["act"].Trim();
                    InitData();
                    //
                    if (hidden_Action.Value.Equals("add"))
                    {
                        txt_companyId.Enabled = false;
                        BtnEdit("新增存檔");
                        FieldEdit(true);
                    }
                    else if (hidden_Action.Value.Equals("edit"))
                    {
                        if (Request.QueryString["id"] != null)
                        {
                            hidden_companyId.Value = Request.QueryString["id"].Trim();
                            //
                            if (LoadData())
                            {
                                BtnEdit("修改存檔");
                                FieldEdit(false);
                            }
                            else
                            {
                                ReDirect("資料讀取錯誤!!");
                            }
                        }
                        else
                        {
                            ReDirect("參數錯誤!!");
                        }
                    }
                }
                else
                {
                    ReDirect("參數錯誤!!");
                }
            }
            catch (Exception ex)
            {
                ReDirect("異常錯誤發生!!");
            }

        }
    }

    protected void ReDirect(string msg)
    {
        ShowMsgAndRedirect(UpdatePanel1, msg, "../MIS/CompanyList.aspx");
    }

    protected void ShowPageMsg(string msg)
    {
        ShowMsg2(UpdatePanel1, msg);
    }

    protected void BtnEdit(string btnName)
    {
        bool visible = false;
        if (btnName.Trim().Length > 0)
        {
            visible = true;
        }
        cmd_Save.Visible = visible;
        cmd_Save.Text = btnName.Trim();
    }

    protected override void InitData()
    {
        BindDropDownListData(cbo_companyGoup, (DataSet)Application["App_Mis_CompanyGroup"], "CompanyGroupName", "CompanyGroupID");
    }

    protected void FieldEdit(bool val)
    {

    }

    protected bool LoadData()
    {
        FieldEdit(false);
        bool suc = false;
        string rowfilter = " CompanyID =  " + hidden_companyId.Value;

        //第一種方法：直接去資料庫抓

        DataSet ds2 = _operator.Select(rowfilter, "", "Company");
        if (ds2.Tables[0].Rows.Count == 1)
        {
            suc = true;
            DataTable dt = ds2.Tables[0];
            DataRow dr = dt.Rows[0];

            txt_companyId.Text = dr["CompanyID"].ToString();
            txt_companyName.Text = dr["CompanyName"].ToString();
            txt_contact.Text = dr["Contact"].ToString();
            txt_contactPhone.Text = dr["ContactPhone"].ToString();
            txt_contactPhoneExet.Text = dr["ContactPhoneExet"].ToString();
            txt_contactMobile.Text = dr["ContactMobile"].ToString();
            txt_contact2.Text = dr["Contact2"].ToString();
            txt_contact2Phone.Text = dr["Contact2Phone"].ToString();
            txt_contact2PhoneExet.Text = dr["Contact2PhoneExet"].ToString();
            txt_contact2Mobile.Text = dr["Contact2Mobile"].ToString();
            txt_fax.Text = dr["Fax"].ToString();
            txt_email.Text = dr["Email"].ToString();
            txt_address.Text = dr["Address"].ToString();
            if (dr["CompanyGroup"].ToString().Trim().Length > 0)
            {
                cbo_companyGoup.SelectedValue = dr["CompanyGroup"].ToString().Trim();
            }
            txt_note.Text = dr["Note"].ToString();
            Session["DS_Mis"] = ds2;
        }

        //第二種方法：從List中所存Session找出DataSset，再找出DataRow，但無法使用DS.GETChange，因為GetDataRow後之ds已被搜尋過
        /*
        DataSet ds = (DataSet)Session["DS_Mis"];
        DataRow dr = _operator.GetDataRow(ds, rowfilter);
        if (dr != null)
        {
            suc = true;
            txt_BreakDown_Type.Text = dr["BreakDown_Type"].ToString().Trim();
        }
         */
        return suc;
    }

    public void UpdateServerData()
    {
        Application["App_Mis_Company"] = CommonLib.GetCompany();
    }

    //public bool IsNumber(String strNumber)//判斷是否為數字
    //{
    //    Regex objNotNumberPattern = new Regex("[^0-9.-]");
    //    Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
    //    Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
    //    String strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
    //    String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
    //    Regex objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");

    //    return !objNotNumberPattern.IsMatch(strNumber) &&
    //    !objTwoDotPattern.IsMatch(strNumber) &&
    //    !objTwoMinusPattern.IsMatch(strNumber) &&
    //    objNumberPattern.IsMatch(strNumber);
    //}
    protected void txt_Car_Licence_Exp_TextChanged(object sender, EventArgs e)
    {

    }
    protected void cmd_Save_Click1(object sender, EventArgs e)
    {
        if (!Validate(txt_companyName.Text))
        {
             ShowPageMsg("請輸入廠商名稱");
            return;
        }
        //if (txt_companyName.Text.Length == 0)
        //{
        //    ShowPageMsg("請輸入廠商名稱");
        //    return;
        //}
        if (txt_email.Text.Length == 0)
        {
            ShowPageMsg("請輸入電子郵件");
            return;
        }
        if (txt_companyId.Text.Length > 0)
        {
            _operator.CompanyID = Convert.ToInt32(txt_companyId.Text);
        }
        _operator.CompanyName = txt_companyName.Text;
        _operator.Contact = txt_contact.Text;
        _operator.ContactPhone = txt_contactPhone.Text;
        _operator.ContactPhoneExet = txt_contactPhoneExet.Text;
        _operator.ContactMobile = txt_contactMobile.Text;
        _operator.Contact2 = txt_contact2.Text;
        _operator.Contact2Phone = txt_contact2Phone.Text;
        _operator.Contact2PhoneExet = txt_contact2PhoneExet.Text;
        _operator.Contact2Mobile = txt_contact2Mobile.Text;
        _operator.Email = txt_email.Text;
        _operator.Fax = txt_fax.Text;
        _operator.Address = txt_address.Text;
        if (cbo_companyGoup.SelectedIndex != 0)
        {
            _operator.CompanyGroup = Convert.ToInt32(cbo_companyGoup.SelectedValue);
        }
        _operator.Note = txt_note.Text;
        //
        if (hidden_Action.Value.Equals("add"))
        {
            if (_operator.Add())
            {
                ReDirect("新增成功");
                //UpdateServerData();
            }
            else
            {
                ShowPageMsg("新增失敗");
            }
        }
        else if (hidden_Action.Value.Equals("edit"))
        {
            bool suc = false;

            //第一種方法，直接GetChange

            DataSet ds = (DataSet)Session["DS_Mis"];
            if (ds != null)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                dr["CompanyID"] = _operator.CompanyID;
                dr["CompanyName"] = _operator.CompanyName;
                dr["Contact"] = _operator.Contact;
                dr["ContactPhone"] = _operator.ContactPhone;
                dr["ContactPhoneExet"] = _operator.ContactPhoneExet;
                dr["ContactMobile"] = _operator.ContactMobile;
                dr["Contact2"] = _operator.Contact2;
                dr["Contact2Phone"] = _operator.Contact2Phone;
                dr["Contact2PhoneExet"] = _operator.Contact2PhoneExet;
                dr["Contact2Mobile"] = _operator.Contact2Mobile;
                dr["Fax"] = _operator.Fax;
                dr["Email"] = _operator.Email;
                dr["Address"] = _operator.Address;
                dr["CompanyGroup"] = _operator.CompanyGroup;
                dr["Note"] = _operator.Note;

                DataSet DSChange = ds.GetChanges(DataRowState.Modified);
                suc = _operator.Update(DSChange);

            }


            //第二種方法，直接傳資料給class檔，至資料庫抓資料再更新
            //_operator.Breakdown_Type_ID = Convert.ToInt32(hidden_BreakDown_Type_ID.Value);
            //_operator.Breakdown_Type = txt_BreakDown_Type.Text.Trim();
            //suc = _operator.EditBreakDownType(_operator);
            if (suc)
            {
                ReDirect("修改成功");
                UpdateServerData();
            }
            else
            {
                ShowPageMsg("修改失敗");
            }
        }
    }
}


#line default
#line hidden
