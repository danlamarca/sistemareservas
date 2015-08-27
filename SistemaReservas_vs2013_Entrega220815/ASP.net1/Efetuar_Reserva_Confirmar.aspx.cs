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
        //if (btn_tal == "OK")
        //{
        //    Response.Redirect("Mensagens.aspx?codigo=1&parametro=1"  + "&botao_ok=S&acao_ok=Apresentacao.aspx");
        //}
    }


      
}
