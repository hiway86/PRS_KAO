using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Inventory_Inventoryadd_A : PageBase
{
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
                    //
                    if (hidden_Action.Value.Equals("add"))
                    {

                    }
                    else if (hidden_Action.Value.Equals("edit"))
                    {
                        if (Request.QueryString["id"] != null)
                        {
                            hidden_Materialid.Value = Request.QueryString["id"].Trim();
                            //
                            if (LoadData())
                            {

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
        BindDropDownListData(cbo_materialType, (DataSet)Application["App_Invetory_MaterialType"], "MaterialTypeName", "MaterialTypeID");
    }
    protected void ReDirect(string msg)
    {
        ShowMsgAndRedirect(UpdatePanel1, msg, "../Inventory/InventoryAdd_Q.aspx");
    }

    private bool LoadData()
    {
        txt_MaterialName.Enabled = false;
        SQLDB _operator = new SQLDB("ICS_Material");
        bool suc = false;
        string query = "select * from ICS_Material m left join ICS_Material_Type mt on m.MaterialTypeID = mt.MaterialTypeID where  NO =  '" + hidden_Materialid.Value + "'";
        DataSet ds2 = _operator.SelectQuery(query);
        if (ds2.Tables[0].Rows.Count == 1)
        {
            suc = true;
            DataTable dt = ds2.Tables[0];
            DataRow dr = dt.Rows[0];
            txt_MaterialName.Text = dr["MaterialName"].ToString();
            cbo_materialType.SelectedValue = dr["MaterialTypeID"].ToString();
            txt_MaterialSafeQuantity.Text = dr["MaterialSafeQuantity"].ToString();
            txt_MaterialUnit.Text = dr["MaterialUnit"].ToString();
        }
        return suc;
    }


    protected void TextBox4_TextChanged(object sender, EventArgs e)
    {
        if (!IsNumeric(txt_MaterialSafeQuantity.Text))
        {
            txt_MaterialSafeQuantity.Text = "";
        }
    }

    public bool IsNumeric(String strNumber)
    {
        Regex NumberPattern = new Regex("[^0-9.-]");
        return !NumberPattern.IsMatch(strNumber);
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        Staff _operator = new Staff("Company");
        //物料名稱
        String my_MaterialName = txt_MaterialName.Text;
        //物料單位
        String my_MaterialUnit = txt_MaterialUnit.Text;
        //安全存量
        String my_MaterialSafeQuantity = txt_MaterialSafeQuantity.Text;
        //更新人員
        String USER;
        if (Session["UserID"] != null)
        {
            USER = Session["UserID"].ToString();
        }
        else
        {
            USER = "admin";
        }
        if (hidden_Action.Value == "add")
        {
            string sql = "INSERT INTO ICS_Material (MaterialName,MaterialUnit,MaterialSafeQuantity,UpdateTime,UpdateUser,MaterialTypeID) VALUES  ('" + my_MaterialName.ToString() + "','" + my_MaterialUnit.ToString() + "','" + my_MaterialSafeQuantity.ToString() + "',getdate(),'" + USER + "','" + cbo_materialType.SelectedValue + "')  ";
            if (_operator.ExecuteStatement(sql))
            {
                ShowMsg2(UpdatePanel1, "儲存成功");
                UpdateServerData(); //更新Application Data
                Response.AddHeader("Refresh", "3; url=Inventory_AQM.aspx");
            }
            else
            {
                ShowMsg2(UpdatePanel1, "儲存失敗");

            }
        }
        else
        {
            SQLDB db = new SQLDB();
            DataSet ds = new DataSet();
            ds = db.Select("NO = '"+hidden_Materialid.Value+"'","","ICS_Material");
            DataRow dr = ds.Tables[0].Rows[0];
            dr["MaterialName"] = my_MaterialName.ToString();
            dr["MaterialUnit"] = my_MaterialUnit.ToString();
            dr["MaterialSafeQuantity"] = my_MaterialSafeQuantity.ToString();
            dr["UpdateTime"] = DateTime.Now;
            dr["UpdateUser"] = USER;
            dr["MaterialTypeID"] = cbo_materialType.SelectedValue;
            DataSet DSChange = ds.GetChanges(DataRowState.Modified);
            //string sql = "UPDATE from ICS_Material (MaterialName,MaterialUnit,MaterialSafeQuantity,UpdateTime,UpdateUser,MaterialTypeID) VALUES  ('" + my_MaterialName.ToString() + "','" + my_MaterialUnit.ToString() + "','" + my_MaterialSafeQuantity.ToString() + "',getdate(),'" + USER + "','" + cbo_materialType.SelectedValue + "')  ";
            if (db.Update(DSChange))
            {
                ShowMsg2(UpdatePanel1, "儲存成功");
                UpdateServerData(); //更新Application Data
                Response.AddHeader("Refresh", "3; url=Inventory_AQM.aspx");
            }
            else
            {
                ShowMsg2(UpdatePanel1, "儲存失敗");

            }
        }

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("InventoryAdd_Q.aspx");
    }
    

    public void UpdateServerData()
    {
        Application["App_Invetory_ICSMaterial"] = CommonLib.GetICSMaterial();
    }
}