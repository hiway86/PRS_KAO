<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mapViewer.aspx.cs" Inherits="MIS_mapViewer" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>地圖檢視</title>
    <link href="../css/web.css" rel="stylesheet" />
    <link rel="Stylesheet" type="text/css" href="../css/impromptu.css" />
    <script src="../javascript/json2.js" type="text/javascript"></script>
    <script type="text/javascript" src="../javascript/jquery-1.3.2.js"></script>
    <script type="text/javascript" src="../javascript/jquery-impromptu.2.8.min.js"></script>
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
    <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>
    <link href="../css/bootstrap-3.1.1-dist/css/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript">
        var jsonString;
        var jsonObject;
        var imagePath;
        var dataType;
        var iconPath = "../img/mapicons/";
        //Initializing the google maps.
        var map = null;
        var infowindow = new google.maps.InfoWindow({
            size: new google.maps.Size(300, 600)
        });

        function ChangeDateFormat(cellval) {
            if (cellval != null) {
                var date = new Date(parseInt(cellval.replace("/Date(", "").replace(")/", ""), 10));
                var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
                var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
                return date.getFullYear() + "-" + month + "-" + currentDate;
            }
            else {
                return "無";
            }
        }

        function initialize() {
            var myOptions = {
                center: new google.maps.LatLng(25.0228, 121.4634),
                zoom: 15,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            }
            map = new google.maps.Map(document.getElementById("map"), myOptions);

            google.maps.event.addListener(map, 'click', function () {
                infowindow.close();
            });
            dataType = document.getElementById("dataType").value;
            jsonString = document.getElementById("jsonData").value;
            imagePath = document.getElementById("imagePath").value;
            jsonObject = JSON.parse(jsonString);
            if (jsonObject.length == 0) {
                alert("無座標資料，回到上一頁？");
                setTimeout(history.back(), 1000);
            }

            if (dataType == "Device") {
                showDevice();
                if (jsonObject.length == 1)
                    map.setCenter(new google.maps.LatLng(jsonObject[0].Gis_Y, jsonObject[0].Gis_X));
            }
            else if (dataType == "Case") {
                showCase();
                if (jsonObject.length == 1)
                    map.setCenter(new google.maps.LatLng(jsonObject[0].Gis_Y, jsonObject[0].Gis_X));
            }
        }

        function showDevice() {
            for (var i = 0; i < jsonObject.length; i++) {
                var point = new google.maps.LatLng(jsonObject[i].Gis_Y, jsonObject[i].Gis_X);
                var type = dataType;
                var name = jsonObject[i].Location;
                var html = "<table><tr><th><h5>" + jsonObject[i].Location + "</h5></th></tr><tr><td><p>設備編號: " + jsonObject[i].Device_ID + "</p></td></tr></table>";
                createMarker(point, name, html, jsonObject[i].DeviceModel);
            }
        }

        function showCase() {
            for (var i = 0; i < jsonObject.length; i++) {
                var point = new google.maps.LatLng(jsonObject[i].Gis_Y, jsonObject[i].Gis_X);
                var type = dataType;
                var name = jsonObject[i].Location;
                var html = "<table><tr><th><h5>" + jsonObject[i].Location + "</h5></th></tr><tr><td><p>案件編號: " + jsonObject[i].CaseID + "<br />設備編號: " + jsonObject[i].Device_ID + " <br />故障描述: " + jsonObject[i].FaultDescribe + " <br />通知日期: " + ChangeDateFormat(jsonObject[i].NotifyDate) + " <br />指定修復日期: " + ChangeDateFormat(jsonObject[i].RepairDeadline) + "</p></td></tr></table>";
                createMarker(point, name, html, jsonObject[i].DeviceModel);
            }
        }

        function createMarker(latlng, name, html, category) {
            var contentString = html;
            var url = iconPath + category + ".gif";
            var marker = new google.maps.Marker({
                position: latlng,
                icon: url,
                map: map,
                title: name
            });


            google.maps.event.addListener(marker, 'click', function () {
                infowindow.setContent(contentString);
                infowindow.open(map, marker);
            });

        }




    </script>
    <style type="text/css">
        html {
            height: 100%;
            width: 100%;
        }

        body {
            height: 100%;
            width: 100%;
            margin: 0;
            padding: 0;
        }

        form, #map {
            width: 100%;
            height: 100%;
        }

            #map img {
                max-width: none;
            }

        #Calendarextender1_popupDiv, #Calendarextender2_popupDiv {
            z-index: 1;
        }
    </style>
    <link href="../css/bootstrap/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap/bootstrap.css" rel="stylesheet" type="text/css" />
</head>
<body onload="initialize()">
    <form id="form1" class="form-inline" role="form" runat="server">
        <br />
        <div>
            <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" CombineScripts="false" EnableScriptGlobalization="True"></cc1:ToolkitScriptManager>
        </div>
        <asp:HiddenField ID="dataType" runat="server" />
        <asp:HiddenField ID="jsonData" runat="server" />
        <asp:HiddenField ID="imagePath" runat="server" />
        <div style="padding-bottom:20px">
            <label>地址/路口：</label>
            <asp:DropDownList ID="DropDownList1" CssClass="dropdown" runat="server" AppendDataBoundItems="true">
            </asp:DropDownList>
            <asp:Button ID="Button2" runat="server" Text="搜尋" OnClick="Button1_Click" CssClass="btn btn-primary" />

            <label id="lbl_repairend" runat="server" class="control-label">修復期限查詢：</label>
            <asp:TextBox ID="TextBox1" Height="30px" CssClass="form-control"
                runat="server"></asp:TextBox>
            <asp:Image ID="Image1" runat="server" ImageUrl="../images/calendar.png" />
            <cc1:CalendarExtender ID="Calendarextender1" runat="server" PopupButtonID="Image1"
                TargetControlID="TextBox1" Format="yyyy/MM/dd">
            </cc1:CalendarExtender>
            <label id="lbl2" runat="server" class="control-label"></label>
            <asp:TextBox ID="TextBox2" Height="30px" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:Image ID="Image2" runat="server" ImageUrl="../images/calendar.png" />
            <cc1:CalendarExtender ID="Calendarextender2" runat="server" PopupButtonID="Image2"
                TargetControlID="TextBox2" Format="yyyy/MM/dd">
            </cc1:CalendarExtender>


            <asp:Button ID="Button1" runat="server" Text="搜尋" OnClick="Button1_Click" CssClass="btn btn-primary" />
        </div>
        <div id="map" style="width: 100%; height: 85%"></div>

    </form>
</body>
</html>
