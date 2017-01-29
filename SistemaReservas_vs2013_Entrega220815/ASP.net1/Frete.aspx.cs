using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Correios;

public partial class Frete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*       
            Referencias:
            http://ws.correios.com.br/calculador/CalcPrecoPrazo.asmx?op=CalcPrecoPrazo
            http://devbrasil.net/profiles/blogs/calculo-de-frete-com-webservice-dos-correios 
         */
    }

    protected void btn_calc_frete_click(object sender, EventArgs e)
    {
        //40010 = Sedex
        //41106 = PAC
        decimal frete = CalculaFrete(txt_cep_origem.Text, 41106, 50, 50, 20, 100, 10);
        lbl_valor.Text = frete.ToString();
        //teste2
    }

    private decimal CalculaFrete(string nuCepDestino, int Servico, decimal nVlComprimento, 
                                 decimal nVlAltura, decimal nVlLargura, decimal nVlDiametro, decimal nuPeso)
    {               
        // Dados da empresa, se tiver contrato com os Correios
        string nCdEmpresa = string.Empty;
        string sDsSenha = string.Empty;
        // Código do tipo de frete – Sedex ou PAC 
        //40010 = Sedex
        //41106 = PAC
        string nCdServico = Servico.ToString();
        // Cep de origem e destino - apenas números
        string sCepOrigem = "89206100";
        string sCepDestino = nuCepDestino;
        // Peso total da encomenda
        string nVlPeso = nuPeso.ToString();
        // Formato da encomenda
        int nCdFormato = 1; //Caixa
        // Informa se é por mão própria
        string sCdMaoPropria = "N";
        // Valor declarado
        decimal nVlValorDeclarado = 0; //não informado - padrao
        // Se desejo receber aviso de recebimento
        string sCdAvisoRecebimento = "N"; //por padrao não

        // Instância o WebService
        //ae \0/
        Correios.CalcPrecoPrazoWS webserviceCorreios = new Correios.CalcPrecoPrazoWS();

        // Efetua a requisição
        Correios.cResultado retornoCorreios = webserviceCorreios.CalcPrecoPrazo(nCdEmpresa, sDsSenha, nCdServico, sCepOrigem, sCepDestino, nVlPeso, nCdFormato, nVlComprimento, nVlAltura, nVlLargura, nVlDiametro, sCdMaoPropria, nVlValorDeclarado, sCdAvisoRecebimento);

        if (retornoCorreios.Servicos.Length > 0)
        {
            //caso tudo certo entao retorna o valor:
            if (retornoCorreios.Servicos[0].Erro == "0")
            {
                lbl_prazo.Text = "dias: " + retornoCorreios.Servicos[0].PrazoEntrega;
                return decimal.Parse(retornoCorreios.Servicos[0].Valor);
            }
            else
            {
                string MsgErro = retornoCorreios.Servicos[0].MsgErro;
                lbl_erro.Text = MsgErro;
                return 0;
            }
        }
        else
        {
            throw new Exception("Não foi possivel consulta o frete");
            return 0;
        }

        return 0;
    }
}