<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frete.aspx.cs" Inherits="frete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txt_frete" runat="server" width="100px" />
        </br>
        <asp:button ID="btn_frete" runat="server" Text="FRETE" OnClick="btn_frete_click"/>

    </div>
    </form>
</body>
</html>
