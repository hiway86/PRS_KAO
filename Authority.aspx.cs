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

public partial class System_Authority : PageBase
{
	public string authString = "var pagePermit;";
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Request.QueryString["p"] != null)
		{
			Security sec = new Security();
			sec = GetPagePermit(Request.QueryString["p"].Trim());
			if (sec != null)
			{
				authString = "var pagePermit = { " +
							" enableBrowser : " + sec.EnableBrowser.ToString().ToLower() + ", " +
							" enableQuery : " + sec.EnableQuery.ToString().ToLower() + ", " +
							" enableAdd : " + sec.EnableAdd.ToString().ToLower() + ", " +
							" enableEdit : " + sec.EnableEdit.ToString().ToLower() + ", " +
							" enableDelete : " + sec.EnableDelete.ToString().ToLower() + ", " +
							" enablePrint : " + sec.EnablePrint.ToString().ToLower() + ", " +
							" enableEditSave : " + sec.EnableEditSave.ToString().ToLower() + ", " +
							" enableNewSave : " + sec.EnableNewSave.ToString().ToLower() + " };";
			}
			else
			{
				//資料庫不存在權限設定，頁面不限定權限
				authString = "var pagePermit = { " +
							" enableBrowser : true, " +
							" enableQuery : true, " +
							" enableAdd : true, " +
							" enableEdit : true, " +
							" enableDelete : true, " +
							" enablePrint : true, " +
							" enableEditSave : true, " +
							" enableNewSave : true };";
			}
		}

		Response.Write(authString);
	}
	protected override void InitData()
	{
	}
}
