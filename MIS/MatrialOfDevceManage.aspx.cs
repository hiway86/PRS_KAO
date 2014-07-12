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


public partial class MIS_MatrialOfDevceManage : PageBase
{
    SQLDB _operator = new SQLDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ToolkitScriptManager1.IsInAsyncPostBack)
        {
            Session["MIS_Material"] = null;
            try
            {
                if (Request.QueryString["act"] != null)
                {
                    hidden_Action.Value = Request.QueryString["act"].Trim();
                    hidden_DeviceID.Value = Request.QueryString["DID"].Trim();
                    InitData();
                    //
                    if (hidden_Action.Value.Equals("add"))
                    {
                        //txt_companyId.Enabled = false;
                        //BtnEdit("新增存檔");
                    }
                    else if (hidden_Action.Value.Equals("edit"))
                    {
                        if (Request.QueryString["DID"] != null)
                        {
                            //
                            if (LoadData())
                            {
                                //BtnEdit("修改存檔");
                            }
                            //else
                            //{
                            //    ReDirect("無所屬零件資料!!");
                            //}
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

    private bool LoadData()
    {
        bool suc = false;
        SQLDB db = new SQLDB("CD_MaterialOfDevice");
        DataSet ds = new DataSet();
        ds = db.Select("Device_ID = '"+hidden_DeviceID.Value+"'","","CD_MaterialOfDevice");
        if (ds.Tables[0].Rows.Count > 0)
        {
            suc = true;
            gv_Material.DataSource = ds;
            gv_Material.DataBind();
            Session["MIS_Material"] = ds;
        }
        return suc;
    }

    protected void ReDirect(string msg)
    {
        ShowMsgAndRedirect(UpdatePanel1, msg, "../MIS/EquipmentDataList.aspx");
    }

    protected void ShowPageMsg(string msg)
    {
        ShowMsg2(UpdatePanel1, msg);
    }

   

    protected override void InitData()
    {
        BindDropDownListData(cbo_MaterialID, (DataSet)Application["App_Invetory_ICSMaterial"], "MaterialName", "NO");
    }

    protected void btn_saveAll_Click(object sender, EventArgs e)
    {
        //DataSet ds_MaterialOfDevice = _operator.Select("Device_ID = '" + hidden_DeviceID.Value + "'", "", "CD_MaterialOfDevice");
        //if (ds_MaterialOfDevice.Tables[0].Rows.Count > 0)
        //{
        //    string deleteMaterial = "Delete from CD_MaterialOfDevice where Device_ID = '" + hidden_DeviceID.Value + "'";
        //    if (!_operator.ExecuteStatement(deleteMaterial))
        //    {
        //        ShowPageMsg("發生異常錯誤");
        //        return;
        //    }
        //}
        DataSet ds = (DataSet)Session["MIS_Material"];
        //DataSet ds2 = new DataSet();

        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    DataRow dr = ds.Tables[0].Rows[i];
        //    ds2.Tables[0].Rows.Add(dr);
        //}

        DataSet DSChangeAdd = ds.GetChanges(DataRowState.Added);
        if (DSChangeAdd != null )
        {
            if (_operator.Insert(DSChangeAdd))
            {
                ShowMsgAndRedirect(UpdatePanel1,"成功", "EquipmentDataList.aspx");
                //ShowMsg(UpdatePanel1, "成功");
                return;
            }
        }
 
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {

    }

    protected void btn_MateralAdd_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        if (Session["MIS_Material"] == null)
        {
            ds = _operator.Select("1=0", "", "CD_MaterialOfDevice");
        }
        else
            ds = (DataSet)Session["MIS_Material"];

        DataRow dr = ds.Tables[0].NewRow();
        dr["Device_ID"] = hidden_DeviceID.Value;
        dr["Material_NO"] = cbo_MaterialID.SelectedValue;
        dr["MaterialName"] = cbo_MaterialID.SelectedItem.Text;
        ds.Tables[0].Rows.Add(dr);

        ////塞流水號
        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    ds.Tables[0].Rows[i]["NO"] = i;
        //}

        DataSet DSChangeAdd = ds.GetChanges(DataRowState.Added);
        if (DSChangeAdd != null)
        {
            if (!_operator.Insert(DSChangeAdd))
            {
                ShowMsg(UpdatePanel1, "新增失敗");
                return;
            }
            else
            {
                LoadData();
            }

        }

        

    }
    protected void btn_MateralClear_Click(object sender, EventArgs e)
    {
        Session["MIS_Material"] = null;
        gv_Material.DataSource = null;
        gv_Material.DataBind();
    }
    protected void gv_Material_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmDelete")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            DataSet ds = (DataSet)Session["MIS_Material"];
            ds.Tables[0].Rows[index].Delete();
            DataSet DSChangeAdd = ds.GetChanges(DataRowState.Deleted);
            if (DSChangeAdd != null)
            {
                if (_operator.Insert(DSChangeAdd))
                {
                    LoadData();
                }
            }
        }
    }
    protected void gv_Material_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            System.Web.UI.WebControls.Button deleteButton = (System.Web.UI.WebControls.Button)e.Row.FindControl("cmd_Delete");
            deleteButton.CommandArgument = e.Row.RowIndex.ToString();
        }
    }
}