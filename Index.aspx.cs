using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

public partial class Index : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["LoginStaffID"] = null;
    }

    protected void btn_login_Click(object sender, EventArgs e)
    {
       
        if (Login(txt_acc.Text.Trim(), txt_password.Text.Trim()))
        {
            Session["UserID"] = txt_acc.Text;
            Response.Redirect("Main.aspx");
            
        }
        else
        {
            //ShowMsg2(this.UpdatePanel1, "登入失敗!!");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "newprintwindow2", "alert(\"登入失敗\");", true);
        }

    }
    protected override void InitData()
    {
    }

    protected void txt_acc_TextChanged(object sender, EventArgs e)
    {

    }
}
