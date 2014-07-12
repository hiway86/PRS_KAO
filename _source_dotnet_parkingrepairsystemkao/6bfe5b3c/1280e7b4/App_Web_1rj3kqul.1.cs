#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\System\Loginchpwd.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BF222C26DF5785E37673134242821E536F7100A0"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\System\Loginchpwd.aspx.cs"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (Session["LOGIN"] != null)
        {
            if (Session["LOGIN"].ToString() != "OK")
            {
                Response.Redirect("../Index.aspx");
            }
            else 
            {
                string LOGINID = Session["UserID"].ToString();
                Label1.Text = LOGINID.ToString();
            }
        }
        else
        {
            Response.Redirect("../Index.aspx");
        }

    }
 
    protected void Button1_Click(object sender, EventArgs e)
    {
        //確認變更
        if (txt_newpw.Text.Trim()!=txt_newpwcheck.Text.Trim())
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "newprintwindow2", "alert(\"新密碼需與確認新密碼相同，請調整\");", true);
        }
        else
        {
            if (Updateuerpwd(txt_newpw.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newprintwindow2", "alert(\"更新成功\");", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "newprintwindow2", "alert(\"更新失敗\");", true);
            }
        }
      
    }

    /// <summary>
    /// 更新登入者密碼
    /// </summary>
    /// <returns>bool</returns>
    private bool Updateuerpwd(string pwd)
    {
        bool success = false;
        Security sec = new Security();
        success = sec.Updateuserpwd(Session["UserID"].ToString(), pwd);
        return success;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        //取消
        Response.Redirect("../MainMenu.aspx");

    }
  
}


#line default
#line hidden
