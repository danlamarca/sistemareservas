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
        ClsBancoDeDados oDB = new ClsBancoDeDados();
        Tratamento_Erros Tr_Error = new Tratamento_Erros();
        Valicoes_num Val_Num_int = new Valicoes_num();

        //variaveis globais de pagina:
        string strSQL;
        int retorna_erro;
         
        if (!IsPostBack)
        {
            //Recupera parametros:
            int iacompanhamento = Convert.ToInt32(Request["Acompanhamento"].ToString());
            int isala = Convert.ToInt32(Request["Sala"].ToString());
            int icodUser = Convert.ToInt32(Session["User_Codigo"].ToString()); 
            string sdata = Request["Data"].ToString();
            string  shoraIni = Request["HoraIni"].ToString();
            string  shoraFim = Request["HoraFim"].ToString();
            string scomentarios="";


            strSQL = "exec SP_TB_RESERVA_TEMP_INS " + iacompanhamento + "," + isala + "," + icodUser + ",'" + sdata + "','" + shoraIni + "','" + shoraFim + "','" + scomentarios +"'";
            DataTableReader ds_reservatemp = oDB.NewReader(strSQL);
            if (oDB.MensagemUltimoComando.ToString() == "Erro")
            {
                string retorno_xml = oDB.MensagemUltimoComando.ToString();
                string pagina = "Efetuar_Reserva_Processa.aspx";
                retorna_erro = Tr_Error.Grava_Excecao(Session["User_Nome"].ToString(), Session["User_Matricula"].ToString(), retorno_xml, strSQL, pagina);
                Response.Redirect("Mensagens.aspx?codigo=2&parametro=" + retorna_erro + "&botao_ok=S&acao_ok=Apresentacao.aspx");

            }
            if (ds_reservatemp != null)
            {
                while (ds_reservatemp.Read())
                {
                    //Ped_Temporario = int.Parse(ds_reservatemp["numped"].ToString());
                    Session["codreservatemp"] = ds_reservatemp["codreservatemp"];
                }
            }
            ds_reservatemp.Close();        
        }
        Response.Redirect("Efetuar_Reserva_Confirmar.aspx");
    }
}
