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

public partial class Report_NotificationConfirmWork : PageBase
{

    DataSet WarrantyNotifyDS;
    DataSet EquipmentDS;
    DataSet RegionDS;
    DataSet DeviceModeDS;
    DataSet ContractDS;
    DataSet CompanyDS;

    protected void Page_Load(object sender, EventArgs e)
    {
        WarrantyNotifyDS = (DataSet)Application["App_Report_WarrantyNotify"];
        EquipmentDS = (DataSet)Application["App_Mis_Equipment"];
        RegionDS = (DataSet)Application["App_Mis_Area"];
        DeviceModeDS = (DataSet)Application["App_Mis_DeviceModel"];
        ContractDS = (DataSet)Application["App_Mis_Contract"];
        CompanyDS = (DataSet)Application["App_Mis_Company"];
    }

    protected override void InitData()
    {

    }

    protected void RadioButtonList_gridviewSelectItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GridView1.PageIndex = 0;
        loadGridViewData();
    }

    protected void loadGridViewData()
    {
        DataTable dt = WarrantyNotifyDS.Tables[0];
        switch (RadioButtonList_gridviewSelectItem.SelectedIndex)
        {
            case 0:

                dt.DefaultView.RowFilter = "";
                this.GridView1.DataSource = dt.DefaultView;
                this.GridView1.DataBind();
                break;
            case 1:

                dt.DefaultView.RowFilter = "NotifyConfirm = 'false'";
                dt.DefaultView.Sort = " NotifyDate DESC";
                this.GridView1.DataSource = dt.DefaultView;
                this.GridView1.DataBind();
                break;
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridView1.PageIndex = e.NewPageIndex;
        loadGridViewData();
        
    }
    protected void Button_save_Click(object sender, EventArgs e)
    {
        if (this.TextBox_CaseID.Text.Trim().Equals(""))
        {
            ShowPageMsg("請先選擇資料!");
            return;
        }

        bool suc = false;
        //string rowfilter = " CaseID =  " + this.TextBox_CaseID.Text.Trim();
        WarrantyNotify wn = new WarrantyNotify();
        //DataSet ds = wn.Select(rowfilter, "", "WarrantyNotify");

        DataTable dt = WarrantyNotifyDS.Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataRow dr = dt.Rows[i];
            if (dr["CaseID"].Equals(int.Parse(this.TextBox_CaseID.Text)))
            {
                
                dr["NotifyConfirm"] = this.CheckBox_NotifyConfirm.Checked;
                dr["NotifyContact"] = this.TextBox_NotifyContact.Text.Trim();
                if (!this.TextBox_PhoneConfirmDate.Text.Trim().Equals(""))
                {
                    dr["PhoneConfirmDate"] = Convert.ToDateTime(this.TextBox_PhoneConfirmDate.Text.Trim());
                }
                if (!this.TextBox_FaxConfirmDate.Text.Trim().Equals(""))
                {
                    dr["FaxConfirmDate"] = Convert.ToDateTime(this.TextBox_FaxConfirmDate.Text.Trim());
                }
                if (!this.TextBox_EmailConfirmDate.Text.Trim().Equals(""))
                {
                    dr["EmailConfirmDate"] = Convert.ToDateTime(this.TextBox_EmailConfirmDate.Text.Trim());
                }
                if (!this.TextBox_Deadline.Text.Trim().Equals(""))
                {
                    dr["Deadline"] = Convert.ToDateTime(this.TextBox_Deadline.Text.Trim());
                }

                //WarrantyNotifyDS.Tables[0].AcceptChanges();
                DataSet DSChange = WarrantyNotifyDS.GetChanges(DataRowState.Modified);
                //DataSet DSChange = ds.GetChanges(DataRowState.Modified);
                suc = wn.Update(DSChange);
                break;
            }
        }
        if (suc)
        {
            loadGridViewData();
            ShowPageMsg("儲存成功!");
            
        }
        else
        {
            ShowPageMsg("儲存失敗!");
        }

    }
    protected void Button_outputPaperData_Click(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "gridviewSelect")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int pageIndex = GridView1.PageIndex;
            GridViewRow row = GridView1.Rows[index - (pageIndex * 5)];
            this.TextBox_CaseID.Text = row.Cells[2].Text;
            this.TextBox_DeviceID.Text = row.Cells[3].Text;
            
            this.TextBox_NotifyContact.Text = row.Cells[6].Text.Replace("&nbsp;","");
            this.TextBox_PhoneConfirmDate.Text = row.Cells[7].Text.Replace("&nbsp;", "");
            this.TextBox_FaxConfirmDate.Text = row.Cells[8].Text.Replace("&nbsp;", "");
            this.TextBox_EmailConfirmDate.Text = row.Cells[9].Text.Replace("&nbsp;", "");
            this.TextBox_Deadline.Text = row.Cells[10].Text.Replace("&nbsp;", "");

            if (row.Cells[5].Text.Equals("已確認"))
            {
                this.CheckBox_NotifyConfirm.Checked = true;
            }
            else
            {
                this.CheckBox_NotifyConfirm.Checked = false;
            }
            //this.CheckBox_NotifyConfirm.Checked = bool.Parse(row.Cells[5].Text);

        }
        else if (e.CommandName == "print")
        {
            string caseId =(string) e.CommandArgument;
            //ExportTOExcel(caseId);
        }
    }
    protected void ShowPageMsg(string msg)
    {
        ShowMsg2(UpdatePanel1, msg);
    }


    //private void ExportTOExcel(string caseId)
    //{

    //    ExcelReport report = null;

    //    try
    //    {
    //        report = new ExcelReport("MIS/WarrantyNotify");

    //        DataTable w_dt = WarrantyNotifyDS.Tables[0];
    //        DataRow[] w_drs = w_dt.Select("CaseID = " + caseId);
    //        DataRow w_dr = w_drs[0];

    //        //設備
    //        DataRow[] e_drs = EquipmentDS.Tables[0].Select("DeviceID = '" + (string)w_dr["DeviceID"] +"'");
    //        DataRow e_dr = e_drs[0];


    //        if (w_dr["CaseID"] .Equals( int.Parse(caseId)) )
    //        {
    //            report.FillData(2, 10, caseId, 1);  //列，行 //案件編號
    //            report.FillData(7, 3, (string)w_dr["DeviceID"], 1); //設備編號

    //            if (e_dr["DeviceModel"] != DBNull.Value)
    //            {
    //                //設備種類
    //                DataRow[] dm_drs = DeviceModeDS.Tables[0].Select("DeviceModelId = '" + e_dr["DeviceModel"] + "'");
    //                DataRow dm_dr = dm_drs[0];
    //                report.FillData(2, 2, (string)dm_dr["DeviceModel"], 1); //設備種類
    //            }

    //            if (w_dr["RepairDateOption"] != DBNull.Value)
    //            {
    //                int repairDateOption = (int)w_dr["RepairDateOption"]; //修復期限
    //                if (repairDateOption == 3)
    //                {
    //                    if (w_dr["repairDeadline"] != DBNull.Value)
    //                    {
    //                        DateTime repairDeadline = (DateTime)w_dr["repairDeadline"];
    //                        string s = repairDeadline.Year + "/" + repairDeadline.Month + "/" + repairDeadline.Day;
    //                        report.FillData(2, 4, "請於" + s + "前修復", 1);
    //                    }
    //                    else
    //                    {
    //                        report.FillData(2, 4, "請限期修復", 1);
    //                    }
                        
    //                }
    //                else
    //                {
    //                    report.FillData(2, 4, "請立即修復", 1);
    //                }
    //            }

    //            if (e_dr["Region"] != DBNull.Value)
    //            {
    //                //區域
    //                DataRow[] r_drs = RegionDS.Tables[0].Select("AreaID = '" + e_dr["Area_ID"] + "'");
    //                DataRow r_dr = r_drs[0];
    //                report.FillData(9, 3, (string)r_dr["RegionName"], 1); //地區
    //            }


    //            if (e_dr["SectorName"] != DBNull.Value)
    //            {
    //                report.FillData(11, 3, (string)e_dr["SectorName"], 1); //路口名稱
    //            }


    //            if (w_dr["WarrantyContract"] != DBNull.Value)
    //            {
    //                //合約
    //                DataRow[] c_drs = ContractDS.Tables[0].Select("ContractID = '" + w_dr["WarrantyContract"] + "'");
    //                DataRow c_dr = c_drs[0];
    //                report.FillData(14, 3, (string)c_dr["ContractName"], 1); //合約名稱
    //            }

    //            if (w_dr["FaultDescribe"] != DBNull.Value)
    //            {
    //                report.FillData(20, 3, (string)w_dr["FaultDescribe"], 1); //故障描述
    //            }
                



    //            int count = 1; //通知次數
    //            if (w_dr["ContractCombineNum"] != DBNull.Value)
    //            {
    //                //統計併案案件
    //                int contractCombineNum = (int)w_dr["ContractCombineNum"]; 
    //                DataRow[] w_drs_1 = w_dt.Select("ContractCombineNum = " + contractCombineNum, "ORDER BY NotifyDate ASC");
    //                string ss = "已於";
    //                count = count + 1 + w_drs_1.Length;
    //                for (int i = 0; i < w_drs_1.Length; i++)
    //                {
    //                    DataRow dr = w_drs_1[i];
    //                    DateTime dt = (DateTime)dr["NotifyDate"];
    //                    ss += dt.Month + "/" + dt.Day;
    //                    if (i != w_drs_1.Length - 1) ss += "、";
    //                }
    //                ss += "通知";
    //                report.FillData(17, 3, ss, 1); //案件通知說明

    //            }
    //            report.FillData(12, 9, "第 " + count + " 次通知", 1); //通知次數

    //            if (w_dr["NotifyDate"] != DBNull.Value)
    //            {
    //            DateTime _dt = (DateTime)w_dr["NotifyDate"];
    //            report.FillData(10, 9, _dt.Year+"/"+_dt.Month+"/"+_dt.Day, 1); //通知日期
    //            }



    //            if (w_dr["WarrantyCompany"] != DBNull.Value)
    //            {
    //                //廠商
    //                DataRow[] company_drs = CompanyDS.Tables[0].Select("CompanyName = '" + w_dr["WarrantyCompany"] + "'");
    //                DataRow company_dr = company_drs[0];
    //                if (company_dr["CompanyName"] != DBNull.Value) report.FillData(14, 10, (string)company_dr["CompanyName"], 1); //廠    商
    //                if (company_dr["Contact"] != DBNull.Value) report.FillData(15, 10, (string)company_dr["Contact"], 1); //聯 絡 人
    //                if (company_dr["ContactPhone"] != DBNull.Value) report.FillData(16, 10, (string)company_dr["ContactPhone"], 1); //聯絡電話
    //                if (company_dr["Fax"] != DBNull.Value) report.FillData(17, 10, (string)company_dr["Fax"], 1); //傳真號碼
    //            }


                


    //        }
            


    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "newprintwindow2", "open_new_window(\"../Temp/" + report.Report() + "\");", true);
    //    }
    //    catch (Exception e)
    //    {
    //        if (report != null)
    //        {
    //            ScriptManager.RegisterStartupScript(this, this.GetType(), "newprintwindow2", "open_new_window(\"../Temp/" + report.Report() + "\");", true);
    //        }
    //    }
    //    finally
    //    {
    //        try
    //        {
    //            report.Close();
    //        }
    //        catch (Exception ex)
    //        {
    //        }
    //    }


    //}

    //private string getDeviceClass(string deviceId)
    //{
    //    string s = deviceId.Substring(0, 1);
    //    if (s .Equals("s",StringComparison.CurrentCultureIgnoreCase))
    //    {
    //        return "TC";
    //    }
    //    else if (s.Equals("x", StringComparison.CurrentCultureIgnoreCase))
    //    {
    //        return "CMS";
    //    }
    //    else if (s.Equals("v", StringComparison.CurrentCultureIgnoreCase))
    //    {
    //        return "VD";
    //    }
    //    return "";
        
    //}



    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[5].Text.Equals("True"))
            {
                e.Row.Cells[5].Text = "已確認";
            }
            else 
            {
                e.Row.Cells[5].Text = "";
            }
    
        }
    }
}
