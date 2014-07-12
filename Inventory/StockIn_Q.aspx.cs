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

public partial class Inventory_StockIn_Q : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ScriptManager1.IsInAsyncPostBack)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "addSearchIcon();", true);
            //隱藏顯示欄位
            GridViewHidden(this.gv_stockitem, 11); //更新時間
            GridViewHidden(this.gv_stockitem, 12); //更新者
            GridViewHidden(this.gv_stock_project, 5); //更新時間
            GridViewHidden(this.gv_stock_project, 6); //更新者
            InitData();
            SearchData();
        }
    }

    protected override void InitData()
    {
        for (int i = 0; i < this.gv.Columns.Count; i++)
        {
            if (this.gv.Columns[i] is BoundField && gv.Columns[i].HeaderStyle.CssClass != "gridviewhiddenrow")
            {
                ListItem item = new ListItem();
                item.Text = gv.Columns[i].HeaderText;
                item.Value = ((BoundField)gv.Columns[i]).DataField;
                this.ddlst_SearchType.Items.Add(item);
            }
        }
    }

    protected void SearchData()
    {
        //string query_company = GetCompanyScope();
        Staff _operator = new Staff("ICS_StockIn_Record");
        string conditionName = ddlst_SearchType.SelectedValue;
        string condition = (txt_Query_Reason.Text.Trim().Length > 0 ? " " + conditionName + " like '%" + txt_Query_Reason.Text.Trim() + "%' " : "");
        //condition += query_company;
        DataSet ds = _operator.Select(condition,"UpdateTIme desc");
        Session["DS_MIS"] = ds;
        gv.DataSource = ds;
        gv.DataBind();
      
        if (ds.Tables[0].Rows.Count == 0)
        {
            ShowMsg2(UpdatePanel1, "查詢無資料");
        }
    }


    protected void lnkbtn_Search_Click(object sender, EventArgs e)
    {
        SearchData();
    }

    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gv.PageIndex = e.NewPageIndex;
        SearchData();
    }
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Button editButton = (Button)e.Row.Cells[0].Controls[1];
            editButton.CommandArgument = e.Row.RowIndex.ToString();
            Button btnDelete = (Button)e.Row.Cells[0].FindControl("btn_Delete");
            btnDelete.CommandArgument = e.Row.Cells[1].Text;
            //先將修改功能隱藏
            //修改資料
            //((Button)e.Row.Cells[0].FindControl("btn_edit")).Attributes.Add("onClick", "edit('" + e.Row.Cells[1].Text.Trim() + "');return false;");
        }

    }
    protected void lnkbtn_Report_Click(object sender, EventArgs e)
    {
        //ExportTOExcel();
    }

    //private void ExportTOExcel()
    //{
    //    ExcelReport report = null;
    //    try
    //    {
    //        report = new ExcelReport("MIS/Company");

    //        DataSet ds = (DataSet)Session["DS_MIS"];

    //        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
    //        {
    //            report.FillData(j + 3, 1, ds.Tables[0].Rows[j]["CompanyID"].ToString(), 1);
    //            report.FillData(j + 3, 2, ds.Tables[0].Rows[j]["CompanyName"].ToString(), 1);
    //            report.FillData(j + 3, 3, ds.Tables[0].Rows[j]["Contact"].ToString(), 1);
    //            report.FillData(j + 3, 4, ds.Tables[0].Rows[j]["ContactPhone"].ToString(), 1);
    //            report.FillData(j + 3, 5, ds.Tables[0].Rows[j]["ContactPhoneExet"].ToString(), 1);
    //            report.FillData(j + 3, 6, ds.Tables[0].Rows[j]["ContactMobile"].ToString(), 1);
    //            report.FillData(j + 3, 7, ds.Tables[0].Rows[j]["Contact2"].ToString(), 1);
    //            report.FillData(j + 3, 8, ds.Tables[0].Rows[j]["Contact2Phone"].ToString(), 1);
    //            report.FillData(j + 3, 9, ds.Tables[0].Rows[j]["Contact2PhoneExet"].ToString(), 1);
    //            report.FillData(j + 3, 10, ds.Tables[0].Rows[j]["Contact2Mobile"].ToString(), 1);
    //            report.FillData(j + 3, 11, ds.Tables[0].Rows[j]["Fax"].ToString(), 1);
    //            report.FillData(j + 3, 12, ds.Tables[0].Rows[j]["Email"].ToString(), 1);
    //            report.FillData(j + 3, 13, ds.Tables[0].Rows[j]["Address"].ToString(), 1);
    //            report.FillData(j + 3, 14, ds.Tables[0].Rows[j]["CompanyGroup"].ToString(), 1);
    //            report.FillData(j + 3, 15, ds.Tables[0].Rows[j]["Note"].ToString(), 1);
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
    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //利用選取入庫編號，抓取入庫內容與入庫單計畫分攤
        if (e.CommandName == "Search")
        {
            labelView(true);
            int index = Convert.ToInt32(e.CommandArgument);
            string stockinid = gv.Rows[index].Cells[1].Text.Replace("&nbsp;", "");  //入庫編號
            hid_stockinid.Value = stockinid;
            SearchStockItemProject(stockinid);
        }

        if (e.CommandName == "btnDelete")
        {
            string stockinid = e.CommandArgument.ToString();
            hid_stockinid.Value = stockinid;
            DeleteStockIn(stockinid);
        }
    }

    //刪除入庫紀錄單、入庫單內容、計畫分攤成本
    private void DeleteStockIn(string stockinid)
    {
        string userid = (string)Session["UserID"];
        SQLDB db = new SQLDB();

        #region 更新庫存量資料表相關欄位
        //DataSet ds_StockInItem = db.Select("StockInID = '" + stockinid + "'", "", "ICS_StockIn_Item");
        //if (ds_StockInItem.Tables[0].Rows.Count> 0)
        //{
        //    //更新庫存量
        //    //庫存數量 = 目前庫存數量+(入庫數 X 轉換係數)

        //    //查詢庫存資料
        //    DataSet ds_inventory = db.Select("", "", "ICS_Inventory");
        //    //查詢物料轉換係數
        //    DataSet ds_material = db.Select("", "", "ICS_Material");
        //    for (int i = 0; i < ds_StockInItem.Tables[0].Rows.Count; i++)
        //    {
        //        string materialid = ds_StockInItem.Tables[0].Rows[i]["MaterialID"].ToString();
        //        string materialName = ds_StockInItem.Tables[0].Rows[i]["MaterialName"].ToString();
        //        int stockInQuantity = Convert.ToInt32(ds_StockInItem.Tables[0].Rows[i]["StockIn_Quantity"].ToString());
        //        int materialValue = Convert.ToInt32(ds_StockInItem.Tables[0].Rows[i]["Material_Single_Value"].ToString());
        //        int stockinCost = Convert.ToInt32(ds_StockInItem.Tables[0].Rows[i]["StockIn_Cost"].ToString());

        //        DataRow[] dr_invertory = ds_inventory.Tables[0].Select("MaterialID = '" + materialid + "'");
        //        DataRow[] dr_material = ds_material.Tables[0].Select("NO = '" + materialid + "'");
        //        double ConversionFactor = Convert.ToDouble(dr_material[0]["ConversionFactor"].ToString());//轉換係數
        //        //若庫存有資料
        //        if (dr_invertory.Length > 0)
        //        {
        //            double invetory_stockinquantity = Convert.ToDouble(dr_invertory[0]["StockInQuantity"].ToString());//庫存購入數量
        //            double invetory_q = Convert.ToDouble(dr_invertory[0]["Quantity"].ToString());//庫存量
        //            double inventoryCost = Convert.ToDouble(dr_invertory[0]["InventoryCost"].ToString());//庫存成本
        //            //更新庫存購入數量:庫存購入數量-(刪除)入庫量
        //            double INStockInQuantity = invetory_stockinquantity - stockInQuantity;
        //            if (INStockInQuantity < 0)
        //                dr_invertory[0]["StockInQuantity"] = 0;
        //            else
        //                dr_invertory[0]["StockInQuantity"] = INStockInQuantity;
        //            //更新庫存數量:庫存數量 = 目前庫存數量-((刪除)入庫數 X 轉換係數)
        //            double quantity =invetory_q - (stockInQuantity * ConversionFactor);
        //            if (quantity < 0)
        //                dr_invertory[0]["Quantity"] = 0;
        //            else
        //                dr_invertory[0]["Quantity"] = invetory_q - (stockInQuantity * ConversionFactor);
        //            //更新料價: (庫存成本-(刪除)入庫成本)/(庫存數量-(刪除)入庫數量)
        //            if ((inventoryCost - stockinCost) <= 0 || (stockInQuantity - invetory_stockinquantity) <= 0 || (invetory_stockinquantity - stockInQuantity) <= 0)
        //            {
        //                dr_invertory[0]["MaterialCost"] = 0;
        //                dr_invertory[0]["InventoryCost"] = 0;
        //            }
        //            else
        //            {   //更新料價: (庫存成本-(刪除)入庫成本)/(庫存數量-(刪除)入庫數量)
        //                dr_invertory[0]["MaterialCost"] = (inventoryCost - stockinCost) / (invetory_stockinquantity -stockInQuantity);
        //                //更新庫存成本:料價 X (刪除)庫存購入數量
        //                dr_invertory[0]["InventoryCost"] = (inventoryCost - stockinCost) / (invetory_stockinquantity - stockInQuantity) * (invetory_stockinquantity - stockInQuantity);
        //            }
        //            dr_invertory[0]["UpdateTime"] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        //        }
        //    }
        //    DataSet ds_invetoryEdit = ds_inventory.GetChanges();
        //    if (db.Update(ds_invetoryEdit))
        //        ShowMsg2(UpdatePanel1, "庫存量更新成功、料價更新成功");
        //    else
        //        ShowMsg2(UpdatePanel1, "庫存量更新成功、料價更新失敗");
        //    SearchData();
        //}
        #endregion
        #region 刪除入庫紀錄單、入庫單內容、計畫分攤成本
        string delete_stockRecord = "Delete ICS_StockIn_Record where stockInID = '" + stockinid + "'";
        string delete_stockitem = "Delete ICS_StockIn_Item where stockInID = '" + stockinid + "'";
        string delete_stockproject = "Delete ICS_Stock_Project where stockInID = '" + stockinid + "'";
        bool suc = false;
        suc = db.ExecuteStatement(delete_stockRecord);
        suc = db.ExecuteStatement(delete_stockitem);
        suc = db.ExecuteStatement(delete_stockproject);
        if (suc)
        {
            ShowMsg2(UpdatePanel1, "刪除成功");
        }
        else
            ShowMsg2(UpdatePanel1, "刪除失敗");
        #endregion
        SearchData();

        //TODO:應該在刪除入庫資料後存一份入庫歷史資料
    }


    //顯示入庫單label與入庫單計畫分擔label
    private void labelView(bool view)
    {
        lbl_stockitem.Visible = view;
        lbl_stockproject.Visible = view;
    }

    //搜尋入庫單內容與入庫單計畫分攤
    private void SearchStockItemProject(string stockinid)
    {
        SQLDB _operator = new SQLDB();
        //抓取入庫內容
        DataSet DS = _operator.Select("stockInID = '" + stockinid + "'", "", "ICS_StockIn_Item");
        if (DS.Tables[0].Rows.Count > 0)
        {
            gv_stockitem.DataSource = DS;
            gv_stockitem.DataBind();
        }
        else
        {
            gv_stockitem.DataSource = null;
            gv_stockitem.DataBind();
            ShowMsg2(UpdatePanel1, "入庫單內容無資料");
            labelView(false);
        }
        //抓取計畫分攤成本
        DataSet ds_project = _operator.Select("stockInID = '" + stockinid + "'", "", "ICS_Stock_Project");
        if (ds_project.Tables[0].Rows.Count > 0)
        {
            gv_stock_project.DataSource = ds_project;
            gv_stock_project.DataBind();
        }
        else
        {
            gv_stock_project.DataSource = null;
            gv_stock_project.DataBind();
            ShowMsg2(UpdatePanel1, "計畫分攤無資料");
            labelView(false);
        }
    }
    protected void gv_stockitem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gv_stockitem.PageIndex = e.NewPageIndex;
        SearchStockItemProject(hid_stockinid.Value);
        //DataSet ds = (DataSet)Session["DS_MIS"];
        //this.gv.DataSource = ds;
        //this.gv.DataBind();
    }
    protected void gv_stock_project_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gv_stock_project.PageIndex = e.NewPageIndex;
        SearchStockItemProject(hid_stockinid.Value);
        //DataSet ds = (DataSet)Session["DS_MIS"];
        //this.gv.DataSource = ds;
        //this.gv.DataBind();
    }
}

