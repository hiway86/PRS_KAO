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
using System.Collections.Generic;

public partial class XPMenuUC : System.Web.UI.UserControl
{
    string systemGroup = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        InitManu();
    }


    private Literal GetLiteral(string htmlContent)
    {
        Literal lt = new Literal();
        lt.Text = htmlContent;
        return lt;
    }

	protected void InitManu()
	{
		if (Session["LoginStaffID"] != null)
		{
			this.systemGroup = this.Attributes["SystemGroup"].ToString();


            //ManuPanel.Controls.Clear();
            Security sec = new Security();
            List<Menu> menus = null;
            string systemGroupName = "";
            if (this.systemGroup.Equals(""))
            {
                menus = sec.GetAllMenu(Session["LoginStaffID"].ToString());
                //系統改成登入後不選擇系統群組，直接撈出所有系統群組
                if (menus != null)
                {
                    AddToPanel("<div id=\"accordian\">");
                    AddToPanel("<ul>");
                    foreach (Menu menu in menus)
                    {
                        if (!menu.System_Group_Name.Equals(systemGroupName))
                        {
                            if (systemGroupName == "")
                            {
                                //每個系統開始
                                systemGroupName = menu.System_Group_Name;
                                AddToPanel("<h3><span class=\"icon-dashboard\"></span>" + systemGroupName + "</h3>");
                                AddToPanel("<ul>");
                            }
                            else
                            {
                                //每個系統結束
                                AddToPanel("</ul></li>");
                                //每個系統開始
                                systemGroupName = menu.System_Group_Name;
                                AddToPanel("<h3><span class=\"icon-dashboard\"></span>" + systemGroupName + "</h3>");
                                AddToPanel("<ul>");
                            }
                        }

                        AddToPanel("<li><a href=\"" + menu.System_Folder_Name + "/" + menu.Program_Name + "\" target=\"mainFrame\">" + menu.Program_CName + "</a></li>");
                    }
                    //第二層結束
                    AddToPanel("</ul></li>");

                    //最外層</div>
                    AddToPanel("</ul>");
                    AddToPanel("</div>");
                }
            }
            else
            {
                menus = sec.GetSystemGroupMenu(this.systemGroup, Session["LoginStaffID"].ToString());
                //舊有寫法只撈出一個系統功能群組
                if (menus != null)
                {
                    AddToPanel("<div class=\"container-fluid\">");
                    //最外層<div>
                    AddToPanel("<div class=\"row-fluid\">");
                    AddToPanel("<div class=\"span20\">");
                    foreach (Menu menu in menus)
                    {
                        if (!menu.System_Group_Name.Equals(systemGroupName))
                        {
                            systemGroupName = menu.System_Group_Name;
                            if (menus.IndexOf(menu) > 0)
                            {
                                //第二層結束
                                AddToPanel("</ul ></div>");
                            }
                            //第一層

                            //第二層開始
                            AddToPanel("<div class=\"well sidebar-nav\"><ul class=\"nav nav-list\">");
                            AddToPanel("<li class=\"nav-header\" href=\"#\">" + systemGroupName + "</li>");
                        }

                        //AddToPanel("<li><a href=\"" + menu.System_Folder_Name + "\\" + menu.Program_Name + "\" target=\"mainFrame\">" + menu.Program_CName + "</a></li>");
                        AddToPanel("<li><a href=\"" + menu.System_Folder_Name + "\\" + menu.Program_Name + "\" target=\"mainFrame\">" + menu.Program_CName + "</a></li>");
                    }
                    //第二層結束
                    AddToPanel("</ul></div>");

                    //最外層</div>
                    AddToPanel("</div>");
                    AddToPanel("</div>");
                    AddToPanel("</div>");
                }
            }
        }
        else
        {
            //最外層<div>
            AddToPanel("<div class=\"glossymenu\" style=\"margin:0\">");
            AddToPanel("<a class=\"menuitem\" href=\"Login.aspx\" target=\"_blank\">重新登入</a>");
            //最外層</div>
            AddToPanel("</div>");
        }
	}

    protected void AddToPanel(string htmlContent)
    {
        //ManuPanel.Controls.Add(GetLiteral(htmlContent));
        this.Controls.Add(GetLiteral(htmlContent));
    }

}
