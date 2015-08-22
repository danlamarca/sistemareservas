<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Efetuar_Reserva_Verificar.aspx.cs" Inherits="Efetuar_Compra_servico" %>


<asp:Content ID="MenuHorizontal_Menu" ContentPlaceHolderID="MenuHorizontal_Menu" runat="server">
    <b><font class="menuhorizontal2">Reserva/Verificar</font></b>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MenuHorizontal" Runat="Server">
    <ul class="menuhorizontal2">

     <li><a href="Efetuar_Reserva.aspx">Cadastrar</a>
     </li>
     
     <li><a href="Efetuar_Reserva_Verificar.aspx"><font color="red"><b>Verificar</b></a>
     </li>
     
     <li><a href="Efetuar_Reserva_Confirmar.aspx">Confirmar</a>
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
    <font class="atencao">Verificar!</font><br/>  
    <font class="atencao" >Verifique/edite a data selecionada:</font><br/>

    
           
    
</asp:Content>