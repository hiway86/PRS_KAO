        ��  ��                  '      �����e                 

    <script type="text/javascript">

        function addSearchIcon() {
            $('#cmd_Search').prepend("<i class=\"icon-search icon-white\"></i>");
        }

        function add() {
            location.href = "DoorSill_AM.aspx?act=add&id=0";
            return false;
        }
        //修改
        function edit(val) {
            location.href = "DoorSill_AM.aspx?act=edit&id=" + val;
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
                            url: "../MISWebService.asmx/DelCompany",
                            data: "{companyid: '" + val + "'}",
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


    <script type="text/javascript" src="../javascript/system.js"></script>
    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>
    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>

    
    
     <script type="text/javascript">

         function pageLoad() {;
         }
            
         var opt = {
             dateFormat: 'yy-mm-dd',
             showSecond: true,
             timeFormat: 'HH:mm:ss'
         };

         $(document).ready(function () {
             $('#txt_StartDate').datetimepicker(opt);
             $('#txt_EndDate').datetimepicker(opt);

             $("#ddlst_SearchType").change(
             function () {
                 var SearchType = $("#ddlst_SearchType").find(':selected').val();
                 if (SearchType == 'RecordTime' || SearchType == 'UpdateTime') {
                     $('#SearchDate').css('display', 'inline');
                     $('#txt_Query_Reason').css('display', 'none');
                 }
                 else {

                     $('#SearchDate').css('display', 'none');
                     $('#txt_Query_Reason').css('display', 'inline');
                 }
             }
         );

         });

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
             {
                 buttons: { 確定: true, 取消: false },
                 submit: function (v, m, f) {
                     if (v) {
                         var Options = {
                             type: "POST",
                             url: "../MISWebService.asmx/DelContract",
                             data: "{contractId: '" + val + "'}",
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

    <script type="text/javascript" src="../javascript/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="../javascript/jquery.dynDateTime.min.js"></script>
    <script type="text/javascript" src="../javascript/calendar-en.min.js"></script>
    

    <script type="text/javascript">

        function pageLoad() {

        }

        function validateInput() {
            var stardate = document.getElementById('txt_startDateTime').value;
            var enddate = document.getElementById('txt_endDateTime').value;
          
            if (stardate == undefined || stardate == "") {
                alert("請選擇VD通報起始時間");
                return false;
            }

            if (enddate == undefined || enddate == "") {
                alert("請選擇VD通報結束時間");
                return false;
            }
        }

        function addSearchIcon() {
            $('#lnkbtn_calStandard').prepend("<i class=\"icon-align-left icon-white\"></i>");
        }
        $(document).ready(function () {
            $("#").dynDateTime({
                showsTime: true,
                ifFormat: "%Y/%m/%d %H:%M",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });
        });

            $(document).ready(function () {
                $("#").dynDateTime({
                showsTime: true,
                ifFormat: "%Y/%m/%d %H:%M",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });
        });

        function add() {
            location.href = "StockOut_AM.aspx?act=add&id=0";
            return false;
        }
        //修改
        function edit(val) {
            location.href = "StockOut_AM.aspx?act=edit&id=" + val;
            return false;
        }

    </script>


                            <div class="progressBackgroundLayer">
                            </div>
                            <div class="fixedCenter">
                                <img src="../images/ajax-loader2.gif">
                            </div>
                        
    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>
    <script type="text/javascript" src="../javascript/system.js"></script>

    <script type="text/javascript" src="../javascript/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="../javascript/jquery.dynDateTime.min.js"></script>
    <script type="text/javascript" src="../javascript/calendar-en.min.js"></script>
    

    <script type="text/javascript">

        function pageLoad() {

        }

        function validateInput() {

        }

        function addSearchIcon() {
            $('#lnkbtn_calStandard').prepend("<i class=\"icon-align-left icon-white\"></i>");
        }


        function add() {
            location.href = "StockOut_AM.aspx?act=add&id=0";
            return false;
        }
        //修改
        function edit(val) {
            location.href = "StockOut_AM.aspx?act=edit&id=" + val;
            return false;
        }

    </script>



    <script type="text/javascript">

        $(document).ready(function () {
            $('#cmd_Save').bind("click", function () { return saveClick(); });
            $('#cmd_Back').bind("click", function () { return backClick(); });
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
            location.href = "DoorSill_Q.aspx";
            return false;
        }
    </script>

    <div class="container">
        <h3>門檻值維護</h3>
        <div class="devide-line">
            <hr />
        </div>
        <!--end-->        
         <div class="control-group">
             <label class="control-label">
                設備編號</label>
            <div class="controls">
                 