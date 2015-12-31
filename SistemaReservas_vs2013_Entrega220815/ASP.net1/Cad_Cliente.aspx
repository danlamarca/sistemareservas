<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Cad_Cliente.aspx.cs" Inherits="Cad_Cliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MenuHorizontal_Menu" Runat="Server">
    <b><font class="menuhorizontal2">Cadastrar Cliente</font></b>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MenuHorizontal" Runat="Server">
    <ul class="menuhorizontal2">
         <li><a href="Cad_Cliente.aspx"><font color="red"><b>Cadastrar</b></font></a>
         </li>
    </ul>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="atencao">
        <tr>
            <td><asp:Label id="lbl_nome" runat="server" text="Nome: " /></td>
            <td><asp:TextBox id="txt_nome" runat="server" style="width:180px" /></td>

            <td><asp:Label id="lbl_cpf" runat="server" text="CPF: " /></td>
            <td><asp:TextBox id="txt_cpf" runat="server" style="width:120px" /></td>

            <td><asp:Label id="lbl_endereco" runat="server" text="Endereço: " /></td>
            <td><asp:TextBox id="txt_endereco" runat="server" style="width:280px" /></td>

            <td><asp:Button class="atencao2" id="btn_ok" runat="server" text="OK" style="width:60px" Onclick="btn_ok_Onclick"/></td>
        </tr>
    </table>   
    
    </br>
    
    <asp:GridView class="atencao1" id="grd_cli" runat="server" autogeneratecolumns="false" OnRowDataBound="grd_cli_OnRowDataBound">  
        <Columns>
            <asp:BoundField datafield="_NOME" headertext="Nome" />
            <asp:BoundField datafield="_CPF" headertext="CPF" />
            <asp:BoundField datafield="_ENDERECO" headertext="Endereço" />

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

    </br>
      
    <asp:ImageButton runat="server" id="btn_Confirma" ImageURL="Image/botoes/bt_azconfirm.gif" class="atencao" onclick="btn_Confirma_Onclick"></asp:ImageButton>
</asp:Content>

