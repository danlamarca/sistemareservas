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
using Uol.PagSeguro.Constants;
using Uol.PagSeguro.Domain;
using Uol.PagSeguro.Service;
using Uol.PagSeguro.Resources;


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

                //exemplo de carregamento da classe de Credenciais:
                AccountCredentials credencias = new AccountCredentials(email, token); 
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