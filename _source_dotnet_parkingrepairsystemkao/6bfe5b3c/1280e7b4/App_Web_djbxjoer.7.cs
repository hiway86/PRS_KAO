#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\VDCheck\StandardManage_A.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6DFC3BDFC51BA35B8C55CDE3AFECC1CF31AFADF4"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\VDCheck\StandardManage_A.aspx.cs"
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

public partial class VDCheck_StandardManage_A : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ScriptManager1.IsInAsyncPostBack)
        {
            Session["MIS_DS"] = null;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "addSearchIcon();", true);
            InitData();
            //SearchData();
        }
    }
    protected override void InitData()
    {
        SQLDB _operator = new SQLDB("VD_Info", "KPT");
        string query = "select vdid from VD_Info group by vdid";
        DataSet ds = _operator.SelectQuery(query);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem vditem = new ListItem();
            vditem.Value = ds.Tables[0].Rows[i]["vdid"].ToString();
            vditem.Text = ds.Tables[0].Rows[i]["vdid"].ToString();
            ddlst_Device.Items.Add(vditem);
        }
    }

    protected void lnkbtn_Add_Click(object sender, EventArgs e)
    {
        //RunChart();
    }

    private void RunChart(DataSet ds_vdstand)
    {
        ////設定標題
        //Title title = new Title();
        //title.ShadowColor = System.Drawing.Color.SkyBlue;
        //title.Text = "故障因素統計";
        //title.ForeColor = System.Drawing.Color.SlateBlue;
        //title.ShadowOffset = 3;
        //System.Drawing.Font font= new System.Drawing.Font("Verdana", 15f,FontStyle.Bold);
        //title.Font = font;
        //Chart1.Titles.Add(title);
        //塞資料

        //將標準型態依照各星期分成個個datatble個別塞到chart

        DataRow[] dr_mon = ds_vdstand.Tables[0].Select("week = 1");
        DataRow[] dr_tue = ds_vdstand.Tables[0].Select("week = 2");
        DataRow[] dr_wed = ds_vdstand.Tables[0].Select("week = 3");
        DataRow[] dr_thu = ds_vdstand.Tables[0].Select("week = 4");
        DataRow[] dr_fri = ds_vdstand.Tables[0].Select("week = 5");
        DataRow[] dr_sat = ds_vdstand.Tables[0].Select("week = 6");
        DataRow[] dr_sun = ds_vdstand.Tables[0].Select("week = 7");

        Series Series1 = new Series();
        Series1.ChartType = SeriesChartType.Line;
        Chart_NormalSpeed.Series.Add(Series1);

        Series Series2 = new Series();
        Series2.ChartType = SeriesChartType.Line;
        Chart_NormalSpeed.Series.Add(Series2);


        Series Series3 = new Series();
        Series3.ChartType = SeriesChartType.Line;
        Chart_NormalSpeed.Series.Add(Series3);

        Series Series4 = new Series();
        Series4.ChartType = SeriesChartType.Line;
        Chart_NormalSpeed.Series.Add(Series4);


        Series Series5 = new Series();
        Series5.ChartType = SeriesChartType.Line;
        Chart_NormalSpeed.Series.Add(Series5);

        Series Series6 = new Series();
        Series6.ChartType = SeriesChartType.Line;
        Chart_WeekdaySpeed.Series.Add(Series6);

        Series Series7 = new Series();
        Series7.ChartType = SeriesChartType.Line;
        Chart_WeekdaySpeed.Series.Add(Series7);

        //建立流量序列
        Series Series_flow1 = new Series();
        Series_flow1.ChartType = SeriesChartType.Line;
        Chart_NormalFlow.Series.Add(Series_flow1);

        Series Series_flow2 = new Series();
        Series_flow2.ChartType = SeriesChartType.Line;
        Chart_NormalFlow.Series.Add(Series_flow2);

        Series Series_flow3 = new Series();
        Series_flow3.ChartType = SeriesChartType.Line;
        Chart_NormalFlow.Series.Add(Series_flow3);

        Series Series_flow4 = new Series();
        Series_flow4.ChartType = SeriesChartType.Line;
        Chart_NormalFlow.Series.Add(Series_flow4);

        Series Series_flow5 = new Series();
        Series_flow5.ChartType = SeriesChartType.Line;
        Chart_NormalFlow.Series.Add(Series_flow5);

        Series Series_flow6 = new Series();
        Series_flow6.ChartType = SeriesChartType.Line;
        Chart_WeekDayflow.Series.Add(Series_flow6);

        Series Series_flow7 = new Series();
        Series_flow7.ChartType = SeriesChartType.Line;
        Chart_WeekDayflow.Series.Add(Series_flow7);

        //建立佔有率序列
        Series Series_laneOccupy1 = new Series();
        Series_laneOccupy1.ChartType = SeriesChartType.Line;
        Chart_NormalLaneOccupy.Series.Add(Series_laneOccupy1);

        Series Series_laneOccupy2 = new Series();
        Series_laneOccupy2.ChartType = SeriesChartType.Line;
        Chart_NormalLaneOccupy.Series.Add(Series_laneOccupy2);

        Series Series_laneOccupy3 = new Series();
        Series_laneOccupy3.ChartType = SeriesChartType.Line;
        Chart_NormalLaneOccupy.Series.Add(Series_laneOccupy3);

        Series Series_laneOccupy4 = new Series();
        Series_laneOccupy4.ChartType = SeriesChartType.Line;
        Chart_NormalLaneOccupy.Series.Add(Series_laneOccupy4);

        Series Series_laneOccupy5 = new Series();
        Series_laneOccupy5.ChartType = SeriesChartType.Line;
        Chart_NormalLaneOccupy.Series.Add(Series_laneOccupy5);

        Series Series_laneOccupy6 = new Series();
        Series_laneOccupy6.ChartType = SeriesChartType.Line;
        Chart_WeekdayLaneOccupy.Series.Add(Series_laneOccupy6);

        Series Series_laneOccupy7 = new Series();
        Series_laneOccupy7.ChartType = SeriesChartType.Line;
        Chart_WeekdayLaneOccupy.Series.Add(Series_laneOccupy7);

        //開始綁定速度資料
        Chart_NormalSpeed.Titles["Title1"].Text = "平日時間-速度分布圖";
        Chart_NormalSpeed.Series["Series1"].Points.DataBindXY(dr_mon, "hours", dr_mon, "SpeedAvg");
        Chart_NormalSpeed.Series["Series1"].LegendText = "星期一";
        Chart_NormalSpeed.Series["Series2"].Points.DataBindXY(dr_tue, "hours", dr_tue, "SpeedAvg");
        Chart_NormalSpeed.Series["Series2"].LegendText = "星期二";
        Chart_NormalSpeed.Series["Series3"].Points.DataBindXY(dr_wed, "hours", dr_wed, "SpeedAvg");
        Chart_NormalSpeed.Series["Series3"].LegendText = "星期三";
        Chart_NormalSpeed.Series["Series4"].Points.DataBindXY(dr_thu, "hours", dr_thu, "SpeedAvg");
        Chart_NormalSpeed.Series["Series4"].LegendText = "星期四";
        Chart_NormalSpeed.Series["Series5"].Points.DataBindXY(dr_fri, "hours", dr_fri, "SpeedAvg");
        Chart_NormalSpeed.Series["Series5"].LegendText = "星期五";

        Chart_WeekdaySpeed.Titles["Title1"].Text = "假日時間-速度分布圖";
        Chart_WeekdaySpeed.Series["Series1"].Points.DataBindXY(dr_sat, "hours", dr_sat, "SpeedAvg");
        Chart_WeekdaySpeed.Series["Series1"].LegendText = "星期六";
        Chart_WeekdaySpeed.Series["Series2"].Points.DataBindXY(dr_sun, "hours", dr_sun, "SpeedAvg");
        Chart_WeekdaySpeed.Series["Series2"].LegendText = "星期日";

        //開始綁定佔有率資料
        Chart_NormalLaneOccupy.Titles["Title1"].Text = "平日時間-佔有率分布圖";
        Chart_NormalLaneOccupy.Series["Series1"].Points.DataBindXY(dr_mon, "hours", dr_mon, "LaneOccupyAvg");
        Chart_NormalLaneOccupy.Series["Series1"].LegendText = "星期一";
        Chart_NormalLaneOccupy.Series["Series2"].Points.DataBindXY(dr_tue, "hours", dr_tue, "LaneOccupyAvg");
        Chart_NormalLaneOccupy.Series["Series2"].LegendText = "星期二";
        Chart_NormalLaneOccupy.Series["Series3"].Points.DataBindXY(dr_wed, "hours", dr_wed, "LaneOccupyAvg");
        Chart_NormalLaneOccupy.Series["Series3"].LegendText = "星期三";
        Chart_NormalLaneOccupy.Series["Series4"].Points.DataBindXY(dr_thu, "hours", dr_thu, "LaneOccupyAvg");
        Chart_NormalLaneOccupy.Series["Series4"].LegendText = "星期四";
        Chart_NormalLaneOccupy.Series["Series5"].Points.DataBindXY(dr_fri, "hours", dr_fri, "LaneOccupyAvg");
        Chart_NormalLaneOccupy.Series["Series5"].LegendText = "星期五";

        Chart_WeekdayLaneOccupy.Titles["Title1"].Text = "假日時間-佔有率分布圖";
        Chart_WeekdayLaneOccupy.Series["Series1"].Points.DataBindXY(dr_sat, "hours", dr_sat, "LaneOccupyAvg");
        Chart_WeekdayLaneOccupy.Series["Series1"].LegendText = "星期六";
        Chart_WeekdayLaneOccupy.Series["Series2"].Points.DataBindXY(dr_sun, "hours", dr_sun, "LaneOccupyAvg");
        Chart_WeekdayLaneOccupy.Series["Series2"].LegendText = "星期日";

        //開始綁定流量資料
        Chart_NormalFlow.Titles["Title1"].Text = "平日時間-流量分布圖";
        Chart_NormalFlow.Series["Series1"].Points.DataBindXY(dr_mon, "hours", dr_mon, "FlowAvg");
        Chart_NormalFlow.Series["Series1"].LegendText = "星期一";
        Chart_NormalFlow.Series["Series2"].Points.DataBindXY(dr_tue, "hours", dr_tue, "FlowAvg");
        Chart_NormalFlow.Series["Series2"].LegendText = "星期二";
        Chart_NormalFlow.Series["Series3"].Points.DataBindXY(dr_wed, "hours", dr_wed, "FlowAvg");
        Chart_NormalFlow.Series["Series3"].LegendText = "星期三";
        Chart_NormalFlow.Series["Series4"].Points.DataBindXY(dr_thu, "hours", dr_thu, "FlowAvg");
        Chart_NormalFlow.Series["Series4"].LegendText = "星期四";
        Chart_NormalFlow.Series["Series5"].Points.DataBindXY(dr_fri, "hours", dr_fri, "FlowAvg");
        Chart_NormalFlow.Series["Series5"].LegendText = "星期五";

        Chart_WeekDayflow.Titles["Title1"].Text = "假日時間-流量分布圖";
        Chart_WeekDayflow.Series["Series1"].Points.DataBindXY(dr_sat, "hours", dr_sat, "FlowAvg");
        Chart_WeekDayflow.Series["Series1"].LegendText = "星期六";
        Chart_WeekDayflow.Series["Series2"].Points.DataBindXY(dr_sun, "hours", dr_sun, "FlowAvg");
        Chart_WeekDayflow.Series["Series2"].LegendText = "星期日";


    }



    //標準型態試算
    protected void lnkbtn_calStandard_Click(object sender, EventArgs e)
    {
        if (txt_startDateTime.Text.Length == 0)
        {
            ShowMsg(UpdatePanel1, "請選擇起始時間");
            return;
        }
        if (txt_endDateTime.Text.Length == 0)
        {
            ShowMsg(UpdatePanel1, "請選擇結束時間");
            return;
        }
        DataSet dsCaledStd = new DataSet();
        dsCaledStd = calStandard();
        if (dsCaledStd.Tables[0].Rows.Count > 0)
        {
            Session["MIS_DS"] = dsCaledStd;
            RunChart(dsCaledStd);
        }
        else
        {
            ShowMsg(UpdatePanel1, "查無資料");
        }
    }

    //標準型態儲存
    protected void lnkbtn_saveStandard_Click(object sender, EventArgs e)
    {
        SQLDB _operator = new SQLDB("VD_STANDARD", "KPT");
        DataSet dsCaledStd = new DataSet();
        dsCaledStd = calStandard();
        if (dsCaledStd.Tables[0].Rows.Count > 0)
        {
            DataSet ds_standard = _operator.Select("", "", "VD_STANDARD");
            DateTime updatetime = DateTime.Now;
            DataSet ds_standardAdd = _operator.Select("1=0", "", "VD_STANDARD");
            DataSet ds_standardAddHis = _operator.Select("1=0", "", "VD_STANDARD_HIS");
            for (int i = 0; i < dsCaledStd.Tables[0].Rows.Count; i++)
            {
                DataRow dr = dsCaledStd.Tables[0].Rows[i];
                string vdid = dr["vdid"].ToString();
                string vsrdir = dr["vsrdir"].ToString();
                string week = dr["week"].ToString();
                string hours = dr["hours"].ToString();

                DataRow[] dr_std = ds_standard.Tables[0].Select("Vdid = '" + vdid + "' AND Vsrdir = '" + vsrdir + "' AND Week = '" + week + "' AND Hours = '" + hours + "' ");


                DataRow dr_add = ds_standardAdd.Tables[0].NewRow();
                dr_add["Vdid"] = vdid;
                dr_add["TypeName"] = "Default";
                dr_add["Vsrdir"] = vsrdir;
                dr_add["Hours"] = hours;
                dr_add["Week"] = week;
                dr_add["SpeedAvg"] = dr["SpeedAvg"].ToString();
                dr_add["SpeedStandard"] = dr["SpeedStandard"].ToString();
                dr_add["LaneOccupyAvg"] = dr["LaneOccupyAvg"].ToString();
                dr_add["LaneOccupyStandard"] = dr["LaneOccupyStandard"].ToString();
                dr_add["FlowAvg"] = dr["FlowAvg"].ToString();
                dr_add["FlowStandard"] = dr["FlowStandard"].ToString();
                dr_add["Times"] = 2;
                dr_add["UpdateTime"] = updatetime;
                ds_standardAdd.Tables[0].Rows.Add(dr_add);

                //將有衝突的標準型態備份到VD_STANDARD_HIS
                if (dr_std.Length > 0)
                {
                    DataRow dr_addhis = ds_standardAddHis.Tables[0].NewRow();
                    dr_addhis["StandardNum"] = dr_std[0]["StandardNum"];
                    dr_addhis["Vdid"] = vdid;
                    dr_addhis["TypeName"] = "Default";
                    dr_addhis["Vsrdir"] = vsrdir;
                    dr_addhis["Hours"] = hours;
                    dr_addhis["Week"] = week;
                    dr_addhis["SpeedAvg"] = dr_std[0]["SpeedAvg"].ToString();
                    dr_addhis["SpeedStandard"] = dr_std[0]["SpeedStandard"].ToString();
                    dr_addhis["LaneOccupyAvg"] = dr_std[0]["LaneOccupyAvg"].ToString();
                    dr_addhis["LaneOccupyStandard"] = dr_std[0]["LaneOccupyStandard"].ToString();
                    dr_addhis["FlowAvg"] = dr_std[0]["FlowAvg"].ToString();
                    dr_addhis["FlowStandard"] = dr["FlowStandard"].ToString();
                    dr_addhis["Times"] = 2;
                    dr_addhis["UpdateTime"] = updatetime;
                    ds_standardAddHis.Tables[0].Rows.Add(dr_addhis);

                    dr_std[0].Delete();
                }
            }

            DataSet DSChange = ds_standard.GetChanges(DataRowState.Deleted);
            if (DSChange != null)
            {
                if (_operator.Delete(DSChange))
                {
                    // ShowMsg(UpdatePanel1, "資料刪除成功");
                }
            }

            DataSet DSChangeAdd = ds_standardAdd.GetChanges();
            DataSet DSChangeAddHis = ds_standardAddHis.GetChanges();
            bool suc = false;
            if (DSChangeAdd != null)
            {
                if (_operator.Insert(DSChangeAdd))
                {
                    suc = true;
                }
            }
            if (DSChangeAddHis != null)
            {
                if (_operator.Insert(DSChangeAdd))
                {
                    suc = true;
                }
            }

            if (suc)
            {
                ShowMsg(UpdatePanel2, "建立成功");
            }

        }
    }

    //計算標準型態
    private DataSet calStandard()
    {
        string vd = ddlst_Device.SelectedValue;
        SQLDB _operator = new SQLDB("VD_DOORSILL", "KPT");
        //撈出相對應的異常資料門檻值
        DataSet vdDoorSill = _operator.Select("DeviceID = '" + vd + "'", "", "VD_DOORSILL");

        //用來存放各VD之標準型態
        DataSet dsCaledStd = new DataSet();

        //先刪除舊標準型態中與計算出來的有衝突的資料
        StringBuilder query = new StringBuilder();

        query.Append(" SELECT vdid,vsrdir,avg(speed)as SpeedAvg,isnull(stdev(speed),0) as SpeedStandard, ");
        query.Append("             avg(laneoccupy) as laneoccupyAvg,isnull(stdev(laneoccupy),0)as LaneOccupyStandard,  ");
        query.Append("             avg(isnull(volume_T,0)+volume_L+volume_S+volume_M) as FlowAvg,isnull(stdev(isnull(volume_T,0)+volume_L+volume_S+volume_M),0)as FlowStandard, ");
        query.Append("             DatePart(WEEKDAY, datacollecttime) as week,DatePart(HOUR, datacollecttime) as hours ");
        query.Append(" from VD_Value_his ");
        query.Append(" where vdid = '" + vd + "' AND vsrdir = '" + ddlst_Vsrdir.SelectedValue + "' ");
        if (vdDoorSill.Tables[0].Rows.Count > 0)
        {
            DataRow door = vdDoorSill.Tables[0].Rows[0];
            query.Append(" AND (isnull(volume_T,0)+volume_L+volume_S+volume_M) < " + door["FlowTop"].ToString() + "  and speed < " + door["SpeedTop"].ToString() + " and laneoccupy < " + door["OccupyTop"].ToString() + " ");
            query.Append(" AND ((isnull(volume_T,0)+volume_L+volume_S+volume_M) <> " + door["FlowBottom"].ToString() + " and speed <> 0 or (isnull(volume_T,0)+volume_L+volume_S+volume_M) <> " + door["FlowBottom"].ToString() + " and laneoccupy <> 0)");
            query.Append(" AND (laneoccupy <> " + door["OccupyBottom"].ToString() + " and speed <> 0 or laneoccupy <> " + door["OccupyBottom"].ToString() + " and (isnull(volume_T,0)+volume_L+volume_S+volume_M) <> 0)");
            query.Append(" AND (speed <>  laneoccupy and speed <>  (isnull(volume_T,0)+volume_L+volume_S+volume_M) and (isnull(volume_T,0)+volume_L+volume_S+volume_M) <> laneoccupy)");
        }
        else
        {
            query.Append(" AND (isnull(volume_T,0)+volume_L+volume_S+volume_M) < 60  and speed < 255 and laneoccupy < 100  ");
            query.Append(" AND ((isnull(volume_T,0)+volume_L+volume_S+volume_M) <> 0 and speed <> 0 or (isnull(volume_T,0)+volume_L+volume_S+volume_M) <> 0 and laneoccupy <> 0) ");
            query.Append(" AND (laneoccupy <> 0 and speed <> 0 or laneoccupy <> 0 and (isnull(volume_T,0)+volume_L+volume_S+volume_M) <> 0)");
            query.Append(" AND (speed <>  laneoccupy and speed <>  (isnull(volume_T,0)+volume_L+volume_S+volume_M) and (isnull(volume_T,0)+volume_L+volume_S+volume_M) <> laneoccupy) ");
        }
        query.Append(" AND datacollecttime between '" + txt_startDateTime.Text + "'  and '" + txt_endDateTime.Text + "'");
        query.Append("  GROUP BY vdid,vsrdir,DatePart(WEEKDAY, datacollecttime), DatePart(HOUR, datacollecttime) ");

        //若是標準型態試算，則算出標準型態並進行資料排序，以利於畫圖表
        query.Append("  Order by vdid,DatePart(WEEKDAY, datacollecttime),DatePart(HOUR, datacollecttime)  ");
        dsCaledStd = _operator.SelectQuery(query.ToString());
        return dsCaledStd;
    }

    private DataSet calStandard(string vd, string vsrdir, DateTime start, DateTime end)
    {
        //string vd = ddlst_Device.SelectedValue;
        SQLDB _operator = new SQLDB("VD_DOORSILL", "KPT");
        //撈出相對應的異常資料門檻值
        DataSet vdDoorSill = _operator.Select("DeviceID = '" + vd + "'", "", "VD_DOORSILL");

        //用來存放各VD之標準型態
        DataSet dsCaledStd = new DataSet();

        //先刪除舊標準型態中與計算出來的有衝突的資料
        StringBuilder query = new StringBuilder();

        query.Append(" SELECT vdid,vsrdir,avg(speed)as SpeedAvg,isnull(stdev(speed),0) as SpeedStandard, ");
        query.Append("             avg(laneoccupy) as laneoccupyAvg,isnull(stdev(laneoccupy),0)as LaneOccupyStandard,  ");
        query.Append("             avg(isnull(volume_T,0)+volume_L+volume_S+volume_M) as FlowAvg,isnull(stdev(isnull(volume_T,0)+volume_L+volume_S+volume_M),0)as FlowStandard, ");
        query.Append("             DatePart(WEEKDAY, datacollecttime) as week,DatePart(HOUR, datacollecttime) as hours ");
        query.Append(" from VD_Value_his ");
        query.Append(" where vdid = '" + vd + "' AND vsrdir = '" + vsrdir + "' ");
        if (vdDoorSill.Tables[0].Rows.Count > 0)
        {
            DataRow door = vdDoorSill.Tables[0].Rows[0];
            query.Append(" AND (isnull(volume_T,0)+volume_L+volume_S+volume_M) < " + door["FlowTop"].ToString() + "  and speed < " + door["SpeedTop"].ToString() + " and laneoccupy < " + door["OccupyTop"].ToString() + " ");
            query.Append(" AND ((isnull(volume_T,0)+volume_L+volume_S+volume_M) <> " + door["FlowBottom"].ToString() + " and speed <> 0 or (isnull(volume_T,0)+volume_L+volume_S+volume_M) <> " + door["FlowBottom"].ToString() + " and laneoccupy <> 0)");
            query.Append(" AND (laneoccupy <> " + door["OccupyBottom"].ToString() + " and speed <> 0 or laneoccupy <> " + door["OccupyBottom"].ToString() + " and (isnull(volume_T,0)+volume_L+volume_S+volume_M) <> 0)");
            query.Append(" AND (speed <>  laneoccupy and speed <>  (isnull(volume_T,0)+volume_L+volume_S+volume_M) and (isnull(volume_T,0)+volume_L+volume_S+volume_M) <> laneoccupy)");
        }
        else
        {
            query.Append(" AND (isnull(volume_T,0)+volume_L+volume_S+volume_M) < 60  and speed < 255 and laneoccupy < 100  ");
            query.Append(" AND ((isnull(volume_T,0)+volume_L+volume_S+volume_M) <> 0 and speed <> 0 or (isnull(volume_T,0)+volume_L+volume_S+volume_M) <> 0 and laneoccupy <> 0) ");
            query.Append(" AND (laneoccupy <> 0 and speed <> 0 or laneoccupy <> 0 and (isnull(volume_T,0)+volume_L+volume_S+volume_M) <> 0)");
            query.Append(" AND (speed <>  laneoccupy and speed <>  (isnull(volume_T,0)+volume_L+volume_S+volume_M) and (isnull(volume_T,0)+volume_L+volume_S+volume_M) <> laneoccupy) ");
        }
        query.Append(" AND datacollecttime between '" + start.ToString("yyyy/MM/dd HH:mm:ss") + "'  and '" + end.ToString("yyyy/MM/dd HH:mm:ss") + "'");
        query.Append("  GROUP BY vdid,vsrdir,DatePart(WEEKDAY, datacollecttime), DatePart(HOUR, datacollecttime) ");

        //若是標準型態試算，則算出標準型態並進行資料排序，以利於畫圖表
        query.Append("  Order by vdid,DatePart(WEEKDAY, datacollecttime),DatePart(HOUR, datacollecttime)  ");
        dsCaledStd = _operator.SelectQuery(query.ToString());
        return dsCaledStd;
    }

    protected void lnkbtn_saveStandardall_Click(object sender, EventArgs e)
    {
        SQLDB _operator = new SQLDB("VD_Info", "KPT");
        string query = "select vdid from VD_Info group by vdid";
        DataSet ds_allvd = _operator.SelectQuery(query);
        for (int f = 10; f < ds_allvd.Tables[0].Rows.Count; f++)
        {
            int vsrdir2 = 2;
            for (int k = 0; k < vsrdir2; k++)
            {
                DataSet dsCaledStd = new DataSet();
                dsCaledStd = calStandard(ds_allvd.Tables[0].Rows[f]["vdid"].ToString(), k.ToString(), new DateTime(2014, 06, 09, 12, 0, 0), new DateTime(2014, 07, 09, 12, 0, 0));
                if (dsCaledStd.Tables[0].Rows.Count > 0)
                {
                    DataSet ds_standard = _operator.Select("", "", "VD_STANDARD");
                    DateTime updatetime = DateTime.Now;
                    DataSet ds_standardAdd = _operator.Select("1=0", "", "VD_STANDARD");
                    DataSet ds_standardAddHis = _operator.Select("1=0", "", "VD_STANDARD_HIS");
                    for (int i = 0; i < dsCaledStd.Tables[0].Rows.Count; i++)
                    {
                        DataRow dr = dsCaledStd.Tables[0].Rows[i];
                        string vdid = dr["vdid"].ToString();
                        string vsrdir = dr["vsrdir"].ToString();
                        string week = dr["week"].ToString();
                        string hours = dr["hours"].ToString();

                        DataRow[] dr_std = ds_standard.Tables[0].Select("Vdid = '" + vdid + "' AND Vsrdir = '" + vsrdir + "' AND Week = '" + week + "' AND Hours = '" + hours + "' ");


                        DataRow dr_add = ds_standardAdd.Tables[0].NewRow();
                        dr_add["Vdid"] = vdid;
                        dr_add["TypeName"] = "Default";
                        dr_add["Vsrdir"] = vsrdir;
                        dr_add["Hours"] = hours;
                        dr_add["Week"] = week;
                        dr_add["SpeedAvg"] = dr["SpeedAvg"].ToString();
                        dr_add["SpeedStandard"] = dr["SpeedStandard"].ToString();
                        dr_add["LaneOccupyAvg"] = dr["LaneOccupyAvg"].ToString();
                        dr_add["LaneOccupyStandard"] = dr["LaneOccupyStandard"].ToString();
                        dr_add["FlowAvg"] = dr["FlowAvg"].ToString();
                        dr_add["FlowStandard"] = dr["FlowStandard"].ToString();
                        dr_add["Times"] = 2;
                        dr_add["UpdateTime"] = updatetime;
                        ds_standardAdd.Tables[0].Rows.Add(dr_add);

                        //將有衝突的標準型態備份到VD_STANDARD_HIS
                        if (dr_std.Length > 0)
                        {
                            DataRow dr_addhis = ds_standardAddHis.Tables[0].NewRow();
                            dr_addhis["StandardNum"] = dr_std[0]["StandardNum"];
                            dr_addhis["Vdid"] = vdid;
                            dr_addhis["TypeName"] = "Default";
                            dr_addhis["Vsrdir"] = vsrdir;
                            dr_addhis["Hours"] = hours;
                            dr_addhis["Week"] = week;
                            dr_addhis["SpeedAvg"] = dr_std[0]["SpeedAvg"].ToString();
                            dr_addhis["SpeedStandard"] = dr_std[0]["SpeedStandard"].ToString();
                            dr_addhis["LaneOccupyAvg"] = dr_std[0]["LaneOccupyAvg"].ToString();
                            dr_addhis["LaneOccupyStandard"] = dr_std[0]["LaneOccupyStandard"].ToString();
                            dr_addhis["FlowAvg"] = dr_std[0]["FlowAvg"].ToString();
                            dr_addhis["FlowStandard"] = dr["FlowStandard"].ToString();
                            dr_addhis["Times"] = 2;
                            dr_addhis["UpdateTime"] = updatetime;
                            ds_standardAddHis.Tables[0].Rows.Add(dr_addhis);

                            dr_std[0].Delete();
                        }
                    }

                    DataSet DSChange = ds_standard.GetChanges(DataRowState.Deleted);
                    if (DSChange != null)
                    {
                        if (_operator.Delete(DSChange))
                        {
                            // ShowMsg(UpdatePanel1, "資料刪除成功");
                        }
                    }

                    DataSet DSChangeAdd = ds_standardAdd.GetChanges();
                    DataSet DSChangeAddHis = ds_standardAddHis.GetChanges();
                    bool suc = false;
                    if (DSChangeAdd != null)
                    {
                        if (_operator.Insert(DSChangeAdd))
                        {
                            suc = true;
                        }
                    }
                    if (DSChangeAddHis != null)
                    {
                        if (_operator.Insert(DSChangeAdd))
                        {
                            suc = true;
                        }
                    }

                    //if (suc)
                    //{
                    //    ShowMsg(UpdatePanel2, "建立成功");
                    //}
                }
            }
        }
        ShowMsg(UpdatePanel2, "建立成功");
    }
}

#line default
#line hidden
