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

public partial class Statistics_BreakDownCount_Q : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ScriptManager1.IsInAsyncPostBack)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "addSearchIcon();", true);
            //隱藏顯示欄位
            GridViewHidden(this.gv, 5); //地區編號
            //InitData();
            SearchData();
        }
    }
    protected override void InitData()
    {
        ddlst_SearchType.Items.Clear();

        for (int i = 0; i < this.gv.Columns.Count; i++)
        {
            if (this.gv.Columns[i] is BoundField && gv.Columns[i].HeaderStyle.CssClass != "gridviewhiddenrow")
            {
                ListItem item = new ListItem();
                item.Text = gv.Columns[i].HeaderText;
                item.Value = ((BoundField)gv.Columns[i]).DataField;
                if (item.Value != "counts")
                    this.ddlst_SearchType.Items.Add(item);
            }
        }
    }

    protected void SearchData()
    {
        gv.DataSource = null;
        gv.DataBind();

        SQLDB db = new SQLDB();
        StringBuilder query = new StringBuilder(" select * from ");
        query.Append(" (SELECT DeviceID,COUNT(*) as counts ");
        query.Append(" FROM WarrantyNotify ");

        string conditionName = ddlst_SearchType.SelectedValue;
        if (txt_startDateTime.Text.Length > 0 || txt_endDateTime.Text.Length > 0)
        {
            query.Append(" WHERE ");
            if (txt_startDateTime.Text.Length > 0 && txt_endDateTime.Text.Length > 0)
            {
                query.Append(" NotifyDate >= '" + txt_startDateTime.Text + "' and NotifyDate <= '" + txt_endDateTime.Text + "' ");
            }
            else if (txt_startDateTime.Text.Length > 0)
            {
                query.Append(" NotifyDate >= '" + txt_startDateTime.Text + "' ");
            }
            else if (txt_endDateTime.Text.Length > 0)
            {
                query.Append(" NotifyDate <= '" + txt_endDateTime.Text + "'  ");
            }
        }
        query.Append(" GROUP BY  deviceid) w left join View_DeviceConfig d on w.deviceid = d.Device_ID "); 
        if (txt_Query_Reason.Text.Trim().Length > 0)
        {
            query.Append(" where "+conditionName + " like '%" + txt_Query_Reason.Text.Trim() + "%' ");
        }
        query.Append("order by counts desc");
        DataSet ds = db.SelectQuery(query.ToString());
        //Session["DS_MIS"] = ds;
        gv.DataSource = ds;
        gv.DataBind();

        if (ds.Tables[0].Rows.Count == 0)
        {
            ShowMsg2(UpdatePanel1, "查詢無資料");
        }


    }
    protected DataTable GetData()
    {
        SQLDB db = new SQLDB();
        StringBuilder query = new StringBuilder(" select top 20 * from ");
        query.Append(" (SELECT DeviceID,COUNT(*) as counts ");
        query.Append(" FROM WarrantyNotify ");

        string conditionName = ddlst_SearchType.SelectedValue;
        StringBuilder condition = new StringBuilder();
        bool isquery = false;
        if (txt_Query_Reason.Text.Trim().Length > 0)
        {
            condition.Append(conditionName + " like '%" + txt_Query_Reason.Text.Trim() + "%' and");
            isquery = true;
        }
        if (txt_startDateTime.Text.Length > 0)
        {
            condition.Append(" NotifyDate >= '" + txt_startDateTime.Text + "' and");
            isquery = true;
        }
        if (txt_endDateTime.Text.Length > 0)
        {
            condition.Append(" NotifyDate <= '" + txt_endDateTime.Text + "'  and");
            isquery = true;
        }
        if (isquery)
        {
            query.Append(" WHERE " + condition.ToString().Substring(0, condition.ToString().Length - 3));
        }
        query.Append(" GROUP BY  deviceid) w left join View_DeviceConfig d on w.deviceid = d.Device_ID  order by counts desc");
        DataSet ds = db.SelectQuery(query.ToString());
        //Session["DS_MIS"] = ds;


        if (ds.Tables[0].Rows.Count == 0)
        {
            ShowMsg2(UpdatePanel1, "查詢無資料");
        }
        return ds.Tables[0];


    }


    protected void lnkbtn_Search_Click(object sender, EventArgs e)
    {
        SearchData();
    }
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;
        SearchData();
        RunChart();
    }

    //private void runRptViewer()
    //{
    //    this.ReportViewer1.Reset();
    //    this.ReportViewer1.LocalReport.ReportPath = Server.MapPath("Report2.rdlc");
    //    ReportDataSource datasource = new ReportDataSource("MROSDataSet_BreakdownCount", GetData());
    //    //datasource.DataSourceId = "breakdownCount";
    //    this.ReportViewer1.LocalReport.DataSources.Clear();
    //    this.ReportViewer1.LocalReport.DataSources.Add(datasource);
    //    this.ReportViewer1.DataBind();
    //    this.ReportViewer1.LocalReport.Refresh();
    //}
    protected void lnkbtn_Add_Click(object sender, EventArgs e)
    {
        //runRptViewer();
        RunChart();
    }

    private void RunChart()
    {
        DataTable dt = GetData();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            Chart1.Series["Series1"].Points.AddXY(dt.Rows[i]["deviceid"].ToString(), Convert.ToDouble(dt.Rows[i]["counts"].ToString()));
            Chart1.Series["Series1"].IsValueShownAsLabel = true;
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
        }
    }
    protected void cmd_ExportExcel_Click(object sender, EventArgs e)
    {

        SQLDB _operator = new SQLDB();
        StringBuilder select = new StringBuilder();
        select.Append("  select DeviceID as 設備編號,Counts as 損壞次數,Device_Kind as 設備種類 ,AreaName as 地區  ,Location as 路段 ,Gis_X as 經度,Gis_Y as 緯度 ");
        select.Append(" from  (SELECT DeviceID,COUNT(*) as counts  FROM WarrantyNotify ");
        //時間查詢條件
        if (txt_startDateTime.Text.Length > 0 && txt_endDateTime.Text.Length > 0)
        {
            select.Append(" WHERE ");

            if (txt_startDateTime.Text.Length > 0 && txt_endDateTime.Text.Length > 0)   //若有設定起始時間與結束時間
            {
                select.Append("NotifyDate >=  '" + txt_startDateTime.Text + "' AND NotifyDate <=  '" + txt_endDateTime.Text + "'");
            }
            else if (txt_startDateTime.Text.Length > 0) //若有設定起始時間
            {
                select.Append("NotifyDate >=  '" + txt_startDateTime.Text + "'");
            }
            else if (txt_endDateTime.Text.Length > 0)  //若有設定結束時間
            {
                select.Append("NotifyDate <=  '" + txt_startDateTime.Text + "'");
            }
        }
        select.Append("  GROUP BY  deviceid) w left join View_DeviceConfig d on w.deviceid = d.Device_ID  ");

        string conditionName = ddlst_SearchType.SelectedValue;
        if (txt_Query_Reason.Text.Trim().Length > 0)    //各欄位查詢條件
        {
            select.Append("where " + conditionName + " like '%" + txt_Query_Reason.Text.Trim() + "%' ");

        }

        select.Append("   order by counts desc ");
        DataSet ds = _operator.SelectQuery(select.ToString());
        if (ds.Tables[0].Rows.Count > 2000)
        {
            ShowMsg2(UpdatePanel1, "查詢筆數過多，請重新調整查詢條件");
            return;
        }
        HSSFWorkbook workbook = new HSSFWorkbook();
        MemoryStream ms = new MemoryStream();

        HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet("Sheet01");
        sheet.SetColumnWidth(4, 48 * 255);
        //sheet.DisplayGridlines = true;

        // 設定儲存格樣式-黑框線,跨欄置中
        ICellStyle style2 = workbook.CreateCellStyle();
        style2.BottomBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;
        style2.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
        style2.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
        style2.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
        style2.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
        style2.BottomBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;
        style2.LeftBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;
        style2.RightBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;
        style2.TopBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;
        style2.Alignment = HorizontalAlignment.Center;
        style2.VerticalAlignment = VerticalAlignment.Center;
        style2.WrapText = true;

        // 設定儲存格樣式-黑框線,跨欄置中,標題
        ICellStyle style3 = workbook.CreateCellStyle();
        style3.BottomBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;
        style3.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
        style3.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
        style3.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
        style3.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
        style3.BottomBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;
        style3.LeftBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;
        style3.RightBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;
        style3.TopBorderColor = NPOI.HSSF.Util.HSSFColor.Black.Index;
        style3.Alignment = HorizontalAlignment.Center;
        style3.VerticalAlignment = VerticalAlignment.Center;
        style3.WrapText = true;
        NPOI.SS.UserModel.IFont font = workbook.CreateFont();
        //以下為設定粗體字,字體大小
        font.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
        font.FontHeightInPoints = 20;
        style3.SetFont(font);

        //插入標題列
        IRow row = sheet.CreateRow(0);
        row.Height = 32 * 20;   //標題列增高為32
        ICell cell2 = row.CreateCell(0);
        cell2.SetCellValue("維修次數統計");
        sheet.AddMergedRegion(new Region(0, 0, 0, 6));
        cell2.CellStyle = style3;
        for (int i = 1; i < ds.Tables[0].Columns.Count; i++)
        {
            //IRow row = sheet.CreateRow(0);
            ICell cell = row.CreateCell(i);
            cell.SetCellValue(ds.Tables[0].Columns[i].ToString());
            cell.CellStyle = style3;
        }


        //插入各欄位名稱列
        row = sheet.CreateRow(1);
        for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
        {
            //IRow row = sheet.CreateRow(0);
            ICell cell = row.CreateCell(i);
            cell.SetCellValue(ds.Tables[0].Columns[i].ToString());
            cell.CellStyle = style2;
        }
        //插入資料列
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            row = sheet.CreateRow(i + 2);
            for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
            {

                ICell cell = row.CreateCell(j);
                cell.SetCellValue(ds.Tables[0].Rows[i][j].ToString());
                cell.CellStyle = style2;
            }
        }


        //Workbook workbook = new Workbook();
        //Worksheet worksheet = new Worksheet("First Sheet");
        //worksheet.Cells[0, 1] = new Cell("VD資料檢核異常報表");
        //MemoryStream ms = new MemoryStream();
        //ExcelLibrary.DataSetHelper.CreateWorkbook(ms, ds);

        workbook.Write(ms);
        Response.AddHeader("Content-Disposition", string.Format("attachment; filename=StatisticsWorkbook.xls"));
        Response.BinaryWrite(ms.ToArray());

        workbook = null;
        ms.Close();
        ms.Dispose();

    }

}