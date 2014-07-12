#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\Report\WarrantyNotifyAdd.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "35B525C508BE6F1807029CE40ADA840546DF303B"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\Report\WarrantyNotifyAdd.aspx.cs"
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Report_WarrantyNotifyAdd : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ScriptManager1.IsInAsyncPostBack)
        {
            try
            {
                InitData();
                GridViewHidden(this.GridView1, 0);    //隱藏修改欄

                if (Request.QueryString["act"] != null)
                {

                    hidden_Action.Value = Request.QueryString["act"].Trim();
                    InitData();

                    if (!hidden_Action.Value.Equals("edit"))
                    {
                        BtnEdit("新增存檔");
                    }
                    else if (hidden_Action.Value.Equals("edit"))
                    {
                        if (Request.QueryString["caseid"] != null)
                        {
                            hidden_Caseid.Value = Request.QueryString["caseid"].Trim();
                            //
                            if (LoadData())
                            {
                                BtnEdit("修改存檔");
                            }
                            else
                            {
                                ShowPageMsg("資料讀取錯誤!!");
                            }
                        }
                        else
                        {
                            ShowPageMsg("參數錯誤!!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowPageMsg("異常錯誤發生!!");
            }
            
        }
    }

    private void BtnEdit(string btntext)
    {
        btn_Add.Text = btntext;
    }

    //修改模式載入資料
    private bool LoadData()
    {
        bool suc = false;

        SQLDB _operator = new SQLDB();
        if (hidden_Caseid.Value != null )
        {
            DataSet ds = new DataSet();
            ds = _operator.Select("caseid = '" + hidden_Caseid.Value + "'", "", "WarrantyNotify");
            if (ds.Tables[0].Rows.Count > 0)
            {
                suc = true;
                DataRow dr = ds.Tables[0].Rows[0];
                DropDownList_DeviceID.SelectedValue = dr["DeviceID"].ToString();
                TextBox_DeviceID_add.Text = dr["DeviceID"].ToString();
                //找出保固廠商的廠商編號，因為資料庫只有紀錄廠商名稱
                if (dr["WarrantyCompany"].ToString().Length > 0)
                {
                    DataSet ds_company = (DataSet)Application["App_Mis_Company"];
                    DataRow[] dr_company = ds_company.Tables[0].Select("CompanyName = '" + dr["WarrantyCompany"].ToString() + "'");
                    DropDownList_WarrantyCompany_add.SelectedValue = dr_company[0]["CompanyID"].ToString();
                }
                DropDownList_WarrantyContract_add.SelectedValue = dr["WarrantyContract"].ToString();
                DropDownList_FaultModel_add.SelectedValue = dr["FaultModel"].ToString();
                TextBox_FaultDescribe_add.Text = dr["FaultDescribe"].ToString();
                DropDownList_ContractCombineNum.SelectedValue = dr["ContractCombineNum"].ToString();
                if (dr["NotifyDate"].ToString().Length > 0)
                    TextBox_NotifyDate_add.Text = Convert.ToDateTime(dr["NotifyDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                if (dr["RepairDeadline"].ToString().Length > 0)
                {
                    TextBox_RepairDeadline_add.Text = Convert.ToDateTime(dr["RepairDeadline"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                }
                DropDownList_RepairDateOption_add.SelectedValue = dr["RepairDateOption"].ToString();
                //併案編號
                DropDownList_ContractCombineNum.SelectedValue = dr["ContractCombineNum"].ToString();
                //重複通知說明
                TextBox_RepeatNotify_add.Text = dr["RepeatNotify"].ToString();

            }
        }
        return suc;
    }

    protected override void InitData()
    {
        SQLDB _operator = new SQLDB();
        DataSet ds_device = _operator.Select("", "", "Device_Config");
        //自動載入通知日期
        TextBox_NotifyDate_add.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //下拉選單，DEVICEID
        BindDropDownListData(DropDownList_DeviceID, ds_device, "Device_Id", "Device_Id");
        //DropDownList_DeviceID.SelectedIndex = 0;

        //ADD下拉選單，保固廠商
        DataSet ds_comapny = _operator.Select("", "", "Company");
        BindDropDownListData(DropDownList_WarrantyCompany_add, ds_comapny, "CompanyName", "CompanyID");
        
        //ADD下拉選單，指定合約
        string query_contract = " select ('('+ContractNum+')'+ContractName) as ContractCombine,* from Contract ";
        DataSet ds_contract = _operator.SelectQuery(query_contract);
        BindDropDownListData(DropDownList_WarrantyContract_add, ds_contract, "ContractCombine", "ContractID");



    }

    /// <summary>
    /// 在Page_Load時將gvidview使用css方式引隱藏欄位
    /// </summary>
    public void GridViewHidden(GridView gv, int idx)
    {
        //gv.Columns[idx].ControlStyle.CssClass ="gridviewhiddenrow";
        //gv.Columns[idx].FooterStyle.CssClass = "gridviewhiddenrow";
        gv.Columns[idx].HeaderStyle.CssClass = "gridviewhiddenrow";
        gv.Columns[idx].ItemStyle.CssClass = "gridviewhiddenrow";
    }

    protected void DropDownList_DeviceID_SelectedIndexChanged(object sender, EventArgs e)
    {
        SQLDB _operator = new SQLDB();
        string deviceID = DropDownList_DeviceID.SelectedValue;
        DataSet EquipmentDS = _operator.Select("Device_ID = '" + deviceID + "'", "", "View_DeviceConfig");
        gv_deviceConfig.DataSource = EquipmentDS;
        gv_deviceConfig.DataBind();

        //更新歷史表格
        DataSet WarrantyNotifyDS = _operator.Select("DeviceID = '" + deviceID + "'", "", "WarrantyNotify");
        //DataTable dt = WarrantyNotifyDS.Tables[0];
        //dt.DefaultView.RowFilter = "DeviceID = '" + deviceID + "'";
        this.GridView1.DataSource = WarrantyNotifyDS;
        this.GridView1.DataBind();


        //更新新增保固單欄位資料
        refreshAddForm(deviceID);
    }

    protected void ShowPageMsg(string msg)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "window.alert('" + msg + "');", true);
        //ShowMsg2(UpdatePanel1, msg);
    }

    protected void refreshAddForm(string deviceId)
    {
        DataSet WarrantyNotifyDS = (DataSet)Application["App_Report_WarrantyNotify"];
        this.TextBox_DeviceID_add.Text = deviceId;

        this.DropDownList_FaultModel_add.SelectedIndex = 0;
        this.TextBox_FaultDescribe_add.Text = "";
        this.TextBox_RepeatNotify_add.Text = "";
        this.DropDownList_WarrantyCompany_add.SelectedIndex = 0;
        //this.DropDownList_WarrantyContract_add.SelectedValue = this.DropDownList_DeviceContractID.SelectedValue;
        this.DropDownList_RepairDateOption_add.SelectedIndex = 0;
        //this.imgCalander2.Visible = false;
        TextBox_RepairDeadline_add.Enabled = false;

        this.DropDownList_ContractCombineNum.Items.Clear();
        DataTable dt = WarrantyNotifyDS.Tables[0];
        //dt.DefaultView.RowFilter = "DeviceID = '" + deviceId + "'";
        this.DropDownList_ContractCombineNum.Items.Add(new ListItem("請選擇", "0"));
        for (int i = 0; i < dt.DefaultView.Table.Rows.Count; i++)
        {
            if (dt.DefaultView.Table.Rows[i]["DeviceID"].ToString().Equals(deviceId))
            this.DropDownList_ContractCombineNum.Items.Add(new ListItem(dt.DefaultView.Table.Rows[i]["CaseID"].ToString()));
        }
        
    }


    protected void button_gridViewEdit(object sender, GridViewCommandEventArgs e)
    {
        //int index = Convert.ToInt32(e.CommandArgument);
        //GridViewRow row = GridView1.Rows[index];
        //gv_index.Value = index.ToString();  //紀錄選取列位
        //row.BackColor = Color.FromArgb(0, 150, 150);  //改變選取列底色
    }

    protected void Button_add_click(object sender, EventArgs e)
    {
        //通報者名稱
        string reportid = Session["UserID"].ToString();

        if (TextBox_FaultDescribe_add.Text.Length == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "window.alert('請輸入故障描述!');", true);
            return;
        }
        if (hidden_Action.Value == "edit")
        {
            SQLDB _operator = new SQLDB();
            DataSet ds_edit = _operator.Select("CaseID = '" + hidden_Caseid.Value + "'", "", "WarrantyNotify");
            DataRow dr = ds_edit.Tables[0].Rows[0];
            dr["FaultModel"] = this.DropDownList_FaultModel_add.Text;
            dr["FaultDescribe"] = this.TextBox_FaultDescribe_add.Text;
            dr["RepeatNotify"] = this.TextBox_RepeatNotify_add.Text;
            dr["WarrantyCompany"] = this.DropDownList_WarrantyCompany_add.SelectedItem.ToString();
            dr["WarrantyContract"] = int.Parse(this.DropDownList_WarrantyContract_add.SelectedValue);
            dr["NotifyDate"] = Convert.ToDateTime(this.TextBox_NotifyDate_add.Text);
             if (this.DropDownList_ContractCombineNum.SelectedIndex > 0)
            {
                dr["ContractCombineNum"] = int.Parse(this.DropDownList_ContractCombineNum.SelectedItem.ToString());
            }

             switch (this.DropDownList_RepairDateOption_add.SelectedIndex)
             {
                 case 0:
                     //修復日期選項
                     ScriptManager.RegisterStartupScript(this, this.GetType(), "", "window.alert('請點選修復日期選項!');", true);
                     return;
                 //break;
                 case 1:
                     dr["RepairDateOption"] = 1;
                     break;
                 case 2:
                     dr["RepairDateOption"] = 2;
                     break;
                 case 3:
                     dr["RepairDateOption"] = 3;
                     dr["RepairDeadline"] = Convert.ToDateTime(this.TextBox_RepairDeadline_add.Text);
                     break;
             }
             DataSet DSChange = ds_edit.GetChanges(DataRowState.Modified);
             if (_operator.Update(DSChange))
             {
                 ScriptManager.RegisterStartupScript(this, this.GetType(), "", "window.alert('修改成功');", true);
                 UpdateServerData();
             }
        }
        else
        {
            WarrantyNotify wn = new WarrantyNotify();
            wn.DeviceID = this.TextBox_DeviceID_add.Text;
            wn.FaultModel = this.DropDownList_FaultModel_add.Text;
            wn.FaultDescribe = this.TextBox_FaultDescribe_add.Text;
            wn.RepeatNotify = this.TextBox_RepeatNotify_add.Text;
            wn.WarrantyCompany = this.DropDownList_WarrantyCompany_add.SelectedItem.ToString();
            if (this.DropDownList_WarrantyContract_add.SelectedIndex > 0)
            {
                wn.WarrantyContract = int.Parse(this.DropDownList_WarrantyContract_add.SelectedValue);
            }
            wn.NotifyDate = Convert.ToDateTime(this.TextBox_NotifyDate_add.Text);
            wn.NotifyConfirm = false;
            if (this.DropDownList_ContractCombineNum.SelectedIndex > 0)
            {
                wn.ContractCombineNum = int.Parse(this.DropDownList_ContractCombineNum.SelectedItem.ToString());
            }

            wn.Status = "維修中";


            switch (this.DropDownList_RepairDateOption_add.SelectedIndex)
            {
                case 0:
                    //修復日期選項
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "window.alert('請點選修復日期選項!');", true);
                    return;
                //break;
                case 1:
                    wn.RepairDateOption = 1;
                    break;
                case 2:
                    wn.RepairDateOption = 2;
                    break;
                case 3:
                    wn.RepairDateOption = 3;
                    wn.RepairDeadline = Convert.ToDateTime(this.TextBox_RepairDeadline_add.Text);
                    break;
            }

            wn.Add();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "window.alert('新增成功');", true);
            UpdateServerData();
        }

        if (chk_isSendMail.Checked)
        {
            try
            {
                //傳送通知email給廠商
                string[] mailaddress = new string[1];
                SQLDB _operateor = new SQLDB();
                DataSet ds = new DataSet();
                ds = _operateor.Select("CompanyID ='" + DropDownList_WarrantyCompany_add.SelectedValue + "'", "", "Company");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    mailaddress[0] = ds.Tables[0].Rows[0]["Email"].ToString();
                }
                Email notifyemail = new Email();

                //通報內容
                //string body = "";
                string first_td = " <td width='150' align='center' style='background-color: #c4ffde;' > ";
                string second_td = " <td align='center' style='background-color: #ffff9d;' > ";

                StringBuilder body = new StringBuilder();

                body.Append("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">");
                body.Append("<HTML><HEAD><META http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
                body.Append("</HEAD><BODY>");

                body.Append(" <table width='80%' border='1' align='center' cellpadding='0' cellspacing='0'>");
                body.Append(" <tr> ");
                body.Append(" <td  colspan='2' align='center' style='background-color: #ffcc33;'><h3>  " + "新北市停車管理系統報修服務單" + "</h3> </td> ");
                body.Append(" </tr> ");
                body.Append(" <tr> ");
                body.Append(first_td + "設備編號" + " </td> ");
                body.Append(second_td + TextBox_DeviceID_add.Text + " </td> ");
                body.Append(" </td> ");
                body.Append(" </tr> ");
                body.Append(" <tr> ");
                body.Append(first_td + "通報者" + " </td> ");
                body.Append(second_td + reportid + " </td> ");
                body.Append(" </td> ");
                body.Append(" </tr> ");
                body.Append(" <tr> ");
                body.Append(first_td + "通報時間" + " </td> ");
                body.Append(second_td + TextBox_NotifyDate_add.Text + " </td> ");
                body.Append(" </td> ");
                body.Append(" </tr> ");
                body.Append(" <tr> ");
                body.Append(first_td + "指定修復日期" + " </td> ");
                body.Append(second_td + TextBox_RepairDeadline_add.Text + " </td> ");
                body.Append(" </td> ");
                body.Append(" </tr> ");
                body.Append(" <tr> ");
                body.Append(first_td + "損壞原因描述" + " </td> ");
                body.Append(second_td + TextBox_FaultDescribe_add.Text + " </td> ");
                body.Append(" </td> ");
                body.Append(" </tr> ");
                body.Append(" <tr> ");
                body.Append(" <td  colspan='2' align='center' style='background-color: #cccc99;'> " + "本郵件由發信系統主動發出，請勿直接回覆，如有任何問題或意見，請撥電話至停管中心" + " </td> ");
                body.Append(" </tr> ");
                body.Append(" </table> ");

                body.Append("</BODY></HTML>");

                if (notifyemail.toSend("新北市停車管理系統報修服務單", mailaddress, body.ToString()))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "window.alert('郵件寄送成功');", true);
                }
            }
            catch (Exception ee)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "window.alert('新增保固單失敗!');", true);
            }
        }
    }

      

    public void UpdateServerData()
    {
        Application["App_Report_WarrantyNotify"] = CommonLib.GetWarrantyNotify();
    }

    protected void DropDownList_RepairDateOption_add_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.DropDownList_RepairDateOption_add.SelectedIndex == 3)
        {
            TextBox_RepairDeadline_add.Enabled = true;
            //MaskedEditValidator2.IsValidEmpty = false;
            //MaskedEditValidator2.EmptyValueMessage = "不可為空";
            //this.imgCalander2.Visible = true;
        }
        else
        {
            TextBox_RepairDeadline_add.Enabled = false;
            //MaskedEditValidator2.IsValidEmpty = true;
            //this.imgCalander2.Visible = false;
        }
    }



    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataSet WarrantyNotifyDS = (DataSet)Application["App_Report_WarrantyNotify"];
        this.GridView1.PageIndex = e.NewPageIndex;
        
        //更新歷史表格
        DataTable dt = WarrantyNotifyDS.Tables[0];
        dt.DefaultView.RowFilter = "DeviceID = '" + this.DropDownList_DeviceID.SelectedValue + "'";
        this.GridView1.DataSource = dt.DefaultView;
        this.GridView1.DataBind();
    }
}


#line default
#line hidden
