<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuthManage.aspx.cs" Inherits="System_AuthManage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="Stylesheet" type="text/css" href="../css/impromptu.css" />
    <link href="../css/bootstrap/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap/bootstrap.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../javascript/authority.js"></script>

    <script type="text/javascript" src="../javascript/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>
    <script type="text/javascript" src="../Authority.aspx?p=AuthList.aspx"></script>
    <link href="../css/web.css" rel="stylesheet" type="text/css" />
    <title></title>

    <script type="text/javascript">

        function pageLoad() {
            $('#cmd_Save').bind("click", function() { return saveClick(); });
            $('#cmd_Back').bind("click", function() { return backClick(); });
            setControlPermit();
        }

        function saveClick() {
            if ($('#dl_Staff')[0].selectedIndex == -1) {
                alert('請選擇使用者');
                return false;
            }

            if ($('#txt_User_ID').val().length == 0) {
                alert('請輸入使用者代號');
                return false;
            }

            if ($('#hidden_Action').val() == "add" && $('#txt_Password').val().length == 0) {
                alert('請輸入使用者密碼');
                return false;
            }
        }

        function backClick() {
            location.href = "AuthList.aspx";
            return false;
        }

        //修改
        function edit(val) {
            alert(val);
            return false;
        }

        function setControlPermit() {
            //設定權限
            if (!pagePermit.enableBrowser) {
                $.prompt('操作逾時，請重新登入',
            {
                buttons: { 確定: true },
                submit: function(v, m, f) {
                    window.location = '../Login.aspx';
                }
            });
                $('div.jqi .jqiclose').hide();
            }
            if (!pagePermit.enableQuery) {
                $('#cmd_Search').attr('disabled', 'disabled');
            }
            if (!pagePermit.enableAdd) {
                $('#lnkbtn_Add').attr('disabled', 'disabled');
            }
            if (!pagePermit.enableEdit) {
                $("#gv :input[id$='cmd_Edit']").attr('disabled', 'disabled');
            }
            if (!pagePermit.enableDelete) {
                $("#gv :input[id$='cmd_Delete']").attr('disabled', 'disabled');
            }
        }


    </script>

    <style type="text/css">
        .style1
        {
            height: 42px;
        }
    </style>

</head>
<body id="body" runat="server">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <center>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                 <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="2">
                    <ProgressTemplate>
                        <div class="progressBackgroundLayer">
                        </div>
                        <div class="fixedCenter">
                            <img src="../images/ajax-loader2.gif"></div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            <br />
                <div class='container-fluid'>
                    <div class="row-fluid">
                        <div class="span5">
                            <fieldset >
                                <legend class="fieldsetText">使用者資料</legend>
                                <asp:HiddenField ID="hidden_Action" runat="server" />
                                <asp:HiddenField ID="hidden_ID" runat="server" />
                                <table>
                                    <tr>
                                        <td style="text-align: center">
                                            <table>
                                               
                                                <tr>
                                                    <td>
                                                        <font color="red">*</font>姓名：
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_UserName" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <font color="red">*</font>使用者代號：
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_User_ID" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        密碼：
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_Password" runat="server" TextMode="Password"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                                                    <td class="style1">
                                                        部門：</td>
                                                    <td class="style1">
                                                        <asp:DropDownList ID="ddl_department" AppendDataBoundItems="true" runat="server">
                                                            <asp:ListItem Value="-1">==請選擇==</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>--%>
                                                <tr>
                                                    <td>
                                                        電話：</td>
                                                    <td>
                                                        <asp:TextBox ID="txt_tel" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        電子信箱：</td>
                                                    <td>
                                                        <asp:TextBox ID="txt_email" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        狀態：
                                                    </td>
                                                    <td>
                                                        啟用<asp:CheckBox ID="chk_Status" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <asp:Button ID="cmd_Save" runat="server" Text="新增" Visible="False" CssClass="btn btn-primary"
                                                OnClick="cmd_Save_Click" />
                                            <asp:Button ID="cmd_Back" runat="server" Text="取消" CssClass="btn btn-primary" />
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </div>
                        <div class='span5'>
                            <fieldset >
                                <div class="row-fluid">
                                </div>
                                <legend class="fieldsetText">權限列表</legend>
                                <asp:GridView ID="gv" runat="server" AllowPaging="True" 
                                    AutoGenerateColumns="False" CellPadding="4" CellSpacing="1" 
                                    CssClass="table table-hover table-striped " GridLines="None" PageSize="12">
                                    <Columns>
                                        <asp:TemplateField HeaderText="選取">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="allow" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Role_ID" HeaderText="角色代號" />
                                        <asp:BoundField DataField="Role_Name" HeaderText="角色名稱" />
                                    </Columns>
                                    <FooterStyle Font-Bold="True" ForeColor="black" />
                                    <HeaderStyle Font-Bold="True" ForeColor="black" />
                                </asp:GridView>
                            </fieldset></div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
    </form>
</body>
</html>
