<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="MeusPedidos.aspx.cs" Inherits="MeusPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MenuHorizontal_Menu" Runat="Server>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuHorizontal" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label id="txt_titulo" runat="server" text="Integração Meus Pedidos" />
    </br>
    <asp:CheckBox id="chk_im_cli" runat="server" text="Importar Cliente" checked="false" />&nbsp;
    <asp:Button id="btn_importar" runat="server" text="OK" OnClick="btn_importar_Click" />

</asp:Content>
