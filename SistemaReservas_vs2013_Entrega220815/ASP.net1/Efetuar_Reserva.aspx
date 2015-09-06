<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Efetuar_Reserva.aspx.cs" Inherits="Efetuar_Compra" %>


<asp:Content ID="MenuHorizontal_Menu" ContentPlaceHolderID="MenuHorizontal_Menu" runat="server">
    <b><font class="menuhorizontal2">Reserva/Cadastrar</font></b>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MenuHorizontal" Runat="Server">
    <ul class="menuhorizontal2">

     <li><a href="Efetuar_Reserva.aspx"><font color="red"><b>Cadastrar</b></font></a>
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
    
    <table>
      <tr>    
          <td>
            <font class="atencao">Informe a Data:</font></br>        
            <asp:TextBox id="txt_datareserva" runat=server Width="114px" class="datepicker" Height="16px" />
          </td>           
          <td></td><td></td><td></td>            
          <td>
            <font class="atencao">Informe o Hor�rio:</font></br> 
            <asp:DropDownList id="drp_hora" name="drp_hora" runat=server Width="114px">
                <asp:ListItem text="08:00 -- 09:00" value="1" runat=server></asp:ListItem>
                <asp:ListItem text="09:00 -- 10:00" value="2" runat="server"></asp:ListItem>
                <asp:ListItem text="10:00 -- 11:00" value="3" runat="server"></asp:ListItem>
                <asp:ListItem text="11:00 -- 12:00" value="4" runat="server"></asp:ListItem>
                <asp:ListItem text="12:00 -- 13:00" value="5" runat="server"></asp:ListItem>
                <asp:ListItem text="13:00 -- 14:00" value="6" runat="server"></asp:ListItem>
                <asp:ListItem text="14:00 -- 15:00" value="7" runat="server"></asp:ListItem>
                <asp:ListItem text="15:00 -- 16:00" value="8" runat="server"></asp:ListItem>
                <asp:ListItem text="16:00 -- 17:00" value="9" runat="server"></asp:ListItem>
                <asp:ListItem text="17:00 -- 18:00" value="10" runat="server"></asp:ListItem>
            </asp:DropDownList>
           </td>  

          <td></td><td></td><td></td>            
           <td>
            <font class="atencao">Sala:</font></br> 
            <asp:DropDownList id="drp_sala" name="drp_sala" runat=server Width="130px"></asp:DropDownList>     
           </td>
           <td></td><td></td><td></td>            
           <td>
            <font class="atencao">Acompanhamento:</font></br> 
            <asp:DropDownList id="drp_acompanhamento" name="drp_acompanhamento" runat=server Width="130px"></asp:DropDownList>     
           </td>
          <td></td><td></td><td></td>            
           <td>
            <asp:ImageButton Id="Btn_img_Avancar" Visible="true" align="left" ImageURL="Image/botoes/bt_az_proxima.gif" runat="server" onclick="Btn_img_Avancar_Click" />    
           </td>        
      </tr> 
    </table>
    
    

</asp:Content>