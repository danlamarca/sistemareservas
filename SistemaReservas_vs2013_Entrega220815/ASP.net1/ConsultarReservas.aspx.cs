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
using System.Text;
using Library1;

public partial class Recuperar_cesta : System.Web.UI.Page
{
    ClsBancoDeDados oDB = new ClsBancoDeDados();
    Tratamento_Erros Tr_Error = new Tratamento_Erros();
    Valicoes_num Val_num = new Valicoes_num();

    //variavies globais
    string strSQL;
    int retorna_erro;


    protected void Page_Load(object sender, EventArgs e)
    {
        Session["CGC"] = "64968218000117";
        Session["Matricula"] = "0123";
        //session responsavel por resgatar o numero da cesta interrompida
        Session["numped_recuperar_cesta_processa"] = null;

      
        if (!IsPostBack)
        {
            //VERIFICAÇÕES:
            //Exclui cestas em aberto sem itens relacionados:
            strSQL = "exec SP_DEL_TB_CESTA_semitens_recuperar_cesta_aspx ";
            oDB.Execute(strSQL);
            if (oDB.MensagemUltimoComando.ToString() == "Erro")
            {
            string retorno_xml = oDB.MensagemUltimoComando.ToString();
            string pagina = "Recuperar_Pedido.aspx";
            retorna_erro = Tr_Error.Grava_Excecao(Session["CGC"].ToString(), Session["Matricula"].ToString(), retorno_xml, strSQL, pagina);
            Response.Redirect("Mensagens.aspx?codigo=4&parametro=" + retorna_erro + "&botao_ok=S&acao_ok=Apresentacao.aspx");

            }
     

            //verifica a exclusão da cesta em andamento:
            if (Request["pedido_exclui"] != null && Request["pedido_exclui"] != "")
            {
                strSQL = "exec SP_EXCL_TB_PEDIDO_NUMEROS_recuperar_cesta_aspx " + Request["pedido_exclui"].ToString().Trim();
                oDB.Execute(strSQL);
                if (oDB.MensagemUltimoComando.ToString() == "Erro")
                {
                    string retorno_xml = oDB.MensagemUltimoComando.ToString();
                    string pagina = "Recuperar_cesta.aspx";
                    retorna_erro = Tr_Error.Grava_Excecao(Session["CGC"].ToString(), Session["Matricula"].ToString(), retorno_xml, strSQL, pagina);
                    Response.Redirect("Mensagens.aspx?codigo=4&parametro=" + retorna_erro + "&botao_ok=S&acao_ok=Apresentacao.aspx");
                }
                Bind_Lista(); 
            }
        }

    }
    //final page load

    protected void btn_buscar_ped_click(object sender, EventArgs e)
    {
        //Response.Write(drp_tipo_pesq.Text.ToString());  
        Bind_Lista();
    }

    protected void Bind_Lista()
    {
        string data_ini = null;
        string data_fim = null;
        string dia_ini = null;
        string mes_ini = null;
        string ano_ini = null;
        string ano_fim = null;
        string mes_fim = null;
        string dia_fim = null;
        string tipo_pesquisa = null;
        string chave_busca_pesq = null;

        //recupera filtro;
        dia_ini = txt_ini_dia.Text.ToString();
        mes_ini = txt_ini_mes.Text.ToString();
        ano_ini = txt_ini_ano.Text.ToString();
        dia_fim = txt_fim_dia.Text.ToString();
        mes_fim = txt_fim_mes.Text.ToString();
        ano_fim = txt_fim_ano.Text.ToString();
        tipo_pesquisa = drp_tipo_pesq.Text.ToString();
        chave_busca_pesq = chaveBusca.Text.ToString();

        //CORRIGIR PARA FORMATO DIA-MES-ANO
        data_ini = dia_ini + '-' + mes_ini + '-' + ano_ini;
        data_fim = dia_fim + '-' + mes_fim + '-' + ano_fim;

        //trata filtro:
        if (Val_num.IsInt(chave_busca_pesq.Trim()) == false && chave_busca_pesq.Trim() != "")
        {
            chave_busca_pesq = null;
            if (drp_tipo_pesq.Text.ToString() == "1")
            {
                Lbl_no_result.Text = "Numero de pedido inválido";
                Lbl_no_result.Visible = true;
            }
            else
            {
                Lbl_no_result.Text = "Parametros de pesquisa inválido";
                Lbl_no_result.Visible = true;
            }

        }
        else if (chave_busca_pesq.Trim() == "")
        {
            chave_busca_pesq = null;
            Lbl_no_result.Text = "";
            Lbl_no_result.Visible = false;
        }
        else
        {
            Lbl_no_result.Text = "";
            Lbl_no_result.Visible = false;
        }


        //valida datas:
        if (Val_num.IsDate(data_ini) == false)
        {
            data_ini = null;
        }
        if (Val_num.IsDate(data_fim) == false)
        {
            data_fim = null;
        }


        strSQL = "exec SP_SEL_TB_PEDIDOS_NUMEROS_recuperar_cesta_aspx '" + Session["CGC"] + "','" + chave_busca_pesq + "','" + data_ini + "','" + data_fim + "'";
        DataSet ds_cesta = oDB.NewDataSet(strSQL);
        if (oDB.MensagemUltimoComando.ToString() == "Erro")
        {
            string retorno_xml = oDB.MensagemUltimoComando.ToString();
            string pagina = "Recuperar_cesta.aspx";
            retorna_erro = Tr_Error.Grava_Excecao(Session["CGC"].ToString(), Session["Matricula"].ToString(), retorno_xml, strSQL, pagina);
            Response.Redirect("Mensagens.aspx?codigo=4&parametro=" + retorna_erro + "&botao_ok=S&acao_ok=Apresentacao.aspx");
        }

        if (ds_cesta != null)
        {
            Gd_Lista_Pesquisa.DataSource = ds_cesta;
            Gd_Lista_Pesquisa.DataBind();
            Gd_Lista_Pesquisa.Visible = true;

            if (Gd_Lista_Pesquisa.Rows.Count == 0)
            {
                Lbl_no_result.Text = "Consulta não retornou nada!";
                Gd_Lista_Pesquisa.Visible = false;
                Lbl_no_result.Visible = true;
            }
        }

    }

    //Propriedade de paginação:
    public void Gd_Lista_Pesquisa_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gd_Lista_Pesquisa.PageIndex = e.NewPageIndex;
        Bind_Lista();
    }
    //final do grid view lista cesta



    protected void Btn_img_abrir_click(object sender, EventArgs e)
    {
        //Crio evento dinamico para o ImageButton, desta forma selecionando o id do pedido correspondente
        System.Web.UI.WebControls.ImageButton Img_Selecione = (System.Web.UI.WebControls.ImageButton)sender;
        GridViewRow Gvd_Selecione = (GridViewRow)Img_Selecione.NamingContainer;
        Int32 indice_linha = Gvd_Selecione.RowIndex;

        //2.Para a linha selecionada, resgata o id do pedido contido na coluna(indice) respectiva:
        string Str_Pedido_Num = (String)Gd_Lista_Pesquisa.Rows[indice_linha].Cells[2].Text.ToString();

        //MessageBox.Show(Str_Pedido_Num);
        //Response.Redirect("Pesquisar_Pedido_Exibe.aspx?pedido=" + Str_Pedido_Num);
        Response.Redirect("Recuperar_cesta_processa.aspx?pedido=" + Str_Pedido_Num);
    }

    protected void Btn_img_excluir_click(object sender, EventArgs e)
    {
        //Crio evento dinamico para o ImageButton, desta forma selecionando o id do pedido correspondente
        System.Web.UI.WebControls.ImageButton Img_Selecione = (System.Web.UI.WebControls.ImageButton)sender;
        GridViewRow Gvd_Selecione = (GridViewRow)Img_Selecione.NamingContainer;
        Int32 indice_linha = Gvd_Selecione.RowIndex;

        //2.Para a linha selecionada, resgata o id do pedido contido na coluna(indice) respectiva:
        string Str_Pedido_Num = (String)Gd_Lista_Pesquisa.Rows[indice_linha].Cells[2].Text.ToString();

        Response.Redirect("Mensagens.aspx?codigo=10&parametro="+Str_Pedido_Num+"&botao_sim=S&botao_nao=S&acao_sim=Recuperar_cesta.aspx?pedido_exclui="+Str_Pedido_Num+"&acao_nao=Recuperar_cesta.aspx");
    }

}
