<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PagSeguro_Teste.aspx.cs" Inherits="PagSeguro_Teste" %>

 

<asp:Content ID="Content1" ContentPlaceHolderID="MenuHorizontal_Menu" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuHorizontal" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    COMPRA:</br>
    <asp:Label runat="server" id="lbl_id" /></br>
    <asp:Label runat="server" id="lbl_nome" /></br>
    <asp:Label runat="server" id="lbl_descricao" /></br>
    <asp:Label runat="server" id="lbl_valorr" /></br>
    </br></br>
    <asp:Button runat="server" id="btn_pagseguro" text="PAGSEGURO" visible="false" onclick="btn_pagseguro_onclick" />
    <b><asp:Label runat="server" id="lbl_teste" forecolor="Red" text="" visible="false" /></b>
    </br></br>		

     
    
</asp:Content>

  