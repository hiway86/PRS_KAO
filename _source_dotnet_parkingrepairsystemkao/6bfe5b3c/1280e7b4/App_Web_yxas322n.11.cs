#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\Report\ReportReturnManage.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A793E6BBF670EC18A02EEEF54FA70E7846D302E3"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\Report\ReportReturnManage.aspx.cs"
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

public partial class Report_ReportReturnManage : PageBase
{
    protected WarrantyNotify _operator = new WarrantyNotify();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ScriptManager1.IsInAsyncPostBack)
        {
            hidden_UsedMaterial.Value = "false";
            Session["DS_UsedMaterial"] = null;
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
                        BtnEdit("新增存檔");
                        FieldEdit(true);
                    }
                    else if (hidden_Action.Value.Equals("edit") || hidden_Action.Value.Equals("return"))
                    {
                        if ( hidden_Action.Value.Equals("return"))
                        {
                            cbo_deviceid.Enabled = false;
                        }
                        else
                        {
                            cbo_deviceid.Enabled = true;
                        }
                        if (Request.QueryString["id"] != null)
                        {
                            hidden_CaseId.Value = Request.QueryString["id"].Trim();
                            cbo_caseId.Enabled = false;
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

    protected override void InitData()
    {
        BindDropDownListData(cbo_MaterialType, (DataSet)Application["App_Invetory_MaterialType"],"MaterialTypeName", "MaterialTypeID");
        BindDropDownListData(cbo_deviceid, (DataSet)Application["App_Mis_Equipment"], "Device_ID", "Device_ID");
        BindDropDownListData(cbo_caseId, (DataSet)Application["App_Report_WarrantyNotify"], "CaseId", "CaseId");
    }

    protected void ReDirect(string msg)
    {
        ShowMsgAndRedirect(UpdatePanel1, msg, "../Report/RepairMaintainList.aspx");
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

    protected void FieldEdit(bool val)
    {

    }

    protected bool LoadData()
    {
        FieldEdit(false);
        bool suc = false;
        string rowfilter = " CaseId =  " + "'" + hidden_CaseId.Value + "'";

        //先抓通報案件回報紀錄
        DataSet ds2 = _operator.Select(rowfilter, "", "WarrantyNotify");
        if (ds2.Tables[0].Rows.Count == 1)
        {
            suc = true;
            DataTable dt = ds2.Tables[0];
            DataRow dr = dt.Rows[0];

            if (dr["CaseID"].ToString().Trim().Length > 0)
            {
                cbo_caseId.SelectedValue = dr["CaseID"].ToString().Trim();
            }
            cbo_deviceid.SelectedValue = dr["DeviceID"].ToString();
            if (dr["FaxReply"].ToString().Trim().Length > 0)
            {
                chk_faxReplay.Checked = Convert.ToBoolean(dr["FaxReply"].ToString());
            }
            txt_replayContent.Text = dr["ReplyContent"].ToString();
            if (dr["RepairDate"].ToString().Trim().Length > 0)
            {
                DateTime dt_repairdate = new DateTime();
                dt_repairdate = Convert.ToDateTime(dr["RepairDate"].ToString());
                txt_repairDate.Text = dt_repairdate.ToString("yyyy/MM/dd HH:mm:ss");
            }

            if (dr["FaxReply"].ToString().Equals(1))
            {
                chk_faxReplay.Checked = true;
            }
            else
                chk_faxReplay.Checked = false;

            Session["DS_Mis"] = ds2;
        }


        //再抓取物料使用資料
        string condition = "CaseId = '" + hidden_CaseId.Value + "'";
        DataSet ds_UsedMaterial = _operator.Select(condition, "", "ICS_MaterialRepaired");

        if (ds_UsedMaterial.Tables[0].Rows.Count > 0)
        {
            Session["DS_UsedMaterial"] = ds_UsedMaterial;
            gv.DataSource = ds_UsedMaterial;
            gv.DataBind();
        }

        return suc;
    }

    public void UpdateServerData()
    {
        Application["App_Report_WarrantyNotify"] = CommonLib.GetWarrantyNotify();
    }

    protected void txt_Car_Licence_Exp_TextChanged(object sender, EventArgs e)
    {

    }

    protected void cmd_Save_Click1(object sender, EventArgs e)
    {
        if (txt_replayContent.Text.Length ==0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "test", "alert(\"請輸入回報內容\")", true);
            return;
        }
        if (txt_repairDate.Text.Length == 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "test", "alert(\"請輸入實際修復日期\")", true);
            return;
        }
        if (hidden_Action.Value.Equals("edit") || hidden_Action.Value.Equals("return"))
        {
            DataSet ds = (DataSet)Session["DS_Mis"];
            if (ds != null)
            {
                //ds.Tables[0].Rows[0]["ContractId"] = txt_contractId.Text;
                ds.Tables[0].Rows[0]["ReplyContent"] = txt_replayContent.Text;
                ds.Tables[0].Rows[0]["RepairDate"] = Convert.ToDateTime(txt_repairDate.Text);
                ds.Tables[0].Rows[0]["FaxReply"] = chk_faxReplay.Checked;
                ds.Tables[0].Rows[0]["Status"] = "結案";

                if (_operator.Update(ds))
                {
                    //判斷是否有新增刪除物料
                    if (hidden_UsedMaterial.Value == "true")
                    {
                        ////先將所有耗材使用紀錄刪除，再將資料新增
                        //string deletestring = "delete ICS_MaterialRepaired where caseid = '" + hidden_CaseId.Value + "'";
                        //_operator.ExecuteStatement(deletestring);
                        DataSet ds_usedMaterial = (DataSet)Session["DS_UsedMaterial"];
                        DataSet DSChange = ds_usedMaterial.GetChanges();
                        if (_operator.Update(DSChange))
                        {
                                ScriptManager.RegisterStartupScript(this, GetType(), "test", "saveClick()", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "test", "alert(\"回報內容成功，使用物料回報失敗\")", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "test", "saveClick()", true);
                    }
                }
                else
                {
                    ReDirect("修改失敗");
                }
            }
        }
    }

    protected void cbo_MaterialType_SelectedIndexChanged(object sender, EventArgs e)
    {
        SQLDB _operator = new SQLDB();
        if (cbo_MaterialType.SelectedIndex != 0)
        {
            string materialtypeid = cbo_MaterialType.SelectedValue;
            DataSet ds =  _operator.Select("materialTypeid = '" + materialtypeid + "'", "", "ICS_Material");
            cbo_Material.Items.Clear();
            ListItem materialItem = new ListItem();
            materialItem.Value = "-1";
            materialItem.Text = "===請選擇===";
            cbo_Material.Items.Add(materialItem);
            BindDropDownListData(cbo_Material, ds, "MaterialName", "NO");
        }
    }

    protected void CustomersGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //hidden_UsedMaterial.Value = "true";
        //int rowindex = Convert.ToInt32(e.
        string materialid = gv.Rows[e.RowIndex].Cells[1].Text;
        string quantity = gv.Rows[e.RowIndex].Cells[4].Text;
        DataSet ds_usedMaterial = (DataSet)Session["DS_UsedMaterial"];
        DataRow[] dr_delete = ds_usedMaterial.Tables[0].Select(" MaterialID= '"+materialid+"' and UsedQuantity = '"+quantity+" ' ");
        for (int i = 0; i < dr_delete.Length; i++)
            dr_delete[i].Delete();
        Session["DS_UsedMaterial"] = ds_usedMaterial;
        gv.DataSource = ds_usedMaterial;
        gv.DataBind();

    }

    protected void btn_MaterialAdd_Click(object sender, EventArgs e)
    {
        hidden_UsedMaterial.Value = "true";
        if (Session["DS_UsedMaterial"] == null)
        {
            SQLDB _operator = new SQLDB();
            DataSet ds = new DataSet();
            ds = _operator.Select("1 = 0", "", "ICS_MaterialRepaired");
            DataRow dr = ds.Tables[0].NewRow();
            dr["Caseid"] = hidden_CaseId.Value;
            dr["MaterialID"] = cbo_Material.SelectedValue;
            dr["MaterialName"] = cbo_Material.SelectedItem.Text;
            dr["MaterialTypeID"] = cbo_MaterialType.SelectedValue;
            dr["UsedQuantity"] = Convert.ToInt32(txt_UsedQantity.Text);
            ds.Tables[0].Rows.Add(dr);
            Session["DS_UsedMaterial"] = ds;
            gv.DataSource = ds;
            gv.DataBind();
        }
        else
        {
            SQLDB _operator = new SQLDB();
            DataSet ds = new DataSet();
            ds = (DataSet)Session["DS_UsedMaterial"];
            DataRow dr = ds.Tables[0].NewRow();
            dr["Caseid"] = hidden_CaseId.Value;
            dr["MaterialID"] = cbo_Material.SelectedValue;
            dr["MaterialName"] = cbo_Material.SelectedItem.Text;
            dr["MaterialTypeID"] = cbo_MaterialType.SelectedValue;
            dr["UsedQuantity"] = Convert.ToInt32(txt_UsedQantity.Text);
            ds.Tables[0].Rows.Add(dr);
            Session["DS_UsedMaterial"] = ds;
            gv.DataSource = ds;
            gv.DataBind();
        }

    }

   
}



#line default
#line hidden
