#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\Inventory\StockIn_ADM.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FA6BEC84985EC0D6020604AD2598EE6D984CE824"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\Inventory\StockIn_ADM.aspx.cs"
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

public partial class Inventory_StockIn_ADM : PageBase
{
    SQLDB _operator = new SQLDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ToolkitScriptManager1.IsInAsyncPostBack)
        {
            Session["StockInItem"] = null;
            Session["ICS_Stock_Project"] = null;
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
        ShowMsgAndRedirect(UpdatePanel1, msg, "../Inventory/StockIn_Q.aspx");
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
        BindDropDownListData(ddl_ICSMaterial, (DataSet)Application["App_Invetory_ICSMaterial"], "MaterialName", "NO");
        BindDropDownListData(ddl_CompanyID, (DataSet)Application["App_Mis_Company"], "CompanyName", "CompanyID");
        BindDropDownListData(ddl_ProjectName, (DataSet)Application["App_Mis_ICSProject"], "ProjectName", "ProjectID");
    }

    protected void FieldEdit(bool val)
    {

    }

    protected bool LoadData()
    {
        FieldEdit(false);
        bool suc = false;
        string rowfilter = "StockInID =  " + hidden_StockInID.Value;
        //讀取入庫單內容
        DataSet ds2 = _operator.Select(rowfilter, "", "ICS_StockIn_Item");
        //塞入rowindex欄位
        ds2.Tables[0].Columns.Add("rowindex");
        for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
        {
            ds2.Tables[0].Rows[i]["rowindex"] = i + 1;
        }
        if (ds2.Tables[0].Rows.Count > 0)
        {
            gv_stockitem.DataSource = ds2;
            gv_stockitem.DataBind();
            Session["StockInItem"] = ds2;
            suc = true;
        }
        else
        {
            gv_stockitem.DataSource = null;
            gv_stockitem.DataBind();
            ShowPageMsg("入庫單無資料");
        }
        //讀取分攤成本資料
        string rowfilter2 = "StockInID =  " + hidden_StockInID.Value;
        DataSet ds_project = _operator.Select(rowfilter2,"","ICS_Stock_Project");
        ds_project.Tables[0].Columns.Add("rowindex");
        for (int i = 0; i < ds_project.Tables[0].Rows.Count; i++)
        {
            ds_project.Tables[0].Rows[i]["rowindex"] = i + 1;
        }

       if (ds_project.Tables[0].Rows.Count > 0)
        {
            gv_stock_project.DataSource = ds_project;
            gv_stock_project.DataBind();
            Session["ICS_Stock_Project"] = ds_project;
            suc = true;
        }
        else
        {
            gv_stock_project.DataSource = null;
            gv_stock_project.DataBind();
            ShowPageMsg("分攤計畫成本無資料");
        }
        //初始化廠商下拉式選單
        return suc;
    }

    public void UpdateServerData()
    {
        //Application["App_Mis_Company"] = CommonLib.GetCompany();
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

    //清空入庫單管理txtbox
    protected void btn_stockCancel_Click(object sender, EventArgs e)
    {
        ddl_ICSMaterial.SelectedIndex = 0;
        txt_MateralSingleValue.Text = "";
        txt_SotckInQuantity.Text = "";
        txt_StockLocation.Text = "";
        txt_materialBrand.Text = "";
        ddl_CompanyID.SelectedIndex = 0;
    }

    //清空計畫成本txtbox
    protected void btn_projectcancel_Click(object sender, EventArgs e)
    {
        txt_ContractCost.Text = "";
    }

    //新增入庫單內容
    protected void btn_stockSave_Click(object sender, EventArgs e)
    {
        SQLDB db = new SQLDB("ICS_StockIn_Item");
        if (ddl_ICSMaterial.SelectedIndex == 0)
        {
            ShowPageMsg("請選擇物料名稱");
            return;
        }
        if (txt_MateralSingleValue.Text.Length == 0)
        {
            ShowPageMsg("請輸入入庫單價");
            return;
        }
        if (txt_SotckInQuantity.Text.Length == 0)
        {
            ShowPageMsg("請輸入入庫數量");
            return;
        }
        try
        {
            //取得轉換係數
            DataSet ds_material = (DataSet)Application["App_Invetory_ICSMaterial"];
            DataRow[] dr_material = ds_material.Tables[0].Select("NO = '" + ddl_ICSMaterial.SelectedValue + "'");
            double conversionFactor = Convert.ToDouble(dr_material[0]["ConversionFactor"].ToString());

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            if (gv_stockitem.Rows.Count > 0)
            {
                ds = (DataSet)Session["StockInItem"];
            }
            else
            {
                ds = db.Select("1 =0", "", "ICS_StockIn_Item");
                //加入流水號欄位，用在刪除gridview項目用的
                ds.Tables[0].Columns.Add("rowindex");
            }

            int sq = Convert.ToInt32(txt_SotckInQuantity.Text);//入庫數量
            int value = Convert.ToInt32(txt_MateralSingleValue.Text);//單價
            int cost = sq * value; //計算入庫成本

            DataRow dr = ds.Tables[0].NewRow();
            dr["MaterialID"] = ddl_ICSMaterial.SelectedValue;
            dr["MaterialName"] = ddl_ICSMaterial.SelectedItem.Text;
            dr["Stock_Location"] = txt_StockLocation.Text;
            dr["StockIn_Quantity"] = sq;
            dr["Material_Single_Value"] = value;
            dr["StockIn_Cost"] = cost;
            dr["Quantity"] = sq * conversionFactor;
            if (ddl_CompanyID.SelectedIndex != 0)
            {
                dr["CompanyID"] = ddl_CompanyID.SelectedValue;
                dr["ComapnyName"] = ddl_CompanyID.SelectedItem.Text;
            }
            if (txt_materialBrand.Text.Trim().Length > 0)
            {
                dr["MaterialBrand"] = txt_materialBrand.Text;
            }
            ds.Tables[0].Rows.Add(dr);
            //塞流水號
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["rowindex"] = i + 1;
            }
            gv_stockitem.DataSource = ds;
            gv_stockitem.DataBind();
            Session["StockInItem"] = ds;
        }
        catch (Exception ex)
        {
            ShowMsg(UpdatePanel1, ex.Message);
            //throw;
        }
    }

    //新增計畫成本內容
    protected void btn_projectSave_Click(object sender, EventArgs e)
    {
        SQLDB db = new SQLDB("ICS_Stock_Project");
        if (ddl_ProjectName.SelectedIndex == 0)
        {
            ShowPageMsg("請選擇計畫編號");
            return;
        }
        if (txt_ContractCost.Text.Length == 0)
        {
            ShowPageMsg("請輸入分攤成本");
            return;
        }


        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        if (gv_stock_project.Rows.Count > 0)
        {
            ds = (DataSet)Session["ICS_Stock_Project"];
        }
        else
        {
            ds = db.Select("1 =0", "", "ICS_Stock_Project");
            //加入流水號欄位，用在刪除gridview項目用的
            ds.Tables[0].Columns.Add("rowindex");
        }
        DataRow dr = ds.Tables[0].NewRow();
        dr["ProjectID"] = ddl_ProjectName.SelectedValue;
        dr["ProjectName"] = ddl_ProjectName.SelectedItem.Text;
        dr["ContractCost"] = txt_ContractCost.Text;
        ds.Tables[0].Rows.Add(dr);
        //塞流水號
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ds.Tables[0].Rows[i]["rowindex"] = i + 1;
        }
        gv_stock_project.DataSource = ds;
        gv_stock_project.DataBind();
        Session["ICS_Stock_Project"] = ds;

    }
    protected void gv_stockitem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void gv_stock_project_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void btn_saveAll_Click(object sender, EventArgs e)
    {
        DataSet ds_StockInItem = (DataSet)Session["StockInItem"];
        DataSet ds_StockProject = (DataSet)Session["ICS_Stock_Project"];
        #region 驗證是否有輸入資料
        if (ds_StockInItem == null || ds_StockProject == null)
        {
            ShowMsg2(UpdatePanel1, "請輸入資料");
            return;
        }
        #endregion
        #region 驗證物料成本跟計畫分攤成本有沒有相同
        int stockcost = 0;
        int projectcost = 0;
        //驗證物料成本跟計畫分攤成本有沒有相同
        if (ds_StockInItem != null)
        {
            for (int i = 0; i < ds_StockInItem.Tables[0].Rows.Count; i++)
            {
                stockcost += Convert.ToInt32(ds_StockInItem.Tables[0].Rows[i]["StockIn_Cost"].ToString());

            }
        }
        if (ds_StockProject!= null)
        {
            for (int j = 0; j < ds_StockProject.Tables[0].Rows.Count; j++)
            {
                projectcost += Convert.ToInt32(ds_StockProject.Tables[0].Rows[j]["ContractCost"].ToString());
            }
        }
        if (stockcost != projectcost)
        {
            ShowMsg2(UpdatePanel1, "入庫單總成本與計畫總成本不一致，請重新調整");
            return;
        }
        #endregion
        #region 新增入庫資料與計畫成本

        string userid = (string)Session["UserID"];
        string stockinid = "";
        SQLDB db = new SQLDB();
        DateTime now = DateTime.Now;
        
        if (hidden_Action.Value == "add")
        {
            //將入庫單時間紀錄起來，之後利用入庫單時間與登入者帳號抓取入庫單編號
            string Stockin_date = now.ToString("yyyy/MM/dd HH:mm:ss");
            string insertstockrecord = "INSERT INTO ICS_StockIn_Record ([UpdateTime],[UpdateUser]) VALUES ('" + Stockin_date + "','" + userid + "')";

            if (db.ExecuteStatement(insertstockrecord))
            {
                DataSet ds = db.Select("UpdateTime ='" + Stockin_date + "'and UpdateUser ='" + userid + "'", "", "ICS_StockIn_Record");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //抓到入庫單編號
                    stockinid = ds.Tables[0].Rows[0]["StockInID"].ToString();

                    //將入庫單編號塞到StockInItem裡
                    for (int i = 0; i < ds_StockInItem.Tables[0].Rows.Count; i++)
                    {
                        DataRow dr = ds_StockInItem.Tables[0].Rows[i];
                        dr["StockInID"] = stockinid;
                        dr["UpdateTime"] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                        dr["UpdateUser"] = userid;
                    }
                    //將入庫單編號塞到StockProject裡
                    for (int j = 0; j < ds_StockProject.Tables[0].Rows.Count; j++)
                    {
                        DataRow dr = ds_StockProject.Tables[0].Rows[j];
                        dr["StockInID"] = stockinid;
                        dr["UpdateTime"] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                        dr["UpdateUser"] = userid;
                    }
                    //刪除rowindex欄位
                    ds_StockInItem.Tables[0].Columns.Remove("rowindex");
                    ds_StockProject.Tables[0].Columns.Remove("rowindex");
                    DataSet DSChangeItem = ds_StockInItem.GetChanges();
                    DataSet DSChangeProject = ds_StockProject.GetChanges();
                    if (db.Insert(DSChangeItem))
                        ShowMsg2(UpdatePanel1, "入庫單內容新增成功");
                    else
                        ShowMsg2(UpdatePanel1, "入庫單內容新增失敗");

                    if (db.Insert(DSChangeProject))
                        ShowMsg2(UpdatePanel1, "入庫分攤成本新增成功");
                    else
                        ShowMsg2(UpdatePanel1, "入庫分攤成本新增失敗");
                }
            }

        }
        else//入庫單內容修改(目前暫時隱藏因為要考量的東西太多)
        {
            DataSet DSChangeItem = ds_StockInItem.GetChanges(DataRowState.Deleted);
            DataSet DSChangeProject = ds_StockProject.GetChanges(DataRowState.Deleted);
            if (DSChangeItem != null)
            {
                if (db.Update(DSChangeItem))
                    ShowMsg2(UpdatePanel1, "入庫單內容修改成功");
                else
                    ShowMsg2(UpdatePanel1, "入庫單內容修改失敗");
            }
            if (DSChangeProject != null)
            {
                if (db.Update(DSChangeProject))
                    ShowMsg2(UpdatePanel1, "入庫分攤成本修改成功");
                else
                    ShowMsg2(UpdatePanel1, "入庫分攤成本修改失敗");
            }
        }
        #endregion

        #region 更新物料庫存量與料價

        #region 舊寫法用庫存資料即時算出物料庫存量與料價再存到ICS_Inventory
        /* 
        //更新庫存量
        //庫存數量 = 目前庫存數量+(入庫數 X 轉換係數)

        //查詢庫存資料
        DataSet ds_inventory = db.Select("", "", "ICS_Inventory");
        //查詢物料轉換係數
        DataSet ds_material = db.Select("", "", "ICS_Material");
        for (int i = 0; i < ds_StockInItem.Tables[0].Rows.Count; i++)
        {
            string materialid = ds_StockInItem.Tables[0].Rows[i]["MaterialID"].ToString();
            string materialName = ds_StockInItem.Tables[0].Rows[i]["MaterialName"].ToString();
            int stockInQuantity = Convert.ToInt32(ds_StockInItem.Tables[0].Rows[i]["StockIn_Quantity"].ToString());
            int materialValue = Convert.ToInt32(ds_StockInItem.Tables[0].Rows[i]["Material_Single_Value"].ToString());
            int stockinCost = Convert.ToInt32(ds_StockInItem.Tables[0].Rows[i]["StockIn_Cost"].ToString());

            DataRow[] dr_invertory = ds_inventory.Tables[0].Select("MaterialID = '" + materialid + "'");
            DataRow[] dr_material = ds_material.Tables[0].Select("NO = '" + materialid + "'");
            double ConversionFactor = Convert.ToDouble(dr_material[0]["ConversionFactor"].ToString());//轉換係數
            //若庫存有資料
            if (dr_invertory.Length > 0)
            {
                double invetory_stockinquantity = Convert.ToDouble(dr_invertory[0]["StockInQuantity"].ToString());//庫存購入數量
                double invetory_q = Convert.ToDouble(dr_invertory[0]["Quantity"].ToString());//庫存量
                double inventoryCost = Convert.ToDouble(dr_invertory[0]["InventoryCost"].ToString());//庫存成本
                //更新庫存購入數量:庫存購入數量+入庫量
                dr_invertory[0]["StockInQuantity"] = invetory_stockinquantity + stockInQuantity;
                //更新庫存數量:庫存數量 = 目前庫存數量+(入庫數 X 轉換係數)
                dr_invertory[0]["Quantity"] = invetory_q + (stockInQuantity * ConversionFactor);
                //更新料價: (庫存成本+入庫成本)/(庫存數量+入庫數量)
                dr_invertory[0]["MaterialCost"] = (inventoryCost + stockinCost) / (stockInQuantity + invetory_stockinquantity);
                //更新庫存成本:料價 X 庫存購入數量
                dr_invertory[0]["InventoryCost"] = (inventoryCost + stockinCost) / (stockInQuantity + invetory_stockinquantity) * (invetory_stockinquantity + stockInQuantity);
                dr_invertory[0]["UpdateTime"] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            }
            else//若庫存無此物料資料則新增
            {
                DataRow dr = ds_inventory.Tables[0].NewRow();
                dr["MaterialID"] = materialid;
                dr["MaterialName"] = materialName;
                dr["StockInQuantity"] = stockInQuantity;
                dr["Quantity"] = stockInQuantity * ConversionFactor;
                dr["MaterialCost"] = materialValue;
                dr["InventoryCost"] = stockinCost;
                dr["UpdateTime"] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                dr["UpdateUser"] = userid;
                ds_inventory.Tables[0].Rows.Add(dr);
            }

        }
        DataSet ds_invetoryEdit = ds_inventory.GetChanges();
        if (db.Update(ds_invetoryEdit))
            ShowMsg2(UpdatePanel1, "庫存量更新成功、料價更新成功");
        else
            ShowMsg2(UpdatePanel1, "庫存量更新成功、料價更新失敗");
         */
        #endregion

        #region 新寫法:從View_ICS_Inventory查出物料庫存量與料價再存到ICS_Inventory_History
        //更新庫存量
        //庫存數量 = 目前庫存數量+(入庫數 X 轉換係數)

        
        //組出要查詢的入庫物料
        StringBuilder stockinItem = new StringBuilder("MaterialID in (");
        for (int i = 0; i < ds_StockInItem.Tables[0].Rows.Count; i++)
        {
            string materialid  = ds_StockInItem.Tables[0].Rows[i]["MaterialID"].ToString();
            stockinItem.Append(" ' ");
            stockinItem.Append(materialid);
            stockinItem.Append(" ',");
        }
        stockinItem.Remove(stockinItem.Length - 1, 1);  //將最後的,號拿掉
        stockinItem.Append(")");
        
        //查詢View_ICS_Inventory即時物料庫存量與料價
        DataSet ds_viewInventory = db.Select(stockinItem.ToString(), "", "View_ICS_Inventory");
        //查詢庫存歷史資料
        DataSet ds_inventoryHis = db.Select(" 1= 0", "", "ICS_Inventory_History");

        for (int i = 0; i < ds_StockInItem.Tables[0].Rows.Count; i++)
        {
            string materialid = ds_StockInItem.Tables[0].Rows[i]["MaterialID"].ToString();
            string materialName = ds_StockInItem.Tables[0].Rows[i]["MaterialName"].ToString();
            string stockLocation = ds_StockInItem.Tables[0].Rows[i]["Stock_Location"].ToString();

            DataRow[] dr_viewinventory = ds_viewInventory.Tables[0].Select("MaterialID = '" + materialid + "'");
            DataRow dr = ds_inventoryHis.Tables[0].NewRow();
            dr["StockInid"] = stockinid;
            dr["MaterialID"] = materialid;
            dr["MaterialName"] = materialName;
            dr["StockInQuantity"] = Convert.ToDouble(ds_StockInItem.Tables[0].Rows[i]["StockIn_Quantity"].ToString());
            dr["Quantity"] = dr_viewinventory[0]["Quantity"];
            dr["MaterialCost"] = dr_viewinventory[0]["MaterialCost"];
            dr["InventoryCost"] = dr_viewinventory[0]["InventoryCost"];
            dr["StockLocation"] = stockLocation;
            dr["UpdateTime"] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            dr["UpdateUser"] = userid;
            ds_inventoryHis.Tables[0].Rows.Add(dr);
        }
        DataSet ds_invetoryEdit = ds_inventoryHis.GetChanges();
        if (db.Update(ds_invetoryEdit))
            ShowMsg2(UpdatePanel1, "庫存量更新成功、料價更新成功");
        else
            ShowMsg2(UpdatePanel1, "庫存量更新成功、料價更新失敗");
        #endregion
       
        #endregion
    }
    protected void gv_stockitem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //利用選取入庫編號，抓取入庫內容與入庫單計畫分攤
        if (e.CommandName == "cmDelete")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            //string rowindex = gv_stockitem.Rows[index].Cells[0].Text.Replace("&nbsp;", "");  //抓序號
            DataSet ds = (DataSet)Session["StockInItem"];
            ds.Tables[0].Rows[index].Delete();
           // ds.Tables[0].AcceptChanges();
            Session["StockInItem"] = ds;
            gv_stockitem.DataSource = ds;
            gv_stockitem.DataBind();
        }
    }
    protected void gv_stockitem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            System.Web.UI.WebControls.Button deleteButton = (System.Web.UI.WebControls.Button)e.Row.Cells[9].Controls[1];
            deleteButton.CommandArgument = e.Row.RowIndex.ToString();
            //修改資料
           // ((Button)e.Row.Cells[0].FindControl("btn_edit")).Attributes.Add("onClick", "edit('" + e.Row.Cells[1].Text.Trim() + "');return false;");
        }
    }
    protected void gv_stock_project_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //利用選取入庫編號，抓取入庫內容與入庫單計畫分攤
        if (e.CommandName == "cmDelete")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            //string rowindex = gv_stockitem.Rows[index].Cells[0].Text.Replace("&nbsp;", "");  //抓序號
            DataSet ds = (DataSet)Session["ICS_Stock_Project"];
            ds.Tables[0].Rows[index].Delete();
           // ds.Tables[0].AcceptChanges();
            Session["ICS_Stock_Project"] = ds;
            gv_stock_project.DataSource = ds;
            gv_stock_project.DataBind();
        }
    }
    protected void gv_stock_project_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            System.Web.UI.WebControls.Button deleteButton = (System.Web.UI.WebControls.Button)e.Row.Cells[3].Controls[1];
            deleteButton.CommandArgument = e.Row.RowIndex.ToString();
            //修改資料
            // ((Button)e.Row.Cells[0].FindControl("btn_edit")).Attributes.Add("onClick", "edit('" + e.Row.Cells[1].Text.Trim() + "');return false;");
        }
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("StockIn_Q.aspx");
    }

}

#line default
#line hidden
