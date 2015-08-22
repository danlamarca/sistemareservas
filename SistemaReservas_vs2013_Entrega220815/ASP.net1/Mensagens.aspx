<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Mensagens.aspx.cs" Inherits="Mensagens" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

</br> 
<table width="500" border="0" align="left" cellspacing="0" cellpadding="1" bgcolor="#000000">
<tr>
	<td>
    <table width="498" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
    <tr bgcolor="#f9f9f9"> 
		<td width="10" align="center"><b><font face="Verdana, Arial, Helvetica, sans-serif">!</font></b></td>
        <td width="478" align="center"><span class="loginbusca">Mensagem - <asp:label id="lbl_codigo" runat="server" visible=false/> </span></td>
        <td width="10" align="center"><b><font face="Tahoma, Verdana">!</font></b></td>
    </tr>
    <tr bgcolor="#E5C500"> 
		<td background="Image/bg_linha_hor_transp.gif" height="1"><img src="Image/transp.gif" width="1" height="1"></td>
		<td background="Image/bg_linha_hor_transp.gif" height="1"><img src="Image/bg_linha_hor_transp_mens.gif" height="1"></td>
		<td background="Image/bg_linha_hor_transp.gif" height="1"><img src="Image/transp.gif" width="1" height="1"></td>
	</tr>
    <tr> 
		<td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr> 
		<td>&nbsp;</td>
        <td align="center"><span class="atencao"><asp:label id="lbl_msg" runat="server" visible=false/></span></td>
        <td>&nbsp;</td>
    </tr>
    <tr> 
		<td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
		<td>&nbsp;</td>
          <td align="center">  
          </td>
        <td>&nbsp;</td>
      
    </tr>
    </table>
    </td>
</tr>
</table>
     
</asp:Content>
