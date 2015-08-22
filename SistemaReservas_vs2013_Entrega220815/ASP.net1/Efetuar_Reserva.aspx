<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Efetuar_Reserva.aspx.cs" Inherits="Efetuar_Compra" %>


<asp:Content ID="MenuHorizontal_Menu" ContentPlaceHolderID="MenuHorizontal_Menu" runat="server">
    <b><font class="menuhorizontal2">Reserva</font></b>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MenuHorizontal" Runat="Server">
    <ul class="menuhorizontal2">

     <li><a href="Efetuar_Reserva.aspx"><font color="red"><b>Cadastrar</b></font></a>
     </li>
     
     <li><a href="Efetuar_Reserva_Verificar.aspx">Verificar</a>
     </li>
     
     <li><a href="Efetuar_Reserva_Confirmar.aspx">Confirmar</a>
     </li>
       
    <li><asp:Label cssclass="atencao3" id="lbl_exibe_pedido" runat="server" visible=false /> 
    </li>
     
</ul>
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">    
    <script>
        $(document).ready(function () {
            $(".datepicker").datepicker({
                dateFormat: 'dd/mm/yy',
                dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado', 'Domingo'],
                dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'],
                dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'],
                monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
                monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
                nextText: 'Pr�ximo',
                prevText: 'Anterior'
            });
        });
    </script> 
    
    <div>
       <font class="atencao">Informe a Data:</font></br>        
       <asp:TextBox id="txt_datareserva" runat=server Width="114px" class="datepicker" />
    </div>
    
</asp:Content>