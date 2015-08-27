<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Efetuar_Reserva_Confirmar.aspx.cs" Inherits="Minha_Cesta" %>


<asp:Content ContentPlaceHolderID="MenuHorizontal_Menu" runat="server">
    <b><font class="menuhorizontal2">Reserva/Confirmar</font></b>
</asp:Content>


<asp:Content ContentPlaceHolderID="MenuHorizontal" runat="server">
    <ul class="menuhorizontal2">

     <li><a href="Efetuar_Reserva.aspx">Cadastrar</b></font></a>
     </li>      
     
     <li><a href="Efetuar_Reserva_Confirmar.aspx"><font color="red"><b>Confirmar</b></a>
     </li>
     
     <!--
       <li><a href="#">Teste</a>
         <ul>
             <li><a href="#">A</a></li>
             <li><a href="#">B</a></li>
             <li><a href="#">C</a></li>
         </ul>
     </li>
     -->
     
     <li><asp:Label cssclass="atencao3" id="lbl_exibe_pedido" runat="server" visible=false /> 
     </li>
     
</ul>
</asp:Content>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <font class="atencao">Confirmar Reserva!</font><br/>
   
   
</asp:Content>