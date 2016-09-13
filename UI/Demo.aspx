<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Demo.aspx.cs" Inherits="UI.Demo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src="https://code.jquery.com/jquery-2.2.4.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
    <script type="text/javascript">
        $.ajax({
            url: "../Home/Index",
            type: "post",
            success: function (data) {
                alert(data);
            }, error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(textStatus);
            }
        });
    </script>
</body>
</html>
