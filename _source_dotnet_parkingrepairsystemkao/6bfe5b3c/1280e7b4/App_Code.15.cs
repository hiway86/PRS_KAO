#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\App_Code\PageBase.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4D71CC505702DA06BA8F067926418CB11FCC4CF9"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\App_Code\PageBase.cs"
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Security.Cryptography;

/// <summary>
/// PageBase 的摘要描述
/// </summary>
public abstract class PageBase : System.Web.UI.Page
{
    public PageBase(): base()
    {

    }

    protected abstract void InitData();

    protected override void OnPreLoad(EventArgs e)
    {
        base.OnPreLoad(e);

        //Authority a = new Authority();
        //DataTable dt = a.GetPermit("ceci");
        //Session["AUTH_DT"] = dt;
        //CheckPermission();
    }

    public string GetCurrentPageName()  //取得目前執行頁面名字
    {
        string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
        string sRet = oInfo.Name;
        return sRet;
    }

    public Security GetPagePermit()  //取得目前執行頁面名字
    {
        Hashtable ht = (Hashtable)Session["PageAuthority"];
        Security sec = null;
        if (ht != null)
        {
            sec = (Security)ht[GetCurrentPageName()];
        }
        return sec;
    }

    public Security GetPagePermit(string pagename)  //取得目前執行頁面名字
    {
        Hashtable ht = (Hashtable)Session["PageAuthority"];
        Security sec = null;
        if (ht != null)
        {
            sec = (Security)ht[pagename];
        }
        return sec;
    }

    public void ShowMsg(Control ctl, string msg)    //顯示訊息
    {
        Random Rnd = new Random();
        string key = "msgScript" + Rnd.Next(1000000, 9999999).ToString();
        ScriptManager.RegisterStartupScript(ctl, GetType(), key, "alert('" + msg + "');", true);
    }

    /// <summary>
    /// 顯示訊息，需加入css:impromptu.css script:jquery-1.3.2.js、jquery-impromptu.2.8.min.js
    /// </summary>
    public void ShowMsg2(Control ctl, string msg)    //顯示訊息
    {
        Random Rnd = new Random();
        string key = "msg2Script" + Rnd.Next(1000000, 9999999).ToString();
        ScriptManager.RegisterStartupScript(ctl, GetType(), key, "$.prompt('" + msg + "');", true);
    }

    /// <summary>
    /// 顯示訊息，需加入css:impromptu.css script:jquery-1.3.2.js、jquery-impromptu.2.8.min.js
    /// 再做其他事
    /// </summary>
    public void ShowMsgAndRedirect(Control ctl, string msg, string url)
    {
        string pagName = "，返回上一頁?";
        ShowMsgAndRedirect(ctl, msg, url, pagName);
    }

    public void ShowMsgAndRedirect(Control ctl, string msg, string url, string pagName)
    {

        Random Rnd = new Random();
        string reScript = "buttons: { 確定: true, 取消: false }, submit: function(v, m, f) { " +
                   " if (v) { window.location='" + url + "'} }";
        string key = "msg2Script" + Rnd.Next(1000000, 9999999).ToString();
        ScriptManager.RegisterStartupScript(ctl, GetType(), key, "$.prompt('" + msg + pagName + "',{" + reScript + "});", true);
    }

    public void ShowErrorMsg(Control ctl, string msg, string url)
    {
        Random Rnd = new Random();
        string reScript = "buttons: { 確定: true}, submit: function(v, m, f) { " +
                   " if (v) { window.location='" + url + "'} }";
        string key = "msg2Script" + Rnd.Next(1000000, 9999999).ToString();
        ScriptManager.RegisterStartupScript(ctl, GetType(), key, "$.prompt('" + msg + "',{" + reScript + "});", true);
    }
    /// <summary>
    /// 顯示訊息，需加入css:impromptu.css script:jquery-1.3.2.js、jquery-impromptu.2.8.min.js
    /// 然後關閉
    /// </summary>
    public void ShowMsgAndClose(Control ctl, string msg)
    {
        string pagName = "，即將關閉本頁?";
        ShowMsgAndClose(ctl, msg, pagName);
    }

    public void ShowMsgAndClose(Control ctl, string msg, string pagName)
    {
        Random Rnd = new Random();
        string reScript = "buttons: { 確定: true, 取消: false }, submit: function(v, m, f) { " +
                   " if (v) { self.close();} }";
        string key = "msgexitScript" + Rnd.Next(1000000, 9999999).ToString();
        ScriptManager.RegisterStartupScript(ctl, GetType(), key, "$.prompt('" + msg + pagName + "',{" + reScript + "});", true);
    }

    public void ReDirectPage(Control ctl, string url)    //顯示訊息
    {
        Random Rnd = new Random();
        string key = "reScript" + Rnd.Next(1000000, 9999999).ToString();
        ScriptManager.RegisterStartupScript(ctl, GetType(), key, "window.location='" + url + "'", true);
    }


    /// <summary>
    /// 主要是match責任車資料
    /// </summary>
    public void ShowMatchSelect(DropDownList ct1, string selectValue, DataSet ds, string matchSelectValueColumn, string matchShowValueColumn)
    {
        try
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (Convert.ToString(dr[matchSelectValueColumn]).Equals(selectValue))
                {
                    ct1.SelectedValue = Convert.ToString(dr[matchShowValueColumn]);
                    break;
                }
            }
        }
        catch (Exception ex)
        {
        }
    }

    /// <summary>
    /// 兩個ListBox相互交換資料
    /// 請參考Repair-->BusMaintainSatistics.aspx.cs -->AddQueryBtn_Click(),CancelQueryBtn_Click
    /// </summary>
    public void AddListItem2OtherList(ListBox fromList, ListBox toList)
    {
        if (fromList.Items.Count > 0)
        {
            if (fromList.SelectedIndex != -1)
            {
                ListItem item = fromList.SelectedItem;
                fromList.Items.RemoveAt(fromList.SelectedIndex);
                toList.Items.Add(item);
            }
        }
    }
    //====================BIND 下拉式選單資料=====================
    public void BindDropDownListData(DropDownList ctl, DataSet ds, string datatextfield, string datavaluefield) //bind 下拉選單資料
    {
        BindDropDownListData(ctl, ds, datatextfield, datavaluefield, "", "");
    }

    public void BindComposeDropDownListData(DropDownList ctl, DataSet ds, string[] datatextfieldlist, string datavaluefield)
    {
        BindComposeDropDownListData(ctl, ds, datatextfieldlist, datavaluefield, "", "", "");
    }

    public void BindComposeDropDownListData(DropDownList ctl, DataSet ds, string[] datatextfieldlist, string datavaluefield, string rowfilter, string sortitem) //bind 下拉選單資料
    {
        BindComposeDropDownListData(ctl, ds, datatextfieldlist, datavaluefield, rowfilter, sortitem, "");
    }

    /// <summary>
    /// Bind複合
    /// ex：text可顯示a欄+b欄
    /// </summary>
    public void BindComposeDropDownListData(DropDownList ctl, DataSet ds, string[] datatextfieldlist, string datavaluefield, string rowfilter, string sortitem, string splitChar) //bind 下拉選單資料
    {
        try
        {

            if (datatextfieldlist.Length > 1)
            {
                DataView dv = ds.Tables[0].DefaultView;
                dv.RowFilter = rowfilter;
                dv.Sort = sortitem;
                DataTable dt = dv.ToTable();
                string tempSplitChar = " ";
                if (splitChar.Trim().Length > 0)
                {
                    tempSplitChar = splitChar;
                }
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem item = new ListItem();
                    string textfield = "";
                    foreach (string obj in datatextfieldlist)
                        textfield += dr[obj] + tempSplitChar;
                    item.Text = textfield.Substring(0, textfield.Length - tempSplitChar.Length);
                    item.Value = Convert.ToString(dr[datavaluefield]);
                    ctl.Items.Add(item);
                }
            }
            else if (datatextfieldlist.Length == 1)
            {
                BindDropDownListData(ctl, ds, datatextfieldlist[0], datavaluefield, rowfilter, sortitem);
            }
        }
        catch (Exception ex)
        {
        }
    }

    public void BindDropDownListData(DropDownList ctl, DataSet ds, string datatextfield, string datavaluefield, string rowfilter, string sortitem) //bind 下拉選單資料
    {
        DataView dv = ds.Tables[0].DefaultView;
        dv.RowFilter = rowfilter;
        dv.Sort = sortitem;
        /* 
        if (!rowfilter.Equals(""))
        {
            dv.RowFilter = rowfilter;
        }

        if (!sortitem.Equals(""))
        {
            dv.Sort = sortitem;
        }
        */
        ctl.DataSource = dv;
        ctl.DataTextField = datatextfield;
        ctl.DataValueField = datavaluefield;
        ctl.DataBind();
    }
    //====================BIND CHECKBOX資料=====================
    public void BindCheckBoxData(CheckBoxList chkl, DataSet ds, string dataText, string dataValue, string rowfilter, string sortitem)
    {
        if (rowfilter.Equals("") && sortitem.Equals(""))
        {
            BindCheckBoxListData(chkl, ds, dataText, dataValue, "", "");
        }
        else if (!rowfilter.Equals("") && sortitem.Equals(""))
        {
            BindCheckBoxListData(chkl, ds, dataText, dataValue, rowfilter, "");
        }
        else
        {
            BindCheckBoxListData(chkl, ds, dataText, dataValue, rowfilter, sortitem);
        }
    }
    protected void BindCheckBoxListData(CheckBoxList chkl, DataSet ds, string dataText, string dataValue, string rowfilter, string sortitem)
    {
        DataView dv = ds.Tables[0].DefaultView;
        dv.RowFilter = rowfilter;
        dv.Sort = sortitem;
        //
        chkl.DataTextField = dataText;
        chkl.DataValueField = dataValue;
        chkl.DataSource = dv;
        chkl.DataBind();
    }
    //====================================================
    public void CheckPermission()   //每一頁面進入時,檢查相關權限判斷是否可進入
    {
        if (Session["LoginStaffID"] == null)
        {
            Session["ErrorMsg"] = "登入錯誤(TimeOut)";
            Response.Redirect("/ERMSC/Error.aspx");
        }
        /*
        string system_group = Request.Url.Segments[2].Replace("/", "");
        string program_name = GetCurrentPageName().Replace(".aspx", "");

        DataTable dt = (DataTable)Session["UserAuthority"];
        if (dt == null)
        {
            Session["ErrorMsg"] = "操作逾時";
            Response.Redirect("/CYbus/Error.aspx");
        }
        else
        {
            string expression;
            expression = "System_Folder_Name = '" + system_group + "' AND Program_Name = '" + program_name + "' ";
            if (dt.Select(expression).Length == 0)  //無該頁面權限
            {
                Session["ErrorMsg"] = "請依正常程序操作系統，若無此權限請聯絡系統管理員";
                Response.Redirect("/CYbus/Error.aspx");
            }
            else
            {
                CheckButtonPermission(dt, expression);
            }
        }
         */
    }

    public void Logout() 
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("Index.aspx");
    } 


    protected bool Login(string _userID, string _password)
    {
        bool success = false;
        Session["LoginStaffID"] = null;
        Session["LoginStaff"] = null;
        Session["CompanyScope"] = null;
        Security sec = new Security();
        Users user = new Users();
        Staff _operator = new Staff();
        string staffID = sec.GetStaffID(_userID, _password);
        if (!staffID.Equals(""))
        {
            success = true;
            Session["LoginStaffID"] = staffID;
            Session["LoginStaff"] = _operator.GetStaffLoginInfoByID(staffID);
            //Session["CompanyScope"] = sec.GetCompanyScope(staffID);
            //Session["CompanyDetailScope"] = sec.GetCompanyDetailScope(staffID);
            Session["LoginAuthority"] = sec.GetAuthority(_userID);
            Session["PageAuthority"] = sec.GetPageAuthority(_userID);
            Session["LOGIN"] = "OK";
            string encrypPassword = user.GetEncryptPassword(_password);
            Session["Pwd"] = encrypPassword;

            sec.SaveLog(_userID, "login", "mis", "success", "System");
        }
        else
        {
            string ip = Request.ServerVariables["REMOTE_ADDR"].ToString();
            if (Request.ServerVariables["HTTP_VIA"] != null)
            {
                ip = Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            sec.SaveLog(_userID, "login", "mis", "fault from ip[" + ip + "]", "System");
        }
        return success;
    }

    protected void CheckControlPermission(Control ctrl, string type)  //檢查頁面按鈕權限
    {
        /*
        DataTable dt = (DataTable)Session["LoginAuthority"];
        string system_group = Request.Url.Segments[2].Replace("/", "");
        string program_name = GetCurrentPageName();
        string query = "System_Forder_Name = '" + system_group + "' AND Program_Name = '" + program_name + "' ";
        switch (type)
        {
            case "query":
                if (dt.Select(query + "AND Enable_Query='true'").Length == 0)
                {
                }

                break;
            case "add":
                break;
            case "edit":
                break;
            case "delete":
                break;
            case "print":
                break;
            case "save":
                break;
            default:
                break;
        }
         */
    }

    protected void CheckButtonPermission(DataTable DT, string query)  //檢查頁面按鈕權限
    {
        Control ctl = Page.FindControl("SearchButton");
        if (ctl != null)
        {
            LinkButton searchbtn = (LinkButton)Page.FindControl("SearchButton");
            if (DT.Select(query + "AND Enable_Query='true'").Length == 0)
            {
                searchbtn.Enabled = false;
            }
        }

        ctl = Page.FindControl("AddButton");
        if (ctl != null)
        {
            LinkButton addbtn = (LinkButton)Page.FindControl("AddButton");
            if (DT.Select(query + "AND Enable_Add='true'").Length == 0)
            {
                addbtn.Enabled = false;
            }
        }

        ctl = Page.FindControl("EditButton");
        if (ctl != null)
        {
            LinkButton editbtn = (LinkButton)Page.FindControl("EditButton");
            if (DT.Select(query + "AND Enable_Edit='true'").Length == 0)
            {
                editbtn.Enabled = false;
            }
        }

        ctl = Page.FindControl("DeleteButton");
        if (ctl != null)
        {
            LinkButton deletebtn = (LinkButton)Page.FindControl("DeleteButton");
            if (DT.Select(query + "AND Enable_Delete='true'").Length == 0)
            {
                deletebtn.Enabled = false;
            }
        }

        ctl = Page.FindControl("PrintButton");
        if (ctl != null)
        {
            LinkButton printbtn = (LinkButton)Page.FindControl("PrintButton");
            if (DT.Select(query + "AND Enable_Print='true'").Length == 0)
            {
                printbtn.Enabled = false;
            }
        }

        ctl = Page.FindControl("SaveBtn");
        if (ctl != null)
        {
            Button savebtn = (Button)Page.FindControl("SaveBtn");
            if (DT.Select(query + "AND Enable_Edit_Save ='true'").Length == 0)
            {
                savebtn.Enabled = false;
            }
        }
    }


    /// <summary>
    /// 主要是match DropDownList必免錯誤
    /// </summary>
    public void ShowMatchSelect(DropDownList ct1, string selectValue)
    {
        try
        {
            ct1.SelectedValue = selectValue;

        }
        catch (Exception ex)
        {
            try
            {
                ct1.SelectedIndex = 0;
            }
            catch (Exception e)
            {
            }
        }
    }
    /// <summary>
    /// 預設回傳值是0(沒找到)
    /// </summary>
    public int GetLoginStaffID()
    {
        if (Session["LoginStaffID"] != null)
        {
            try
            {
                return Convert.ToInt32(Session["LoginStaffID"]);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        else
        {
            return 0;
        }
    }

    public void BindDynamicFixGridViewBoundData(GridView gv, string headertext, string datafield)
    {
        try
        {
            BoundField boundField = new BoundField();
            boundField.HeaderText = headertext;
            boundField.DataField = datafield;
            boundField.ReadOnly = true;
            boundField.HeaderStyle.CssClass = "FixedTitleColumn";
            boundField.ItemStyle.CssClass = "FixedDataColumn";
            gv.Columns.Insert(gv.Columns.Count, boundField);
        }
        catch (Exception e)
        {
        }
    }

    public void BindDynamicFixGridViewBoundData(GridView gv, string headertext, string datafield, int itemwidth)
    {
        try
        {
            BoundField boundField = new BoundField();
            boundField.HeaderText = headertext;
            boundField.DataField = datafield;
            boundField.ReadOnly = true;
            boundField.ItemStyle.Width = itemwidth;
            boundField.HeaderStyle.CssClass = "FixedTitleColumn";
            boundField.ItemStyle.CssClass = "FixedDataColumn";
            gv.Columns.Insert(gv.Columns.Count, boundField);
        }
        catch (Exception e)
        {
        }
    }

    public void BindDynamicGridViewBoundData(GridView gv, string headertext, string datafield)
    {
        try
        {
            BoundField boundField = new BoundField();
            boundField.HeaderText = headertext;
            boundField.DataField = datafield;
            boundField.ReadOnly = true;
            gv.Columns.Insert(gv.Columns.Count, boundField);
        }
        catch (Exception e)
        {
        }
    }

    public void BindDynamicGridViewBoundData(GridView gv, string headertext, string datafield, int itemwidth)
    {
        try
        {
            BoundField boundField = new BoundField();
            boundField.HeaderText = headertext;
            boundField.DataField = datafield;
            boundField.ReadOnly = true;
            boundField.ItemStyle.Width = itemwidth;
            gv.Columns.Insert(gv.Columns.Count, boundField);
        }
        catch (Exception e)
        {
        }
    }

    /// <summary>
    /// 將HTML裡面的"nbsp"鬼東西拿掉
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public string removeHTMLBlank(string s)
    {
        return s.Replace("&nbsp;", "");
    }

    /// <summary>
    /// 將datetime輸出入所有要格式(民國年)
    /// </summary>
    //ConvertToTaiwanDate(Convert.ToDateTime(dr["Create_Report_Time"]), "yy/MM/dd HH:mm"))
    public string ConvertToTaiwanDate(DateTime date, string date_format)
    {
        string str_roc_date = date_format;
        string yy = Convert.ToString(date.Year - 1911);
        string MM = date.ToString("MM");
        string M = date.Month.ToString();
        string dd = date.ToString("dd");
        string d = date.Day.ToString();

        string HH = date.ToString("HH");
        string H = date.Hour.ToString();
        string mm = date.ToString("mm");
        string m = date.Minute.ToString();

        if (date_format.Length == 0)
        {
            str_roc_date = Convert.ToString(date.Year - 1911) + "年" + date.Month.ToString() + "月" + date.Day.ToString() + "日";
        }
        else
        {
            str_roc_date = str_roc_date.Replace("yy", yy);
            str_roc_date = str_roc_date.Replace("MM", MM);
            str_roc_date = str_roc_date.Replace("M", M);
            str_roc_date = str_roc_date.Replace("dd", dd);
            str_roc_date = str_roc_date.Replace("d", d);
            str_roc_date = str_roc_date.Replace("HH", HH);
            str_roc_date = str_roc_date.Replace("H", H);
            str_roc_date = str_roc_date.Replace("mm", mm);
            str_roc_date = str_roc_date.Replace("m", m);
        }
        return str_roc_date;
    }

    /// <summary>
    /// 檢查text是不是有值，有true,沒有false
    /// </summary>
    public bool CheckExistText(TextBox t)
    {
        try
        {
            if (t.Text.Trim().Length == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        catch (Exception ex)
        {
            return false;
        }

    }

    /// <summary>
    /// 在Page_Load時將gvidview使用css方式引隱藏欄位
    /// </summary>
    public void GridViewHidden(GridView gv, int idx)
    {
        //gv.Columns[idx].ControlStyle.CssClass ="gridviewhiddenrow";
        //gv.Columns[idx].FooterStyle.CssClass = "gridviewhiddenrow";
        gv.Columns[idx].HeaderStyle.CssClass = "gridviewhiddenrow";
        gv.Columns[idx].ItemStyle.CssClass = "gridviewhiddenrow";
    }

    /// <summary>
    /// 得到加總公式 如=SUM(D1:D30)
    /// </summary>
    public string GetExcelSumFormulate(int sumColumn, int startRow, int endRow)
    {
        string column = GetExcelColumn(sumColumn);
        return "=SUM(" + column + "" + startRow + ":" + column + "" + endRow + ")";
    }

    public string GetExcelColumn(int num)
    {
        string temp = "";
        double fNum = Math.Floor(Convert.ToDouble(num) / Convert.ToDouble(26));
        double sNum = Convert.ToDouble(num) - fNum * 26;
        if (sNum == 0)
        {
            fNum = fNum - 1;
            sNum = 26;
        }
        temp = GetEngChar(Convert.ToInt16(fNum)) + GetEngChar(Convert.ToInt16(sNum));
        return temp;
    }

    public char GetChr(int Num)
    {
        char C = Convert.ToChar(Num);
        return C;
    }

    public string GetEngChar(int num)
    {
        if (num == 0)
        {
            return "";
        }
        else
        {
            return GetChr(num + 64).ToString();
        }
    }

    /// <summary>
    /// Binddata
    /// </summary>
    public void BindDistinctDropDownListData(DropDownList ctl, DataTable dt, string datatextfield, string datavaluefield, DataTable distdt, string distdatavalue, ListItem exitem)
    {
        List<string> list = new List<string>();
        ctl.Items.Clear();
        if (distdt != null)
        {
            foreach (DataRow dr in distdt.Rows)
            {
                list.Add(Convert.ToString(dr[distdatavalue]));
            }
        }
        if (dt != null)
        {
            foreach (DataRow dr in dt.Rows)
            {
                string value = Convert.ToString(dr[datavaluefield]);
                string text = Convert.ToString(dr[datatextfield]);
                if (!list.Contains(value))
                {
                    ListItem item = new ListItem(text, value);
                    ctl.Items.Add(item);
                }
            }
        }
        if (exitem != null)
        {
            ctl.Items.Add(exitem);
        }
    }

    /// <summary>
    /// Binddata
    /// </summary>
    public void BindDistinctDropDownListData(DropDownList ctl, DataTable dt, string datatextfield, string datavaluefield, DataTable distdt, string distdatavalue)
    {
        BindDistinctDropDownListData(ctl, dt, datatextfield, datavaluefield, distdt, distdatavalue, null);
    }

    /// <summary>
    /// Binddata
    /// </summary>
    public void BindComposeDistinctDropDownListData(DropDownList ctl, DataTable dt, string[] datatextfieldlist, string datavaluefield, DataTable distdt, string distdatavalue, string splitChar, ListItem exitem)
    {
        List<string> list = new List<string>();
        ctl.Items.Clear();
        if (distdt != null)
        {
            foreach (DataRow dr in distdt.Rows)
            {
                list.Add(Convert.ToString(dr[distdatavalue]));
            }
        }
        if (dt != null)
        {
            foreach (DataRow dr in dt.Rows)
            {
                string value = Convert.ToString(dr[datavaluefield]);
                string text = "";
                if (datatextfieldlist.Length > 1)
                {
                    foreach (string obj in datatextfieldlist)
                        text += dr[obj] + splitChar;
                    text = text.Substring(0, text.Length - splitChar.Length);
                }
                else if (datatextfieldlist.Length == 1)
                {
                    text = datatextfieldlist[0];
                }
                if (!list.Contains(value))
                {
                    ListItem item = new ListItem(text, value);
                    ctl.Items.Add(item);
                }
            }
        }

        if (exitem != null)
        {
            ctl.Items.Add(exitem);
        }
    }

    /// <summary>
    /// Binddata
    /// </summary>
    public void BindComposeDistinctDropDownListData(DropDownList ctl, DataTable dt, string[] datatextfieldlist, string datavaluefield, DataTable distdt, string distdatavalue, string splitChar)
    {
        BindComposeDistinctDropDownListData(ctl, dt, datatextfieldlist, datavaluefield, distdt, distdatavalue, null);
    }

    /// <summary>
    /// 得到 Literal
    /// </summary>
    public Literal GetLiteral(string htmlContent)
    {
        Literal lt = new Literal();
        lt.Text = htmlContent;
        return lt;
    }

    /// <summary>
    /// 更新車機資料
    /// </summary>
    public static Hashtable GetDirtyBus()
    {
        Hashtable ht_bus = (Hashtable)HttpContext.Current.Application["DirtyBus"];

        if (ht_bus == null)
        {
            ht_bus = new Hashtable();
        }

        return ht_bus;
    }
    

    /// <summary>
    /// 取得登入公司的CompnayID
    /// </summary>
    /// <returns></returns>
    public string GetCompanyScope()
    {
        DataSet ds = (DataSet)Session["CompanyScope"];
        StringBuilder query = new StringBuilder();
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            query.Append(" '" + dr["Company_ID"].ToString() + "',");
        }
        query.Remove(query.Length - 1, 1);
        query.Insert(0, "Company_ID in (");
        query.Append(")");

        return query.ToString();
    }

    public bool Validate<T>(T validateValue)
    {
        if (validateValue == null || (validateValue as string) == "" )
        {
            return false;
        }
        return true;
    }
   
}


#line default
#line hidden
