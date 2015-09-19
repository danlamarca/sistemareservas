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
    <asp:Label id="lbl_tableReserva" runat="server" visible="false">
        <table class="atencao2" border="1px">
            <tr height="20px">
                <td>Sala</td>             
                <td>Acompanhamento</td>             
                <td>Data Início</td>             
                <td>Data Fim</td>                
            </tr>
                 
            <tr>
                <td><asp:Label runat="server" id="lblSala"/></td>
                <td><asp:Label runat="server" id="lblAcompanha"/></td>
                <td><asp:Label runat="server" id="lblDtIni"/></td>
                <td><asp:Label runat="server" id="lblDtFim"/></td>
            </tr>
        </table>  
    </asp:label>
    
    <asp:label runat="server" id="lblmsg" visible="false" class="atencao" text="Reserva ainda não efetuada!" />
    <asp:label runat="server" id="lblreservaok" visible="false" class="atencao" />

    </br></br>
    
    <asp:ImageButton runat="server" id="btnConfirma" ImageURL="Image/botoes/bt_azconfirm.gif" visible="false" class="atencao" text="Confirmar Reserva" onclick="btnConfirma_click"/>&nbsp; &nbsp; 
    <asp:ImageButton runat="server" id="btnCancela" ImageURL="Image/botoes/bt_azexcl.gif" visible="false" class="atencao" text="Cancela Reserva" onclick="btnCancela_click"/>
    <asp:ImageButton runat="server" id="btnVoltar" ImageURL="Image/botoes/bt_azvolt.gif" visible="false" class="atencao" text="Confirmar Reserva" onclick="btnVoltar_click"/>&nbsp; &nbsp; 
 
</asp:Content>