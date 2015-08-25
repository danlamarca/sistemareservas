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

public partial class Mensagens : System.Web.UI.Page
{
    ClsBancoDeDados oDB = new ClsBancoDeDados();
    Tratamento_Erros Tr_Error = new Tratamento_Erros();
    Valicoes_num Val_Num_int = new Valicoes_num();

    //variaveis
    string strSQL;
    int retorna_erro;
    string codigo_msg;
    string msg;
    string parametro;
    string acao_ok;
    string acao_sim;
    string acao_nao;
    string botao_ok;
    string botao_sim;
    string botao_nao;

    protected void Page_Load(object sender, EventArgs e)
    {
        //parametros (cod_msg,parametros,acao_ok,acao_sim,acao_nao,botao_ok,botao_sim,botao_nao)
        //ex1: Response.Redirect("Mensagens.aspx?codigo=1&botao_ok=S&acao_ok=Efetuar_Compra.aspx")
        //ex2: Response.Redirect("Mensagens.aspx?codigo=1&botao_ok=S&acao_ok=Efetuar_Compra.aspx?pedido=S")
        //ex3: string pedido = "9"; Response.Redirect("Mensagens.aspx?codigo=2&parametro=" + pedido + "&botao_ok=S&acao_ok=Efetuar_Compra.aspx");
        //ex4: mensagem de erro: Response.Redirect("Mensagens.aspx?codigo=4&parametro="+retorna_erro+"&botao_ok=S&acao_ok=Apresentacao.aspx");
        //messagem: O processo de transformar a lista [PARAM_1] em publica só será efetuado após as 00:00

        if (!IsPostBack)
        {
            if (Request["codigo"] != null && Request["codigo"] != "")
            {
                codigo_msg = Request["codigo"].ToString().Trim();
                //preenche o codigo da msg
                lbl_codigo.Text = codigo_msg;
                lbl_codigo.Visible = true;
            }

            if (Request["parametro"] != null && Request["parametro"] != "")
            {
                parametro = Request["parametro"].ToString().Trim();
            }

            if (Request["acao_ok"] != null && Request["acao_ok"] != "")
            {
                acao_ok = Request["acao_ok"].ToString().Trim();
            }

            if (Request["acao_sim"] != null && Request["acao_sim"] != "")
            {
                acao_ok = Request["acao_sim"].ToString().Trim();
            }

            if (Request["acao_nao"] != null && Request["acao_nao"] != "")
            {
                acao_ok = Request["acao_nao"].ToString().Trim();
            }

            if (Request["botao_ok"] != null && Request["botao_ok"] != "")
            {
                botao_ok = Request["botao_ok"].ToString().Trim();
            }

            if (Request["botao_sim"] != null && Request["botao_sim"] != "")
            {
                botao_sim = Request["botao_sim"].ToString().Trim();
            }

            if (Request["botao_nao"] != null && Request["botao_nao"] != "")
            {
                botao_nao = Request["botao_nao"].ToString().Trim();
            }

            //caso o codigo da mensagem não seja preenchido
            if (codigo_msg == null && codigo_msg == "")
            {
                codigo_msg = "0";
            }

            strSQL = "exec SP_SEL_TB_MENSAGEM " + codigo_msg;
            DataTableReader ds_msg = oDB.NewReader(strSQL);
            if (oDB.MensagemUltimoComando.ToString() == "Erro")
            {
                string retorno_xml = oDB.MensagemUltimoComando.ToString();
                string pagina = "Mensagens.aspx";
                retorna_erro = Tr_Error.Grava_Excecao(Session["CGC"].ToString(), Session["Matricula"].ToString(), retorno_xml, strSQL, pagina);
                MessageBox.Show("Erro no Processamento da Página, favor informar o codigo do erro ao responsável: Danilo Moreira, tel.: 11-953648750,email: danilo.lamarca@hotmail.com. Codigo do ERRO: " + retorna_erro);
                Response.Redirect("Apresentacao.aspx");
            }
            if (ds_msg != null)
            {
                //preenche a mensagem
                while (ds_msg.Read())
                {
                    if (parametro != null && parametro != "")
                    {
                        msg = ds_msg["descricao"].ToString();
                        msg = msg.Replace("[PARAM1]", parametro);
                        lbl_msg.Text = msg;
                        lbl_msg.Visible = true;
                    }
                    else
                    {
                        msg = ds_msg["descricao"].ToString();
                        lbl_msg.Text = msg;
                        lbl_msg.Visible = true;
                    }
                }
            }
            ds_msg.Close();


            //trata os botões:
            //OK
            if (botao_ok == "S")
            {
                Btn_img_ok.Visible = true;
            }
            else
            {
                Btn_img_ok.Visible = false;
            }

            //Sim
            if (botao_sim == "S")
            {
                Btn_img_sim.Visible = true;
            }
            else
            {
                Btn_img_sim.Visible = false;
            }

            //Nao
            if (botao_nao == "S")
            {
                Btn_img_nao.Visible = true;
            }
            else
            {
                Btn_img_nao.Visible = false;
            }



        }//final postback

    }//final page load


    protected void Btn_img_sim_click(object sender, EventArgs e)
    {
        acao_sim = Request["acao_sim"].ToString().Trim();
        if (acao_sim != null && acao_sim != "")
        {
            Response.Redirect(acao_sim);
        }
        else
        {
            Response.Redirect("Apresentacao.aspx");
        }
    }

    protected void Btn_img_ok_click(object sender, EventArgs e)
    {
        acao_ok = Request["acao_ok"].ToString().Trim();
        if (acao_ok != null && acao_ok != null)
        {
            Response.Redirect(acao_ok);
        }
        else
        {
            Response.Redirect("Apresentacao.aspx");
        }
    }

    protected void Btn_img_nao_click(object sender, EventArgs e)
    {
        acao_nao = Request["acao_nao"].ToString().Trim();
        if (acao_nao != null && acao_nao != "")
        {
            Response.Redirect(acao_nao);
        }
        else
        {
            Response.Redirect("Apresentacao.aspx");
        }
    }
}
