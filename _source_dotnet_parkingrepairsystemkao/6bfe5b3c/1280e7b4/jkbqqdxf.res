        ��  ��                  '      �����e                 
    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>
    <script type="text/javascript" src="../javascript/system.js"></script>
    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>

    

    <script type="text/javascript">

        function pageLoad() {
      
        }

        function addSearchIcon() {
            $('#cmd_Search').prepend("<i class=\"icon-search icon-white\"></i>");
        }

        function add() {
            location.href = "Project_AM.aspx?act=add&id=0";
            return false;
        }
        //修改
        function edit(val) {
            location.href = "Project_AM.aspx?act=edit&id=" + val;
            return false;
        }
        function del(val) {
            $.prompt('確定要刪除此筆資料?',
            {
                buttons: { 確定: true, 取消: false },
                submit: function (v, m, f) {
                    if (v) {
                        var Options = {
                            type: "POST",
                            url: "../MISWebService.asmx/DelProject",
                            data: "{projectno: '" + val + "'}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            error: function (error) {
                                $.prompt('錯誤');
                            },
                            timeout: function (error) {
                                $.prompt('連線逾時');
                            },
                            success: function (response) {
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

    <script type="text/javascript" src="../javascript/system.js"></script>

    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>

    

    <script type="text/javascript">

        function pageLoad() {
          
        }

        function addSearchIcon() {
            $('#cmd_Search').prepend("<i class=\"icon-search icon-white\"></i>");
        }

        function url() {
            location.href = "ReInventory_D.aspx";
            return false;
        }

    </script>


                            <div class="progressBackgroundLayer">
                            </div>
                            <div class="fixedCenter">
                                <img src="../images/ajax-loader2.gif">
                            </div>
                        
    <script type="text/javascript" src="../javascript/system.js"></script>
    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>
    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>
    
    
     <script type="text/javascript">


         function pageLoad() {
         }

         function addSearchIcon() {
             $('#cmd_Search').prepend("<i class=\"icon-search icon-white\"></i>");
         }


        function add() {
            location.href = "KindsOfEquipmentManage.aspx?act=add&id=0";
            return false;
        }
        //個人資料修改(應於menu)
        function privateadd() {
            location.href = "KindsOfEquipmentManage.aspx?act=private&id=26";
            return false;
        }
        //修改
        function edit(val) {
            location.href = "KindsOfEquipmentManage.aspx?act=edit&id=" + val;
            return false;
        }
        function kindphoto(val) {
            location.href = "DeviceKindPhoto.aspx?id=" + val;
            return false;
        }
        function del(val) {
            $.prompt('確定要刪除此筆資料?',
            { buttons: { 確定: true, 取消: false },
                submit: function(v, m, f) {
                    if (v) {
                        var Options = {
                            type: "POST",
                            url: "../MISWebService.asmx/DelDevieKind",
                            data: "{DevieKindid: '" + val + "'}",
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

//            if ($('#txt_Company_ID').val().trim().length == 0) {//判斷是否有輸入資料
//                alert('請輸入客運業者代碼');
//                return false;
//            }
//            if ($('#txt_Company_Name').val().trim().length == 0) {
//                alert('請輸入客運業者名稱');
//                return false;
//            }
        }

        function backClick() {
            location.href = "CompanyList.aspx";
            return false;
        }
    </script>
     <style type="text/css">
        b {
            color:red;
        }
    </style>



    <script type="text/javascript">

        $(document).ready(function() {
            $('#cmd_Save').bind("click", function() { return saveClick(); });
            $('#cmd_Back').bind("click", function() { return backClick(); });
        });

        function saveClick() {
/*
            if ($('#txt_Company_ID').val().trim().length == 0) {//判斷是否有輸入資料
                alert('請輸入客運業者代碼');
                return false;
            }
            if ($('#txt_Company_Name').val().trim().length == 0) {
                alert('請輸入客運業者名稱');
                return false;
            }
*/
        }

        function backClick() {
            location.href = "RegionList.aspx";
            return false;
        }
    </script>
     <style type="text/css">
        b {
            color:red;
        }
    </style>

    <div class="container">
        <h3>地區資料維護</h3>
        
        <!--資料分隔請複製我，更改內文即可-->
        <div class="devide-line">
            <p>地區資料</p>
            <hr />
        </div>
        <!--end-->        
         <div class="control-group">
         <label class="control-label">
                地區編碼</label>
            <div class="controls">
                
    <script type="text/javascript" src="../javascript/system.js"></script>
    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>
    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>
    
    
     <script type="text/javascript">

         function pageLoad() {;
         }

         function addSearchIcon() {
             $('#cmd_Search').prepend("<i class=\"icon-search icon-white\"></i>");
         }

        function add() {
            location.href = "ContractManage.aspx?act=add&id=0";
            return false;
        }
        //個人資料修改(應於menu)
        function privateadd() {
            location.href = "ContractManage.aspx?act=private&id=26";
            return false;
        }
        //修改
        function edit(val) {
            location.href = "ContractManage.aspx?act=edit&id=" + val;
            return false;
        }
        function del(val) {
            $.prompt('確定要刪除此筆資料?',
            { buttons: { 確定: true, 取消: false },
                submit: function(v, m, f) {
                    if (v) {
                        var Options = {
                            type: "POST",
                            url: "../MISWebService.asmx/DelContract",
                            data: "{contractId: '" + val + "'}",
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
