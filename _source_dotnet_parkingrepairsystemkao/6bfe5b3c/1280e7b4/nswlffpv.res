        ��  ��                  J@      �����e                 

    <script type="text/javascript">

        $(document).ready(function () {
            //$('#cmd_Save').bind("click", function() { return saveClick(); });
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
            location.href = "KindsOfEquipmentList.aspx";
            return false;
        }
    </script>


        <div class="container">
            <h3>設備種類維護</h3>

            <!--資料分隔請複製我，更改內文即可-->
            <div class="devide-line">
                <hr />
            </div>
            <!--end-->
            <div class="control-group">
                <label class="control-label">
                    設備種類編號</label>
                <div class="controls">
                    

    <script type="text/javascript">

        $(document).ready(function () {
            $('#cmd_Save').bind("click", function () { return saveClick(); });
            $('#cmd_Back').bind("click", function () { return backClick(); });
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
            location.href = "Project_QD.aspx";
            return false;
        }
    </script>


                <br />
                <div class='container'>
                    <fieldset>
                        <legend>管理設備零件</legend>
                        <div>
                            <table style="width: 100%;">
                                <tr>
                                    <td>&nbsp;零件名稱：
                                         
                                        &nbsp;</td>
                                    <td>&nbsp;
                                       
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                   
                                    </td>
                                    <td></td>
                                    <td>&nbsp;
                                        

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
            location.href = "RegionManage.aspx?act=add&id=0";
            return false;
        }
        //個人資料修改(應於menu)
        function privateadd() {
            location.href = "RegionManage.aspx?act=private&id=26";
            return false;
        }
        //修改
        function edit(val) {
            location.href = "RegionManage.aspx?act=edit&id=" + val;
            return false;
        }
        function del(val) {
            $.prompt('確定要刪除此筆資料?',
            { buttons: { 確定: true, 取消: false },
                submit: function(v, m, f) {
                    if (v) {
                        var Options = {
                            type: "POST",
                            url: "../MISWebService.asmx/DelRegion",
                            data: "{AreaID: '" + val + "'}",
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



    <script type="text/javascript" src="../javascript/system.js"></script>

    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>

    

    <script type="text/javascript">

        function pageLoad() {

        } 
        //$(document).ready(function () {
        //    $("#ddlst_SearchType").change(
        //    function () {
        //        var SearchType = $("#ddlst_SearchType").find(':selected').val();
        //        if (SearchType == 'ContractStartDate' || SearchType == 'ContractEndDate') {
        //            $('#SearchDate').css('display', 'inline');
        //            $('#txt_Query_Reason').css('display', 'none');
        //        }
        //        else {
                    
        //            $('#SearchDate').css('display', 'none');
        //            $('#txt_Query_Reason').css('display', 'inline');
        //        }
        //    }
        //);

        //});
        

        function addSearchIcon() {
            $('#cmd_Search').prepend("<i class=\"icon-search icon-white\"></i>");
        }

        function addMapIcon() {
            $('#mapView').prepend("<i class=\"icon-map-marker icon-white\"></i>");
        }

        function add() {
            location.href = "EquipmentDataManage.aspx?act=add&id=0";
            return false;
        }
        //修改
        function edit(val) {
            location.href = "EquipmentDataManage.aspx?act=edit&id=" + val;
            return false;
        }

        function AddMaterial(val) {
            location.href = "MatrialOfDevceManage.aspx?act=edit&DID=" + val;
            return false;
        }
        function map(val) {
            location.href = "mapViewer.aspx?type=Device&id=" + val;
            return false;
        }
        function del(val) {
            $.prompt('確定要刪除此筆資料?',
            { buttons: { 確定: true, 取消: false },
                submit: function(v, m, f) {
                    if (v) {
                        var Options = {
                            type: "POST",
                            url: "../MISWebService.asmx/DelEquipment",
                            data: "{device_id: '" + val + "'}",
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
            location.href = "EquipmentDataList.aspx";
            return false;
        }
    </script>
    <style type="text/css">
        b {
            color:red;
        }
    </style>

    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>
    <script type="text/javascript" src="../javascript/system.js"></script>
    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>
    

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



    <script type="text/javascript">

        function pageLoad() {
        }

        function addSearchIcon() {
            $('#cmd_Search').prepend("<i class=\"icon-search icon-white\"></i>");
        }

        function addCheckIcon() {
            $('#lnkbtn_Add').prepend("<i class=\"icon-calendar icon-white\"></i>");
        }

        function add() {
            location.href = "EquipmentDataManage.aspx?act=add&id=0";
            return false;
        }
        //修改
        function edit(val) {
            location.href = "EquipmentDataManage.aspx?act=edit&id=" + val;
            return false;
        }

        function AddMaterial(val) {
            location.href = "MatrialOfDevceManage.aspx?act=edit&DID=" + val;
            return false;
        }
        function map(val) {
            location.href = "mapViewer.aspx?type=Device&id=" + val;
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
                            url: "../MISWebService.asmx/DelEquipment",
                            data: "{device_id: '" + val + "'}",
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


                             <div class="progressBackgroundLayer">
                            </div>
                            <div class="fixedCenter">
                                <img src="../images/ajax-loader2.gif">
                            </div>
                        

    <script type="text/javascript">

        $(document).ready(function() {
            //To control calendar visible or not
            $('#Calendar_contractStartDate').addClass('hidden');
            $('#Calendar_contractEndDate').addClass('hidden');
            $('#txt_contractStartDate').click(function() {
                $('#Calendar_contractStartDate').removeClass('hidden');
            });
            $('#Calendar_contractStartDate').click(function() {
                $('#Calendar_contractStartDate').addClass('hidden');
            });
            $('#txt_contractEndDate').click(function() {
                $('#Calendar_contractEndDate').removeClass('hidden');
            });
            $('#Calendar_contractEndDate').click(function() {
                $('#Calendar_contractEndDate').addClass('hidden');
            });
            //
            $('#cmd_Save').bind("click", function() { return saveClick(); });
            $('#cmd_Back').bind("click", function() { return backClick(); });
        });

        function saveClick() {
            return true;
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
            location.href = "ContractList.aspx";
            return false;
        }
    </script>
    <style type="text/css">
        b {
            color:red;
        }
    </style>


    <div class="container">
        <h3>
            合約種類維護</h3>
        <!--資料分隔請複製我，更改內文即可-->
        <div class="devide-line">
            <p>
                合約資料</p>
            <hr />
        </div>
        <!--end-->
        <div class="control-group">
            <label class="control-label"><b >*</b>
                合約識別碼</label>
            <div class="controls">
                