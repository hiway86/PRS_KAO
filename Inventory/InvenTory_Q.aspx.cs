using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Configuration;

public partial class Inventory_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DBInit();
    }


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {    //---- 分 頁 ----
        GridView1.PageIndex = e.NewPageIndex;
        DBInit();
    }


    //====自己手寫的程式碼， DataAdapter / DataSet ====(start)
    protected void DBInit()
    {
        //----上面已經事先寫好 using System.Web.Configuration ----
        //----連結資料庫的另一種寫法----
        SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["MROSConnectionString"].ConnectionString);
        SqlDataAdapter myAdapter = null;

        try
        {
            //Conn.Open();  //---- 這一行註解掉，可以不用寫，DataAdapter會自動開啟

            //=====重 點=====(start)
            string mySearchString = "Select * From ICS_Material Where 1=1 ";

            if (TextBox1.Text != "")
            {
                mySearchString += " and MaterialName like '%" + TextBox1.Text + "%'";
            }

            if (TextBox2.Text != "")
            {
                mySearchString += " and MaterialTypeID like '%" + TextBox2.Text + "%'";
            }

            Response.Write(mySearchString.ToString() + "<hr>");
            //=====重 點=====(end)


            myAdapter = new SqlDataAdapter(mySearchString, Conn);
            DataSet ds = new DataSet();
            myAdapter.Fill(ds, "test");     //把資料庫撈出來的資料，填入DataSet裡面。
            // DataSet是由許多 DataTable組成的，我們目前只放進一個名為 test的 DataTable而已。

            GridView1.DataSource = ds.Tables["test"];
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("<HR/>" + ex.ToString() + "<HR/>");
        }
        //finally
        //{   
        //    if (Conn.State == ConnectionState.Open) 
        //    {
        //        Conn.Close();
        //        Conn.Dispose();
        //    }  //使用SqlDataAdapter的時候，不需要寫程式去控制Conn.Open()與 Conn.Close()。
        //}
        //====自己手寫的程式碼， DataAdapter / DataSet ====(end)
    }

    /// <summary>
    /// 編輯資料
    /// </summary>
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;

        DBInit();
    }

    protected void GridView1_RowDeleting(object sender, GridViewEditEventArgs e)
    { 
    
    }

    protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
    {
        DBInit();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //if (e.CommandName.ToUpper().Equals("ED"))
        {
            TextBox my_MaterialName, my_PurchaseUnit, my_ConsumeUnit, my_MaterialID;

            my_MaterialName = (TextBox)GridView1.Rows[e.RowIndex].Cells[0].Controls[0];
            my_PurchaseUnit = (TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0];
            my_ConsumeUnit = (TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0];
            my_MaterialID = (TextBox)GridView1.Rows[e.RowIndex].Cells[8].Controls[0];

            SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["MROSConnectionString"].ConnectionString);
            SqlDataAdapter myAdapter = new SqlDataAdapter();

            //----------------------事先寫好 UpdateCommand / DeleteCommand / InsertCommand
            myAdapter.UpdateCommand = new SqlCommand("UPDATE [ICS_Material] SET [MaterialName] = @MaterialName, [PurchaseUnit] = @PurchaseUnit, [ConsumeUnit] = @ConsumeUnit WHERE [MaterialID] = @MaterialID", Conn);


            myAdapter.UpdateCommand.Parameters.Add("@MaterialName", SqlDbType.VarChar, 50);
            myAdapter.UpdateCommand.Parameters["@MaterialName"].Value = my_MaterialName.Text;

            myAdapter.UpdateCommand.Parameters.Add("@PurchaseUnit", SqlDbType.VarChar, 50);
            myAdapter.UpdateCommand.Parameters["@PurchaseUnit"].Value = my_PurchaseUnit.Text;

            myAdapter.UpdateCommand.Parameters.Add("@ConsumeUnit", SqlDbType.VarChar, 50);
            myAdapter.UpdateCommand.Parameters["@ConsumeUnit"].Value = my_ConsumeUnit.Text;

            myAdapter.UpdateCommand.Parameters.Add("@MaterialID", SqlDbType.VarChar, 50);
            myAdapter.UpdateCommand.Parameters["@MaterialID"].Value = my_MaterialID.Text;

            Conn.Open();
            myAdapter.UpdateCommand.ExecuteNonQuery();
            myAdapter.Dispose();


            GridView1.EditIndex = -1;
            DBInit();
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
   
}