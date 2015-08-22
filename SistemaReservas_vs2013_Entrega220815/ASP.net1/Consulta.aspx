<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Consulta.aspx.cs" Inherits="Consulta" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="left" class="style3">  
        <tr>
            <td>
                <font class="atencao">Pedido</font><br/>
                <font class="atencao" >Digite o Nome do Produto:</font><br/>
                <asp:TextBox ID="Lbl_busca_produto" runat="server" Width="319px"></asp:TextBox>&nbsp;&nbsp;<br/>
                <!--<asp:ImageButton ImageUrl="Image/bt_buscar.gif" id="Img1" runat="server" alt="" border="0" onclick="Btn_Teste_Click"/>-->
                <asp:Button ID="btn_teste" runat="server" CssClass="atencao" Text="Buscar" onclick="Btn_Teste_Click"></asp:Button>
                <br/><br/>
              
                </div>
    
                <div align="left">  
                 
                <asp:GridView width="29%" ID="Gd_Busca_Produtos" runat="server" BorderWidht="1px" CellPadding="4" Forecolor="#333333"  GridLines="Vertical" Visible="False" CaptionAlign="Right" HorizontalAlign="center">
                
                    <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" /><RowStyle BackColor="#EFF3FB" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White"  HorizontalAlign= "Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"/>
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"/>
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                    
                </asp:GridView>
                
                   
                
                
            </td>
        </tr>
    </table>
    
</asp:Content>