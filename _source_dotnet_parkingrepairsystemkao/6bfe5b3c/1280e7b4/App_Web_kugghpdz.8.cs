﻿#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "335F7D367850CED89063216D4D1BB63932B40789"
//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.18408
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------



public partial class testchart : System.Web.SessionState.IRequiresSessionState {
    
    
    #line 17 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
    protected global::System.Web.UI.DataVisualization.Charting.Chart Chart1;
    
    #line default
    #line hidden
    
    
    #line 27 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
    protected global::System.Web.UI.WebControls.SqlDataSource SqlDataSource1;
    
    #line default
    #line hidden
    
    
    #line 28 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
    protected global::System.Web.UI.DataVisualization.Charting.Chart Chart2;
    
    #line default
    #line hidden
    
    
    #line 13 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
    protected global::System.Web.UI.HtmlControls.HtmlForm form1;
    
    #line default
    #line hidden
    
    protected System.Web.Profile.DefaultProfile Profile {
        get {
            return ((System.Web.Profile.DefaultProfile)(this.Context.Profile));
        }
    }
    
    protected ASP.global_asax ApplicationInstance {
        get {
            return ((ASP.global_asax)(this.Context.ApplicationInstance));
        }
    }
}
namespace ASP {
    
    #line 3 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
    using System.Web.UI.WebControls.Expressions;
    
    #line default
    #line hidden
    
    #line 387 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 393 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Text;
    
    #line default
    #line hidden
    
    #line 3 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
    using System.Web.UI;
    
    #line default
    #line hidden
    
    #line 388 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 3 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
    using System.Web.DynamicData;
    
    #line default
    #line hidden
    
    #line 392 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Linq;
    
    #line default
    #line hidden
    
    #line 405 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Xml.Linq;
    
    #line default
    #line hidden
    
    #line 398 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Web.SessionState;
    
    #line default
    #line hidden
    
    #line 391 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Configuration;
    
    #line default
    #line hidden
    
    #line 395 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Web;
    
    #line default
    #line hidden
    
    #line 3 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
    using System.Web.UI.WebControls;
    
    #line default
    #line hidden
    
    #line 396 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Web.Caching;
    
    #line default
    #line hidden
    
    #line 400 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Web.Profile;
    
    #line default
    #line hidden
    
    #line 390 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.ComponentModel.DataAnnotations;
    
    #line default
    #line hidden
    
    #line 389 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Collections.Specialized;
    
    #line default
    #line hidden
    
    #line 399 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Web.Security;
    
    #line default
    #line hidden
    
    #line 386 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System;
    
    #line default
    #line hidden
    
    #line 3 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
    using System.Web.UI.WebControls.WebParts;
    
    #line default
    #line hidden
    
    #line 394 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Text.RegularExpressions;
    
    #line default
    #line hidden
    
    #line 3 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
    using System.Web.UI.DataVisualization.Charting;
    
    #line default
    #line hidden
    
    #line 404 "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\web.config"
    using System.Web.UI.HtmlControls;
    
    #line default
    #line hidden
    
    
    [System.Runtime.CompilerServices.CompilerGlobalScopeAttribute()]
    public class testchart_aspx : global::testchart, System.Web.IHttpHandler {
        
        private static System.Reflection.MethodInfo @__PageInspector_SetTraceDataMethod = global::ASP.testchart_aspx.@__PageInspector_LoadHelper("SetTraceData");
        
        private static bool @__initialized;
        
        private static object @__stringResource;
        
        private static object @__fileDependencies;
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public testchart_aspx() {
            string[] dependencies;
            
            #line 912304 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx.cs"
            ((global::System.Web.UI.Page)(this)).AppRelativeVirtualPath = "~/testchart.aspx";
            
            #line default
            #line hidden
            if ((global::ASP.testchart_aspx.@__initialized == false)) {
                global::ASP.testchart_aspx.@__stringResource = this.ReadStringResource();
                dependencies = new string[2];
                dependencies[0] = "~/testchart.aspx";
                dependencies[1] = "~/testchart.aspx.cs";
                global::ASP.testchart_aspx.@__fileDependencies = this.GetWrappedFileDependencies(dependencies);
                global::ASP.testchart_aspx.@__initialized = true;
            }
            this.Server.ScriptTimeout = 30000000;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private global::System.Web.UI.LiteralControl @__BuildControl__control2() {
            global::System.Web.UI.LiteralControl @__ctrl;
            @__ctrl = new global::System.Web.UI.LiteralControl("\r\n\r\n<!DOCTYPE html>\r\n\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
            this.@__PageInspector_SetTraceData(new object[] {
                        @__ctrl,
                        null,
                        293,
                        68,
                        true});
            return @__ctrl;
        }
        
        private static System.Reflection.MethodInfo @__PageInspector_LoadHelper(string helperName) {
            System.Type helperClass = System.Type.GetType("Microsoft.VisualStudio.Web.PageInspector.Runtime.WebForms.TraceHelpers, Microsoft" +
                    ".VisualStudio.Web.PageInspector.Runtime, Version=1.3.0.0, Culture=neutral, Publi" +
                    "cKeyToken=b03f5f7f11d50a3a", false, false);
            if ((helperClass != null)) {
                return helperClass.GetMethod(helperName);
            }
            return null;
        }
        
        private void @__PageInspector_SetTraceData(object[] parameters) {
            if ((global::ASP.testchart_aspx.@__PageInspector_SetTraceDataMethod != null)) {
                global::ASP.testchart_aspx.@__PageInspector_SetTraceDataMethod.Invoke(null, parameters);
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private global::System.Web.UI.HtmlControls.HtmlMeta @__BuildControl__control4() {
            global::System.Web.UI.HtmlControls.HtmlMeta @__ctrl;
            
            #line 9 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl = new global::System.Web.UI.HtmlControls.HtmlMeta();
            
            #line default
            #line hidden
            
            #line 9 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            ((System.Web.UI.IAttributeAccessor)(@__ctrl)).SetAttribute("http-equiv", "Content-Type");
            
            #line default
            #line hidden
            
            #line 9 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl.Content = "text/html; charset=utf-8";
            
            #line default
            #line hidden
            this.@__PageInspector_SetTraceData(new object[] {
                        @__ctrl,
                        null,
                        384,
                        68,
                        false});
            return @__ctrl;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private global::System.Web.UI.HtmlControls.HtmlTitle @__BuildControl__control5() {
            global::System.Web.UI.HtmlControls.HtmlTitle @__ctrl;
            
            #line 10 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl = new global::System.Web.UI.HtmlControls.HtmlTitle();
            
            #line default
            #line hidden
            this.@__PageInspector_SetTraceData(new object[] {
                        @__ctrl,
                        null,
                        458,
                        15,
                        false});
            return @__ctrl;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private global::System.Web.UI.HtmlControls.HtmlHead @__BuildControl__control3() {
            global::System.Web.UI.HtmlControls.HtmlHead @__ctrl;
            
            #line 8 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl = new global::System.Web.UI.HtmlControls.HtmlHead("head");
            
            #line default
            #line hidden
            global::System.Web.UI.HtmlControls.HtmlMeta @__ctrl1;
            
            #line 8 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl1 = this.@__BuildControl__control4();
            
            #line default
            #line hidden
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            
            #line 8 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__parser.AddParsedSubObject(@__ctrl1);
            
            #line default
            #line hidden
            global::System.Web.UI.HtmlControls.HtmlTitle @__ctrl2;
            
            #line 8 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl2 = this.@__BuildControl__control5();
            
            #line default
            #line hidden
            
            #line 8 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__parser.AddParsedSubObject(@__ctrl2);
            
            #line default
            #line hidden
            this.@__PageInspector_SetTraceData(new object[] {
                        @__ctrl,
                        null,
                        361,
                        121,
                        false});
            return @__ctrl;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private global::System.Web.UI.LiteralControl @__BuildControl__control6() {
            global::System.Web.UI.LiteralControl @__ctrl;
            @__ctrl = new global::System.Web.UI.LiteralControl("\r\n<body>\r\n    ");
            this.@__PageInspector_SetTraceData(new object[] {
                        @__ctrl,
                        null,
                        482,
                        14,
                        true});
            return @__ctrl;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private global::System.Web.UI.LiteralControl @__BuildControl__control7() {
            global::System.Web.UI.LiteralControl @__ctrl;
            @__ctrl = new global::System.Web.UI.LiteralControl("\r\n    <div>\r\n    \r\n\r\n        ");
            this.@__PageInspector_SetTraceData(new object[] {
                        @__ctrl,
                        null,
                        528,
                        29,
                        true});
            return @__ctrl;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private global::System.Web.UI.DataVisualization.Charting.Series @__BuildControl__control9() {
            global::System.Web.UI.DataVisualization.Charting.Series @__ctrl;
            
            #line 19 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl = new global::System.Web.UI.DataVisualization.Charting.Series();
            
            #line default
            #line hidden
            
            #line 19 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl.Name = "Series1";
            
            #line default
            #line hidden
            
            #line 19 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl.XValueMember = "CompanyName";
            
            #line default
            #line hidden
            
            #line 19 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl.YValueMembers = "CompanyGroup";
            
            #line default
            #line hidden
            return @__ctrl;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void @__BuildControl__control8(System.Web.UI.DataVisualization.Charting.SeriesCollection @__ctrl) {
            global::System.Web.UI.DataVisualization.Charting.Series @__ctrl1;
            
            #line 17 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl1 = this.@__BuildControl__control9();
            
            #line default
            #line hidden
            
            #line 17 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl.Add(@__ctrl1);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private global::System.Web.UI.DataVisualization.Charting.ChartArea @__BuildControl__control11() {
            global::System.Web.UI.DataVisualization.Charting.ChartArea @__ctrl;
            
            #line 23 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl = new global::System.Web.UI.DataVisualization.Charting.ChartArea();
            
            #line default
            #line hidden
            
            #line 23 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl.Name = "ChartArea1";
            
            #line default
            #line hidden
            return @__ctrl;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void @__BuildControl__control10(System.Web.UI.DataVisualization.Charting.ChartAreaCollection @__ctrl) {
            global::System.Web.UI.DataVisualization.Charting.ChartArea @__ctrl1;
            
            #line 17 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl1 = this.@__BuildControl__control11();
            
            #line default
            #line hidden
            
            #line 17 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl.Add(@__ctrl1);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private global::System.Web.UI.DataVisualization.Charting.Chart @__BuildControlChart1() {
            global::System.Web.UI.DataVisualization.Charting.Chart @__ctrl;
            
            #line 17 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl = new global::System.Web.UI.DataVisualization.Charting.Chart();
            
            #line default
            #line hidden
            this.Chart1 = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this);
            
            #line 17 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl.ID = "Chart1";
            
            #line default
            #line hidden
            
            #line 17 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl.DataSourceID = "SqlDataSource1";
            
            #line default
            #line hidden
            
            #line 17 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            this.@__BuildControl__control8(@__ctrl.Series);
            
            #line default
            #line hidden
            
            #line 17 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            this.@__BuildControl__control10(@__ctrl.ChartAreas);
            
            #line default
            #line hidden
            this.@__PageInspector_SetTraceData(new object[] {
                        @__ctrl,
                        null,
                        557,
                        405,
                        false});
            return @__ctrl;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private global::System.Web.UI.LiteralControl @__BuildControl__control12() {
            global::System.Web.UI.LiteralControl @__ctrl;
            @__ctrl = new global::System.Web.UI.LiteralControl("\r\n        ");
            this.@__PageInspector_SetTraceData(new object[] {
                        @__ctrl,
                        null,
                        962,
                        10,
                        true});
            return @__ctrl;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private global::System.Web.UI.WebControls.SqlDataSource @__BuildControlSqlDataSource1() {
            global::System.Web.UI.WebControls.SqlDataSource @__ctrl;
            
            #line 27 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl = new global::System.Web.UI.WebControls.SqlDataSource();
            
            #line default
            #line hidden
            this.SqlDataSource1 = @__ctrl;
            
            #line 27 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl.ID = "SqlDataSource1";
            
            #line default
            #line hidden
            
            #line 27 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl.SelectCommand = "SELECT * FROM [Company]";
            
            #line default
            #line hidden
            @__ctrl.ConnectionString = global::System.Convert.ToString(System.Web.Compilation.ConnectionStringsExpressionBuilder.GetConnectionString("MROSConnectionString"), global::System.Globalization.CultureInfo.CurrentCulture);
            this.@__PageInspector_SetTraceData(new object[] {
                        @__ctrl,
                        null,
                        972,
                        179,
                        false});
            return @__ctrl;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private global::System.Web.UI.LiteralControl @__BuildControl__control13() {
            global::System.Web.UI.LiteralControl @__ctrl;
            @__ctrl = new global::System.Web.UI.LiteralControl("\r\n        ");
            this.@__PageInspector_SetTraceData(new object[] {
                        @__ctrl,
                        null,
                        1151,
                        10,
                        true});
            return @__ctrl;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private global::System.Web.UI.DataVisualization.Charting.Series @__BuildControl__control15() {
            global::System.Web.UI.DataVisualization.Charting.Series @__ctrl;
            
            #line 30 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl = new global::System.Web.UI.DataVisualization.Charting.Series();
            
            #line default
            #line hidden
            
            #line 30 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl.ChartType = global::System.Web.UI.DataVisualization.Charting.SeriesChartType.Doughnut;
            
            #line default
            #line hidden
            
            #line 30 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl.Name = "Series1";
            
            #line default
            #line hidden
            
            #line 30 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl.XValueMember = "CompanyName";
            
            #line default
            #line hidden
            
            #line 30 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl.YValueMembers = "CompanyGroup";
            
            #line default
            #line hidden
            return @__ctrl;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void @__BuildControl__control14(System.Web.UI.DataVisualization.Charting.SeriesCollection @__ctrl) {
            global::System.Web.UI.DataVisualization.Charting.Series @__ctrl1;
            
            #line 28 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl1 = this.@__BuildControl__control15();
            
            #line default
            #line hidden
            
            #line 28 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl.Add(@__ctrl1);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private global::System.Web.UI.DataVisualization.Charting.ChartArea @__BuildControl__control17() {
            global::System.Web.UI.DataVisualization.Charting.ChartArea @__ctrl;
            
            #line 34 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl = new global::System.Web.UI.DataVisualization.Charting.ChartArea();
            
            #line default
            #line hidden
            
            #line 34 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl.Name = "ChartArea1";
            
            #line default
            #line hidden
            return @__ctrl;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void @__BuildControl__control16(System.Web.UI.DataVisualization.Charting.ChartAreaCollection @__ctrl) {
            global::System.Web.UI.DataVisualization.Charting.ChartArea @__ctrl1;
            
            #line 28 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl1 = this.@__BuildControl__control17();
            
            #line default
            #line hidden
            
            #line 28 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl.Add(@__ctrl1);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private global::System.Web.UI.DataVisualization.Charting.Chart @__BuildControlChart2() {
            global::System.Web.UI.DataVisualization.Charting.Chart @__ctrl;
            
            #line 28 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl = new global::System.Web.UI.DataVisualization.Charting.Chart();
            
            #line default
            #line hidden
            this.Chart2 = @__ctrl;
            @__ctrl.ApplyStyleSheetSkin(this);
            
            #line 28 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl.ID = "Chart2";
            
            #line default
            #line hidden
            
            #line 28 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl.DataSourceID = "SqlDataSource1";
            
            #line default
            #line hidden
            
            #line 28 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            this.@__BuildControl__control14(@__ctrl.Series);
            
            #line default
            #line hidden
            
            #line 28 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            this.@__BuildControl__control16(@__ctrl.ChartAreas);
            
            #line default
            #line hidden
            this.@__PageInspector_SetTraceData(new object[] {
                        @__ctrl,
                        null,
                        1161,
                        426,
                        false});
            return @__ctrl;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private global::System.Web.UI.LiteralControl @__BuildControl__control18() {
            global::System.Web.UI.LiteralControl @__ctrl;
            @__ctrl = new global::System.Web.UI.LiteralControl("\r\n    \r\n\r\n    </div>\r\n    ");
            this.@__PageInspector_SetTraceData(new object[] {
                        @__ctrl,
                        null,
                        1587,
                        26,
                        true});
            return @__ctrl;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private global::System.Web.UI.HtmlControls.HtmlForm @__BuildControlform1() {
            global::System.Web.UI.HtmlControls.HtmlForm @__ctrl;
            
            #line 13 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl = new global::System.Web.UI.HtmlControls.HtmlForm();
            
            #line default
            #line hidden
            this.form1 = @__ctrl;
            
            #line 13 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl.ID = "form1";
            
            #line default
            #line hidden
            global::System.Web.UI.LiteralControl @__ctrl1;
            
            #line 13 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl1 = this.@__BuildControl__control7();
            
            #line default
            #line hidden
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            
            #line 13 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__parser.AddParsedSubObject(@__ctrl1);
            
            #line default
            #line hidden
            global::System.Web.UI.DataVisualization.Charting.Chart @__ctrl2;
            
            #line 13 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl2 = this.@__BuildControlChart1();
            
            #line default
            #line hidden
            
            #line 13 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__parser.AddParsedSubObject(@__ctrl2);
            
            #line default
            #line hidden
            global::System.Web.UI.LiteralControl @__ctrl3;
            
            #line 13 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl3 = this.@__BuildControl__control12();
            
            #line default
            #line hidden
            
            #line 13 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__parser.AddParsedSubObject(@__ctrl3);
            
            #line default
            #line hidden
            global::System.Web.UI.WebControls.SqlDataSource @__ctrl4;
            
            #line 13 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl4 = this.@__BuildControlSqlDataSource1();
            
            #line default
            #line hidden
            
            #line 13 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__parser.AddParsedSubObject(@__ctrl4);
            
            #line default
            #line hidden
            global::System.Web.UI.LiteralControl @__ctrl5;
            
            #line 13 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl5 = this.@__BuildControl__control13();
            
            #line default
            #line hidden
            
            #line 13 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__parser.AddParsedSubObject(@__ctrl5);
            
            #line default
            #line hidden
            global::System.Web.UI.DataVisualization.Charting.Chart @__ctrl6;
            
            #line 13 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl6 = this.@__BuildControlChart2();
            
            #line default
            #line hidden
            
            #line 13 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__parser.AddParsedSubObject(@__ctrl6);
            
            #line default
            #line hidden
            global::System.Web.UI.LiteralControl @__ctrl7;
            
            #line 13 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl7 = this.@__BuildControl__control18();
            
            #line default
            #line hidden
            
            #line 13 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__parser.AddParsedSubObject(@__ctrl7);
            
            #line default
            #line hidden
            this.@__PageInspector_SetTraceData(new object[] {
                        @__ctrl,
                        null,
                        496,
                        1124,
                        false});
            return @__ctrl;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private global::System.Web.UI.LiteralControl @__BuildControl__control19() {
            global::System.Web.UI.LiteralControl @__ctrl;
            @__ctrl = new global::System.Web.UI.LiteralControl("\r\n</body>\r\n</html>\r\n");
            this.@__PageInspector_SetTraceData(new object[] {
                        @__ctrl,
                        null,
                        1620,
                        20,
                        true});
            return @__ctrl;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void @__BuildControlTree(testchart_aspx @__ctrl) {
            
            #line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            this.InitializeCulture();
            
            #line default
            #line hidden
            global::System.Web.UI.LiteralControl @__ctrl1;
            
            #line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl1 = this.@__BuildControl__control2();
            
            #line default
            #line hidden
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            
            #line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__parser.AddParsedSubObject(@__ctrl1);
            
            #line default
            #line hidden
            global::System.Web.UI.HtmlControls.HtmlHead @__ctrl2;
            
            #line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl2 = this.@__BuildControl__control3();
            
            #line default
            #line hidden
            
            #line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__parser.AddParsedSubObject(@__ctrl2);
            
            #line default
            #line hidden
            global::System.Web.UI.LiteralControl @__ctrl3;
            
            #line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl3 = this.@__BuildControl__control6();
            
            #line default
            #line hidden
            
            #line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__parser.AddParsedSubObject(@__ctrl3);
            
            #line default
            #line hidden
            global::System.Web.UI.HtmlControls.HtmlForm @__ctrl4;
            
            #line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl4 = this.@__BuildControlform1();
            
            #line default
            #line hidden
            
            #line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__parser.AddParsedSubObject(@__ctrl4);
            
            #line default
            #line hidden
            global::System.Web.UI.LiteralControl @__ctrl5;
            
            #line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__ctrl5 = this.@__BuildControl__control19();
            
            #line default
            #line hidden
            
            #line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx"
            @__parser.AddParsedSubObject(@__ctrl5);
            
            #line default
            #line hidden
        }
        
        
        #line 912304 "D:\Source\DotNet\ParkingRepairSystemKAO\testchart.aspx.cs"
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override void FrameworkInitialize() {
            base.FrameworkInitialize();
            this.SetStringResourcePointer(global::ASP.testchart_aspx.@__stringResource, 0);
            this.@__BuildControlTree(this);
            this.AddWrappedFileDependencies(global::ASP.testchart_aspx.@__fileDependencies);
            this.Request.ValidateInput();
        }
        
        #line default
        #line hidden
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public override int GetTypeHashCode() {
            return -1973239897;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public override void ProcessRequest(System.Web.HttpContext context) {
            base.ProcessRequest(context);
        }
    }
}
