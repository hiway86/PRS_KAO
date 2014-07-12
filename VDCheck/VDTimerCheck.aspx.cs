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
using System.Text;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.HSSF.UserModel;
using System.IO;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;

public partial class VDCheck_VDTimerCheck : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SQLDB _operator = new SQLDB("", "KPT");
        //定義連續錯誤超過幾筆的次數
        string errorcount = System.Configuration.ConfigurationManager.AppSettings["ErrorCount"];
        //幾分鐘檢核一次VD
        int VDCheckMinute = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["VDCheckMinute"]);
        DateTime end = DateTime.Now;
        DateTime start = DateTime.Now.AddMinutes(VDCheckMinute);
        DataSet ds_ckeckvd = _operator.Select("Counts > '" + errorcount + "' and 時間 between '" + start.ToString("yyyy/MM/dd HH:mm:ss") + "' and '" + end.ToString("yyyy/MM/dd HH:mm:ss") + "' ", "設備編號,標準型態名稱,方向,星期,時段", "View_CheckVDFilter");

        if (ds_ckeckvd.Tables[0].Rows.Count > 0)
        {
            DataSet ds_error = _operator.Select("1=0", "", "VD_ERRORRECORD");
            DateTime time = DateTime.Now;
            foreach (DataRow dr in ds_ckeckvd.Tables[0].Rows)
            {
                DataRow dr_add = ds_error.Tables[0].NewRow();
                dr_add["Vdid"] = dr["設備編號"];
                dr_add["Vsrdir"] = dr["方向"];
                dr_add["Week"] = dr["星期"];
                dr_add["Hours"] = dr["時段"];
                dr_add["TypeName"] = dr["標準型態名稱"];
                dr_add["SpeedRange"] = dr["速度範圍"];
                dr_add["LaneoccupyRange"] = dr["佔有率範圍"];
                dr_add["FlowRange"] = dr["流量範圍"];
                dr_add["RecordTime"] = dr["時間"];
                dr_add["Counts"] = dr["Counts"];
                dr_add["UpdateTime"] = time;
                ds_error.Tables[0].Rows.Add(dr_add);
            }

            DataSet DSChange = ds_error.GetChanges();
            if (!_operator.Insert(DSChange))
            {
                Response.Write("資料塞入錯誤");
            }
        }
        else
        {
            DataSet ds_error = _operator.Select("1=0", "", "VD_ERRORRECORD_log");
            DateTime time = DateTime.Now;

            DataRow dr_add = ds_error.Tables[0].NewRow();
            dr_add["Vdid"] = "log";
            dr_add["Vsrdir"] = "0";
            dr_add["Week"] = "0";
            dr_add["Hours"] = "0";
            dr_add["TypeName"] = "0";
            dr_add["SpeedRange"] = "0";
            dr_add["LaneoccupyRange"] = "0";
            dr_add["FlowRange"] = "0";
            dr_add["RecordTime"] = DateTime.Now;
            dr_add["Counts"] = "0";
            dr_add["UpdateTime"] = DateTime.Now;
            ds_error.Tables[0].Rows.Add(dr_add);


            DataSet DSChange = ds_error.GetChanges();
            if (!_operator.Insert(DSChange))
            {
                Response.Write("紀錄log塞入錯誤");
            }

        }
    }
}