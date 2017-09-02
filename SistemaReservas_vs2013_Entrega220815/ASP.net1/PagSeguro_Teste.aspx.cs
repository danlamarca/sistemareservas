using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Xml;
using Library1;
using Uol.PagSeguro;
using Uol.PagSeguro.Constants;
using Uol.PagSeguro.Domain;
using Uol.PagSeguro.Service;
using Uol.PagSeguro.Resources;
using System.Web.UI;
using Library1.BO;
using System.Windows.Forms;

public partial class PagSeguro_Teste : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            #region Sessões
            //sessao que transitará por toda a aplicação, com o id da transação
            Session["sessionResponse"] = "";
            #endregion

            #region javascript
            //btn_pagseguro.Attributes.Add("onclick", "var texto = document.getElementById('lbl_teste'); texto.innerHTML = 'Treinamento!'; alert('oi')");
            #endregion

            Produto produto = new Produto();
            produto.ID_PRODUTO = 1;
            produto.NOME = "Vassoura";
            produto.DESCRICAO = "Serviços Internos";
            produto.VALOR = 50;

            lbl_descricao.Text = produto.DESCRICAO;
            lbl_id.Text = produto.ID_PRODUTO.ToString();
            lbl_nome.Text = produto.NOME;
            lbl_valorr.Text = produto.VALOR.ToString();

            //setando os dados do form:

            
            
        }
    }

    protected void Recupera_ID_Sessao()
    {//tecnlogia WebClient

        try
        {
            XmlDocument xmlRetorno = new XmlDocument();

            //As informações de email e token devem estar em um arquivo xml(na raiz da aplicação) ou vir do BD, com os dados do VENDEDOR
            string email = "lamarca.danilo@gmail.com";
            string token = "5ABF5EC16FA6433BBD38FD9990128240";
            string urlAddress = "https://ws.sandbox.pagseguro.uol.com.br/v2/sessions";            

            using (WebClient client = new WebClient())
            {
                NameValueCollection postData = new NameValueCollection()
                {
                    {"email",email},
                    {"token",token}
                };

                string retorno = Encoding.UTF8.GetString(client.UploadValues(urlAddress, postData));
                xmlRetorno.LoadXml(retorno);                
            }

            if (xmlRetorno.InnerXml != "")
            {
                XmlNodeList elemento = xmlRetorno.GetElementsByTagName("id");
                Session["sessionResponse"] = elemento[0].InnerXml;

                //exemplo de carregamento da classe de Credenciais do Vendedor:
                AccountCredentials CREDENCIAIS = new AccountCredentials(email, token);
                string ID_SESSAO = Session["sessionResponse"].ToString();
                
                //ver biblioteca PagSeguro js na MasterPage, segue chamada desta funcao obrigatoria:
                //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "TScript", "PagSeguroDirectPayment.setSessionId('" + Session["sessionResponse"].ToString() + "'); var senderHash = PagSeguroDirectPayment.getSenderHash(); alert(senderHash)", true);
               // ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "TScript", "$("#getSenderHash").click(function(){var senderHash = PagSeguroDirectPayment.getSenderHash();console.log(senderHash);$("input#senderHash").val(senderHash);})", true);
            }

        }
        catch (ArgumentException ex)
        { 
            throw new ArgumentException("Ocorreu um erro ao efetuar o pagamento: " + ex.ToString());
        }
    }

    protected void btn_pagseguro_onclick(object sender, EventArgs e)
    {
        Recupera_ID_Sessao();
    }
 
}