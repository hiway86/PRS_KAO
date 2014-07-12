// JavaScript File
function login() 
{
    alert("aa");
    open_newwindow("Index.aspx");

    if(navigator.appName=='Microsoft Internet Explorer')
    {
        this.focus();
        self.opener = this;
        self.close();
    }
    else 
    {
        window.open('','_parent','');
        window.close();
    } 
}

function open_new_window(url)
    {
        var newwindow;

        newwindow=window.open(url,'name2',"height=740,width=1020,status=1,menubar=yes,scrollbars=no,location=no");
        if (window.focus) {newwindow.focus()}
    }


function open_newwindow(url)
{
    var newwindow;
    var window_height = screen.availHeight;
    var window_width = screen.availWidth;

    newwindow=window.open(url,'name',"height=" + window_height + ",width=" + window_width  + ",status=0,menubar=no,scrollbars=no,location=no");
    if (window.focus) {newwindow.focus()}
}

function open_newmainwindow(url)
{
    var newwindow;
    var window_height = screen.availHeight;
    var window_width = screen.availWidth;

    newwindow=window.open(url,url.substr(2,url.lastIndexOf("/")-2),"height=" + window_height + ",width=" + window_width  + ",status=0,menubar=no,scrollbars=no,location=no");
    if (window.focus) {newwindow.focus()}
}

function open_newdialog(url,dlwidth,dllength)
{
    var mDialog;
    mDialog = window.showModelessDialog(url,window,"scroll:no;status:no;dialogWidth:" + dlwidth + "px; dialogHeight:" + dllength  + "px; help:No;");
}

//停止非同步之讀取（如果讀取資料過大）
function stopAsyncPostBack()
{
    if(Sys.WebForms.PageRequestManager.getInstance().get_isInAsyncPostBack())
    {
       Sys.WebForms.PageRequestManager.getInstance().abortPostBack();
    }
}



//調整開啟之視窗大小與iframe大小
function selfResize()
{
    self.resizeTo(screen.availWidth,screen.availHeight);
    moveTo(0,0);
    var iframeobj = document.getElementById("bodyframe");
    iframeobj.style.height = (screen.availHeight-41) + 'px';
}

/* 57918
* 2010/1/22
* 常用js方法
*/
function getNowTime() {
    timeStr=date2str(new Date());
    return timeStr;
}
//計算n小時後
function addHours(hourvalue,nowtime) {
    HoursToAdd=hourvalue;
    var newdate=new Date();
    if(nowtime){
        newdate=nowtime
    }
    var newtimems=newdate.getTime()+(HoursToAdd*60*60*1000);
    newdate.setTime(newtimems);
    return newdate;
}
//計算n天後
function addDays(dayvalue,nowtime) {
    DayToAdd=dayvalue;
    var newdate=new Date();
    if(nowtime){
        newdate=nowtime
    }
    var newtimems=newdate.getTime()+(DayToAdd*24*60*60*1000);
    newdate.setTime(newtimems);
    return newdate;
}
/**
 * 轉js的date至指定格式
 * format Date 格式：yyyy/MM/dd HH:mm:ss;
 */
function date2str(dt) {
    var delimiter="/";
    if(dt instanceof Date){
        return fill0(dt.getFullYear(),4)+delimiter+fill0(dt.getMonth()+1,2)+delimiter+fill0(dt.getDate(),2)+" "+fill0(dt.getHours(),2)+":"+fill0(dt.getMinutes(),2)+":"+fill0(dt.getSeconds(),2);
    }else{
        alert("時間格式錯誤-"+dt);
        return dt;
    }
}
/*
 * 轉字串至js的date物件
 */
function str2date(str) {
    return new Date(str);
}
/**
 * fill zero
 */
function fill0(str,length) {
    str=new String(str);
    while(str.length<length){
        str="0"+str;
    }
    return str;
}
//取得mouse位置
//呼叫時 ev = ev || window.event;
function mouseMove(objName){
    ev = ev || window.event;
    var mousePos = mouseCoords(ev);
    document.getElementById(objName).style.left = mousePos.x;
    document.getElementById(objName).style.top = mousePos.y;
}

/* 57918
* 2010/1/22
* 常用js驗證欄位
*/

//檢查欄位格式
//檢查日期
function y2k(number){
    return (number<1000) ? number+1900 : number;
}
//check是否存在
function checkDateExist(day, month, year){
    var today=new Date();
    year=((!year) ? y2k(today.getYear()):year);
    month=((!month) ? today.getMonth():month-1);

    if(!day){
        return false;
    }
    var test=new Date(year,month,day);
    if((y2k(test.getYear()) == year) && (month == test.getMonth()) && (day == test.getDate())){
        return true;
    }else{
        return false;
    }
}
//check日期格式[ yyyy/MM/dd ]
function checkDate(dates){
    var datePattern=/^\d{4}\/(0[1-9]|1[0-2])\/(3[0-1]|[0-2][0-9])$/;
    if(dates.match(datePattern)){
        if(checkDateExist(dates.substring(8, 10), dates.substring(5, 7), dates.substring(0, 4))==true){
            alert("輸入日期正確！");
        }else{
            alert("輸入日期不存在");
        }
    }else{
        alert("日期格式錯誤!\n請依照下列格式輸入日期：\n\n[ yyyy/MM/dd ]");
    }
}
//檢查from time & to time 合理性
function checkTimeLogic(Stime,Etime) {    
    if(Date.parse (Stime)>=Date.parse(Etime)){
        return false;
    }else{
        return true;
    }
}


//驗證email
function checkEmail(string) {
    re = /^.+@.+\..{2,3}$/;
    if (re.test(string)){
        return true; 
     }else{
        return false;
    }
}
 
//驗證數字
function checkNumber(string) {
    re = /^\d+$/;
    if (re.test(string)){
        return true;
    }else{
        return false;
    }
}
//驗證身份證
function checkID(string) {
    var re = /^[A-Z]\d{9}$/;
    if (!re.test(string)){
        return true;
    }else{
        return false;
    }
}

//欄位驗證
//檢查電話(手機)
function isMobileTel(str){
    var reg=/^\d+$/;
    if(str.length!=10){
        return false;
    }else{
        return reg.test(str);
    }
}
//檢查電話(市話、辦公室市話+#分機)
//格式：0255551111;0255551111#1234
function isOfficeTel(str){
    var reg=/^\d+$/;
    if(str.indexOf("#")<0){
        if(str.length!=10){
            return false;
        }else{
            return reg.test(str);
        }
    }else{
        if(str.split("#")[0].length==10 && reg.test(str.split("#")[0])==true && reg.test(str.split("#")[1])==true){
            return true;
        }else{
            return false;
        }
    }
}
//去左右空白
function trim(stringToTrim){
    return stringToTrim.replace(/^\s+|\s+$/g,"");
}


/**
*
*  Secure Hash Algorithm (SHA1)
*  SHA1加密並處理編碼問題
*
**/

function SHA1(msg) {

    function rotate_left(n, s) {
        var t4 = (n << s) | (n >>> (32 - s));
        return t4;
    };

    function lsb_hex(val) {
        var str = "";
        var i;
        var vh;
        var vl;

        for (i = 0; i <= 6; i += 2) {
            vh = (val >>> (i * 4 + 4)) & 0x0f;
            vl = (val >>> (i * 4)) & 0x0f;
            str += vh.toString(16) + vl.toString(16);
        }
        return str;
    };

    function cvt_hex(val) {
        var str = "";
        var i;
        var v;

        for (i = 7; i >= 0; i--) {
            v = (val >>> (i * 4)) & 0x0f;
            str += v.toString(16);
        }
        return str;
    };


    function Utf8Encode(string) {
        string = string.replace(/\r\n/g, "\n");
        var utftext = "";

        for (var n = 0; n < string.length; n++) {

            var c = string.charCodeAt(n);

            if (c < 128) {
                utftext += String.fromCharCode(c);
            }
            else if ((c > 127) && (c < 2048)) {
                utftext += String.fromCharCode((c >> 6) | 192);
                utftext += String.fromCharCode((c & 63) | 128);
            }
            else {
                utftext += String.fromCharCode((c >> 12) | 224);
                utftext += String.fromCharCode(((c >> 6) & 63) | 128);
                utftext += String.fromCharCode((c & 63) | 128);
            }

        }

        return utftext;
    };

    var blockstart;
    var i, j;
    var W = new Array(80);
    var H0 = 0x67452301;
    var H1 = 0xEFCDAB89;
    var H2 = 0x98BADCFE;
    var H3 = 0x10325476;
    var H4 = 0xC3D2E1F0;
    var A, B, C, D, E;
    var temp;

    msg = escape(msg);

    var msg_len = msg.length;

    var word_array = new Array();
    for (i = 0; i < msg_len - 3; i += 4) {
        j = msg.charCodeAt(i) << 24 | msg.charCodeAt(i + 1) << 16 |
        msg.charCodeAt(i + 2) << 8 | msg.charCodeAt(i + 3);
        word_array.push(j);
    }

    switch (msg_len % 4) {
        case 0:
            i = 0x080000000;
            break;
        case 1:
            i = msg.charCodeAt(msg_len - 1) << 24 | 0x0800000;
            break;

        case 2:
            i = msg.charCodeAt(msg_len - 2) << 24 | msg.charCodeAt(msg_len - 1) << 16 | 0x08000;
            break;

        case 3:
            i = msg.charCodeAt(msg_len - 3) << 24 | msg.charCodeAt(msg_len - 2) << 16 | msg.charCodeAt(msg_len - 1) << 8 | 0x80;
            break;
    }

    word_array.push(i);

    while ((word_array.length % 16) != 14) word_array.push(0);

    word_array.push(msg_len >>> 29);
    word_array.push((msg_len << 3) & 0x0ffffffff);


    for (blockstart = 0; blockstart < word_array.length; blockstart += 16) {

        for (i = 0; i < 16; i++) W[i] = word_array[blockstart + i];
        for (i = 16; i <= 79; i++) W[i] = rotate_left(W[i - 3] ^ W[i - 8] ^ W[i - 14] ^ W[i - 16], 1);

        A = H0;
        B = H1;
        C = H2;
        D = H3;
        E = H4;

        for (i = 0; i <= 19; i++) {
            temp = (rotate_left(A, 5) + ((B & C) | (~B & D)) + E + W[i] + 0x5A827999) & 0x0ffffffff;
            E = D;
            D = C;
            C = rotate_left(B, 30);
            B = A;
            A = temp;
        }

        for (i = 20; i <= 39; i++) {
            temp = (rotate_left(A, 5) + (B ^ C ^ D) + E + W[i] + 0x6ED9EBA1) & 0x0ffffffff;
            E = D;
            D = C;
            C = rotate_left(B, 30);
            B = A;
            A = temp;
        }

        for (i = 40; i <= 59; i++) {
            temp = (rotate_left(A, 5) + ((B & C) | (B & D) | (C & D)) + E + W[i] + 0x8F1BBCDC) & 0x0ffffffff;
            E = D;
            D = C;
            C = rotate_left(B, 30);
            B = A;
            A = temp;
        }

        for (i = 60; i <= 79; i++) {
            temp = (rotate_left(A, 5) + (B ^ C ^ D) + E + W[i] + 0xCA62C1D6) & 0x0ffffffff;
            E = D;
            D = C;
            C = rotate_left(B, 30);
            B = A;
            A = temp;
        }

        H0 = (H0 + A) & 0x0ffffffff;
        H1 = (H1 + B) & 0x0ffffffff;
        H2 = (H2 + C) & 0x0ffffffff;
        H3 = (H3 + D) & 0x0ffffffff;
        H4 = (H4 + E) & 0x0ffffffff;

    }

    var temp = cvt_hex(H0) + cvt_hex(H1) + cvt_hex(H2) + cvt_hex(H3) + cvt_hex(H4);

    return temp.toLowerCase();

}