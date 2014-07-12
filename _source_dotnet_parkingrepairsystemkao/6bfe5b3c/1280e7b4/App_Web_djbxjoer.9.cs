#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\VDCheck\StandardList_Q.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E428970FCC8E242EBAF8F1050E5F446FC5956AA8"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\VDCheck\StandardList_Q.aspx.cs"
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

public partial class VDCheck_StandardList_Q : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ScriptManager1.IsInAsyncPostBack)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "addSearchIcon();", true);
            InitData();
        }
    }
    protected override void InitData()
    {
        SQLDB _operator = new SQLDB("VD_Info", "KPT");
        string query = "select Vdid from VD_STANDARD group by Vdid";
        DataSet ds = _operator.SelectQuery(query);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem vditem = new ListItem();
            vditem.Value = ds.Tables[0].Rows[i]["Vdid"].ToString();
            vditem.Text = ds.Tables[0].Rows[i]["Vdid"].ToString();
            ddlst_Device.Items.Add(vditem);
        }
    }

    //查詢標準型態資料
    protected void lnkbtn_calStandard_Click(object sender, EventArgs e)
    {
        string vd = ddlst_Device.SelectedValue;
        SQLDB _operator = new SQLDB("VD_STANDARD", "KPT");
        DataSet vdStandard = _operator.Select("Vdid = '" + vd + "' AND Vsrdir = '" + ddlst_Vsrdir.SelectedValue + "'", "Vdid , TypeName,Week,Hours", "VD_STANDARD");
        RunChart(vdStandard);
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



   
}

#line default
#line hidden
