#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\Report\WarrantyNotifyList.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "939C8C615A35F27AE1D026D6B59450BB62D86CAB"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\Report\WarrantyNotifyList.aspx.cs"
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

public partial class Report_WarrantyNotifyList : PageBase
{
    SQLDB _operator = new SQLDB("View_Device");
    DataSet EquipmentDS;
    DataSet DeviceModeDS;
    DataSet ContractDS;
    DataSet RegionDS;
    DataSet WarrantyNotifyDS;
    DataSet CompanyDS;
    DataSet Project;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ScriptManager1.IsInAsyncPostBack)
        {
            GridViewHidden(this.GridView1, 0);    //隱藏修改欄
            EquipmentDS = (DataSet)Application["App_Mis_Equipment"];
            DeviceModeDS = (DataSet)Application["App_Mis_DeviceModel"];
            ContractDS = (DataSet)Application["App_Mis_Contract"];
            RegionDS = (DataSet)Application["App_Mis_Area"];
            WarrantyNotifyDS = (DataSet)Application["App_Report_WarrantyNotify"];
            CompanyDS = (DataSet)Application["App_Mis_Company"];
            Project = (DataSet)Application["App_Mis_Project"];
            InitData();
            
        }
    }

    protected override void InitData()
    {

        //下拉選單，DEVICEID
        BindDropDownListData(DropDownList_DeviceID, EquipmentDS, "DeviceId", "DeviceId");
        //DropDownList_DeviceID.SelectedIndex = 0;

        //ADD下拉選單，保固廠商
        BindDropDownListData(DropDownList_WarrantyCompany_add, CompanyDS, "CompanyName", "CompanyID");

        //ADD下拉選單，指定合約
        BindDropDownListData(DropDownList_WarrantyContract_add, ContractDS, "ContractShortName", "ContractID");

        //ADD下拉選單，指定計畫資料
        BindDropDownListData(DropDownList_Project, Project, "ProjectName", "ProjectID");
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
        string deviceID = DropDownList_DeviceID.SelectedValue;
        DataSet ds = _operator.Select("DeviceID = '" + deviceID + "'", "", "View_Device");

        DataRow[] drs = EquipmentDS.Tables[0].Select("DeviceID = '" + deviceID + "'");

        

       //更新設備資料表
        GridView2.DataSource = ds;
        GridView2.DataBind();

        //更新歷史表格
        DataTable dt = WarrantyNotifyDS.Tables[0];
        dt.DefaultView.RowFilter = "DeviceID = '" + deviceID + "'";
        this.GridView1.DataSource = dt.DefaultView;
        this.GridView1.DataBind();


        //更新新增保固單欄位資料
        this.DropDownList_WarrantyContract_add.SelectedValue =  drs[0]["DeviceContractID"].ToString();
        refreshAddForm(deviceID);

    }

    protected void ShowPageMsg(string msg)
    {
        ShowMsg2(UpdatePanel1, msg);
    }

    protected void refreshAddForm(string deviceId)
    {
        this.DropDownList_FaultModel_add.SelectedIndex = 0;
        this.TextBox_FaultDescribe_add.Text = "";
        this.TextBox_RepeatNotify_add.Text = "";
        this.DropDownList_WarrantyCompany_add.SelectedIndex = 0;
        //this.DropDownList_WarrantyContract_add.SelectedValue = this.DropDownList_DeviceContractID.SelectedValue;
        this.DropDownList_RepairDateOption_add.SelectedIndex = 0;
        this.imgCalander2.Visible = false;

        this.DropDownList_ContractCombineNum.Items.Clear();
        DataTable dt = WarrantyNotifyDS.Tables[0];
        //dt.DefaultView.RowFilter = "DeviceID = '" + deviceId + "'";

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
        WarrantyNotify wn = new WarrantyNotify();
        wn.DeviceID = DropDownList_DeviceID.SelectedValue;
        wn.FaultModel = this.DropDownList_FaultModel_add.Text;
        wn.FaultDescribe = this.TextBox_FaultDescribe_add.Text;
        wn.RepeatNotify = this.TextBox_RepeatNotify_add.Text;
        wn.WarrantyCompany = this.DropDownList_WarrantyCompany_add.SelectedItem.ToString();
        wn.WarrantyContract = int.Parse(this.DropDownList_WarrantyContract_add.SelectedValue);
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
                ShowPageMsg("請點選修復日期選項!");
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
        try
        {
            wn.Add();
            ShowPageMsg("新增保固單成功!");
            UpdateServerData();

        }
        catch (Exception ee)
        {
            ShowPageMsg("新增保固單失敗!");
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
            this.imgCalander2.Visible = true;
        }
        else
        {
            this.imgCalander2.Visible = false;
        }
    }



    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
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
