        ��  ��                  �7      �����e                 

    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="../javascript/system.js"></script>

    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>

    <script language="javascript">
    <!--
    //只可輸入整數
    function TextBoxNumCheck_Int() {
        if (event.keyCode < 48 || window.event.keyCode > 57) event.returnValue = false;
    }
    // -->
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

        function add() {
            location.href = "InventoryAdd_A.aspx?act=add&id=0";
            return false;
        }
        //修改
        function edit(val) {
            location.href = "InventoryAdd_A.aspx?act=edit&id=" + val;
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
                            url: "../MISWebService.asmx/DelMaterial",
                            data: "{materialid: '" + val + "'}",
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
                                    __doPostBack('cmd_Search', '');
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
            location.href = "MaterialType_QD.aspx";
            return false;
        }
    </script>
     <style type="text/css">
        b {
            color:red;
        }
    </style>

    <div class="container">
        <h3>耗材種類資料維護</h3>
        
        <!--資料分隔請複製我，更改內文即可-->
        <div class="devide-line">
            <p>耗材種類資料</p>
            <hr />
        </div>
        <!--end-->        
         <div class="control-group">
         <label class="control-label">
                耗材編碼</label>
            <div class="controls">
                
                <div class='container'>
                    <br />
                    <fieldset>
                        <legend>出庫單</legend>
                        <div>
                            <table style="width: 100%;">
                                <tr>

                                    <td>&nbsp;工單編號:
                                    </td>
                                    <td>&nbsp;
                                        
                                        </td>
                                        <td></td>
                                        <td>&nbsp;
                                    
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;
                                        </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;出庫時間：
                                    </td>
                                    <td>&nbsp;
                                    
                                    </td>

                                </tr>

                            </table>
                        </div>
                        </legend>
                    </fieldset>
                </div>
                <br />
                <div class='container'>
                    <fieldset>
                        <legend>出庫物料</legend>
                        <div>
                            <table style="width: 100%;">
                                <tr>
                                    <td>&nbsp;物料名稱：
                                        &nbsp;</td>
                                    <td>&nbsp;
                                       
                                    </td>
                                    <td>&nbsp;領用數量:
                                    </td>
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
            location.href = "InventoryAdd_A.aspx?act=add&id=0";
            return false;
        }
        //修改
        function edit(val) {
            location.href = "InventoryReview_AM.aspx?act=edit&id=" + val;
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
                            url: "../MISWebService.asmx/DelMaterial",
                            data: "{materialid: '" + val + "'}",
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
                                    __doPostBack('cmd_Search', '');
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

        function add() {
            location.href = "StockIn_ADM.aspx?act=add&id=0";
            return false;
        }
        //修改
        function edit(val) {
            location.href = "StockIn_ADM.aspx?act=edit&id=" + val;
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


                    </div>
                    <div class='container-fluid'>
                        <div class="row-fluid">
                            <div class="span8">
                                <fieldset>
                                    
                                </fieldset>
                            </div>
                            <div class='span4'>
                                <fieldset>
                                    <div class="row-fluid">
                                    </div>
                                    

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
            location.href = "Inventoryadd_A.aspx";
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

    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>

    
                            <div class="progressBackgroundLayer">
                            </div>
                            <div class="fixedCenter">
                                <img src="../images/ajax-loader2.gif">
                            </div>
                        
                <div class='container'>
                    <br />
                    <fieldset>
                        <legend>入庫單管理</legend>
                        <div>
                            <table style="width: 100%;">
                                <tr>

                                    <td>&nbsp;物料名稱:
                                    </td>
                                    <td>&nbsp;
                                        

                                        </td>
                                </tr>
                                <tr>

                                    <td>&nbsp;存放位置：
                                    </td>
                                    <td>&nbsp;
                                    
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td>
                                        
                        </legend>
                    </fieldset>
                </div>
                <br />
                <div class='container'>
                    <fieldset>
                        <legend>計畫成本</legend>
                        <div>
                            <table style="width: 100%;">
                                <tr>
                                    <td>&nbsp;計畫編號：
                                    </td>
                                    <td>&nbsp;
                                        