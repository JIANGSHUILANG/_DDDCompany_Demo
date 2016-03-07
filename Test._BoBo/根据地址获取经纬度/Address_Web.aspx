<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Address_Web.aspx.cs" Inherits="Test._BoBo.根据地址获取经纬度.Address_Web" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="../Javascripts/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=LOoFXO0NxsgLd6BgTjGxb2ZD"></script>
    <script type="text/javascript">
        function getLngLat(address) {
            var pointlnglat = document.getElementById(address).value;
            // 创建地址解析器实例
            var myGeo = new BMap.Geocoder();
            // 将地址解析结果显示在地图上,并调整地图视野
            myGeo.getPoint(pointlnglat, function (point) {
                var lng = 0;
                var lat = 0;
                if (point) {
                    lng = point.lng;
                    lat = point.lat;
                }
                alert(lng+"-----"+lat);
            })
        }
    </script>
</head>
<body>
    <input type="text"  onblur="getLngLat(this.id)" id="address" />
</body>
</html>
