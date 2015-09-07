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



public partial class Efetuar_Compra : System.Web.UI.Page
{
    ClsBancoDeDados oDB = new ClsBancoDeDados();
    Tratamento_Erros Tr_Error = new Tratamento_Erros();
    Valicoes_num Val_Num_int = new Valicoes_num();

    //variaveis globais de pagina:
    string strSQL;   
    int retorna_erro;
    int cesta_ok;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Carrega Acompanhamento:
            strSQL = "Select CODACOMPANHAMENTOITEM,ITEM from tb_acompanhamento_item(nolock)";
            DataTableReader ds_acompanha = oDB.NewReader(strSQL);
            //carrega lista de acompanhamentos:
            if (oDB.MensagemUltimoComando.ToString() == "Erro") 
            {
                string retorno_xml = oDB.MensagemUltimoComando.ToString();
                string pagina = "Efetuar_Reserva.aspx";
                retorna_erro = Tr_Error.Grava_Excecao("user1", "user1", retorno_xml, strSQL, pagina);
                Response.Redirect("Mensagens.aspx?codigo=2&parametro=" + retorna_erro + "&botao_ok=S&acao_ok=Apresentacao.aspx");
            }

            if (ds_acompanha != null) 
            {
                while (ds_acompanha.Read())
                { 
                    //carrega dropdownlist dinamicamente:
                    drp_acompanhamento.Items.Add(new ListItem(ds_acompanha["item"].ToString(), ds_acompanha["CODACOMPANHAMENTOITEM"].ToString()));
                }
            }
            ds_acompanha.Close();

            //Carrega Sala:
            strSQL = "Select * from tb_sala(nolock)";
            DataTableReader ds_sala = oDB.NewReader(strSQL);
            //carrega lista de salas:
            if (oDB.MensagemUltimoComando.ToString() == "Erro")
            {
                string retorno_xml = oDB.MensagemUltimoComando.ToString();
                string pagina = "Efetuar_Reserva.aspx";
                retorna_erro = Tr_Error.Grava_Excecao("user1", "user1", retorno_xml, strSQL, pagina);
                Response.Redirect("Mensagens.aspx?codigo=2&parametro=" + retorna_erro + "&botao_ok=S&acao_ok=Apresentacao.aspx");
            }

            if (ds_sala != null)
            {
                while (ds_sala.Read())
                {
                    //carrega dropdownlist dinamicamente:
                    drp_sala.Items.Add(new ListItem(ds_sala["descricao"].ToString(), ds_sala["codsala"].ToString()));
                }
            }
            ds_acompanha.Close();
        }

    }

    protected void Btn_img_Avancar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Efetuar_Reserva_Processa.aspx?Acompanhamento=" + drp_acompanhamento.SelectedValue.ToString() +"&Sala="+drp_sala.SelectedValue.ToString()+ "&Data=" + txt_datareserva.Text.ToString().Replace("/", "-") + "&Hora=" + drp_hora.Text.ToString());
    }
}
    
    

