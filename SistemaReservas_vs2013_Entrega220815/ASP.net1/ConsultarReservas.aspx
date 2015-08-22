<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="ConsultarReservas.aspx.cs" Inherits="Recuperar_cesta" %>

 <asp:Content ID="Content1" ContentPlaceHolderID=MenuHorizontal_Menu runat=server >
     <b><font class="menuhorizontal2">Consultar Reservas</font></b>
</asp:Content> 



<asp:Content ID="Content2" ContentPlaceHolderID=MenuHorizontal runat=server>
      <ul class="menuhorizontal2">

         <li><a href="ConsultarReservas.aspx"><font color="red"><b></b></font></a>
         </li>
                  
    </ul>
</asp:Content>




<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat=server>

    <!--INICIO TABELA DE PESQUISA-->
<table width="670" border=0 align="left" bgcolor=""> 
<tr> 
  <td> 
    <table width="100%" border="0" cellspacing="0" cellpadding="3" bgcolor="#F5F5F5">
      <tr align="left" valign="top"> 
        <td colspan="6"><span class="atencao3"><img src="Image/gr_filtro.gif" align="absmiddle">Consultar Reservas</span></td>
      </tr>
    </table>

    <table width="100%" border="0" cellspacing="0" cellpadding="3" bgcolor="#F5F5F5" ID="Table4">
      <tr> 
        <td colspan="6"></td>
      </tr>
      <tr> 
        <td width="15%"><span class="">Periodo de: </span></td>
        <td width="30%" class="texto" align="right">
        <font size="2">
            <asp:TextBox Id="txt_ini_dia" size=2 maxlenght="2" value="" runat="server" />
        &nbsp;/&nbsp;
            <asp:DropDownList id="txt_ini_mes" runat="server">
                  <asp:ListItem text="1" value="1" runat=server></asp:ListItem>
                  <asp:ListItem text="2" value="2" runat=server></asp:ListItem>
                  <asp:ListItem text="3" value="3" runat=server></asp:ListItem>
                  <asp:ListItem text="4" value="4" runat=server></asp:ListItem>
                  <asp:ListItem text="5" value="5" runat=server></asp:ListItem>
                  <asp:ListItem text="6" value="6" runat=server></asp:ListItem>
                  <asp:ListItem text="7" value="7" runat=server></asp:ListItem>
                  <asp:ListItem text="8" value="8" runat=server></asp:ListItem>
                  <asp:ListItem text="9" value="9" runat=server></asp:ListItem>
                  <asp:ListItem text="10" value="10" runat=server></asp:ListItem>
                  <asp:ListItem text="11" value="11" runat=server></asp:ListItem>
                  <asp:ListItem text="12" value="12" runat=server></asp:ListItem>
            </asp:DropDownlist>
        &nbsp;/&nbsp;            
            <asp:TextBox id="txt_ini_ano" size="4" maxlenght="4" runat=server />
        </font>
        </td>
        <td width="5%" align="center"><span class="">At&eacute; </span></td>
        <td colspan="3">
        <font size="2">
             <asp:TextBox id="txt_fim_dia" size="2" maxlength="2" runat="server" />
        &nbsp;/&nbsp;
           <asp:DropDownList id="txt_fim_mes" runat="server">
                  <asp:ListItem text="1" value="1" runat=server></asp:ListItem>
                  <asp:ListItem text="2" value="2" runat=server></asp:ListItem>
                  <asp:ListItem text="3" value="3" runat=server></asp:ListItem>
                  <asp:ListItem text="4" value="4" runat=server></asp:ListItem>
                  <asp:ListItem text="5" value="5" runat=server></asp:ListItem>
                  <asp:ListItem text="6" value="6" runat=server></asp:ListItem>
                  <asp:ListItem text="7" value="7" runat=server></asp:ListItem>
                  <asp:ListItem text="8" value="8" runat=server></asp:ListItem>
                  <asp:ListItem text="9" value="9" runat=server></asp:ListItem>
                  <asp:ListItem text="10" value="10" runat=server></asp:ListItem>
                  <asp:ListItem text="11" value="11" runat=server></asp:ListItem>
                  <asp:ListItem text="12" value="12" runat=server></asp:ListItem>
            </asp:DropDownlist>
        &nbsp;/&nbsp;
             <asp:TextBox id="txt_fim_ano" size="4" maxlength="4" runat="server"  />
        </font>
		      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
      </tr>
    </table>    

    <table width="100%" border="0" cellspacing="0" cellpadding="2" bgcolor="#F5F5F5" ID="Table2">
      <tr> 
        <td colspan="6"><img src="Image/transp.gif" width="5" height="5"></td>
      </tr>
      <tr>
        <td width="27%">
        <font size="2"> 
            <asp:DropDownList id="drp_tipo_pesq" runat="server">
              <asp:ListItem text="Cesta" value="1" runat=server></asp:ListItem>
            </asp:DropDownlist>
          </font></td>
          <td width="14%"> 
          <asp:Textbox id="chaveBusca" size="5" maxlength="15" value="" runat=server />  
        </td>
      <td width="59%"><asp:ImageButton ID="btn_buscar_ped" runat="server" ImageURL="Image/bt_buscar.gif" onclick="btn_buscar_ped_click"></asp:ImageButton></td>
      </tr>
    </table>
    <table width="100%" border="0" cellspacing="0" cellpadding="3" bgcolor="#F5F5F5" ID="Table3"> 
      <tr> 
        <td colspan="6"><img src="Image/transp.gif" width="5" height="5"></td>
      </tr>
      <tr> 
        <td colspan="6" class="atencao" align="center">Pesquisar Reservas!</font></td>
      </tr>
    </table>
  </td>
</tr>
<!--FINAL TABELA DE PESQUISA-->

<tr>
<td></td>
</tr>
<tr>
<td><asp:Label id="Lbl_no_result" runat=server cssclass="atencao" align="center" visible=false/></td>
</tr>

   <tr>
        <td>
            <!--TABELA DE LISTAGEM DA PESQUISA-->    
            <asp:GridView width="29%" class="atencao" ID="Gd_Lista_Pesquisa" runat="server" GridViewPageEventArgs=true  
                AllowPaging="true"   PageSize="3" OnPageIndexChanging="Gd_Lista_Pesquisa_PageIndexChanging" 
                BorderWidht="1px" CellPadding="4" Forecolor="#333333"  GridLines="Vertical" 
                Visible="False" CaptionAlign="Right" HorizontalAlign="left" >                 
                <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" /><RowStyle BackColor="#EFF3FB" />
                <PagerStyle BackColor="#2461BF" ForeColor="White"  HorizontalAlign= "Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"/>
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"/>
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
                <PagerSettings Mode="Numeric" PageButtonCount="7" FirstPageText="First" />
                 
                
                <Columns>
                    <asp:TemplateField HeaderText="">
                        <ItemStyle HorizontalAlign="center" />
                        <ItemTemplate>
                           <asp:ImageButton Id="Btn_img_abrir" runat="server" ImageURL="Image/bt_abrir.gif" onclick="Btn_img_abrir_click" />
                        </ItemTemplate>
                    </asp:TemplateField>    
                </Columns>  
                
                <Columns>
                    <asp:TemplateField HeaderText="">
                        <ItemStyle HorizontalAlign="center"/>
                            <ItemTemplate>
                                <asp:ImageButton id="Btn_img_excluir" runat="server" ImageUrl="Image/bt_excluir.gif" onclick="Btn_img_excluir_click" />
                            </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                 
            </asp:GridView>
            <!--FIM DA TABELA DE LISTAGEM DA PESQUISA-->
        </td>
    </tr>
    
</td>	
</tr>	
</table>    
</asp:Content>



