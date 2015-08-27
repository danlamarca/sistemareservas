<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Apresentacao.aspx.cs" Inherits="Apresentacao" %>


<asp:Content ID="MenuHorizontal_Menu" ContentPlaceHolderID="MenuHorizontal_Menu" runat="server">  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MenuHorizontal" Runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <font class="atencao" >!!! Bem vindo ao Sistema de Reservas <%=Session["User_Nome"]%>!!!</br>
        Clique no meu ao lado para iniciar sua reserva!</font>
</asp:Content> 