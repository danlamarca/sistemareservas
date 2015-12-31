<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Teste1.aspx.cs" Inherits="JavaScript_Teste_Teste1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body  onload="javascript:document.forms[0]['txt_data'].value=Date();">
<script type="text/javascript" >
    function altera_status(pedido, status)
    {
        if (status) {
            status = 'S'
        }
        else {
            status = 'N'
        }
        xmlhttp.open("GET", "teste2.aspx?data=" + Date(), true);
        xmlhttp.send(null);        
    }
</script>
    <form id="form1" runat="server">
    <div>
    <asp:textbox ID="txt_data" runat="server" value="" Width="500px" /></br>
    <asp:Button ID="btn_salva" runat="server" Text="Salva" />
    <asp:Button ID="btn_salva2" runat="server" Text="Salva2" />
    <asp:textbox ID="txt_info" runat="server" value="atenção" />
    </div>
    </form>
</body>
</html>
