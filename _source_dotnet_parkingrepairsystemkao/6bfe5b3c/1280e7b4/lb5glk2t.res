        ��  ��                  �      �����e                 

    <script type="text/javascript" src="javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="javascript/jquery-impromptu.2.8.min.js"></script>

    <script type="text/javascript" language="javascript">
        function checkquery() {
            var userid = document.getElementById('').value;
            if (userid == "" || pswd == "") {
                alert("使用者帳號及密碼不得為空白，請重新輸入");
                return false;
            }
            if (userid.match("'") != null) {
                alert("錯誤字元，請重新輸入");
                return false;
            }
        }



    </script>

<style type="text/css">

body {
	background-image: url(images/bg_01.jpg);
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
    background-repeat:repeat-x;
}
</style>
    
