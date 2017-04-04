<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="ConsultarReservas.aspx.cs" Inherits="ConsultarReservas" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="MenuHorizontal_Menu" runat="server" >
     <b><font class="menuhorizontal2">Consultar Reservas</font></b>
     <script>
         $(document).ready(function () {
             $(".datepicker").datepicker({
                 dateFormat: 'dd/mm/yy',
                 dayNames: ['Domingo', 'Segunda', 'TerÃ§a', 'Quarta', 'Quinta', 'Sexta', 'SÃ¡bado', 'Domingo'],
                 dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'],
                 dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'SÃ¡b', 'Dom'],
                 monthNames: ['Janeiro', 'Fevereiro', 'MarÃ§o', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
                 monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
                 nextText: 'Próximo',
                 prevText: 'Anterior'
             });
         });
    </script>
</asp:Content> 

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat=server>
      <table id="tb_td1" runat="server" runat="server">
                 <tr>
                    <td>
                        <asp:Label id="lbl_de" runat="server" text="De:" cssclass="atencao" />    
                        <asp:TextBox runat="server" id="txt_reservas_de" Width="70px" class="datepicker" Height="16px"/>
                    </td>              
                    <td>
                        <asp:Label id="lbl_ate" runat="server" cssclass="atencao" text="Até"/>
                        <asp:TextBox runat="server" id="txt_reservas_ate" Width="70px" class="datepicker" Height="16px"/>
                     </td>                
                    <td>
                        <asp:ImageButton Id="Btn_img_Avancar" Visible="true" align="left" ImageURL="Image/botoes/bt_az_proxima.gif" runat="server" onclick="Btn_img_Avancar_click" />
                    </td>
                </tr>    
             </table> 
        
             </br>

             <table>
                 <tr>
                     <td>
                         <asp:GridView class="atencao1" id="grd_consulta_reserva" runat="server" autogeneratecolumns="false" OnRowDataBound="grd_cons_reserva_OnRowDataBound">  
                            <Columns>
                                <asp:BoundField datafield="_CODRESERVA" headertext="Reserva" />
                                <asp:BoundField datafield="_DATAINICIO" headertext="Data Inicial" />
                                <asp:BoundField datafield="_DATAFIM" headertext="Data Final" />
                                <asp:BoundField datafield="_CODSALA" headertext="Sala" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton id="lnk_editar" runat="server" text="Editar" Onclick="lnk_editar_Onclick"/>
                                    </ItemTemplate> 
                                </asp:TemplateField>
                                 <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton id="lnk_excluir" runat="server" text="Excluir" Onclick="lnk_excluir_Onclick"/>
                                    </ItemTemplate> 
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                     </td>   
                 </tr>
             </table>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MenuHorizontal" Runat="Server">
    <ul class="menuhorizontal2">     
     <li><a href="ConsultarReservas.aspx"><font color="red"><b>Consultar</b></font></a>
     </li>
     <li><a href="Efetuar_Reserva.aspx"><font color="black"><b>Cadastrar</b></font></a>
     </li>
</ul>
</asp:Content>




