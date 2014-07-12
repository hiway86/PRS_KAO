#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\App_Code\WebService\JSONWebService.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8F3375C4AA4E002F303A337C7B71E012E4953DFA"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\App_Code\WebService\JSONWebService.cs"
using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
/// <summary>
/// JSONWebService 的摘要描述
/// </summary>
public class JSONWebService : System.Web.Services.WebService
{
	public JSONWebService()
	{

	}

    public string GetJson(DataTable dt)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row;
        foreach (DataRow dr in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, dr[col]);
            }
            rows.Add(row);
        }
        return serializer.Serialize(rows);
    }
}


#line default
#line hidden
