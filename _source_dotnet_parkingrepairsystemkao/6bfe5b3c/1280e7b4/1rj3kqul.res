        ��  ��                        �����e                 

    <script type="text/javascript" src="javascript/jquery-1.3.2.js"></script>
    <script type="text/javascript" src="javascript/system.js"></script>
    <script type="text/javascript" src="javascript/jquery-impromptu.2.8.min.js"></script>
    <script type="text/javascript" language="javascript">
        function checkquery() {

            var newpw = document.getElementById('').value;



            if (newpw == "") {
                alert("新密碼不得為空白，請重新輸入");
                return false;
            }

            if (newpwcheck == "") {
                alert("確認新密碼不得為空白，請重新輸入");
                return false;
            }

            if (newpw != newpwcheck) {
                alert("新密碼需與確認新密碼相同，請調整");
                return false;
            }

            if (newpw.match("'") != null || newpwcheck.match("'") != null) {
                alert("錯誤字元，請重新輸入");
                return false;
            }

            if (document.getElementById('

    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="../javascript/authority.js"></script>

    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>

    <script type="text/javascript">

        function pageLoad() {
            addSearchIcon();
        }

        function addSearchIcon() {
            $('#cmd_Search').prepend("<i class=\"icon-search icon-white\"></i>");
        }

        function add() {
            location.href = "RoleManage.aspx?act=add";
            return false;
        }

        //修改
        function edit(val) {
            location.href = "RoleManage.aspx?act=edit&id=" + val;
            return false;
        }

        function del(val) {
            $.prompt('確定要刪除此筆資料?',
            { buttons: { 確定: true, 取消: false },
                submit: function(v, m, f) {
                    if (v) {
                        var Options = {
                            type: "POST",
                            url: "../MISWebService.asmx/DelRole",
                            data: "{roleid: '" + val + "'}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            error: function(error) {
                                $.prompt('錯誤');
                            },
                            timeout: function(error) {
                                $.prompt('連線逾時');
                            },
                            success: function(response) {
                                if (response.d) {
                                    $.prompt('刪除成功');
                                    __doPostBack('lnkbtn_Search', '');
                                }
                            }
                        };
                        $.ajax(Options);
                    }
                }
            });
        }

    </script>



    <script type="text/javascript">

        $(document).ready(function() {
            $('#cmd_Save').bind("click", function() { return saveClick(); });
            $('#cmd_Back').bind("click", function() { return backClick(); });
        });

        function saveClick() {

        }

        function backClick() {
            location.href = "RoleList.aspx";
            return false;
        }
    </script>
     <style type="text/css">
        b {
            color:red;
        }
    </style>

    <div class="container">
        <h3>系統角色維護</h3>
        
        <!--資料分隔請複製我，更改內文即可-->
        <div class="devide-line">
            <p>角色資料</p>
            <hr />
        </div>
        <!--end-->        
         <div class="control-group">
         <label class="control-label"><b >*</b>
                角色代號</label>
            <div class="controls">
                

    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>
    <script type="text/javascript" src="../javascript/authority.js"></script>
    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>
    <script type="text/javascript" src="../Authority.aspx?p=RoleProgramManage.aspx"></script>
    

    

    <script type="text/javascript">

        function addSearchIcon() {
            $('#cmd_Search').prepend("<i class=\"icon-search icon-white\"></i>");
        }

        function add() {
            location.href = "CompanyManage.aspx?act=add&id=0";
            return false;
        }
        //修改
        function edit(val) {
            location.href = "CompanyManage.aspx?act=edit&id=" + val;
            return false;
        }
        function del(val) {
            $.prompt('確定要刪除此筆資料?',
            { buttons: { 確定: true, 取消: false },
                submit: function(v, m, f) {
                    if (v) {
                        var Options = {
                            type: "POST",
                            url: "../MISWebService.asmx/DelCompany",
                            data: "{companyid: '" + val + "'}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            error: function(error) {
                                $.prompt('錯誤');
                            },
                            timeout: function(error) {
                                $.prompt('連線逾時');
                            },
                            success: function(response) {
                                if (response.d) {
                                    $.prompt('刪除成功');
                                    __doPostBack('lnkbtn_Search', '');
                                }
                            }
                        };
                        $.ajax(Options);
                    }
                }
            });
        }

      
    </script>



    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="../javascript/authority.js"></script>

    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>

   

    <script type="text/javascript">

       

        function add() {
            location.href = "AuthManage.aspx?act=add";
            return false;
        }

        //修改
        function edit(val) {
            location.href = "AuthManage.aspx?act=edit&id=" + val;
            return false;
        }

    </script>

