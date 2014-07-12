//developer : 55329
//last modify time : 2009/01/11
//本檔案禁止修改，有修改需求請聯絡負責人：楊峻武

var webDir="/ERMS";  //本變數應等於"/ProjectName"或是空字串(放在ROOT下的話)

var mapObj;
var mapID;
var markerClickFunc;
var mapClickFunc;
var clickListener;

var markerRightClickFunc;
var mapRightClickFunc;
var rightClickListener;

//markerImg順序查看MarkerType「enum MarkerType」 V,S,X,C,F,W,Activity,Event,POI;
var markerImg=new Array('vd.gif','sing.gif','cms.gif','cctv.gif','fog.gif','water.gif','activity.gif','warning.gif','','truck_online.gif','truck_offline.gif','maintain_1.gif','maintain_2.gif','maintain_3.gif');
var iconManager=new Object();
var mapRange;  //檢查可視範圍用
//static int firstForNewdevices=0;
function setupMap(divMap,clat,clng,level,minlevel,maxlevel,swlat,swlng,nelat,nelng){
    if(level==undefined) level=13;
    if(minlevel==undefined) minlevel=8;
    if(maxlevel==undefined) maxlevel=19;

    if (GBrowserIsCompatible()) {
        mapID=divMap;
        mapObj = new GMap2(document.getElementById(divMap));
        mapObj.addControl(new GLargeMapControl());
        mapObj.setCenter(new GLatLng(clat, clng), level);
        //map的樣式
        mapObj.setMapType(G_NORMAL_MAP);
        //增加控制元件
        mapObj.addControl(new GOverviewMapControl()); //縮圖
        mapObj.addControl(new GLargeMapControl()); //方向
        mapObj.addControl(new GMapTypeControl()); //map樣式控制
        mapObj.disableDoubleClickZoom();
        mapObj.enableScrollWheelZoom();
        //限制縮放等級
        setZoomLevel(minlevel,maxlevel);
        //增加drag事件 限制地圖可見範圍
        if(swlat){
            mapRange=new GLatLngBounds(new GLatLng(swlat, swlng),new GLatLng(nelat, nelng));
            GEvent.addListener(mapObj,"dragend",function(){
                checkBounds(mapRange,clat,clng);
            });
        }
    }
    /**指定 map之singlerightclick 事件及
    /*增加 marker之singlerightclick事件
     */
    GEvent.addListener(mapObj,"singlerightclick", function(pixel,src,overlay) {
        if (overlay) {
            if (overlay instanceof GMarker) {
                GEvent.trigger(overlay,"SingleRightClick");
            }
        }
    });
    return mapObj;
}

function addKML(url){
    var kml=new GGeoXml(url);
    mapObj.addOverlay(kml);
    GEvent.addListener(kml,"load",function(){
        if(kml.loadedCorrectly()) {
            alert("download success!!");
        }
    });
}

function existClickFunc(){
    if(markerClickFunc==undefined && mapClickFunc==undefined){
        return false;
    }else{
        return true;
    }
}

function enableMarkerClick(callback){
    if(!existClickFunc()){
        clickListener=GEvent.addListener(mapObj, "click", fireClick);
    }
    markerClickFunc=callback;
}

function enableMapClick(callback){
    if(!existClickFunc()){
        clickListener=GEvent.addListener(mapObj, "click", fireClick);
    }
    mapClickFunc=callback;
}

function fireClick(overlay, latlng){
    if(overlay instanceof GMarker && markerClickFunc!=undefined){
        markerClickFunc(overlay, latlng);
    }
    if(overlay==null && mapClickFunc!=undefined){
        mapClickFunc(overlay, latlng);
    }
}

function disableMarkerClick(){
    markerClickFunc=undefined;
    if(!existClickFunc()){
        GEvent.removeListener(clickListener);
    }
}

function disableMapClick(){
    mapClickFunc=undefined;
    if(!existClickFunc()){
        GEvent.removeListener(clickListener);
    }
}

function existRightClickFunc(){
    if(markerRightClickFunc==undefined && mapRightClickFunc==undefined){
        return false;
    }else{
        return true;
    }
}

function enableMarkerRightClick(callback){
    if(!existRightClickFunc()){
        rightClickListener=GEvent.addListener(mapObj, "singlerightclick", fireRightClick);
    }
    markerRightClickFunc=callback;
}

function enableMapRightClick(callback){
    if(!existRightClickFunc()){
        rightClickListener=GEvent.addListener(mapObj, "singlerightclick", fireRightClick);
    }
    mapRightClickFunc=callback;
}

function fireRightClick(point,src,overlay){
    if(overlay instanceof GMarker && markerRightClickFunc!=undefined){
        markerRightClickFunc(point,src,overlay);
    }
    if(overlay.id==mapID && mapRightClickFunc!=undefined){
        mapRightClickFunc(point,src,mapObj);
    }
}

function disableMarkerRightClick(){
    markerRightClickFunc=undefined;
    if(!existRightClickFunc()){
        GEvent.removeListener(rightClickListener);
    }
}

function disableMapRightClick(){
    mapRightClickFunc=undefined;
    if(!existRightClickFunc()){
        GEvent.removeListener(rightClickListener);
    }
}

function selectMarker(kmlString){
    window.kmlSrc=location.hostname;
    window.kmlString=kmlString;
    var selectedItem=showModalDialog("//"+location.host+webDir+"/ceci_gm/select_point.jsp","scroll:no;status:no;dialogWidth:700px; dialogHeight:700px; help:No;");
    return selectedItem;
}
/**
 * 開啟select_point.jsp 點選座標資訊
 * 傳入座標參數時可顯示位置
 **/
function selectPoint(centerPoint){
    var point;
    if(centerPoint==undefined){
        point=showModalDialog("//"+location.host+webDir+"/ceci_gm/select_point.jsp","scroll:no;status:no;dialogWidth:700px; dialogHeight:700px; help:No;");
    }else{
        point=showModalDialog("//"+location.host+webDir+"/ceci_gm/select_point.jsp?cx="+centerPoint.x+"&cy="+centerPoint.y,"scroll:no;status:no;dialogWidth:700px; dialogHeight:700px; help:No;");
    }
    return point;
}
function createMarker(point,name,markerType) {
    var iconObj=getIcon(markerType);
    var basemarker = new GMarker(point, {
        title:name,
        icon:iconObj
    });
    return basemarker;
}
/**
 * create GIcon
 */
function getIcon(markerType) {
    if(iconManager["icon"+markerType]==undefined){
        iconManager["icon"+markerType]=new GIcon(G_DEFAULT_ICON,"http://"+location.host+webDir+"/images/"+markerImg[markerType]);
        if(markerType=="11" ||markerType=="12" || markerType=="13"){
            iconManager["icon"+markerType].iconSize=new GSize(15,15);
            iconManager["icon"+markerType].shadow="";//http://"+location.host+webDir+"/images/shadow.gif";
        }else{
            iconManager["icon"+markerType].iconSize=new GSize(35,35);
            iconManager["icon"+markerType].shadow="";
        }
    }
    return iconManager["icon"+markerType];
}
/**
 * add icon
 */
function addTypeIcon(markerType,imgURL,imgSize) {
    if(iconManager["icon"+markerType]==undefined){
        iconManager["icon"+markerType]=new GIcon(G_DEFAULT_ICON,imgURL);
        iconManager["icon"+markerType].iconSize=new GSize(imgSize,imgSize);
        iconManager["icon"+markerType].shadow="";//http://"+location.host+webDir+"/images/shadow.gif";
    }else{
        alert("重複設定GIcon!!"+markerType+":"+imgURL);
    }
}

//*****2009/03/23 增加地圖限制檢視範圍******
//限制縮放級別
function setZoomLevel(minZoom,maxZoom) {
    var maptype=mapObj.getMapTypes();
    for(var i=0; i<maptype.length; i++){
        maptype[i].getMinimumResolution=function(){
            return minZoom;
        }
        maptype[i].getMaximumResolution=function(){
            return maxZoom;
        }
    }
}
//檢查Bounds函式
function checkBounds(range){
    if(range.contains(mapObj.getCenter())){
        return;
    }
    var center=mapObj.getCenter();
    var x=center.lng();
    var y=center.lat();

    var maxX=range.getNorthEast().lng();
    var maxY=range.getNorthEast().lat();
    var minX=range.getSouthWest().lng();
    var minY=range.getSouthWest().lat();

    if(x< minX){
        x=minX;
    }
    if(y< minY){
        y=minY;
    }
    if(x> maxX){
        x=maxX;
    }
    if(y> maxY){
        y=maxY;
    }
    mapObj.setCenter(new GLatLng(centerY,centerX));
}

/**
 * 快速指向某中心點
 */
function getFocusIn(x,y,scale) {
    if(scale==undefined){
        mapObj.panTo(new GLatLng(y,x));
    }else{
        mapObj.setCenter(new GLatLng(y,x),scale);
    }
}
/**
 * 依地址指向中心點
 */
function getFocusInByAddress(address){
    var geocoder = new GClientGeocoder();
    geocoder.getLatLng(address, function(point) {
        if (!point) {
            alert('Google Maps 找不到該地址，無法顯示地圖！'); //如果Google Maps無法顯示該地址的警示文字
        } else {
            mapObj.setCenter(point, 16);
        }
    });
}
/**
 * 2009/6/18增加
 * 列印地圖
 */
function printMap(mapid,width,height){
    var disp_setting="toolbar=yes,location=no,directories=yes,menubar=yes,";
    disp_setting+="scrollbars=yes,width="+width+", height="+height+", left=100, top=25";
    var content_vlue = document.getElementById(mapid).innerHTML;
    var docprint=window.open("","",disp_setting);

    docprint.document.open();
    docprint.document.write('<html><head><title>Inel Power System</title>');

    docprint.document.write('</head><body onLoad="window.print();window.close()"><center>');
    docprint.document.write(content_vlue);
    docprint.document.write('</center></body></html>');
    docprint.document.close();
    docprint.focus();
}
/**
 *抓取地圖中心點
 **/
function getMapCenter(){
    alert(mapObj.getBounds(),mapObj.getZoom());
}
/**
 * 將經緯度轉div map物件的pixcal值
 **/
function geLatLngToPixcal(latlng) {
    var pixcal=mapObj.fromLatLngToDivPixel(latlng);
    return pixcal;
}