using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class MIS_Project_AM : PageBase
{
    SQLDB _operator = new SQLDB();
    protected void Page_Load(object sender, EventArgs e)
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
                    //txt_companyId.Enabled = false;
                    BtnEdit("新增存檔");
                    FieldEdit(true);
                }
                else if (hidden_Action.Value.Equals("edit"))
                {
                    if (Request.QueryString["id"] != null)
                    {
                        hidden_projectno.Value = Request.QueryString["id"].Trim();
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

    protected void ReDirect(string msg)
    {
        ShowMsgAndRedirect(UpdatePanel1, msg, "../MIS/Project_QD.aspx");
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
        //BindDropDownListData(cbo_companyGoup, (DataSet)Application["App_Mis_CompanyGroup"], "CompanyGroupName", "CompanyGroupID");
    }

    protected void FieldEdit(bool val)
    {

    }

    protected bool LoadData()
    {
        FieldEdit(false);
        bool suc = false;
        string rowfilter = "projectno =  " + hidden_projectno.Value;

        //第一種方法：直接去資料庫抓

        DataSet ds2 = _operator.Select(rowfilter, "", "ICS_Project");
        if (ds2.Tables[0].Rows.Count == 1)
        {
            suc = true;
            DataTable dt = ds2.Tables[0];
            DataRow dr = dt.Rows[0];
            txt_projectId.Text = dr["ProjectID"].ToString();
            txt_projectName.Text = dr["ProjectName"].ToString();
            if (dr["Client"].ToString().Trim().Length > 0)
            {
                txt_client.Text = dr["Client"].ToString();
            }
            if (dr["StartDate"].ToString().Trim().Length > 0)
            {
                DateTime startdate = new DateTime();
                startdate = Convert.ToDateTime(dr["StartDate"].ToString());
                txt_startDate.Text = startdate.ToString("yyyy/MM/dd HH:mm:ss");
            }
            if (dr["EndDate"].ToString().Trim().Length > 0)
            {
                DateTime enddate = new DateTime();
                enddate = Convert.ToDateTime(dr["enddate"].ToString());
                txt_endDate.Text = enddate.ToString("yyyy/MM/dd HH:mm:ss");
            }

            if (dr["WarStartDate"].ToString().Trim().Length > 0)
            {
                DateTime warstartdate = new DateTime();
                warstartdate = Convert.ToDateTime(dr["WarStartDate"].ToString());
                txt_warStartDate.Text = warstartdate.ToString("yyyy/MM/dd HH:mm:ss");
            }
            if (dr["WarEndDate"].ToString().Trim().Length > 0)
            {
                DateTime warenddate = new DateTime();
                warenddate = Convert.ToDateTime(dr["WarEndDate"].ToString());
                txt_warEndDate.Text = warenddate.ToString("yyyy/MM/dd HH:mm:ss");
            }


        }

        //第二種方法：從List中所存Session找出DataSset，再找出DataRow，但無法使用DS.GETChange，因為GetDataRow後之ds已被搜尋過
        /*
        DataSet ds = (DataSet)Session["DS_Mis"];
        DataRow dr = _operator.GetDataRow(ds, rowfilter);
        if (dr != null)
        {
            suc = true;
            txt_BreakDown_Type.Text = dr["BreakDown_Type"].ToString().Trim();
        }
         */
        return suc;
    }

    public void UpdateServerData()
    {
        Application["App_Mis_Company"] = CommonLib.GetCompany();
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

    protected void cmd_Save_Click1(object sender, EventArgs e)
    {
        int suc = 0;
        SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["MROSConnectionString"].ConnectionString);
        SqlDataAdapter myAdapter = new SqlDataAdapter();

        //----------------------事先寫好 UpdateCommand ------------------------------------------------------------------
        myAdapter.UpdateCommand = new SqlCommand("UPDATE [ICS_Project] SET [ProjectID] = @ProjectID, [ProjectName] = @ProjectName, " +
  " [Client] = @Client,[StartDate] = @StartDate ,[EndDate] = @EndDate,[WarStartDate] = @WarStartDate, [WarEndDate] = @WarEndDate, " +
  " [UpdateTime] = @UpdateTime , [UpdateUser] = @UpdateUser WHERE [ProjectNO] = @ProjectNO ", Conn);

        myAdapter.InsertCommand = new SqlCommand("INSERT INTO [ICS_Project] ([ProjectID], [ProjectName], [Client], [StartDate], [EndDate], [WarStartDate], [WarEndDate], [UpdateTime], [UpdateUser]) VALUES (@ProjectID, @ProjectName, @Client, @StartDate, @EndDate, @WarStartDate, @WarEndDate, @UpdateTime, @UpdateUser)", Conn);

        myAdapter.UpdateCommand.Parameters.Add("@ProjectNO", SqlDbType.Int);
        myAdapter.UpdateCommand.Parameters["@ProjectNO"].Value = hidden_projectno.Value;

        myAdapter.UpdateCommand.Parameters.Add("@ProjectID", SqlDbType.Int);
        myAdapter.UpdateCommand.Parameters["@ProjectID"].Value = txt_projectId.Text;

        myAdapter.UpdateCommand.Parameters.Add("@ProjectName", SqlDbType.VarChar, 100);
        myAdapter.UpdateCommand.Parameters["@ProjectName"].Value = txt_projectName.Text;

        myAdapter.UpdateCommand.Parameters.Add("@Client", SqlDbType.VarChar, 50);
        myAdapter.UpdateCommand.Parameters["@Client"].Value = txt_client.Text;

        myAdapter.UpdateCommand.Parameters.Add("@StartDate", SqlDbType.DateTime);
        myAdapter.UpdateCommand.Parameters["@StartDate"].Value = txt_startDate.Text;

        myAdapter.UpdateCommand.Parameters.Add("@EndDate", SqlDbType.DateTime);
        myAdapter.UpdateCommand.Parameters["@EndDate"].Value = txt_endDate.Text;

        myAdapter.UpdateCommand.Parameters.Add("@WarStartDate", SqlDbType.DateTime);
        myAdapter.UpdateCommand.Parameters["@WarStartDate"].Value = txt_warStartDate.Text;

        myAdapter.UpdateCommand.Parameters.Add("@WarEndDate", SqlDbType.DateTime);
        myAdapter.UpdateCommand.Parameters["@WarEndDate"].Value = txt_warEndDate.Text;

        myAdapter.UpdateCommand.Parameters.Add("@UpdateTime", SqlDbType.DateTime);
        myAdapter.UpdateCommand.Parameters["@UpdateTime"].Value = DateTime.Now;

        myAdapter.UpdateCommand.Parameters.Add("@UpdateUser", SqlDbType.VarChar, 50);
        myAdapter.UpdateCommand.Parameters["@UpdateUser"].Value = Session["UserID"].ToString();


        DateTime startdate = new DateTime();
        DateTime enddate = new DateTime();
        DateTime warstart = new DateTime();
        DateTime warend = new DateTime();

        startdate = Convert.ToDateTime(txt_startDate.Text);
        enddate = Convert.ToDateTime(txt_endDate.Text);
        warstart = Convert.ToDateTime(txt_warStartDate.Text);
        warend = Convert.ToDateTime(txt_warEndDate.Text);

        myAdapter.InsertCommand.Parameters.Add("@ProjectID", SqlDbType.Int);
        myAdapter.InsertCommand.Parameters["@ProjectID"].Value = txt_projectId.Text;

        myAdapter.InsertCommand.Parameters.Add("@ProjectName", SqlDbType.VarChar, 100);
        myAdapter.InsertCommand.Parameters["@ProjectName"].Value = txt_projectName.Text;

        myAdapter.InsertCommand.Parameters.Add("@Client", SqlDbType.VarChar, 50);
        myAdapter.InsertCommand.Parameters["@Client"].Value = txt_client.Text;

        myAdapter.InsertCommand.Parameters.Add("@StartDate", SqlDbType.DateTime);
        myAdapter.InsertCommand.Parameters["@StartDate"].Value = startdate.ToString("yyyy/MM/dd HH:mm:ss");

        myAdapter.InsertCommand.Parameters.Add("@EndDate", SqlDbType.DateTime);
        myAdapter.InsertCommand.Parameters["@EndDate"].Value = enddate.ToString("yyyy/MM/dd HH:mm:ss");

        myAdapter.InsertCommand.Parameters.Add("@WarStartDate", SqlDbType.DateTime);
        myAdapter.InsertCommand.Parameters["@WarStartDate"].Value = warstart.ToString("yyyy/MM/dd HH:mm:ss");

        myAdapter.InsertCommand.Parameters.Add("@WarEndDate", SqlDbType.DateTime);
        myAdapter.InsertCommand.Parameters["@WarEndDate"].Value = warend.ToString("yyyy/MM/dd HH:mm:ss");

        myAdapter.InsertCommand.Parameters.Add("@UpdateTime", SqlDbType.DateTime);
        myAdapter.InsertCommand.Parameters["@UpdateTime"].Value = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

        myAdapter.InsertCommand.Parameters.Add("@UpdateUser", SqlDbType.VarChar, 50);
        myAdapter.InsertCommand.Parameters["@UpdateUser"].Value = Session["UserID"].ToString();
        //
        if (hidden_Action.Value.Equals("add"))
        {
            Conn.Open();
            suc = myAdapter.InsertCommand.ExecuteNonQuery();
            myAdapter.Dispose();
        }
        else if (hidden_Action.Value.Equals("edit"))
        {
            Conn.Open();
            suc = myAdapter.UpdateCommand.ExecuteNonQuery();
            myAdapter.Dispose();
        }


        //第二種方法，直接傳資料給class檔，至資料庫抓資料再更新
        //_operator.Breakdown_Type_ID = Convert.ToInt32(hidden_BreakDown_Type_ID.Value);
        //_operator.Breakdown_Type = txt_BreakDown_Type.Text.Trim();
        //suc = _operator.EditBreakDownType(_operator);
        if (suc > 0)
        {
            ReDirect("修改成功");
            UpdateServerData();
            Application["App_Mis_Project"] = CommonLib.GetProject();
        }
        else
        {
            ShowPageMsg("修改失敗");
        }
    }

}
