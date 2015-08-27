using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Library1;
using System.Web;
using System.Windows.Forms;


public partial class Efetuar_compra_processa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Recupera parametros:
            int Acompanhamento = Convert.ToInt32(Request["Acompanhamento"].ToString());


        //    strSQL = "exec SP_INS_TB_RESERVA_TEMP '" + @CODSALA+ "','" + Session["User_Codigo"] + "','" + @DATAINICIO +"','"+ @DATAFIM +"','"+ @DESCRICAO +"'";
        //    DataTableReader ds_reservatemp = oDB.NewReader(strSQL);
        //    if (oDB.MensagemUltimoComando.ToString() == "Erro")
        //    {
        //        string retorno_xml = oDB.MensagemUltimoComando.ToString();
        //        string pagina = "Efetuar_Reserva_Confirmar.aspx";
        //        retorna_erro = Tr_Error.Grava_Excecao(Session["User_Nome"].ToString(), Session["User_Matricula"].ToString(), retorno_xml, strSQL, pagina);
        //        Response.Redirect("Mensagens.aspx?codigo=2&parametro=" + retorna_erro + "&botao_ok=S&acao_ok=Apresentacao.aspx");

        //    }
        //    if (ds_reservatemp != null)
        //    {
        //        while (ds_reservatemp.Read())
        //        {
        //            Ped_Temporario = int.Parse(ds_reservatemp["numped"].ToString());
        //            Session["num_reservatemp"] = ds_reservatemp["numped"];
        //        }
        //    }
        //    ds_reservatemp.Close();        
        }
        //Response.Redirect("Efetuar_Reserva.aspx");
    }
}
