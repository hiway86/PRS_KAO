        ÿÿ  ÿÿ                  r      ÿÿ»ÿÿe                 

    <script type="text/javascript">
        function pageLoad() {
            setControlPermit();
        }

        function setControlPermit() {
            //è¨­å®æ¬é
            if (!pagePermit.enableBrowser) {
                $.prompt('æä½é¾æï¼è«éæ°ç»å¥',
            {
                buttons: { ç¢ºå®: true },
                submit: function (v, m, f) {
                    window.location = '../Index.aspx';
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
            if (!pagePermit.enableAdd) {
                $('#btn_Add').attr('disabled', 'disabled');
            }
            if (!pagePermit.enableEdit) {
                $("#gv :input[id$='cmd_Edit']").attr('disabled', 'disabled');
            }
            if (!pagePermit.enableDelete) {
                $("#gv :image[id$='cmd_Delete']").attr('disabled', 'disabled');
            }
        }

    </script>


            <div class='container'>
                <fieldset>
                    <legend>æ°å¢ç¶­ä¿®éå ±</legend>
                    <div>
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    &nbsp; è¨­åç·¨èï¼
                                </td>
                                <td>
                                   &nbsp;
                                    
                                </td>
                                <td>
                                    &nbsp;ä¿åºå» åï¼
                                </td>
                                <td>
                                    &nbsp;
                                    
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp; æéç¨®é¡ï¼
                                </td>
                                <td>
                                    &nbsp;
                                    
                                </td>
                                <td>
                                    &nbsp;æå®åç´ï¼
                                </td>
                                <td>
                                    &nbsp;
                                    
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp; æéæè¿°ï¼
                                </td>
                                <td rowspan="2">
                                    &nbsp;
                                    
                                </td>
                                <td>
                                    &nbsp;ä½µæ¡ç·¨èï¼
                                </td>
                                <td>
                                    &nbsp;
                                    
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;éç¥æ¥æï¼
                                </td>
                                <td>
                                    &nbsp;
                                    
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;éè¤éç¥èªªæï¼
                                </td>
                                <td rowspan="2">
                                    &nbsp;
                                    
                                </td>
                                <td>
                                    &nbsp;ä¿®å¾©æ¥æé¸é ï¼
                                </td>
                                <td>
                                    &nbsp;
                                    
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;æå®ä¿®å¾©æ¥æï¼
                                </td>
                                <td>
                                    &nbsp;
                                    
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;æå±¬è¨ç«ï¼
                                </td>
                                <td>
                                     &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                    
                                </td>
                            </tr>
                        </table>
                    </div>
                    </legend>
                </fieldset>
            </div>
            <br />
            <div class='container'>
                <br />
                <fieldset>
                    <legend>è¨­åæ­·å²éå ±ç´é</legend>
                    <div>
                       

    <script type="text/javascript">

        function jScript() {


            var opt = {
                dateFormat: 'yy-mm-dd',
                showSecond: true,
                timeFormat: 'HH:mm:ss'
            };

            $(document).ready(function () {
                $('#TextBox_RepairDeadline_add').datetimepicker(opt);
                $('#TextBox_NotifyDate_add').datetimepicker(opt);

                $('#DropDownList_RepairDateOption_add').change(function () {
                    $("#DropDownList_RepairDateOption_add option:selected").each(function () {
                        if ($(this).val() == '3') {
                            $('#TextBox_RepairDeadline_add').removeAttr('disabled');
                        }
                        else {
                            $('#TextBox_RepairDeadline_add').attr("disabled", "disabled");
                        }
                    });
                });


            });
        }

        function validateInput() {
            TextBox_FaultDescribe_add
            var devidid = document.getElementById('TextBox_DeviceID_add').value;
            var faultDescribe = document.getElementById('TextBox_FaultDescribe_add').value;
            var faultModel = document.getElementById('DropDownList_FaultModel_add')[0].selected;
            var Company = document.getElementById('DropDownList_WarrantyCompany_add')[0].selected;
            var NotifyDate = document.getElementById('TextBox_NotifyDate_add').value;
            var RepairDateOption = document.getElementById('DropDownList_RepairDateOption_add')[0].selected;
            if (devidid == undefined || devidid == "") {
                alert("è«è¼¸å¥è¨­åç·¨è");
                return false;
            }

            if (faultDescribe == undefined || faultDescribe == "") {
                alert("è«è¼¸å¥æéæè¿°");
                return false;
            }

            if (faultModel) {
                alert("è«é¸ææéç¨®é¡");
                return false;
            }

            if (Company) {
                alert("è«é¸æä¿åºå» å");
                return false;
            }

            if (NotifyDate == undefined || NotifyDate == "") {
                alert("è«è¼¸å¥éç¥æ¥æ");
                return false;
            }

            if (RepairDateOption) {
                alert("è«é¸æä¿®å¾©æ¥æé¸é ");
                return false;
            }

        }


    </script>
    <style type="text/css">
        b {
            color:red;
        }
    </style>

                        <div class="progressBackgroundLayer">
                        </div>
                        <div class="fixedCenter">
                            <img src="../images/ajax-loader2.gif">
                        </div>
                    
                <div class='container'>
                    <br />
                    <fieldset>
                        <legend>
                            <p class="text-info"><i class="icon-star"></i>éå ±è³ææ¥è©¢</p>
                        </legend>
                        <div>
                            <table style="width: 100%;">
                                <tr>
                                    <td>&nbsp;é¸æè¨­åç·¨èï¼
                                    </td>
                                    <td>&nbsp;
                                    
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    
                                    </td>
                                </tr>
                            </table>
                        </div>
                        
                
                <div class='container'>
                    <fieldset>
                        <legend>
                            <p class="text-info"><i class="icon-star"></i>éå ±è³ææ°å¢</p>
                        </legend>
                        <div>
                            <table style="width: 100%;">
                                <tr>
                                    <td>&nbsp;<b >*</b>è¨­åç·¨èï¼
                                    </td>
                                    <td>&nbsp;
                                    
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp; <b >*</b>æéç¨®é¡ï¼
                                    </td>
                                    <td>&nbsp;
                                    
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp; <b >*</b>æéæè¿°ï¼
                                    </td>
                                    <td rowspan="2">&nbsp;
                                        
                                                                      
                                    </td>
                                    <td>&nbsp;ä½µæ¡ç·¨èï¼
                                    </td>
                                    <td>&nbsp;
                                    
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;<b >*</b>éç¥æ¥æï¼
                                    </td>
                                    <td>&nbsp;
                                    
                                        
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;éè¤éç¥èªªæï¼
                                    </td>
                                    <td rowspan="2">&nbsp;
                                    
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;æå®ä¿®å¾©æ¥æï¼
                                    </td>
                                    <td>&nbsp;
                                    
                                        
                                        
                                        
                                    </td>
                                </tr>
                                <tr>
                                  
                                    <td>&nbsp;
                                        
                                    </td>
                                </tr>
                            </table>
                        </div>
                        </legend>
                    </fieldset>
                </div>
                <br />
            
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
            location.href = "ReportReturnManage.aspx?act=add&id=0";
            return false;
        }
        //ä¿®æ¹
        function edit(val) {
            location.href = "ReportReturnManage.aspx?act=edit&id=" + val;
            return false;
        }
        function del(val) {
            $.prompt('ç¢ºå®è¦åªé¤æ­¤ç­è³æ?',
            { buttons: { ç¢ºå®: true, åæ¶: false },
                submit: function(v, m, f) {
                    if (v) {
                        var Options = {
                            type: "POST",
                            url: "../MISWebService.asmx/DelEquipment",
                            data: "{deviceid: '" + val + "'}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            error: function(error) {
                                $.prompt('é¯èª¤');
                            },
                            timeout: function(error) {
                                $.prompt('é£ç·é¾æ');
                            },
                            success: function(response) {
                                if (response.d) {
                                    $.prompt('åªé¤æå');
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
        function pageLoad() {

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
                if (SearchType == 'NotifyDate' || SearchType == 'RepairDeadline') {
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

        function addMapIcon() {
            $('#mapView').prepend("<i class=\"icon-map-marker icon-white\"></i>");
        }

        function add() {
            location.href = "ReportReturnManage.aspx?act=add&id=0";
            return false;
        }
        //ä¿®æ¹
        function edit(val) {
            location.href = "ReportReturnManage.aspx?act=edit&id=" + val;
            return false;
        }

        //ç¶­ä¿®åå ±
        function ReturnList(val) {
            location.href = "ReportReturnManage.aspx?act=edit&id=" + val;
            return false;
        }
        function del(val) {
            $.prompt('ç¢ºå®è¦åªé¤æ­¤ç­è³æ?',
            { buttons: { ç¢ºå®: true, åæ¶: false },
                submit: function(v, m, f) {
                    if (v) {
                        var Options = {
                            type: "POST",
                            url: "../MISWebService.asmx/DelWarrantyNotify",
                            data: "{caseid: '" + val + "'}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            error: function(error) {
                                $.prompt('é¯èª¤');
                            },
                            timeout: function(error) {
                                $.prompt('é£ç·é¾æ');
                            },
                            success: function(response) {
                                if (response.d) {
                                    $.prompt('åªé¤æå');
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

    
    <style>
        span.radio
        {
            padding: 0px;
        }
        span.radio > input[type="radio"]
        {
            margin: 8px 0px 7px 0px;
        }
        span.radio > label
        {
        	margin: 5px 0px 7px 0px;
            float: left;
            margin-right: 5px;
            padding: 0px 5px 0px 10px;
        }
    </style>
    
    <script type="text/javascript">
        function pageLoad() {
            setControlPermit();
        }

        function setControlPermit() {
            //è¨­å®æ¬é
            if (!pagePermit.enableBrowser) {
                $.prompt('æä½é¾æï¼è«éæ°ç»å¥',
            {
                buttons: { ç¢ºå®: true },
                submit: function(v, m, f) {
                    window.location = '../Index.aspx';
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
            if (!pagePermit.enableAdd) {
                $('#btn_Add').attr('disabled', 'disabled');
            }
            if (!pagePermit.enableEdit) {
                $("#gv :input[id$='cmd_Edit']").attr('disabled', 'disabled');
            }
            if (!pagePermit.enableDelete) {
                $("#gv :image[id$='cmd_Delete']").attr('disabled', 'disabled');
            }
        }     

    </script>

    

                <div class='container'>
                    <br />
                    <fieldset>
                        <legend><p class="text-info"><i class="icon-star"></i>ä¿åºéç¥ä½æ¥­</p></legend>
                        <div>
                            <div class="row-fluid">
                                <div class="span2">
                                    
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        &nbsp; æ¡ä»¶ç·¨èï¼
                                    </td>
                                    <td>
                                        &nbsp;
                                        
                                    </td>
                                    <td>
                                        &nbsp; è¨­åç·¨èï¼
                                    </td>
                                    <td>
                                        &nbsp;
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp; éç¥ç¢ºèªï¼
                                    </td>
                                    <td>
                                        &nbsp;
                                        
                                    </td>
                                    <td>
                                        &nbsp; ç¢ºèªçªå£ï¼
                                    </td>
                                    <td>
                                        &nbsp;
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp; é»è©±ç¢ºèªæéï¼
                                    </td>
                                    <td>
                                        &nbsp;
                                        
                                    </td>
                                    <td>
                                        &nbsp; Faxç¢ºèªæéï¼
                                    </td>
                                    <td>
                                        &nbsp;
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp; Emailç¢ºèªæéï¼
                                    </td>
                                    <td>
                                        &nbsp;
                                        
                                    </td>
                                    <td>
                                        &nbsp; å³æå¬è¾¦æéï¼
                                    </td>
                                    <td>
                                        &nbsp;
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                        
                                    </td>
                                </tr>
                            </table>
                        </div>
                        </legend>
                    </fieldset>
                </div>
            

    <script type="text/javascript">

        var opt = {
            dateFormat: 'yy-mm-dd',
            showSecond: true,
            timeFormat: 'HH:mm:ss'
        };

        $(document).ready(function () {
            //$('#cmd_Save').bind("click", function () { return saveClick(); });
            $('#cmd_Back').bind("click", function () { return backClick(); });
            $('#txt_repairDate').datetimepicker(opt);
        });

        function saveClick() {
            alert("æ°å¢æå");
            location.href = "RepairMaintainList.aspx";
            return false;
        }

        function backClick() {
            location.href = "RepairMaintainList.aspx";
            return false;
        }

    </script>
    <style type="text/css">
        b {
            color:red;
        }
    </style>

                <div class="container">
                    <div class="control-group">
                        <label class="control-label">
                            èæç¨®é¡</label>
                        <div class="controls">
                            
    <script type="text/javascript" src="../javascript/system.js"></script>
    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>

    
    

    <script type="text/javascript">

        function pageLoad() {
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
                if (SearchType == 'NotifyDate' || SearchType == 'RepairDeadline' || SearchType == 'RepairDate') {
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
            location.href = "ReportReturnManage.aspx?act=add&id=0";
            return false;
        }
        //ä¿®æ¹
        function edit(val) {
            location.href = "ReportReturnManage.aspx?act=edit&id=" + val;
            return false;
        }
        function del(val) {
            $.prompt('ç¢ºå®è¦åªé¤æ­¤ç­è³æ?',
            {
                buttons: { ç¢ºå®: true, åæ¶: false },
                submit: function (v, m, f) {
                    if (v) {
                        var Options = {
                            type: "POST",
                            url: "../MISWebService.asmx/DelEquipment",
                            data: "{deviceid: '" + val + "'}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            error: function (error) {
                                $.prompt('é¯èª¤');
                            },
                            timeout: function (error) {
                                $.prompt('é£ç·é¾æ');
                            },
                            success: function (response) {
                                if (response.d) {
                                    $.prompt('åªé¤æå');
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


                            <div class="progressBackgroundLayer">
                            </div>
                            <div class="fixedCenter">
                                <img src="../images/ajax-loader2.gif">
                            </div>
                        