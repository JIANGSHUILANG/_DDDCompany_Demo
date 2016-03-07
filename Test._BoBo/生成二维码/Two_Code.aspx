<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Two_Code.aspx.cs" Inherits="Test._BoBo.生成二维码.Two_Code" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../Javascripts/jquery-1.8.2.min.js"></script>
    <script src="../Javascripts/jquery.qrcode.js"></script>
    <script src="../Javascripts/qrcode.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#qrcodeTable").qrcode({
                render: "canvas",
                text: "http://localhost:4194/生成二维码/TwoCode_Jump_ThisPage.html", //给一个线上的地址
                width: "100",
                height: "100"
            });
        })
    </script>
</head>
<body>
    <div id="qrcodeTable" class="form_wrp">
    </div>
    <span>扫一扫二维码</span>
</body>
</html>
