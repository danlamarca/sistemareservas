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
using System.Windows.Forms;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Library1;

public partial class Minha_Cesta : System.Web.UI.Page
{
    //Instanciando todas as classes
    ClsBancoDeDados oDB = new ClsBancoDeDados();
    Tratamento_Erros Tr_Error = new Tratamento_Erros();     

    //Carregando as Sessões  
    string strSQL;
    int retorna_erro;
    int Ped_Temporario; 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["codreservatemp"] != null)
            {
                if (Session["codreservatemp"].ToString() != "")
                {
                    lbl_exibe_pedido.Text = "Reserva nº " + Session["codreservatemp"].ToString();
                    lbl_exibe_pedido.Visible = true;
                }

                //carrega agendamento temporário:
                strSQL = "SP_TB_RESERVA_TEMP_SEL " + Convert.ToInt32(Session["codreservatemp"].ToString());
                DataTableReader drAgenda = oDB.NewReader(strSQL);
                if (oDB.MensagemUltimoComando.ToString() == "Erro")
                {
                    string retorno_xml = oDB.MensagemUltimoComando.ToString();
                    string pagina = "Efetuar_Reserva_Confirmar.aspx";
                    retorna_erro = Tr_Error.Grava_Excecao(Session["User_Nome"].ToString(), Session["User_Matricula"].ToString(), retorno_xml, strSQL, pagina);
                    Response.Redirect("Mensagens.aspx?codigo=2&parametro=" + retorna_erro + "&botao_ok=S&acao_ok=Apresentacao.aspx");
                }
                if (drAgenda != null)
                {
                    while (drAgenda.Read())
                    {
                        lblSala.Text = drAgenda["sala"].ToString();
                        lblAcompanha.Text = drAgenda["acompanhamento"].ToString();
                        lblDtIni.Text = drAgenda["dtini"].ToString();
                        lblDtFim.Text = drAgenda["dtfim"].ToString();
                    }
                }
                drAgenda.Close();

                btnConfirma.Visible = true;
                btnCancela.Visible = true;
                lbl_tableReserva.Visible = true;
            }
            else
                lblmsg.Visible = true;
            
        }
    }
 
    protected void btnConfirma_click(object sender, EventArgs e)
    {
        strSQL = "exec SP_TB_RESERVA_INS " + Session["codreservatemp"].ToString();
        oDB.ExecuteSemRetorno(strSQL);
        if (oDB.MensagemUltimoComando.ToString() == "Erro")
        {
            string retorno_xml = oDB.MensagemUltimoComando.ToString();
            string pagina = "Efetuar_Reserva_Confirmar.aspx";
            retorna_erro = Tr_Error.Grava_Excecao(Session["User_Nome"].ToString(), Session["User_Matricula"].ToString(), retorno_xml, strSQL, pagina);
            Response.Redirect("Mensagens.aspx?codigo=2&parametro=" + retorna_erro + "&botao_ok=S&acao_ok=Apresentacao.aspx");
        }
        string sreserva = Session["codreservatemp"].ToString();
        Session["codreservatemp"] = null;

        btnVoltar.Visible = true;
        btnConfirma.Visible = false;
        btnCancela.Visible = false;
        lbl_tableReserva.Visible = false;

        lblreservaok.Visible = true;
        lblreservaok.Text = "Reserva " + sreserva + " criada com sucesso!!!";

    }

    protected void btnCancela_click(object sender, EventArgs e)  
    {
        strSQL = "exec SP_TB_RESERVA_TEMP_DEL " + Session["codreservatemp"].ToString();
        oDB.ExecuteSemRetorno(strSQL);
        if (oDB.MensagemUltimoComando.ToString() == "Erro")
        {
            string retorno_xml = oDB.MensagemUltimoComando.ToString();
            string pagina = "Efetuar_Reserva_Confirmar.aspx";
            retorna_erro = Tr_Error.Grava_Excecao(Session["User_Nome"].ToString(), Session["User_Matricula"].ToString(), retorno_xml, strSQL, pagina);
            Response.Redirect("Mensagens.aspx?codigo=2&parametro=" + retorna_erro + "&botao_ok=S&acao_ok=Apresentacao.aspx");
        }

        Session["codreservatemp"] = null;

        Response.Redirect("Efetuar_Reserva.aspx");
    }

    protected void btnVoltar_click(object sender, EventArgs e)
    {
        Response.Redirect("Apresentacao.aspx");
    }
      
}
