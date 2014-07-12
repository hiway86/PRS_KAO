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

public partial class XPMenu : System.Web.UI.Page
{
    public string systemGroup = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["sg"] != null)
        {
            systemGroup = Request.QueryString["sg"];
        }
        this.XPMenuUC.Attributes["SystemGroup"] = systemGroup;
        if (Session["UserID"] != null)
        {
            string login = Session["UserID"].ToString() + "歡迎登入";
            Label1.Text = login;
        }
    }
    protected void LinkButton_logout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("Index.aspx");
    }
}

