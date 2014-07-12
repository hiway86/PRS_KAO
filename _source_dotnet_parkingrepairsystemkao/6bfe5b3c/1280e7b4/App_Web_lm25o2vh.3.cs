#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\Inventory\InventoryReview_AM.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "65323433ED7FA10E8B74D3D81DC8777CB2CB2C24"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\Inventory\InventoryReview_AM.aspx.cs"
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

public partial class Inventory_InventoryReview_AM : PageBase
{
    protected SQLDB stocknow = new SQLDB("ICS_Stock_QuantityNow");
    protected SQLDB stockhis = new SQLDB("ICS_Stock_QuantityHis");
    DataSet stockDS;
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
                    
                    if (hidden_Action.Value.Equals("edit"))
                    {
                        if (Request.QueryString["id"] != null)
                        {
                            hidden_materialId.Value = Request.QueryString["id"].Trim();
                            //
                            if (LoadData())
                            {
                                txt_materialName.Enabled = false;
                                BtnEdit("修改存檔");
                                FieldEdit(false);
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
        ShowMsgAndRedirect(UpdatePanel1, msg, "../Inventory/InventoryReview_Q.aspx");
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

    }

    protected void FieldEdit(bool val)
    {

    }


    protected bool LoadData()
    {
        string materialid = Request.QueryString["id"];
        FieldEdit(false);
        bool suc = false;
        string rowfilter = "MaterialID='" + materialid + "'";

        //直接去資料庫抓
        stockDS = stocknow.Select(rowfilter);

        if (stockDS.Tables[0].Rows.Count == 1)
        {
            DataTable dt = stockDS.Tables[0];
            DataRow dr = dt.Rows[0];

            txt_materialName.Text = dr["MaterialName"].ToString();
            txt_stockQuantity.Text = dr["stockQuantity"].ToString();
            Session["DS_Mis"] = stockDS;
            suc = true;
        }
        else
        {
            DataSet ds_material = stocknow.Select("NO = '" + hidden_materialId.Value + "'", "", "ICS_Material");
            txt_materialName.Text = ds_material.Tables[0].Rows[0]["materialName"].ToString();

        }
        return suc;
    }

    public void UpdateServerData()
    {
        
    }

    protected void txt_Car_Licence_Exp_TextChanged(object sender, EventArgs e)
    {

    }
    protected void cmd_Save_Click1(object sender, EventArgs e)
    {
        string materialid = Request.QueryString["id"];
        DateTime now = DateTime.Now;
        if (hidden_Action.Value.Equals("edit"))
        {
           // DataSet ds = (DataSet)Session["DS_Mis"];
            DataSet ds_material = stocknow.Select("NO = '" + materialid + "'", "", "ICS_Material");
            DataSet ds_stock = stocknow.Select("materialid = '" + materialid + "'", "", "ICS_Stock_QuantityNow");
            if (ds_stock.Tables[0].Rows.Count > 0)
            {
                //更新NOW庫存
                ds_stock.Tables[0].Rows[0]["StockQuantity"] = txt_stockQuantity.Text;
                DataSet DSChangeNow = ds_stock.GetChanges();
                //更新His庫存
                DataSet ds_his = stockhis.Select("1 =0", "", "ICS_Stock_QuantityHis");
                DataRow dr = ds_his.Tables[0].NewRow();
                dr["MaterialID"] = materialid;
                dr["MaterialName"] = ds_material.Tables[0].Rows[0]["MaterialName"].ToString();
                dr["StockQuantity"] = txt_stockQuantity.Text;
                dr["UpdateDate"] = now;
                ds_his.Tables[0].Rows.Add(dr);
                DataSet DSChangeHis = ds_his.GetChanges();
                if (stocknow.Update(DSChangeNow) && stockhis.Insert(DSChangeHis))
                {
                    ReDirect("更新成功");
                }
                else
                {
                    ReDirect("修改失敗");
                }
            }
            else
            {
                //新增NOW庫存
                DataSet ds_Now = stockhis.Select("1 =0", "", "ICS_Stock_QuantityNow");
                DataRow dr = ds_Now.Tables[0].NewRow();
                dr["MaterialID"] = materialid;
                dr["MaterialName"] = ds_material.Tables[0].Rows[0]["MaterialName"].ToString();
                dr["StockQuantity"] = txt_stockQuantity.Text;
                dr["UpdateDate"] = now;
                ds_Now.Tables[0].Rows.Add(dr);
                DataSet DSChangeNow = ds_Now.GetChanges();
                //新增His庫存
                DataSet ds_his = stockhis.Select("1 =0", "", "ICS_Stock_QuantityHis");
                DataRow dr2 = ds_his.Tables[0].NewRow();
                dr2["MaterialID"] = materialid;
                dr2["MaterialName"] = ds_material.Tables[0].Rows[0]["MaterialName"].ToString();
                dr2["StockQuantity"] = txt_stockQuantity.Text;
                dr2["UpdateDate"] = now;
                ds_his.Tables[0].Rows.Add(dr2);
                DataSet DSChangeHis = ds_his.GetChanges();
                if (stocknow.Update(DSChangeNow) && stockhis.Insert(DSChangeHis))
                {
                    ReDirect("更新成功");
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
