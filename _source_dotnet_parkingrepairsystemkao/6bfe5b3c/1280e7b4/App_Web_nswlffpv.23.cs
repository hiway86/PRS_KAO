#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\MIS\ContractManage.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "599B240FA9AA3BCE9538FDFB033611C3906E61A0"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\MIS\ContractManage.aspx.cs"
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class MIS_ContractManage : PageBase
{
    protected SQLDB contract = new SQLDB("Contract");
    DataSet contractDS;
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

                    if (hidden_Action.Value.Equals("add"))
                    {
                        txt_contractId.Enabled = false;
                        BtnEdit("新增存檔");
                        FieldEdit(true);
                    }
                    else if (hidden_Action.Value.Equals("edit"))
                    {
                        if (Request.QueryString["id"] != null)
                        {
                            hidden_EquipmentKindId.Value = Request.QueryString["id"].Trim();
                            //
                            if (LoadData())
                            {
                                txt_contractId.Enabled = false;
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
        ShowMsgAndRedirect(UpdatePanel1, msg, "../MIS/ContractList.aspx");
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
        SQLDB companyDB = new SQLDB("Company");
        DataSet companyDS = companyDB.Select("1=1");
        DataTable companyDT = companyDS.Tables[0];
        foreach (DataRow companyData in companyDT.Rows) {
            ListItem company = new ListItem();
            company.Value = companyData["CompanyID"].ToString();
            company.Text = companyData["CompanyName"].ToString();
            ddl_company.Items.Add(company);
        }

    }

    protected void FieldEdit(bool val)
    {

    }


    protected bool LoadData()
    {
        FieldEdit(false);
        bool suc = false;
        string rowfilter = "ContractId=" + hidden_EquipmentKindId.Value;

        //直接去資料庫抓
        contractDS = contract.Select(rowfilter);

        if (contractDS.Tables[0].Rows.Count == 1)
        {
            DataTable dt = contractDS.Tables[0];
            DataRow dr = dt.Rows[0];

            txt_contractId.Text = dr["ContractID"].ToString();
            txt_contractNum.Text = dr["ContractNum"].ToString();
            txt_contractName.Text = dr["ContractName"].ToString();
            txt_contractShortName.Text = dr["ContractShortName"].ToString();
            txt_subContractName.Text = dr["SubContractName"].ToString();
            ddl_company.SelectedValue = dr["Company"].ToString();
            txt_contractStartDate.Text = dr["ContractStartDate"].ToString();
            txt_contractEndDate.Text = dr["ContractEndDate"].ToString();
            txt_note.Text = dr["Note"].ToString();
            //ddl_display.SelectedValue = dr["display"].ToString();

            Session["DS_Mis"] = contractDS;
            suc = true;
        }
        return suc;
    }

    public void UpdateServerData()
    {
        Application["App_Mis_Contract"] = CommonLib.GetContract();
    }

    protected void txt_Car_Licence_Exp_TextChanged(object sender, EventArgs e)
    {

    }
    protected void cmd_Save_Click1(object sender, EventArgs e)
    {
        if (txt_contractNum.Text.Length == 0)
        {
            ShowPageMsg("請輸入合約編號");
            return;
        }
        if (txt_contractName.Text.Length == 0)
        {
            ShowPageMsg("請輸入合約名稱");
            return;
        }
        if (txt_contractShortName.Text.Length == 0)
        {
            ShowPageMsg("請輸入合約簡稱");
            return;
        }
        if (ddl_company.SelectedValue == "0")
        {
            ShowPageMsg("請選擇得標廠商");
            return;
        }
        if (txt_contractStartDate.Text.Length == 0)
        {
            ShowPageMsg("請選擇保固起始日");
            return;
        }
        if (txt_contractEndDate.Text.Length == 0)
        {
            ShowPageMsg("請選擇保固中止日");
            return;
        }
        DateTime start = Convert.ToDateTime(txt_contractStartDate.Text);
        DateTime end = Convert.ToDateTime(txt_contractEndDate.Text);
        if (DateTime.Compare( end, start) == -1)
        {
            ShowPageMsg("請選擇保固中止日不得小於保固起始日");
            return;
        }

        if (hidden_Action.Value.Equals("add"))
        {
            DataSet DS = new DataSet();
            DataTable DT = new DataTable("Contract");
            DT.Columns.Add("ContractId");
            DT.Columns.Add("ContractNum");
            DT.Columns.Add("ContractName");
            DT.Columns.Add("ContractShortName");
            DT.Columns.Add("SubContractName");
            DT.Columns.Add("Company");
            DT.Columns.Add("ContractStartDate");
            DT.Columns.Add("ContractEndDate");
            DT.Columns.Add("Note");
            DT.Columns.Add("Display");
            DS.Tables.Add(DT);
            DataRow DR = DS.Tables[0].NewRow();
            //DR["ContractId"] = contract.Select().Tables[0].Rows.Count + 1;
            DR["ContractNum"] = txt_contractNum.Text;
            DR["ContractName"] = txt_contractName.Text;
            DR["ContractShortName"] = txt_contractShortName.Text;
            DR["SubContractName"] = txt_subContractName.Text;
            DR["Company"] = ddl_company.SelectedValue.ToString();
            if (txt_contractStartDate.Text.Length > 0)
                DR["ContractStartDate"] = txt_contractStartDate.Text;
            else
                DR["ContractStartDate"] = "NULL";
            if (txt_contractEndDate.Text.Length > 0)
                DR["ContractEndDate"] = txt_contractEndDate.Text;
            else
                DR["ContractEndDate"] = "NULL";
            DR["Note"] = txt_note.Text;
            //DR["Display"] = ddl_display.SelectedValue;

            DS.Tables[0].Rows.Add(DR);
            DataSet _changed = DS.GetChanges();
            if (contract.Insert(_changed))
            {
                ReDirect("新增成功");
                UpdateServerData();
            }
            else
            {
                ReDirect("新增失敗");
            }
        }
        else if (hidden_Action.Value.Equals("edit"))
        {
            DataSet ds = (DataSet)Session["DS_Mis"];
            if (ds != null)
            {
                //ds.Tables[0].Rows[0]["ContractId"] = txt_contractId.Text;
                ds.Tables[0].Rows[0]["ContractNum"] = txt_contractNum.Text;
                ds.Tables[0].Rows[0]["ContractName"] = txt_contractName.Text;
                ds.Tables[0].Rows[0]["ContractShortName"] = txt_contractShortName.Text;
                ds.Tables[0].Rows[0]["SubContractName"] = txt_subContractName.Text;
                ds.Tables[0].Rows[0]["Company"] = ddl_company.SelectedValue.ToString();
                if(txt_contractStartDate.Text.Length > 0)
                    ds.Tables[0].Rows[0]["ContractStartDate"] = txt_contractStartDate.Text;
                if(txt_contractEndDate.Text.Length > 0)
                    ds.Tables[0].Rows[0]["ContractEndDate"] = txt_contractEndDate.Text;
                ds.Tables[0].Rows[0]["Note"] = txt_note.Text;
                //ds.Tables[0].Rows[0]["Display"] = ddl_display.SelectedValue;
                if (contract.Update(ds))
                {
                    ReDirect("修改成功");
                    UpdateServerData();
                }
                else
                {
                    ReDirect("修改失敗");
                }
            }
        }
    }
}


#line default
#line hidden
