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
/// WarrantyNotify 保固通知資料表
/// </summary>
public class WarrantyNotify : SQLDB
{

    public int CaseID { get; set; }             //案件編號
    public string DeviceID { get; set; }           //設備編號
    public string FaultModel { get; set; }         //故障種類
    public string FaultDescribe { get; set; }      //故障描述
    public string RepeatNotify { get; set; }       //重複通知說明
    public string WarrantyCompany { get; set; }    //保固廠商
    public int WarrantyContract { get; set; }   //指定合約(保固合約)
    public DateTime NotifyDate  { get; set; }         //通知日期
    public int RepairDateOption { get; set; }   //修復期限選項
    public DateTime RepairDeadline { get; set; }     //修復限期
    public int ContractCombineNum { get; set; } //併案編號
    public bool NotifyConfirm { get; set; }      //通知確認
    public string NotifyContact { get; set; }      //確認窗口
    public DateTime PhoneConfirmDate { get; set; }   //電話確認時間
    public DateTime FaxConfirmDate { get; set; }   //Fax確認時間
    public DateTime EmailConfirmDate { get; set; }   //Email確認時間
    public DateTime Deadline { get; set; }           //即期催辦時間
    public bool FaxReply { get; set; }           //廠商傳真回覆
    public string ReplyContent { get; set; }       //廠商回覆內容
    public DateTime RepairDate { get; set; }         //實際修復日期
    public int CheckID { get; set; }            //查核出單編號
    public string Checker { get; set; }            //查核人
    public DateTime CheckTIme { get; set; }          //查核時間
    public bool CheckResult { get; set; }        //保固查核成果
    public string CheckDescribe { get; set; }      //保固查核說明
    public string Status { get; set; }             //執行狀態
    public string Note { get; set; }               // 備註
    public bool ControlStatus { get; set; }      // 列管狀態






	public WarrantyNotify()
	{
        this.tableName = "WarrantyNotify";
	}

    public WarrantyNotify(string _tableName)
    {
        if (_tableName.Trim().Length > 0)
        {
            this.tableName = _tableName;
        }
        else
            this.tableName = "WarrantyNotify";
    }

    /// <summary>
    /// 新增維修單，保固通知資料表
    /// </summary>
    /// <returns></returns>
    public bool Add()
    {
        DataSet DS = new DataSet();
        DataTable DT = new DataTable("WarrantyNotify");

        DT.Columns.Add("CaseID");
        DT.Columns.Add("DeviceID");
        DT.Columns.Add("FaultModel");
        DT.Columns.Add("FaultDescribe");
        DT.Columns.Add("RepeatNotify");
        DT.Columns.Add("WarrantyCompany");
        DT.Columns.Add("WarrantyContract");
        DT.Columns.Add("NotifyDate");
        DT.Columns.Add("RepairDateOption");
        DT.Columns.Add("RepairDeadline");
        DT.Columns.Add("ContractCombineNum");
        DT.Columns.Add("NotifyConfirm");
        DT.Columns.Add("NotifyContact");
        DT.Columns.Add("PhoneConfirmDate");
        DT.Columns.Add("FaxConfirmDate");
        DT.Columns.Add("EmailConfirmDate");
        DT.Columns.Add("Deadline");
        DT.Columns.Add("FaxReply");
        DT.Columns.Add("ReplyContent");
        DT.Columns.Add("RepairDate");
        DT.Columns.Add("CheckID");
        DT.Columns.Add("Checker");
        DT.Columns.Add("CheckTIme");
        DT.Columns.Add("CheckResult");
        DT.Columns.Add("CheckDescribe");
        DT.Columns.Add("Status");
        DT.Columns.Add("Note");
        DT.Columns.Add("ControlStatus");

        DS.Tables.Add(DT);
        DataRow DR = DS.Tables[0].NewRow();

        DR["CaseID"] = this.CaseID;
        DR["DeviceID"] = this.DeviceID;
        DR["FaultModel"] = this.FaultModel;
        DR["FaultDescribe"] = this.FaultDescribe;
        DR["RepeatNotify"] = this.RepeatNotify;
        DR["WarrantyCompany"] = this.WarrantyCompany;
        DR["WarrantyContract"] = this.WarrantyContract;
        DR["NotifyDate"] = this.NotifyDate;
        DR["RepairDateOption"] = this.RepairDateOption;
        if (this.RepairDateOption == 3)
        {
            DR["RepairDeadline"] = this.RepairDeadline;
        }
        
        DR["ContractCombineNum"] = this.ContractCombineNum;
        DR["NotifyConfirm"] = this.NotifyConfirm;
        //DR["NotifyContact"] = this.NotifyContact;
        //DR["PhoneConfirmDate"] = this.PhoneConfirmDate;
        //DR["Deadline"] = this.Deadline;
        //DR["FaxReply"] = this.FaxReply;
        //DR["ReplyContent"] = this.ReplyContent;
        //DR["RepairDate"] = this.RepairDate;
        //DR["CheckID"] = this.CheckID;
        //DR["Checker"] = this.Checker;
        //DR["CheckTIme"] = this.CheckTIme;
        //DR["CheckResult"] = this.CheckResult;
        //DR["CheckDescribe"] = this.CheckDescribe;
        DR["Status"] = this.Status;
        //DR["Note"] = this.Note;
        //DR["ControlStatus"] = this.ControlStatus;




        DS.Tables[0].Rows.Add(DR);
        DataSet DSChange = DS.GetChanges();
        return Insert(DSChange);
    }

    public bool Edit(WarrantyNotify warrantyNotify)
    {
        bool suc = false;
        //string rowFilter = " CaseID = " +  warrantyNotify.CaseID;
        //DataSet ds = this.Select(rowFilter, "", warrantyNotify.tableName);
        //if (ds.Tables[0].Rows.Count == 1)
        //{
        //    DataRow dr = ds.Tables[0].Rows[0];
        //    if (this.FaultModel != null)
        //    {
        //        dr["FaultModel"] = this.FaultModel;
        //    }
        //    if (this.FaultDescribe != null)
        //    {
        //        dr["FaultDescribe"] = this.FaultDescribe;
        //    }
        //    if (this.RepeatNotify != null)
        //    {
        //        dr["RepeatNotify"] = this.RepeatNotify;
        //    }
        //    if (this.WarrantyCompany != null)
        //    {
        //        dr["WarrantyCompany"] = this.WarrantyCompany;
        //    }
        //    if (this.NotifyDate != null)
        //    {
        //        dr["NotifyDate"] = this.NotifyDate;
        //    }
        //    if (this.RepairDateOption != null)
        //    {
        //        dr["RepairDateOption"] = this.RepairDateOption;
        //    }
        //    if (this.RepairDeadline != null)
        //    {
        //        dr["RepairDeadline"] = this.RepairDeadline;
        //    }
        //    if (this.ContractCombineNum != null)
        //    {
        //        dr["ContractCombineNum"] = this.ContractCombineNum;
        //    }
        //    if (this.NotifyConfirm != null)
        //    {
        //        dr["NotifyConfirm"] = this.NotifyConfirm;
        //    }
        //    if (this.NotifyContact != null)
        //    {
        //        dr["NotifyContact"] = this.NotifyContact;
        //    }
        //    if (this.PhoneConfirmDate != null)
        //    {
        //        dr["PhoneConfirmDate"] = this.PhoneConfirmDate;
        //    }
        //    if (this.FaxConfirmDate != null)
        //    {
        //        dr["FaxConfirmDate"] = this.FaxConfirmDate;
        //    }
        //    if (this.EmailConfirmDate != null)
        //    {
        //        dr["EmailConfirmDate"] = this.EmailConfirmDate;
        //    }
        //    if (this.Deadline != null)
        //    {
        //        dr["Deadline"] = this.Deadline;
        //    }
        //    if (this.FaxReply != null)
        //    {
        //        dr["FaxReply"] = this.FaxReply;
        //    }
        //    if (this.ReplyContent != null)
        //    {
        //        dr["ReplyContent"] = this.ReplyContent;
        //    }
        //    if (this.RepairDate != null)
        //    {
        //        dr["RepairDate"] = this.RepairDate;
        //    }
        //    if (this.CheckID != null)
        //    {
        //        dr["CheckID"] = this.CheckID;
        //    }
        //    if (this.Checker != null)
        //    {
        //        dr["Checker"] = this.Checker;
        //    }
        //    if (this.CheckTIme != null)
        //    {
        //        dr["CheckTIme"] = this.CheckTIme;
        //    }
        //    if (this.CheckResult != null)
        //    {
        //        dr["CheckResult"] = this.CheckResult;
        //    }
        //    if (this.CheckDescribe != null)
        //    {
        //        dr["CheckDescribe"] = this.CheckDescribe;
        //    }
        //    if (this.Status != null)
        //    {
        //        dr["Status"] = this.Status;
        //    }
        //    if (this.Note != null)
        //    {
        //        dr["Note"] = this.Note;
        //    }
        //    if (this.ControlStatus != null)
        //    {
        //        dr["ControlStatus"] = this.ControlStatus;
        //    }

        //    DataSet DSChange = ds.GetChanges(DataRowState.Modified);
        //    suc = this.Update(DSChange);

        //}
        return suc;
    }

    public bool Del(string CaseID)
    {
        return this.Delete("CaseID=" + CaseID);
    }


}
