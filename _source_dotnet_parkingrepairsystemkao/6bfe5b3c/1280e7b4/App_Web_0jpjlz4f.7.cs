#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\Inventory\StockOut_AM.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CB50740A17167C856CDE1BA642BBF56111695494"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\Inventory\StockOut_AM.aspx.cs"
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Windows.Forms;
using System.Text;

public partial class Inventory_StockOut_AM : PageBase
{
    SQLDB _operator = new SQLDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ToolkitScriptManager1.IsInAsyncPostBack)
        {
            Session["ICS_StockOut_Item"] = null;
            try
            {
                if (Request.QueryString["act"] != null)
                {
                    hidden_Action.Value = Request.QueryString["act"].Trim();
                    InitData();
                    //
                    if (hidden_Action.Value.Equals("add"))
                    {
                        //txt_companyId.Enabled = false;
                        BtnEdit("新增存檔");
                        FieldEdit(true);
                    }
                    else if (hidden_Action.Value.Equals("edit"))
                    {
                        if (Request.QueryString["id"] != null)
                        {
                            hidden_StockInID.Value = Request.QueryString["id"].Trim();
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
        ShowMsgAndRedirect(UpdatePanel1, msg, "../Inventory/StockOut_QD.aspx");
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
        btn_saveAll.Visible = visible;
        btn_saveAll.Text = btnName.Trim();
    }

    protected override void InitData()
    {
        BindDropDownListData(ddl_WarrantyNotify, (DataSet)Application["App_Report_WarrantyNotify"], "CaseID", "CaseID");
        BindDropDownListData(ddl_Region, (DataSet)Application["App_Mis_Area"], "AreaName", "AreaID");
        BindDropDownListData(ddl_ProjectName, (DataSet)Application["App_Mis_ICSProject"], "ProjectName", "ProjectID");
        BindDropDownListData(ddl_MateriName, (DataSet)Application["App_Invetory_ICSMaterial"], "MaterialName", "NO");
    }

    protected void FieldEdit(bool val)
    {

    }

    protected bool LoadData()
    {
        FieldEdit(false);
        return true;
    }

    public void UpdateServerData()
    {
        //Application["App_Mis_Company"] = CommonLib.GetCompany();
    }


    protected void btn_saveAll_Click(object sender, EventArgs e)
    {
        DataSet ds_StockOut_Item = (DataSet)Session["ICS_StockOut_Item"];
        #region 驗證入庫物料與計畫編號是否有輸入資料
        if (ds_StockOut_Item == null || ddl_ProjectName.SelectedIndex == 0)
        {
            ShowMsg2(UpdatePanel1, "請輸入資料");
            return;
        }
        #endregion

        if (hidden_Action.Value == "add")
        {
           

            string userid = (string)Session["UserID"];
            string stockoutid = "";
            SQLDB db = new SQLDB();
            DateTime now = DateTime.Now;
            string Stockout_date = now.ToString("yyyy/MM/dd HH:mm:ss");

            #region 新增出庫單
            DataSet ds_stockOut_record = db.Select(" 1=0", "", "ICS_StockOut_Record");
            DataRow dr_record = ds_stockOut_record.Tables[0].NewRow();
            if (ddl_WarrantyNotify.SelectedIndex != 0)
            {
                dr_record["CaseID"] = ddl_WarrantyNotify.SelectedValue;
            }
            dr_record["ProjectID"] = ddl_ProjectName.SelectedValue;
            dr_record["ProjectName"] = ddl_ProjectName.SelectedItem.Text;
            if (ddl_Region.SelectedIndex != 0)
            {
                dr_record["RegionID"] = ddl_Region.SelectedValue;
            }
            dr_record["StockOutDate"] = txt_StockOutTime.Text;
            dr_record["StockOutUser"] = userid;
            dr_record["IsOut"] = false;
            dr_record["UpdateTime"] = Stockout_date;
            ds_stockOut_record.Tables[0].Rows.Add(dr_record);
            DataSet DSChange = ds_stockOut_record.GetChanges();
            if (!db.Insert(DSChange))
            {
                ShowMsg(UpdatePanel1, "新增出庫單失敗");
                return;
            }
            #endregion

            #region 新增出庫物料
            //將出庫單時間紀錄起來，之後利用出庫單時間與登入者帳號抓取入庫單編號
            DataSet ds = db.Select("UpdateTime ='" + Stockout_date + "'and StockOutUser ='" + userid + "' and ProjectID = '" + ddl_ProjectName.SelectedValue + "' ", "", "ICS_StockOut_Record");
            if (ds.Tables[0].Rows.Count > 0)
            {
                //抓到入庫單編號
                stockoutid = ds.Tables[0].Rows[0]["StockOutID"].ToString();

                //將入庫單編號塞到StockOutItem裡
                for (int i = 0; i < ds_StockOut_Item.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds_StockOut_Item.Tables[0].Rows[i];
                    dr["StockOutID"] = stockoutid;
                    dr["UpdateTime"] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    dr["UpdateUser"] = userid;
                }

                //刪除rowindex欄位
                ds_StockOut_Item.Tables[0].Columns.Remove("rowindex");
                DataSet DSChangeItem = ds_StockOut_Item.GetChanges();
                if (db.Insert(DSChangeItem))
                    ShowMsgAndRedirect(UpdatePanel1, "新增成功", "StockOut_QD.aspx");
                else
                    ShowMsg2(UpdatePanel1, "新增失敗");


            } 
            #endregion
        }
           
    

    }

    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        //Response.Redirect("StockOut_QD.aspx");
    }


    protected void btn_StockOutSave_Click(object sender, EventArgs e)
    {
        SQLDB db = new SQLDB("ICS_StockOut_Item");
        if (ddl_MateriName.SelectedIndex == 0)
        {
            ShowPageMsg("請選擇物料名稱");
            return;
        }
        if (txt_ConsumeQuantity.Text.Length  == 0)
        {
            ShowPageMsg("請輸入領用數量");
            return;
        }
        //載入即時料價資料與庫存量資料
        DataSet ds_ICSInventory = new DataSet();
        ds_ICSInventory = db.Select("Materialid = '" + ddl_MateriName.SelectedValue + "'", "", "View_ICS_Inventory");
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        if (gv_stockOut_Item.Rows.Count > 0)
        {
            ds = (DataSet)Session["ICS_StockOut_Item"];
        }
        else
        {
            ds = db.Select("1 =0", "", "ICS_StockOut_Item");
            //加入流水號欄位，用在刪除gridview項目用的
            ds.Tables[0].Columns.Add("rowindex");
            ds.Tables[0].Columns.Add("Quantity");
        }
        DataRow dr = ds.Tables[0].NewRow();
        dr["MaterialName"] = ddl_MateriName.SelectedItem.Text;
        dr["MaterialID"] = ddl_MateriName.SelectedValue;
        dr["ConsumeQuantity"] = Convert.ToInt32(txt_ConsumeQuantity.Text);
        //塞入料價與庫存數量
        if (ds_ICSInventory.Tables[0].Rows.Count > 0)
        {
            DataRow dr_inventory = ds_ICSInventory.Tables[0].Rows[0];
            double materialcost = Convert.ToDouble(dr_inventory["MaterialCost"]);
            dr["StockOutCost"] = (materialcost * Convert.ToDouble(txt_ConsumeQuantity.Text)).ToString("0.000");
            dr["Quantity"] = dr_inventory["Quantity"].ToString().Split('.')[0];
            dr["MaterialCost"] = Convert.ToDouble(dr_inventory["MaterialCost"]).ToString("0.000");
        }
        ds.Tables[0].Rows.Add(dr);
        //塞流水號
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ds.Tables[0].Rows[i]["rowindex"] = i + 1;
        }
        gv_stockOut_Item.DataSource = ds;
        gv_stockOut_Item.DataBind();
        Session["ICS_StockOut_Item"] = ds;
    }
    //清空物料資料
    protected void btn_StockoutCancel_Click(object sender, EventArgs e)
    {
        ddl_MateriName.SelectedIndex = 0;
        txt_ConsumeQuantity.Text = "";
    }
    
    protected void gv_stockOut_Item_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //利用選取入庫編號，抓取入庫內容與入庫單計畫分攤
        if (e.CommandName == "cmDelete")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            //string rowindex = gv_stockitem.Rows[index].Cells[0].Text.Replace("&nbsp;", "");  //抓序號
            DataSet ds = (DataSet)Session["ICS_StockOut_Item"];
            ds.Tables[0].Rows[index].Delete();
            // ds.Tables[0].AcceptChanges();
            Session["ICS_StockOut_Item"] = ds;
            gv_stockOut_Item.DataSource = ds;
            gv_stockOut_Item.DataBind();
        }
    }
    protected void gv_stockOut_Item_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            System.Web.UI.WebControls.Button deleteButton = (System.Web.UI.WebControls.Button)e.Row.FindControl("cmd_Delete");
            deleteButton.CommandArgument = e.Row.RowIndex.ToString();
            //修改資料
            // ((Button)e.Row.Cells[0].FindControl("btn_edit")).Attributes.Add("onClick", "edit('" + e.Row.Cells[1].Text.Trim() + "');return false;");
        }
    }
}

#line default
#line hidden
