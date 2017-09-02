<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PagSeguro_Teste.aspx.cs" Inherits="PagSeguro_Teste" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MenuHorizontal_Menu" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuHorizontal" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label runat="server" id="lbl_valor" text="Total: R$ 200,00" />
    </br></br>
    <asp:Button runat="server" id="btn_pagseguro" text="PAGSEGURO" onclick="btn_pagseguro_onclick" />

</asp:Content>

  