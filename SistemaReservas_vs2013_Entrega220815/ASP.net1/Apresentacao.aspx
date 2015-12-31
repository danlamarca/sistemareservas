<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Apresentacao.aspx.cs" Inherits="Apresentacao" %>


<asp:Content ID="MenuHorizontal_Menu" ContentPlaceHolderID="MenuHorizontal_Menu" runat="server">  
    <b><font class="menuhorizontal2">Apresentação</font></b>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MenuHorizontal" Runat="Server">
    <ul class="menuhorizontal2">   
        <li></li>   
    </ul>
</asp:Content> 


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <font class="atencao">!!! <%=Session["User_Nome"]%>, bem vindo ao Sistema de Reservas!!!</br>
        Clique no meu ao lado para iniciar sua reserva!</font>
    </div>
</asp:Content> 
