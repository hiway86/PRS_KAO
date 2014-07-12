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

public partial class System_AuthManage : PageBase
{
    UserRole _operator = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ScriptManager1.IsInAsyncPostBack)
        {
            if (Session["LoginStaffID"] == null)
            {
                ShowErrorMsg(this.UpdatePanel1, "請重新登入", "../Logout.aspx");
                return;
            }

            Session["Uers"] = null;
            Session["URDS"] = null;
            try
            {
                if (Request.QueryString["act"] != null)
                {
                    this.hidden_Action.Value = Request.QueryString["act"].Trim();
                    //新增
                    if (this.hidden_Action.Value.Equals("add"))
                    {
                        InitData();
                        BtnEdit("新增存檔");
                    }
                    else if (this.hidden_Action.Value.Equals("edit"))
                    {
                        InitData();
                        if (Request.QueryString["id"] != null)
                        {
                            this.hidden_ID.Value = Request.QueryString["id"].Trim();
                            //
                            if (LoadData())
                            {
                                BtnEdit("修改存檔");
                            }
                            else
                            {
                                ReDirect("資料讀取錯誤!!");
                            }
                        }
                        else
                        {
                            ReDirect("參數錯誤!!");
                        }
                    }
                }
                else
                {
                    ReDirect("參數錯誤!!");
                }
            }
            catch (Exception ex)
            {
                ReDirect("異常錯誤發生!!");
            }
        }

        //ShowMsg(this.UpdatePanel1, this.hidden_Runtask_Detail_ID.Value);
    }

    protected override void InitData()
    {
        //BindDropDownListData(ddl_department, (DataSet)Application["App_Systm_Department"], "DepartmentName", "DepartmentID");
        SQLDB db = new SQLDB();
        DataSet ds = db.Select("", "", "role");
        this.gv.DataSource = ds;
        this.gv.DataBind();
    }

    protected bool LoadData()
    {
        if (_operator == null)
        {
            _operator = new UserRole();
        }

        bool suc = true;

        //取得User
        Users _operator_u = new Users();
        DataSet users = _operator_u.Select("User_ID = '" + this.hidden_ID.Value + "'");
        Session["Uers"] = users;

        txt_UserName.Text = users.Tables[0].Rows[0]["User_Name"].ToString();
        txt_User_ID.Text = users.Tables[0].Rows[0]["User_ID"].ToString();
        //ddl_department.SelectedValue = users.Tables[0].Rows[0]["Departmentid"].ToString();
        txt_tel.Text = users.Tables[0].Rows[0]["Phone"].ToString();
        txt_email.Text = users.Tables[0].Rows[0]["Email"].ToString();
        if (users.Tables[0].Rows[0]["status"].ToString().Length > 0)
        {
            chk_Status.Checked = Convert.ToBoolean(users.Tables[0].Rows[0]["status"].ToString());
        }
        
        //取得User Role
        DataSet role = _operator.Select("", "", "role");
        DataSet urds = _operator.Select(" User_ID = '" + this.hidden_ID.Value + "'", "", "User_Role");

        this.gv.DataSource = null;
        this.gv.DataBind();

        this.gv.DataSource = role;
        this.gv.DataBind();

        if (urds != null && urds.Tables != null)
        {
            for (int i = 0; i < this.gv.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)this.gv.Rows[i].Cells[0].Controls[1];
                DataRow[] drs = urds.Tables[0].Select("Role_ID = '" + this.gv.Rows[i].Cells[1].Text + "'");
                if (drs.Length > 0)
                {
                    chk.Checked = true;
                }
            }
        }

        return suc;
    }


   
    protected void ShowPageMsg(string msg)
    {
        ShowMsg2(UpdatePanel1, msg);
    }

    protected void ReDirect(string msg)
    {
        ShowMsgAndRedirect(UpdatePanel1, msg, "../System/AuthList.aspx");
    }

    protected void BtnEdit(string btnName)
    {
        bool visible = false;
        if (btnName.Trim().Length > 0)
        {
            visible = true;
        }
        this.cmd_Save.Visible = visible;
        this.cmd_Save.Text = btnName.Trim();
    }

    
    protected void cmd_Save_Click(object sender, EventArgs e)
    {
        if (!CheckExistText(txt_UserName))
        {
            ShowPageMsg("請輸入使用者姓名");
            return;
        }
        if (!CheckExistText(txt_User_ID))
        {
            ShowPageMsg("請輸入使用者代號");
            return;
        }
        if (_operator == null)
        {
            _operator = new UserRole();
        }
        Security sec = new Security();
        Users user = new Users();
        bool suc = true;
        try
        {
                user.User_ID = this.txt_User_ID.Text.Trim();
                user.User_Name = this.txt_UserName.Text;
                if (txt_Password.Text.Length > 0)
                    user.User_Password = user.GetEncryptPassword(this.txt_Password.Text.Trim());
                user.Create_Time = DateTime.Now;
                //if (ddl_department.SelectedValue != "-1")
                //{
                //    user.DepartmentID = Convert.ToInt32(ddl_department.SelectedValue);
                //}
                user.Phone = txt_tel.Text;
                user.Email = txt_email.Text;
                user.Status = chk_Status.Checked;
                user.Expire_Time = DateTime.Now;
                user.Update_Time = DateTime.Now;

            if (this.hidden_Action.Value.Equals("add"))
            {
                //新增User
                if (user.Add())
                {
                    
                    sec.SaveLog(this.txt_User_ID.Text.Trim(), "add user", "AuthManage", "success", Session["LoginStaffID"].ToString());
                }
                else
                {
                    suc = false;
                    sec.SaveLog(this.txt_User_ID.Text.Trim(), "add user", "AuthManage", "fault", Session["LoginStaffID"].ToString());
                }

                //新增User Role
                string role = "";
                for (int i = 0; i < this.gv.Rows.Count; i++)
                {
                    CheckBox chk = (CheckBox)this.gv.Rows[i].Cells[0].Controls[1];
                    if (chk.Checked)
                    {
                        _operator.User_ID = this.txt_User_ID.Text.Trim();
                        _operator.Role_ID = this.gv.Rows[i].Cells[1].Text.Trim();
                        suc &= _operator.AddUserRole();
                        role += _operator.Role_ID + ",";
                    }
                }
                sec.SaveLog(this.txt_User_ID.Text.Trim(), "add userrole", "AuthManage", "role[" + role.TrimEnd(',') + "]", Session["LoginStaffID"].ToString());
            }
            else
            {
                //儲存User Role
                _operator.DeleteUserRole(this.hidden_ID.Value);
                string role = "";
                for (int i = 0; i < this.gv.Rows.Count; i++)
                {
                    CheckBox chk = (CheckBox)this.gv.Rows[i].Cells[0].Controls[1];
                    if (chk.Checked)
                    {
                        _operator.User_ID = this.hidden_ID.Value;
                        _operator.Role_ID = this.gv.Rows[i].Cells[1].Text.Trim();
                        suc &= _operator.AddUserRole();
                        role += _operator.Role_ID + ",";
                    }
                }
                sec.SaveLog(this.hidden_ID.Value, "save userrole", "AuthManage", "role[" + role.TrimEnd(',') + "]", Session["LoginStaffID"].ToString());

                //儲存狀態
                switch (this.chk_Status.Checked)
                {
                    case true:
                        user.SaveStatus(this.hidden_ID.Value, "1");
                        break;
                    case false:
                        user.SaveStatus(this.hidden_ID.Value, "0");
                        break;
                    default:
                        break;
                }
                suc = user.EditUser(user);
                
                
                sec.SaveLog(this.hidden_ID.Value, "save status", "AuthManage", "status[" + this.chk_Status.Checked + "]", Session["LoginStaffID"].ToString());
            }

            if (suc)
            {
                ShowMsgAndRedirect(UpdatePanel1, "修改成功", "AuthList.aspx");
                //ShowPageMsg("儲存成功");
            }
            else
            {
                ShowMsgAndRedirect(UpdatePanel1, "儲存失敗", "AuthList.aspx");
                //ShowPageMsg("儲存失敗");
            }
        }
        catch (Exception ex)
        {
            ShowMsgAndRedirect(UpdatePanel1, "儲存失敗", "AuthList.aspx");
        }
    }

   
}
