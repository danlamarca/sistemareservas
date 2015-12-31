<%@ Page Language="C#" AutoEventWireup="true" CodeFile="teste1.aspx.cs" Inherits="teste1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body  onload="javascript:document.forms[0]['txt_data'].value=Date();">
    <form id="form1" runat="server">
    <div>
    <asp:textbox ID="txt_data" runat="server" value="" Width="500px" />
    </div>
    </form>
</body>
</html>
